package kr.co.micube.mes.process.rule;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

import kr.co.micube.common.mes.constant.ProcessClass;
import kr.co.micube.common.mes.constant.SystemOption;
import kr.co.micube.common.mes.service.SfLotEquipmentService;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.mes.service.UlSubProcessWorkResultService;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.UlSubprocessworkresultData;
import kr.co.micube.common.mes.util.DateFunction;
import kr.co.micube.common.mes.util.MathFunction;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.standard.service.CodeService;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.mes.CodeData;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 조립
 * 설               명	: 조립 세부공정 작업완료
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-05-26
 * 수   정   이   력	: 
 * 				  
 */

public class SubTrackOutAssy extends DatasetRule {
	
	// 트랜잭션 정보
	private TxnInfo txnInfo;
	
	// 파라미터
	private String lotId;					// LOT ID
	private String subProcessSegmentId;		// 세부공정 ID
	private Double workTime;				// 작업시간
	private String comment;					// 특이사항
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		SfLotService.validateLotStateIsInProduction(this.lotId);
		SfLotService.validateProcessClass(this.lotId, ProcessClass.ASSEMBLY);			// 조립 LOT인지 검증
		SfLotData lotData = SfLotService.getLot(this.lotId);
		UlSubprocessworkresultData workResult = UlSubProcessWorkResultService.getSubProcessWorkResult(this.lotId
				, lotData.getProcesssegmentid(), this.subProcessSegmentId);				// 세부공정 작업시작정보 조회
		if(workResult == null) {
			// 세부공정이 작업중 상태가 아닙니다.
			throw new SystemException("SubProcessIsNotRunning");
		}
		Date workEndTime = SQLService.toDate();
		Double workTimeValue = this.workTime; 
		if(this.workTime <= 0D) {
			workTimeValue = MathFunction.round(DateFunction.dateDiffInMinutes(workResult.getWorkstarttime(), workEndTime), 2);
		}
		else {
			CodeData codeData = CodeService.getCode(SystemOption.WORK_TIME_MANUAL_INPUT, SystemOption.CODECLASSID);
			if(Constant.NO.equals(codeData.getDescription())) {
				throw new SystemException("WorkTimeOptionChange");
			}
					
			Calendar cal = Calendar.getInstance(); 
			cal.setTime(workResult.getWorkstarttime());
			cal.add(Calendar.SECOND, (int)Math.round(workTimeValue * 60)); //소수점 처리위해 Second로 처리함.
			
			workEndTime = cal.getTime();
		}
		workResult = UlSubProcessWorkResultService.endSubProcessWorkResult(this.lotId, this.subProcessSegmentId
				, workEndTime, workResult.getWorkstartuser(), workTimeValue, this.comment, this.txnInfo);				// 세부공정 작업완료 처리
		if(!StringUtils.isNullOrEmpty(workResult.getEquipmentid())) {													// 세부공정에서 설비를 사용했으면
			SfLotEquipmentService.endLotEquipment(this.lotId, workResult.getWorkendtime(), this.txnInfo);				// Lot Equipment 완료처리
		}
		UlSubProcessWorkResultService.finishSubProcessWorkResult(this.lotId, this.subProcessSegmentId, this.txnInfo, workResult.getSpecdefidversion());	// 세부공정 실적 확정
	}
	
	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);
		 
		// 파라미터
		this.lotId = body.getString("lotid");
		this.subProcessSegmentId = body.getString("subprocesssegmentid");
		this.workTime = body.getDouble("worktime");
		this.comment = body.getString("comment");
	}
}
