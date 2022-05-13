package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.SfEquipmentmaintitemData;
import kr.co.micube.common.mes.so.SfEquipmentmaintitemKey;
import kr.co.micube.commons.factory.so.EnterpriseData;
import kr.co.micube.commons.factory.so.PlantData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 기준정보 > 설비점검관리 > 설비그룹별점검항목
 * 설               명	: 설비그룹별 점검항목을 관리한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-03-04
 * 수   정   이   력	: 
 */
public class SaveEquipCheckMapping extends DatasetRule {
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
		private SfEquipmentmaintitemData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			SfEquipmentmaintitemData code = new SfEquipmentmaintitemData();
			SfEquipmentmaintitemKey codeKey = code.key();

			codeKey.setEquipmentclassid(row.getString("EQUIPMENTCLASSID"));
			codeKey.setMaintitemid(row.getString("EQUIPCHECKID"));
			codeKey.setMainttype(row.getString("CHECKTYPE"));

			code = code.selectOne();
			
			if (code != null)
			{
				throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("EQUIPMENTCLASSID") + "|" + row.getString("EQUIPCHECKID") + "|" + row.getString("CHECKTYPE")));
			}
			
			SfEquipmentmaintitemData newCode = new SfEquipmentmaintitemData();
			SfEquipmentmaintitemKey newCodeKey = newCode.key();

			newCodeKey.setEquipmentclassid(row.getString("EQUIPMENTCLASSID"));
			newCodeKey.setMaintitemid(row.getString("EQUIPCHECKID"));
			newCodeKey.setMainttype(row.getString("CHECKTYPE"));
			
			EnterpriseData enterpriseData = new EnterpriseData();
			ISQLDataList<EnterpriseData> enterpriseDataList = enterpriseData.selectAll();
			enterpriseData = enterpriseDataList.get(0);
			
			
			PlantData plantData = new PlantData();
			ISQLDataList<PlantData> plantDataList = plantData.selectAll();
			plantData = plantDataList.get(0);
			
			newCode.setEnterpriseid(enterpriseData.getEnterpriseid());
			newCode.setPlantid(plantData.getPlantid());
			newCode.setResulttype(row.getString("RESULTTYPE"));
			newCode.setMaintsequence(row.getString("MAINTSEQUENCE"));
			newCode.setMaintduration(row.getDouble("CHECKCOUNT"));
			newCode.setMaintdurationunit(row.getString("CHECKCYCLE"));
			newCode.setValidationtype(row.getString("CHECKWAY"));
			newCode.setValidstate(row.getString("VALIDSTATE"));
					
			return newCode;
		}
		
		// Update Code
		private SfEquipmentmaintitemData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			SfEquipmentmaintitemData code = new SfEquipmentmaintitemData();
			SfEquipmentmaintitemKey codeKey = code.key();

			codeKey.setEquipmentclassid(row.getString("EQUIPMENTCLASSID"));
			codeKey.setMaintitemid(row.getString("EQUIPCHECKID"));
			codeKey.setMainttype(row.getString("CHECKTYPE"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("EQUIPMENTCLASSID") + "|" + row.getString("EQUIPCHECKID") + "|" + row.getString("CHECKTYPE")));
			}
				
			code.setResulttype(row.getString("RESULTTYPE"));
			code.setMaintsequence(row.getString("MAINTSEQUENCE"));
			code.setMaintduration(row.getDouble("CHECKCOUNT"));
			code.setMaintdurationunit(row.getString("CHECKCYCLE"));
			code.setValidationtype(row.getString("CHECKWAY"));
			code.setValidstate(row.getString("VALIDSTATE"));

			return code;
		}

		// Delete Code
		private SfEquipmentmaintitemData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			SfEquipmentmaintitemData code = new SfEquipmentmaintitemData();
			SfEquipmentmaintitemKey codeKey = code.key();

			codeKey.setEquipmentclassid(row.getString("EQUIPMENTCLASSID"));
			codeKey.setMaintitemid(row.getString("EQUIPCHECKID"));
			codeKey.setMainttype(row.getString("CHECKTYPE"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("EQUIPMENTCLASSID") + "|" + row.getString("EQUIPCHECKID") + "|" + row.getString("CHECKTYPE")));
			}
			
			return code;
		}

}
