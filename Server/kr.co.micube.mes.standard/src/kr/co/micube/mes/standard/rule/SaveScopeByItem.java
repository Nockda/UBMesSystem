package kr.co.micube.mes.standard.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlScopebyitemData;
import kr.co.micube.common.mes.so.UlScopebyitemKey;
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

public class SaveScopeByItem extends DatasetRule {

	@Override
	public void doEvent() throws Throwable {
		// Get Message
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
	//Insert
	private UlScopebyitemData getInsertData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		UlScopebyitemData code = new UlScopebyitemData();
		UlScopebyitemKey codeKey = code.key();
		
		codeKey.setItemid(row.getString("ITEMID"));
		
		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("ITEMID = %s", row.getString("ITEMID")));
		}
		
		UlScopebyitemData newCode = new UlScopebyitemData();
		UlScopebyitemKey newCodeKey = newCode.key();
		
		newCodeKey.setItemid(row.getString("ITEMID"));
	
		newCode.setItemname(row.getString("ITEMNAME"));
		newCode.setModelname(row.getString("MODELNAME"));
		newCode.setDrawingnumber(row.getString("DRAWINGNUMBER"));
		newCode.setProcessid(row.getString("PROCESSID"));
		newCode.setTeam(row.getString("TEAM"));
		newCode.setScope(row.getDouble("SCOPE"));
		newCode.setValidstate(row.getString("VALIDSTATE"));
		
		return newCode;
	}
	//Update
	private UlScopebyitemData getUpdateData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		UlScopebyitemData code = new UlScopebyitemData();
		UlScopebyitemKey codeKey = code.key();
		
		codeKey.setItemid(row.getString("ITEMID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("ITEMID = %s", row.getString("ITEMID")));
		}
		
		code.setItemname(row.getString("ITEMNAME"));
		code.setModelname(row.getString("MODELNAME"));
		code.setDrawingnumber(row.getString("DRAWINGNUMBER"));
		code.setProcessid(row.getString("PROCESSID"));
		code.setTeam(row.getString("TEAM"));
		code.setScope(row.getDouble("SCOPE"));
		code.setValidstate(row.getString("VALIDSTATE"));
		
		return code;
	}
	//Delete
	private ISQLData getDeleteData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		UlScopebyitemData code = new UlScopebyitemData();
		UlScopebyitemKey codeKey = code.key();
		
		codeKey.setItemid(row.getString("ITEMID"));
		
		code = code.selectOne();
		
		if(code == null) 
		{
			throw new MESException("InValidData003", String.format("ITEMID = %s", row.getString("ITEMID")));
		}
		
		return code;
	}

}
