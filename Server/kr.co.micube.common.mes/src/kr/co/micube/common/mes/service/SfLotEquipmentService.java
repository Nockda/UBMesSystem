package kr.co.micube.common.mes.service;

import java.util.Date;

import kr.co.micube.common.mes.so.SfEquipmentData;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfLotKey;
import kr.co.micube.common.mes.so.SfLotequipmentData;
import kr.co.micube.common.mes.so.SfLotequipmentKey;
import kr.co.micube.common.mes.so.SfLotworkerData;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SfLotEquipmentService {
	
	/**
	 * LOT별 설비작업 실적 작업시작
	 * @param lotId LOT ID
	 * @param equipmentId 설비 ID
	 * @param subprocessSegmentId 세부공정 ID
	 * @param workStartTime 작업시작 시간
	 * @param txnInfo 트랜잭션 정보
	 * @return LotEquipment
	 * @throws SystemException 
	 */
	public static SfLotequipmentData startLotEquipment(String lotId, String equipmentId, String subprocessSegmentId, Date workStartTime, TxnInfo txnInfo) throws SystemException {
		SfLotData lotData = SfLotService.getLot(lotId);
		SfEquipmentData equipData = SfEquipmentService.getEquipment(equipmentId);
		if(equipData == null) {
			// 등록되지 않은 설비입니다. {0}
			throw new SystemException("EquipmentNotFound", String.format("EquipmentId=%s", equipmentId));
		}
		validateIsNotRunning(lotData);
		SfLotequipmentData data = new SfLotequipmentData();
		SfLotequipmentKey key = data.key();
		key.setLotid(lotId);
		key.setTxnhistkey(Generate.createTimeKey());
		data.setEquipmentid(equipmentId);
		data.setProcesssegmentid(lotData.getProcesssegmentid());
		data.setProcesssegmentversion(lotData.getProcesssegmentversion());
		data.setSubprocesssegmentid(subprocessSegmentId);
		data.setTrackintime(workStartTime);
		data.setQty(lotData.getQty());
		data.txnInfo().set(txnInfo.getTransaction());
		data.insert();
		return data;
	}
	
	// 작업중인 설비가 있는지 확인
	private static void validateIsNotRunning(SfLotData lotData) throws SystemException {
		SfLotKey lotKey = lotData.key();
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfLotequipmentData.Lotid);
		cond.set(SfLotequipmentData.Processsegmentid);
		cond.set(SfLotequipmentData.Processsegmentversion);
		cond.set(SfLotequipmentData.Trackouttime);
		SfLotequipmentData data = new SfLotequipmentData();
		SfLotequipmentKey key = data.key();
		key.setLotid(lotKey.getLotid());
		data.setProcesssegmentid(lotData.getProcesssegmentid());
		data.setProcesssegmentversion(lotData.getProcesssegmentversion());
		data.setTrackouttime(null);
		ISQLDataList<SfLotequipmentData> list = data.select(cond);
		if(list.size() > 0) {
			// LOT이 이미 작업중 입니다.
			throw new SystemException("LotIsAlreadyRunning");
		}
	}

	/**
	 * LOT의 현재 공정에 등록된 작업설비가 하나도 없는지 확인
	 * @param lotId LOT ID
	 * @return true = 하나도 없음, false = 있음
	 * @throws DatabaseException
	 */
	public static Boolean isLotEquipmentEmpty(String lotId) throws DatabaseException {
		SfLotData lotData = SfLotService.getLot(lotId);
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfLotequipmentData.Lotid, lotId);
		cond.set(SfLotequipmentData.Processsegmentid, lotData.getProcesssegmentid());
		cond.set(SfLotequipmentData.Processsegmentversion, lotData.getProcesssegmentversion());
		SfLotequipmentData data = new SfLotequipmentData();
		ISQLDataList<SfLotequipmentData> list = data.select(cond);
		return list.size() == 0;
	}

	/**
	 * LOT별 설비작업 실적 작업완료
	 * @param lotId LOT ID
	 * @param txnInfo 트랜잭션 정보
	 * @return LOT별 설비작업 실적
	 * @throws SystemException
	 */
	public static SfLotequipmentData endLotEquipment(String lotId, Date workEndTime, TxnInfo txnInfo) throws SystemException {
		SfLotData lotData = SfLotService.getLot(lotId);
		SfLotequipmentData lotEquipData = getRunningLotEquipment(lotData);
		updateLotWorkerTxnGroupHistKey(lotId, lotEquipData.getTxngrouphistkey(), txnInfo);	// NOTE : SF_LOTWORKER 와의 연결을 유지하기위해 TXNGROUPHISTKEY 를 업데이트 한다.
		lotEquipData.setQty(lotData.getQty());
		lotEquipData.setTrackouttime(workEndTime);
		lotEquipData.txnInfo().set(txnInfo.getTransaction());
		lotEquipData.update();
		return lotEquipData;
	}
	
	// 현재 작업중인 LotEquipmentData 를 가져온다.
	private static SfLotequipmentData getRunningLotEquipment(SfLotData lotData) throws SystemException {
		SfLotKey lotKey = lotData.key();
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfLotequipmentData.Lotid);
		cond.set(SfLotequipmentData.Processsegmentid);
		cond.set(SfLotequipmentData.Processsegmentversion);
		cond.set(SfLotequipmentData.Trackouttime);
		SfLotequipmentData data = new SfLotequipmentData();
		SfLotequipmentKey key = data.key();
		key.setLotid(lotKey.getLotid());
		data.setProcesssegmentid(lotData.getProcesssegmentid());
		data.setProcesssegmentversion(lotData.getProcesssegmentversion());
		data.setTrackouttime(null);
		ISQLDataList<SfLotequipmentData> list = data.select(cond);
		if(list.size() == 0) {
			// 작업중인 설비가 없습니다.
			throw new SystemException("RunningEquipmentNotFound");
		}
		return list.get(0);
	}
	
	// NOTE : SF_LOTWORKER 와의 연결을 유지하기위해 TXNGROUPHISTKEY 를 업데이트 한다.
	private static void updateLotWorkerTxnGroupHistKey(String lotId, String txnGroupHistKey, TxnInfo txnInfo) throws SystemException {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfLotworkerData.Lotid, lotId);
		cond.set(SfLotworkerData.Txngrouphistkey, txnGroupHistKey);
		SfLotworkerData data = new SfLotworkerData();
		ISQLDataList<SfLotworkerData> dataList = data.select(cond);
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		for(int i = 0; i < dataList.size(); i++) {
			SfLotworkerData eachData = dataList.get(i);
			eachData.txnInfo().set(txnInfo.getTransaction());
			batch.add(eachData, SQLUpsertType.UPDATE);
		}
		batch.execute();
	}
	
	/**
	 * LOT별 설비작업 내역에 하나이상의 실적이 있고, 모든 실적이 작업완료상태인지 유효성 검사를 한다.
	 * 오류 메세지 : 
	 * 		NoResultRegistered : 등록된 실적이 없습니다.
	 * 		RunningEquipmentExists : 작업중인 설비가 있습니다.
	 * @param lotId LOT ID
	 * @throws SystemException
	 */
	public static void validateAllLotEquipmentTrackedOut(String lotId) throws SystemException {
		SfLotData lotData = SfLotService.getLot(lotId);
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfLotequipmentData.Lotid, lotId);
		cond.set(SfLotequipmentData.Processsegmentid, lotData.getProcesssegmentid());
		cond.set(SfLotequipmentData.Processsegmentversion, lotData.getProcesssegmentversion());
		SfLotequipmentData data = new SfLotequipmentData();
		ISQLDataList<SfLotequipmentData> list = data.select(cond);
		if (list.size() == 0) {
			// 등록된 실적이 없습니다.
			throw new SystemException("NoResultRegistered");
		}
		for (int i = 0; i < list.size(); i++) {
			SfLotequipmentData each = list.get(i);
			if (each.getTrackouttime() == null) {
				// 작업중인 설비가 있습니다.
				throw new SystemException("RunningEquipmentExists");
			}
		}
	}
}
