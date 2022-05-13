package kr.co.micube.mes.com.rule;

import java.util.List;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.util.LanguageUtils;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.mes.DictionaryData;
import kr.co.micube.tool.so.mes.DictionaryKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveDictionary extends DatasetRule {
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
					getInsertData(row, batch);
					break;
				case UpsertState.UPDATE:
					getUpdateData(row, batch);
					break;
				case UpsertState.DELETE:
					getDeleteData(row, batch);
					break;
			}
		}
		
		batch.execute();
	}
	
	// Insert Dictionary
	private void getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		List<String> languageType = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageType) {
			if (!row.containsKey(DictionaryData.Dictionaryname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			DictionaryData dictionary = new DictionaryData();
			DictionaryKey dictionaryKey = dictionary.key();
			dictionaryKey.setDictionaryid(row.getString("DICTIONARYID").toUpperCase());
			dictionaryKey.setLanguagetype(lang);
			
			dictionary = dictionary.selectOne();
			
			if (dictionary != null)
			{
				throw new InValidDataException("InValidData002", String.format("DictionaryId = %s, LanguageType = %s", row.getString("DICTIONARYID").toUpperCase(), row.getString("LANGUAGETYPE")));
			}
			
			
			DictionaryData newDictionary = new DictionaryData();
			DictionaryKey newDictionaryKey = newDictionary.key();
			newDictionaryKey.setDictionaryid(row.getString("DICTIONARYID").toUpperCase());
			newDictionaryKey.setLanguagetype(lang);
			
			newDictionary.setDictionaryname(row.getString(DictionaryData.Dictionaryname.toUpperCase() + "$$" + lang.toUpperCase()));
			newDictionary.setDescription(row.getString("DESCRIPTION"));
			newDictionary.setDictionaryclassid(row.getString("DICTIONARYCLASSID"));
			newDictionary.setValidstate(row.getString("VALIDSTATE"));
			
			newDictionary.setLasttxnid(TransactionId.CREATE);
			
			batch.add(newDictionary, SQLUpsertType.INSERT);
		}
	}
	
	// Update Dictionary
	private void getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		List<String> languageType = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageType) {
			if (!row.containsKey(DictionaryData.Dictionaryname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			DictionaryData dictionary = new DictionaryData();
			DictionaryKey dictionaryKey = dictionary.key();
			dictionaryKey.setDictionaryid(row.getString("DICTIONARYID").toUpperCase());
			dictionaryKey.setLanguagetype(lang);
			
			dictionary = dictionary.selectOne();
			
			if (dictionary == null)
			{
				throw new InValidDataException("InValidData001", String.format("DictionaryId = %s, LanguageType = %s", row.getString("DICTIONARYID").toUpperCase(), row.getString("LANGUAGETYPE")));
			}
			
			
			dictionary.setDictionaryname(row.getString(DictionaryData.Dictionaryname.toUpperCase() + "$$" + lang.toUpperCase()));
			dictionary.setDescription(row.getString("DESCRIPTION"));
			dictionary.setDictionaryclassid(row.getString("DICTIONARYCLASSID"));
			dictionary.setValidstate(row.getString("VALIDSTATE"));
			
			dictionary.setLasttxnid(TransactionId.MODIFY);
			
			batch.add(dictionary, SQLUpsertType.UPDATE);
		}
	}
	
	// Delete Dictionary
	private void getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		List<String> languageType = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageType) {
			if (!row.containsKey(DictionaryData.Dictionaryname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			DictionaryData dictionary = new DictionaryData();
			DictionaryKey dictionaryKey = dictionary.key();
			dictionaryKey.setDictionaryid(row.getString("DICTIONARYID").toUpperCase());
			dictionaryKey.setLanguagetype(lang);
			
			dictionary = dictionary.selectOne();
			
			if (dictionary == null)
			{
				throw new InValidDataException("InValidData003", String.format("DictionaryId = %s, LanguageType = %s", row.getString("DICTIONARYID").toUpperCase(), row.getString("LANGUAGETYPE")));
			}
			
			
			dictionary.setLasttxnid(TransactionId.DELETE);
			
			batch.add(dictionary, SQLUpsertType.DELETE);
		}
	}
}