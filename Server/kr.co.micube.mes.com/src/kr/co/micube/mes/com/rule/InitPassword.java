package kr.co.micube.mes.com.rule;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.util.EmailSendData;
import kr.co.micube.common.mes.util.EmailUtils;
import kr.co.micube.common.util.MultiLanguage;
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

public class InitPassword extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		Map<String, Object> parameters = new HashMap<>();
		String languageType = "";
		
		IDataRow row = null;
		
		for (int i = 0, len = dt.size(); i < len; i++) {
			ISQLUpsertBatch batch = new SQLUpsertBatch();
			
			
			row = dt.getRow(i);
			
			UserData user = new UserData();
			UserKey userKey = user.key();
			userKey.setUserid(row.getString("USERID"));
			
			user = user.selectOne();
			
			String password = Cipher.encrypt(row.getString("PASSWORD"), CipherMode.SHA256);
			String encryptPassword = Cipher.encrypt(password + row.getString("SEED"), CipherMode.SHA256);
			
			user.setPassword(encryptPassword);
			user.setValidstate(row.getString("VALIDSTATE"));
			
			user.setLasttxnid(TransactionId.MODIFY);
			
			batch.add(user, SQLUpsertType.UPDATE);
			
			batch.execute();
			
			
			if (!user.getEmailaddress().isEmpty())
			{
				parameters.clear();
				
				EmailSendData email = new EmailSendData();
				
				languageType = user.getLanguagetype();
				
				List<String> recepients = new ArrayList<String>();
				recepients.add(user.getEmailaddress());
				
				parameters.put("INITPASSWORDNOTICE", MultiLanguage.getMessage("INITPASSWORDNOTICE", languageType));
				parameters.put("INITPASSWORDCONTENT", MultiLanguage.getMessage("INITPASSWORDCONTENT", languageType, row.getString("PASSWORD")));
				
				email.setUser(row.getString("USERID"));
				email.setSubject(MultiLanguage.getMessage("INITPASSWORDNOTICE", languageType));
				email.setRecipients(recepients);
				email.setContentId("InitPassword");
				email.setParameters(parameters);
				
				
				EmailUtils.send(email);
			}
		}
	}
}