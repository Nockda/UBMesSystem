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
import kr.co.micube.tool.so.mes.MenuData;
import kr.co.micube.tool.so.mes.MenuKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveMenu extends DatasetRule {
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
	
	// Insert Menu
	private MenuData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		MenuData menu = new MenuData();
		MenuKey menuKey = menu.key();
		menuKey.setMenuid(row.getString("MENUID"));
		menuKey.setUiid(row.getString("UIID"));
		
		menu = menu.selectOne();
		
		if (menu != null)
		{
			throw new MESException("InValidData002", String.format("MenuId = %s", row.getString("MENUID")));
		}
		
		
		String dictionaryId = "MENU_" + row.getString("MENUID").toUpperCase();
		
		MenuData newMenu = new MenuData();
		MenuKey newMenuKey = newMenu.key();
		newMenuKey.setMenuid(row.getString("MENUID"));
		newMenuKey.setUiid(row.getString("UIID"));
		
		newMenu.setMenuname(row.getString("MENUNAME&&KO-KR"));
		newMenu.setDescription(row.getString("DESCRIPTION"));
		newMenu.setEnterpriseid(row.getString("ENTERPRISEID"));
		newMenu.setPlantid(row.getString("PLANTID"));
		newMenu.setParentmenuid(row.getString("PARENTMENUID"));
		newMenu.setDisplaysequence(row.getDouble("DISPLAYSEQUENCE"));
		newMenu.setMenutype(row.getString("MENUTYPE"));
		newMenu.setProgramid(row.getString("PROGRAMID"));
		newMenu.setDictionaryid(dictionaryId);
		newMenu.setValidstate(row.getString("VALIDSTATE"));
		
		newMenu.setLasttxnid(TransactionId.CREATE);
		
		// Menu Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(MenuData.Menuname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(MenuData.Menuname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, "MENU", dictionaryMap);
		
		
		return newMenu;
	}
	
	// Update Menu
	private MenuData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		MenuData menu = new MenuData();
		MenuKey menuKey = menu.key();
		menuKey.setMenuid(row.getString("MENUID"));
		menuKey.setUiid(row.getString("UIID"));
		
		menu = menu.selectOne();
		
		if (menu == null)
		{
			throw new MESException("InValidData001", String.format("MenuId = %s", row.getString("MENUID")));
		}
		
		String dictionaryId = menu.getDictionaryid();
		
		if (StringUtils.isNullOrEmpty(dictionaryId))
		{
			dictionaryId = "MENU_" + row.getString("MENUID").toUpperCase();
			menu.setDictionaryid(dictionaryId);
		}
		
		menu.setMenuname(row.getString("MENUNAME$$KO-KR"));
		menu.setDescription(row.getString("DESCRIPTION"));
		menu.setEnterpriseid(row.getString("ENTERPRISEID"));
		menu.setPlantid(row.getString("PLANTID"));
		menu.setParentmenuid(row.getString("PARENTMENUID"));
		menu.setDisplaysequence(row.getDouble("DISPLAYSEQUENCE"));
		menu.setMenutype(row.getString("MENUTYPE"));
		menu.setProgramid(row.getString("PROGRAMID"));
		menu.setValidstate(row.getString("VALIDSTATE"));
		
		menu.setLasttxnid(TransactionId.MODIFY);
		
		// Menu Name Dictionary
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(MenuData.Menuname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(MenuData.Menuname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, "MENU", dictionaryMap);
		
		
		return menu;
	}
	
	// Delete Menu
	private MenuData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		MenuData menu = new MenuData();
		MenuKey menuKey = menu.key();
		menuKey.setMenuid(row.getString("MENUID"));
		menuKey.setUiid(row.getString("UIID"));
		
		menu = menu.selectOne();
		
		if (menu == null)
		{
			throw new MESException("InValidData003", String.format("MenuId = %s", row.getString("MENUID")));
		}
		
		String dictionaryId = menu.getDictionaryid();
		
		CommonUtils.deleteDictionaryData(batch, dictionaryId);
		
		
		return menu;
	}
}