package kr.co.micube.mes.process.rule;

import java.text.ParseException;
import java.util.HashMap;
import java.util.Map;

import kr.co.micube.common.mes.constant.LotType;
import kr.co.micube.common.mes.constant.ProcessClass;
import kr.co.micube.common.mes.constant.ProcessDefinition;
import kr.co.micube.common.mes.constant.WorkorderState;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.mes.service.SfProductDefinitionService;
import kr.co.micube.common.mes.service.SfWorkorderService;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfLotKey;
import kr.co.micube.common.mes.so.SfProductdefinitionData;
import kr.co.micube.common.mes.so.SfWorkorderData;
import kr.co.micube.common.mes.so.UlXmanageData;
import kr.co.micube.common.mes.so.UlXmanageKey;
import kr.co.micube.common.mes.util.CommonUtils;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.support.ISQLDataList;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 수리
 * 설               명	: 수리 LOT 생성
 * 				작업지시 정보에 기반해 LOT을 생성하고, 라우팅을 수리 라우팅으로 변경한다.
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-05-22
 * 수   정   이   력	: 
 * 				  
 */

public class CreateRepairLot extends DatasetRule {

	// 트랜잭션 정보
	private TxnInfo txnInfo;
	
	// 파라미터
	private String workorderId;			// 작업지시번호
	private String processSegmentId;	// 공정코드
	private String lotCreateRuleId;		// LOT ID 채번규칙
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		validateWorkorderIsNotCanceled(this.workorderId);
		validateIsLotAlreadyExists();	// 한 작업지시에 1 LOT만 생성가능
		SfWorkorderService.validateProcessClass(this.workorderId, ProcessClass.REPAIR);		// 수리 작업지시인지 검증
		SfWorkorderData woData = SfWorkorderService.getWorkorder(this.workorderId);
		SfProductdefinitionData prodDefData = SfProductDefinitionService.getProductdefinition(woData.getProductdefid(), woData.getProductdefversion());
		String lotId = null;
		if(ProcessDefinition.REPAIR.equals(prodDefData.getProcessdefid())) {	// 수리
			lotId = prodDefData.getPartnumber();
			
			UlXmanageData xd = new UlXmanageData();
			UlXmanageKey xdKey = xd.key();
			
			xdKey.setXnumber(lotId);
			xd = xd.selectOne();
			
			if(xd != null)
			{
				xd.setOrdernumber(this.workorderId);
				xd.setProgressstate("Working");
				xd.update();
			}
		}
		else { // 개조
			lotId = CommonUtils.GenerateLotid(woData.getProductdefid(), this.processSegmentId, this.txnInfo, Constant.EMPTY, this.lotCreateRuleId);
		}
		SfLotData lotData = SfLotService.createLot(lotId, this.workorderId, LotType.NORMAL, woData.getOrderqty(), this.txnInfo);
		SfLotKey lotKey = lotData.key();
		SfWorkorderService.start(this.workorderId, this.txnInfo);
		returnLotId(lotKey.getLotid());
	}
	
	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);
		 
		// 파라미터
		this.workorderId = body.getString("workorderid");
		this.processSegmentId = body.getString("processsegmentid");
		this.lotCreateRuleId = body.getString("lotcreateruleid");
	}
	
	private void validateIsLotAlreadyExists() throws SystemException {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfLotData.Workorderid, this.workorderId);
		SfLotData lotData = new SfLotData();
		ISQLDataList<SfLotData> result = lotData.select(cond);
		if(result.size() > 0) {
			// 이미 LOT이 생성된 작업지시 입니다.
			throw new SystemException("WorkorderAlreadyHasLot");
		}
	}
	
	// 클라이언트에 생성된 LOT ID 반환
	private void returnLotId(String lotId) {
		Map<String, Object> result = new HashMap<String, Object>();
		result.put("LOTID", lotId);
		IDataSet ds = this.getResponseDataset();
		IDataTable dt = ds.addTable("DATA");
		dt.addRow(result);
	}
	
	// 작업지시가 취소되었는지 확인
	private void validateWorkorderIsNotCanceled(String workorderId) throws SystemException {
		SfWorkorderData woData = SfWorkorderService.getWorkorder(workorderId);
		if(WorkorderState.CANCEL.equals(woData.getState())) {
			// 작업지시가 취소되어 LOT을 생성할 수 없습니다. {0}
			throw new SystemException("CantCreateLotWithCanceledWorkorder", String.format("WorkorderId=%s", workorderId));
		}
		if(!Constant.VALIDSTATE_VALID.equals(woData.getValidstate())) {
			// 작업지시가 삭제되어 LOT을 생성할 수 없습니다. {0}
			throw new SystemException("CantCreateLotWithDeletedWorkorder", String.format("WorkorderId=%s", workorderId));
		}
		if(WorkorderState.CLOSE.equals(woData.getState())) {
			// 작업지시가 완료되어 LOT을 생성할 수 없습니다. {0}
			throw new SystemException("CantCreateLotWithClosedWorkorder", String.format("WorkorderId=%s", workorderId));
		}
	}
}
