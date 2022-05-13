package kr.co.micube.common.mes.service;

import kr.co.micube.common.mes.constant.ProcessClass;
import kr.co.micube.common.mes.constant.WorkorderState;
import kr.co.micube.common.mes.so.SfProductdefinitionData;
import kr.co.micube.common.mes.so.SfWorkorderData;
import kr.co.micube.common.mes.so.SfWorkorderKey;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.so.ProcessdefinitionData;
import kr.co.micube.commons.factory.standard.service.ProcessDefinitionService;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;

public class SfWorkorderService {
	
	/**
	 * 작업지시 객체를 반환.
	 * @param workorderId 작업지시 번호
	 * @return 작업지시
	 * @throws DatabaseException
	 */
	public static SfWorkorderData getWorkorder(String workorderId) throws DatabaseException {
		SfWorkorderData data = new SfWorkorderData();
		SfWorkorderKey key = data.key();
		key.setWorkorderid(workorderId);
		return data.selectOne();
	}
	
	/**
	 * 작업지시의 공정을 검증한다.
	 * 오류 메세지 :
	 * 		WorkorderProcessIsNotMachining : 기계가공 작업지시가 아닙니다. {0}
	 * 		WorkorderProcessIsNotRepair : 수리 작업지시가 아닙니다. {0}
	 * @param workorderId 작업지시 번호
	 * @param processClassId 라우팅 그룹 ID 
	 * @throws Throwable
	 */
	public static void validateProcessClass(String workorderId, String processClassId) throws Throwable {
		SfWorkorderData woData = SfWorkorderService.getWorkorder(workorderId);
		SfProductdefinitionData prodDefData = SfProductDefinitionService.getProductdefinition(woData.getProductdefid(), woData.getProductdefversion());
		ProcessdefinitionData processData = ProcessDefinitionService.getProcessDef(prodDefData.getProcessdefid(), prodDefData.getProcessdefversion());
		if(!processData.getProcessclassid().equals(processClassId)) {
			switch(processClassId) {
			case ProcessClass.MACHINING:
				// 기계가공 작업지시가 아닙니다. {0}
				throw new SystemException("WorkorderProcessIsNotMachining", String.format("ProcessDefId=%s", prodDefData.getProcessdefid()));
			case ProcessClass.REPAIR:
				// 수리 작업지시가 아닙니다. {0}
				throw new SystemException("WorkorderProcessIsNotRepair", String.format("ProcessDefId=%s", prodDefData.getProcessdefid()));
			}
		}
	}
	
	public static void start(String workorderId, TxnInfo txnInfo) throws SystemException {
		SfWorkorderData data = getWorkorder(workorderId);
		if(!WorkorderState.PROCESS.equals(data.getState())) {
			// 진행상태의 작업지시만 시작할 수 있습니다.
			throw new SystemException("OnlyProcessWorkorderCanStart");
		}
	}
	
	public static void end(String workorderId, TxnInfo txnInfo) throws SystemException
	{
		SfWorkorderData data = getWorkorder(workorderId);
		if(!WorkorderState.PROCESS.equals(data.getState())) {
			// 진행상태의 작업지시만 완료할 수 있습니다.
			throw new SystemException("OnlyProcessWorkorderCanEnd");
		}
	}
}
