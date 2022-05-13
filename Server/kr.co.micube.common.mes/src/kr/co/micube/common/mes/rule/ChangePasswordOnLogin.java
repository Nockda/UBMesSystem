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

public class ChangePasswordOnLogin extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		if (dt.size() > 0)
		{
			IDataRow row = dt.getFirstRow();
			
			UserData user = new UserData();
			UserKey userKey = user.key();
			userKey.setUserid(row.getString("USERID"));
			
			user = user.selectOne();
			
			if (user == null)
			{
				throw new InValidDataException("InValidData001", String.format("User Id = %s", row.getString("USERID")));
			}
			
			
			String oldPassword = Cipher.encrypt(row.getString("CURRENTPASSWORD") + user.getSeed(), CipherMode.SHA256);
			
			if (!user.getPassword().equals(oldPassword))
			{
				throw new InValidDataException("CURRENTPASSWORDNOTMATCHING");
			}
			
			String newPassword = Cipher.encrypt(row.getString("NEWPASSWORD") + user.getSeed(), CipherMode.SHA256);
			
			user.setPassword(newPassword);
			user.setLasttxnid(TransactionId.MODIFY);
			user.extendedColumn("USERSTATE", "Normal");
			
			batch.add(user, SQLUpsertType.UPDATE);
		}
		
		batch.execute();
	}
}
