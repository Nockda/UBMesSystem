package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.mes.UserClassUserData;
import kr.co.micube.tool.so.mes.UserClassUserKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveUserClassUser extends DatasetRule {
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
					batch.add(getInsertData(row), SQLUpsertType.INSERT);
					break;
				case UpsertState.UPDATE:
					break;
				case UpsertState.DELETE:
					batch.add(getDeleteData(row), SQLUpsertType.DELETE);
					break;
			}
		}
		
		batch.execute();
	}
	
	// Insert User Class User
	private UserClassUserData getInsertData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UserClassUserData userClassUser = new UserClassUserData();
		UserClassUserKey userClassUserKey = userClassUser.key();
		userClassUserKey.setUserclassid(row.getString("USERCLASSID"));
		userClassUserKey.setUserid(row.getString("USERID"));
		
		userClassUser = userClassUser.selectOne();
		
		if (userClassUser != null)
		{
			throw new InValidDataException("InValidData002", String.format("UserClassId = %s, UserId = %s, ValidState = Valid", row.getString("USERCLASSID"), row.getString("USERID")));
		}
		
		
		UserClassUserData newUserClassUser = new UserClassUserData();
		UserClassUserKey newUserClassUserKey = newUserClassUser.key();
		newUserClassUserKey.setUserclassid(row.getString("USERCLASSID"));
		newUserClassUserKey.setUserid(row.getString("USERID"));
		
		newUserClassUser.setValidstate("Valid");
		
		newUserClassUser.setLasttxnid(TransactionId.CREATE);
		
		
		return newUserClassUser;
	}
	
	// Delete User Class User
	private UserClassUserData getDeleteData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UserClassUserData userClassUser = new UserClassUserData();
		UserClassUserKey userClassUserKey = userClassUser.key();
		userClassUserKey.setUserclassid(row.getString("USERCLASSID"));
		userClassUserKey.setUserid(row.getString("USERID"));
		
		userClassUser = userClassUser.selectOne();
		
		if (userClassUser == null)
		{
			throw new InValidDataException("InValidData003", String.format("UserClassId = %s, UserId = %s, ValidState = Valid", row.getString("USERCLASSID"), row.getString("USERID")));
		}
		

		userClassUser.setLasttxnid(TransactionId.DELETE);
		
		
		return userClassUser;
	}
}