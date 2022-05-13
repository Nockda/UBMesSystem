package kr.co.micube.mes.standard.rule;


import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.CtModelstandardinfoData;
import kr.co.micube.common.mes.so.CtModelstandardinfoKey;
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

public class SaveProcessStandard extends DatasetRule{
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
		
		CtModelstandardinfoData code = new CtModelstandardinfoData();
		CtModelstandardinfoKey codeKey = code.key();
		
		codeKey.setModelid(row.getString("MODELID"));
		codeKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		
		code = code.selectOne();
		
		if(code != null) {
			throw new InValidDataException("InValidData002", String.format("ProcesssegmentId = %s, ModelId = %s", row.getString("PROCESSSEGMENTID"), row.getString("MODELID")));
		}
		
		CtModelstandardinfoData newCode = new CtModelstandardinfoData();
		CtModelstandardinfoKey newCodeKey = newCode.key();
		
		newCodeKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		newCodeKey.setModelid(row.getString("MODELID"));
		newCode.setStandard1(row.getString("STANDARD1"));
		newCode.setStandard2(row.getString("STANDARD2"));
		newCode.setStandard3(row.getString("STANDARD3"));
		newCode.setDescription(row.getString("DESCRIPTION"));
		newCode.setValidstate(row.getString("VALIDSTATE"));
		newCode.setLasttxnid(TransactionId.CREATE);
		return newCode;
	}

	private ISQLData getUpdateData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		
		CtModelstandardinfoData code = new CtModelstandardinfoData();
		CtModelstandardinfoKey codeKey = code.key();
		
		codeKey.setModelid(row.getString("MODELID"));
		codeKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		
		code = code.selectOne();
		
		if(code == null) {
			throw new InValidDataException("InValidData001", String.format("ProcesssegmentId = %s, ModelId = %s", row.getString("PROCESSSEGMENTID"), row.getString("MODELID")));
		}
		
		code.setStandard1(row.getString("STANDARD1"));
		code.setStandard2(row.getString("STANDARD2"));
		code.setStandard3(row.getString("STANDARD3"));
		code.setDescription(row.getString("DESCRIPTION"));
		code.setValidstate(row.getString("VALIDSTATE"));
		code.setLasttxnid(TransactionId.MODIFY);
		return code;
	}

	private ISQLData getDeleteData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		
		CtModelstandardinfoData code = new CtModelstandardinfoData();
		CtModelstandardinfoKey codeKey = code.key();
		
		codeKey.setModelid(row.getString("MODELID"));
		codeKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		
		code = code.selectOne();
		
		if(code == null) {
			throw new InValidDataException("InValidData003", String.format("ProcesssegmentId = %s, ModelId = %s", row.getString("PROCESSSEGMENTID"), row.getString("MODELID")));
		}
		code.setLasttxnid(TransactionId.DELETE);
		
		
		return code;
	}

}
