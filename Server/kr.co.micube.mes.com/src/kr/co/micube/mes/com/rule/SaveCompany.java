package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlCompanyData;
import kr.co.micube.common.mes.so.UlCompanyKey;
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
public class SaveCompany extends DatasetRule {
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
	private UlCompanyData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlCompanyData code = new UlCompanyData();
		UlCompanyKey codeKey = code.key();

		codeKey.setCompanyid(row.getString("COMPANYID"));

		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("COMPANYID")));
		}
		
		UlCompanyData newCode = new UlCompanyData();
		UlCompanyKey newCodeKey = newCode.key();

		newCodeKey.setCompanyid(row.getString("COMPANYID"));
		
		newCode.setCompanynamekor(row.getString("COMPANYNAMEKOR"));
		newCode.setCompanynameeng(row.getString("COMPANYNAMEENG"));
		newCode.setCompanynamejpn(row.getString("COMPANYNAMEJPN"));
		newCode.setDescription(row.getString("DESCRIPTION"));
		newCode.setCompanytype(row.getString("COMPANYTYPE"));
		newCode.setLawregno(row.getString("LAWREGNO"));
		newCode.setBusinessno(row.getString("BUSINESSNO"));
		newCode.setCeoname(row.getString("CEONAME"));
		newCode.setPhone(row.getString("PHONE"));
		newCode.setFaxno(row.getString("FAXNO"));
		newCode.setAddress(row.getString("ADDRESS"));
		newCode.setHomepage(row.getString("HOMEPAGE"));
		newCode.setCategory(row.getString("CATEGORY"));
		newCode.setItem(row.getString("ITEM"));
		newCode.setValidstate(row.getString("VALIDSTATE"));
		
		return newCode;
	}
	
	// Update Code
	private UlCompanyData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlCompanyData code = new UlCompanyData();
		UlCompanyKey codeKey = code.key();

		codeKey.setCompanyid(row.getString("COMPANYID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("COMPANYID")));
		}
			
		code.setCompanynamekor(row.getString("COMPANYNAMEKOR"));
		code.setCompanynameeng(row.getString("COMPANYNAMEENG"));
		code.setCompanynamejpn(row.getString("COMPANYNAMEJPN"));
		code.setDescription(row.getString("DESCRIPTION"));
		code.setCompanytype(row.getString("COMPANYTYPE"));
		code.setLawregno(row.getString("LAWREGNO"));
		code.setBusinessno(row.getString("BUSINESSNO"));
		code.setCeoname(row.getString("CEONAME"));
		code.setPhone(row.getString("PHONE"));
		code.setFaxno(row.getString("FAXNO"));
		code.setAddress(row.getString("ADDRESS"));
		code.setHomepage(row.getString("HOMEPAGE"));
		code.setCategory(row.getString("CATEGORY"));
		code.setItem(row.getString("ITEM"));
		code.setValidstate(row.getString("VALIDSTATE"));

		return code;
	}

	// Delete Code
	private UlCompanyData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlCompanyData code = new UlCompanyData();
		UlCompanyKey codeKey = code.key();

		codeKey.setCompanyid(row.getString("COMPANYID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("COMPANYID")));
		}
		
		return code;
	}
}
