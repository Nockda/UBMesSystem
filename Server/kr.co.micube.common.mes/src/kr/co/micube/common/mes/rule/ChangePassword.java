package kr.co.micube.common.mes.rule;

import kr.co.micube.tool.management.user.LogonManagement;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

public class ChangePassword extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		if (dt.size() > 0)
		{
			IDataRow row = dt.getFirstRow();
			
			LogonManagement lm = new LogonManagement();
			
			String userId = row.getString("USERID");
			String oldPassword = row.getString("CURRENTPASSWORD");
			String newPassword = row.getString("NEWPASSWORD");
			
			lm.changePassword(userId, oldPassword, newPassword);
		}
	}
}
