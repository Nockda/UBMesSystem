package kr.co.micube.mes.process.rule;

import java.text.ParseException;
import java.util.HashMap;
import java.util.Map;

import kr.co.micube.common.mes.constant.WorkorderState;
import kr.co.micube.common.mes.service.SfConsumableLotService;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.mes.service.SfWorkorderService;
import kr.co.micube.common.mes.service.UlSubProcessWorkResultService;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfWorkorderData;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.data.StateModelCache;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 조립
 * 설               명	: 취소된 작업지시의 LOT 폐기
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-07-06
 * 수   정   이   력	: 
 * 				  
 */

public class TerminateLotOfCanceledWorkorder extends DatasetRule {

	// 트랜잭션 정보
	private TxnInfo txnInfo;

	// 파라미터
	private String lotId; 	// LOT ID
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		SfLotData lotData = SfLotService.getLot(this.lotId);
		validateIsWorkorderCanceled(lotData.getWorkorderid());	// 작업지시 취소여부 확인
		validateIsLotStateInProduction(lotData.getLotstate());	// LotState 확인
		UlSubProcessWorkResultService.validateUnFinishedResultNotExists(this.lotId, lotData.getProcesssegmentid());	// 세부공정 작업완료여부 확인
		terminateLot(lotData);	// LOT 폐기
		SfConsumableLotService.cancelAllInputConsumablelot(this.lotId, this.txnInfo);	// 가투입	자재 투입취소
	}

	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);

		// 파라미터
		this.lotId = body.getString("lotid");
	}
	
	// 작업지시 취소여부 확인
	private void validateIsWorkorderCanceled(String workorderId) throws SystemException {
		SfWorkorderData woData = SfWorkorderService.getWorkorder(workorderId);
		if(!WorkorderState.CANCEL.equals(woData.getState())) {
			// 취소된 작업지시의 LOT만 폐기할 수 있습니다. {0}
			throw new SystemException("WorkorderIsNotCanceled", String.format("WorkorderId=%s", workorderId));
		}
	}
	
	// LotState 확인
	private void validateIsLotStateInProduction(String lotState) throws SystemException {
		if(!Constant.LOTSTATE_INPRODUCTION.equals(lotState)) {
			// InProduction 상태의 LOT만 폐기할 수 있습니다. {0}
			throw new SystemException("OnlyInProductionLotCanBeTerminated", String.format("LotState=%s", lotState));
		}
	}
	
	// LOT 폐기
	// NOTE : ProcessState = Run 인 LOT을 Terminate 해야하기 때문에 Factory API 사용 불가
	private void terminateLot(SfLotData lotData) throws Throwable {
		
		Map<String, Object> result = new HashMap<String, Object>();
		result.put("LOTID", lotId);
		IDataSet ds = this.getResponseDataset();
		IDataTable dt = ds.addTable("DATA");
		dt.addRow(result);

	    Map<String, Object> parameter = new HashMap<String, Object>();
	    parameter.put("PREVLOTSTATE", lotData.getLotstate());
	    lotData.setLotstate(StateModelCache.getToStateName("LotState", lotData.getLotstate(), "terminateLot"));
	    lotData.txnInfo().set(this.txnInfo.getTransaction());
	    lotData.appendHistoryData(parameter);
	    lotData.update();
	}
}
