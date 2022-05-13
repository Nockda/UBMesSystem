package kr.co.micube.mes.standard.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlModelData;
import kr.co.micube.common.mes.so.UlModelKey;
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
 * 프  로  그  램  명	: 기준정보 > 코드관리 > 기종관리
 * 설               명	: 기종을 정의
 * 생      성      자	: jylee
 * 생      성      일	: 2020-05-04
 * 수   정   이   력	: 
 * 				  
 */
public class SaveModelList extends DatasetRule {

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
	//Insert
	private ISQLData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		
		UlModelData code = new UlModelData();
		UlModelKey codeKey = code.key();
		
		codeKey.setModelid(row.getString("MODELID"));
		
		code = code.selectOne();
		
		if(code != null) {
			throw new InValidDataException("InValidData002", String.format("ModelId = %s", row.getString("MODELID")));
		}
		
		UlModelData newCode = new UlModelData();
		UlModelKey newCodeKey = newCode.key();
		
		newCodeKey.setModelid(row.getString("MODELID"));
		newCode.setModelnamekor(row.getString("MODELNAMEKOR"));
		newCode.setModelnameeng(row.getString("MODELNAMEENG"));
		newCode.setModelnamejpn(row.getString("MODELNAMEJPN"));
		newCode.setDescription(row.getString("DESCRIPTION"));
		newCode.setValidstate(row.getString("VALIDSTATE"));

		return newCode;
	}

	private ISQLData getUpdateData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		
		UlModelData code = new UlModelData();
		UlModelKey codeKey = code.key();
		
		codeKey.setModelid(row.getString("MODELID"));
		code.setModelnamekor(row.getString("MODELNAMEKOR"));
		code.setModelnameeng(row.getString("MODELNAMEENG"));
		code.setModelnamejpn(row.getString("MODELNAMEJPN"));
		code.setDescription(row.getString("DESCRIPTION"));
		code.setValidstate(row.getString("VALIDSTATE"));
		
		return code;
	}

	private ISQLData getDeleteData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		UlModelData code = new UlModelData();
		UlModelKey codeKey = code.key();
		
		codeKey.setModelid(row.getString("MODELID"));
		
		code = code.selectOne();
		
		if(code == null) 
		{
			throw new MESException("InValidData003", String.format("SpecId = %s", row.getString("SPECID")));
		}
		return code;
	}

}
