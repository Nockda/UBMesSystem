package kr.co.micube.common.mes.service;

import kr.co.micube.common.mes.so.SfEquipmentData;
import kr.co.micube.common.mes.so.SfEquipmentKey;
import kr.co.micube.core.sql.exception.DatabaseException;

public class SfEquipmentService {

	public static SfEquipmentData getEquipment(String equipmentId) throws DatabaseException {
		SfEquipmentData data = new SfEquipmentData();
		SfEquipmentKey key = data.key();
		key.setEquipmentid(equipmentId);
		return data.selectOne();
	}
}
