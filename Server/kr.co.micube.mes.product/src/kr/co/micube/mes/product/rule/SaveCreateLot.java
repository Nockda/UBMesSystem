package kr.co.micube.mes.product.rule;

import java.sql.SQLException;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.ProcessClass;
import kr.co.micube.common.mes.constant.WorkorderState;
import kr.co.micube.common.mes.service.SfProductDefinitionService;
import kr.co.micube.common.mes.so.SfProcesssegmentData;
import kr.co.micube.common.mes.so.SfProcesssegmentKey;
import kr.co.micube.common.mes.so.SfProductdefinitionData;
import kr.co.micube.common.mes.so.SfWorkorderData;
import kr.co.micube.common.mes.so.SfWorkorderKey;
import kr.co.micube.common.mes.so.UlXmanageData;
import kr.co.micube.common.mes.so.UlXmanageKey;
import kr.co.micube.common.mes.util.CommonUtils;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.common.util.QueryProvider;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.so.LotData;
import kr.co.micube.commons.factory.so.ProcessdefinitionData;
import kr.co.micube.commons.factory.standard.info.CreateLotInfo;
import kr.co.micube.commons.factory.standard.info.StartLotInfo;
import kr.co.micube.commons.factory.standard.service.LotService;
import kr.co.micube.commons.factory.standard.service.ProcessDefinitionService;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 생산지지조회
 * 설               명	: 생산지시에서 Lot을 생성 한다.
 * 생      성      자	: 배선용
 * 생      성      일	: 2020-05-19
 * 수   정   이   력	: 
 */
public class SaveCreateLot extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		//IDataSet ds = this.getRequestDataset();
		IMessage msg = this.getMessage().get();
		
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);
		
		String WorkOrderID = body.getString("workOrderid");
		Double InputQty = body.getDouble("inputQty");
		//String Worker = body.getString("worker");
		String productdefid = body.getString("productDefid");
		String processsegmentid = body.getString("processSegmentid");
		String userLot = body.getString("userLot");
		
		
		//라우팅 등록 여부 체크
		
		//투입수량 체크
		
		//조립 공정여부 체크
		
		//Lot Size 체크

		SfWorkorderData wd = new SfWorkorderData();
		SfWorkorderKey wdkey = wd.key();
		
		wdkey.setWorkorderid(WorkOrderID);
		
		wd = wd.selectOne();
		
		if(wd == null)
		{
			// 등록되지 않은 작업지시 입니다.
			throw new SystemException("WorkorderNotExists");
		}

		if(!wd.getState().equals(WorkorderState.PROCESS))
		{
			// 진행상태의 작업지시에서만 LOT을 생성할 수 있습니다.
			throw new SystemException("OnlyProcessWorkorderCanCreateLot");
		}
		if(!Constant.VALIDSTATE_VALID.equals(wd.getValidstate())) {
			// 작업지시가 삭제되어 LOT을 생성할 수 없습니다. {0}
			throw new SystemException("CantCreateLotWithDeletedWorkorder", String.format("WorkorderId=%s", WorkOrderID));
		}
		
		SfProductdefinitionData prodDefData = SfProductDefinitionService.getProductdefinition(productdefid, Constant.ASTERISK);
		String areaId = prodDefData.getAreaid();
		if(StringUtils.isNullOrEmpty(areaId)) {
			// 품목정보에 작업장이 지정되지 않았습니다.
			throw new SystemException("AreaIsNotSpecified");
		}
		ProcessdefinitionData processDefData = ProcessDefinitionService.getProcessDef(prodDefData.getProcessdefid(), prodDefData.getProcessdefversion());
		if(processDefData == null) {
			// 품목정보에 라우팅이 지정되지 않았습니다.
			throw new SystemException("RoutingIsNotSpecified");
		}
		if(ProcessClass.ASSEMBLY.equals(processDefData.getProcessclassid()) && StringUtils.isNullOrEmpty(prodDefData.getSpecdefid())) {
			// 품목정보에 SPEC이 지정되지 않았습니다.
			throw new SystemException("SpecIsNotSpecified");
		}
		
		
		// 클라이언트에서 작업지시수량 체크하지만 서버에서 한번 더 체크
		
		Map<String, Object> param = new HashMap<String, Object>();
		param.put("WORKORDERID", wdkey.getWorkorderid());
		List<Map<String, Object>> resultMap = QueryProvider.select("GetWorkOrderProcessQTY", "00001", param);
		
		if (resultMap.size() == 0)
		{
			throw new SystemException("WorkorderNotExists");
		}
		else {
			double processQty = Double.parseDouble(resultMap.get(0).get("PROCESSQTY").toString());
			if(InputQty + processQty > wd.getPlanqty()) {
				// 작업 지시수량 초과 되었습니다.
				throw new SystemException("OverWorkOrderQty");
			}
		}
		
		
		
		UlXmanageData xd = new UlXmanageData();
		UlXmanageKey xdkey = xd.key();
		
		xdkey.setXnumber(productdefid);
		xd = xd.selectOne();
		if(xd != null)
		{
			xd.setOrdernumber(WorkOrderID);
			xd.setProgressstate("Working");
			xd.update();
		}
		
		/*
		List<String> argList = new ArrayList<>();
        TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
        String lotid = IdService.createId("PLotNo", 1, argList, txnInfo).get(0);		
        */
		//public static String GenerateLotid(String ProductDefid,String ProcessSegmentID, TxnInfo txninfo,String UserDefine)throws Throwable
		TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
		String lotid = CommonUtils.GenerateLotid(productdefid, processsegmentid, txnInfo, userLot,"");
        
		CreateLotInfo lot = new CreateLotInfo();
		lot.setLotId(lotid);
		lot.setWorkOrderId(wdkey.getWorkorderid());
		lot.setProductionOrderId(wd.getProductionorderid());
		lot.setEnterpriseId(wd.getEnterpriseid());
		lot.setPlantId(wd.getPlantid());
		lot.setParentLotID(lotid);
		lot.setRootLotID(lotid);
		lot.setAreaId(areaId);
		lot.setProductDefId(wd.getProductdefid());
		lot.setProductDefVersion(wd.getProductdefversion());
		lot.setPriority(1);
		lot.setCreatedQty(InputQty);
		lot.setQty(InputQty);
		lot.setDueDate(wd.getPlanendtime());
		
		LotData lotData = LotService.createLot(lot, txnInfo);
		lotData.setCreatedqty(lotData.getQty());
		lotData.update();	// createLot API 에서 CreatedQty 를 설정해주지 못하는 버그가 있어 수동으로 설정
		
		//lot start
		SfProcesssegmentData ps = new SfProcesssegmentData();
		SfProcesssegmentKey psKey = ps.key();
		
		psKey.setProcesssegmentid(processsegmentid);
		psKey.setProcesssegmentversion("*");
		
		ps = ps.selectOne();
		
		if(ps.getIsuseuserlotserial().equals("Y"))
		{
			if(wd.getUserlotserial() == null || wd.getUserlotserial().length() == 0)
			{
				wd.setUserlotserial(userLot);
				wd.update();
			}
		}
		
		StartLotInfo startLot = new StartLotInfo();
		startLot.setLotId(lotid);
		startLot.setQty(InputQty); 
		startLot.setPriority(1);
		startLot.setDueDate(wd.getPlanendtime());
		
		LotService.startLot(startLot, txnInfo);
		
		returnLotId(lotid);	// 클라이언트에 생성된 LOT ID 반환
	}

	// 클라이언트에 생성된 LOT ID 반환
	private void returnLotId(String lotId) {
		Map<String, Object> result = new HashMap<String, Object>();
		result.put("LOTID", lotId);
		IDataSet ds = this.getResponseDataset();
		IDataTable dt = ds.addTable("DATA");
		dt.addRow(result);
	}
}
