package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlCellData;
import kr.co.micube.common.mes.so.UlCellgroupData;
import kr.co.micube.common.mes.so.UlCellgroupKey;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 기준정보 > 창고관리 > CELL관리
 * 설               명	: 창고 랙 관리 데이터를 수정한다.
 * 생      성      자	: jylee
 * 생      성      일	: 2020-04-15
 * 수   정   이   력	: 2020-04-21 | JYLEE | 랙관리 => CELL관리
 * 				  2020-06-11 | JYLEE | 테이블 정보 변경에 따른 RULE 수정 
 */
public class SaveCellGroup extends DatasetRule{

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
					getInsertData(row, batch);
					break;
				case UpsertState.UPDATE:
					getUpdateData(row, batch);
					break;
				case UpsertState.DELETE:
					getDeleteData(row, batch);
					break;
			}
		}
		batch.execute();
	}
	
	//INSERT
	private void getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		UlCellgroupData cellGroupData = new UlCellgroupData();
		UlCellgroupKey cellGroupKey = cellGroupData.key();
		
		cellGroupKey.setCellgroupid(row.getString("CELLGROUPID"));
		
		cellGroupData = cellGroupData.selectOne();
		
		if (cellGroupData != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("CELLGROUPID")));
		}
		
		UlCellgroupData newCellGroupData = new UlCellgroupData();
		UlCellgroupKey newCellGroupKey = newCellGroupData.key();
		
		newCellGroupKey.setCellgroupid(row.getString("CELLGROUPID"));
		newCellGroupData.setCellgroupname(row.getString("CELLGROUPNAME"));
		newCellGroupData.setWarehouseid(row.getString("WAREHOUSEID"));
		newCellGroupData.setType(row.getString("TYPE"));
		newCellGroupData.setTeamid(row.getString("TEAM"));
		newCellGroupData.setDescription(row.getString("DESCRIPTION"));
		newCellGroupData.setMainuserid(row.getString("MAINUSERID"));
		newCellGroupData.setSubuserid(row.getString("SUBUSERID"));
		newCellGroupData.setValidstate(row.getString("VALIDSTATE"));
		
		batch.add(newCellGroupData,SQLUpsertType.INSERT);

		
		
	}
	
	//UPDATE
	private void getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		UlCellgroupData cellGroupData = new UlCellgroupData();
		UlCellgroupKey cellGroupKey = cellGroupData.key();
		
		cellGroupKey.setCellgroupid(row.getString("CELLGROUPID"));
		
		cellGroupData = cellGroupData.selectOne();
		
		if (cellGroupData == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("CELLGROUPID")));
		}
		
		cellGroupKey.setCellgroupid(row.getString("CELLGROUPID"));
		cellGroupData.setCellgroupname(row.getString("CELLGROUPNAME"));
		cellGroupData.setTeamid(row.getString("TEAM"));
		cellGroupData.setWarehouseid(row.getString("WAREHOUSEID"));
		cellGroupData.setType(row.getString("TYPE"));
		cellGroupData.setDescription(row.getString("DESCRIPTION"));
		cellGroupData.setMainuserid(row.getString("MAINUSERID"));
		cellGroupData.setSubuserid(row.getString("SUBUSERID"));
		cellGroupData.setValidstate(row.getString("VALIDSTATE"));
		
		batch.add(cellGroupData, SQLUpsertType.UPDATE);
	}
	
	//DELETE
	private void getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException {
		// 셀그룹 삭제
		UlCellgroupData cellGroupData = new UlCellgroupData();
		UlCellgroupKey cellGroupKey = cellGroupData.key();
		cellGroupKey.setCellgroupid(row.getString("CELLGROUPID"));
		cellGroupData = cellGroupData.selectOne();
		batch.add(cellGroupData, SQLUpsertType.DELETE);
		
		// 셀 삭제
		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlCellData.Cellgroupid, row.getString("CELLGROUPID"));
		UlCellData cellData = new UlCellData();
		ISQLDataList<UlCellData> cellList = cellData.select(cond);
		for(int i = 0; i < cellList.size(); i++) {
			batch.add(cellList.get(i), SQLUpsertType.DELETE);
		}
	}
}
