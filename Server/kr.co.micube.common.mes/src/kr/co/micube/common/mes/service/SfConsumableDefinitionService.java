package kr.co.micube.common.mes.service;

import kr.co.micube.common.mes.so.SfConsumabledefinitionData;
import kr.co.micube.common.mes.so.SfConsumabledefinitionKey;
import kr.co.micube.commons.factory.generate.id.Constant;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;

public class SfConsumableDefinitionService {
	
	/**
	 * 자재 정의를 반환.
	 * @param consumabledefId 자재 정의 ID
	 * @param consumabledefVersion 자재 정의 버전
	 * @return 자재 정의
	 * @throws DatabaseException
	 */
	public static SfConsumabledefinitionData getConsumabledefinition(String consumabledefId, String consumabledefVersion) throws DatabaseException {
		SfConsumabledefinitionData data = new SfConsumabledefinitionData();
		SfConsumabledefinitionKey key = data.key();
		key.setConsumabledefid(consumabledefId);
		key.setConsumabledefversion(consumabledefVersion);
		return data.selectOne();
	}
	
	public static SfConsumabledefinitionData getConsumabledefinitionByPartnumber(String partnumber) throws DatabaseException {
		SfConsumabledefinitionData data = new SfConsumabledefinitionData();
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfConsumabledefinitionData.Partnumber, partnumber);
		cond.set(SfConsumabledefinitionData.Validstate, kr.co.micube.commons.factory.util.Constant.VALIDSTATE_VALID);
		return data.selectOne(cond);
	}
}
