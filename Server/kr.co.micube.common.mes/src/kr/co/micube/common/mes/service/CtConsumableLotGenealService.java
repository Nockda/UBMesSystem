package kr.co.micube.common.mes.service;

import kr.co.micube.common.mes.so.CtConsumablelotgenealData;
import kr.co.micube.common.mes.so.CtConsumablelotgenealKey;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.util.Generate;

public class CtConsumableLotGenealService {
	/**
	 * 자재 LOT 분할/병합 이력 기록
	 * @param txnType 분할/병합 구분(Split/Merge)
	 * @param consumableLotId 자재 LOT 번호
	 * @param destConsumableLotId 대상 자재 LOT 번호
	 * @param originalQty 초기수량
	 * @param qty 수량
	 * @param txnInfo 트랜잭션 정보
	 * @return
	 * @throws SystemException
	 */
	public static CtConsumablelotgenealData createCtConsumablelotgenealData(String txnType, String consumableLotId
			, String destConsumableLotId, Double originalQty, Double qty, TxnInfo txnInfo) throws SystemException {
		SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(consumableLotId);
		CtConsumablelotgenealData data = new CtConsumablelotgenealData();
		CtConsumablelotgenealKey key = data.key();
		key.setConsumablelotid(consumableLotId);
		key.setTxnhistkey(Generate.createTimeKey());
		data.setEnterpriseid(conLotData.getEnterpriseid());
		data.setPlantid(conLotData.getPlantid());
		data.setAreaid(conLotData.getAreaid());
		data.setWarehouseid(conLotData.getWarehouseid());
		data.setConsumabledefid(conLotData.getConsumabledefid());
		data.setConsumabledefversion(conLotData.getConsumabledefversion());
		data.setDestinationlotid(destConsumableLotId);
		data.setTxntype(txnType);
		data.setOriginalqty(originalQty);
		data.setQty(qty);
		data.insert();
		return data;
	}
}
