package kr.co.micube.mes.process.rule;

import java.text.ParseException;

import kr.co.micube.common.mes.service.SfConsumableLotService;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록
 * 설               명	: 자재 투입
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-05-26
 * 수   정   이   력	: 
 * 				  
 */

public class InputMaterial extends DatasetRule {

	// 트랜잭션 정보
	private TxnInfo txnInfo;

	// 파라미터
	private String lotId; 							// LOT ID
	private String isOverwrite;						// Y : 기존 가투입내역을 삭제하고 투입, N : 기존 가투입내역을 유지하고 추가투입 
	private String isAllowInputUntracked;			// Y : 비추적 자재 투입 허용, N : 비추적 자재 투입 허용하지 않음
	private IDataTable materials; 					// 투입 자재 목록(컬럼 : ConsumableLotId, GoodQty, BadQty, SerialNo, Comment)
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		SfLotService.validateLotStateIsInProduction(this.lotId);	// InProduction 상태에만 자재투입 가능
		if(Constant.YES.equals(this.isOverwrite)) {
			SfConsumableLotService.cancelAllInputConsumablelot(this.lotId, this.txnInfo);
		}
		consumeMaterials();
	}

	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);

		// 파라미터
		this.lotId = body.getString("lotid");
		this.isOverwrite = body.getString("isoverwrite");
		this.isAllowInputUntracked = body.getString("isallowinputuntracked");

		IDataSet ds = this.getRequestDataset();
		this.materials = ds.getTable("materials");
	}
	
	// 자재 가투입
	private void consumeMaterials() throws Throwable {
		for (int i = 0; i < this.materials.size(); i++) {
			IDataRow row = this.materials.getRow(i);
			String consumablelotId = row.getString("CONSUMABLELOTID");	// 자재 LOT ID
			Double goodQty = row.getDouble("GOODQTY");					// 자재 양품수량
			Double badQty = row.getDouble("BADQTY");					// 자재 불량수량
			String serialNo = row.getString("SERIALNO");				// 자재 일련번호(협력사 LOT NO)
			String comment = row.getString("COMMENT");					// 특이사항
			SfConsumableLotService.inputConsumablelot(this.lotId, consumablelotId, goodQty, badQty, serialNo, comment, this.isAllowInputUntracked, this.txnInfo);
		}
	}
}
