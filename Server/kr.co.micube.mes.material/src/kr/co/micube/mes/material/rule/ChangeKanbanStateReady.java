package kr.co.micube.mes.material.rule;

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
 * 설               명	: 간반요청상태 => 재고준비상태
 * 생      성      자	: jylee
 * 생      성      일	: 2020-06-16
 * 수   정   이   력	: 
 * 				  
 */
public class ChangeKanbanStateReady extends DatasetRule {

	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		
		  for(int i = 0, len = dt.size(); i < len; i++) { 
			row = dt.getRow(i); 
			batch.add(getUpdateData(row), SQLUpsertType.UPDATE);  
		  }

		batch.execute();
	}

	private ISQLData getUpdateData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException, ParseException{
		UlKanbanData code = new UlKanbanData();
		UlKanbanKey key = code.key();
		key.setReqcode(row.getString("REQCODE"));
		code.setState("Ready"); 					// 준비상태
		
		return code;
	}

}
