package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlRackData;
import kr.co.micube.common.mes.so.UlRackKey;
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
 * 프  로  그  램  명	: 기준정보 > 창고관리 > 랙관리
 * 설               명	: 창고 랙 관리 데이터를 수정한다.
 * 생      성      자	: jylee
 * 생      성      일	: 2020-04-15
 * 수   정   이   력	: 
 */
public class SaveRack2 extends DatasetRule{

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
	
	//INSERT
	private UlRackData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		UlRackData code = new UlRackData();
		UlRackKey codeKey = code.key();
		
		codeKey.setRackid(row.getString("RACKID"));
		
		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("RACKID")));
		}
		
		UlRackData newCode = new UlRackData();
		UlRackKey newCodeKey = newCode.key();
		
		newCodeKey.setRackid(row.getString("RACKID"));
		newCode.setRackname(row.getString("RACKNAME"));
		newCode.setTeam(row.getString("TEAM"));
		newCode.setWarehouseid(row.getString("WAREHOUSEID"));
		newCode.setWarehousename(row.getString("WAREHOUSENAME"));
		newCode.setMainuserid(row.getString("MAINUSERID"));
		newCode.setMainusername(row.getString("MAINUSERNAME"));
		newCode.setSubuserid(row.getString("SUBUSERID"));
		newCode.setSubusername(row.getString("SUBUSERNAME"));
		newCode.setValidstate(row.getString("VALIDSTATE"));
		
		return newCode;
	}
	
	//UPDATE
	private UlRackData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		UlRackData code = new UlRackData();
		UlRackKey codeKey = code.key();
		
		codeKey.setRackid(row.getString("RACKID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("RACKID")));
		}
		
		codeKey.setRackid(row.getString("RACKID"));
		code.setRackname(row.getString("RACKNAME"));
		code.setTeam(row.getString("TEAM"));
		code.setWarehouseid(row.getString("WAREHOUSEID"));
		code.setWarehousename(row.getString("WAREHOUSENAME"));
		code.setMainuserid(row.getString("MAINUSERID"));
		code.setMainusername(row.getString("MAINUSERNAME"));
		code.setSubuserid(row.getString("SUBUSERID"));
		code.setSubusername(row.getString("SUBUSERNAME"));
		code.setValidstate(row.getString("VALIDSTATE"));
		
		return code;
	}
	
	//DELETE
	private UlRackData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		UlRackData code = new UlRackData();
		UlRackKey codeKey = code.key();
		
		codeKey.setRackid(row.getString("RACKID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("RACKID")));
		}
		
		return code;
	}

}
