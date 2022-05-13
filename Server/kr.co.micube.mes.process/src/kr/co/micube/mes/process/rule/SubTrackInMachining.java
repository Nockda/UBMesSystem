package kr.co.micube.mes.process.rule;

import java.text.DecimalFormat;
import java.text.ParseException;
import java.util.Date;

import kr.co.micube.common.mes.constant.ProcessClass;
import kr.co.micube.common.mes.service.SfConsumeMaterialLotTempService;
import kr.co.micube.common.mes.service.SfEquipmentService;
import kr.co.micube.common.mes.service.SfLotEquipmentService;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.mes.service.SfLotWorkerService;
import kr.co.micube.common.mes.service.UlProcessWorkResultService;
import kr.co.micube.common.mes.so.SfConsumemateriallottempData;
import kr.co.micube.common.mes.so.SfEquipmentData;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfWorkorderbomData;
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
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.support.ISQLDataList;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 가공
 * 설               명	: 가공 작업시작
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-05-25
 * 수   정   이   력	: 
 * 				  
 */

public class SubTrackInMachining extends DatasetRule {
	
	// 트랜잭션 정보
	private TxnInfo txnInfo;
	
	// 파라미터
	private String lotId;		// LOT ID
	private String equipmentId;	// 설비 ID
	private String userId;		// 작업자 ID
	private Double qty;			// 수량
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		SfLotService.validateLotStateIsInProduction(this.lotId);
		SfLotService.validateProcessClass(this.lotId, ProcessClass.MACHINING);							// 가공 LOT인지 검증
		validateUser();
		Date workStartTime = SQLService.toDate();														// 작업시작 시간
		SfLotData lotData = SfLotService.getLot(this.lotId);
		validateMaterial(lotData.getWorkorderid());
		validateQty(lotData.getQty());
		validateLotAndEquipmentInSameArea(lotData.getAreaid());
		if(this.qty != lotData.getQty()) {	// 입력된 수량이 현재수량과 다르면 LOT 수량 변경
			lotData.setQty(this.qty);
			lotData.update();
		}
		if(lotData.getProcessstate().equals(Constant.LOTPROCESSSTATE_IDLE)) {							// 첫번째 설비 등록이면
			lotData = SfLotService.trackIn(this.lotId, this.equipmentId, this.txnInfo);					// Track In
			workStartTime = lotData.getTrackintime();													// 실적테이블간 작업시작시간 동기화
			UlProcessWorkResultService.startProcessWorkResult(this.lotId, this.equipmentId, workStartTime, this.userId, Constant.EMPTY, this.txnInfo);	// 공정별 실적 등록
		}
		SfLotEquipmentService.startLotEquipment(this.lotId, this.equipmentId, Constant.ASTERISK, workStartTime, this.txnInfo);	// 설비별 작업실적 등록
		SfLotWorkerService.createSfLotworker(this.lotId, this.userId, Constant.ASTERISK, this.equipmentId, this.txnInfo);		// 작업자 등록
	}
	
	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);
		 
		// 파라미터
		this.lotId = body.getString("lotid");
		this.equipmentId = body.getString("equipmentid");
		this.userId = body.getString("userid");
		this.qty = body.getDouble("qty");
	}
	
	private void validateUser() throws SystemException {
		if(StringUtils.isNullOrEmpty(this.userId)) {
			// 작업자를 입력해주세요.
			throw new SystemException("UserIdRequired");
		}
	}
	
	private void validateLotAndEquipmentInSameArea(String lotAreaId) throws SystemException {
		SfEquipmentData equipData = SfEquipmentService.getEquipment(this.equipmentId);
		if(!lotAreaId.equals(equipData.getAreaid())) {
			// 설비와 LOT의 작업장이 다릅니다. {0}
			throw new SystemException("LotEquipmentAreaNotMatch", String.format("EquipmentAreaId=%s, LotAreaId=%s", equipData.getAreaid(), lotAreaId));
		}
	}
	
	private void validateMaterial(String workorderId) throws SystemException {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfWorkorderbomData.Workorderid, workorderId);
		SfWorkorderbomData bomData = new SfWorkorderbomData();
		ISQLDataList<SfWorkorderbomData> bomDataList = bomData.select(cond);
		
		ISQLDataList<SfConsumemateriallottempData> material = SfConsumeMaterialLotTempService.getConsumemateriallottempList(this.lotId);
		if(material.size() == 0 && bomDataList.size() > 0) {
			// 먼저 자재를 투입해야 합니다.
			throw new SystemException("MaterialInputRequired");
		}
	}
	
	private void validateQty(Double lotQty) throws SystemException {
		DecimalFormat format = new DecimalFormat("0.######");
		if(this.qty < 0) {
			// 수량이 0보다 작을 수 없습니다. {0}
			throw new SystemException("QtyCantBeLowerThanZero", String.format("Qty=%s", format.format(this.qty)));
		}
		if(this.qty > lotQty) {
			// 현재 LOT수량보다 큰 수를 입력할 수 없습니다. {0}
			throw new SystemException("QtyCantBeLargerThanLotQty", String.format("Qty=%s, LotQty=%s", format.format(this.qty), format.format(lotQty)));
		}
	}
}
