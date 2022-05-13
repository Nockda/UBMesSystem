package kr.co.micube.mes.standard.rule;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlShipinspstandardData;
import kr.co.micube.common.mes.so.UlShipinspstandardKey;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLData;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;
/*
 * 프  로  그  램  명	: 기준정보 > 검사관리 > 출하검사기준등록
 * 설               명	: 출하 검사 기준 등록
 * 생      성      자	: sejoo
 * 생      성      일	: 2022-05-09
 * 수   정   이   력	: 
 * 				  
 */
public class SaveShipInspectionStandard extends DatasetRule {

	@Override
	public void doEvent() throws Throwable {
		IMessage msg = this.getMessage().get();
		IData body = msg.get().get(MessageFormat.Body);
		
		IDataSet ds = this.getRequestDataset();
		IDataTable dtRev = ds.getTable("dtRev");
		IDataTable dtInsp = ds.getTable("dtInsp");
		
		String state = body.getString("state");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		IDataRow rowInsp = null;
		//String state = null;
		
		if(state.equals("Insert") || state.equals("Update") || state.equals("Delete")) {
			for (int i = 0, len = dtRev.size(); i < len; i++) {
				
				for(int j=0, len2 = dtInsp.size(); j < len2; j++) {
					
					row = dtRev.getRow(i);
					rowInsp = dtInsp.getRow(j);
					//state = row.getString("_STATE_");
					
					switch (state) {
						case "Insert":
							batch.add(getInsertData(row, rowInsp, batch), SQLUpsertType.INSERT);
							break;
						case "Update":
							batch.add(getUpdateData(row, rowInsp, batch), SQLUpsertType.UPDATE);
							break;
						case "Delete":
							//batch.add(getDeleteData(row, rowInsp, batch), SQLUpsertType.DELETE);
							getDeleteData(row, rowInsp, batch);
							break;
					}
				}
				
			}
		} 
		else if(state.equals("UpdateInspData")) {
			for(int r=0, len3 = dtInsp.size(); r < len3; r++) {
				rowInsp = dtInsp.getRow(r);
				
				batch.add(getUpdateInspData(rowInsp, batch), SQLUpsertType.UPDATE);
			}
		}
		
		batch.execute();
	}
	
	//Insert
	private ISQLData getInsertData(IDataRow row, IDataRow rowInsp, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		
		UlShipinspstandardData data = new UlShipinspstandardData();
		UlShipinspstandardKey key = data.key();
		
		key.setRevno(row.getInteger("REVNO"));
		key.setInspectionid(rowInsp.getString("INSPECTIONID"));
		
		data = data.selectOne();
		
		if(data != null) {
			throw new InValidDataException("InValidData002", String.format("RevNo = %s, InspectionId = %s", row.getInteger("REVNO"), rowInsp.getString("INSPECTIONID")));
		}
		
		UlShipinspstandardData newData = new UlShipinspstandardData();
		UlShipinspstandardKey newKey = newData.key();
		
		newKey.setRevno(row.getInteger("REVNO"));
		newKey.setInspectionid(rowInsp.getString("INSPECTIONID"));
		
		newData.setInspectionname(rowInsp.getString("INSPECTIONNAME"));
		newData.setReasondescription(row.getString("REASONDESCRIPTION"));
		newData.setValidstate(Constant.VALIDSTATE_VALID);
		
		
		return newData;
	}

	private ISQLData getUpdateData(IDataRow row, IDataRow rowInsp, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		
		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlShipinspstandardData.Revno, row.getInteger("REVNO"));
		
		UlShipinspstandardData upData = new UlShipinspstandardData();
		ISQLDataList<UlShipinspstandardData> upList = upData.select(cond);
		
		if(upList==null) {
			throw new InValidDataException("InValidData001", String.format("RevNo = %s"), row.getInteger("REVNO"));
		}
		
		UlShipinspstandardData data = new UlShipinspstandardData();
		UlShipinspstandardKey key = data.key();
		
		key.setRevno(row.getInteger("REVNO"));
		key.setInspectionid(rowInsp.getString("INSPECTIONID"));
		
		data.setReasondescription(row.getString("REASONDESCRIPTION"));
		
		return data;
		
	}

	private void getDeleteData(IDataRow row, IDataRow rowInsp, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		
		UlShipinspstandardData data = new UlShipinspstandardData();
		UlShipinspstandardKey key = data.key();
		
		key.setRevno(row.getInteger("REVNO"));
		key.setInspectionid(rowInsp.getString("INSPECTIONID"));
		
		data = data.selectOne();
		
		if(data == null) {
			throw new MESException("InValidData003", String.format("RevNo = %s, InspectionId = %s", row.getInteger("REVNO"), rowInsp.getString("INSPECTIONID")));
		}
		
		data.delete();
		//return data;
	}

	
	private ISQLData getUpdateInspData(IDataRow rowInsp, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		
		UlShipinspstandardData data = new UlShipinspstandardData();
		UlShipinspstandardKey key = data.key();
		
		key.setRevno(rowInsp.getInteger("REVNO"));
		key.setInspectionid(rowInsp.getString("INSPECTIONID"));
		
		data.setInspectionname(rowInsp.getString("INSPECTIONNAME"));
		
		return data;
		
	}
}
