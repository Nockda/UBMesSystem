package kr.co.micube.mes.process.rule;

import java.text.ParseException;

import kr.co.micube.common.mes.service.SfConsumableLotService;
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
 * 설               명	: 자재 투입취소
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-06-16
 * 수   정   이   력	: 
 * 				  
 */

public class CancelInputMaterial extends DatasetRule {

	// 트랜잭션 정보
	private TxnInfo txnInfo;

	// 파라미터
	private String lotId; 							// LOT ID
	private IDataTable materials; 					// 투입 자재 목록(컬럼 : ConsumableLotId)
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		cancelInputMaterials();
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
	
	// 자재 가투입 취소
	private void cancelInputMaterials() throws Throwable {
		for (int i = 0; i < this.materials.size(); i++) {
			IDataRow row = this.materials.getRow(i);
			String consumablelotId = row.getString("CONSUMABLELOTID");	// 자재 LOT ID
			SfConsumableLotService.cancelInputConsumablelot(this.lotId, consumablelotId, this.txnInfo);
		}
	}
}
