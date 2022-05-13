package kr.co.micube.common.mes.rule;

import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.management.user.LogonManagement;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.mes.UserData;

public class LoginForDotnet extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		LogonManagement lm = new LogonManagement();
		
		
		IMessage msg  = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);
		IData trans = jmsg.get(MessageFormat.Transaction);

		String uiid = trans.getString("uiid");
		if (StringUtils.trimToNull(uiid).isEmpty())
			uiid = "MES";
		
		UserData user = lm.login(
				uiid,
				body.getString("id"),
				body.getString("password")
		);
		
		IDataSet ds = this.getResponseDataset();
		IDataTable dt = ds.addTable("DATA");
		dt.addRow(user.toMap());
	}
}