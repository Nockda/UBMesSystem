package kr.co.micube.mes.process.rule;

import java.text.ParseException;

import kr.co.micube.common.mes.service.SfConsumableLotService;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 
 * 설               명	: MBS-C 사양 저장
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-07-16
 * 수   정   이   력	: 
 * 				  
 */

public class SaveSubPartNumber extends DatasetRule {

	// 트랜잭션 정보
	// private TxnInfo txnInfo;

	// 파라미터
	private IDataTable list;	// LOT 목록(lotid, subpartnumber)
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		for (int i = 0; i < this.list.size(); i++) {
			IDataRow row = this.list.getRow(i);
			SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(row.getString("LOTID"));
			conLotData.setSubpartnumber(row.getString("SUBPARTNUMBER"));	// MBS-C 사양
			batch.add(conLotData, SQLUpsertType.UPDATE);
		}
		batch.execute();
	}

	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		/*
		this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);
		*/
		
		// 파라미터
		IDataSet ds = this.getRequestDataset();
		this.list = ds.getTable("list");
	}
}
