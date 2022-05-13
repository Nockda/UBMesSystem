package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlRackdetailData;
import kr.co.micube.common.mes.so.UlRackdetailKey;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 기준정보 > 창고관리 > 랙관리
 * 설               명	: 창고 랙관리 하위그리드 데이터를 수정한다.
 * 생      성      자	: jylee
 * 생      성      일	: 2020-04-15
 * 수   정   이   력	: 
 */
public class SaveRackDetail extends DatasetRule{

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
	
	//INSERT
	private UlRackdetailData getInsertData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		UlRackdetailData code = new UlRackdetailData();
		UlRackdetailKey codeKey = code.key();
		
		codeKey.setCellid(row.getString("CELLID"));
		
		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("CELLID")));
		}
		
		UlRackdetailData newCode = new UlRackdetailData();
		UlRackdetailKey newCodeKey = newCode.key();
		
		newCodeKey.setCellid(row.getString("CELLID"));
		newCode.setCellname(row.getString("CELLNAME"));
		newCode.setRackid(row.getString("RACKID"));
		newCode.setRackname(row.getString("RACKNAME"));
		newCode.setItemid(row.getString("ITEMID"));
		newCode.setItemname(row.getString("ITEMNAME"));
		newCode.setQty(row.getDouble("QTY"));
		newCode.setInqty(row.getDouble("INQTY"));
		newCode.setOutqty(row.getDouble("OUTQTY"));
		newCode.setValidstate(row.getString("VALIDSTATE"));
	
		return newCode;
	}
	//UPDATE
	private UlRackdetailData getUpdateData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		
		UlRackdetailData code = new UlRackdetailData();
		UlRackdetailKey codeKey = code.key();
		
		codeKey.setCellid(row.getString("CELLID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("CELLID")));
		}
		
		codeKey.setCellid(row.getString("CELLID"));
		code.setCellname(row.getString("CELLNAME"));
		code.setRackid(row.getString("RACKID"));
		code.setRackname(row.getString("RACKNAME"));
		code.setItemid(row.getString("ITEMID"));
		code.setItemname(row.getString("ITEMNAME"));
		code.setQty(row.getDouble("QTY"));
		code.setInqty(row.getDouble("INQTY"));
		code.setOutqty(row.getDouble("OUTQTY"));
		code.setValidstate(row.getString("VALIDSTATE"));
		
		return code;
	}
	//DELETE
	private UlRackdetailData getDeleteData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		UlRackdetailData code = new UlRackdetailData();
		UlRackdetailKey codeKey = code.key();
		
		codeKey.setCellid(row.getString("CELLID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("CELLID")));
		}
		
		return code;
	}

}
