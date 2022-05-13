package kr.co.micube.mes.standard.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.SfConsumabledefinitionData;
import kr.co.micube.common.mes.so.SfConsumabledefinitionKey;
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

public class MappingConsumableInfo extends DatasetRule{

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

	private ISQLData getInsertData(IDataRow row, ISQLUpsertBatch batch) {
		// TODO Auto-generated method stub
		return null;
	}

	private SfConsumabledefinitionData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException{
		SfConsumabledefinitionData code = new SfConsumabledefinitionData();
		SfConsumabledefinitionKey codeKey = code.key();
		
		codeKey.setConsumabledefid(row.getString("CONSUMABLEDEFID"));
		codeKey.setConsumabledefversion(row.getString("CONSUMABLEDEFVERSION"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CONSUMABLEDEFID = %s", row.getString("ITEMID")));
		}
		
		code.setPartnumber(row.getString("PARTNUMBER"));
		code.setImportinsp(row.getString("IMPORTINSP"));
		code.setIsserial(row.getString("SERIAL"));
		code.setIstracking(row.getString("TRACKING"));
		code.setLotsize(row.getDouble("LOTSIZE"));
		code.setValidstate(row.getString("VALIDSTATE"));
		code.setReceivinginspstdfileid(row.getString("RECEIVINGINSPSTDFILEID"));
		code.setShippinginspstdfileid(row.getString("SHIPPINGINSPSTDFILEID"));
		code.setConsumabledefshortname(row.getString("CONSUMABLEDEFSHORTNAME"));
		code.setIsnotorderresult(row.getString("ISNOTORDERRESULT"));
		code.setNotordersegmentid(row.getString("NOTORDERSEGMENTID"));
		return code;
	}

	private ISQLData getDeleteData(IDataRow row, ISQLUpsertBatch batch) {
		// TODO Auto-generated method stub
		return null;
	}
}
