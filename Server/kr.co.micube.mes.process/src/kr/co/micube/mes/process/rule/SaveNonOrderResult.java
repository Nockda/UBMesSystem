package kr.co.micube.mes.process.rule;

import java.text.ParseException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.service.CtNonOrderConsumableWorkResultService;
import kr.co.micube.common.mes.service.SfConsumableDefinitionService;
import kr.co.micube.common.mes.service.SfConsumableLotService;
import kr.co.micube.common.mes.so.SfConsumabledefinitionData;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 무지시 공정
 * 설               명	: 무지시 공정 실적등록
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-06-02
 * 수   정   이   력	: 
 * 				  
 */

public class SaveNonOrderResult extends DatasetRule {

	// 트랜잭션 정보
	private TxnInfo txnInfo;

	// 파라미터
	private IDataTable list; 					// 무지시 공정 자재 LOT(컬럼 : consumablelotid, workqty) 
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		List<String> childLotIds = new ArrayList<String>();
		for (int i = 0; i < this.list.size(); i++) {
			IDataRow row = this.list.getRow(i);
			String consumableLotId = row.getString("CONSUMABLELOTID");	// 자재 LOT ID
			Double workQty = row.getDouble("WORKQTY");					// 작업수량
			SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(consumableLotId);
			validateConsumableLot(conLotData);
			SfConsumablelotData childLotData = SfConsumableLotService.splitNonOrderConsumableLot(consumableLotId, workQty, this.txnInfo);	// 자재 LOT 분할분할
			CtNonOrderConsumableWorkResultService.createCtNonOrderConsumableWorkResult(childLotData
					, Constant.ASTERISK, this.txnInfo.getTxnUser(), this.txnInfo);						// 무지시 작업내역 등록
			SfConsumablelotKey childLotKey = childLotData.key();
			childLotIds.add(childLotKey.getConsumablelotid());
		}
		returnChildConsumableLotIds(childLotIds);
	}

	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		// IMessage msg = this.getMessage().get();
		// IData jmsg = msg.get();
		// IData body = jmsg.get(MessageFormat.Body);

		// 파라미터
		IDataSet ds = this.getRequestDataset();
		this.list = ds.getTable("list");
	}
	
	private static void validateConsumableLot(SfConsumablelotData conLotData) throws SystemException {
		SfConsumablelotKey conLotKey = conLotData.key();
		SfConsumabledefinitionData conDefData = SfConsumableDefinitionService.getConsumabledefinition(conLotData.getConsumabledefid(), conLotData.getConsumabledefversion());
		if(!Constant.YES.equals(conDefData.getIsnotorderresult())) {
			// 무지시작업 대상 자재가 아닙니다. {0}
			throw new SystemException("ConsumableDefIsNotNonOrderResult", String.format("ConsumableDefId=%s", conLotData.getConsumabledefid()));
		}
		if(Constant.YES.equals(conLotData.getIshold())) {
			// 보류상태의 자재입니다. {0}
			throw new SystemException("ConsumableLotIsHold", String.format("ConsumableLotId=%s", conLotKey.getConsumablelotid()));
		}
		if(!Constant.CONSUMABLESTATE_AVAILABLE.equals(conLotData.getConsumablestate())) {
			// 사용가능한 상태의 자재가 아닙니다. {0}
			throw new SystemException("ConsumableLotIsNotAvailable", String.format("ConsumableLotId=%s, ConsumableState=%s", conLotKey.getConsumablelotid(), conLotData.getConsumablestate()));
		}
		if(!StringUtils.isNullOrEmpty(conLotData.getEquipmentid())) {
			// 이미 작업중인 자재입니다. {0}
			throw new SystemException("ConsumableLotIsAlreadyWorking", String.format("ConsumableLotId=%s, EquipmentId=%s", conLotKey.getConsumablelotid(), conLotData.getEquipmentid()));
		}
		if(Constant.YES.equals(conLotData.getIsnotorderresult())) {
			// 이미 무지시 작업을 완료한 자재LOT 입니다. {0}
			throw new SystemException("NonOrderWorkAlreadyFinished", String.format("ConsumableLotId=%s", conLotKey.getConsumablelotid()));
		}
	}
	
	// 자식 자재LOT ID 목록 반환
	private void returnChildConsumableLotIds(List<String> childLotIds) {
		Map<String, Object> result = new HashMap<String, Object>();
		for(int i = 0; i < childLotIds.size(); i++) {
			result.put("CONSUMABLELOTID", childLotIds.get(i));
		}
		IDataSet ds = this.getResponseDataset();
		IDataTable dt = ds.addTable("DATA");
		dt.addRow(result);
	}
}
