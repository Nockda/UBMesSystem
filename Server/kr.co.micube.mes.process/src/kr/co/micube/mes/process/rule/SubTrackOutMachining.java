package kr.co.micube.mes.process.rule;

import java.text.DecimalFormat;
import java.text.ParseException;

import kr.co.micube.common.mes.constant.ProcessClass;
import kr.co.micube.common.mes.service.SfLotEquipmentService;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 가공
 * 설               명	: 가공 작업완료
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-05-25
 * 수   정   이   력	: 
 * 				  
 */

public class SubTrackOutMachining extends DatasetRule {

	// 트랜잭션 정보
	private TxnInfo txnInfo;

	// 파라미터
	private String lotId; 							// LOT ID
	private Double qty;								// 수량
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		SfLotService.validateLotStateIsInProduction(this.lotId);
		SfLotService.validateProcessClass(this.lotId, ProcessClass.MACHINING);					// 기계가공 LOT인지 검증
		SfLotData lotData = SfLotService.getLot(this.lotId);
		validateQty(lotData.getQty());
		if(this.qty != lotData.getQty()) {	// 입력된 수량이 현재수량과 다르면 LOT 수량 변경
			lotData.setQty(this.qty);
			lotData.update();
		}
		SfLotEquipmentService.endLotEquipment(this.lotId, SQLService.toDate(), this.txnInfo);	// LOT 별 설비작업실적 작업완료 처리
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
}
