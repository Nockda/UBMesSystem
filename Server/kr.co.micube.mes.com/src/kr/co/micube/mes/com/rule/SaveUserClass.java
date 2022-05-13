package kr.co.micube.mes.com.rule;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.util.CommonUtils;
import kr.co.micube.common.mes.util.LanguageUtils;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.mes.UserClassData;
import kr.co.micube.tool.so.mes.UserClassKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveUserClass extends DatasetRule {
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
					batch.add(getInsertData(row, batch), SQLUpsertType.INSERT);
					break;
				case UpsertState.UPDATE:
					batch.add(getUpdateData(row, batch), SQLUpsertType.UPDATE);
					break;
				case UpsertState.DELETE:
					batch.add(getDeleteData(row, batch), SQLUpsertType.DELETE);
					break;
			}
		}
		
		batch.execute();
	}
	
	// Insert User Class
	private UserClassData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UserClassData userClass = new UserClassData();
		UserClassKey userClassKey = userClass.key();
		userClassKey.setUserclassid(row.getString("USERCLASSID"));
		
		userClass = userClass.selectOne();
		
		if (userClass != null)
		{
			throw new InValidDataException("InValidData002", String.format("UserClassId = %s", row.getString("USERCLASSID")));
		}
		
		
		String dictionaryId = Generate.createID();
		
		UserClassData newUserClass = new UserClassData();
		UserClassKey newUserClassKey = newUserClass.key();
		newUserClassKey.setUserclassid(row.getString("USERCLASSID"));
		
		newUserClass.setUserclassname(row.getString("USERCLASSNAME$$KO-KR"));
		newUserClass.setDescription(row.getString("DESCRIPTION"));
		newUserClass.setDictionaryid(dictionaryId);
		newUserClass.setValidstate(row.getString("VALIDSTATE"));
		
		newUserClass.setLasttxnid(TransactionId.CREATE);
		
		// User Class Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(UserClassData.Userclassname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(UserClassData.Userclassname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		
		return newUserClass;
	}
	
	// Update User Class
	private UserClassData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UserClassData userClass = new UserClassData();
		UserClassKey userClassKey = userClass.key();
		userClassKey.setUserclassid(row.getString("USERCLASSID"));
		
		userClass = userClass.selectOne();
		
		if (userClass == null)
		{
			throw new InValidDataException("InValidData001", String.format("UserClassId = %s", row.getString("USERCLASSID")));
		}
		
		
		String dictionaryId = userClass.getDictionaryid();
		
		if (StringUtils.isNullOrEmpty(dictionaryId))
		{
			dictionaryId = Generate.createID();
			userClass.setDictionaryid(dictionaryId);
		}
		
		userClass.setUserclassname(row.getString("USERCLASSNAME$$KO-KR"));
		userClass.setDescription(row.getString("DESCRIPTION"));
		userClass.setValidstate(row.getString("VALIDSTATE"));

		userClass.setLasttxnid(TransactionId.MODIFY);
		
		// User Class Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(UserClassData.Userclassname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(UserClassData.Userclassname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		
		return userClass;
	}
	
	// Delete User Class
	private UserClassData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UserClassData userClass = new UserClassData();
		UserClassKey userClassKey = userClass.key();
		userClassKey.setUserclassid(row.getString("USERCLASSID"));
		
		userClass = userClass.selectOne();
		
		if (userClass == null)
		{
			throw new InValidDataException("InValidData003", String.format("UserClassId = %s", row.getString("USERCLASSID")));			
		}
		
		
		String dictionaryId = userClass.getDictionaryid();
		
		userClass.setLasttxnid(TransactionId.DELETE);
		
		// Delete User Class Name Dictionary
		CommonUtils.deleteDictionaryData(batch, dictionaryId);
		
		
		return userClass;
	}
}