package kr.co.micube.common.mes.service;

import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfLotKey;
import kr.co.micube.common.mes.so.SfLotworkerData;
import kr.co.micube.common.mes.so.SfLotworkerKey;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.SQLDataList;

public class SfLotWorkerService {

	/**
	 * LotWorker 등록
	 * @param lotId LOT ID
	 * @param userId 작업자 ID
	 * @param subprocessSegmentId 세부공정 ID
	 * @param equipmentId 설비 ID
	 * @return LotWorker
	 * @throws DatabaseException
	 */
	public static SfLotworkerData createSfLotworker(String lotId, String userId, String subprocessSegmentId, String equipmentId, TxnInfo txnInfo) throws DatabaseException {
		SfLotData lotData = SfLotService.getLot(lotId);
		return insertLotWorker(lotData, userId, subprocessSegmentId, equipmentId, txnInfo);
	}
	
	/**
	 * LotWorker 등록
	 * @param lotId LOT ID
	 * @param userIds 작업자 ID 리스트
	 * @param subprocessSegmentId 세부공정 ID
	 * @param equipmentId 설비 ID
	 * @return LotWorker 리스트
	 * @throws DatabaseException
	 */
	public static ISQLDataList<SfLotworkerData> createSfLotworker(String lotId, String[] userIds, String subprocessSegmentId, String equipmentId, TxnInfo txnInfo) throws DatabaseException {
		SfLotData lotData = SfLotService.getLot(lotId);
		ISQLDataList<SfLotworkerData> result = new SQLDataList<SfLotworkerData>(SfLotworkerData.class);
		for(int i = 0; i < userIds.length; i++) {
			result.add(insertLotWorker(lotData, userIds[i], subprocessSegmentId, equipmentId, txnInfo));
		}
		return result;
	}
	
	// LotWorker 테이블에 데이터 생성
	private static SfLotworkerData insertLotWorker(SfLotData lotData, String userId, String subprocessSegmentId, String equipmentId, TxnInfo txnInfo) throws DatabaseException {
		SfLotKey lotKey = lotData.key();
		SfLotworkerData data = new SfLotworkerData();
		SfLotworkerKey key = data.key();
		key.setLotid(lotKey.getLotid());
		key.setTxnhistkey(Generate.createTimeKey());
		data.setEnterpriseid(lotData.getEnterpriseid());
		data.setPlantid(lotData.getPlantid());
		data.setAreaid(lotData.getAreaid());
		data.setProductdefid(lotData.getProductdefid());
		data.setProductdefversion(lotData.getProductdefversion());
		data.setProcessdefid(lotData.getProcessdefid());
		data.setProcessdefversion(lotData.getProcessdefversion());
		data.setProcesssegmentid(lotData.getProcesssegmentid());
		data.setProcesssegmentversion(lotData.getProcesssegmentversion());
		data.setSubprocesssegmentid(subprocessSegmentId);
		data.setProcesspathid(StringUtils.convertStringToStack(lotData.getProcesspathstack(), ".").peek());
		data.setUsersequence(lotData.getUsersequence());
		data.setEquipmentid(equipmentId);
		data.setUserid(userId);
		data.txnInfo().set(txnInfo.getTransaction());
		data.insert();
		return data;
	}
	
	/**
	 * Lotworker 삭제
	 * @param lotId LOT ID
	 * @throws DatabaseException
	 */
	public static void deleteSfLotworker(String lotId) throws DatabaseException {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfLotworkerData.Lotid, lotId);
		SfLotworkerData data = new SfLotworkerData();
		data.delete(cond);
	}
}
