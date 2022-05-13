package kr.co.micube.mes.standard.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlUserinfobyareaData;
import kr.co.micube.common.mes.so.UlUserinfobyareaKey;
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

public class SaveUserInfoByArea extends DatasetRule{

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
	private ISQLData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException  {
		UlUserinfobyareaData code = new UlUserinfobyareaData();
		UlUserinfobyareaKey codeKey = code.key();
		
		codeKey.setAreaid(row.getString("AREAID"));
		codeKey.setProcessid(row.getString("PROCESSID"));
		
		code = code.selectOne();
		
		if (code != null)
		{
			throw new MESException("InValidData002", String.format("AREAID = %s", row.getString("AREAID")));
		}
		
		UlUserinfobyareaData newCode = new UlUserinfobyareaData();
		UlUserinfobyareaKey newCodeKey = newCode.key();
		
		newCodeKey.setAreaid(row.getString("AREAID"));
		newCodeKey.setProcessid(row.getString("PROCESSID"));
		
		newCode.setUserid(row.getString("USERID"));
		newCode.setUsername(row.getString("USERNAME"));
		newCode.setPosition(row.getString("POSITION"));
		newCode.setTeam(row.getString("TEAM"));
		newCode.setValidstate(row.getString("VALIDSTATE"));
		
		return newCode;
	}
	//Update
	private ISQLData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		UlUserinfobyareaData code = new UlUserinfobyareaData();
		UlUserinfobyareaKey codeKey = code.key();
		
		codeKey.setAreaid(row.getString("AREAID"));
		codeKey.setProcessid(row.getString("PROCESSID"));
		
		code.setUserid(row.getString("USERID"));
		code.setUsername(row.getString("USERNAME"));
		code.setPosition(row.getString("POSITION"));
		code.setTeam(row.getString("TEAM"));
		code.setValidstate(row.getString("VALIDSTATE"));
		
		return code;
	}
	//Delete
	private ISQLData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		UlUserinfobyareaData code = new UlUserinfobyareaData();
		UlUserinfobyareaKey codeKey = code.key();
		
		codeKey.setAreaid(row.getString("AREAID"));
		codeKey.setProcessid(row.getString("PROCESSID"));
		
		code = code.selectOne();
		
		if(code == null) 
		{
			throw new MESException("InValidData003", String.format("AREAID = %s", row.getString("AREAID")));
		}
		return code;
	}

}
