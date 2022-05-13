package kr.co.micube.common.mes.service;

import kr.co.micube.common.mes.so.CtSubsegmentspecData;
import kr.co.micube.common.mes.so.CtSubsegmentspecKey;
import kr.co.micube.common.mes.so.CtSubsegmentspecdetailData;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.support.ISQLDataList;

public class CtSubSegmentSpecDetailService {
	/**
	 * 세부공정 스펙 상세목록 반환
	 * @param specDefid SPEC ID
	 * @param subProcessSegmentId 세부공정 ID
	 * @return 세부공정 스펙 상세목록
	 * @throws DatabaseException
	 */
	public static ISQLDataList<CtSubsegmentspecdetailData> getSubSegmentSpecDetail(String specDefid, String subProcessSegmentId, String specDefIdVersion) throws DatabaseException {
		CtSubsegmentspecData specData = CtSubSegmentSpecService.getSubSegmentSpec(specDefid, subProcessSegmentId, specDefIdVersion);
		CtSubsegmentspecKey specKey = specData.key(); 
		return getSubSegmentSpecDetailByKey(specKey.getSpecdefid(), specKey.getSpecsequence(), specKey.getSpecdefidversion());
	}
	
	/**
	 * 세부공정 스펙 상세목록 반환
	 * @param specDefId SPEC ID
	 * @param specSequence SPEC SEQ
	 * @return 세부공정 스펙 상세목록
	 * @throws DatabaseException
	 */
	public static ISQLDataList<CtSubsegmentspecdetailData> getSubSegmentSpecDetailByKey(String specDefId, Double specSequence, String specDefIdVersion) throws DatabaseException {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(CtSubsegmentspecdetailData.Specdefid, specDefId);
		cond.set(CtSubsegmentspecdetailData.Specsequence, specSequence);
		cond.set(CtSubsegmentspecdetailData.Specdefidversion, specDefIdVersion);
		CtSubsegmentspecdetailData data = new CtSubsegmentspecdetailData();
		return data.select(cond);
	}
}
