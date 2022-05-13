package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlEquipmentchecklistData;
import kr.co.micube.common.mes.so.UlEquipmentchecklistKey;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 기준정보 > 설비점검관리 > 점검항목
 * 설               명	: 설비점검항목을 관리한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-03-04
 * 수   정   이   력	: 
 */
public class SaveEquipCheckList extends DatasetRule {
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
	
	// Insert Code
		private UlEquipmentchecklistData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlEquipmentchecklistData code = new UlEquipmentchecklistData();
			UlEquipmentchecklistKey codeKey = code.key();

			codeKey.setEquipcheckid(row.getString("EQUIPCHECKID"));

			code = code.selectOne();
			
			if (code != null)
			{
				throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("EQUIPCHECKID")));
			}
			
			UlEquipmentchecklistData newCode = new UlEquipmentchecklistData();
			UlEquipmentchecklistKey newCodeKey = newCode.key();

			newCodeKey.setEquipcheckid(row.getString("EQUIPCHECKID"));
			
			newCode.setEquipcheckname(row.getString("EQUIPCHECKNAME"));
			newCode.setChecktype(row.getString("CHECKTYPE"));
			newCode.setCheckway(row.getString("CHECKWAY"));
			newCode.setCheckcycle(row.getString("CHECKCYCLE"));
			newCode.setCheckcount(row.getDouble("CHECKCOUNT"));
			newCode.setResultway(row.getString("RESULTWAY"));
			newCode.setDescription(row.getString("DESCRIPTION"));
			newCode.setValidstate(row.getString("VALIDSTATE"));
			
			return newCode;
		}
		
		// Update Code
		private UlEquipmentchecklistData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlEquipmentchecklistData code = new UlEquipmentchecklistData();
			UlEquipmentchecklistKey codeKey = code.key();

			codeKey.setEquipcheckid(row.getString("EQUIPCHECKID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("EQUIPCHECKID")));
			}
				
			code.setEquipcheckname(row.getString("EQUIPCHECKNAME"));
			code.setChecktype(row.getString("CHECKTYPE"));
			code.setCheckway(row.getString("CHECKWAY"));
			code.setCheckcycle(row.getString("CHECKCYCLE"));
			code.setCheckcount(row.getDouble("CHECKCOUNT"));
			code.setResultway(row.getString("RESULTWAY"));
			code.setDescription(row.getString("DESCRIPTION"));
			code.setValidstate(row.getString("VALIDSTATE"));

			return code;
		}

		// Delete Code
		private UlEquipmentchecklistData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlEquipmentchecklistData code = new UlEquipmentchecklistData();
			UlEquipmentchecklistKey codeKey = code.key();

			codeKey.setEquipcheckid(row.getString("EQUIPCHECKID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("EQUIPCHECKID")));
			}
			
			return code;
		}

}
