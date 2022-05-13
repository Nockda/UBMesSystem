package kr.co.micube.common.mes.service;

import kr.co.micube.common.mes.so.SfWarehouseData;
import kr.co.micube.common.mes.so.SfWarehouseKey;
import kr.co.micube.core.sql.exception.DatabaseException;

public class SfWarehouseService {

	/**
	 * 창고정보를 반환
	 * @param warehouseId 창고 ID
	 * @return 창고
	 * @throws DatabaseException
	 */
	public static SfWarehouseData getWarehouse(String warehouseId) throws DatabaseException {
		SfWarehouseData data = new SfWarehouseData();
		SfWarehouseKey key = data.key();
		key.setWarehouseid(warehouseId);
		return data.selectOne();
	}
}
