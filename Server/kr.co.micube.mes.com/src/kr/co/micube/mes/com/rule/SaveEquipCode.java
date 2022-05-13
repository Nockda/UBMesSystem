package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.EquipmentData;
import kr.co.micube.common.mes.so.EquipmentKey;
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
public class SaveEquipCode extends DatasetRule {
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
		private EquipmentData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			EquipmentData code = new EquipmentData();
			EquipmentKey codeKey = code.key();

			codeKey.setEquipmentid(row.getString("EQUIPMENTID"));

			code = code.selectOne();
			
			if (code != null)
			{
				throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("EQUIPMENTID")));
			}
			
			EquipmentData newCode = new EquipmentData();
			EquipmentKey newCodeKey = newCode.key();

			newCodeKey.setEquipmentid(row.getString("EQUIPMENTID"));
			
			newCode.setEquipmentnamekor(row.getString("EQUIPMENTNAMEKOR"));
			newCode.setEquipmentnameeng(row.getString("EQUIPMENTNAMEENG"));
			newCode.setEquipmentnamejpn(row.getString("EQUIPMENTNAMEJPN"));
			newCode.setEquipmenttype(row.getString("EQUIPMENTTYPE"));
			newCode.setEquipmentclassid(row.getString("EQUIPMENTCLASSID"));
			newCode.setAreaid(row.getString("AREAID"));
			newCode.setProcessdefid(row.getString("PROCESSDEFID"));
			newCode.setDepartmentid(row.getString("DEPARTMENTID"));
			newCode.setAssetno(row.getString("ASSETNO"));
			newCode.setIfstate(row.getString("IFSTATE"));
			newCode.setValidstate(row.getString("VALIDSTATE"));
			newCode.setDescription(row.getString("DESCRIPTION"));
			
			return newCode;
		}
		
		// Update Code
		private EquipmentData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			EquipmentData code = new EquipmentData();
			EquipmentKey codeKey = code.key();

			codeKey.setEquipmentid(row.getString("EQUIPMENTID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("EQUIPMENTID")));
			}
				
			code.setEquipmentnamekor(row.getString("EQUIPMENTNAMEKOR"));
			code.setEquipmentnameeng(row.getString("EQUIPMENTNAMEENG"));
			code.setEquipmentnamejpn(row.getString("EQUIPMENTNAMEJPN"));
			code.setEquipmenttype(row.getString("EQUIPMENTTYPE"));
			code.setEquipmentclassid(row.getString("EQUIPMENTCLASSID"));
			code.setAreaid(row.getString("AREAID"));
			code.setProcessdefid(row.getString("PROCESSDEFID"));
			code.setDepartmentid(row.getString("DEPARTMENTID"));
			code.setAssetno(row.getString("ASSETNO"));
			code.setIfstate(row.getString("IFSTATE"));
			code.setValidstate(row.getString("VALIDSTATE"));
			code.setDescription(row.getString("DESCRIPTION"));

			return code;
		}

		// Delete Code
		private EquipmentData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			EquipmentData code = new EquipmentData();
			EquipmentKey codeKey = code.key();

			codeKey.setEquipmentid(row.getString("EQUIPMENTID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("EQUIPMENTID")));
			}
			
			return code;
		}
	
	
	/*
	// Insert Code
	private UlEquipmentData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlEquipmentData code = new UlEquipmentData();
		UlEquipmentKey codeKey = code.key();

		codeKey.setEquipcode(row.getString("EQUIPCODE"));

		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("EQUIPCODE")));
		}
		
		UlEquipmentData newCode = new UlEquipmentData();
		UlEquipmentKey newCodeKey = newCode.key();

		newCodeKey.setEquipcode(row.getString("EQUIPCODE"));
		
		newCode.setEquipnamekor(row.getString("EQUIPNAMEKOR"));
		newCode.setEquipnameeng(row.getString("EQUIPNAMEENG"));
		newCode.setEquipnamejpn(row.getString("EQUIPNAMEJPN"));
		newCode.setEquipcodeparent(row.getString("EQUIPCODEPARENT"));
		newCode.setBigo(row.getString("BIGO"));
		newCode.setEquiptype(row.getString("EQUIPTYPE"));
		newCode.setEquipgroup(row.getString("EQUIPGROUP"));
		newCode.setAreacode(row.getString("AREACODE"));
		newCode.setProcesscode(row.getString("PROCESSCODE"));
		newCode.setDeptcode(row.getString("DEPTCODE"));
		newCode.setAssetno(row.getString("ASSETNO"));
		newCode.setIfstate(row.getString("IFSTATE"));
		newCode.setValidstate(row.getString("VALIDSTATE"));
		
		return newCode;
	}
	
	// Update Code
	private UlEquipmentData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlEquipmentData code = new UlEquipmentData();
		UlEquipmentKey codeKey = code.key();

		codeKey.setEquipcode(row.getString("EQUIPCODE"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("EQUIPCODE")));
		}
			
		code.setEquipnamekor(row.getString("EQUIPNAMEKOR"));
		code.setEquipnameeng(row.getString("EQUIPNAMEENG"));
		code.setEquipnamejpn(row.getString("EQUIPNAMEJPN"));
		code.setEquipcodeparent(row.getString("EQUIPCODEPARENT"));
		code.setBigo(row.getString("BIGO"));
		code.setEquiptype(row.getString("EQUIPTYPE"));
		code.setEquipgroup(row.getString("EQUIPGROUP"));
		code.setAreacode(row.getString("AREACODE"));
		code.setProcesscode(row.getString("PROCESSCODE"));
		code.setDeptcode(row.getString("DEPTCODE"));
		code.setAssetno(row.getString("ASSETNO"));
		code.setIfstate(row.getString("IFSTATE"));
		code.setValidstate(row.getString("VALIDSTATE"));

		return code;
	}

	// Delete Code
	private UlEquipmentData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlEquipmentData code = new UlEquipmentData();
		UlEquipmentKey codeKey = code.key();

		codeKey.setEquipcode(row.getString("EQUIPCODE"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("EQUIPCODE")));
		}
		
		return code;
	}
	*/
}
