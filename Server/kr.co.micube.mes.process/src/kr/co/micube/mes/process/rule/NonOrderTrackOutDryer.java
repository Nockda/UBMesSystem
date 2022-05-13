package kr.co.micube.mes.process.rule;

import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.Area;
import kr.co.micube.common.mes.constant.EquipmentClass;
import kr.co.micube.common.mes.service.CtNonOrderConsumableWorkResultService;
import kr.co.micube.common.mes.service.SfEquipmentService;
import kr.co.micube.common.mes.so.CtNonorderconsumableworkresultData;
import kr.co.micube.common.mes.so.CtNonorderconsumableworkresultKey;
import kr.co.micube.common.mes.so.SfEquipmentData;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.so.EquipmentData;
import kr.co.micube.commons.factory.standard.service.EquipmentService;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 건조기
 * 설               명	: 건조기 작업완료(무지시)
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-06-09
 * 수   정   이   력	: 
 * 				  
 */

public class NonOrderTrackOutDryer extends DatasetRule {

	// 트랜잭션 정보
	private TxnInfo txnInfo;

	// 파라미터
	private String equipmentId;					// 설비 ID
	private IDataTable list; 					// 무지시 공정 자재 LOT(컬럼 : consumablelotid, qty) 
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		validateEquipment();
		
		Date workEndTime = SQLService.toDate();
		boolean trackOut = true;
		List<String> lotIdsToPrint = new ArrayList<String>();
		for (int i = 0; i < this.list.size(); i++) {
			IDataRow row = this.list.getRow(i);
			String consumablelotId = row.getString("CONSUMABLELOTID");
			Double qty = row.getDouble("QTY");
			CtNonorderconsumableworkresultData resultData = CtNonOrderConsumableWorkResultService.endNonOrderConsumableWorkResult(this.equipmentId, consumablelotId, qty, workEndTime, this.txnInfo);
			CtNonorderconsumableworkresultKey resultKey = resultData.key();
			if(!consumablelotId.equals(resultKey.getConsumablelotid())) {
				trackOut = false;
			}
			lotIdsToPrint.add(resultKey.getConsumablelotid());
		}
		if(trackOut) {
			trackOutEquipment();
		}
		returnChildConsumableLotIds(lotIdsToPrint);
	}

	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);

		// 파라미터
		this.equipmentId = body.getString("equipmentid");
		IDataSet ds = this.getRequestDataset();
		this.list = ds.getTable("list");
	}
	
	// 설비 유효성 검사
	private void validateEquipment() throws SystemException {
		SfEquipmentData equipmentData = SfEquipmentService.getEquipment(this.equipmentId);
		if(!equipmentData.getEquipmentclassid().equals(EquipmentClass.DRYER)) {
			// 건조설비가 아닙니다. {0}
			throw new SystemException("EquipmentIsNotDryer", String.format("EquipmentId=%s", this.equipmentId));
		}
		if(!equipmentData.getAreaid().equals(Area.DISPLAYMACHINING)) {
			// 디스플레이가공 작업장의 설비가 아닙니다. {0}
			throw new SystemException("AreaOfEquipmentIsNotDisplayMachining", String.format("EquipmentId=%s", this.equipmentId));
		}
		if(!equipmentData.getValidstate().equals(Constant.VALIDSTATE_VALID)) {
			// 설비상태가 유효하지 않습니다. {0}
			throw new SystemException("EquipmentIsNotValid", String.format("EquipmentId=%s, ValidState=%s", this.equipmentId, equipmentData.getValidstate()));
		}
		if(!equipmentData.getState().equals(Constant.STATE_RUN)) {
			// 작업완료를 할 수 없는 설비상태 입니다. {0}
			throw new SystemException("EquipmentStateIsNotRun", String.format("EquipmentId=%s, State=%s", this.equipmentId, equipmentData.getState()));
		}
	}
	
	// 설비 Track Out
	private void trackOutEquipment() throws Throwable {
		EquipmentData equipmentData = EquipmentService.getEquipment(this.equipmentId);
		EquipmentService.changeState(equipmentData, Constant.TRANSITIONID_TRACKOUT);
		equipmentData.update();
	}
	
	// 자식 자재LOT ID 목록 반환
	private void returnChildConsumableLotIds(List<String> lotIdsToPrint) {
		IDataSet ds = this.getResponseDataset();
		IDataTable dt = ds.addTable("DATA");
		for(int i = 0; i < lotIdsToPrint.size(); i++) {
			Map<String, Object> result = new HashMap<String, Object>();
			result.put("OUTPUTLOT", lotIdsToPrint.get(i));
			dt.addRow(result);
		}
	}
}
