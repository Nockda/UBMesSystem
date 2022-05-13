package kr.co.micube.mes.process.rule;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import kr.co.micube.common.mes.constant.ProcessClass;
import kr.co.micube.common.mes.constant.VirtualEquipmentId;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.mes.service.SfLotWorkerService;
import kr.co.micube.common.mes.service.UlProcessWorkResultService;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.UlProcessworkresultData;
import kr.co.micube.common.mes.util.DateFunction;
import kr.co.micube.common.mes.util.MathFunction;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 수리
 * 설               명	: 수리 작업완료 처리 및 자재투입
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-05-22
 * 수   정   이   력	: 
 * 				  
 */

public class TrackInOutRepair extends DatasetRule {

	// 트랜잭션 정보
	private TxnInfo txnInfo;

	// 파라미터
	private String lotId; 	// LOT ID
	private String userIds;	// 작업자 목록 (콤마로 구분)
	private Date trackInTime;
	private Date trackOutTime;
	private Double workTime;
	private String comment;
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		validateParameter();
		this.txnInfo.setTxnUser(this.userIds.split(",")[0]);
		SfLotService.validateProcessClass(this.lotId, ProcessClass.REPAIR);			// 수리 LOT인지 검증
		SfLotService.validateLotStateIsInProduction(this.lotId);
		SfLotData lotData = SfLotService.getLot(this.lotId);
		UlProcessworkresultData workResultData = UlProcessWorkResultService.getProcessWorkResult(this.lotId, lotData.getProcesssegmentid());
		if(workResultData == null) {		
			SfLotService.trackIn(this.lotId, VirtualEquipmentId.REPAIR, this.txnInfo);
			UlProcessWorkResultService.startProcessWorkResult(this.lotId, VirtualEquipmentId.REPAIR, this.trackInTime, this.userIds.split(",")[0], this.comment, this.txnInfo);
			SfLotWorkerService.createSfLotworker(this.lotId, this.userIds.split(","), Constant.ASTERISK, VirtualEquipmentId.REPAIR, this.txnInfo);
			UlProcessWorkResultService.endProcessWorkResultForRepair(this.lotId, this.trackOutTime, this.workTime, this.userIds.split(",")[0], this.txnInfo);
			SfLotService.trackOut(this.lotId, VirtualEquipmentId.REPAIR, this.txnInfo);
		}
		else {
			// LotWorker 지우고 새로등록
			SfLotWorkerService.deleteSfLotworker(this.lotId);
			SfLotWorkerService.createSfLotworker(this.lotId, this.userIds.split(","), Constant.ASTERISK, VirtualEquipmentId.REPAIR, this.txnInfo);
			
			// 실적정보 업데이트
			String chargeUserId = this.userIds.split(",")[0];
			workResultData.setWorkstarttime(this.trackInTime);
			workResultData.setWorkendtime(this.trackOutTime);
			workResultData.setWorkstartuser(chargeUserId);
			workResultData.setWorkenduser(chargeUserId);
			workResultData.setChargeuserid(chargeUserId);
			workResultData.setWorktime(this.workTime);
			workResultData.setStandardtime(this.workTime);
			workResultData.setComments(this.comment);
			workResultData.txnInfo().set(this.txnInfo.getTransaction());
			workResultData.update();
		}
	}

	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);

		// 파라미터
		this.lotId = body.getString("lotid");
		this.userIds = body.getString("userids");
		this.comment = body.getString("comment");

		SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		this.trackInTime = format.parse(body.getString("trackintime"));
		this.trackOutTime = format.parse(body.getString("trackouttime"));
		this.workTime = body.getDouble("worktime") * 60;	// 분단위로 변환
	}
	
	private void validateParameter() throws SystemException {
		if(StringUtils.isNullOrEmpty(this.userIds)) {
			// 작업자를 입력해주세요.
			throw new SystemException("UserIdRequired");
		}
		if (this.trackInTime.compareTo(this.trackOutTime) > 0) {
			// 완료시간이 시작시간보다 작을 수 없습니다.
			throw new SystemException("StartTimeCantBeAfterEndTime");
		}
	}
}
