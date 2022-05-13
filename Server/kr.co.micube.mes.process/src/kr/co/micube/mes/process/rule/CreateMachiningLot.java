package kr.co.micube.mes.process.rule;

import java.text.ParseException;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.LotType;
import kr.co.micube.common.mes.constant.ProcessClass;
import kr.co.micube.common.mes.constant.WorkorderState;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.mes.service.SfWorkorderService;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfLotKey;
import kr.co.micube.common.mes.so.SfWorkorderData;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.common.util.QueryProvider;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 가공
 * 설               명	: 가공 LOT 생성
 * 				작업지시 정보에 기반해 LOT을 생성한다.
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-05-25
 * 수   정   이   력	: 
 * 				  
 */

public class CreateMachiningLot extends DatasetRule {
	
	// 트랜잭션 정보
	private TxnInfo txnInfo;
	
	// 파라미터
	private String workorderId;			// 작업지시번호
	private Double createQty;			// 수량 
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		validateWorkorderIsNotCanceled(this.workorderId);
		SfWorkorderService.validateProcessClass(this.workorderId, ProcessClass.MACHINING);	// 기계가공 작업지시인지 검증
		SfLotData lotData = SfLotService.createLot(this.workorderId, LotType.NORMAL, getQtyToCreate(), this.txnInfo);
		SfLotKey lotKey = lotData.key();
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
		this.createQty = body.getDouble("createqty");
	}
	
	// 클라이언트에 생성된 LOT ID 반환
	private void returnLotId(String lotId) {
		Map<String, Object> result = new HashMap<String, Object>();
		result.put("LOTID", lotId);
		IDataSet ds = this.getResponseDataset();
		IDataTable dt = ds.addTable("DATA");
		dt.addRow(result);
	}
	
	private Double getQtyToCreate() throws SystemException {
		SfWorkorderData woData = SfWorkorderService.getWorkorder(this.workorderId);
		Double createdQty = getLotCreatedQtyOfWorkorder();
		Double remainQty = woData.getOrderqty() - createdQty;
		Double qty = Math.min(remainQty, this.createQty);
		if(qty <= 0D) {
			// 이미 작업지시 수량만큼 LOT을 생성했습니다.
			throw new SystemException("LotAlreadyCreatedWorkorderPlanQty");
		}
		return qty;
	}
	
	private Double getLotCreatedQtyOfWorkorder() throws DatabaseException {
		Map<String, Object> param = new HashMap<String, Object>();
		param.put("WORKORDERID", this.workorderId);
		List<Map<String, Object>> result = QueryProvider.select("GetLotCreatedQtyOfWorkorder", "00001", param);
		if(result.size() > 0) {
			return Double.valueOf(result.get(0).get("QTY").toString());
		}
		return 0D;
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
