package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.EnterpriseData;
import kr.co.micube.common.mes.so.EnterpriseKey;
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
 * 프  로  그  램  명	: 기준정보 > 코드관리 > 회사코드관리
 * 설               명	: 회사코드관리 화면에서 변경된 데이터를 저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-03-24
 * 수   정   이   력	: 
 */
public class SaveEnterprise extends DatasetRule {
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
	private EnterpriseData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		
		
		
		EnterpriseData code = new EnterpriseData();
		EnterpriseKey codeKey = code.key();

		codeKey.setEnterpriseid(row.getString("ENTERPRISEID"));

		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("ENTERPRISEID")));
		}
		
		EnterpriseData newCode = new EnterpriseData();
		EnterpriseKey newCodeKey = newCode.key();

		newCodeKey.setEnterpriseid(row.getString("ENTERPRISEID"));
		
		newCode.setEnterprisename(row.getString("ENTERPRISENAME"));
		newCode.setDescription(row.getString("DESCRIPTION"));
		newCode.setAddress(row.getString("ADDRESS"));
		newCode.setPhone(row.getString("PHONE"));
		newCode.setFaxno(row.getString("FAXNO"));
		newCode.setValidstate(row.getString("VALIDSTATE"));
		
		return newCode;
	}
	
	// Update Code
	private EnterpriseData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		EnterpriseData code = new EnterpriseData();
		EnterpriseKey codeKey = code.key();

		codeKey.setEnterpriseid(row.getString("ENTERPRISEID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("ENTERPRISEID")));
		}
			
		code.setEnterprisename(row.getString("ENTERPRISENAME"));
		code.setDescription(row.getString("DESCRIPTION"));
		code.setAddress(row.getString("ADDRESS"));
		code.setPhone(row.getString("PHONE"));
		code.setFaxno(row.getString("FAXNO"));
		code.setValidstate(row.getString("VALIDSTATE"));

		return code;
	}

	// Delete Code
	private EnterpriseData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		EnterpriseData code = new EnterpriseData();
		EnterpriseKey codeKey = code.key();

		codeKey.setEnterpriseid(row.getString("ENTERPRISEID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("ENTERPRISEID")));
		}
		
		return code;
	}
}
