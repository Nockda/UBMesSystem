package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlIqcinsplistData;
import kr.co.micube.common.mes.so.UlIqcinsplistKey;
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
 * 프  로  그  램  명	: 기준정보 > 항목관리 > 수입검사항목
 * 설               명	: 수입검사항목 내 변경된 데이터를 저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-04-07
 * 수   정   이   력	: 
 */
public class SaveIqcInspectionList extends DatasetRule {
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
	
	// Insert Code
	private UlIqcinsplistData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlIqcinsplistData code = new UlIqcinsplistData();
		UlIqcinsplistKey codeKey = code.key();

		codeKey.setItemid(row.getString("ITEMID"));

		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("ITEMID")));
		}
		
		UlIqcinsplistData newCode = new UlIqcinsplistData();
		UlIqcinsplistKey newCodeKey = newCode.key();

		newCodeKey.setItemid(row.getString("ITEMID"));
		
		newCode.setItemname(row.getString("ITEMNAME"));
		newCode.setFilename(row.getString("FILENAME"));
		newCode.setFiledata(row.getString("FILEDATA").getBytes());
		//newCode.setFiledata(row.getString("FILEDATA").getBytes(StandardCharsets.UTF_8));
		//newCode.setFiledata(Base64.getDecoder().decode(row.getString("FILEDATA")));
		newCode.setDescription(row.getString("DESCRIPTION"));
		
		return newCode;
	}
	
	// Update Code
	private UlIqcinsplistData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlIqcinsplistData code = new UlIqcinsplistData();
		UlIqcinsplistKey codeKey = code.key();

		codeKey.setItemid(row.getString("ITEMID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("ITEMID")));
		}
			
		code.setItemname(row.getString("ITEMNAME"));
		code.setFilename(row.getString("FILENAME"));
		code.setFiledata(row.getString("FILEDATA").getBytes());
		code.setDescription(row.getString("DESCRIPTION"));

		return code;
	}

	// Delete Code
	private UlIqcinsplistData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlIqcinsplistData code = new UlIqcinsplistData();
		UlIqcinsplistKey codeKey = code.key();

		codeKey.setItemid(row.getString("ITEMID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("ITEMID")));
		}
		
		return code;
	}

}
