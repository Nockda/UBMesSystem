package kr.co.micube.mes.standard.rule;



import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.CtUnitdefinitionData;
import kr.co.micube.common.mes.so.CtUnitdefinitionKey;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;



public class SaveUnit extends DatasetRule {
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		if(dt != null)
		{
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
		}
		
		batch.execute();
	}


	//TEAM Insert
	private CtUnitdefinitionData getInsertData(IDataRow row, ISQLUpsertBatch batch)
			throws InValidDataException, DatabaseException, MESException, SystemException {
		CtUnitdefinitionData unitdata = new CtUnitdefinitionData();
		CtUnitdefinitionKey unitkey = unitdata.key();
		unitkey.setUnitid(row.getString("UNITID"));
		unitdata = unitdata.selectOne();
		
		if (unitdata != null) {
			throw new InValidDataException("InValidData002",String.format("UNITID = %s"
					,row.getString("UNITID")));
		}
		
		unitdata = new CtUnitdefinitionData();
		unitkey = unitdata.key();
		unitkey.setUnitid(row.getString("UNITID"));
		
		unitdata.setUnit(row.getString("UNIT"));
		unitdata.setUnitname(row.getString("UNITNAME"));
		unitdata.setValidstate(row.getString("VALIDSTATE"));
		unitdata.setDescription(row.getString("DESCRIPTION"));

		
		unitdata.setLasttxnid(TransactionId.CREATE);
		return unitdata;
	}
	
	//TEAM Update
	private CtUnitdefinitionData getUpdateData(IDataRow row, ISQLUpsertBatch batch)
			throws InValidDataException, DatabaseException, MESException, SystemException {
		CtUnitdefinitionData unitdata = new CtUnitdefinitionData();
		CtUnitdefinitionKey unitkey = unitdata.key();
		unitkey.setUnitid(row.getString("UNITID"));
		unitdata = unitdata.selectOne();

		
		
		if (unitdata == null) {
			throw new InValidDataException("InValidData001",String.format("UNITID = %s"
					,row.getString("UNITID")));
		}
		

		
		unitdata.setUnit(row.getString("UNIT"));
		unitdata.setUnitname(row.getString("UNITNAME"));
		unitdata.setValidstate(row.getString("VALIDSTATE"));
		unitdata.setDescription(row.getString("DESCRIPTION"));
		
		unitdata.setLasttxnid(TransactionId.MODIFY);
		return unitdata;
	}
	
	//TEAM Delete
	private CtUnitdefinitionData getDeleteData(IDataRow row, ISQLUpsertBatch batch)
			throws InValidDataException, DatabaseException, MESException, SystemException {
		CtUnitdefinitionData unitdata = new CtUnitdefinitionData();
		CtUnitdefinitionKey unitkey = unitdata.key();
		unitkey.setUnitid(row.getString("UNITID"));
		unitdata = unitdata.selectOne();

		
		
		if (unitdata == null) {
			throw new InValidDataException("InValidData003",String.format("UNITID = %s"
					,row.getString("UNITID")));
		}

		unitdata.setLasttxnid(TransactionId.DELETE);

		return unitdata;
	}

}
