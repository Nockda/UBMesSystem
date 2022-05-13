package kr.co.micube.mes.standard.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlProcessmodelspecmappingData;
import kr.co.micube.common.mes.so.UlProcessmodelspecmappingKey;
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
 * 프  로  그  램  명	: 기준정보 > 코드관리 > 공정별기종맵핑
 * 설               명	: 공정정보와 기종정보를 맵핑
 * 생      성      자	: jylee
 * 생      성      일	: 2020-05-12
 * 수   정   이   력	: 
 */
public class MappingProcessModelSpec extends DatasetRule{

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
	private UlProcessmodelspecmappingData getInsertData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		UlProcessmodelspecmappingData code = new UlProcessmodelspecmappingData();
		UlProcessmodelspecmappingKey codeKey = code.key();
		
		codeKey.setProcessid(row.getString("PROCESSID"));
		codeKey.setModelid(row.getString("MODELID"));
		codeKey.setSpecid(row.getString("SPECID"));
		
		code = code.selectOne();
		
		if (code != null)
		{
			throw new MESException("InValidData002", String.format("PROCESSID = %s", row.getString("PROCESSID")));
		}
		
		UlProcessmodelspecmappingData newCode = new UlProcessmodelspecmappingData();
		UlProcessmodelspecmappingKey newCodeKey = newCode.key();
		
		newCodeKey.setProcessid(row.getString("PROCESSID"));
		newCodeKey.setModelid(row.getString("MODELID"));
		newCodeKey.setSpecid(row.getString("SPECID"));
		
		newCode.setProcessname(row.getString("PROCESSNAME"));
		newCode.setModelname(row.getString("MODELNAME"));
		newCode.setSpecname(row.getString("SPECNAME"));
		newCode.setValidstate(row.getString("VALIDSTATE"));
		
		return newCode;
	}
	//Update
	private ISQLData getUpdateData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		// TODO Auto-generated method stub
		return null;
	}
	//Delete
	private ISQLData getDeleteData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		UlProcessmodelspecmappingData code = new UlProcessmodelspecmappingData();
		UlProcessmodelspecmappingKey codeKey = code.key();
		
		codeKey.setProcessid(row.getString("PROCESSID"));
		codeKey.setModelid(row.getString("MODELID"));
		codeKey.setSpecid(row.getString("SPECID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData003", String.format("PROCESSID = %s", row.getString("PROCESSID")));
		}
		
		return code;
	}

}
