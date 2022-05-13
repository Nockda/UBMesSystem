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
import kr.co.micube.tool.so.mes.CodeData;
import kr.co.micube.tool.so.mes.CodeKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveCode extends DatasetRule {
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
	
	// Insert Code
	private CodeData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		CodeData code = new CodeData();
		CodeKey codeKey = code.key();
		codeKey.setCodeclassid(row.getString("CODECLASSID"));
		codeKey.setCodeid(row.getString("CODEID"));
		
		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeClassId = %s, CodeId = %s", row.getString("CODECLASSID"), row.getString("CODEID")));
		}
		
		String dictionaryId = Generate.createID();
		
		CodeData newCode = new CodeData();
		CodeKey newCodeKey = newCode.key();
		newCodeKey.setCodeclassid(row.getString("CODECLASSID"));
		newCodeKey.setCodeid(row.getString("CODEID"));
		
		newCode.setCodename(row.getString("CODENAME$$KO-KR"));
		newCode.setDescription(row.getString("DESCRIPTION"));
		newCode.setParentcodeid(row.getString("PARENTCODEID"));
		newCode.setDisplaysequence(row.getDouble("DISPLAYSEQUENCE"));
		newCode.setDictionaryid(dictionaryId);
		newCode.setValidstate(row.getString("VALIDSTATE"));
		
		newCode.setLasttxnid(TransactionId.CREATE);
		
		// Code Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(CodeData.Codename.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(CodeData.Codename.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		
		return newCode;
	}
	
	// Update Code
	private CodeData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		CodeData code = new CodeData();
		CodeKey codeKey = code.key();
		codeKey.setCodeclassid(row.getString("CODECLASSID"));
		codeKey.setCodeid(row.getString("CODEID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeClassId = %s, CodeId = %s", row.getString("CODECLASSID"), row.getString("CODEID")));
		}
		
		
		String dictionaryId = code.getDictionaryid();
		
		if (StringUtils.isNullOrEmpty(dictionaryId))
		{
			dictionaryId = Generate.createID();
			code.setDictionaryid(dictionaryId);
		}
		
		code.setCodename(row.getString("CODENAME$$KO-KR"));
		code.setDescription(row.getString("DESCRIPTION"));
		code.setParentcodeid(row.getString("PARENTCODEID"));
		code.setDisplaysequence(row.getDouble("DISPLAYSEQUENCE"));
		code.setValidstate(row.getString("VALIDSTATE"));
		
		code.setLasttxnid(TransactionId.MODIFY);
		
		// Code Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(CodeData.Codename.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(CodeData.Codename.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		
		return code;
	}
	
	// Delete Code
	private CodeData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		CodeData code = new CodeData();
		CodeKey codeKey = code.key();
		codeKey.setCodeclassid(row.getString("CODECLASSID"));
		codeKey.setCodeid(row.getString("CODEID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData003", String.format("CodeClassId = %s, CodeId = %s", row.getString("CODECLASSID"), row.getString("CODEID")));
		}
		
		
		String dictionaryId = code.getDictionaryid();
		
		code.setLasttxnid(TransactionId.DELETE);
		
		// Delete Code Name Dictionary
		CommonUtils.deleteDictionaryData(batch, dictionaryId);
		
		
		return code;
	}
}