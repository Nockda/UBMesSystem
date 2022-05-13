package kr.co.micube.mes.equipment.rule;

import java.text.ParseException;
import java.text.SimpleDateFormat;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlEquipmentcheckdatadetailData;
import kr.co.micube.common.mes.so.UlEquipmentcheckdatadetailKey;
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
 * 설               명	: 설비일상점검표 상세데이터를 저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-05-21
 * 수   정   이   력	: 
 */
public class SaveEquipCheckDataDetail extends DatasetRule {
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
	
	  private UlEquipmentcheckdatadetailData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException, ParseException 
	  { 
		  UlEquipmentcheckdatadetailData code = new UlEquipmentcheckdatadetailData(); 
		  UlEquipmentcheckdatadetailKey codeKey = code.key();
	  
		  codeKey.setSeq(row.getDouble("SEQ"));
		  
		  code = code.selectOne();
		  
		  if (code != null) { throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getInteger("SEQ").toString())); }
		  
		  UlEquipmentcheckdatadetailData newCode = new UlEquipmentcheckdatadetailData();
		  //UlEquipmentcheckdatadetailKey newCodeKey = newCode.key();
		  
		  //newCodeKey.setSeq(row.getInteger("SEQ"));
		  
		  SimpleDateFormat fm = new SimpleDateFormat("yyyy-MM-dd");
		  String sOccurDate = row.getString("OCCURDATE");
		  String sActionDate = row.getString("ACTIONDATE");
		  
		  newCode.setEquipmentid(row.getString("EQUIPMENTID"));
		  newCode.setOccurdate(fm.parse(sOccurDate));
		  newCode.setOccurdescription(row.getString("OCCURDESCRIPTION"));
		  if(sActionDate.length() > 0)
			  newCode.setActiondate(fm.parse(sActionDate));
		  newCode.setActiondescription(row.getString("ACTIONDESCRIPTION"));
		  
		  return newCode; 
	  }
	  
	  // Update Code 
	  private UlEquipmentcheckdatadetailData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException, ParseException 
	  { 
		  UlEquipmentcheckdatadetailData code = new UlEquipmentcheckdatadetailData(); 
		  UlEquipmentcheckdatadetailKey codeKey = code.key();
	  
		  codeKey.setSeq(row.getDouble("SEQ"));
		  
		  code = code.selectOne();
		  
		  if (code == null) { throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getInteger("SEQ").toString())); }
		  
		  SimpleDateFormat fm = new SimpleDateFormat("yyyy-MM-dd");
		  String sActionDate = row.getString("ACTIONDATE");
		  
		  code.setOccurdescription(row.getString("OCCURDESCRIPTION"));
		  if(sActionDate.length() > 0)
			  code.setActiondate(fm.parse(sActionDate));
		  code.setActiondescription(row.getString("ACTIONDESCRIPTION"));
	  
		  return code; 
	  }
	  
	  // Delete Code 
	  private UlEquipmentcheckdatadetailData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException 
	  { 
		  UlEquipmentcheckdatadetailData code = new UlEquipmentcheckdatadetailData(); 
		  UlEquipmentcheckdatadetailKey codeKey = code.key();
	  
		  codeKey.setSeq(row.getDouble("SEQ"));

		  code = code.selectOne();
		  
		  if (code == null) { throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getInteger("SEQ").toString())); }
		  
		  return code;
	  }
	 
}
