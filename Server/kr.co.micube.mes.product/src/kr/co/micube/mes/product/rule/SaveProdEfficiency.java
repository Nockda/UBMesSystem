package kr.co.micube.mes.product.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlProdefficiencyData;
import kr.co.micube.common.mes.so.UlProdefficiencyKey;
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
 * 프  로  그  램  명	: 생산관리 > 생산관리 > 생산효율
 * 설               명	: 생산효율 데이터를 저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-04-13
 * 수   정   이   력	: 
 */
public class SaveProdEfficiency extends DatasetRule {
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
		private UlProdefficiencyData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlProdefficiencyData code = new UlProdefficiencyData();
			UlProdefficiencyKey codeKey = code.key();

			codeKey.setWorkdate(row.getString("WORKDATE"));
			codeKey.setTeamid(row.getString("TEAMID"));

			code = code.selectOne();
			
			if (code != null)
			{
				throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("WORKDATE") + "|" + row.getString("TEAMID")));
			}
			
			UlProdefficiencyData newCode = new UlProdefficiencyData();
			UlProdefficiencyKey newCodeKey = newCode.key();

			newCodeKey.setWorkdate(row.getString("WORKDATE"));
			newCodeKey.setTeamid(row.getString("TEAMID"));
			
			newCode.setWorkyear(row.getInteger("WORKYEAR"));
			newCode.setWorkmonth(row.getInteger("WORKMONTH"));
			newCode.setWeeknumber(row.getInteger("WEEKNUMBER"));
			newCode.setDayofweek(row.getString("DAYOFWEEK"));
			newCode.setStandworkhour(row.getDouble("STANDWORKHOUR"));
			newCode.setStandtranshour(row.getDouble("STANDTRANSHOUR"));
			newCode.setStandworkercnt(row.getDouble("STANDWORKERCNT"));
			newCode.setWorkhour(row.getDouble("WORKHOUR"));
			newCode.setTranshour(row.getDouble("TRANSHOUR"));
			newCode.setApphour(row.getDouble("APPHOUR"));
			newCode.setSupporthour(row.getDouble("SUPPORTHOUR"));
			newCode.setExtendhour(row.getDouble("EXTENDHOUR"));
			newCode.setHolidayhour(row.getDouble("HOLIDAYHOUR"));
			newCode.setEducationhour(row.getDouble("EDUCATIONHOUR"));
			newCode.setTraininghour(row.getDouble("TRAININGHOUR"));
			newCode.setDispatchhour(row.getDouble("DISPATCHHOUR"));
			newCode.setTotalworkhour(row.getDouble("TOTALWORKHOUR"));
			newCode.setTotalavailablehour(row.getDouble("TOTALAVAILABLEHOUR"));
			newCode.setDescription(row.getString("DESCRIPTION"));

			return newCode;
		}
		
		// Update Code
		private UlProdefficiencyData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlProdefficiencyData code = new UlProdefficiencyData();
			UlProdefficiencyKey codeKey = code.key();

			codeKey.setWorkdate(row.getString("WORKDATE"));
			codeKey.setTeamid(row.getString("TEAMID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("WORKDATE") + "|" + row.getString("TEAMID")));
			}
				
			code.setWorkyear(row.getInteger("WORKYEAR"));
			code.setWorkmonth(row.getInteger("WORKMONTH"));
			code.setWeeknumber(row.getInteger("WEEKNUMBER"));
			code.setDayofweek(row.getString("DAYOFWEEK"));
			//code.setWorkdatetype(row.getString("WORKDATETYPE"));
			code.setStandworkhour(row.getDouble("STANDWORKHOUR"));
			code.setStandtranshour(row.getDouble("STANDTRANSHOUR"));
			code.setStandworkercnt(row.getDouble("STANDWORKERCNT"));
			code.setWorkhour(row.getDouble("WORKHOUR"));
			code.setTranshour(row.getDouble("TRANSHOUR"));
			code.setApphour(row.getDouble("APPHOUR"));
			code.setSupporthour(row.getDouble("SUPPORTHOUR"));
			code.setExtendhour(row.getDouble("EXTENDHOUR"));
			code.setHolidayhour(row.getDouble("HOLIDAYHOUR"));
			code.setEducationhour(row.getDouble("EDUCATIONHOUR"));
			code.setTraininghour(row.getDouble("TRAININGHOUR"));
			code.setDispatchhour(row.getDouble("DISPATCHHOUR"));
			code.setTotalworkhour(row.getDouble("TOTALWORKHOUR"));
			code.setTotalavailablehour(row.getDouble("TOTALAVAILABLEHOUR"));
			code.setDescription(row.getString("DESCRIPTION"));

			return code;
		}

		// Delete Code
		private UlProdefficiencyData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlProdefficiencyData code = new UlProdefficiencyData();
			UlProdefficiencyKey codeKey = code.key();

			codeKey.setWorkdate(row.getString("WORKDATE"));
			codeKey.setTeamid(row.getString("TEAMID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("WORKDATE") + "|" + row.getString("TEAMID")));
			}
			
			return code;
		}

}
