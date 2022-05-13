package kr.co.micube.common.mes.util;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.so.CtConsumablelotgenealData;
import kr.co.micube.common.mes.so.CtConsumablelotgenealKey;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.common.util.QueryProvider;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;

public class MaterialServiceImpl {
	
	/****************************************************************************************************************
	 * Consumable Lot Split
	 ****************************************************************************************************************/
	public static SfConsumablelotData SplitConsumableLotImpl(String parentConsumablelotId, double beforeQty, double totalSplitQty, double splitQty, boolean flag, TxnInfo txnInfo) throws Throwable
	{
		SfConsumablelotData parentData = new SfConsumablelotData();
		SfConsumablelotKey parentKey = parentData.key();
		
		parentKey.setConsumablelotid(parentConsumablelotId);
		
		parentData = parentData.selectOne();
		
		if (parentData == null)
		{
			throw new InValidDataException("InValidData001", String.format("CONSUMABLELOTID = %s", parentConsumablelotId));
		}
		
		// 분할대상 자재 Lot의 상태가 Available인지 체크
		if (!parentData.getConsumablestate().equals("Available"))
		{
			// 분할대상 자재 Lot의 상태가 Available이 아닙니다.
			throw new InValidDataException("ConsumableLotStateIsNotAvailable");
		}
		
		// 분할대상 자재 Lot의 수량이 분할수량보다 큰지 체크
		if (parentData.getConsumablelotqty() < splitQty)
		{
			// 분할대상 자재 Lot의 수량보다 분할수량이 더 많습니다.
			throw new InValidDataException("SplitQtyMoreThanConsumableLotQty");
		}
		
		// 수량이 0일경우 자재상태 Consumed로 변경
		if (parentData.getConsumablelotqty() - splitQty == Double.valueOf(0))
		{
			parentData.setConsumablestate("Consumed"); 
		}
		
		parentData.setConsumablelotqty(parentData.getConsumablelotqty() - splitQty);
		parentData.update();
		
		SfConsumablelotData childData = new SfConsumablelotData();
		SfConsumablelotKey childKey = childData.key();
		
		// 2020-08-06 유태근 - 최상위 자재 LOT NO를 파라미터로 넘겨 더블대쉬가 생기지 않도록 수정	
		/*
		Map<String, Object> param = new HashMap<String, Object>();
		param.put("CONSUMABLELOTID", parentConsumablelotId);
		
		List<Map<String, Object>> result = QueryProvider.select("GetRootConsumableLotId", "00001", param);
		
		String childConsumableLotId = MaxSplitConsumableLotId(result.get(0).get("ROOTCONSUMABLELOTID").toString());
		*/
		String childConsumableLotId = MaxSplitConsumableLotId(parentConsumablelotId);
		
		
		childKey.setConsumablelotid(childConsumableLotId);
		
		childData.setConsumablelotname(childConsumableLotId);
		childData.setEnterpriseid(parentData.getEnterpriseid());
		childData.setPlantid(parentData.getPlantid());
		childData.setAreaid(parentData.getAreaid());
		childData.setEquipmentid(parentData.getEquipmentid());
		childData.setWarehouseid(parentData.getWarehouseid());
		childData.setLocationid(parentData.getLocationid());
		childData.setConsumabledefid(parentData.getConsumabledefid());
		childData.setConsumabledefversion(parentData.getConsumabledefversion());
		childData.setConsumablelotgroupid(parentData.getConsumablelotgroupid());
		childData.setConsumablestate("Available");
		childData.setCreatedqty(splitQty);
		childData.setConsumablelotqty(splitQty);
		childData.setExpireddate(parentData.getExpireddate());
		childData.setIshold(parentData.getIshold());
		childData.setOrderseq(parentData.getOrderseq());
		childData.setParentconsumablelotid(parentConsumablelotId);
		childData.setState(parentData.getState());
		childData.setIsnotorderresult(parentData.getIsnotorderresult());
		childData.setDescription(parentData.getDescription());
		childData.insert();
		
		SaveConsumableLotSplitGeneal(parentConsumablelotId, childConsumableLotId, beforeQty, totalSplitQty, splitQty, flag, txnInfo);
		
		return childData;
	}
	
	/****************************************************************************************************************
	 * Max Consumable Lot Id 채번
	 ****************************************************************************************************************/
	private static String MaxSplitConsumableLotId(String parentConsumablelotId) throws DatabaseException
	{
		String maxSplitConsumableLotId = "";
		
		Map<String, Object> param = new HashMap<String, Object>();
		param.put("CONSUMABLELOTID", parentConsumablelotId);
		
		List<Map<String, Object>> lastSplitIdResult = QueryProvider.select("GetLastSplitIdOfConsumableLot", "00001", param);
		
		int lastSplitPart = 0; 
		
		if (lastSplitIdResult.size() > 0 && lastSplitIdResult.get(0).get("LASTSPLITID") != null) 
		{
			String lastSplitId = lastSplitIdResult.get(0).get("LASTSPLITID").toString();
			String[] lastParts = lastSplitId.split("-");
			lastSplitPart = Integer.valueOf(lastParts[lastParts.length - 1]);
		}

		maxSplitConsumableLotId = parentConsumablelotId + "-" + String.format("%02d", lastSplitPart + 1);

		return maxSplitConsumableLotId;
	}
	
	/****************************************************************************************************************
	 * Consumable Lot Split 이력저장
	 ****************************************************************************************************************/
	private static void SaveConsumableLotSplitGeneal(String parentConsumableLotId, String splitConsumableLotId, double beforeQty, double totalSplitQty, double splitQty, boolean flag, TxnInfo txnInfo) throws DatabaseException
	{
		SfConsumablelotData parentData = new SfConsumablelotData();
		SfConsumablelotKey parentKey = parentData.key();
		
		parentKey.setConsumablelotid(parentConsumableLotId);
		
		parentData = parentData.selectOne();		
		
		CtConsumablelotgenealData data = new CtConsumablelotgenealData();
		CtConsumablelotgenealKey key = data.key();
		
		// 최초에 전수분할인지 체크하여 전수분할이 아니라면 잔량만큼 나 자신 이력 저장
		if (flag)
		{
			if (beforeQty - totalSplitQty > 0)
			{
				key.setConsumablelotid(parentConsumableLotId);
				key.setTxnhistkey(Generate.createTimeKey());
				data.setEnterpriseid(parentData.getEnterpriseid());
				data.setPlantid(parentData.getPlantid());
				data.setAreaid(parentData.getAreaid());
				data.setWarehouseid(parentData.getWarehouseid());
				data.setConsumabledefid(parentData.getConsumabledefid());
				data.setConsumabledefversion(parentData.getConsumabledefversion());
				data.setDestinationlotid(parentConsumableLotId);
				data.setTxntype("Split");
				data.setOriginalqty(beforeQty); // 분할되기 전 수량
				data.setQty(beforeQty - totalSplitQty); // 분할되고 남은 잔량			
				data.setTxnid(txnInfo.getTxnId());
				data.setTxnuser(txnInfo.getTxnUser());
				data.setTxntime(txnInfo.getTxnTime());
				data.setTxngrouphistkey(txnInfo.getGroupHistKey());
				data.setTxnreasoncodeclass(txnInfo.getTxnReasonCodeClass());
				data.setTxnreasoncode(txnInfo.getTxnReasonCode());
				data.setTxncomment(txnInfo.getTxnComment());		
				data.insert();
			}
		}
		
		key.setConsumablelotid(parentConsumableLotId);
		key.setTxnhistkey(Generate.createTimeKey());
		data.setEnterpriseid(parentData.getEnterpriseid());
		data.setPlantid(parentData.getPlantid());
		data.setAreaid(parentData.getAreaid());
		data.setWarehouseid(parentData.getWarehouseid());
		data.setConsumabledefid(parentData.getConsumabledefid());
		data.setConsumabledefversion(parentData.getConsumabledefversion());
		data.setDestinationlotid(splitConsumableLotId);
		data.setTxntype("Split");
		data.setOriginalqty(beforeQty); // 분할되기 전 수량
		data.setQty(splitQty); // 분할수량
		data.setTxnid(txnInfo.getTxnId());
		data.setTxnuser(txnInfo.getTxnUser());
		data.setTxntime(txnInfo.getTxnTime());
		data.setTxngrouphistkey(txnInfo.getGroupHistKey());
		data.setTxnreasoncodeclass(txnInfo.getTxnReasonCodeClass());
		data.setTxnreasoncode(txnInfo.getTxnReasonCode());
		data.setTxncomment(txnInfo.getTxnComment());
		data.insert();
	}
	
	/****************************************************************************************************************
	 * Consumable Lot Merge
	 ****************************************************************************************************************/
	public static SfConsumablelotData MergeConsumableLotImpl(String parentConsumablelotId, String childConsumablelotId, double totalMergeQty, double mergeQty, boolean flag, TxnInfo txnInfo) throws Throwable
	{
		SfConsumablelotData parentData = new SfConsumablelotData();
		SfConsumablelotKey parentKey = parentData.key();
		
		parentKey.setConsumablelotid(parentConsumablelotId);
		
		parentData = parentData.selectOne();
		
		SfConsumablelotData childData = new SfConsumablelotData();
		SfConsumablelotKey childKey = childData.key();
		
		childKey.setConsumablelotid(childConsumablelotId);
		
		childData = childData.selectOne();
				
		if (parentData == null)
		{
			throw new InValidDataException("InValidData001", String.format("CONSUMABLELOTID = %s", parentConsumablelotId));
		}
		else if (childData == null)
		{
			throw new InValidDataException("InValidData001", String.format("CONSUMABLELOTID = %s", childConsumablelotId));
		}
		
		// 병합대상 자재 Lot, 병합 자재 Lot의 상태가 Available인지 체크
		if (!parentData.getConsumablestate().equals("Available") || !childData.getConsumablestate().equals("Available"))
		{
			// 자재 Lot의 상태가 Available이 아닙니다.
			throw new InValidDataException("ConsumableLotStateIsNotAvailable");
		}
		
		// 병합 자재 Lot의 병합수량이 총 수량보다 큰지 체크
		if (childData.getConsumablelotqty() < mergeQty)
		{
			// 병합자재 Lot의 수량보다 병합수량이 더 많습니다.
			throw new InValidDataException("MergeQtyMoreThanConsumableLotQty");
		}
		
		// 수량이 0일경우 자재상태 Consumed로 변경
		if (childData.getConsumablelotqty() - mergeQty == Double.valueOf(0))
		{
			childData.setConsumablestate("Consumed"); 
		}
		
		// 자재 Lot병합이력 저장
		SaveConsumableLotMergeGeneal(parentConsumablelotId, childConsumablelotId, totalMergeQty, mergeQty, flag, txnInfo);
		
		parentData.setConsumablelotqty(parentData.getConsumablelotqty() + mergeQty);
		parentData.update();
		
		childData.setConsumablelotqty(childData.getConsumablelotqty() - mergeQty);
		childData.update();
		
		return childData;
	}
	
	/****************************************************************************************************************
	 * Consumable Lot Merge 이력저장
	 ****************************************************************************************************************/
	private static void SaveConsumableLotMergeGeneal(String parentConsumableLotId, String mergeConsumableLotId, double totalMergeQty, double mergeQty, boolean flag, TxnInfo txnInfo) throws DatabaseException
	{
		SfConsumablelotData parentData = new SfConsumablelotData();
		SfConsumablelotKey parentKey = parentData.key();
		
		parentKey.setConsumablelotid(parentConsumableLotId);
		
		parentData = parentData.selectOne();		
		
		CtConsumablelotgenealData data = new CtConsumablelotgenealData();
		CtConsumablelotgenealKey key = data.key();
		
		// 나 자신은 최초한번 저장
		if (flag)
		{
			key.setConsumablelotid(parentConsumableLotId);
			key.setTxnhistkey(Generate.createTimeKey());
			data.setEnterpriseid(parentData.getEnterpriseid());
			data.setPlantid(parentData.getPlantid());
			data.setAreaid(parentData.getAreaid());
			data.setWarehouseid(parentData.getWarehouseid());
			data.setConsumabledefid(parentData.getConsumabledefid());
			data.setConsumabledefversion(parentData.getConsumabledefversion());
			data.setDestinationlotid(parentConsumableLotId);
			data.setTxntype("Merge");
			data.setOriginalqty(totalMergeQty); // 총 병합된 수량
			data.setQty(parentData.getConsumablelotqty()); // 병합 수량
			data.setTxnid(txnInfo.getTxnId());
			data.setTxnuser(txnInfo.getTxnUser());
			data.setTxntime(txnInfo.getTxnTime());
			data.setTxngrouphistkey(txnInfo.getGroupHistKey());
			data.setTxnreasoncodeclass(txnInfo.getTxnReasonCodeClass());
			data.setTxnreasoncode(txnInfo.getTxnReasonCode());
			data.setTxncomment(txnInfo.getTxnComment());
			data.insert();
		}
		
		key.setConsumablelotid(parentConsumableLotId);
		key.setTxnhistkey(Generate.createTimeKey());
		data.setEnterpriseid(parentData.getEnterpriseid());
		data.setPlantid(parentData.getPlantid());
		data.setAreaid(parentData.getAreaid());
		data.setWarehouseid(parentData.getWarehouseid());
		data.setConsumabledefid(parentData.getConsumabledefid());
		data.setConsumabledefversion(parentData.getConsumabledefversion());
		data.setDestinationlotid(mergeConsumableLotId);
		data.setTxntype("Merge");
		data.setOriginalqty(totalMergeQty); // 총 병합된 수량
		data.setQty(mergeQty); // 병합 수량
		data.setTxnid(txnInfo.getTxnId());
		data.setTxnuser(txnInfo.getTxnUser());
		data.setTxntime(txnInfo.getTxnTime());
		data.setTxngrouphistkey(txnInfo.getGroupHistKey());
		data.setTxnreasoncodeclass(txnInfo.getTxnReasonCodeClass());
		data.setTxnreasoncode(txnInfo.getTxnReasonCode());
		data.setTxncomment(txnInfo.getTxnComment());
		data.insert();
	}
	
}
