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
import kr.co.micube.tool.so.mes.MessageData;
import kr.co.micube.tool.so.mes.ToolbarData;
import kr.co.micube.tool.so.mes.ToolbarKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveToolbar extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		// Get Message
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
	
	// Insert Toolbar
	private ToolbarData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		ToolbarData toolbar = new ToolbarData();
		ToolbarKey toolbarKey = toolbar.key();
		toolbarKey.setUiid(row.getString("UIID"));
		toolbarKey.setToolbarid(row.getString("TOOLBARID"));
		
		toolbar = toolbar.selectOne();
		
		if (toolbar != null)
		{
			throw new MESException("InValidData002", String.format("ToolbarId = %s", row.getString("TOOLBARID")));
		}
		
		String dictionaryId = "Toolbar_" + row.getString("TOOLBARID");
		String messageId = Generate.createID();
		
		ToolbarData newToolbar = new ToolbarData();
		ToolbarKey newToolbarKey = newToolbar.key();
		newToolbarKey.setUiid(row.getString("UIID"));
		newToolbarKey.setToolbarid(row.getString("TOOLBARID"));
		
		newToolbar.setToolbarname(row.getString("TOOLBARNAME$$KO-KR"));
		newToolbar.setDescription(row.getString("DESCRIPTION"));
		newToolbar.setToolbartype(row.getString("TOOLBARTYPE"));
		//newToolbar.setOptions(row.getString("OPTIONS"));
		newToolbar.setDisplaysequence(row.getDouble("DISPLAYSEQUENCE"));
		newToolbar.setDictionaryid(dictionaryId);
		newToolbar.setMessageid(messageId);
		newToolbar.setValidstate(row.getString("VALIDSTATE"));
		
		//smjang - 컬럼 추가
//		newToolbar.setIswrite(row.getString("ISWRITE"));
		
		newToolbar.setLasttxnid(TransactionId.CREATE);
		
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		// Toolbar Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(ToolbarData.Toolbarname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(ToolbarData.Toolbarname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, "TOOLBAR", dictionaryMap);
		
		// ToolTip Dictionary
		Map<String, String> messageMap = new HashMap<>();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(MessageData.Messagename.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			messageMap.put(lang, row.getString(MessageData.Messagename.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendToolTipData(batch, messageId, messageMap);
		
		
		return newToolbar;
	}
	
	// Update Toolbar
	private ToolbarData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		ToolbarData toolbar = new ToolbarData();
		ToolbarKey toolbarKey = toolbar.key();
		toolbarKey.setUiid(row.getString("UIID"));
		toolbarKey.setToolbarid(row.getString("TOOLBARID"));
		
		toolbar = toolbar.selectOne();
		
		if (toolbar == null)
		{
			throw new MESException("InValidData001", String.format("ToolbarId = %s", row.getString("TOOLBARID")));
		}
		
		String dictionaryId = toolbar.getDictionaryid();
		String messageId = toolbar.getMessageid();
		
		if (StringUtils.isNullOrEmpty(dictionaryId))
		{
			dictionaryId = "Toolbar_" + row.getString("TOOLBARID");
			toolbar.setDictionaryid(dictionaryId);
		}
		
		if (StringUtils.isNullOrEmpty(messageId))
		{
			messageId = Generate.createID();
			toolbar.setMessageid(messageId);
		}
		
		toolbar.setToolbarname(row.getString("TOOLBARNAME%%KO-KR"));
		toolbar.setDescription(row.getString("DESCRIPTION"));
		toolbar.setToolbartype(row.getString("TOOLBARTYPE"));
		toolbar.setOptions(row.getString("OPTIONS"));
		toolbar.setDisplaysequence(row.getDouble("DISPLAYSEQUENCE"));
		toolbar.setValidstate(row.getString("VALIDSTATE"));
		
		//smjang - 컬럼추가
//		toolbar.setIswrite(row.getString("ISWRITE"));
		
		toolbar.setLasttxnid(TransactionId.MODIFY);
		
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		// Toolbar Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(ToolbarData.Toolbarname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(ToolbarData.Toolbarname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, "TOOLBAR", dictionaryMap);
		
		// ToolTip Dictionary
		Map<String, String> messageMap = new HashMap<>();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(MessageData.Messagename.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			messageMap.put(lang, row.getString(MessageData.Messagename.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendToolTipData(batch, messageId, messageMap);
		
		
		return toolbar;
	}
	
	// Delete Toolbar
	private ToolbarData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		ToolbarData toolbar = new ToolbarData();
		ToolbarKey toolbarKey = toolbar.key();
		toolbarKey.setUiid(row.getString("UIID"));
		toolbarKey.setToolbarid(row.getString("TOOLBARID"));
		
		toolbar = toolbar.selectOne();
		
		if (toolbar == null)
		{
			throw new MESException("InValidData003", String.format("ToolbarId = %s", row.getString("TOOLBARID")));
		}
		
		String dictionaryId = toolbar.getDictionaryid();
		String messageId = toolbar.getMessageid();
		
		toolbar.setLasttxnid(TransactionId.DELETE);
		
		
		CommonUtils.deleteDictionaryData(batch, dictionaryId);
		CommonUtils.deleteToolTipData(batch, messageId);
		
		
		return toolbar;
	}
}
