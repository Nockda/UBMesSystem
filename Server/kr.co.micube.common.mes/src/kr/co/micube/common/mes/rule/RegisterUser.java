package kr.co.micube.common.mes.rule;

import java.util.Map;

import kr.co.micube.common.util.MessageUtils;
import kr.co.micube.tool.management.user.LogonManagement;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

public class RegisterUser extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		LogonManagement lm = new LogonManagement();
		Map<String, Object> result = lm.addUser(dt.getFirstRow()).toMap();
		
		MessageUtils.setResult(result);
	}
}
