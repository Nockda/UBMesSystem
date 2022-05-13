package kr.co.micube.mes.standard.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlModelmappingData;
import kr.co.micube.common.mes.so.UlModelmappingKey;
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

public class MappingModelSpec extends DatasetRule {

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
		UlModelmappingData code = new UlModelmappingData();
		UlModelmappingKey codeKey = code.key();
		
		codeKey.setModelid(row.getString("MODELID"));
		codeKey.setSpecid(row.getString("SPECID"));
		
		code = code.selectOne();
		
		if (code != null)
		{
			throw new MESException("InValidData002", String.format("MODELID = %s", row.getString("MODELID")));
		}
		
		UlModelmappingData newCode = new UlModelmappingData();
		UlModelmappingKey newCodeKey = newCode.key();
		
		newCodeKey.setModelid(row.getString("MODELID"));
		newCodeKey.setSpecid(row.getString("SPECID"));
		
		newCode.setModelname(row.getString("MODELNAME"));
		newCode.setSpecname(row.getString("SPECNAME"));
		newCode.setDescription(row.getString("DESCRIPTION"));
		newCode.setValidstate(row.getString("VALIDSTATE"));
		

		return newCode;
	}
	//Update
	private ISQLData getUpdateData(IDataRow row, ISQLUpsertBatch batch)  throws InValidDataException, DatabaseException, MESException, SystemException {
		UlModelmappingData code = new UlModelmappingData();
		UlModelmappingKey codeKey = code.key();
		
		codeKey.setModelid(row.getString("MODELID"));
		codeKey.setSpecid(row.getString("SPECID"));
		
		code.setModelname(row.getString("MODELNAME"));
		code.setSpecname(row.getString("SPECNAME"));
		code.setDescription(row.getString("DESCRIPTION"));
		code.setValidstate(row.getString("VALIDSTATE"));
		
		return code;
	}
	//Delete
	private ISQLData getDeleteData(IDataRow row, ISQLUpsertBatch batch)  throws InValidDataException, DatabaseException, MESException, SystemException {
		// TODO Auto-generated method stub
		
		UlModelmappingData code = new UlModelmappingData();
		UlModelmappingKey codeKey = code.key();
		
		codeKey.setModelid(row.getString("MODELID"));
		codeKey.setSpecid(row.getString("SPECID"));
		
		code = code.selectOne();
		
		if(code == null) 
		{
			throw new MESException("InValidData003", String.format("MODELID = %s", row.getString("MODELID")));
		}
		
		
		return code;
	}

}
