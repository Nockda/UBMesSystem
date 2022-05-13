package kr.co.micube.mes.standard.rule;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.CtAreaworkerData;
import kr.co.micube.common.mes.so.CtAreaworkerKey;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;



public class SaveAreaWorker extends DatasetRule {
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


	//Areaworker Insert
	private CtAreaworkerData getInsertData(IDataRow row, ISQLUpsertBatch batch)
			throws InValidDataException, DatabaseException, MESException, SystemException {
		CtAreaworkerData AreaworkerData = new CtAreaworkerData();
		CtAreaworkerKey AreaworkerKey = AreaworkerData.key();
		AreaworkerKey.setAreaid(row.getString("AREAID"));
		AreaworkerKey.setUserid(row.getString("USERID"));
		AreaworkerData = AreaworkerData.selectOne();
		
		if (AreaworkerData != null) {
			throw new InValidDataException("InValidData002",String.format("AREAID = %s,WORKERNAME = %s"
					,row.getString("AREAID"),row.getString("USERID")));
		}
		
		AreaworkerData = new CtAreaworkerData();
		AreaworkerKey = AreaworkerData.key();
		AreaworkerKey.setAreaid(row.getString("AREAID"));
		AreaworkerKey.setUserid(row.getString("USERID"));
		AreaworkerData.setValidstate(row.getString("VALIDSTATE"));

		
		AreaworkerData.setLasttxnid(TransactionId.CREATE);
		return AreaworkerData;
	}
	
	//Areaworker Update
	private CtAreaworkerData getUpdateData(IDataRow row, ISQLUpsertBatch batch)
			throws InValidDataException, DatabaseException, MESException, SystemException {
		CtAreaworkerData AreaworkerData = new CtAreaworkerData();
		CtAreaworkerKey AreaworkerKey = AreaworkerData.key();
		
		AreaworkerKey.setAreaid(row.getString("AREAID"));
		AreaworkerKey.setUserid(row.getString("USERID"));
		
		AreaworkerData = AreaworkerData.selectOne();
		
		if (AreaworkerData == null) {
			throw new InValidDataException("InValidData001",String.format("AREAID = %s,WORKERNAME = %s"
					,row.getString("AREAID"),row.getString("USERID")));
		}
		
		AreaworkerData.setValidstate(row.getString("VALIDSTATE"));
		AreaworkerData.setLasttxnid(TransactionId.MODIFY);
		return AreaworkerData;
	}
	
	//AreaworkerData Delete
	private CtAreaworkerData getDeleteData(IDataRow row, ISQLUpsertBatch batch)
			throws InValidDataException, DatabaseException, MESException, SystemException {
		CtAreaworkerData AreaworkerData = new CtAreaworkerData();
		CtAreaworkerKey AreaworkerKey = AreaworkerData.key();
		
		AreaworkerKey.setAreaid(row.getString("AREAID"));
		AreaworkerKey.setUserid(row.getString("USERID"));
		
		AreaworkerData = AreaworkerData.selectOne();
		
		if (AreaworkerData == null) {
			throw new InValidDataException("InValidData003",String.format("AREAID = %s,WORKERNAME = %s"
					,row.getString("AREAID"),row.getString("USERID")));
		}

		AreaworkerData.setLasttxnid(TransactionId.DELETE);

		return AreaworkerData;
	}

}
