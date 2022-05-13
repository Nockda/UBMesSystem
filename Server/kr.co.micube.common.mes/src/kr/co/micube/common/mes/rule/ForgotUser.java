package kr.co.micube.common.mes.rule;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.mes.UserData;
import kr.co.micube.tool.so.mes.UserKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class ForgotUser extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		
		if (dt.size() > 0)
		{
			row = dt.getFirstRow();
			
			UserData user = new UserData();
			UserKey userKey = user.key();
			userKey.setUserid(row.getString("USERID"));
			
			user = user.selectOne();
			
			user.setValidstate(row.getString("VALIDSTATE"));
			user.extendedColumn("USERSTATE", row.getString("USERSTATE"));
			
			user.setLasttxnid(TransactionId.MODIFY);
			
			batch.add(user, SQLUpsertType.UPDATE);
		}
		
		batch.execute();
	}
}
