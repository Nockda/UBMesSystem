package kr.co.micube.mes.standard.rule;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.CtSubprocessworkerData;
import kr.co.micube.common.mes.so.CtSubprocessworkerKey;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;



public class SaveProcessWorker extends DatasetRule {
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
	private CtSubprocessworkerData getInsertData(IDataRow row, ISQLUpsertBatch batch)
			throws InValidDataException, DatabaseException, MESException, SystemException {
		CtSubprocessworkerData ProcessworkerData = new CtSubprocessworkerData();
		CtSubprocessworkerKey ProcessworkerKey = ProcessworkerData.key();
		ProcessworkerKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		ProcessworkerKey.setSubprocesssegmentid(row.getString("SUBPROCESSSEGMENTID"));
		ProcessworkerKey.setUserid(row.getString("USERID"));
		ProcessworkerData = ProcessworkerData.selectOne();
		
		if (ProcessworkerData != null) {
			throw new InValidDataException("InValidData002",String.format("PROCESSSEGMENTID = %s, SUBPROCESSSEGMENTID = %S, WORKERNAME = %s"
					,row.getString("PROCESSSEGMENTID"), row.getString("SUBPROCESSSEGMENTID") ,row.getString("USERID")));
		}
		
		ProcessworkerData = new CtSubprocessworkerData();
		ProcessworkerKey = ProcessworkerData.key();
		ProcessworkerKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		ProcessworkerKey.setSubprocesssegmentid(row.getString("SUBPROCESSSEGMENTID"));
		ProcessworkerKey.setUserid(row.getString("USERID"));
		ProcessworkerData.setValidstate(row.getString("VALIDSTATE"));

		
		ProcessworkerData.setLasttxnid(TransactionId.CREATE);
		return ProcessworkerData;
	}
	
	//Areaworker Update
	private CtSubprocessworkerData getUpdateData(IDataRow row, ISQLUpsertBatch batch)
			throws InValidDataException, DatabaseException, MESException, SystemException {
		CtSubprocessworkerData ProcessworkerData = new CtSubprocessworkerData();
		CtSubprocessworkerKey ProcessworkerKey = ProcessworkerData.key();
		ProcessworkerKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		ProcessworkerKey.setSubprocesssegmentid(row.getString("SUBPROCESSSEGMENTID"));
		ProcessworkerKey.setUserid(row.getString("USERID"));
		ProcessworkerData = ProcessworkerData.selectOne();;
		
		if (ProcessworkerData == null) {
			throw new InValidDataException("InValidData001",String.format("PROCESSSEGMENTID = %s, SUBPROCESSSEGMENTID = %S, WORKERNAME = %s"
					,row.getString("PROCESSSEGMENTID"), row.getString("SUBPROCESSSEGMENTID") ,row.getString("USERID")));
		}
		ProcessworkerData.setValidstate(row.getString("VALIDSTATE"));
		ProcessworkerData.setLasttxnid(TransactionId.MODIFY);
		return ProcessworkerData;
	}
	
	//AreaworkerData Delete
	private CtSubprocessworkerData getDeleteData(IDataRow row, ISQLUpsertBatch batch)
			throws InValidDataException, DatabaseException, MESException, SystemException {
		
		CtSubprocessworkerData ProcessworkerData = new CtSubprocessworkerData();
		CtSubprocessworkerKey ProcessworkerKey = ProcessworkerData.key();
		ProcessworkerKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		ProcessworkerKey.setSubprocesssegmentid(row.getString("SUBPROCESSSEGMENTID"));
		ProcessworkerKey.setUserid(row.getString("USERID"));
		ProcessworkerData = ProcessworkerData.selectOne();;
		
		if (ProcessworkerData == null) {
			throw new InValidDataException("InValidData003",String.format("PROCESSSEGMENTID = %s, SUBPROCESSSEGMENTID = %S, WORKERNAME = %s"
					,row.getString("PROCESSSEGMENTID"), row.getString("SUBPROCESSSEGMENTID") ,row.getString("USERID")));
		}
		

		ProcessworkerData.setLasttxnid(TransactionId.DELETE);

		return ProcessworkerData;
	}

}
