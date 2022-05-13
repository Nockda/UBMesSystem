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
import kr.co.micube.tool.so.mes.MenuAuthorityData;
import kr.co.micube.tool.so.mes.MenuAuthorityKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveMenuAuthority extends DatasetRule {
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
			String activated = row.getString("ACTIVATED");
			
			if (state.equals(UpsertState.UPDATE))
			{
				MenuAuthorityData menuAuthority = getData(row, activated);
				
				if (menuAuthority == null)
					continue;
				
				
				if (menuAuthority.getLasttxnid().equals(TransactionId.CREATE))
					batch.add(menuAuthority, SQLUpsertType.INSERT);
				else if (menuAuthority.getLasttxnid().equals(TransactionId.DELETE))
					batch.add(menuAuthority, SQLUpsertType.DELETE);
			}
		}
		
		batch.execute();
	}
	
	// Get Data
	private MenuAuthorityData getData(IDataRow row, String activated) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		MenuAuthorityData menuAuthority = new MenuAuthorityData();
		MenuAuthorityKey menuAuthorityKey = menuAuthority.key();
		menuAuthorityKey.setUserclassid(row.getString("USERCLASSID"));
		menuAuthorityKey.setUiid(row.getString("UIID"));
		menuAuthorityKey.setMenuid(row.getString("MENUID"));
		
		menuAuthority = menuAuthority.selectOne();
		
		if (activated.equals("true"))
		{
			if (menuAuthority != null)
				return null;
			
			menuAuthority = new MenuAuthorityData();
			menuAuthorityKey = menuAuthority.key();
			menuAuthorityKey.setUserclassid(row.getString("USERCLASSID"));
			menuAuthorityKey.setUiid(row.getString("UIID"));
			menuAuthorityKey.setMenuid(row.getString("MENUID"));
			
			menuAuthority.setDescription(row.getString("DESCRIPTION"));
			menuAuthority.setValidstate("Valid");
			
			menuAuthority.setLasttxnid(TransactionId.CREATE);
		}
		else if (activated.equals("false"))
		{
			if (menuAuthority == null)
				return null;
			
			menuAuthority.setLasttxnid(TransactionId.DELETE);
		}
		else
			return null;
		
		
		return menuAuthority;
	}
}
