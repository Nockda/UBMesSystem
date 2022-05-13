package kr.co.micube.mes.material.rule;

import kr.co.micube.common.mes.util.MaterialService;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 자재관리 > 자재 Lot 관리 > 자재 Lot 분할
 * 설               명	: 한개의 자재 Lot을 여러개의 자재 Lot으로 분할한다.
 * 생      성      자	: 유태근
 * 생      성      일	: 2020-06-09
 * 수   정   이   력	: 
 */
public class SaveConsumableLotSplit extends DatasetRule {
	
	private String consumableLotId;
	private double totalSplitQty;
	private double beforeQty;
	
	@Override
	public void doEvent() throws Throwable {
		
		IMessage msg = this.getMessage().get(); // 메세지
		IData jmsg = msg.get(); // IData 형태로 변환
		IData body = jmsg.get(MessageFormat.Body); // 메세지부의 Body부 추출
		
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("splitConsumableLotlist");
		
		consumableLotId = body.getString("consumableLotId");
		totalSplitQty = body.getDouble("totalSplitQty");
		beforeQty = body.getDouble("beforeQty");
		
		TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
		
		/***************************************************
		 * 자재 Lot 분할
		****************************************************/
		IDataRow row = null;
		
		boolean flag = true;

		for (int i = 0, len = dt.size(); i < len; i++) 
		{		
			row = dt.getRow(i);
			MaterialService.SplitConsumableLot(consumableLotId, beforeQty, totalSplitQty,row.getDouble("SPLITQTY"), flag, txnInfo);
			flag = false;
		}
		
	}
}