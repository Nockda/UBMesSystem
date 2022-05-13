package kr.co.micube.mes.standard.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.SfLabelmapData;
import kr.co.micube.common.mes.so.SfLabelmapKey;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLData;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 기준정보 > 항목관리 > 라벨 맵핑
 * 설               명	: 라벨과 품목/팀간의 맵핑정보를 저장한다.
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-05-21
 * 수   정   이   력	: 
 * 				  
 */

public class SaveLabelMap extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		for (int i = 0; i < dt.size(); i++) {
			IDataRow row = dt.getRow(i);
			String state = row.getString("_STATE_");
			
			switch (state) {
				case UpsertState.INSERT:
					batch.add(getInsertData(row), SQLUpsertType.INSERT);
					break;
				case UpsertState.UPDATE:
					batch.add(getUpdateData(row), SQLUpsertType.UPDATE);
					break;
				case UpsertState.DELETE:
					batch.add(getDeleteData(row), SQLUpsertType.DELETE);
					break;
			}
		}
		batch.execute();
	}
	
	private ISQLData getInsertData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException {
		// 중복검사
		SfLabelmapData data = new SfLabelmapData();
		SfLabelmapKey key = data.key();
		key.setProductdefid(row.getString(SfLabelmapData.Productdefid));
		key.setProductdefversion(row.getString(SfLabelmapData.Productdefversion));
		key.setLabelid(row.getString(SfLabelmapData.Labelid));
		data = data.selectOne();
		
		if(data != null) {
			// 생성할 데이터가 이미 존재합니다.({0})
			throw new InValidDataException("InValidData002", String.format("ProductDefId=%s, ProductDefVersion=%s, LabelId=%s"
					, row.getString(SfLabelmapData.Productdefid), row.getString(SfLabelmapData.Productdefversion)
					, row.getString(SfLabelmapData.Labelid)));
		}
		
		// 데이터 생성
		SfLabelmapData newData = new SfLabelmapData();
		SfLabelmapKey newKey = newData.key();
		newKey.setProductdefid(row.getString(SfLabelmapData.Productdefid));
		newKey.setProductdefversion(row.getString(SfLabelmapData.Productdefversion));
		newKey.setLabelid(row.getString(SfLabelmapData.Labelid));
		newData.setDescription(row.getString(SfLabelmapData.Description));
		newData.setValidstate(Constant.VALIDSTATE_VALID);
		return newData;
	}

	private ISQLData getUpdateData(IDataRow row)throws InValidDataException, DatabaseException, MESException, SystemException {
		SfLabelmapData data = new SfLabelmapData();
		SfLabelmapKey key = data.key();
		key.setProductdefid(row.getString(SfLabelmapData.Productdefid));
		key.setProductdefversion(row.getString(SfLabelmapData.Productdefversion));
		key.setLabelid(row.getString(SfLabelmapData.Labelid));
		data = data.selectOne();
		
		if(data == null) {
			// 수정할 데이터가 존재하지 않습니다.({0})
			throw new InValidDataException("InValidData001", String.format("ProductDefId=%s, ProductDefVersion=%s, LabelId=%s"
					, row.getString(SfLabelmapData.Productdefid), row.getString(SfLabelmapData.Productdefversion)
					, row.getString(SfLabelmapData.Labelid)));
		}

		data.setDescription(row.getString(SfLabelmapData.Description));
		return data;
	}

	private ISQLData getDeleteData(IDataRow row)throws InValidDataException, DatabaseException, MESException, SystemException {
		SfLabelmapData data = new SfLabelmapData();
		SfLabelmapKey key = data.key();
		key.setProductdefid(row.getString(SfLabelmapData.Productdefid));
		key.setProductdefversion(row.getString(SfLabelmapData.Productdefversion));
		key.setLabelid(row.getString(SfLabelmapData.Labelid));
		data = data.selectOne();
		
		if(data == null) {
			// 삭제할 데이터가 존재하지 않습니다.({0})
			throw new InValidDataException("InValidData003", String.format("ProductDefId=%s, ProductDefVersion=%s, LabelId=%s"
					, row.getString(SfLabelmapData.Productdefid), row.getString(SfLabelmapData.Productdefversion)
					, row.getString(SfLabelmapData.Labelid)));
		}
		return data;
	}
}
