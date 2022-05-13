package kr.co.micube.common.mes.rule;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.core.security.Cipher;
import kr.co.micube.core.security.CipherMode;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.mes.UserData;
import kr.co.micube.tool.so.mes.UserKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class ResetPassword extends DatasetRule {
	
	private final static String NEW_PASSWORD = "1";
	
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		for(int i = 0; i < dt.size(); i++) {
			IDataRow row = dt.getRow(i);
			UserData user = new UserData();
			UserKey userKey = user.key();
			userKey.setUserid(row.getString("USERID"));
			user = user.selectOne();
			if (user == null)
			{
				throw new InValidDataException("InValidData001", String.format("User Id = %s", row.getString("USERID")));
			}
			String newPassword = Cipher.encrypt(Cipher.encrypt(NEW_PASSWORD, CipherMode.SHA256) + user.getSeed(), CipherMode.SHA256);
			user.setPassword(newPassword);
			user.setLasttxnid(TransactionId.MODIFY);
			user.extendedColumn("USERSTATE", "Create");
			batch.add(user, SQLUpsertType.UPDATE);
		}
		batch.execute();
	}
}
