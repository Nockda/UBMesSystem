package kr.co.micube.mes.equipment.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlEquipmentcheckdataData;
import kr.co.micube.common.mes.so.UlEquipmentcheckdataKey;
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
 * 프  로  그  램  명	: 설비관리 > 설비점검 > 설비일상점검표
 * 설               명	: 설비일상점검표 데이터를 저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-04-09
 * 수   정   이   력	: 2020-05-20 설비일상점검표 수정에 따른 변경
 */
public class SaveEquipCheckData extends DatasetRule {
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
	
	  private UlEquipmentcheckdataData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException 
	  { 
		  UlEquipmentcheckdataData code = new UlEquipmentcheckdataData(); UlEquipmentcheckdataKey codeKey = code.key();
	  
		  codeKey.setCheckdate(row.getString("CHECKDATE"));
		  codeKey.setEquipmentid(row.getString("EQUIPMENTID"));
		  codeKey.setEquipcheckid(row.getString("EQUIPCHECKID"));

		  code = code.selectOne();
		  
		  if (code != null) { throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("CHECKDATE") + "|" + row.getString("EQUIPMENTID") + "|" + row.getString("EQUIPMENTCHECKID"))); }
		  
		  UlEquipmentcheckdataData newCode = new UlEquipmentcheckdataData();
		  UlEquipmentcheckdataKey newCodeKey = newCode.key();
		  
		  newCodeKey.setCheckdate(row.getString("CHECKDATE"));
		  newCodeKey.setEquipmentid(row.getString("EQUIPMENTID"));
		  newCodeKey.setEquipcheckid(row.getString("EQUIPCHECKID"));

		  newCode.setResulttype01(row.getString("RESULTTYPE01"));
		  newCode.setResulttype02(row.getDouble("RESULTTYPE02"));
		  
		  return newCode; 
	  }
	  
	  // Update Code 
	  private UlEquipmentcheckdataData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException 
	  { 
		  UlEquipmentcheckdataData code = new UlEquipmentcheckdataData(); 
		  UlEquipmentcheckdataKey codeKey = code.key();
	  
		  codeKey.setCheckdate(row.getString("CHECKDATE"));
		  codeKey.setEquipmentid(row.getString("EQUIPMENTID"));
		  codeKey.setEquipcheckid(row.getString("EQUIPCHECKID"));

		  
		  code = code.selectOne();
		  
		  if (code == null) 
		  { 
			  throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("CHECKDATE") + "|" + row.getString("EQUIPMENTID") + "|" + row.getString("EQUIPMENTCHECKID"))); 
		  }
		  
		  code.setResulttype01(row.getString("RESULTTYPE01"));
		  code.setResulttype02(row.getDouble("RESULTTYPE02"));
	  
		  return code; 
	  }
	  
	  // Delete Code 
	  private UlEquipmentcheckdataData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException 
	  { 
		  UlEquipmentcheckdataData code = new UlEquipmentcheckdataData(); UlEquipmentcheckdataKey codeKey = code.key();
	  
		  codeKey.setCheckdate(row.getString("CHECKDATE"));
		  codeKey.setEquipmentid(row.getString("EQUIPMENTID"));
		  codeKey.setEquipcheckid(row.getString("EQUIPCHECKID"));

		  
		  code = code.selectOne();
		  
		  if (code == null) { throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("CHECKDATE") + "|" + row.getString("EQUIPMENTID") + "|" + row.getString("EQUIPMENTCHECKID"))); }
		  
		  return code;
	  }
	 
}
