package kr.co.micube.common.mes.service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.ConsumableLotGenealTxnType;
import kr.co.micube.common.mes.constant.ConsumableTransactionCode;
import kr.co.micube.common.mes.constant.ConsumableTransactionType;
import kr.co.micube.common.mes.constant.ConsumableType;
import kr.co.micube.common.mes.constant.ConsumablelotState;
import kr.co.micube.common.mes.constant.ProcessSegment;
import kr.co.micube.common.mes.constant.ProductDefType;
import kr.co.micube.common.mes.constant.SystemOption;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.CtConsumabletransactionData;
import kr.co.micube.common.mes.so.CtModelstandardinfoData;
import kr.co.micube.common.mes.so.CtModelstandardinfoKey;
import kr.co.micube.common.mes.so.SfAreaData;
import kr.co.micube.common.mes.so.SfConsumabledefinitionData;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.common.mes.so.SfConsumemateriallotData;
import kr.co.micube.common.mes.so.SfConsumemateriallotKey;
import kr.co.micube.common.mes.so.SfConsumemateriallottempData;
import kr.co.micube.common.mes.so.SfConsumemateriallottempKey;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfLotKey;
import kr.co.micube.common.mes.so.SfProductdefinitionData;
import kr.co.micube.common.mes.util.CommonUtils;
import kr.co.micube.common.mes.util.ConsumableTransactionUtils;
import kr.co.micube.common.util.QueryProvider;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.so.ProcesspathData;
import kr.co.micube.commons.factory.standard.info.ConsumeConsumableLotInfo;
import kr.co.micube.commons.factory.standard.info.CreateConsumableLotInfo;
import kr.co.micube.commons.factory.standard.info.CreateConsumeMaterialLotInfo;
import kr.co.micube.commons.factory.standard.info.SplitConsumableLotInfo;
import kr.co.micube.commons.factory.standard.service.CodeService;
import kr.co.micube.commons.factory.standard.service.ConsumableLotService;
import kr.co.micube.commons.factory.standard.service.ConsumeMaterialLotService;
import kr.co.micube.commons.factory.standard.service.ProcessPathService;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.DataSet;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.mes.CodeData;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLDataList;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SfConsumableLotService {

	/**
	 * 자재LOT을 반환.
	 * @param consumablelotId 자재LOT ID
	 * @return 자재LOT
	 * @throws DatabaseException 
	 */
	public static SfConsumablelotData getConsumablelot(String consumablelotId) throws DatabaseException {
		SfConsumablelotData data = new SfConsumablelotData();
		SfConsumablelotKey key = data.key();
		key.setConsumablelotid(consumablelotId);
		return data.selectOne();
	}
	
	/**
	 * 자재 가투입처리를 한다. 자재투입 확정시 자재 소모처리를 한다.
	 * @param lotId LOT번호
	 * @param consumablelotId 자재LOT ID
	 * @param goodQty 자재 양품수량
	 * @param badQty 자재 불량수량
	 * @param serialNo 자재 일련번호
	 * @param txnInfo 트랜잭션 정보
	 * @throws Throwable 
	 */
	public static void inputConsumablelot(String lotId, String consumablelotId, Double goodQty, Double badQty, String serialNo, String comment, String isAllowInputUntracked, TxnInfo txnInfo) throws Throwable {
		SfLotData lotData = SfLotService.getLot(lotId);
		
		if(goodQty < 0 || badQty < 0) {
			// 수량에 음수를 입력할 수 없습니다.
			throw new SystemException("QtyCannotBeNegative");
		}
		// 일련번호 입력여부 검사
		SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(consumablelotId);
		SfConsumabledefinitionData conDefData = SfConsumableDefinitionService.getConsumabledefinition(conLotData.getConsumabledefid(), conLotData.getConsumabledefversion());
		if(Constant.YES.equals(conDefData.getIsserial()) && StringUtils.isNullOrEmpty(serialNo)) {	// 일련번호 관리대상 자재인데 일련번호를 입력하지 않았으면
			// 일련번호 관리대상입니다. 일련번호를 입력해주세요.
			throw new SystemException("SerialNoRequired");
		}
		validateWarehouse(lotData, conLotData);	// LOT 과 투입자재의 창고가 같은지 검사
		Double consumedQty = goodQty + badQty;	// 자재 투입수량
		if(getAvailableQty(conLotData) < consumedQty) {
			// 재고수량을 초과하여 투입할 수 없습니다. {0}
			throw new SystemException("CantInputMoreThanAvailableQty", String.format("ConsumableLotId=%s", consumablelotId));
		}
		if(consumedQty <= 0) {
			// 투입수량이 입력 되지 않았습니다.
			throw new SystemException("CheckInputQty");
		}
		if(Constant.YES.equals(conLotData.getIshold())) {
			// 보류상태의 자재입니다. {0}
			throw new SystemException("ConsumableLotIsHold", String.format("ConsumableLotId=%s", consumablelotId));
		}
		if(!Constant.YES.equals(isAllowInputUntracked) && !Constant.YES.equals(conDefData.getIstracking()) && !ConsumableType.HALF_PRODUCT.equals(conDefData.getConsumabletype())) {
			// 반제품 또는 추적대상 자재만 투입할 수 있습니다. {0}
			throw new SystemException("NotTrackingAndNotHalfProduct", String.format("ConsumableDefId=%s", conLotData.getConsumabledefid()));
		}
		// 중복투입 여부 검사
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfConsumemateriallottempData.Lotid, lotId);
		cond.set(SfConsumemateriallottempData.Materiallotid, consumablelotId);
		SfConsumemateriallottempData dupCheckData = new SfConsumemateriallottempData();
		ISQLDataList<SfConsumemateriallottempData> dupList = dupCheckData.select(cond);
		if(dupList.size() > 0) {
			// 이미 투입된 자재입니다. {0}
			throw new SystemException("ConsumableLotAlreadyInput", String.format("ConsumableLotId=%s", consumablelotId));
		}
		// 무지시 작업여부 검사
		if(Constant.YES.equals(conDefData.getIsnotorderresult()) && !Constant.YES.equals(conLotData.getIsnotorderresult())) {
			// 작업하지 않은 무지시공정대상 자재는 투입할 수 없습니다. 
			throw new SystemException("NonOrderWorkNoResultCantInput");
		}
		
		// 자재 가투입 내역기록
		SfConsumemateriallottempData tempConsumeData = new SfConsumemateriallottempData();
		SfConsumemateriallottempKey tempConsumeKey = tempConsumeData.key();
		tempConsumeKey.setLotid(lotId);
		tempConsumeKey.setMaterialtype(Constant.MATERIALTYPE_CONSUMABLE);
		tempConsumeKey.setMateriallotid(consumablelotId);
		tempConsumeKey.setTxnhistkey(Generate.createTimeKey());
		tempConsumeData.setMaterialdefid(conLotData.getConsumabledefid());
		tempConsumeData.setAreaid(lotData.getAreaid());
		tempConsumeData.setConsumedqty(consumedQty);
		tempConsumeData.setEnterpriseid(lotData.getEnterpriseid());
		tempConsumeData.setEquipmentid(lotData.getEquipmentid());
		tempConsumeData.setLocationid(lotData.getLocationid());
		tempConsumeData.setPlantid(lotData.getPlantid());
		tempConsumeData.setProcessdefid(lotData.getProcessdefid());
		tempConsumeData.setProcessdefversion(lotData.getProcessdefversion());
		tempConsumeData.setProcesspathid(StringUtils.convertStringToStack(lotData.getProcesspathstack(), ".").peek());
		tempConsumeData.setProcesssegmentid(lotData.getProcesssegmentid());
		tempConsumeData.setProcesssegmentversion(lotData.getProcesssegmentversion());
		tempConsumeData.setProductdefid(lotData.getProductdefid());
		tempConsumeData.setProductdefversion(lotData.getProductdefversion());
		tempConsumeData.setUsersequence(lotData.getUsersequence());
		tempConsumeData.setGoodqty(goodQty);
		tempConsumeData.setBadqty(badQty);
		tempConsumeData.setSerialno(serialNo);
		tempConsumeData.setDescription(comment);
		tempConsumeData.txnInfo().set(txnInfo.getTransaction());
		tempConsumeData.insert();
	}
	
	// 투입가능 수량을 반환(consumablelotqty - 가투입수량)
	private static Double getAvailableQty(SfConsumablelotData conLotData) throws DatabaseException {
		SfConsumablelotKey conLotKey = conLotData.key();
		Map<String, Object> param = new HashMap<String, Object>();
		param.put("CONSUMABLELOTID", conLotKey.getConsumablelotid());
		List<Map<String, Object>> result = QueryProvider.select("GetMaterialTempInputQty", "00001", param);
		Double tempInputQty = 0D;
		if(result.size() > 0) {
			tempInputQty = Double.valueOf(result.get(0).get("CONSUMEDQTY").toString());
		}
		return conLotData.getConsumablelotqty() - tempInputQty;
	}
	
	// LOT과 투입자재의 창고가 일치하는지 검사
	private static void validateWarehouse(SfLotData lotData, SfConsumablelotData conLotData) throws SystemException {
		SfAreaData lotAreaData = SfAreaService.getArea(lotData.getAreaid());
		if(lotAreaData == null) {
			// 등록된 작업장이 아닙니다. {0}
			throw new SystemException("AreaIsNotExists", String.format("AreaId=%s", lotData.getAreaid()));
		}
		if(!lotAreaData.getWarehouseid().equals(conLotData.getWarehouseid())) {
				// 다른창고에 있는 자재를 투입할 수 없습니다. {0}
				throw new SystemException("CantInputMaterialInAnotherWarehouse", 
					String.format("LotWarehouseId=%s, ConsumableLotWarehouseId=%s", lotAreaData.getWarehouseid(), conLotData.getWarehouseid()));
		}
	}
	
	/**
	 * Finished 상태의 Lot으로 동일한 ID 를 가진 ConsumableLot 을 생성한다.
	 * 오류 메세지 : 
	 * 		OnlyFinishedLotCanConvertToConsumable : Finished 상태의 LOT만 자재전환이 가능합니다.
	 * @param lotId LOT ID
	 * @param txnInfo 트랜잭션 정보
	 * @return 자재LOT
	 * @throws Throwable
	 */
	public static SfConsumablelotData createConsumableFromLot(String lotId, TxnInfo txnInfo) throws Throwable {
		SfLotData lotData = SfLotService.getLot(lotId);
		if(!lotData.getLotstate().equals(Constant.LOTSTATE_FINISHED)) {
			// Finished 상태의 LOT만 자재전환이 가능합니다.
			throw new SystemException("OnlyFinishedLotCanConvertToConsumable");
		}
		SfAreaData areaData = SfAreaService.getArea(lotData.getAreaid());
		CreateConsumableLotInfo info = new CreateConsumableLotInfo();
		info.setConsumableDefId(lotData.getProductdefid());
		info.setConsumableDefVersion(lotData.getProductdefversion());
		info.setConsumableLotId(lotId);
		info.setConsumableState(Constant.CONSUMABLESTATE_AVAILABLE);
		info.setCreatedQty(lotData.getQty());
		info.setQty(lotData.getQty());
		info.setEnterpriseId(lotData.getEnterpriseid());
		info.setPlantId(lotData.getPlantid());
		info.setAreaId(lotData.getAreaid());
		info.setUdf(SfConsumablelotData.Warehouseid, areaData.getWarehouseid());
		info.setUdf(SfConsumablelotData.State, ConsumablelotState.IN_PRODUCTION);
		info.setUdf(SfConsumablelotData.Printcount, lotData.getPrintcount());
		ConsumableLotService.createConsumableLot(info, txnInfo);
		SfConsumablelotData conLotData = getConsumablelot(lotId);
		SfProductdefinitionData prodDefData = SfProductDefinitionService.getProductdefinition(lotData.getProductdefid(), lotData.getProductdefversion());
		createConsumableTransaction(conLotData, lotData.getQty(), ConsumableTransactionType.IN, ConsumableTransactionCode.IN_WIP, Constant.EMPTY
				, prodDefData.getTeamid(), lotData.getWorkorderid(), Constant.EMPTY);
		return conLotData;
	}
	
	/**
	 * 자재 LOT을 하나 하나 분할한다. (자재 LOT ID = 부모LOT ID + '-' + 01 ~ 09)
	 * @param consumableLotId 자재 LOT ID
	 * @param txnInfo 트랜잭션 정보
	 * @return 자식LOT 목록
	 * @throws Throwable
	 */
	public static ISQLDataList<SfConsumablelotData> splitConsumableLotOneByOne(String consumableLotId, Double lotCreatedQty, TxnInfo txnInfo) throws Throwable {
		// LOT의 양품 SEQ만 가져온다.
		Map<String, Object> param = new HashMap<String, Object>();
		param.put("LOTID", consumableLotId);
		param.put("CREATEDQTY", lotCreatedQty);
		List<Map<String, Object>> goodSeqList = QueryProvider.select("GetAssyGoodSeq", "00001", param);
		SfConsumablelotData parentConLot = getConsumablelot(consumableLotId);
		int prefixLength = getPrefixLengthOfAssySplitId(consumableLotId) + 2;	// 실린더 조립 공정 분할 LOT ID 채번용 변수
		ISQLDataList<SfConsumablelotData> result = new SQLDataList<SfConsumablelotData>(SfConsumablelotData.class);
		for(int i = 0; i < goodSeqList.size(); i++) {
			String childConsumableLotId;
			if(ProcessSegment.CYLINDERASSY.equals(getProcessSegment(consumableLotId))) { // 실린더 조립 공정인 경우
				childConsumableLotId = SfConsumableLotService.createAssySplitIdWithModelStandardInfo(consumableLotId, (int)goodSeqList.get(i).get("SEQ"), prefixLength);
			}
			else if(ProcessSegment.MBSCASSY.equals(getProcessSegment(consumableLotId))) { // MBS-C 조립 공정인 경우
				childConsumableLotId = CommonUtils.GenerateLotid(parentConLot.getConsumabledefid(), getProcessSegment(consumableLotId), txnInfo, Constant.EMPTY, "MBSCLotNo");
			}
			else {
				childConsumableLotId = SfConsumableLotService.createAssySplitId(consumableLotId, (int)goodSeqList.get(i).get("SEQ"));
			}
			SplitConsumableLotInfo info = new SplitConsumableLotInfo();
			info.setConsumableLotId(consumableLotId);
			info.setChildConsumableLotId(childConsumableLotId);
			info.setSplitqty(1);
			info.setChildqty(1);
			ConsumableLotService.splitConsumableLot(info, txnInfo);
			SfConsumablelotData childConLot = getConsumablelot(childConsumableLotId);
			childConLot.setWarehouseid(parentConLot.getWarehouseid());
			childConLot.setParentconsumablelotid(consumableLotId);
			childConLot.setPrintcount(0);
			childConLot.txnInfo().set(txnInfo.getTransaction());
			childConLot.update();
			result.add(childConLot);
			
			// 자재 LOT 분할이력 기록
			CtConsumableLotGenealService.createCtConsumablelotgenealData(ConsumableLotGenealTxnType.SPLIT
					, consumableLotId, childConsumableLotId, parentConLot.getConsumablelotqty(), 1D, txnInfo);
		}
		parentConLot = getConsumablelot(consumableLotId);
		if(parentConLot.getConsumablelotqty() <= 0D) {
			parentConLot.setConsumablestate(Constant.CONSUMABLESTATE_CONSUMED);	// NOTE : splitConsumableLot API 에서 완전히 소진된 자재 LOT의 상태를 Consumed 로 바꿔주지 않아 강제 설정
			parentConLot.update();
		}
		return result;
	}

	// 실린더 조립 분할 LOT ID 채번용 PREFIX 길이 반환
	private static int getPrefixLengthOfAssySplitId(String lotId) throws Throwable {
		SfLotData lotData = SfLotService.getLot(lotId);
		SfProductdefinitionData prodDefData = SfProductDefinitionService.getProductdefinition(lotData.getProductdefid(), lotData.getProductdefversion());
		ProcesspathData pathData = ProcessPathService.getProcessPathByProcessDef(prodDefData.getProcessdefid(), prodDefData.getProcessdefversion()).get(0);
		CtModelstandardinfoData standardData = new CtModelstandardinfoData();
		CtModelstandardinfoKey standardKey = standardData.key();
		standardKey.setModelid(prodDefData.getModelid());
		standardKey.setProcesssegmentid(pathData.getProcesssegmentid());
		standardData = standardData.selectOne();
		if(standardData == null) {
			return 0;
		}
		else {
			return standardData.getStandard1().length() + 2;
		}
	}
	
	// LOT의 공정 반환
	private static String getProcessSegment(String lotId) throws Throwable {
		SfLotData lotData = SfLotService.getLot(lotId);
		SfProductdefinitionData prodDefData = SfProductDefinitionService.getProductdefinition(lotData.getProductdefid(), lotData.getProductdefversion());
		ProcesspathData pathData = ProcessPathService.getProcessPathByProcessDef(prodDefData.getProcessdefid(), prodDefData.getProcessdefversion()).get(0);
		return pathData.getProcesssegmentid();
	}

	/**
	 * 부모LOTID-00 형식의 자재 LOT 분할 ID 를 생성한다.
	 * IdService.createId 와는 달리 SF_CONSUMABLELOT 테이블의 MAX(CONSUMABLELOTID) 를 가져오는 것이므로
	 * 자재 LOT을 생성하기 전에 재 조회시, 다음 분할 ID 를 생성하지 못한다.
	 * @param consumableLotId 부모 자재 LOT ID
	 * @return 분할 LOT ID
	 * @throws DatabaseException
	 */
	public static String createSplitId(String consumableLotId) throws DatabaseException {
		return createSplitId(consumableLotId, 1).get(0);
	}

	/**
	 * 부모LOTID-00 형식의 자재 LOT 분할 ID 를 생성한다.
	 * IdService.createId 와는 달리 SF_CONSUMABLELOT 테이블의 MAX(CONSUMABLELOTID) 를 가져오는 것이므로
	 * 자재 LOT을 생성하기 전에 재 조회시, 다음 분할 ID 를 생성하지 못한다.
	 * @param consumableLotId 부모 자재 LOT ID
	 * @param numberOfIds 생성할 분할 LOT ID 갯수
	 * @return 분할 LOT ID 목록
	 * @throws DatabaseException
	 */
	public static List<String> createSplitId(String consumableLotId, int numberOfIds) throws DatabaseException {
		Map<String, Object> param = new HashMap<String, Object>();
		param.put("CONSUMABLELOTID", consumableLotId);
		List<Map<String, Object>> lastSplitIdResult = QueryProvider.select("GetLastSplitIdOfConsumableLot", "00001", param);
		int lastSplitPart = 0; 
		if(lastSplitIdResult.size() > 0 && lastSplitIdResult.get(0).get("LASTSPLITID") != null) {
			String lastSplitId = lastSplitIdResult.get(0).get("LASTSPLITID").toString();
			String[] lastParts = lastSplitId.split("-");
			lastSplitPart = Integer.valueOf(lastParts[lastParts.length - 1]);
		}
		List<String> result = new ArrayList<String>();
		for(int i = 1; i <= numberOfIds; i++) {
			result.add(consumableLotId + "-" + String.format("%02d", lastSplitPart + i));
		}
		return result;
	}
	
	/**
	 * 자재 LOT 분할
	 * 자식 LOT ID = 부모LOTID-01~99
	 * 오류 메세지 :
	 * 		OnlyPositiveNumberForSplitQty : 분할수량에는 양수만 입력 가능합니다. {0}
	 * 		SplitQtyIsLargerThanConsumableLotQty : 분할수량이 LOT의 수량을 초과했습니다. {0}
	 * @param consumableLotId 부모 LOT ID
	 * @param splitQty 분할 수량
	 * @param txnInfo 트랜잭션 정보
	 * @return 자식 LOT
	 * @throws Throwable
	 */
	public static SfConsumablelotData splitConsumableLot(String consumableLotId, Double splitQty, TxnInfo txnInfo) throws Throwable {
		return splitConsumableLot(consumableLotId, splitQty, false, txnInfo);
	}

	/**
	 * 자재 LOT 분할(무지시 작업)
	 * 자식 LOT ID = 부모LOTID-01~99
	 * 오류 메세지 :
	 * 		OnlyPositiveNumberForSplitQty : 분할수량에는 양수만 입력 가능합니다. {0}
	 * 		SplitQtyIsLargerThanConsumableLotQty : 분할수량이 LOT의 수량을 초과했습니다. {0}
	 * @param consumableLotId 부모 LOT ID
	 * @param splitQty 분할 수량
	 * @param txnInfo 트랜잭션 정보
	 * @return 자식 LOT
	 * @throws Throwable
	 */
	public static SfConsumablelotData splitNonOrderConsumableLot(String consumableLotId, Double splitQty, TxnInfo txnInfo) throws Throwable {
		return splitConsumableLot(consumableLotId, splitQty, true, txnInfo);
	}

	// 자재 LOT 분할
	private static SfConsumablelotData splitConsumableLot(String consumableLotId, Double splitQty, Boolean nonOrderResult, TxnInfo txnInfo) throws Throwable {
		SfConsumablelotData parentConLot = getConsumablelot(consumableLotId);
		Double parentConLotOriginalQty = parentConLot.getConsumablelotqty();
		validateSplitQty(parentConLot.getConsumablelotqty(), splitQty);
		String childConsumableLotId = createSplitId(consumableLotId);
		SplitConsumableLotInfo info = new SplitConsumableLotInfo();
		info.setConsumableLotId(consumableLotId);
		info.setChildConsumableLotId(childConsumableLotId);
		info.setSplitqty(splitQty);
		info.setChildqty(splitQty);
		ConsumableLotService.splitConsumableLot(info, txnInfo);
		parentConLot = getConsumablelot(consumableLotId);
		if(parentConLot.getConsumablelotqty() <= 0D) {
			parentConLot.setConsumablestate(Constant.CONSUMABLESTATE_CONSUMED);
			parentConLot.update();
		}
		SfConsumablelotData childConLot = getConsumablelot(childConsumableLotId);
		childConLot.setWarehouseid(parentConLot.getWarehouseid());
		childConLot.setOrderseq(parentConLot.getOrderseq());
		childConLot.setParentconsumablelotid(consumableLotId);
		if(nonOrderResult) {
			childConLot.setIsnotorderresult(Constant.YES);	
		}
		else {
			childConLot.setIsnotorderresult(Constant.NO);
		}
		childConLot.setPrintcount(0);
		childConLot.txnInfo().set(txnInfo.getTransaction());
		childConLot.update();
		
		// 자재 LOT 분할이력 기록
		CtConsumableLotGenealService.createCtConsumablelotgenealData(ConsumableLotGenealTxnType.SPLIT
				, consumableLotId, childConsumableLotId, parentConLotOriginalQty, splitQty, txnInfo);
		if(parentConLotOriginalQty > splitQty) {	// 일부수량 분할인경우 부모 LOT의 분할이력 추가
			CtConsumableLotGenealService.createCtConsumablelotgenealData(ConsumableLotGenealTxnType.SPLIT
					, consumableLotId, consumableLotId, parentConLotOriginalQty, parentConLot.getConsumablelotqty(), txnInfo);
		}
		return childConLot;
	}

	// 분할수량 유효성검사를 한다.
	public static void validateSplitQty(Double consumableLotQty, Double splitQty) throws SystemException {
		if(splitQty <= 0) {
			// 분할수량에는 양수만 입력 가능합니다. {0}
			throw new SystemException("OnlyPositiveNumberForSplitQty", String.format("SplitQty=%.2f", splitQty));
		}
		if(splitQty > consumableLotQty) {
			// 분할수량이 LOT의 수량을 초과했습니다. {0}
			throw new SystemException("SplitQtyIsLargerThanConsumableLotQty", String.format("ConsumableLotQty=%.2f, SplitQty=%.2f", splitQty));
		}
	}
	
	/**
	 * 자재투입 확정
	 * 자재 가투입 내역을 투입내역으로 옮기고, 자재 소모처리를 한다.
	 * @param lotId LOT ID
	 * @param txnInfo 트랜잭션 정보
	 * @throws Throwable
	 */
	public static void commitInputConsumablelot(String lotId, TxnInfo txnInfo) throws Throwable {
		SfLotData lotData = SfLotService.getLot(lotId);
		SfProductdefinitionData prodDefData = SfProductDefinitionService.getProductdefinition(lotData.getProductdefid(), lotData.getProductdefversion());
		SfAreaData areaData = SfAreaService.getArea(lotData.getAreaid());
		ISQLDataList<SfConsumemateriallottempData> tempConsumeDataList = SfConsumeMaterialLotTempService.getConsumemateriallottempList(lotId);
		ISQLUpsertBatch transactionBatch = new SQLUpsertBatch();
		ISQLUpsertBatch deleteBatch = new SQLUpsertBatch();
		for(int i = 0; i < tempConsumeDataList.size(); i++) {
			SfConsumemateriallottempData tempConsumeData = tempConsumeDataList.get(i);
			SfConsumemateriallottempKey tempConsumeKey = tempConsumeData.key();
			if(!Constant.ASTERISK.equals(tempConsumeKey.getMateriallotid())) {
				commitInputTrackingConsumablelot(lotData, prodDefData, tempConsumeData, transactionBatch, txnInfo);	// 추적대상 자재 투입
			}
			else {
				commitInputUnTrackingConsumablelot(lotData, prodDefData, areaData.getWarehouseid(), tempConsumeData, transactionBatch, txnInfo);	// 비추적대상 자재 투입
			}
			deleteBatch.add(tempConsumeData, SQLUpsertType.DELETE);
		}
		deleteBatch.execute();		// 가투입 내역 삭제
		transactionBatch.execute();	// 자재 입출고 내역 기록 
	}
	
	// 추적대상 자재 소모처리 및 실투입 내역 기록
	private static void commitInputTrackingConsumablelot(SfLotData lotData, SfProductdefinitionData prodDefData, SfConsumemateriallottempData tempConsumeData
			, ISQLUpsertBatch transactionBatch, TxnInfo txnInfo) throws Throwable {
		SfLotKey lotKey = lotData.key();
		SfConsumemateriallottempKey tempConsumeKey = tempConsumeData.key();
		SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(tempConsumeKey.getMateriallotid());
		if(Constant.YES.equals(conLotData.getIshold())) {
			// 보류상태의 자재입니다. {0}
			throw new SystemException("ConsumableLotIsHold", String.format("ConsumableLotId=%s", tempConsumeKey.getMateriallotid()));
		}
		
		// 자재수량 차감
		ConsumeConsumableLotInfo consumeInfo = new ConsumeConsumableLotInfo();
		consumeInfo.setConsumableLotId(tempConsumeKey.getMateriallotid());
		consumeInfo.setConsumedQty(tempConsumeData.getConsumedqty());
		consumeInfo.setUdf(SfConsumablelotData.State, ConsumablelotState.OUT_PRODUCTION);
		ConsumableLotService.consumeConsumableLot(consumeInfo, txnInfo);
		
		// 자재투입이력 기록
		CreateConsumeMaterialLotInfo materialInfo = new CreateConsumeMaterialLotInfo();
		materialInfo.setAreaId(tempConsumeData.getAreaid());
		materialInfo.setConsumedQty(tempConsumeData.getConsumedqty());
		materialInfo.setEnterpriseId(tempConsumeData.getEnterpriseid());
		materialInfo.setEquipmentId(tempConsumeData.getEquipmentid());
		materialInfo.setLocationId(tempConsumeData.getLocationid());
		materialInfo.setLotId(lotKey.getLotid());
		materialInfo.setMaterialLotId(tempConsumeKey.getMateriallotid());
		materialInfo.setMaterialType(tempConsumeKey.getMaterialtype());
		materialInfo.setPlantId(tempConsumeData.getPlantid());
		materialInfo.setProcessDefId(tempConsumeData.getProcessdefid());
		materialInfo.setProcessDefVersion(tempConsumeData.getProcessdefversion());
		materialInfo.setProcessPathId(tempConsumeData.getProcesspathid());
		materialInfo.setProcessSegmentId(tempConsumeData.getProcesssegmentid());
		materialInfo.setProcessSegmentVersion(tempConsumeData.getProcesssegmentversion());
		materialInfo.setProductDefId(tempConsumeData.getProductdefid());
		materialInfo.setProductDefVersion(tempConsumeData.getProductdefversion());
		materialInfo.setUserSequence(tempConsumeData.getUsersequence());
		materialInfo.setUdf(SfConsumemateriallotData.Materialdefid, tempConsumeData.getMaterialdefid());
		materialInfo.setUdf(SfConsumemateriallotData.Goodqty, tempConsumeData.getGoodqty());
		materialInfo.setUdf(SfConsumemateriallotData.Badqty, tempConsumeData.getBadqty());
		materialInfo.setUdf(SfConsumemateriallotData.Serialno, tempConsumeData.getSerialno());
		materialInfo.setUdf(SfConsumemateriallotData.Description, tempConsumeData.getDescription());
		ConsumeMaterialLotService.createConsumeMaterialLot(materialInfo, txnInfo);
		
		// 자재 입출고내역 기록
		createConsumableTransaction(transactionBatch, conLotData, tempConsumeData.getConsumedqty()
				, ConsumableTransactionType.OUT, ConsumableTransactionCode.OUT_WIP, tempConsumeData.getEquipmentid(), prodDefData.getTeamid(), lotData.getWorkorderid(), Constant.EMPTY); 
	}
	
	// 비추적대상 자재 소모처리 및 실투입 내역 기록
	private static void commitInputUnTrackingConsumablelot(SfLotData lotData, SfProductdefinitionData prodDefData, String warehouseId, SfConsumemateriallottempData tempConsumeData
			, ISQLUpsertBatch transactionBatch, TxnInfo txnInfo) throws Throwable {
		SfLotKey lotKey = lotData.key();
		SfConsumemateriallottempKey tempConsumeKey = tempConsumeData.key();

		Map<String, Object> param = new HashMap<String, Object>();
		param.put("CONSUMABLEDEFID", tempConsumeData.getMaterialdefid());
		param.put("WAREHOUSEID", warehouseId);
		param.put("CONSUMEQTY", tempConsumeData.getConsumedqty());
		param.put("BADQTY", tempConsumeData.getBadqty());
		List<Map<String, Object>> input = QueryProvider.select("GetConsumableLotsToInput", "00001", param);	// 투입대상 LOT 조회(선입선출)

		Double actualGoodQty = 0D;
		Double actualBadQty = 0D;
		for(int i = 0; i < input.size(); i++) {
			String consumableLotId = input.get(i).get("CONSUMABLELOTID").toString();
			Double inputQty = Double.valueOf(input.get(i).get("INPUTQTY").toString());
			Double goodQty = Double.valueOf(input.get(i).get("GOODQTY").toString());
			Double badQty = Double.valueOf(input.get(i).get("BADQTY").toString());

			actualGoodQty += goodQty;
			actualBadQty += badQty;

			// 자재수량 차감
			ConsumeConsumableLotInfo consumeInfo = new ConsumeConsumableLotInfo();
			consumeInfo.setConsumableLotId(consumableLotId);
			consumeInfo.setConsumedQty(inputQty);
			consumeInfo.setUdf(SfConsumablelotData.State, ConsumablelotState.OUT_PRODUCTION);
			ConsumableLotService.consumeConsumableLot(consumeInfo, txnInfo);
			
			// 자재투입이력 기록
			CreateConsumeMaterialLotInfo materialInfo = new CreateConsumeMaterialLotInfo();
			materialInfo.setAreaId(tempConsumeData.getAreaid());
			materialInfo.setConsumedQty(inputQty);
			materialInfo.setEnterpriseId(tempConsumeData.getEnterpriseid());
			materialInfo.setEquipmentId(tempConsumeData.getEquipmentid());
			materialInfo.setLocationId(tempConsumeData.getLocationid());
			materialInfo.setLotId(lotKey.getLotid());
			materialInfo.setMaterialLotId(consumableLotId);
			materialInfo.setMaterialType(tempConsumeKey.getMaterialtype());
			materialInfo.setPlantId(tempConsumeData.getPlantid());
			materialInfo.setProcessDefId(tempConsumeData.getProcessdefid());
			materialInfo.setProcessDefVersion(tempConsumeData.getProcessdefversion());
			materialInfo.setProcessPathId(tempConsumeData.getProcesspathid());
			materialInfo.setProcessSegmentId(tempConsumeData.getProcesssegmentid());
			materialInfo.setProcessSegmentVersion(tempConsumeData.getProcesssegmentversion());
			materialInfo.setProductDefId(tempConsumeData.getProductdefid());
			materialInfo.setProductDefVersion(tempConsumeData.getProductdefversion());
			materialInfo.setUserSequence(tempConsumeData.getUsersequence());
			materialInfo.setUdf(SfConsumemateriallotData.Materialdefid, tempConsumeData.getMaterialdefid());
			materialInfo.setUdf(SfConsumemateriallotData.Goodqty, goodQty);
			materialInfo.setUdf(SfConsumemateriallotData.Badqty, badQty);
			materialInfo.setUdf(SfConsumemateriallotData.Serialno, "UnTracked");					// 비추적 대상 여부 표시			
			materialInfo.setUdf(SfConsumemateriallotData.Description, tempConsumeData.getDescription());
			ConsumeMaterialLotService.createConsumeMaterialLot(materialInfo, txnInfo);
			
			// 자재 입출고내역 기록
			SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(consumableLotId);
			createConsumableTransaction(transactionBatch, conLotData, inputQty
					, ConsumableTransactionType.OUT, ConsumableTransactionCode.OUT_WIP, tempConsumeData.getEquipmentid(), prodDefData.getTeamid(), lotData.getWorkorderid(), Constant.EMPTY);
		}
		
		// MES 재고 부족분 투입이력에만 기록
		if(tempConsumeData.getGoodqty() > actualGoodQty || tempConsumeData.getBadqty() > actualBadQty) {
			SfConsumemateriallotData remainMaterialData = new SfConsumemateriallotData();
			SfConsumemateriallotKey remainMaterialKey = remainMaterialData.key();
			remainMaterialKey.setLotid(tempConsumeKey.getLotid());
			remainMaterialKey.setMateriallotid(Constant.ASTERISK);
			remainMaterialKey.setMaterialtype(tempConsumeKey.getMaterialtype());
			remainMaterialKey.setTxnhistkey(Generate.createTimeKey());
			
			remainMaterialData.setAreaid(tempConsumeData.getAreaid());
			remainMaterialData.setConsumedqty(tempConsumeData.getConsumedqty() - (actualGoodQty + actualBadQty));
			remainMaterialData.setEnterpriseid(tempConsumeData.getEnterpriseid());
			remainMaterialData.setEquipmentid(tempConsumeData.getEquipmentid());
			remainMaterialData.setLocationid(tempConsumeData.getLocationid());
			remainMaterialData.setPlantid(tempConsumeData.getPlantid());
			remainMaterialData.setProcessdefid(tempConsumeData.getProcessdefid());
			remainMaterialData.setProcessdefversion(tempConsumeData.getProcessdefversion());
			remainMaterialData.setProcesspathid(tempConsumeData.getProcesspathid());
			remainMaterialData.setProcesssegmentid(tempConsumeData.getProcesssegmentid());
			remainMaterialData.setProcesssegmentversion(tempConsumeData.getProcesssegmentversion());
			remainMaterialData.setProductdefid(tempConsumeData.getProductdefid());
			remainMaterialData.setProductdefversion(tempConsumeData.getProductdefversion());
			remainMaterialData.setUsersequence(tempConsumeData.getUsersequence());
			remainMaterialData.setMaterialdefid(tempConsumeData.getMaterialdefid());
			remainMaterialData.setGoodqty(tempConsumeData.getGoodqty() - actualGoodQty);
			remainMaterialData.setBadqty(tempConsumeData.getBadqty() - actualBadQty);
			remainMaterialData.setSerialno("UnTracked");						// 비추적 대상 여부 표시
			remainMaterialData.setDescription(tempConsumeData.getDescription());
			remainMaterialData.txnInfo().set(txnInfo.getTransaction());
			remainMaterialData.insert();
		}
	}
	
	// 자재 입출고 내역 기록
	private static void createConsumableTransaction(ISQLUpsertBatch batch, SfConsumablelotData conLotData, Double qty
			, String transactionType, String transactionCode, String equipmentId, String teamId, String referenceKey, String description) throws InValidDataException, MESException, SystemException {
		
		SfConsumablelotKey conLotKey = conLotData.key();
		
		Map<String, Object> rowMap = new HashMap<String, Object>();
		rowMap.put("TXNHISTKEY", Generate.createTimeKey());
		rowMap.put("WAREHOUSEID", conLotData.getWarehouseid());
		rowMap.put("TRANSACTIONTYPE", transactionType);
		rowMap.put("TRANSACTIONCODE", transactionCode);
		rowMap.put("CONSUMABLEDEFID", conLotData.getConsumabledefid());
		rowMap.put("CONSUMABLELOTID", conLotKey.getConsumablelotid());
		rowMap.put("QTY", qty);
		rowMap.put("LOCATIONID", conLotData.getLocationid());
		rowMap.put("EQUIPMENTID", equipmentId);
		rowMap.put("TOWAREHOUSEID", Constant.EMPTY);
		rowMap.put("TEAMID", teamId);
		rowMap.put("CELLID", conLotData.getLocationid());
		rowMap.put("REFERENCEKEY", referenceKey);
		rowMap.put("DESCRIPTION", description);
		
		IDataSet ds = new DataSet();
		IDataTable dt = ds.addTable("transaction");
		dt.addRow(rowMap);
		
		CtConsumabletransactionData data = ConsumableTransactionUtils.getInsertData(dt.getFirstRow(), null);
		batch.add(data, SQLUpsertType.INSERT);
	}
	
	// 자재 입출고 내역 기록
	private static void createConsumableTransaction(SfConsumablelotData conLotData, Double qty
			, String transactionType, String transactionCode, String equipmentId, String teamId, String referenceKey, String description) throws InValidDataException, MESException, SystemException {
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		createConsumableTransaction(batch, conLotData, qty, transactionType, transactionCode, equipmentId, teamId, referenceKey, description);
		batch.execute();
	}
	
	/**
	 * 자재투입을 취소한다.
	 * @param lotId LOT ID
	 * @param consumablelotId 자재 LOT ID
	 * @param txnInfo 트랜잭션 정보
	 * @throws Throwable
	 */
	public static void cancelInputConsumablelot(String lotId, String consumablelotId, TxnInfo txnInfo) throws Throwable {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfConsumemateriallottempData.Lotid, lotId);
		cond.set(SfConsumemateriallottempData.Materiallotid, consumablelotId);
		SfConsumemateriallottempData data = new SfConsumemateriallottempData();
		data.delete(cond);		
	}
	
	/**
	 * 자재투입을 취소한다.
	 * @param lotId LOT ID
	 * @param txnInfo 트랜잭션 정보
	 * @throws Throwable
	 */
	public static void cancelAllInputConsumablelot(String lotId, TxnInfo txnInfo) throws Throwable {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfConsumemateriallottempData.Lotid, lotId);
		SfConsumemateriallottempData data = new SfConsumemateriallottempData();
		data.delete(cond);		
	}
	
	/**
	 * 비추적 자재 투입
	 * @param lotId LOT ID
	 * @param consumableDefId 자재 정의 ID
	 * @param goodQty 양품수량
	 * @param badQty 불량수량
	 * @param comment 특이사항
	 * @param txnInfo 트랜잭션 정보
	 * @throws Throwable
	 */
	public static void inputUnTrackingConsumablelot(String lotId, String consumableDefId, Double goodQty, Double badQty, String comment, TxnInfo txnInfo) throws Throwable {
		SfLotData lotData = SfLotService.getLot(lotId);
		SfAreaData areaData = SfAreaService.getArea(lotData.getAreaid());
		
		if(goodQty < 0 || badQty < 0) {
			// 수량에 음수를 입력할 수 없습니다.
			throw new SystemException("QtyCannotBeNegative");
		}
		SfConsumabledefinitionData conDefData = SfConsumableDefinitionService.getConsumabledefinition(consumableDefId, Constant.ASTERISK);
		Double consumedQty = goodQty + badQty;	// 자재 투입수량

		CodeData codeData = CodeService.getCode(SystemOption.CONSUME_UNTRACKED_MATERIALS, SystemOption.CODECLASSID);
		if(Constant.YES.equals(codeData.getDescription())) {	// 비추적 자재 소진여부가 Y 일때만 재고수량 체크
			if(getStockQty(consumableDefId, areaData.getWarehouseid()) < consumedQty) {
				// 재고수량을 초과하여 투입할 수 없습니다. {0}
				throw new SystemException("CantInputMoreThanAvailableQty", String.format("ConsumableDefId=%s", consumableDefId));
			}
		}
		if(Constant.YES.equals(conDefData.getIstracking()) || !ConsumableType.MATERIAL.equals(conDefData.getConsumabletype())) {
			// 비추적대상 원자재만 투입할 수 있습니다. {0}
			throw new SystemException("OnlyNotTrackingMaterial", String.format("ConsumableDefId=%s", consumableDefId));
		}
		// 중복투입 여부 검사
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfConsumemateriallottempData.Lotid, lotId);
		cond.set(SfConsumemateriallottempData.Materialdefid, consumableDefId);
		cond.set(SfConsumemateriallottempData.Materiallotid, Constant.ASTERISK);
		SfConsumemateriallottempData dupCheckData = new SfConsumemateriallottempData();
		ISQLDataList<SfConsumemateriallottempData> dupList = dupCheckData.select(cond);
		if(dupList.size() > 0) {
			// 이미 투입된 자재입니다. {0}
			throw new SystemException("ConsumableLotAlreadyInput", String.format("ConsumableDefId=%s", consumableDefId));
		}
		
		// 자재 가투입 내역기록
		SfConsumemateriallottempData tempConsumeData = new SfConsumemateriallottempData();
		SfConsumemateriallottempKey tempConsumeKey = tempConsumeData.key();
		tempConsumeKey.setLotid(lotId);
		tempConsumeKey.setMaterialtype(Constant.MATERIALTYPE_CONSUMABLE);
		tempConsumeKey.setMateriallotid(Constant.ASTERISK);
		tempConsumeKey.setTxnhistkey(Generate.createTimeKey());
		tempConsumeData.setMaterialdefid(consumableDefId);
		tempConsumeData.setAreaid(lotData.getAreaid());
		tempConsumeData.setConsumedqty(consumedQty);
		tempConsumeData.setEnterpriseid(lotData.getEnterpriseid());
		tempConsumeData.setEquipmentid(lotData.getEquipmentid());
		tempConsumeData.setLocationid(lotData.getLocationid());
		tempConsumeData.setPlantid(lotData.getPlantid());
		tempConsumeData.setProcessdefid(lotData.getProcessdefid());
		tempConsumeData.setProcessdefversion(lotData.getProcessdefversion());
		tempConsumeData.setProcesspathid(StringUtils.convertStringToStack(lotData.getProcesspathstack(), ".").peek());
		tempConsumeData.setProcesssegmentid(lotData.getProcesssegmentid());
		tempConsumeData.setProcesssegmentversion(lotData.getProcesssegmentversion());
		tempConsumeData.setProductdefid(lotData.getProductdefid());
		tempConsumeData.setProductdefversion(lotData.getProductdefversion());
		tempConsumeData.setUsersequence(lotData.getUsersequence());
		tempConsumeData.setGoodqty(goodQty);
		tempConsumeData.setBadqty(badQty);
		tempConsumeData.setDescription(comment);
		tempConsumeData.txnInfo().set(txnInfo.getTransaction());
		tempConsumeData.insert();
	}
	
	// 창고의 재고수량 확인
	private static Double getStockQty(String consumableDefId, String warehouseId) throws DatabaseException {
		Map<String, Object> param = new HashMap<String, Object>();
		param.put("CONSUMABLEDEFID", consumableDefId);
		param.put("WAREHOUSEID", warehouseId);
		List<Map<String, Object>> result = QueryProvider.select("GetStockQty", "00001", param);
		if(result.size() > 0) {
			return Double.valueOf(result.get(0).get("STOCKQTY").toString());
		}
		else {
			return 0D;
		}
	}
	
	/**
	 * 비추적 자재투입을 취소한다.
	 * @param lotId LOT ID
	 * @param txnInfo 트랜잭션 정보
	 * @throws Throwable
	 */
	public static void cancelInputUnTrackingConsumablelot(String lotId, TxnInfo txnInfo) throws Throwable {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfConsumemateriallottempData.Lotid, lotId);
		cond.set(SfConsumemateriallottempData.Materiallotid, Constant.ASTERISK);
		SfConsumemateriallottempData data = new SfConsumemateriallottempData();
		data.delete(cond);		
	}
	
	/**
	 * 조립 LOT 분할 ID를 생성한다.
	 * @param consumableLotId 자재 LOT 번호
	 * @param seq SEQ
	 * @return 분할 LOT ID
	 * @throws DatabaseException
	 */
	public static String createAssySplitId(String consumableLotId, int seq) throws DatabaseException {
		return consumableLotId + "-" + String.format("%02d", seq);
	}
	
	/**
	 * 기종별 기준서 정보를 이용한 분할 LOT ID 생성
	 * YY + CT_MODELSTANDARDINFO.STANDARD1 + LOT(2) + SEQ(2) + SUFFIX 
	 * @param consumableLotId 부모 LOT ID
	 * @param seq 순번
	 * @param prefixLength YY + CT_MODELSTANDARDINFO.STANDARD1 의 길이 + 2
	 * @return 분할 LOT ID
	 * @throws DatabaseException
	 */
	public static String createAssySplitIdWithModelStandardInfo(String consumableLotId, int seq, int prefixLength) throws DatabaseException {
		return consumableLotId.substring(0, prefixLength) + String.format("%02d", seq) + consumableLotId.substring(prefixLength + 2); 
	}
	
	/**
	 * 제품출하 처리를 한다.
	 * 제품 재고의 ConsumableState를 Shipped로 변경하여 MES 제품 재고를 차감한다.
	 * ERP에서는 (품목으로)출하를 따로 하기 때문에 I/F는 하지 않는다.
	 * @param consumableLotId 제품 LOT ID
	 * @return 자재LOT
	 * @throws SystemException
	 */
	public static SfConsumablelotData shipConsumableLot(String consumableLotId) throws SystemException {
		SfLotData lotData = SfLotService.getLot(consumableLotId);
		if(lotData == null) {
			// LOT을 찾을 수 없습니다. {0}
			throw new SystemException("LotIsNotExists", String.format("LotId=%s", consumableLotId));
		}
		SfProductdefinitionData prodDefData = SfProductDefinitionService.getProductdefinition(lotData.getProductdefid(), lotData.getProductdefversion());
		if(!ProductDefType.PRODUCT.equals(prodDefData.getProductdeftype()) && !ProductDefType.HALF_PRODUCT.equals(prodDefData.getProductdeftype())) {
			// 제품/반제품만 출하 가능합니다.
			throw new SystemException("OnlyProductCanBeShipped");
		}
		SfConsumablelotData conLotData = getConsumablelot(consumableLotId);
		// Available 여부 확인
		if(!Constant.CONSUMABLESTATE_AVAILABLE.equals(conLotData.getConsumablestate())) {
			// Available상태의 재고만 출하 가능합니다. {0}
			throw new SystemException("OnlyAvailableStateCanBeShipped", String.format("ConsumableState=%s", conLotData.getConsumablestate()));
		}
		// Hold 여부 확인
		if(Constant.YES.equals(conLotData.getIshold())) {
			// 해당 LOT은 HOLD 상태입니다. {0}
			throw new SystemException("HOLDLOT", String.format("ConsumableLotId=%s", consumableLotId));
		}
		// 출하처리
		conLotData.setConsumablestate("Shipped");
		conLotData.update();
		// 자재 입/출고 이력 기록
		createConsumableTransaction(conLotData, conLotData.getConsumablelotqty(), ConsumableTransactionType.OUT, ConsumableTransactionCode.OUT_PRODUCT, Constant.EMPTY
				, prodDefData.getTeamid(), lotData.getWorkorderid(), Constant.EMPTY);
		return conLotData;
	}
}
