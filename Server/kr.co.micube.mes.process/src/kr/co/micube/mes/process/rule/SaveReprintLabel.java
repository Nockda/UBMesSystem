package kr.co.micube.mes.process.rule;

import java.text.ParseException;

import kr.co.micube.common.mes.service.SfConsumableLotService;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 
 * 설               명	: 라벨 재발행 횟수 증가
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-06-16
 * 수   정   이   력	: 
 * 				  
 */

public class SaveReprintLabel extends DatasetRule {

	// 트랜잭션 정보
	// private TxnInfo txnInfo;

	// 파라미터
	private String lotId; 		// LOT ID
	private String labelType;	// 라벨 타입(Lot, Material)
	
	// 상수
	private final String LABELTYPE_LOT = "Lot";
	private final String LABELTYPE_MATERIAL = "Material";
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		switch(this.labelType) {
		case LABELTYPE_LOT:
			SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(this.lotId);
			if(conLotData != null) {
				Integer printCount = 0;
				if(conLotData.getPrintcount() != null) {
					printCount = conLotData.getPrintcount();
				}
				conLotData.setPrintcount(printCount + 1);
				conLotData.update();
			}
			else {
				SfLotData lotData = SfLotService.getLot(this.lotId);
				Integer printCount = 0;
				if(lotData.getPrintcount() != null) {
					printCount = lotData.getPrintcount();
				}
				lotData.setPrintcount(printCount + 1);
				lotData.update();
			}
			break;
		case LABELTYPE_MATERIAL:
			SfConsumablelotData conLotData2 = SfConsumableLotService.getConsumablelot(this.lotId);
			Integer printCount = 0;
			if(conLotData2.getPrintcount() != null) {
				printCount = conLotData2.getPrintcount();
			}
			conLotData2.setPrintcount(printCount + 1);
			conLotData2.update();
			break;
		}
	}

	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		// this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);

		// 파라미터
		this.lotId = body.getString("lotid");
		this.labelType = body.getString("labeltype");
	}
}
