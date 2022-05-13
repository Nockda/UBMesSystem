package kr.co.micube.mes.process.rule;

import java.text.ParseException;
import java.text.SimpleDateFormat;

import kr.co.micube.common.mes.constant.ProcessClass;
import kr.co.micube.common.mes.constant.WorkorderState;
import kr.co.micube.common.mes.service.SfConsumableLotService;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.mes.service.SfWorkorderService;
import kr.co.micube.common.mes.service.UlErptmesmatinputService;
import kr.co.micube.common.mes.service.UlErptmesworkreportService;
import kr.co.micube.common.mes.service.UlProcessWorkResultService;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfWorkorderData;
import kr.co.micube.common.mes.so.UlProcessworkresultData;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 수리
 * 설               명	: 수리 완료보고
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-07-16
 * 수   정   이   력	: 
 * 				  
 */

public class DispatchRepair extends DatasetRule {

	// 트랜잭션 정보
	private TxnInfo txnInfo;

	// 파라미터
	private String lotId; 	// LOT ID
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		SfLotData lotData = SfLotService.getLot(this.lotId);
		validateWorkorderIsNotDeleted(lotData.getWorkorderid());
		String processSegmentId = lotData.getProcesssegmentid();
		SfLotService.validateProcessClass(this.lotId, ProcessClass.REPAIR);			// 수리 LOT인지 검증
		validateWorkresult(processSegmentId);										// 완료된 실적이 있는지 검증
		SfConsumableLotService.commitInputConsumablelot(this.lotId, this.txnInfo);
		lotData = SfLotService.dispatch(this.lotId, this.txnInfo);
		if (lotData.getLotstate().equals(Constant.LOTSTATE_FINISHED)) {													// Lot 이 Finished 면
			SfConsumableLotService.createConsumableFromLot(this.lotId, this.txnInfo);									// 자재전환
		}
		// ERP I/F
		String workDate = new SimpleDateFormat("yyyyMMdd").format(SQLService.toDate());									// 작업일자
		UlErptmesworkreportService.createUlErptmesworkreport(this.lotId, processSegmentId, workDate, this.txnInfo);		// 생산실적 ERP I/F
		UlErptmesmatinputService.createUlErptmesmatinput(this.lotId, processSegmentId, workDate, this.txnInfo);			// 생산투입 ERP I/F
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
	
	// 작업실적이 등록되어있는지 확인
	private void validateWorkresult(String processSegmentId) throws SystemException {
		UlProcessworkresultData workResultData = UlProcessWorkResultService.getProcessWorkResult(this.lotId, processSegmentId);
		if(workResultData == null || workResultData.getWorkendtime() == null) {
			// 작업이 완료되지 않았습니다.
			throw new SystemException("LotWorkresultNotEnd");
		}
	}
	
	// 작업지시가 삭제되었는지 확인
	private void validateWorkorderIsNotDeleted(String workorderId) throws SystemException {
		SfWorkorderData woData = SfWorkorderService.getWorkorder(workorderId);
		if(!Constant.VALIDSTATE_VALID.equals(woData.getValidstate())) {
			// 작업지시가 삭제되어 완료보고를 할 수 없습니다. {0}
			throw new SystemException("CantDispatchWithDeletedWorkorder", String.format("WorkorderId=%s", workorderId));
		}
		if(WorkorderState.CLOSE.equals(woData.getState())) {
			// 작업지시가 완료되어 완료보고를 할 수 없습니다. {0}
			throw new SystemException("CantDispatchWithClosedWorkorder", String.format("WorkorderId=%s", workorderId));
		}
	}
}
