package kr.co.micube.common.mes.service;

import kr.co.micube.common.mes.so.SfAreaData;
import kr.co.micube.common.mes.so.SfAreaKey;
import kr.co.micube.core.sql.exception.DatabaseException;

public class SfAreaService {
	
	/**
	 * 작업장 반환.
	 * @param areaId 작업장 ID
	 * @return 작업장
	 * @throws DatabaseException
	 */
	public static SfAreaData getArea(String areaId) throws DatabaseException {
		SfAreaData data = new SfAreaData();
		SfAreaKey key = data.key();
		key.setAreaid(areaId);
		return data.selectOne();
	}
}
