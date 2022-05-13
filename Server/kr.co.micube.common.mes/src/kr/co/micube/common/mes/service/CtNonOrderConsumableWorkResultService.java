package kr.co.micube.common.mes.service;

import java.util.Date;

import kr.co.micube.common.mes.constant.ConsumableLotGenealTxnType;
import kr.co.micube.common.mes.so.CtConsumablelotgenealData;
import kr.co.micube.common.mes.so.CtNonorderconsumableworkresultData;
import kr.co.micube.common.mes.so.CtNonorderconsumableworkresultKey;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.standard.info.DeKitConsumableLotInfo;
import kr.co.micube.commons.factory.standard.info.KitConsumableLotInfo;
import kr.co.micube.commons.factory.standard.info.SplitConsumableLotInfo;
import kr.co.micube.commons.factory.standard.service.ConsumableLotService;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.core.util.Generate;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;

public class CtNonOrderConsumableWorkResultService {

	/**
	 * 무지시 작업내역 등록
	 * @param conLotData 자재 LOT
	 * @param equipmentId 설비 ID
	 * @param userId 작업자 ID
	 * @param txnInfo 트랜잭션 정보
	 * @return 무지시 작업내역 
	 * @throws SystemException 
	 */
	public static CtNonorderconsumableworkresultData createCtNonOrderConsumableWorkResult(
			SfConsumablelotData conLotData, String equipmentId, String userId, TxnInfo txnInfo) throws SystemException {

		Date now = SQLService.toDate();
		SfConsumablelotKey conLotKey = conLotData.key();
		CtNonorderconsumableworkresultData data = new CtNonorderconsumableworkresultData();
		CtNonorderconsumableworkresultKey key = data.key();
		key.setConsumablelotid(conLotKey.getConsumablelotid());
		key.setTxnhistkey(Generate.createTimeKey());
		data.setEnterpriseid(conLotData.getEnterpriseid());
		data.setPlantid(conLotData.getPlantid());
		data.setAreaid(conLotData.getAreaid());
		data.setEquipmentid(equipmentId);
		data.setWarehouseid(conLotData.getWarehouseid());
		data.setParentconsumablelotid(conLotData.getParentconsumablelotid());
		data.setInputqty(conLotData.getConsumablelotqty());
		data.setWorkqty(conLotData.getConsumablelotqty());
		data.setWorker(userId);
		data.setWorkstarttime(now);
		data.setWorkendtime(now);
		data.txnInfo().set(txnInfo.getTransaction());
		data.setValidstate(Constant.VALIDSTATE_VALID);
		data.insert();
		return data;
	}
	
	/**
	 * 무지시 공정 작업시작(건조기 등)
	 * @param conLotData 자재 LOT
	 * @param equipmentId 설비 ID
	 * @param userId 작업자
	 * @param workStartTime 작업 시작시간
	 * @param txnInfo 트랜잭션 정보
	 * @return 무지시 작업내역
	 * @throws Throwable
	 */
	public static CtNonorderconsumableworkresultData startNonOrderConsumableWorkResult(
			SfConsumablelotData conLotData, String equipmentId, String userId, Date workStartTime, TxnInfo txnInfo) throws Throwable {

		SfConsumablelotKey conLotKey = conLotData.key();
		kitConsumableLot(conLotKey.getConsumablelotid(), equipmentId, txnInfo);
		CtNonorderconsumableworkresultData data = new CtNonorderconsumableworkresultData();
		CtNonorderconsumableworkresultKey key = data.key();
		key.setConsumablelotid(conLotKey.getConsumablelotid());
		key.setTxnhistkey(Generate.createTimeKey());
		data.setEnterpriseid(conLotData.getEnterpriseid());
		data.setPlantid(conLotData.getPlantid());
		data.setAreaid(conLotData.getAreaid());
		data.setEquipmentid(equipmentId);
		data.setWarehouseid(conLotData.getWarehouseid());
		data.setParentconsumablelotid(conLotData.getParentconsumablelotid());
		data.setInputqty(conLotData.getConsumablelotqty());
		data.setWorkqty(conLotData.getConsumablelotqty());
		data.setWorker(userId);
		data.setWorkstarttime(workStartTime);
		data.txnInfo().set(txnInfo.getTransaction());
		data.setValidstate(Constant.VALIDSTATE_VALID);
		data.insert();
		return data;
	}
	
	// 자재 LOT을 설비에 키팅
	private static void kitConsumableLot(String consumableLotId, String equipmentId, TxnInfo txnInfo) throws Throwable {
		KitConsumableLotInfo info = new KitConsumableLotInfo();
		info.setConsumableLotId(consumableLotId);
		info.setEquipmentId(equipmentId);
		ConsumableLotService.kitConsumableLot(info, txnInfo);
	}
	
	public static CtNonorderconsumableworkresultData endNonOrderConsumableWorkResult(
			String equipmentId, String consumableLotId, Double qty, Date workEndTime, TxnInfo txnInfo) throws Throwable {
		SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(consumableLotId);
		if(conLotData.getConsumablelotqty() > qty) {
			return endNonOrderConsumableWorkResultWithSplit(equipmentId, consumableLotId, qty, workEndTime, txnInfo);
		}
		else {
			return endNonOrderConsumableWorkResultWithoutSplit(equipmentId, consumableLotId, qty, workEndTime, txnInfo);
		}
	}
	
	// 분할없이 작업완료
	private static CtNonorderconsumableworkresultData endNonOrderConsumableWorkResultWithoutSplit(
			String equipmentId, String consumableLotId, Double qty, Date workEndTime, TxnInfo txnInfo) throws Throwable {
		SfConsumablelotData conLotdata = SfConsumableLotService.getConsumablelot(consumableLotId);
		if(qty > conLotdata.getConsumablelotqty()) {
			// 현재수량보다 더 큰 수량으로 작업완료할 수 없습니다. {0}
			throw new SystemException("CantTrackOutWithQtyGreaterThanCurrentQty", String.format("ConsumableLotId=%s", consumableLotId));
		}
		
		ISQLCondition cond = new SQLCondition(false);
		cond.set(CtNonorderconsumableworkresultData.Equipmentid);
		cond.set(CtNonorderconsumableworkresultData.Consumablelotid);
		cond.set(CtNonorderconsumableworkresultData.Workendtime);
		CtNonorderconsumableworkresultData data = new CtNonorderconsumableworkresultData();
		CtNonorderconsumableworkresultKey key = data.key();
		data.setEquipmentid(equipmentId);
		key.setConsumablelotid(consumableLotId);
		data.setWorkendtime(null);
		
		data = data.selectOne(cond);
		data.setWorkqty(qty);
		data.setWorkendtime(workEndTime);
		data.update();
		dekitConsumableLot(consumableLotId, txnInfo);
		return data;
	}

	// 자재 LOT을 설비에서 키팅 해제
	private static void dekitConsumableLot(String consumableLotId, TxnInfo txnInfo) throws Throwable {
		DeKitConsumableLotInfo info = new DeKitConsumableLotInfo(); 
		info.setConsumableLotId(consumableLotId);
		ConsumableLotService.deKitConsumableLot(info, txnInfo);
	}

	// 작업완료 및 분할
	private static CtNonorderconsumableworkresultData endNonOrderConsumableWorkResultWithSplit(
			String equipmentId, String consumableLotId, Double qty, Date workEndTime, TxnInfo txnInfo) throws Throwable {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(CtNonorderconsumableworkresultData.Equipmentid);
		cond.set(CtNonorderconsumableworkresultData.Consumablelotid);
		cond.set(CtNonorderconsumableworkresultData.Workendtime);
		CtNonorderconsumableworkresultData resultData = new CtNonorderconsumableworkresultData();
		CtNonorderconsumableworkresultKey resultKey = resultData.key();
		resultData.setEquipmentid(equipmentId);
		resultKey.setConsumablelotid(consumableLotId);
		resultData.setWorkendtime(null);
		resultData = resultData.selectOne(cond);
		
		// 자재 LOT 특수 분할
		SfConsumablelotData childLotData = specialSplitConsumableLot(consumableLotId, resultData.getParentconsumablelotid(), resultData.getInputqty(), qty, txnInfo);
		SfConsumablelotKey childLotKey = childLotData.key();
		
		// 실적 복사
		CtNonorderconsumableworkresultData newResultData = new CtNonorderconsumableworkresultData();
		CtNonorderconsumableworkresultKey newResultKey = newResultData.key();
		newResultKey.setTxnhistkey(Generate.createTimeKey());
		newResultKey.setConsumablelotid(childLotKey.getConsumablelotid());
		newResultData.setEnterpriseid(resultData.getEnterpriseid());
		newResultData.setPlantid(resultData.getPlantid());
		newResultData.setAreaid(resultData.getAreaid());
		newResultData.setEquipmentid(resultData.getEquipmentid());
		newResultData.setWarehouseid(resultData.getWarehouseid());
		newResultData.setParentconsumablelotid(resultData.getParentconsumablelotid());
		newResultData.setInputqty(resultData.getInputqty());
		newResultData.setWorkqty(qty);
		newResultData.setWorker(resultData.getWorker());
		newResultData.setDescription(resultData.getDescription());
		newResultData.setValidstate(Constant.VALIDSTATE_VALID);
		newResultData.setWorkstarttime(resultData.getWorkstarttime());
		newResultData.setWorkendtime(workEndTime);
		newResultData.setSwitchdate(resultData.getSwitchdate());
		newResultData.insert();
		return newResultData;
	}
	
	// 자재 LOT 특수 분할 : 수량은 qtyParentConsumableLotId 에서 가져오고, 분할이력에는 idParentConsumableLotId 에서 분할 한것으로 기록
	// NOTE : qtyParentConsumableLotId 는 idParentConsumableLotId 의 자식LOT 이다.
	private static SfConsumablelotData specialSplitConsumableLot(String qtyParentConsumableLotId, String idParentConsumableLotId, Double originalQty, Double splitQty, TxnInfo txnInfo) throws Throwable {
		SfConsumablelotData qtyParentConLot = SfConsumableLotService.getConsumablelot(qtyParentConsumableLotId);
		SfConsumableLotService.validateSplitQty(qtyParentConLot.getConsumablelotqty(), splitQty);
		String childConsumableLotId = SfConsumableLotService.createSplitId(idParentConsumableLotId);
		SplitConsumableLotInfo info = new SplitConsumableLotInfo();
		info.setConsumableLotId(qtyParentConsumableLotId);
		info.setChildConsumableLotId(childConsumableLotId);
		info.setSplitqty(splitQty);
		info.setChildqty(splitQty);
		ConsumableLotService.splitConsumableLot(info, txnInfo);
		qtyParentConLot = SfConsumableLotService.getConsumablelot(qtyParentConsumableLotId);
		if(qtyParentConLot.getConsumablelotqty() <= 0D) {
			qtyParentConLot.setConsumablestate(Constant.CONSUMABLESTATE_CONSUMED);
			qtyParentConLot.update();
		}
		SfConsumablelotData childConLot = SfConsumableLotService.getConsumablelot(childConsumableLotId);
		childConLot.setWarehouseid(qtyParentConLot.getWarehouseid());
		childConLot.setOrderseq(qtyParentConLot.getOrderseq());
		childConLot.setParentconsumablelotid(idParentConsumableLotId);
		childConLot.setIsnotorderresult(Constant.YES);	
		childConLot.setPrintcount(0);
		childConLot.txnInfo().set(txnInfo.getTransaction());
		childConLot.update();
		
		// 자재 LOT 분할이력 기록
		CtConsumableLotGenealService.createCtConsumablelotgenealData(ConsumableLotGenealTxnType.SPLIT
				, idParentConsumableLotId, childConsumableLotId, originalQty, splitQty, txnInfo);
		
		// idParentConsumableLotId -> qtyParentConsumableLotId 분할이력에서 수량 수정
		ISQLCondition cond = new SQLCondition(false);
		cond.set(CtConsumablelotgenealData.Consumablelotid, idParentConsumableLotId);
		cond.set(CtConsumablelotgenealData.Destinationlotid, qtyParentConsumableLotId);
		cond.set(CtConsumablelotgenealData.Txntype, ConsumableLotGenealTxnType.SPLIT);
		CtConsumablelotgenealData genealData = new CtConsumablelotgenealData();
		genealData = genealData.selectOne(cond);
		genealData.setQty(qtyParentConLot.getConsumablelotqty());
		genealData.update();
		
		return childConLot;
	}
}
