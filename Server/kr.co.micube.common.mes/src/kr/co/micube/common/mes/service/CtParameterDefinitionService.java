package kr.co.micube.common.mes.service;

import kr.co.micube.common.mes.so.CtParameterdefinitionData;
import kr.co.micube.common.mes.so.CtParameterdefinitionKey;
import kr.co.micube.core.sql.exception.DatabaseException;

public class CtParameterDefinitionService {
	public static CtParameterdefinitionData getParameterDefinition(String parameterId) throws DatabaseException {
		CtParameterdefinitionData data = new CtParameterdefinitionData();
		CtParameterdefinitionKey key = data.key();
		key.setParameterid(parameterId);
		return data.selectOne();
	}
}
