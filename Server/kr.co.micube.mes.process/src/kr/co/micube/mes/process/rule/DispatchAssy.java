package kr.co.micube.mes.process.rule;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.HashMap;
import java.util.Map;

import kr.co.micube.common.mes.constant.ProcessClass;
import kr.co.micube.common.mes.constant.WorkorderState;
import kr.co.micube.common.mes.service.CtSpecDefinitionService;
import kr.co.micube.common.mes.service.SfConsumableLotService;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.mes.service.SfProductDefinitionService;
import kr.co.micube.common.mes.service.SfWorkorderService;
import kr.co.micube.common.mes.service.UlErptmesmatinputService;
import kr.co.micube.common.mes.service.UlErptmesworkreportService;
import kr.co.micube.common.mes.service.UlProcessWorkResultService;
import kr.co.micube.common.mes.service.UlSubProcessWorkResultService;
import kr.co.micube.common.mes.so.CtSpecdefinitionData;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfProductdefinitionData;
import kr.co.micube.common.mes.so.SfWorkorderData;
import kr.co.micube.common.mes.so.UlSubprocessworkresultData;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.ISQLOrderBy;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.SQLOrderBy;
import kr.co.micube.tool.so.SQLOrderByType;
import kr.co.micube.tool.so.support.ISQLDataList;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 조립
 * 설               명	: 조립 실적 확정
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-05-26
 * 수   정   이   력	: 
 * 				  
 */

public class DispatchAssy extends DatasetRule {
	
	// 트랜잭션 정보
	private TxnInfo txnInfo;
	
	// 파라미터
	private String lotId;					// LOT ID
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		SfLotService.validateProcessClass(this.lotId, ProcessClass.ASSEMBLY);					// 조립 LOT인지 검증
		UlSubProcessWorkResultService.validateAllSubProcessFinished(lotId);						// 모든 세부공정이 확정되었는지 검증
		SfLotData lotData = SfLotService.getLot(this.lotId);
		validateWorkorderIsNotCanceled(lotData.getWorkorderid());
		String processSegmentId = lotData.getProcesssegmentid();
		String lastUserId = getLastSubProcessWorkResult(processSegmentId).getWorkenduser();		// 마지막 작업자
		this.txnInfo.setTxnUser(lastUserId);													// History 테이블에 입력될 TrackOutUser 등을 설정
		SfConsumableLotService.commitInputConsumablelot(this.lotId, this.txnInfo);				// 자재투입 확정		
		lotData = SfLotService.trackOut(this.lotId, lotData.getEquipmentid(), this.txnInfo);	// Track Out
		UlProcessWorkResultService.endProcessWorkResult(this.lotId, lotData.getTrackouttime(), lastUserId, this.txnInfo);	// 공정별 생산실적 완료처리
		lotData = SfLotService.dispatch(this.lotId, this.txnInfo);								// 다음공정으로 이동
		if(lotData.getLotstate().equals(Constant.LOTSTATE_FINISHED) && lotData.getQty() > 0) {	// Lot 이 Finished 상태면
			SfConsumableLotService.createConsumableFromLot(this.lotId, this.txnInfo);			// 자재전환
			if(isDivideRequired(lotData)) {
				ISQLDataList<SfConsumablelotData> childConLots = SfConsumableLotService.splitConsumableLotOneByOne(this.lotId, lotData.getCreatedqty(), this.txnInfo);	// 분할
				returnLotId(childConLots);
			}
			else {
				returnLotId(this.lotId);	// 분할되지 않더라도 LOT 라벨 재발행
			}
		}
		String workDate = new SimpleDateFormat("yyyyMMdd").format(SQLService.toDate());			// 작업일자
		UlErptmesworkreportService.createUlErptmesworkreport(this.lotId, processSegmentId, workDate, this.txnInfo);		// 생산실적 ERP I/F
		UlErptmesmatinputService.createUlErptmesmatinput(this.lotId, processSegmentId, workDate, this.txnInfo);			// 자재투입 ERP I/F
	}
	
	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);
		 
		// 파라미터
		this.lotId = body.getString("lotid");
	}
	
	// 작업지시가 취소되었는지 확인
	private void validateWorkorderIsNotCanceled(String workorderId) throws SystemException {
		SfWorkorderData woData = SfWorkorderService.getWorkorder(workorderId);
		if(WorkorderState.CANCEL.equals(woData.getState())) {
			// 작업지시가 취소되어 완료보고를 할 수 없습니다. {0}
			throw new SystemException("CantDispatchWithCanceledWorkorder", String.format("WorkorderId=%s", workorderId));
		}
		if(!Constant.VALIDSTATE_VALID.equals(woData.getValidstate())) {
			// 작업지시가 삭제되어 완료보고를 할 수 없습니다. {0}
			throw new SystemException("CantDispatchWithDeletedWorkorder", String.format("WorkorderId=%s", workorderId));
		}
		if(WorkorderState.CLOSE.equals(woData.getState())) {
			// 작업지시가 완료되어 완료보고를 할 수 없습니다. {0}
			throw new SystemException("CantDispatchWithClosedWorkorder", String.format("WorkorderId=%s", workorderId));
		}
	}
	
	// 마지막 세부공정 실적 조회
	private UlSubprocessworkresultData getLastSubProcessWorkResult(String processSegmentId) throws SystemException {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlSubprocessworkresultData.Lotid, this.lotId);
		cond.set(UlSubprocessworkresultData.Processsegmentid, processSegmentId);
		ISQLOrderBy orderBy = new SQLOrderBy(SQLOrderByType.Descending);
		orderBy.addColumn(UlSubprocessworkresultData.Createdtime);
		UlSubprocessworkresultData data = new UlSubprocessworkresultData();
		return data.selectFirst(cond, orderBy);
	}
	
	// LOT 분할공정 여부
	private Boolean isDivideRequired(SfLotData lotData) throws DatabaseException {
		SfProductdefinitionData prodDefData = SfProductDefinitionService.getProductdefinition(lotData.getProductdefid(), lotData.getProductdefversion());		
		CtSpecdefinitionData specDefData = CtSpecDefinitionService.getSpecDefinition(prodDefData.getSpecdefid());
		return Constant.YES.equals(specDefData.getIsdivide());
	}
	
	// 클라이언트에 생성된 LOT ID 반환
	private void returnLotId(ISQLDataList<SfConsumablelotData> childConLots) {
		IDataSet ds = this.getResponseDataset();
		IDataTable dt = ds.addTable("DATA");
		if(childConLots != null) {
			for(int i = 0; i < childConLots.size(); i++) {
				SfConsumablelotData conLotData = childConLots.get(i);
				SfConsumablelotKey conLotKey = conLotData.key();
				Map<String, Object> result = new HashMap<String, Object>();
				result.put("LOTID", conLotKey.getConsumablelotid());
				dt.addRow(result);
			}
		}
	}
	
	// 클라이언트에 LOT ID 반환
	private void returnLotId(String lotId) {
		IDataSet ds = this.getResponseDataset();
		IDataTable dt = ds.addTable("DATA");
		Map<String, Object> result = new HashMap<String, Object>();
		result.put("LOTID", lotId);
		dt.addRow(result);
	}
}
