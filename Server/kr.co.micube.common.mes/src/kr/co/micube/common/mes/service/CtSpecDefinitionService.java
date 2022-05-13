package kr.co.micube.common.mes.service;

import kr.co.micube.common.mes.so.CtSpecdefinitionData;
import kr.co.micube.common.mes.so.CtSpecdefinitionKey;
import kr.co.micube.core.sql.exception.DatabaseException;

public class CtSpecDefinitionService {
	
	/**
	 * 스펙 정의를 반환
	 * @param specDefId 스펙 정의 ID
	 * @return 스펙 정의
	 * @throws DatabaseException
	 */
	public static CtSpecdefinitionData getSpecDefinition(String specDefId) throws DatabaseException {
		CtSpecdefinitionData data = new CtSpecdefinitionData();
		CtSpecdefinitionKey key = data.key();
		key.setSpecdefid(specDefId);
		return data.selectOne();
	}
}
