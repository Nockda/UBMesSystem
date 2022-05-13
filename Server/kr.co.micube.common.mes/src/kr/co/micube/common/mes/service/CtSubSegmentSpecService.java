package kr.co.micube.common.mes.service;

import kr.co.micube.common.mes.so.CtSubsegmentspecData;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;

public class CtSubSegmentSpecService {

	/**
	 * 세부공정 스펙을 반환
	 * @param specDefId SPEC 정의 ID
	 * @param subProcessSegmentId 세부공정 ID
	 * @return 세부공정 스펙을
	 * @throws DatabaseException
	 */
	public static CtSubsegmentspecData getSubSegmentSpec(String specDefId, String subProcessSegmentId, String specDefIdVersion) throws DatabaseException {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(CtSubsegmentspecData.Specdefid, specDefId);
		cond.set(CtSubsegmentspecData.Subprocesssegmentid, subProcessSegmentId);
		cond.set(CtSubsegmentspecData.Specdefidversion, specDefIdVersion);
		CtSubsegmentspecData data = new CtSubsegmentspecData();
		return data.selectOne(cond);
	}
}
