package kr.co.micube.common.mes.util;

import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.commons.factory.service.TxnInfo;

public class MaterialService {
	
	/****************************************************************************************************************
	 * 분할대상 자재 Lot을 분할수량만큼 Split한다.
	 * @param parentConsumablelotId : 분할대상 자재 Lot Id
	 * @param beforeQty : 분할되기 이전수량
	 * @param totalSplitQty : 총 분할수량
	 * @param splitQty : 분할수량
	 * @param flag : 최초 한번만 실행하기 위한 플래그
	 * @param txnInfo : Transaction 정보
	 * @return 자재 Lot 분할 후 자식 자재 Lot Data
	 * @throws Throwable
	 ****************************************************************************************************************/
	public static SfConsumablelotData SplitConsumableLot(String parentConsumablelotId, double beforeQty, double totalSplitQty, double splitQty, boolean flag, TxnInfo txnInfo) throws Throwable
	{
		return MaterialServiceImpl.SplitConsumableLotImpl(parentConsumablelotId, beforeQty, totalSplitQty, splitQty, flag, txnInfo);
	}
	
	/****************************************************************************************************************
	 * 병합대상 자재 Lot을 병합수량만큼 Merge한다.
	 * @param parentConsumablelotId : 병합대상 자재 Lot Id
	 * @param childConsumablelotId : 병합 자재 Lot Id
	 * @param totalMergeQty : 병합총수량
	 * @param mergeQty : 병합수량
	 * @param flag : 최초 한번만 실행하기 위한 플래그
	 * @param txnInfo : Transaction 정보
	 * @return 자재 Lot 병합 후 자식 자재 Lot Data
	 * @throws Throwable
	 ****************************************************************************************************************/
	public static SfConsumablelotData MergeConsumableLot(String parentConsumablelotId, String childConsumablelotId, double totalMergeQty, double mergeQty, boolean flag, TxnInfo txnInfo) throws Throwable
	{
		return MaterialServiceImpl.MergeConsumableLotImpl(parentConsumablelotId, childConsumablelotId, totalMergeQty, mergeQty, flag, txnInfo);
	}

}
