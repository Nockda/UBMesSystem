package kr.co.micube.mes.com.rule;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.util.EmailSendData;
import kr.co.micube.common.mes.util.EmailUtils;
import kr.co.micube.common.util.MultiLanguage;
import kr.co.micube.common.util.PasswordUtils;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.security.Cipher;
import kr.co.micube.core.security.CipherMode;
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

public class SaveUser extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		String state = null;
		
		List<IDataRow> insertUserList = new ArrayList<>();
		
		for (int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);
			state = row.getString("_STATE_");
		
			switch (state) {
				case UpsertState.INSERT:
					batch.add(getInsertData(row), SQLUpsertType.INSERT);
					
					insertUserList.add(row);
					break;
				case UpsertState.UPDATE:
					batch.add(getUpdateData(row), SQLUpsertType.UPDATE);
					break;
				case UpsertState.DELETE:
					batch.add(getDeleteData(row), SQLUpsertType.DELETE);
					break;
			}
		}
		
		sendInitialPasswordEmail(insertUserList);
		
		batch.execute();
	}
	
	// Insert User
	private UserData getInsertData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
 
		UserData user = new UserData();
		UserKey userKey = user.key();
		userKey.setUserid(row.getString("USERID"));
		
		user = user.selectOne();
		
		if (user != null)
		{
			throw new InValidDataException("InValidData002", String.format("UserId = %s", row.getString("USERID")));
		}
		
		
		String seed = PasswordUtils.createSeed();
		String password = Cipher.encrypt(row.getString("PASSWORD"), CipherMode.SHA256);
		String encryptPassword = Cipher.encrypt(password + seed, CipherMode.SHA256);
		
		UserData newUser = new UserData();
		UserKey newUserKey = newUser.key();
		newUserKey.setUserid(row.getString("USERID"));
		
		newUser.setUsername(row.getString("USERNAME"));
		newUser.setDescription(row.getString("DESCRIPTION"));
		newUser.setPassword(encryptPassword);
		newUser.setNickname(row.getString("NICKNAME"));
		newUser.setDepartment(row.getString("DEPARTMENT"));
		newUser.setPosition(row.getString("POSITION"));
		newUser.setDuty(row.getString("DUTY"));
		newUser.setEmailaddress(row.getString("EMAILADDRESS"));
		newUser.setHomeaddress(row.getString("HOMEADDRESS"));
		newUser.setCellphonenumber(row.getString("CELLPHONENUMBER"));
		newUser.setLanguagetype(row.getString("DEFAULTLANGUAGETYPE"));
		newUser.setSeed(seed);
		newUser.setValidstate(row.getString("VALIDSTATE"));
		newUser.extendedColumn("USERSTATE", "Create");
		
		newUser.setLasttxnid(TransactionId.CREATE);
		
		
		return newUser;
	}
	
	// Update User
	private UserData getUpdateData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UserData user = new UserData();
		UserKey userKey = user.key();
		userKey.setUserid(row.getString("USERID"));
		
		user = user.selectOne();
		
		if (user == null)
		{
			throw new InValidDataException("InValidData001", String.format("UserId = %s", row.getString("USERID")));
		}
		
		
		user.setUsername(row.getString("USERNAME"));
		user.setDescription(row.getString("DESCRIPTION"));
		user.setNickname(row.getString("NICKNAME"));
		user.setDepartment(row.getString("DEPARTMENT"));
		user.setPosition(row.getString("POSITION"));
		user.setDuty(row.getString("DUTY"));
		user.setEmailaddress(row.getString("EMAILADDRESS"));
		user.setHomeaddress(row.getString("HOMEADDRESS"));
		user.setCellphonenumber(row.getString("CELLPHONENUMBER"));
		user.setLanguagetype(row.getString("DEFAULTLANGUAGETYPE"));
		user.setValidstate(row.getString("VALIDSTATE"));
		
		user.setLasttxnid(TransactionId.MODIFY);
		
		
		return user;
	}
	
	// Delete User
	private UserData getDeleteData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UserData user = new UserData();
		UserKey userKey = user.key();
		userKey.setUserid(row.getString("USERID"));
		
		user = user.selectOne();
		
		if (user == null)
		{
			throw new InValidDataException("InValidData003", String.format("UserId = %s", row.getString("USERID")));
		}
		
		
		user.setLasttxnid(TransactionId.DELETE);
		
		
		return user;
	}
	
	// Send E-mail Initial Password
	private void sendInitialPasswordEmail(List<IDataRow> insertUserList) throws InValidDataException, MESException, SystemException
	{
		Map<String, Object> parameters = new HashMap<>();
		
		for (int i = 0, len = insertUserList.size(); i < len; i++) {
			IDataRow row = insertUserList.get(i);
			
			if (!row.getString("EMAILADDRESS").isEmpty())
			{
				parameters.clear();
				
				EmailSendData email = new EmailSendData();
				
				String languageType = row.getString("DEFAULTLANGUAGETYPE");
				
				List<String> recepients = new ArrayList<String>();
				recepients.add(row.getString("EMAILADDRESS"));
				
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
