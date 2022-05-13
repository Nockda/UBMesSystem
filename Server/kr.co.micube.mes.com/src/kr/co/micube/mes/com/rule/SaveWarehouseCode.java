package kr.co.micube.mes.com.rule;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.SfWarehouseData;
import kr.co.micube.common.mes.so.SfWarehouseKey;
import kr.co.micube.common.mes.util.CommonUtils;
import kr.co.micube.common.mes.util.LanguageUtils;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 기준정보 > 코드관리 > 창고코드
 * 설               명	: 코드그룹 정보 화면에서 변경된 데이터를 저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-03-05
 * 수   정   이   력	: 
 */
public class SaveWarehouseCode extends DatasetRule {
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
	private SfWarehouseData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfWarehouseData code = new SfWarehouseData();
		SfWarehouseKey codeKey = code.key();

		codeKey.setWarehouseid(row.getString("WAREHOUSEID"));

		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("WAREHOUSECODE")));
		}
		
		SfWarehouseData newCode = new SfWarehouseData();
		codeKey = newCode.key();
		
		codeKey.setWarehouseid(row.getString("WAREHOUSEID"));
		
		newCode.setWarehousename(row.getString("WAREHOUSENAME$$KO-KR"));
		newCode.setWarehousetype(row.getString("WAREHOUSETYPE"));
		newCode.setDepartmentid(row.getString("DEPARTMENTID"));
		newCode.setDescription(row.getString("DESCRIPTION"));
		newCode.setWarehouseseq(row.getInteger("WAREHOUSESEQ"));
		newCode.setValidstate(row.getString("VALIDSTATE"));
		String dictionaryId = Generate.createID();
		newCode.setDictionaryid(dictionaryId);
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
			
		for (String lang : languageTypes) {
			if (!row.containsKey(SfWarehouseData.Warehousename.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(SfWarehouseData.Warehousename.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		
		
		return newCode;
	}
	
	// Update Code
	private SfWarehouseData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfWarehouseData code = new SfWarehouseData();
		SfWarehouseKey codeKey = code.key();

		codeKey.setWarehouseid(row.getString("WAREHOUSEID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("WAREHOUSECODE")));
		}
		
		// 다국어
		String dictionaryId = code.getDictionaryid();
		if(StringUtils.isNullOrEmpty(dictionaryId))
		{
			dictionaryId = Generate.createID();
			code.setDictionaryid(dictionaryId);
		}
		
		
		
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
			
		for (String lang : languageTypes) {
			if (!row.containsKey(SfWarehouseData.Warehousename.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(SfWarehouseData.Warehousename.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		code.setWarehousename(row.getString("WAREHOUSENAME$$KO-KR"));
		code.setWarehousetype(row.getString("WAREHOUSETYPE"));
		code.setDepartmentid(row.getString("DEPARTMENTID"));
		code.setDescription(row.getString("DESCRIPTION"));
		code.setWarehouseseq(row.getInteger("WAREHOUSESEQ"));		
		code.setValidstate(row.getString("VALIDSTATE"));
		

		return code;
	}

	// Delete Code
	private SfWarehouseData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfWarehouseData code = new SfWarehouseData();
		SfWarehouseKey codeKey = code.key();

		codeKey.setWarehouseid(row.getString("WAREHOUSEID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("WAREHOUSECODE")));
		}
		
		return code;
	}
}
