package kr.co.micube.common.mes.service;

import kr.co.micube.common.mes.so.SfConsumemateriallottempData;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.support.ISQLDataList;

public class SfConsumeMaterialLotTempService {
	
	/**
	 * 자재 가투입 내역 조회
	 * @param lotId LOT 번호
	 * @param processSegmentId 공정 ID
	 * @return 자재투입 내역
	 * @throws DatabaseException
	 */
	public static ISQLDataList<SfConsumemateriallottempData> getConsumemateriallottempList(String lotId) throws DatabaseException {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfConsumemateriallottempData.Lotid, lotId);
		SfConsumemateriallottempData data = new SfConsumemateriallottempData();
		return data.select(cond);
	}
}
