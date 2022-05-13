package kr.co.micube.common.mes.service;

import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.WorkorderState;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfProductdefinitionData;
import kr.co.micube.common.mes.so.SfWorkorderData;
import kr.co.micube.common.mes.so.UlSubprocessworkresultData;
import kr.co.micube.common.mes.so.UlSubprocessworkresultKey;
import kr.co.micube.common.util.QueryProvider;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.support.ISQLDataList;

public class UlSubProcessWorkResultService {

	/**
	 * 세부공정 실적 조회
	 * 오류 메세지 : 
	 * 		SubProcessResultNotFound : 세부공정 실적을 찾을 수 없습니다.
	 * @param lotId LOT ID
	 * @param processSegmentId 공정 ID
	 * @param subProcessSegmentId 세부공정 ID
	 * @return 세부공정 실적
	 * @throws SystemException
	 */
	public static UlSubprocessworkresultData getSubProcessWorkResult(String lotId, String processSegmentId, String subProcessSegmentId) throws SystemException {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlSubprocessworkresultData.Lotid, lotId);
		cond.set(UlSubprocessworkresultData.Processsegmentid, processSegmentId);
		cond.set(UlSubprocessworkresultData.Subprocesssegmentid, subProcessSegmentId);
		UlSubprocessworkresultData data = new UlSubprocessworkresultData();
		data = data.selectOne(cond);
		if(data == null) {
			// 세부공정 실적을 찾을 수 없습니다.
			throw new SystemException("SubProcessResultNotFound");
		}
		return data;
	}
	
	/**
	 * 세부공정 작업시작
	 * 오류 메세지 : 
	 * 		SubProcessIsNotFinished : 먼저 현재 확정되지 않은 세부공정 실적을 확정해주세요.
	 * 		SubProcessResultAlreadyRegistered : 이미 실적등록된 세부공정입니다.
	 * @param lotId LOT ID
	 * @param subProcessSegmentId 세부공정 ID
	 * @param equipmentId 설비 ID
	 * @param workStartTime 작업시작 시간
	 * @param userId 작업자 ID
	 * @param txnInfo 트랜잭션 정보
	 * @return 세부공정 실적
	 * @throws Throwable
	 */
	public static UlSubprocessworkresultData startSubProcessWorkResult(String lotId, String subProcessSegmentId, String equipmentId, Date workStartTime, String userId, TxnInfo txnInfo, String specDefIdVersion) throws Throwable {
		SfLotData lotData = SfLotService.getLot(lotId);
		
		// 유효성 검사
		validateUnFinishedResultNotExists(lotId, lotData.getProcesssegmentid());
		validateIsResultNotRegistered(lotId, lotData.getProcesssegmentid(), subProcessSegmentId);
		validateWorkorderIsNotCanceled(lotData.getWorkorderid());
		
		// 실적 등록
		SfProductdefinitionData prodData = SfProductDefinitionService.getProductdefinition(lotData.getProductdefid(), lotData.getProductdefversion());
		UlSubprocessworkresultData data = new UlSubprocessworkresultData();
		UlSubprocessworkresultKey key = data.key();
		key.setTxnhistkey(Generate.createTimeKey());	// 임의 키 생성
		data.setLotid(lotId);
		data.setProcesssegmentid(lotData.getProcesssegmentid());
		data.setSubprocesssegmentid(subProcessSegmentId);
		data.setWorkstarttime(workStartTime);
		data.setWorkstartuser(userId);
		data.setWorkstartqty(lotData.getQty());
		data.setEquipmentid(equipmentId);
		data.setSpecdefid(prodData.getSpecdefid());
		data.setChargeuserid(userId);
		data.setIsfinished(Constant.NO);
		data.txnInfo().set(txnInfo.getTransaction());
		data.setSpecdefidversion(specDefIdVersion);
		data.insert();
		return data;
	}
	
	// 미확정 세부공정 실적이 있는지 확인
	public static void validateUnFinishedResultNotExists(String lotId, String processSegmentId) throws SystemException {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlSubprocessworkresultData.Lotid, lotId);
		cond.set(UlSubprocessworkresultData.Processsegmentid, processSegmentId);
		cond.set(UlSubprocessworkresultData.Isfinished, Constant.NO);
		UlSubprocessworkresultData data = new UlSubprocessworkresultData();
		ISQLDataList<UlSubprocessworkresultData> list = data.select(cond);
		if(list.size() > 0) {
			// 먼저 현재 확정되지 않은 세부공정 실적을 확정해주세요.
			throw new SystemException("SubProcessIsNotFinished");
		}
	}
	
	// 세부공정의 실적이 이미 등록되어 있는지 확인
	private static void validateIsResultNotRegistered(String lotId, String processSegmentId, String subProcessSegmentId) throws SystemException {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlSubprocessworkresultData.Lotid, lotId);
		cond.set(UlSubprocessworkresultData.Processsegmentid, processSegmentId);
		cond.set(UlSubprocessworkresultData.Subprocesssegmentid, subProcessSegmentId);
		UlSubprocessworkresultData data = new UlSubprocessworkresultData();
		ISQLDataList<UlSubprocessworkresultData> list = data.select(cond);
		if(list.size() > 0) {
			// 이미 실적등록된 세부공정입니다.
			throw new SystemException("SubProcessResultAlreadyRegistered");
		}
	}
	
	// 작업지시가 취소상태가 아닌지 확인
	private static void validateWorkorderIsNotCanceled(String workorderId) throws SystemException {
		SfWorkorderData woData = SfWorkorderService.getWorkorder(workorderId);
		if(WorkorderState.CANCEL.equals(woData.getState())) {
			// 작업지시가 취소되어 작업시작을 할 수 없습니다. {0}
			throw new SystemException("CantStartWorkWithCanceledWorkorder", String.format("WorkorderId=%s", workorderId));
		}
	}
	
	/**
	 * LOT의 현재 공정에 등록된 세부공정이 하나도 없는지 확인
	 * @param lotId LOT ID
	 * @param processSegmentId 공정 ID
	 * @return true = 하나도 없음, false = 있음
	 * @throws SystemException
	 */
	public static Boolean isSubProcessWorkResultEmpty(String lotId) throws SystemException {
		SfLotData lotData = SfLotService.getLot(lotId);
		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlSubprocessworkresultData.Lotid, lotId);
		cond.set(UlSubprocessworkresultData.Processsegmentid, lotData.getProcesssegmentid());
		UlSubprocessworkresultData data = new UlSubprocessworkresultData();
		ISQLDataList<UlSubprocessworkresultData> list = data.select(cond);
		return list.size() == 0;
	}
	
	/**
	 * 세부공정 작업완료 및 불량수량 차감
	 * 오류 메세지 : 
	 * 		SubProcessIsNotRunning : 세부공정이 작업중 상태가 아닙니다.
	 * @param lotId LOT ID
	 * @param subProcessSegmentId 세부공정 ID
	 * @param workEndTime 작업완료 시간
	 * @param userId 작업자 ID
	 * @param txnInfo 트랜잭션 정보
	 * @return 세부공정 실적
	 * @throws Throwable
	 */
	public static UlSubprocessworkresultData endSubProcessWorkResult(String lotId, String subProcessSegmentId, Date workEndTime, String userId, Double workTime, String comment, TxnInfo txnInfo) throws Throwable {
		SfLotData lotData = SfLotService.getLot(lotId);
		UlSubprocessworkresultData data = getSubProcessWorkResult(lotId, lotData.getProcesssegmentid(), subProcessSegmentId);
		if(data.getWorkendtime() != null) {	// 세부공정이 이미 완료되었으면
			// 세부공정이 작업중 상태가 아닙니다.
			throw new SystemException("SubProcessIsNotRunning");
		}
		// 불량에 의한 수량 차감
		Map<String, Object> param = new HashMap<String, Object>();
		param.put("LOTID", lotId);
		List<Map<String, Object>> result = QueryProvider.select("GetAssyDefectQty", "00001", param);
		Double lotQty = lotData.getCreatedqty() - Double.valueOf(result.get(0).get("DEFECTQTY").toString());
		if(!lotData.getQty().equals(lotQty)) {
			lotData.setQty(lotQty);
			lotData.update();
		}
		// 세부공정 작업완료 실적 등록
		data.setWorkendtime(workEndTime);
		data.setWorkenduser(userId);
		data.setWorkendqty(lotData.getQty());
		data.setWorktime(workTime);
		data.setComments(comment);
		data.txnInfo().set(txnInfo.getTransaction());
		data.update();
		return data;
	}
	
	/**
	 * 세부공정 실적 확정
	 * 오류 메세지 : 
	 * 		SubProcessIsRunning : 먼저 현재 작업중인 세부공정을 완료해주세요.
	 * 		SubProcessIsFinished : 이미 확정된 실적입니다.
	 * 		SubProcessResultDetailMissing : 입력되지 않은 검사실적 있는지 확인
	 * @param lotId LOT ID
	 * @param subProcessSegmentId 세부공정 ID
	 * @param txnInfo 트랜잭션 정보
	 * @return 세부공정 실적
	 * @throws Throwable
	 */
	public static UlSubprocessworkresultData finishSubProcessWorkResult(String lotId, String subProcessSegmentId, TxnInfo txnInfo, String specDefIdVersion) throws Throwable {
		SfLotData lotData = SfLotService.getLot(lotId);
		UlSubprocessworkresultData data = getSubProcessWorkResult(lotId, lotData.getProcesssegmentid(), subProcessSegmentId);
		if(data.getWorkendtime() == null) {	// 세부공정이 완료되지 않았으면
			// 먼저 현재 작업중인 세부공정을 완료해주세요.
			throw new SystemException("SubProcessIsRunning");
		}
		if(data.getIsfinished() != null && data.getIsfinished().equals(Constant.YES)) {
			// 이미 확정된 실적입니다.
			throw new SystemException("SubProcessIsFinished");
		}
		validateIsInspResultRegistered(lotId, subProcessSegmentId, lotData.getCreatedqty(), specDefIdVersion);
		data.setIsfinished(Constant.YES);
		data.txnInfo().set(txnInfo.getTransaction());		
		data.update();
		return data;
	}
	
	// 등록되지 않은 검사실적이 있는지 확인
	private static void validateIsInspResultRegistered(String lotId, String subProcessSegmentId, Double createdQty, String specDefIdVersion) throws SystemException {
		Map<String, Object> param = new HashMap<String, Object>();
		param.put("LOTID", lotId);
		param.put("SUBPROCESSSEGMENTID", subProcessSegmentId);
		param.put("CREATEDQTY", createdQty);
		param.put("SPECDEFIDVERSION", specDefIdVersion);
		List<Map<String, Object>> result = QueryProvider.select("GetMissingSubProcessResultDetail", "00001", param);
		if(result.size() > 0) {
			if(Integer.valueOf(result.get(0).get("RESULTNOTFOUND").toString()) > 0) {
				// 등록되지 않은 검사실적이 있습니다.
				throw new SystemException("SubProcessResultDetailMissing");
			}
		}
	}

	/**
	 * 공정 내 모든 세부공정의 실적이 확정되었는지 검증
	 * 오류 메세지 : 
	 * 		SubProcessResultMissing : 등록되지 않은 세부공정실적이 있습니다.
	 * @param lotId LOT ID
	 * @throws Throwable
	 */
	public static void validateAllSubProcessFinished(String lotId) throws Throwable {
		SfLotData lotData = SfLotService.getLot(lotId);
		
		Map<String, Object> param = new HashMap<String, Object>();
		param.put("LOTID", lotId);
		param.put("QTY", lotData.getQty());
		List<Map<String, Object>> result = QueryProvider.select("GetMissingSubProcessResult", "00001", param);
		if(result.size() > 0) {
			if(Integer.valueOf(result.get(0).get("RESULTNOTFOUND").toString()) > 0) {
				// 등록되지 않은 세부공정실적이 있습니다.
				throw new SystemException("SubProcessResultMissing");
			}
		}
	}
}
