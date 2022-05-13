package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.mes.UserData;
import kr.co.micube.tool.so.mes.UserKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class ApprovalUser extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		
		for (int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);
			
			batch.add(getApprovalData(row), SQLUpsertType.UPDATE);
		}
		
		batch.execute();
	}
	
	// Approval User
	private UserData getApprovalData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UserData user = new UserData();
		UserKey userKey = user.key();
		userKey.setUserid(row.getString("USERID"));
		
		user = user.selectOne();
		
		if (user == null)
		{
			throw new InValidDataException("InValidData001", String.format("UserId = %s", row.getString("USERID")));
		}
		
		
		user.setValidstate(row.getString("VALIDSTATE"));
		
		user.setLasttxnid(TransactionId.MODIFY);
		
		
		return user;
	}
}
