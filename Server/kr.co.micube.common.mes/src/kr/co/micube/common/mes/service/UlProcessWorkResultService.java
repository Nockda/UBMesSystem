package kr.co.micube.common.mes.service;

import java.util.Date;

import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfLotKey;
import kr.co.micube.common.mes.so.SfProductdefinitionData;
import kr.co.micube.common.mes.so.UlProcessworkresultData;
import kr.co.micube.common.mes.so.UlProcessworkresultKey;
import kr.co.micube.common.mes.util.DateFunction;
import kr.co.micube.common.mes.util.MathFunction;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.support.ISQLDataList;

public class UlProcessWorkResultService {
	
	/**
	 * 공정별 생산실적을 반환
	 * @param lotId LOT ID
	 * @param processSegmentId 공정 ID
	 * @return 공정별 생산실적
	 * @throws DatabaseException
	 */
	public static UlProcessworkresultData getProcessWorkResult(String lotId, String processSegmentId) throws DatabaseException {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlProcessworkresultData.Lotid, lotId);
		cond.set(UlProcessworkresultData.Processsegmentid, processSegmentId);
		UlProcessworkresultData data = new UlProcessworkresultData();
		return data.selectOne(cond);
	}
	
	/**
	 * 공정별 생산실적을 등록하고 작업시작정보를 기입합니다.
	 * @param lotId LOT 번호
	 * @param equipmentId 설비 ID
	 * @param workStartTime 작업시작 시간
	 * @param userId 작업자
	 * @param txnInfo 트랜잭션 정보
	 * @return 공정별 생산실적
	 * @throws SystemException
	 */
	public static UlProcessworkresultData startProcessWorkResult(String lotId, String equipmentId, Date workStartTime, String userId, String comment, TxnInfo txnInfo) throws SystemException {
		SfLotData lotData = SfLotService.getLot(lotId);
		validateIsNotRunning(lotData);
		UlProcessworkresultData data = new UlProcessworkresultData();
		UlProcessworkresultKey key = data.key();
		key.setTxnhistkey(Generate.createTimeKey());	// 임의 키 생성
		data.setLotid(lotId);
		data.setProcesssegmentid(lotData.getProcesssegmentid());
		data.setWorkstarttime(workStartTime);
		data.setWorkstartuser(userId);
		data.setWorkstartqty(lotData.getQty());
		data.setEquipmentid(equipmentId);
		data.setChargeuserid(userId);
		data.setComments(comment);
		data.txnInfo().set(txnInfo.getTransaction());
		data.insert();
		return data;
	}
	
	// 작업중인지 확인
	private static void validateIsNotRunning(SfLotData lotData) throws SystemException {
		SfLotKey lotKey = lotData.key();
		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlProcessworkresultData.Lotid, lotKey.getLotid());
		cond.set(UlProcessworkresultData.Processsegmentid, lotData.getProcesssegmentid());
		UlProcessworkresultData data = new UlProcessworkresultData();
		ISQLDataList<UlProcessworkresultData> list = data.select(cond);
		if(list.size() > 0) {
			if(list.get(0).getWorkendtime() == null) {
				// LOT이 이미 작업중 입니다.
				throw new SystemException("LotIsAlreadyRunning");
			}
			else {
				// 이미 실적등록된 공정입니다.
				throw new SystemException("ProcessWorkResultAlreadyExists");
			}
		}
	}
	
	/**
	 * 공정별 생산실적 작업완료 처리.
	 * 오류 메세지 : 
	 * 		NoResultRegistered : 등록된 실적이 없습니다.
	 * 		ProcessWorkResultAlreadyEnd : 공정실적이 이미 완료되었습니다.
	 * @param lotId LOT ID
	 * @param workEndTime 작업완료 시간
	 * @param userId 작업자
	 * @param txnInfo 트랜잭션 정보
	 * @return 공정별 생산실적
	 * @throws SystemException
	 */
	public static UlProcessworkresultData endProcessWorkResult(String lotId, Date workEndTime, String userId, TxnInfo txnInfo) throws SystemException {
		SfLotData lotData = SfLotService.getLot(lotId);
		SfProductdefinitionData prodDefData = SfProductDefinitionService.getProductdefinition(lotData.getProductdefid(), lotData.getProductdefversion());
		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlProcessworkresultData.Lotid, lotId);
		cond.set(UlProcessworkresultData.Processsegmentid, lotData.getProcesssegmentid());
		UlProcessworkresultData data = new UlProcessworkresultData();
		data = data.selectOne(cond);
		if(data == null) { 
			// 등록된 실적이 없습니다.
			throw new SystemException("NoResultRegistered");
		}
		if(data.getWorkendtime() != null) {
			// 공정실적이 이미 완료되었습니다.
			throw new SystemException("ProcessWorkResultAlreadyEnd");
		}
		data.setWorkendtime(workEndTime);
		data.setWorkendqty(lotData.getQty());
		data.setWorkenduser(userId);
		data.setWorktime(MathFunction.round(DateFunction.dateDiffInMinutes(data.getWorkstarttime(), workEndTime), 2));
		data.setStandardtime(prodDefData.getStandardtime());
		data.txnInfo().set(txnInfo.getTransaction());
		data.update();
		return data;
	}

	/**
	 * 공정 생산실적 작업완료 처리(수리 공정용)
	 * @param lotId LOT ID
	 * @param workEndTime 작업완료 시간
	 * @param workTime 작업시간 및 표준시간(수리는 표준시간이 없음)
	 * @param userId 작업자 ID
	 * @param txnInfo 트랜잭션 정보
	 * @return
	 * @throws SystemException
	 */
	public static UlProcessworkresultData endProcessWorkResultForRepair(String lotId, Date workEndTime, Double workTime, String userId, TxnInfo txnInfo) throws SystemException {
		SfLotData lotData = SfLotService.getLot(lotId);
		SfProductdefinitionData prodDefData = SfProductDefinitionService.getProductdefinition(lotData.getProductdefid(), lotData.getProductdefversion());
		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlProcessworkresultData.Lotid, lotId);
		cond.set(UlProcessworkresultData.Processsegmentid, lotData.getProcesssegmentid());
		UlProcessworkresultData data = new UlProcessworkresultData();
		data = data.selectOne(cond);
		if(data == null) { 
			// 등록된 실적이 없습니다.
			throw new SystemException("NoResultRegistered");
		}
		if(data.getWorkendtime() != null) {
			// 공정실적이 이미 완료되었습니다.
			throw new SystemException("ProcessWorkResultAlreadyEnd");
		}
		data.setWorkendtime(workEndTime);
		data.setWorkendqty(lotData.getQty());
		data.setWorkenduser(userId);
		data.setWorktime(workTime);
		data.setStandardtime(workTime);
		data.txnInfo().set(txnInfo.getTransaction());
		data.update();
		return data;
	}
}
