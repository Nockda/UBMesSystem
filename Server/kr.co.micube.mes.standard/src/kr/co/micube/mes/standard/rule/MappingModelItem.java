package kr.co.micube.mes.standard.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlModelitemmappingData;
import kr.co.micube.common.mes.so.UlModelitemmappingKey;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class MappingModelItem extends DatasetRule {

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
	private UlModelitemmappingData getInsertData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		UlModelitemmappingData code = new UlModelitemmappingData();
		UlModelitemmappingKey codeKey = code.key();
		
		codeKey.setModelid(row.getString("MODELID"));
		codeKey.setItemid(row.getString("ITEMID"));
		
		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("MODELID = %s", row.getString("MODELID")));
		}
		
		UlModelitemmappingData newCode = new UlModelitemmappingData();
		UlModelitemmappingKey newCodeKey = newCode.key();
		
		newCodeKey.setModelid(row.getString("MODELID"));
		newCodeKey.setItemid(row.getString("ITEMID"));
		
		newCode.setModelname(row.getString("MODELNAME"));
		newCode.setItemname(row.getString("ITEMNAME"));
		newCode.setItemstandard(row.getString("ITEMSTANDARD"));
		newCode.setItemassetcategory(row.getString("ITEMASSETCATEGORY"));
		newCode.setDomesticforeign(row.getString("DOMESTICFOREIGN"));
		newCode.setValidstate(row.getString("VALIDSTATE"));
		
		return newCode;
	}

	//Update
	private UlModelitemmappingData getUpdateData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		
		UlModelitemmappingData code = new UlModelitemmappingData();
		UlModelitemmappingKey codeKey = code.key();
		
		codeKey.setModelid(row.getString("MODELID"));
		codeKey.setItemid(row.getString("ITEMID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("MODELID = %s", row.getString("MODELID")));
		}
		
		code.setModelname(row.getString("MODELNAME"));
		code.setItemname(row.getString("ITEMNAME"));
		code.setItemstandard(row.getString("ITEMSTANDARD"));
		code.setItemassetcategory(row.getString("ITEMASSETCATEGORY"));
		code.setDomesticforeign(row.getString("DOMESTICFOREIGN"));
		code.setValidstate(row.getString("VALIDSTATE"));
		
		return code;
	}

	//Delete
	private UlModelitemmappingData getDeleteData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		UlModelitemmappingData code = new UlModelitemmappingData();
		UlModelitemmappingKey codeKey = code.key();
		
		codeKey.setModelid(row.getString("MODELID"));
		codeKey.setItemid(row.getString("ITEMID"));
		
		code = code.selectOne();
		
		if(code == null) 
		{
			throw new MESException("InValidData003", String.format("MODELID = %s", row.getString("MODELID")));
		}
		
		return code;
	}

}
