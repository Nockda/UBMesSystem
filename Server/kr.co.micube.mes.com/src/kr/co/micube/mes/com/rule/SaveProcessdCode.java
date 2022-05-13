package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlProcessdData;
import kr.co.micube.common.mes.so.UlProcessdKey;
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
 * 프  로  그  램  명	: 기준정보 > 코드 관리 > 세부공정코드
 * 설               명	: 세부공정코드 정보 화면에서 변경된 데이터를 저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-04-06
 * 수   정   이   력	: 
 */
public class SaveProcessdCode extends DatasetRule {
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
		private UlProcessdData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlProcessdData code = new UlProcessdData();
			UlProcessdKey codeKey = code.key();

			codeKey.setProcessdid(row.getString("PROCESSDID"));

			code = code.selectOne();
			
			if (code != null)
			{
				throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("PROCESSDID")));
			}
			
			UlProcessdData newCode = new UlProcessdData();
			UlProcessdKey newCodeKey = newCode.key();

			newCodeKey.setProcessdid(row.getString("PROCESSDID"));
			
			newCode.setProcessdnamekor(row.getString("PROCESSDNAMEKOR"));
			newCode.setProcessdnameeng(row.getString("PROCESSDNAMEENG"));
			newCode.setProcessdnamejpn(row.getString("PROCESSDNAMEJPN"));
			newCode.setValidstate(row.getString("VALIDSTATE"));
			newCode.setDescription(row.getString("DESCRIPTION"));
			
			return newCode;
		}
		
		// Update Code
		private UlProcessdData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlProcessdData code = new UlProcessdData();
			UlProcessdKey codeKey = code.key();

			codeKey.setProcessdid(row.getString("PROCESSDID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("PROCESSDID")));
			}
				
			code.setProcessdnamekor(row.getString("PROCESSDNAMEKOR"));
			code.setProcessdnameeng(row.getString("PROCESSDNAMEENG"));
			code.setProcessdnamejpn(row.getString("PROCESSDNAMEJPN"));
			code.setValidstate(row.getString("VALIDSTATE"));
			code.setDescription(row.getString("DESCRIPTION"));

			return code;
		}

		// Delete Code
		private UlProcessdData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlProcessdData code = new UlProcessdData();
			UlProcessdKey codeKey = code.key();

			codeKey.setProcessdid(row.getString("PROCESSDID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("PROCESSDID")));
			}
			
			return code;
		}

}
