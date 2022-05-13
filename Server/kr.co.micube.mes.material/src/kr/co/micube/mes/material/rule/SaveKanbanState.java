package kr.co.micube.mes.material.rule;

import java.util.ArrayList;
import java.util.List;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlKanbanData;
import kr.co.micube.common.mes.so.UlKanbanKey;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.json.parser.ParseException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLData;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 자재관리 > 자재재고관리 > 간반요청출고관리
 * 설               명	: 처리완료 => 간반 자재LOT 맵핑
 * 생      성      자	: 이준용
 * 생      성      일	: 2020-06-24
 * 수   정   이   력	: 2020-06-30 |이준용 |창고이동, 입출력 반영
 * 				  
 */
public class SaveKanbanState extends DatasetRule {

	private IDataTable gridReq; 
	//private IDataTable gridLot;
	//private String newLotId;
	//private Double newLotQty;
	//private String lotId;
	//private Double lotQty;
	
	List<String> list = new ArrayList<String>();
	Object[] objs;
	
	@Override
	public void doEvent() throws Throwable {
		
		//IMessage msg = this.getMessage().get();
		//IData jmsg = msg.get();
		
		IDataSet ds = this.getRequestDataset();
		this.gridReq = ds.getTable("gridreq");


		ISQLUpsertBatch batch = new SQLUpsertBatch();
		//TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
		
		IDataRow reqRow = null;

		for(int j=0, len=gridReq.size(); j < len; j++) {
			reqRow=gridReq.getRow(j);
			batch.add(getUpdateData(reqRow),  SQLUpsertType.UPDATE);
		}
		
		
		  batch.execute();
	}

	// 준비상태 => 완료상태
 	private ISQLData getUpdateData(IDataRow reqRow) throws InValidDataException, DatabaseException, MESException, SystemException, ParseException, java.text.ParseException {
		UlKanbanData code = new UlKanbanData();
		UlKanbanKey codeKey = code.key();

		RequestKanban requstInfo = new RequestKanban();
		
		String reqCode = reqRow.getString("REQCODE");
		codeKey.setReqcode(reqCode);
		
		code.setState("Response");
		code.setLotqty(reqRow.getDouble("LOTQTY"));
		code.setConsumabledefid(reqRow.getString("CONSUMABLEDEFID"));
		code.setFromwarehouseid(reqRow.getString("FROMWAREHOUSEID"));
		code.setResdate(requstInfo.getDate());
		
		return code;
	}
}
