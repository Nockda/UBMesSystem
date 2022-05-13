package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlEquipmentparameterData;
import kr.co.micube.common.mes.so.UlEquipmentparameterKey;
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
 * 프  로  그  램  명	: 기준정보 > 설비 관리 > 설비별 Parameter 관리
 * 설               명	: 설비별 Parameter를 저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-04-06
 * 수   정   이   력	: 
 */
public class SaveEquipParameter extends DatasetRule {
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
		private UlEquipmentparameterData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlEquipmentparameterData code = new UlEquipmentparameterData();
			UlEquipmentparameterKey codeKey = code.key();

			codeKey.setEquipmentid(row.getString("EQUIPMENTID"));
			codeKey.setParameterid(row.getString("PARAMETERID"));

			code = code.selectOne();
			
			if (code != null)
			{
				throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("EQUIPMENTID") + "|" + row.getString("PARAMETERID")));
			}
			
			UlEquipmentparameterData newCode = new UlEquipmentparameterData();
			UlEquipmentparameterKey newCodeKey = newCode.key();

			newCodeKey.setEquipmentid(row.getString("EQUIPMENTID"));
			newCodeKey.setParameterid(row.getString("PARAMETERID"));
			
			newCode.setParameternamekor(row.getString("PARAMETERNAMEKOR"));
			newCode.setParameternameeng(row.getString("PARAMETERNAMEENG"));
			newCode.setParameternamejpn(row.getString("PARAMETERNAMEJPN"));
			newCode.setParameterlevel(row.getString("PARAMETERLEVEL"));
			newCode.setUnit(row.getString("UNIT"));
			newCode.setDataformat(row.getString("DATAFORMAT"));
			newCode.setLowerspeclimit(row.getDouble("LOWERSPECLIMIT"));
			newCode.setTarget(row.getDouble("TARGET"));
			newCode.setUpperspeclimit(row.getDouble("UPPERSPECLIMIT"));
			newCode.setGathercycle(row.getInteger("GATHERCYCLE"));
			newCode.setLimittime(row.getInteger("LIMITTIME"));
			newCode.setManagestate(row.getString("MANAGESTATE"));
			newCode.setLowercontrollimit(row.getDouble("LOWERCONTROLLIMIT"));
			newCode.setAveragevalue(row.getDouble("AVERAGEVALUE"));
			newCode.setUppercontrollimit(row.getDouble("UPPERCONTROLLIMIT"));
			newCode.setSvparameterid(row.getString("SVPARAMETERID"));
			newCode.setSvrate(row.getDouble("SVRATE"));
			newCode.setInterlockstate(row.getString("INTERLOCKSTATE"));
			newCode.setDescription(row.getString("DESCRIPTION"));
			newCode.setValidstate(row.getString("VALIDSTATE"));
			
			return newCode;
		}
		
		// Update Code
		private UlEquipmentparameterData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlEquipmentparameterData code = new UlEquipmentparameterData();
			UlEquipmentparameterKey codeKey = code.key();

			codeKey.setEquipmentid(row.getString("EQUIPMENTID"));
			codeKey.setParameterid(row.getString("PARAMETERID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("EQUIPMENTID") + "|" + row.getString("PARAMETERID")));
			}
				
			code.setParameternamekor(row.getString("PARAMETERNAMEKOR"));
			code.setParameternameeng(row.getString("PARAMETERNAMEENG"));
			code.setParameternamejpn(row.getString("PARAMETERNAMEJPN"));
			code.setParameterlevel(row.getString("PARAMETERLEVEL"));
			code.setUnit(row.getString("UNIT"));
			code.setDataformat(row.getString("DATAFORMAT"));
			code.setLowerspeclimit(row.getDouble("LOWERSPECLIMIT"));
			code.setTarget(row.getDouble("TARGET"));
			code.setUpperspeclimit(row.getDouble("UPPERSPECLIMIT"));
			code.setGathercycle(row.getInteger("GATHERCYCLE"));
			code.setLimittime(row.getInteger("LIMITTIME"));
			code.setManagestate(row.getString("MANAGESTATE"));
			code.setLowercontrollimit(row.getDouble("LOWERCONTROLLIMIT"));
			code.setAveragevalue(row.getDouble("AVERAGEVALUE"));
			code.setUppercontrollimit(row.getDouble("UPPERCONTROLLIMIT"));
			code.setSvparameterid(row.getString("SVPARAMETERID"));
			code.setSvrate(row.getDouble("SVRATE"));
			code.setInterlockstate(row.getString("INTERLOCKSTATE"));
			code.setDescription(row.getString("DESCRIPTION"));
			code.setValidstate(row.getString("VALIDSTATE"));

			return code;
		}

		// Delete Code
		private UlEquipmentparameterData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlEquipmentparameterData code = new UlEquipmentparameterData();
			UlEquipmentparameterKey codeKey = code.key();

			codeKey.setEquipmentid(row.getString("EQUIPMENTID"));
			codeKey.setParameterid(row.getString("PARAMETERID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("EQUIPMENTID") + "|" + row.getString("PARAMETERID")));
			}
			
			return code;
		}
	
}
