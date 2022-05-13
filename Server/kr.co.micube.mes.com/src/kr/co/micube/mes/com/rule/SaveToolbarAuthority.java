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
import kr.co.micube.tool.so.mes.ToolbarAuthorityData;
import kr.co.micube.tool.so.mes.ToolbarAuthorityKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveToolbarAuthority extends DatasetRule {
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
				ToolbarAuthorityData toolbarAuthority = getData(row, activated);
				
				if (toolbarAuthority == null)
					continue;
				
				
				if (toolbarAuthority.getLasttxnid().equals(TransactionId.CREATE))
					batch.add(toolbarAuthority, SQLUpsertType.INSERT);
				else if (toolbarAuthority.getLasttxnid().equals(TransactionId.DELETE))
					batch.add(toolbarAuthority, SQLUpsertType.DELETE);
			}
		}
		
		batch.execute();
	}
	
	// Get Data
	private ToolbarAuthorityData getData(IDataRow row, String activated) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		ToolbarAuthorityData toolbarAuthority = new ToolbarAuthorityData();
		ToolbarAuthorityKey toolbarAuthorityKey = toolbarAuthority.key();
		toolbarAuthorityKey.setUiid(row.getString("UIID"));
		toolbarAuthorityKey.setToolbarid(row.getString("TOOLBARID"));
		toolbarAuthorityKey.setMenuid(row.getString("MENUID"));
		toolbarAuthorityKey.setUserclassid(row.getString("USERCLASSID"));
		
		toolbarAuthority = toolbarAuthority.selectOne();
		
		if (activated.equals("true"))
		{
			if (toolbarAuthority != null)
				return null;
			
			toolbarAuthority = new ToolbarAuthorityData();
			toolbarAuthorityKey = toolbarAuthority.key();
			toolbarAuthorityKey.setUiid(row.getString("UIID"));
			toolbarAuthorityKey.setToolbarid(row.getString("TOOLBARID"));
			toolbarAuthorityKey.setMenuid(row.getString("MENUID"));
			toolbarAuthorityKey.setUserclassid(row.getString("USERCLASSID"));
			
			toolbarAuthority.setValidstate("Valid");
			
			toolbarAuthority.setLasttxnid(TransactionId.CREATE);
		}
		else if (activated.equals("false"))
		{
			if (toolbarAuthority == null)
				return null;
			
			toolbarAuthority.setLasttxnid(TransactionId.DELETE);
		}
		else
			return null;
		

		return toolbarAuthority;
	}
}
