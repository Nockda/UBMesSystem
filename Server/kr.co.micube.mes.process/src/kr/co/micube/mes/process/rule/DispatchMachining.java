package kr.co.micube.mes.process.rule;

import java.text.DecimalFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;

import kr.co.micube.common.mes.constant.ProcessClass;
import kr.co.micube.common.mes.constant.WorkorderState;
import kr.co.micube.common.mes.service.SfConsumableLotService;
import kr.co.micube.common.mes.service.SfLotEquipmentService;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.mes.service.SfWorkorderService;
import kr.co.micube.common.mes.service.UlErptmesmatinputService;
import kr.co.micube.common.mes.service.UlErptmesworkreportService;
import kr.co.micube.common.mes.service.UlProcessWorkResultService;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfLotKey;
import kr.co.micube.common.mes.so.SfLotequipmentData;
import kr.co.micube.common.mes.so.SfLotworkerData;
import kr.co.micube.common.mes.so.SfWorkorderData;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.ISQLOrderBy;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.SQLOrderBy;
import kr.co.micube.tool.so.SQLOrderByType;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 가공
 * 설               명	: 가공 실적확정
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-05-25
 * 수   정   이   력	: 
 * 				  
 */

public class DispatchMachining extends DatasetRule {

	// 트랜잭션 정보
	private TxnInfo txnInfo;

	// 파라미터
	private String lotId;	// LOT ID
	private Double qty;		// 수량

	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		SfLotService.validateProcessClass(this.lotId, ProcessClass.MACHINING);											// 기계가공 LOT인지 검증
		SfLotEquipmentService.validateAllLotEquipmentTrackedOut(this.lotId);											// 모든 설비를 작업완료 했는지 검증
		SfLotData lotData = SfLotService.getLot(this.lotId);
		validateWorkorderIsNotDeleted(lotData.getWorkorderid());
		validateQty(lotData.getQty());
		String processSegmentId = lotData.getProcesssegmentid();
		String lastUserId = getUserIdFromLotWorker(lotData, getLastLotEquipment(lotData).getEquipmentid());				// 마지막 작업설비의 작업자
		this.txnInfo.setTxnUser(lastUserId);																			// Lot History 등에 기록될 작업자 ID를 설정
		if(this.qty != lotData.getQty()) {	// 입력된 수량이 현재수량과 다르면 LOT 수량 변경
			lotData.setQty(this.qty);
			lotData.update();
		}
		SfConsumableLotService.commitInputConsumablelot(this.lotId, this.txnInfo);										// 자재투입 확정
		lotData = SfLotService.trackOut(this.lotId, lotData.getEquipmentid(), this.txnInfo);							// Track Out
		UlProcessWorkResultService.endProcessWorkResult(lotId, lotData.getTrackouttime(), lastUserId, this.txnInfo);	// 공정별 생산실적 완료 처리
		lotData = SfLotService.dispatch(this.lotId, this.txnInfo);														// 다음공정으로 이동 및 Finished 처리
		if (lotData.getLotstate().equals(Constant.LOTSTATE_FINISHED)) {													// Lot 이 Finished 면
			SfConsumableLotService.createConsumableFromLot(this.lotId, this.txnInfo);									// 자재전환
		}
		
		// ERP I/F
		String workDate = new SimpleDateFormat("yyyyMMdd").format(SQLService.toDate());									// 작업일자
		UlErptmesworkreportService.createUlErptmesworkreport(this.lotId, processSegmentId, workDate, this.txnInfo);		// 생산실적 ERP I/F
		UlErptmesmatinputService.createUlErptmesmatinput(this.lotId, processSegmentId, workDate, this.txnInfo);			// 생산투입 ERP I/F
	}

	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);

		// 파라미터
		this.lotId = body.getString("lotid");
		this.qty = body.getDouble("qty");
	}

	// 현재공정의 해당작업설비의 작업자 정보를 가져온다.
	private String getUserIdFromLotWorker(SfLotData lotData, String equipmentId) throws DatabaseException {
		SfLotKey lotKey = lotData.key();
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfLotworkerData.Lotid, lotKey.getLotid());
		cond.set(SfLotworkerData.Processsegmentid, lotData.getProcesssegmentid());
		cond.set(SfLotworkerData.Processsegmentversion, lotData.getProcesssegmentversion());
		cond.set(SfLotworkerData.Equipmentid, equipmentId);
		ISQLOrderBy orderBy = new SQLOrderBy();
		orderBy.addColumn(SfLotworkerData.Txnhistkey);
		SfLotworkerData data = new SfLotworkerData();
		data = data.selectFirst(cond, orderBy);
		return data.getUserid();
	}

	// 현재공정의 마지막 작업설비 정보를 가져온다.
	private SfLotequipmentData getLastLotEquipment(SfLotData lotData) throws DatabaseException {
		SfLotKey lotKey = lotData.key();
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfLotequipmentData.Lotid, lotKey.getLotid());
		cond.set(SfLotequipmentData.Processsegmentid, lotData.getProcesssegmentid());
		cond.set(SfLotequipmentData.Processsegmentversion, lotData.getProcesssegmentversion());
		ISQLOrderBy orderBy = new SQLOrderBy(SQLOrderByType.Descending);
		orderBy.addColumn(SfLotequipmentData.Txnhistkey);
		SfLotequipmentData data = new SfLotequipmentData();
		return data.selectFirst(cond, orderBy);
	}
	
	private void validateQty(Double lotQty) throws SystemException {
		DecimalFormat format = new DecimalFormat("0.######");
		if(this.qty < 0) {
			// 수량이 0보다 작을 수 없습니다. {0}
			throw new SystemException("QtyCantBeLowerThanZero", String.format("Qty=%s", format.format(this.qty)));
		}
		if(this.qty > lotQty) {
			// 현재 LOT수량보다 큰 수를 입력할 수 없습니다. {0}
			throw new SystemException("QtyCantBeLargerThanLotQty", String.format("Qty=%s, LotQty=%s", format.format(this.qty), format.format(lotQty)));
		}
	}
	
	// 작업지시가 삭제되었는지 확인
	private void validateWorkorderIsNotDeleted(String workorderId) throws SystemException {
		SfWorkorderData woData = SfWorkorderService.getWorkorder(workorderId);
		if(!Constant.VALIDSTATE_VALID.equals(woData.getValidstate())) {
			// 작업지시가 삭제되어 완료보고를 할 수 없습니다. {0}
			throw new SystemException("CantDispatchWithDeletedWorkorder", String.format("WorkorderId=%s", workorderId));
		}
		if(WorkorderState.CLOSE.equals(woData.getState())) {
			// 작업지시가 완료되어 완료보고를 할 수 없습니다. {0}
			throw new SystemException("CantDispatchWithClosedWorkorder", String.format("WorkorderId=%s", workorderId));
		}
	}
}
