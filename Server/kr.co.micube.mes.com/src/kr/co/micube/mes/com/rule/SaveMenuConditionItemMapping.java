package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.mes.UIMenuCondItemMapData;
import kr.co.micube.tool.so.mes.UIMenuCondItemMapKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveMenuConditionItemMapping extends DatasetRule {
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
					batch.add(getInsertData(row), SQLUpsertType.INSERT);
					break;
				case UpsertState.UPDATE:
					batch.add(getUpdateData(row), SQLUpsertType.UPDATE);
					break;
				case UpsertState.DELETE:
					batch.add(getDeleteData(row), SQLUpsertType.DELETE);
					break;
			}
		}
		
		batch.execute();
	}
	
	// Insert Menu Condition Item Mapping
	private UIMenuCondItemMapData getInsertData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UIMenuCondItemMapData uiMenuCondItem = new UIMenuCondItemMapData();
		UIMenuCondItemMapKey uiMenuCondItemKey = uiMenuCondItem.key();
		uiMenuCondItemKey.setUiid(row.getString("UIID"));
		uiMenuCondItemKey.setMenuid(row.getString("MENUID"));
		uiMenuCondItemKey.setConditionitemid(row.getString("CONDITIONITEMID"));
		
		uiMenuCondItem = uiMenuCondItem.selectOne();
		
		if (uiMenuCondItem != null)
		{
			throw new InValidDataException("InValidData002", String.format("MenuId = %2, ConditionItemId = %s", row.getString("MENUID"), row.getString("CONDITIONITEMID")));
		}
		
		UIMenuCondItemMapData newUiMenuCondItem = new UIMenuCondItemMapData();
		UIMenuCondItemMapKey newUiMenuCondItemKey = newUiMenuCondItem.key();
		newUiMenuCondItemKey.setUiid(row.getString("UIID"));
		newUiMenuCondItemKey.setMenuid(row.getString("MENUID"));
		newUiMenuCondItemKey.setConditionitemid(row.getString("CONDITIONITEMID"));
		
		newUiMenuCondItem.setConditiontype(row.getString("CONDITIONTYPE"));
		newUiMenuCondItem.setDisplaysequence(row.getDouble("DISPLAYSEQUENCE"));
		newUiMenuCondItem.setValidstate(row.getString("VALIDSTATE"));
		newUiMenuCondItem.setRelationcolumnstack(row.getString("RELATIONCOLUMNSTACK"));
		
		newUiMenuCondItem.setLasttxnid(TransactionId.CREATE);
		
		
		return newUiMenuCondItem;
	}
	
	// Update Menu Condition Item Mapping
	private UIMenuCondItemMapData getUpdateData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UIMenuCondItemMapData uiMenuCondItem = new UIMenuCondItemMapData();
		UIMenuCondItemMapKey uiMenuCondItemKey = uiMenuCondItem.key();
		uiMenuCondItemKey.setUiid(row.getString("UIID"));
		uiMenuCondItemKey.setMenuid(row.getString("MENUID"));
		uiMenuCondItemKey.setConditionitemid(row.getString("CONDITIONITEMID"));
		
		uiMenuCondItem = uiMenuCondItem.selectOne();
		
		if (uiMenuCondItem == null)
		{
			throw new InValidDataException("InValidData001", String.format("MenuId = %2, ConditionItemId = %s", row.getString("MENUID"), row.getString("CONDITIONITEMID")));
		}
		
		uiMenuCondItem.setConditiontype(row.getString("CONDITIONTYPE"));
		uiMenuCondItem.setDisplaysequence(row.getDouble("DISPLAYSEQUENCE"));
		uiMenuCondItem.setValidstate(row.getString("VALIDSTATE"));
		uiMenuCondItem.setRelationcolumnstack(row.getString("RELATIONCOLUMNSTACK"));
		
		uiMenuCondItem.setLasttxnid(TransactionId.MODIFY);
		
		
		return uiMenuCondItem;
	}
	
	// Delete Menu Condition Item Mapping
	private UIMenuCondItemMapData getDeleteData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UIMenuCondItemMapData uiMenuCondItem = new UIMenuCondItemMapData();
		UIMenuCondItemMapKey uiMenuCondItemKey = uiMenuCondItem.key();
		uiMenuCondItemKey.setUiid(row.getString("UIID"));
		uiMenuCondItemKey.setMenuid(row.getString("MENUID"));
		uiMenuCondItemKey.setConditionitemid(row.getString("CONDITIONITEMID"));
		
		uiMenuCondItem = uiMenuCondItem.selectOne();
		
		if (uiMenuCondItem == null)
		{
			throw new InValidDataException("InValidData003", String.format("MenuId = %2, ConditionItemId = %s", row.getString("MENUID"), row.getString("CONDITIONITEMID")));
		}
		
		uiMenuCondItem.setLasttxnid(TransactionId.DELETE);
		
		
		return uiMenuCondItem;
	}
}