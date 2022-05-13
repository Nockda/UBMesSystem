package kr.co.micube.mes.process.rule;

import java.text.ParseException;

import kr.co.micube.common.mes.service.SfConsumableLotService;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록
 * 설               명	: 비 추적대상 자재 투입
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-06-24
 * 수   정   이   력	: 
 * 				  
 */

public class InputUnTrackingMaterial extends DatasetRule {

	// 트랜잭션 정보
	private TxnInfo txnInfo;

	// 파라미터
	private String lotId; 							// LOT ID
	private IDataTable materials; 					// 투입 자재 목록(컬럼 : ConsumableDefId, GoodQty, BadQty, Comment)
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		SfLotService.validateLotStateIsInProduction(this.lotId);	// InProduction 상태에만 자재투입 가능
		SfConsumableLotService.cancelInputUnTrackingConsumablelot(this.lotId, this.txnInfo);
		inputMaterials();
	}

	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);

		// 파라미터
		this.lotId = body.getString("lotid");

		IDataSet ds = this.getRequestDataset();
		this.materials = ds.getTable("materials");
	}
	
	// 자재 가투입
	private void inputMaterials() throws Throwable {
		for (int i = 0; i < this.materials.size(); i++) {
			IDataRow row = this.materials.getRow(i);
			String consumableDefId = row.getString("CONSUMABLEDEFID");	// 자재 정의 ID
			Double goodQty = row.getDouble("GOODQTY");					// 자재 양품수량
			Double badQty = row.getDouble("BADQTY");					// 자재 불량수량
			String comment = row.getString("COMMENT");					// 특이사항
			if(goodQty + badQty > 0D) {
				SfConsumableLotService.inputUnTrackingConsumablelot(this.lotId, consumableDefId, goodQty, badQty, comment, this.txnInfo);
			}
		}
	}
}
