package kr.co.micube.mes.standard.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.SfLabeldefinitionData;
import kr.co.micube.common.mes.so.SfLabeldefinitionKey;
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
 * 프  로  그  램  명	: 기준정보 > 항목관리 > 라벨 디자인
 * 설               명	: 바코드라벨관리에서 라벨 디자인정보(LABELDATA 컬럼)을 제외하고 저장한다
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-05-20
 * 수   정   이   력	: 
 * 				  
 */
public class SaveLabelForm extends DatasetRule {
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
		SfLabeldefinitionData data = new SfLabeldefinitionData();
		SfLabeldefinitionKey key = data.key();
		key.setLabelid(row.getString(SfLabeldefinitionData.Labelid));
		data = data.selectOne();
		
		if(data != null) {
			// 생성할 데이터가 이미 존재합니다.({0})
			throw new InValidDataException("InValidData002", String.format("LabelId=%s"
					, row.getString(SfLabeldefinitionData.Labelid)));
		}
		
		// 데이터 생성
		SfLabeldefinitionData newData = new SfLabeldefinitionData();
		SfLabeldefinitionKey newKey = newData.key();
		newKey.setLabelid(row.getString(SfLabeldefinitionData.Labelid));
		newData.setLabelname(row.getString(SfLabeldefinitionData.Labelname));
		newData.setLabeltype(row.getString(SfLabeldefinitionData.Labeltype));
		newData.setPageheight(row.getDouble(SfLabeldefinitionData.Pageheight));
		newData.setPagewidth(row.getDouble(SfLabeldefinitionData.Pagewidth));
		newData.setFilename(row.getString(SfLabeldefinitionData.Filename));
		newData.setFileext(row.getString(SfLabeldefinitionData.Fileext));
		newData.setQueryid(row.getString(SfLabeldefinitionData.Queryid));
		newData.setQueryversion(row.getString(SfLabeldefinitionData.Queryversion));
		newData.setDescription(row.getString(SfLabeldefinitionData.Description));
		newData.setValidstate(row.getString(SfLabeldefinitionData.Validstate));
		return newData;
	}

	private ISQLData getUpdateData(IDataRow row)throws InValidDataException, DatabaseException, MESException, SystemException {
		SfLabeldefinitionData data = new SfLabeldefinitionData();
		SfLabeldefinitionKey key = data.key();
		key.setLabelid(row.getString(SfLabeldefinitionData.Labelid));
		data = data.selectOne();
		
		if(data == null) {
			// 수정할 데이터가 존재하지 않습니다.({0})
			throw new InValidDataException("InValidData001", String.format("LabelId=%s"
					, row.getString(SfLabeldefinitionData.Labelid)));
		}

		data.setLabelname(row.getString(SfLabeldefinitionData.Labelname));
		data.setLabeltype(row.getString(SfLabeldefinitionData.Labeltype));
		data.setPageheight(row.getDouble(SfLabeldefinitionData.Pageheight));
		data.setPagewidth(row.getDouble(SfLabeldefinitionData.Pagewidth));
		data.setFilename(row.getString(SfLabeldefinitionData.Filename));
		data.setFileext(row.getString(SfLabeldefinitionData.Fileext));
		data.setQueryid(row.getString(SfLabeldefinitionData.Queryid));
		data.setQueryversion(row.getString(SfLabeldefinitionData.Queryversion));
		data.setDescription(row.getString(SfLabeldefinitionData.Description));
		data.setValidstate(row.getString(SfLabeldefinitionData.Validstate));
		return data;
	}

	private ISQLData getDeleteData(IDataRow row)throws InValidDataException, DatabaseException, MESException, SystemException {
		SfLabeldefinitionData data = new SfLabeldefinitionData();
		SfLabeldefinitionKey key = data.key();
		key.setLabelid(row.getString(SfLabeldefinitionData.Labelid));
		data = data.selectOne();
		
		if(data == null) {
			// 삭제할 데이터가 존재하지 않습니다.({0})
			throw new InValidDataException("InValidData003", String.format("LabelId=%s"
					, row.getString(SfLabeldefinitionData.Labelid)));
		}
		return data;
	}
}
