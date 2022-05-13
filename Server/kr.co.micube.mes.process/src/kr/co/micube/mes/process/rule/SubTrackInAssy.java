package kr.co.micube.mes.process.rule;

import java.text.ParseException;
import java.util.Date;

import kr.co.micube.common.mes.constant.ProcessClass;
import kr.co.micube.common.mes.constant.VirtualEquipmentId;
import kr.co.micube.common.mes.service.SfEquipmentService;
import kr.co.micube.common.mes.service.SfLotEquipmentService;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.mes.service.SfLotWorkerService;
import kr.co.micube.common.mes.service.UlProcessWorkResultService;
import kr.co.micube.common.mes.service.UlSubProcessWorkResultService;
import kr.co.micube.common.mes.so.SfEquipmentData;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.util.StringFunction;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 조립
 * 설               명	: 조립 세부공정 작업시작
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-05-26
 * 수   정   이   력	: 
 * 				  
 */

public class SubTrackInAssy extends DatasetRule {
	
	// 트랜잭션 정보
	private TxnInfo txnInfo;
	
	// 파라미터
	private String lotId;					// LOT ID
	private String subProcessSegmentId;		// 세부공정 ID
	private String userIds;					// 작업자 목록 (콤마로 구분)
	private String chargeUserId;			// 대표작업자
	private String equipmentId;				// 설비 ID(옵션)
	private String specDefIdVersion;		// 스펙 ID 버전
	
	// 기타
	// private String logInUserId;			// 로그인 사용자 ID
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		validateLotAndEquipmentInSameArea();
		// this.logInUserId = this.txnInfo.getTxnUser();
		this.txnInfo.setTxnUser(this.chargeUserId);																// Lot History TrackInUser 등에 대표작업자 ID 등록
		validateUser();																							// 작업자 유효성 검사
		SfLotService.validateLotStateIsInProduction(this.lotId);
		SfLotService.validateProcessClass(this.lotId, ProcessClass.ASSEMBLY);									// 조립 LOT인지 검증
		Date workStartTime = SQLService.toDate();
		if(UlSubProcessWorkResultService.isSubProcessWorkResultEmpty(this.lotId)) {								// 첫 세부공정 작업시작이면
			SfLotData lotData = SfLotService.trackIn(this.lotId, VirtualEquipmentId.ASSEMBLY, this.txnInfo);	// Track In
			workStartTime = lotData.getTrackintime();
			UlProcessWorkResultService.startProcessWorkResult(this.lotId, VirtualEquipmentId.ASSEMBLY
					, workStartTime, this.chargeUserId, Constant.EMPTY, this.txnInfo);							// 공정별 생산실적 등록
		}
		UlSubProcessWorkResultService.startSubProcessWorkResult(this.lotId, this.subProcessSegmentId
				, this.equipmentId, workStartTime, this.chargeUserId, this.txnInfo, this.specDefIdVersion);		// 세부공정 작업시작
		if(!StringUtils.isNullOrEmpty(this.equipmentId)) {														// 설비가 있으면
			SfLotEquipmentService.startLotEquipment(this.lotId, this.equipmentId, this.subProcessSegmentId, workStartTime, this.txnInfo);	// LotEquipment 등록
		}
		SfLotWorkerService.createSfLotworker(this.lotId, this.userIds.split(","), this.subProcessSegmentId, this.equipmentId, this.txnInfo);	// LotWorker 등록
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
		this.userIds = body.getString("userids");
		this.chargeUserId = body.getString("chargeuserid");
		this.equipmentId = body.getString("equipmentid");
		this.specDefIdVersion = body.getString("specdefidversion");
	}
	
	private void validateUser() throws SystemException {
		if(StringUtils.isNullOrEmpty(this.chargeUserId)) {
			// 대표 작업자를 입력해주세요.
			throw new SystemException("ChargeUserIdRequired");
		}
		if(StringUtils.isNullOrEmpty(this.userIds)) {
			// 작업자를 입력해주세요.
			throw new SystemException("UserIdRequired");
		}
		String[] userIdList = this.userIds.split(",");
		if(!StringFunction.contains(userIdList, this.chargeUserId)) {
			// 대표작업자는 작업자 목록에 속해야합니다.
			throw new SystemException("ChargeUserIdMustInUserIds");
		}
		/* TODO : 해당 유효성검사 필요한지 확인
		if(!StringFunction.contains(userIdList, this.logInUserId)) {
			// 작업자 목록에 로그인 사용자가 있어야 합니다.
			throw new SystemException("LoginUserIdMustInUserIds");
		}
		*/
	}
	
	private void validateLotAndEquipmentInSameArea() throws SystemException {
		if(StringUtils.isNullOrEmpty(this.equipmentId)) {
			return;
		}
		SfLotData lotData = SfLotService.getLot(this.lotId);
		SfEquipmentData equipData = SfEquipmentService.getEquipment(this.equipmentId);
		if(!lotData.getAreaid().equals(equipData.getAreaid())) {
			// 설비와 LOT의 작업장이 다릅니다. {0}
			throw new SystemException("LotEquipmentAreaNotMatch", String.format("EquipmentAreaId=%s, LotAreaId=%s", equipData.getAreaid(), lotData.getAreaid()));
		}
	}
}
