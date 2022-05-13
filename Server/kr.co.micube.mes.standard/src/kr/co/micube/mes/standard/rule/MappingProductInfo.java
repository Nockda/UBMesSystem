package kr.co.micube.mes.standard.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.SfProductdefinitionData;
import kr.co.micube.common.mes.so.SfProductdefinitionKey;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLData;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명   : 기준정보 > 항목관리 > 품목관리
 * 설               명   : 품목정보에 SPECID를 맵핑
 * 생      성      자   : jylee
 * 생      성      일   : 2020-05-15
 * 수   정   이   력   : 
 */

public class MappingProductInfo extends DatasetRule {

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
	//Insert
	private ISQLData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		// TODO Auto-generated method stub
		return null;
	}
	//Update
	private SfProductdefinitionData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		SfProductdefinitionData code = new SfProductdefinitionData();
		SfProductdefinitionKey codeKey = code.key();
		
		codeKey.setProductdefid(row.getString("PRODUCTDEFID"));
		codeKey.setProductdefversion(row.getString("PRODUCTDEFVERSION"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("ProductdefId = %s", row.getString("PRODUCTDEFID")));
		}
		code.setPartnumber(row.getString("ITEMID"));
		code.setTeamid(row.getString("TEAM"));
		code.setAreaid(row.getString("AREAID"));
		code.setModelid(row.getString("MODELID"));
		code.setSpecdefid(row.getString("SPECDEFID"));
		code.setLotsize(row.getDouble("LOTSIZE"));
		code.setProcessdefid(row.getString("PROCESSDEFID"));
		code.setShippinginspstdfileid(row.getString("SHIPPINGINSPSTDFILEID"));
		code.setValidstate(row.getString("VALIDSTATE"));
		code.setProductdefshortname(row.getString("PRODUCTDEFSHORTNAME"));
		
		return code;
	}
	//Delete
	private ISQLData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException{
		// TODO Auto-generated method stub
		return null;
	}

}
