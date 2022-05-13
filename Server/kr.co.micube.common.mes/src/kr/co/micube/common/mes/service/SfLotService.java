package kr.co.micube.common.mes.service;

import java.util.ArrayList;
import java.util.List;

import kr.co.micube.common.mes.constant.ProcessClass;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfLotKey;
import kr.co.micube.common.mes.so.SfProductdefinitionData;
import kr.co.micube.common.mes.so.SfWorkorderData;
import kr.co.micube.common.mes.so.SfWorkorderKey;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.so.LotData;
import kr.co.micube.commons.factory.so.ProcessdefinitionData;
import kr.co.micube.commons.factory.standard.info.CreateLotInfo;
import kr.co.micube.commons.factory.standard.info.DispatchLotInfo;
import kr.co.micube.commons.factory.standard.info.StartLotInfo;
import kr.co.micube.commons.factory.standard.info.TrackInInfo;
import kr.co.micube.commons.factory.standard.info.TrackOutInfo;
import kr.co.micube.commons.factory.standard.service.IdService;
import kr.co.micube.commons.factory.standard.service.LotService;
import kr.co.micube.commons.factory.standard.service.ProcessDefinitionService;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.StringUtils;

public class SfLotService {
	
	/**
	 * LOT을 반환.
	 * @param lotId
	 * @return LOT
	 * @throws DatabaseException
	 */
	public static SfLotData getLot(String lotId) throws DatabaseException {
		SfLotData data = new SfLotData();
		SfLotKey key = data.key();
		key.setLotid(lotId);
		return data.selectOne();
	}
	
	/**
	 * 작업지시 정보를 이용해 LOT을 생성하고 LOT을 시작(startLot)한다. LOT번호는 'PLotNo' 규칙에 의해 채번된다. 작업장은 품목에 정의된 작업장으로 설정.
	 * @param workorderId 작업지시 번호
	 * @param lotType LOT 타입
	 * @param qty LOT 생성 수량
	 * @param txnInfo 트랜잭션 정보
	 * @return LOT
	 * @throws Throwable
	 */
	public static SfLotData createLot(String workorderId, String lotType, Double qty, TxnInfo txnInfo) throws Throwable {
		List<String> idList = IdService.createId("PLotNo", 1, new ArrayList<String>(), txnInfo);
		String lotId = idList.get(0);
		return createLot(lotId, workorderId, lotType, qty, txnInfo);
	}
	
	/**
	 * 작업지시 정보를 이용해 LOT을 생성하고 LOT을 시작(startLot)한다. 작업장은 품목에 정의된 작업장으로 설정.
	 * @param lotId LOT ID
	 * @param workorderId 작업지시 번호
	 * @param lotType LOT 타입
	 * @param qty 생성 수량
	 * @param txnInfo 트랜잭션 정보
	 * @return LOT
	 * @throws Throwable
	 */
	public static SfLotData createLot(String lotId, String workorderId, String lotType, Double qty, TxnInfo txnInfo) throws Throwable {
		SfWorkorderData woData = SfWorkorderService.getWorkorder(workorderId);
		SfProductdefinitionData prodDefData = SfProductDefinitionService.getProductdefinition(woData.getProductdefid(), woData.getProductdefversion());
		if(StringUtils.isNullOrEmpty(prodDefData.getAreaid())) {
			// 품목정보에 작업장이 지정되지 않았습니다.
			throw new SystemException("AreaIsNotSpecified");
		}
		LotData lotData = createLotByWorkorder(woData, lotId, lotType, qty, prodDefData.getAreaid(), txnInfo);
		lotData.setCreatedqty(qty);	// NOTE : createLot API 에서 CreatedQty 를  초기화하지 않아 강제설정
		lotData.update();
		startLot(lotId, qty, txnInfo);
		return getLot(lotId);
	}

	// 작업지시 정보를 이용해 Lot 생성
	private static LotData createLotByWorkorder(SfWorkorderData woData, String lotId, String lotType, Double qty, String areaId, TxnInfo txnInfo) throws Throwable {
		SfWorkorderKey woKey = woData.key();
		CreateLotInfo lotInfo = new CreateLotInfo();
		lotInfo.setLotId(lotId);
		lotInfo.setRootLotID(lotId);
		lotInfo.setEnterpriseId(woData.getEnterpriseid());
		lotInfo.setPlantId(woData.getPlantid());
		lotInfo.setAreaId(areaId);
		lotInfo.setWorkOrderId(woKey.getWorkorderid());
		lotInfo.setProductionOrderId(woData.getProductionorderid());
		lotInfo.setProductDefId(woData.getProductdefid());
		lotInfo.setProductDefVersion(woData.getProductdefversion());
		lotInfo.setCreatedQty(qty);
		lotInfo.setQty(qty);
		lotInfo.setLotType(lotType);
		return LotService.createLot(lotInfo, txnInfo);
	}
	
	// LotState 를 Created 에서 InProduction 으로 변경한다.
	private static LotData startLot(String lotId, Double qty, TxnInfo txnInfo) throws Throwable {
		StartLotInfo startLotInfo = new StartLotInfo();
		startLotInfo.setLotId(lotId);
		startLotInfo.setQty(qty);
		return LotService.startLot(startLotInfo, txnInfo);
	}
	
	/**
	 * 작업시작
	 * @param lotId LOT ID
	 * @param equipmentId 설비 ID 
	 * @param txnInfo 트랜잭션 정보
	 * @return LOT
	 * @throws Throwable
	 */
	public static SfLotData trackIn(String lotId, String equipmentId, TxnInfo txnInfo) throws Throwable {
		TrackInInfo trackInInfo = new TrackInInfo();
		trackInInfo.setLotId(lotId);
		trackInInfo.setEquipmentId(equipmentId);
		LotService.trackIn(trackInInfo, txnInfo);
		return getLot(lotId);
	}
	
	/**
	 * 작업완료
	 * @param lotId LOT ID
	 * @param equipmentId 설비 ID
	 * @param txnInfo 트랜잭션 정보
	 * @return LOT
	 * @throws Throwable
	 */
	public static SfLotData trackOut(String lotId, String equipmentId, TxnInfo txnInfo) throws Throwable {
		TrackOutInfo trackOutInfo = new TrackOutInfo();
		trackOutInfo.setLotId(lotId);
		trackOutInfo.setEquipmentId(equipmentId);
		LotService.trackOut(trackOutInfo, txnInfo);
		return getLot(lotId);
	}
	
	/**
	 * LOT 을 다음공정으로 이동시키고, 마지막 공정인 경우 LotState를 Finished 로 변경한다.
	 * 자재전환해야 하는 경우 자재전환 함수를 별도로 호출해야 한다. (SfConsumableLotService.createConsumableFromLot)
	 * @param lotId LOT ID
	 * @param txnInfo 트랜잭션 정보
	 * @return LOT
	 * @throws Throwable
	 */
	public static SfLotData dispatch(String lotId, TxnInfo txnInfo) throws Throwable {
		DispatchLotInfo dispatchLotInfo = new DispatchLotInfo();
		dispatchLotInfo.setLotId(lotId);
		dispatchLotInfo.setMoveFlag(Constant.MOVEFLAG_NORMAL);
		LotService.dispatchLot(dispatchLotInfo, txnInfo);
		return getLot(lotId);
	}
	
	/**
	 * 해당 화면에서 실적등록 가능한 LOT인지 검증한다.
	 * 오류 메세지 :
	 * 		LotProcessIsNotAssembly : 조립 화면에서 작업할 수 있는 LOT이 아닙니다. {0}
	 * 		LotProcessIsNotMachining : 기계가공 화면에서 작업할 수 있는 LOT이 아닙니다. {0}
	 * 		LotProcessIsNotRepair : 수리 화면에서 작업할 수 있는 LOT이 아닙니다. {0}
	 * 		LotProcessIsNotNoWorkorder : 무지시 작업 화면에서 작업할 수 있는 LOT이 아닙니다. {0}
	 * @param lotId LOT ID
	 * @param processClassId 라우팅 그룹 ID
	 * @throws Throwable
	 */
	public static void validateProcessClass(String lotId, String processClassId) throws Throwable {
		SfLotData lotData = getLot(lotId);
		ProcessdefinitionData processData = ProcessDefinitionService.getProcessDef(lotData.getProcessdefid(), lotData.getProcessdefversion());
		if(!processData.getProcessclassid().equals(processClassId)) {
			switch(processClassId) {
			case ProcessClass.ASSEMBLY:
				// 조립 화면에서 작업할 수 있는 LOT이 아닙니다. {0}
				throw new SystemException("LotProcessIsNotAssembly", String.format("ProcessDefId=%s", lotData.getProcessdefid()));
			case ProcessClass.MACHINING:
				// 기계가공 화면에서 작업할 수 있는 LOT이 아닙니다. {0}
				throw new SystemException("LotProcessIsNotMachining", String.format("ProcessDefId=%s", lotData.getProcessdefid()));
			case ProcessClass.REPAIR:
				// 수리 화면에서 작업할 수 있는 LOT이 아닙니다. {0}
				throw new SystemException("LotProcessIsNotRepair", String.format("ProcessDefId=%s", lotData.getProcessdefid()));
			case ProcessClass.NOWORKORDER:
				// 무지시 작업 화면에서 작업할 수 있는 LOT이 아닙니다. {0}
				throw new SystemException("LotProcessIsNotNoWorkorder", String.format("ProcessDefId=%s", lotData.getProcessdefid()));
			}
		}
	}
	
	/**
	 * LOT 이 InProduction 상태인지 유효성 검사를 한다.
	 * @param lotId
	 * @throws SystemException
	 */
	public static void validateLotStateIsInProduction(String lotId) throws SystemException {
		SfLotData lotData = getLot(lotId);
		if(!lotData.getLotstate().equals(Constant.LOTSTATE_INPRODUCTION)) {
			// LOT 이 InProduction 상태가 아닙니다.
			throw new SystemException("LotStateIsNotInProduction");
		}
	}
}
