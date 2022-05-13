package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlProcessData;
import kr.co.micube.common.mes.so.UlProcessKey;
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
 * 프  로  그  램  명	: 기준정보 > 코드관리 > 설비코드
 * 설               명	: 코드그룹 정보 화면에서 변경된 데이터를 저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-03-03
 * 수   정   이   력	: 
 */
public class SaveProcessCode extends DatasetRule {
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
		private UlProcessData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlProcessData code = new UlProcessData();
			UlProcessKey codeKey = code.key();

			codeKey.setProcessid(row.getString("PROCESSID"));

			code = code.selectOne();
			
			if (code != null)
			{
				throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("PROCESSID")));
			}
			
			UlProcessData newCode = new UlProcessData();
			UlProcessKey newCodeKey = newCode.key();

			newCodeKey.setProcessid(row.getString("PROCESSID"));
			
			newCode.setProcessnamekor(row.getString("PROCESSNAMEKOR"));
			newCode.setProcessnameeng(row.getString("PROCESSNAMEENG"));
			newCode.setProcessnamejpn(row.getString("PROCESSNAMEJPN"));
			newCode.setWorkgroupid(row.getString("WORKGROUPID"));
			newCode.setOrdertype(row.getString("ORDERTYPE"));
			newCode.setLotunit(row.getString("LOTUNIT"));
			newCode.setValidstate(row.getString("VALIDSTATE"));
			newCode.setDescription(row.getString("DESCRIPTION"));
			
			
			
			return newCode;
		}
		
		// Update Code
		private UlProcessData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlProcessData code = new UlProcessData();
			UlProcessKey codeKey = code.key();

			codeKey.setProcessid(row.getString("PROCESSID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("PROCESSID")));
			}
				
			code.setProcessnamekor(row.getString("PROCESSNAMEKOR"));
			code.setProcessnameeng(row.getString("PROCESSNAMEENG"));
			code.setProcessnamejpn(row.getString("PROCESSNAMEJPN"));
			code.setWorkgroupid(row.getString("WORKGROUPID"));
			code.setOrdertype(row.getString("ORDERTYPE"));
			code.setLotunit(row.getString("LOTUNIT"));
			code.setValidstate(row.getString("VALIDSTATE"));
			code.setDescription(row.getString("DESCRIPTION"));

			return code;
		}

		// Delete Code
		private UlProcessData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlProcessData code = new UlProcessData();
			UlProcessKey codeKey = code.key();

			codeKey.setProcessid(row.getString("PROCESSID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("PROCESSID")));
			}
			
			return code;
		}

}
