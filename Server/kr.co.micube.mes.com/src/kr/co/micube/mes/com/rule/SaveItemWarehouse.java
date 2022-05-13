package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlItemwarehouseData;
import kr.co.micube.common.mes.so.UlItemwarehouseKey;
import kr.co.micube.core.exception.SystemException;
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
 * 프  로  그  램  명	: 기준정보 > 코드 관리 > 자재창고대차관리
 * 설               명	: 자재창고대차관리 정보 화면에서 변경된 데이터를 수정 한다.
 * 생      성      자	: jylee
 * 생      성      일	: 2020-04-09
 * 수   정   이   력	: 
 */
public class SaveItemWarehouse extends DatasetRule {

	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		String state = null;
		
		for (int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);
			state = row.getString("_STATE_");
			
			switch (state) {
				case UpsertState.INSERT:
					batch.add(getInsertData(row, batch), SQLUpsertType.INSERT);
					break;
				case UpsertState.UPDATE:
					batch.add(getUpdateData(row, batch), SQLUpsertType.UPDATE);
					break;
				case UpsertState.DELETE:
					batch.add(getDeleteData(row, batch), SQLUpsertType.DELETE);
					break;
			}
		}
		
		batch.execute();
		
	}
	// Delete Code
	private ISQLData getDeleteData(IDataRow row, ISQLUpsertBatch batch) {
		// TODO Auto-generated method stub
		return null;
	}
	
	// Update Code
	private UlItemwarehouseData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		
		UlItemwarehouseData code = new UlItemwarehouseData();
		UlItemwarehouseKey codeKey = code.key();
		
		codeKey.setCodeid(row.getString("C_TYPEID"));
		codeKey.setItemid(row.getString("ITEMID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("C_TYPEID")));
		}
		

		return code;
	}

	private ISQLData getInsertData(IDataRow row, ISQLUpsertBatch batch) {
		// TODO Auto-generated method stub
		return null;
	}

}
