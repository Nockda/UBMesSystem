package kr.co.micube.mes.com.rule;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.mes.FavoriteMenusData;
import kr.co.micube.tool.so.mes.FavoriteMenusKey;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveFavoriteMenu extends DatasetRule {
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
	
	// Insert Favorite Menu
	private FavoriteMenusData getInsertData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SQLCondition cond = new SQLCondition(false);
		cond.set(FavoriteMenusData.Userid);
		cond.set(FavoriteMenusData.Menuid);
		
		FavoriteMenusData favoriteMenus = new FavoriteMenusData();
		FavoriteMenusKey favoriteMenusKey = favoriteMenus.key();
		favoriteMenusKey.setUserid(row.getString("USERID"));
		favoriteMenusKey.setMenuid(row.getString("MENUID"));
		
		
		ISQLDataList<FavoriteMenusData> ret = favoriteMenus.select(cond);
		
		if (ret.size() > 0)
		{
			throw new MESException("HaveFavoriteMenu", row.getString("MENUID"));
		}
		
		
		cond = new SQLCondition(false);
		cond.set(FavoriteMenusData.Userid);
		
		favoriteMenus = new FavoriteMenusData();
		favoriteMenusKey = favoriteMenus.key();
		favoriteMenusKey.setUserid(row.getString("USERID"));
		
		ret = favoriteMenus.select(cond);
		
		DateFormat format = new SimpleDateFormat("yyyyMMddHHmmssSSSSSS");
		String txnHistKey = format.format(new Date());
		double displaySequence = ret.size() + 1;
		
		
		favoriteMenus = new FavoriteMenusData();
		favoriteMenusKey = favoriteMenus.key();
		favoriteMenusKey.setUserid(row.getString("USERID"));
		favoriteMenusKey.setMenuid(row.getString("MENUID"));
		favoriteMenusKey.setRegtype(row.getString("REGTYPE"));
		favoriteMenusKey.setTxnhistkey(txnHistKey);
		
		favoriteMenus.setDisplaysequence(displaySequence);
		
		
		return favoriteMenus;
	}
	
	// Update Favorite Menu
	private FavoriteMenusData getUpdateData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		FavoriteMenusData favoriteMenus = new FavoriteMenusData();
		FavoriteMenusKey favoriteMenusKey = favoriteMenus.key();
		favoriteMenusKey.setUserid(row.getString("USERID"));
		favoriteMenusKey.setMenuid(row.getString("MENUID"));
		favoriteMenusKey.setRegtype(row.getString("REGTYPE"));
		favoriteMenusKey.setTxnhistkey(row.getString("TXNHISTKEY"));
		
		if (favoriteMenus.selectOne() == null)
		{
			throw new InValidDataException("InValidData001", String.format("User Id = %s, Menu Id = %s", row.getString("USERID"), row.getString("MENUID")));
		}
		
		
		favoriteMenus.setDisplaysequence(row.getDouble("DISPLAYSEQUENCE"));
		
		
		return favoriteMenus;
	}
	
	// Delete Favorite Menu
	private FavoriteMenusData getDeleteData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		FavoriteMenusData favoriteMenus = new FavoriteMenusData();
		FavoriteMenusKey favoriteMenusKey = favoriteMenus.key();
		favoriteMenusKey.setUserid(row.getString("USERID"));
		favoriteMenusKey.setMenuid(row.getString("MENUID"));
		favoriteMenusKey.setRegtype(row.getString("REGTYPE"));
		favoriteMenusKey.setTxnhistkey(row.getString("TXNHISTKEY"));
		
		
		return favoriteMenus;
	}
}