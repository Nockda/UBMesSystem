package kr.co.micube.common.mes.service;

import kr.co.micube.common.mes.so.SfProductdefinitionData;
import kr.co.micube.common.mes.so.SfProductdefinitionKey;
import kr.co.micube.core.sql.exception.DatabaseException;

public class SfProductDefinitionService {
	
	/**
	 * 품목 정의 반환.
	 * @param productdefId 품목 정의 ID
	 * @param productdefVersion 품목 정의 버전
	 * @return 품목 정의
	 * @throws DatabaseException
	 */
	public static SfProductdefinitionData getProductdefinition(String productdefId, String productdefVersion) throws DatabaseException {
		SfProductdefinitionData data = new SfProductdefinitionData();
		SfProductdefinitionKey key = data.key();
		key.setProductdefid(productdefId);
		key.setProductdefversion(productdefVersion);
		return data.selectOne();
	}
}
