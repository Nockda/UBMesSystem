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
import kr.co.micube.tool.so.mes.DictionaryClassData;
import kr.co.micube.tool.so.mes.DictionaryClassKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveDictionaryClass extends DatasetRule {
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
	
	// Insert Dictionary Class
	private DictionaryClassData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		DictionaryClassData dictionaryClass = new DictionaryClassData();
		DictionaryClassKey dictionaryClassKey = dictionaryClass.key();
		dictionaryClassKey.setDictionaryclassid(row.getString("DICTIONARYCLASSID"));
		
		dictionaryClass = dictionaryClass.selectOne();
		
		if (dictionaryClass != null)
		{
			throw new InValidDataException("InValidData002", String.format("DictionaryClassId = %s", row.getString("DICTIONARYCLASSID")));
		}
		
		
		String dictionaryId = Generate.createID();
		
		DictionaryClassData newDictionaryClass = new DictionaryClassData();
		DictionaryClassKey newDictionaryClassKey = newDictionaryClass.key();
		newDictionaryClassKey.setDictionaryclassid(row.getString("DICTIONARYCLASSID"));
		
		newDictionaryClass.setDictionaryclassname(row.getString("DICTIONARYCLASSNAME$$KO-KR"));
		newDictionaryClass.setDescription(row.getString("DESCRIPTION"));
		newDictionaryClass.setDictionaryid(dictionaryId);
		newDictionaryClass.setValidstate(row.getString("VALIDSTATE"));
		
		newDictionaryClass.setLasttxnid(TransactionId.CREATE);
		
		// Dictionary Class Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(DictionaryClassData.Dictionaryclassname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(DictionaryClassData.Dictionaryclassname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		
		return newDictionaryClass;
	}
	
	// Update Dictionary Class
	private DictionaryClassData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		DictionaryClassData dictionaryClass = new DictionaryClassData();
		DictionaryClassKey dictionaryClassKey = dictionaryClass.key();
		dictionaryClassKey.setDictionaryclassid(row.getString("DICTIONARYCLASSID"));
		
		dictionaryClass = dictionaryClass.selectOne();
		
		if (dictionaryClass == null)
		{
			throw new InValidDataException("InValidData001", String.format("DictionaryClassId = %s", row.getString("DICTIONARYCLASSID")));
		}
		
		
		String dictionaryId = dictionaryClass.getDictionaryid();
		
		if (StringUtils.isNullOrEmpty(dictionaryId))
		{
			dictionaryId = Generate.createID();
			dictionaryClass.setDictionaryid(dictionaryId);
		}
		
		dictionaryClass.setDictionaryclassname(row.getString("DICTIONARYCLASSNAME$$KO-KR"));
		dictionaryClass.setDescription(row.getString("DESCRIPTION"));
		dictionaryClass.setValidstate(row.getString("VALIDSTATE"));
		
		dictionaryClass.setLasttxnid(TransactionId.MODIFY);
		
		// Dictionary Class Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(DictionaryClassData.Dictionaryclassname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(DictionaryClassData.Dictionaryclassname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		
		return dictionaryClass;
	}
	
	// Delete Dictionary Class
	private DictionaryClassData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		DictionaryClassData dictionaryClass = new DictionaryClassData();
		DictionaryClassKey dictionaryClassKey = dictionaryClass.key();
		dictionaryClassKey.setDictionaryclassid(row.getString("DICTIONARYCLASSID"));
		
		dictionaryClass = dictionaryClass.selectOne();
		
		if (dictionaryClass == null)
		{
			throw new InValidDataException("InValidData003", String.format("DictionaryClassId = %s", row.getString("DICTIONARYCLASSID")));
		}
		
		
		String dictionaryId = dictionaryClass.getDictionaryid();
		
		dictionaryClass.setLasttxnid(TransactionId.DELETE);
		
		// Delete Dictionary Class Name Dictionary
		CommonUtils.deleteDictionaryData(batch, dictionaryId);
		
		
		return dictionaryClass;
	}
}