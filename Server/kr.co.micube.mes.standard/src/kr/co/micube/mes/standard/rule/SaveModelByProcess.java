package kr.co.micube.mes.standard.rule;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.CtProcesssegmentmodelData;
import kr.co.micube.common.mes.so.CtProcesssegmentmodelKey;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;



public class SaveModelByProcess extends DatasetRule {
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
	private CtProcesssegmentmodelData getInsertData(IDataRow row, ISQLUpsertBatch batch)
			throws InValidDataException, DatabaseException, MESException, SystemException {
		CtProcesssegmentmodelData ProcesssegmentmodelData = new CtProcesssegmentmodelData();
		CtProcesssegmentmodelKey ProcesssegmentmodelKey = ProcesssegmentmodelData.key();
		ProcesssegmentmodelKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		ProcesssegmentmodelKey.setProcesssegmentversion(row.getString("PROCESSSEGMENTVERSION"));
		ProcesssegmentmodelKey.setModelid(row.getString("MODELID"));
		ProcesssegmentmodelData = ProcesssegmentmodelData.selectOne();
		
		if (ProcesssegmentmodelData != null) {
			throw new InValidDataException("InValidData002",String.format("PROCESSSEGMENTID = %s, PROCESSSEGMENTVERSION = %S, MODELID = %s"
					,row.getString("PROCESSSEGMENTID"), row.getString("PROCESSSEGMENTVERSION") ,row.getString("MODELID")));
		}
		
		ProcesssegmentmodelData = new CtProcesssegmentmodelData();
		ProcesssegmentmodelKey = ProcesssegmentmodelData.key();
		ProcesssegmentmodelKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		ProcesssegmentmodelKey.setProcesssegmentversion(row.getString("PROCESSSEGMENTVERSION"));
		ProcesssegmentmodelKey.setModelid(row.getString("MODELID"));
		ProcesssegmentmodelData.setEnterpriseid(row.getString("ENTERPRISEID"));
		ProcesssegmentmodelData.setPlantid(row.getString("PLANTID"));
		ProcesssegmentmodelData.setValidstate(row.getString("VALIDSTATE"));

		
		ProcesssegmentmodelData.setLasttxnid(TransactionId.CREATE);
		return ProcesssegmentmodelData;
	}
	
	//Areaworker Update
	private CtProcesssegmentmodelData getUpdateData(IDataRow row, ISQLUpsertBatch batch)
			throws InValidDataException, DatabaseException, MESException, SystemException {
		CtProcesssegmentmodelData ProcesssegmentmodelData = new CtProcesssegmentmodelData();
		CtProcesssegmentmodelKey ProcesssegmentmodelKey = ProcesssegmentmodelData.key();
		ProcesssegmentmodelKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		ProcesssegmentmodelKey.setProcesssegmentversion(row.getString("PROCESSSEGMENTVERSION"));
		ProcesssegmentmodelKey.setModelid(row.getString("MODELID"));
		ProcesssegmentmodelData = ProcesssegmentmodelData.selectOne();
		
		if (ProcesssegmentmodelData == null) {
			throw new InValidDataException("InValidData001",String.format("PROCESSSEGMENTID = %s, PROCESSSEGMENTVERSION = %S, MODELID = %s"
					,row.getString("PROCESSSEGMENTID"), row.getString("PROCESSSEGMENTVERSION") ,row.getString("MODELID")));
		}
		ProcesssegmentmodelData.setEnterpriseid(row.getString("ENTERPRISEID"));
		ProcesssegmentmodelData.setPlantid(row.getString("PLANTID"));
		ProcesssegmentmodelData.setValidstate(row.getString("VALIDSTATE"));
		ProcesssegmentmodelData.setLasttxnid(TransactionId.MODIFY);
		return ProcesssegmentmodelData;
	}
	
	//AreaworkerData Delete
	private CtProcesssegmentmodelData getDeleteData(IDataRow row, ISQLUpsertBatch batch)
			throws InValidDataException, DatabaseException, MESException, SystemException {
		
		CtProcesssegmentmodelData ProcesssegmentmodelData = new CtProcesssegmentmodelData();
		CtProcesssegmentmodelKey ProcesssegmentmodelKey = ProcesssegmentmodelData.key();
		ProcesssegmentmodelKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		ProcesssegmentmodelKey.setProcesssegmentversion(row.getString("PROCESSSEGMENTVERSION"));
		ProcesssegmentmodelKey.setModelid(row.getString("MODELID"));
		ProcesssegmentmodelData = ProcesssegmentmodelData.selectOne();
		
		if (ProcesssegmentmodelData == null) {
			throw new InValidDataException("InValidData003",String.format("PROCESSSEGMENTID = %s, PROCESSSEGMENTVERSION = %S, MODELID = %s"
					,row.getString("PROCESSSEGMENTID"), row.getString("PROCESSSEGMENTVERSION") ,row.getString("MODELID")));
		}
		

		ProcesssegmentmodelData.setLasttxnid(TransactionId.DELETE);

		return ProcesssegmentmodelData;
	}

}
