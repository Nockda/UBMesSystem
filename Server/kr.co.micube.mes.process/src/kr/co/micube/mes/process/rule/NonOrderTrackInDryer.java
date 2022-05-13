package kr.co.micube.mes.process.rule;

import java.text.ParseException;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.Area;
import kr.co.micube.common.mes.constant.EquipmentClass;
import kr.co.micube.common.mes.constant.ProcessSegment;
import kr.co.micube.common.mes.service.CtNonOrderConsumableWorkResultService;
import kr.co.micube.common.mes.service.SfAreaService;
import kr.co.micube.common.mes.service.SfConsumableDefinitionService;
import kr.co.micube.common.mes.service.SfConsumableLotService;
import kr.co.micube.common.mes.service.SfEquipmentService;
import kr.co.micube.common.mes.so.SfAreaData;
import kr.co.micube.common.mes.so.SfConsumabledefinitionData;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
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
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 건조기
 * 설               명	: 건조기 작업시작(무지시)
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-06-09
 * 수   정   이   력	: 
 * 				  
 */

public class NonOrderTrackInDryer extends DatasetRule {

	// 트랜잭션 정보
	private TxnInfo txnInfo;

	// 파라미터
	private String equipmentId;					// 설비 ID
	private IDataTable list; 					// 무지시 공정 자재 LOT(컬럼 : inputlot) 
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		validateInputLots();
		validateEquipment();
		trackInEquipment();
		String warehouseId = getWarehouseId();
		Date now = SQLService.toDate();
		List<String> childLotIds = new ArrayList<String>();
		for (int i = 0; i < this.list.size(); i++) {
			IDataRow row = this.list.getRow(i);
			String consumablelotId = row.getString("INPUTLOT");	// 자재 LOT ID
			SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(consumablelotId);
			validateConsumableLot(conLotData, warehouseId);
			SfConsumablelotData childConLotData = SfConsumableLotService.splitNonOrderConsumableLot(consumablelotId, conLotData.getConsumablelotqty(), this.txnInfo);
			CtNonOrderConsumableWorkResultService.startNonOrderConsumableWorkResult(childConLotData, this.equipmentId, txnInfo.getTxnUser(), now, this.txnInfo);
			SfConsumablelotKey childConLotKey = childConLotData.key();
			childLotIds.add(childConLotKey.getConsumablelotid());
		}
		returnChildConsumableLotIds(childLotIds);
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
	
	private void validateInputLots() throws SystemException {
		if(this.list.size() == 0) {
			// 투입 LOT 없이 작업을 시작할 수 없습니다.
			throw new SystemException("CantStartWithoutInputLot");
		}
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
		if(!equipmentData.getState().equals(Constant.STATE_IDLE)) {
			// 작업시작을 할 수 없는 설비상태 입니다. {0}
			throw new SystemException("EquipmentStateIsNotIdle", String.format("EquipmentId=%s, State=%s", this.equipmentId, equipmentData.getState()));
		}
	}
	
	// 설비 상태를 작업중으로 변경
	private void trackInEquipment() throws Throwable {
		EquipmentData equipmentData = EquipmentService.getEquipment(this.equipmentId);
		EquipmentService.changeState(equipmentData, Constant.TRANSITIONID_TRACKIN);
		equipmentData.update();
	}
	
	// 설비의 작업장에 연결된 창고 ID 를 가져온다.
	private String getWarehouseId() throws DatabaseException {
		SfEquipmentData equipmentData = SfEquipmentService.getEquipment(this.equipmentId);
		SfAreaData areaData = SfAreaService.getArea(equipmentData.getAreaid());
		return areaData.getWarehouseid();
	}
	
	// 자재 LOT 유효성 검사
	private void validateConsumableLot(SfConsumablelotData conLotData, String warehouseId) throws SystemException {
		SfConsumablelotKey conLotKey = conLotData.key();
		SfConsumabledefinitionData conDefData = SfConsumableDefinitionService.getConsumabledefinition(conLotData.getConsumabledefid(), conLotData.getConsumabledefversion());
		if(!ProcessSegment.DISPLACERDRY.equals(conDefData.getNotordersegmentid())) {
			// 무지시 건조대상 자재가 아닙니다. {0}
			throw new SystemException("ConsumableDefIsNotForNonOrderDry", String.format("ConsumableDefId=%s", conLotData.getConsumabledefid()));
		}
		if(!warehouseId.equals(conLotData.getWarehouseid())) {
			// 다른창고에 있는 자재를 투입할 수 없습니다. {0}
			throw new SystemException("CantInputMaterialInAnotherWarehouse", String.format("ConsumableLotId=%s, WarehouseId=%s", conLotKey.getConsumablelotid(), conLotData.getWarehouseid()));
		}
		if(!Constant.YES.equals(conDefData.getIsnotorderresult())) {
			// 무지시작업 대상 자재가 아닙니다. {0}
			throw new SystemException("ConsumableDefIsNotNonOrderResult", String.format("ConsumableDefId=%s", conLotData.getConsumabledefid()));
		}
		if(Constant.YES.equals(conLotData.getIshold())) {
			// 보류상태의 자재입니다. {0}
			throw new SystemException("ConsumableLotIsHold", String.format("ConsumableLotId=%s", conLotKey.getConsumablelotid()));
		}
		if(!Constant.CONSUMABLESTATE_AVAILABLE.equals(conLotData.getConsumablestate())) {
			// 사용가능한 상태의 자재가 아닙니다. {0}
			throw new SystemException("ConsumableLotIsNotAvailable", String.format("ConsumableLotId=%s, ConsumableState=%s", conLotKey.getConsumablelotid(), conLotData.getConsumablestate()));
		}
		if(!StringUtils.isNullOrEmpty(conLotData.getEquipmentid())) {
			// 이미 작업중인 자재입니다. {0}
			throw new SystemException("ConsumableLotIsAlreadyWorking", String.format("ConsumableLotId=%s, EquipmentId=%s", conLotKey.getConsumablelotid(), conLotData.getEquipmentid()));
		}
		if(Constant.YES.equals(conLotData.getIsnotorderresult())) {
			// 이미 무지시 작업을 완료한 자재LOT 입니다. {0}
			throw new SystemException("NonOrderWorkAlreadyFinished", String.format("ConsumableLotId=%s", conLotKey.getConsumablelotid()));
		}
	}
	
	// 자식 자재LOT ID 목록 반환
	private void returnChildConsumableLotIds(List<String> childLotIds) {
		Map<String, Object> result = new HashMap<String, Object>();
		for(int i = 0; i < childLotIds.size(); i++) {
			result.put("INPUTLOT", childLotIds.get(i));
		}
		IDataSet ds = this.getResponseDataset();
		IDataTable dt = ds.addTable("DATA");
		dt.addRow(result);
	}
}
