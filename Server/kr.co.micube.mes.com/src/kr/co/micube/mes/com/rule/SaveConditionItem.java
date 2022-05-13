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
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.mes.UICondItemData;
import kr.co.micube.tool.so.mes.UICondItemKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveConditionItem extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		// Get Message
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		// Get Batch Variable
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		// Initialize for Variables
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
	
	// Insert ConditionItem
	private UICondItemData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UICondItemData conditionItem = new UICondItemData();
		UICondItemKey conditionItemKey = conditionItem.key();
		conditionItemKey.setConditionitemid(row.getString("CONDITIONITEMID"));
		conditionItemKey.setUiid(row.getString("UIID"));
		
		conditionItem = conditionItem.selectOne();
		
		if (conditionItem != null)
		{
			throw new InValidDataException("InValidData002", String.format("ConditionItemId = %s", row.getString("CONDITIONITEMID")));
		}
		
		
		//String dictionaryId = Generate.createID();
		String dictionaryId = row.getString("CONDITIONITEMID");
		
		UICondItemData newConditionItem = new UICondItemData();
		UICondItemKey newConditionItemKey = newConditionItem.key();
		newConditionItemKey.setConditionitemid(row.getString("CONDITIONITEMID"));
		newConditionItemKey.setUiid(row.getString("UIID"));
		
		newConditionItem.setConditionitemname(row.getString("CONDITIONITEMNAME$$KO-KR"));
		newConditionItem.setDescription(row.getString("DESCRIPTION"));
		newConditionItem.setColumnname(row.getString("COLUMNNAME"));
		newConditionItem.setItemtype(row.getString("ITEMTYPE"));
		newConditionItem.setDataformat(row.getString("DATAFORMAT"));
		newConditionItem.setDefaultvalue(row.getString("DEFAULTVALUE"));
		newConditionItem.setConstantdata(row.getString("CONSTANTDATA"));
		newConditionItem.setIsrequired(row.getString("ISREQUIRED"));
		newConditionItem.setIshidden(row.getString("ISHIDDEN"));
		newConditionItem.setIsall(row.getString("ISALL"));
		newConditionItem.setExecutetype(row.getString("EXECUTETYPE"));
		newConditionItem.setExecuteid(row.getString("EXECUTEID"));
		newConditionItem.setExecuteversion(row.getString("EXECUTEVERSION"));
		newConditionItem.setExecuteparameter(row.getString("EXECUTEPARAMETER"));
		newConditionItem.setDisplaymember(row.getString("DISPLAYMEMBER"));
		newConditionItem.setValuemember(row.getString("VALUEMEMBER"));
		newConditionItem.setDictionaryid(dictionaryId);
		newConditionItem.setValidstate(row.getString("VALIDSTATE"));
		
		newConditionItem.setLasttxnid(TransactionId.CREATE);
		
		// ConditionItem Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(UICondItemData.Conditionitemname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(UICondItemData.Conditionitemname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, "CONDITIONLABEL", dictionaryMap);
		
		
		return newConditionItem;
	}
	
	// Update ConditionItem
	private UICondItemData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UICondItemData conditionItem = new UICondItemData();
		UICondItemKey conditionItemKey = conditionItem.key();
		conditionItemKey.setConditionitemid(row.getString("CONDITIONITEMID"));
		conditionItemKey.setUiid(row.getString("UIID"));
		
		conditionItem = conditionItem.selectOne();
		
		if (conditionItem == null)
		{
			throw new InValidDataException("InValidData001", String.format("ConditionItemId = %s", row.getString("CONDITIONITEMID")));
		}
		
		String dictionaryId = conditionItem.getDictionaryid();
		
		if (StringUtils.isNullOrEmpty(dictionaryId))
		{
			//dictionaryId = Generate.createID();
			dictionaryId = row.getString("CONDITIONITEMID");
			conditionItem.setDictionaryid(dictionaryId);
		}
		
		conditionItem.setConditionitemname(row.getString("CONDITIONITEMNAME$$KO-KR"));
		conditionItem.setDescription(row.getString("DESCRIPTION"));
		conditionItem.setColumnname(row.getString("COLUMNNAME"));
		conditionItem.setItemtype(row.getString("ITEMTYPE"));
		conditionItem.setDataformat(row.getString("DATAFORMAT"));
		conditionItem.setDefaultvalue(row.getString("DEFAULTVALUE"));
		conditionItem.setConstantdata(row.getString("CONSTANTDATA"));
		conditionItem.setIsrequired(row.getString("ISREQUIRED"));
		conditionItem.setIshidden(row.getString("ISHIDDEN"));
		conditionItem.setIsall(row.getString("ISALL"));
		conditionItem.setExecutetype(row.getString("EXECUTETYPE"));
		conditionItem.setExecuteid(row.getString("EXECUTEID"));
		conditionItem.setExecuteversion(row.getString("EXECUTEVERSION"));
		conditionItem.setExecuteparameter(row.getString("EXECUTEPARAMETER"));
		conditionItem.setDisplaymember(row.getString("DISPLAYMEMBER"));
		conditionItem.setValuemember(row.getString("VALUEMEMBER"));
		conditionItem.setValidstate(row.getString("VALIDSTATE"));
		
		conditionItem.setLasttxnid(TransactionId.MODIFY);
		
		// ConditionItem Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(UICondItemData.Conditionitemname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(UICondItemData.Conditionitemname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, "CONDITIONLABEL", dictionaryMap);
		
		
		return conditionItem;
	}
	
	// Delete ConditionItem
	private UICondItemData getDeleteData(IDataRow row, ISQLUpsertBatch batch)  throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UICondItemData conditionItem = new UICondItemData();
		UICondItemKey conditionItemKey = conditionItem.key();
		conditionItemKey.setConditionitemid(row.getString("CONDITIONITEMID"));
		conditionItemKey.setUiid(row.getString("UIID"));
		
		conditionItem = conditionItem.selectOne();
		
		if (conditionItem == null)
		{
			throw new InValidDataException("InValidData003", String.format("ConditionItemId = %s", row.getString("CONDITIONITEMID")));
		}
		
		String dictionaryId = conditionItem.getDictionaryid();
		
		CommonUtils.deleteDictionaryData(batch, dictionaryId);
		
		
		return conditionItem;
	}
}