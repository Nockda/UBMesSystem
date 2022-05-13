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
import kr.co.micube.tool.so.mes.MessageClassData;
import kr.co.micube.tool.so.mes.MessageClassKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveMessageClass extends DatasetRule {
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
	
	// Insert Message Class
	private MessageClassData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		MessageClassData messageClass = new MessageClassData();
		MessageClassKey messageClassKey = messageClass.key();
		messageClassKey.setMessageclassid(row.getString("MESSAGECLASSID"));
		
		messageClass = messageClass.selectOne();
		
		if (messageClass != null)
		{
			throw new InValidDataException("InValidData002", String.format("MessageClassId = %s", row.getString("MESSAGECLASSID")));
		}
		
		
		String dictionaryId = Generate.createID();
		
		MessageClassData newMessageClass = new MessageClassData();
		MessageClassKey newMessageClassKey = newMessageClass.key();
		newMessageClassKey.setMessageclassid(row.getString("MESSAGECLASSID"));
		
		newMessageClass.setMessageclassname(row.getString("MESSAGECLASSNAME$$KO-KR"));
		newMessageClass.setDescription(row.getString("DESCRIPTION"));
		newMessageClass.setDictionaryid(dictionaryId);
		newMessageClass.setValidstate(row.getString("VALIDSTATE"));
		
		newMessageClass.setLasttxnid(TransactionId.CREATE);
		
		// Message Class Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(MessageClassData.Messageclassname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(MessageClassData.Messageclassname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		
		return newMessageClass;
	}
	
	// Update Message Class
	private MessageClassData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		MessageClassData messageClass = new MessageClassData();
		MessageClassKey messageClassKey = messageClass.key();
		messageClassKey.setMessageclassid(row.getString("MESSAGECLASSID"));
		
		messageClass = messageClass.selectOne();
		
		if (messageClass == null)
		{
			throw new InValidDataException("InValidData001", String.format("MessageClassId = %s", row.getString("MESSAGECLASSID")));
		}
		
		
		String dictionaryId = messageClass.getDictionaryid();
		
		if (StringUtils.isNullOrEmpty(dictionaryId))
		{
			dictionaryId = Generate.createID();
			messageClass.setDictionaryid(dictionaryId);
		}
		
		messageClass.setMessageclassname(row.getString("MESSAGECLASSNAME$$KO-KR"));
		messageClass.setDescription(row.getString("DESCRIPTION"));
		messageClass.setValidstate(row.getString("VALIDSTATE"));
		
		messageClass.setLasttxnid(TransactionId.MODIFY);
		
		// Message Class Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(MessageClassData.Messageclassname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(MessageClassData.Messageclassname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		
		return messageClass;
	}
	
	// Delete Message Class
	private MessageClassData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		MessageClassData messageClass = new MessageClassData();
		MessageClassKey messageClassKey = messageClass.key();
		messageClassKey.setMessageclassid(row.getString("MESSAGECLASSID"));
		
		messageClass = messageClass.selectOne();
		
		if (messageClass == null)
		{
			throw new InValidDataException("InValidData003", String.format("MessageClassId = %s", row.getString("MESSAGECLASSID")));
		}
		
		
		String dictionaryId = messageClass.getDictionaryid();
		
		// Delete Message Class Name Dictionary
		CommonUtils.deleteDictionaryData(batch, dictionaryId);
		
		
		return messageClass;
	}
}
