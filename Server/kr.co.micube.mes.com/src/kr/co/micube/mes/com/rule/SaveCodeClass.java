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
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.mes.CodeClassData;
import kr.co.micube.tool.so.mes.CodeClassKey;
import kr.co.micube.tool.so.mes.CodeData;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 시스템 관리 > 코드 관리 > 코드그룹 정보
 * 설               명	: 코드그룹 정보 화면에서 변경된 데이터를 저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: 강호윤
 * 생      성      일	: 2019-04-01
 * 수   정   이   력	: 
 */
public class SaveCodeClass extends DatasetRule {
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
	
	// Insert Code Class
	private CodeClassData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		CodeClassData codeClass = new CodeClassData();
		CodeClassKey codeClassKey = codeClass.key();
		codeClassKey.setCodeclassid(row.getString("CODECLASSID"));
		
		codeClass = codeClass.selectOne();
		
		if (codeClass != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeClassId = %s", row.getString("CODECLASSID")));
		}
		
		
		String dictionaryId = Generate.createID();
		
		CodeClassData newCodeClass = new CodeClassData();
		CodeClassKey newCodeClassKey = newCodeClass.key();
		newCodeClassKey.setCodeclassid(row.getString("CODECLASSID"));
		
		newCodeClass.setCodeclassname(row.getString("CODECLASSNAME$$KO-KR"));
		newCodeClass.setDescription(row.getString("DESCRIPTION"));
		newCodeClass.setCodeclasstype(row.getString("CODECLASSTYPE"));
		newCodeClass.setParentcodeclassid(row.getString("PARENTCODECLASSID"));
		newCodeClass.setDictionaryid(dictionaryId);
		newCodeClass.setValidstate(row.getString("VALIDSTATE"));
		
		newCodeClass.setLasttxnid(TransactionId.CREATE);
		
		// Code Class Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(CodeClassData.Codeclassname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(CodeClassData.Codeclassname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		
		return newCodeClass;
	}
	
	// Update Code Class
	private CodeClassData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		CodeClassData codeClass = new CodeClassData();
		CodeClassKey codeClassKey = codeClass.key();
		codeClassKey.setCodeclassid(row.getString("CODECLASSID"));
		
		codeClass = codeClass.selectOne();
		
		if (codeClass == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeClassId = %s", row.getString("CODECLASSID")));
		}
		
		
		String dictionaryId = codeClass.getDictionaryid();
		
		if (StringUtils.isNullOrEmpty(dictionaryId))
		{
			dictionaryId = Generate.createID();
			codeClass.setDictionaryid(dictionaryId);
		}
		
		codeClass.setCodeclassname(row.getString("CODECLASSNAME$$KO-KR"));
		codeClass.setDescription(row.getString("DESCRIPTION"));
		codeClass.setCodeclasstype(row.getString("CODECLASSTYPE"));
		codeClass.setParentcodeclassid(row.getString("PARENTCODECLASSID"));
		codeClass.setValidstate(row.getString("VALIDSTATE"));
		
		codeClass.setLasttxnid(TransactionId.MODIFY);
		
		// Code Class Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(CodeClassData.Codeclassname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(CodeClassData.Codeclassname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		
		return codeClass;
	}
	
	// Delete Code Class
	private CodeClassData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		CodeClassData codeClass = new CodeClassData();
		CodeClassKey codeClassKey = codeClass.key();
		codeClassKey.setCodeclassid(row.getString("CODECLASSID"));
		
		codeClass = codeClass.selectOne();
		
		if (codeClass == null)
		{
			throw new InValidDataException("InValidData003", String.format("CodeClassId = %s", row.getString("CODECLASSID")));
		}
		
		if (codeClass.getCodeclasstype().equals("System"))
		{
			throw new MESException("NoSaveSystemCodeClassType", "Delete");
		}
		
		// Check Exists Code Data
		CodeData code = new CodeData();
		SQLCondition cond = new SQLCondition(false);
		cond.set(CodeData.Codeclassid, row.getString("CODECLASSID"));
		ISQLDataList<CodeData> codeList = code.select(cond);
		
		if (codeList.size() > 0)
		{
			throw new MESException("NoDeleteCodeClassIncludingCode");
		}
		
		// Check Exists Children Code Class Data
		Map<String, Object> map = new HashMap<>();
		map.put("CODECLASSID", row.getObject("CODECLASSID"));
		List<Map<String, Object>> listMap = getExistsChildCodeClassList(map);
		
		if (listMap != null && listMap.size() > 0) {
			throw new MESException("NoDeleteCodeClassIncludingChildCodeClass");
		}
		
		
		String dictionaryId = codeClass.getDictionaryid();
		
		codeClass.setLasttxnid(TransactionId.DELETE);
		
		// Delete Code Class Name Dictionary
		CommonUtils.deleteDictionaryData(batch, dictionaryId);
		
		
		return codeClass;
	}
	
	// Check Exists Child Code Class
	private List<Map<String, Object>> getExistsChildCodeClassList(Map<String, Object> map)
	{
		List<Map<String, Object>> listMap = null;
		
		try {
			listMap = select("GetExistsChildCodeClassList", "00001", map);
		} catch (SystemException e) {
			e.printStackTrace();
		} catch (NullPointerException ne) {
			ne.printStackTrace();
		}
		
		return listMap;
	}
}