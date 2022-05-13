package kr.co.micube.mes.standard.rule;

import java.util.List;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.common.mes.so.SfEquipmentclassData;
import kr.co.micube.common.mes.so.SfEquipmentclassKey;
import kr.co.micube.common.mes.util.CommonUtils;
import kr.co.micube.common.mes.util.LanguageUtils;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.standard.service.IdService;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명   : 기준정보 > 코드관리 > 설비그룹
 * 설               명   : 설비그룹을 등록하는 룰이다.
 * 생      성      자   : 유태근
 * 생      성      일   : 2020-06-05 
 * 수   정   이   력   : 
 */

public class SaveEquipmentClass extends  DatasetRule {

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
	

	/***************************************************************************
	 * SF_EQUIPMENTCLASS INSERT
	****************************************************************************/
	private SfEquipmentclassData getInsertData(IDataRow row, ISQLUpsertBatch batch)throws ParseException, Throwable {
		
		SfEquipmentclassData data = new SfEquipmentclassData();
		SfEquipmentclassKey key = data.key();
		
		String equipmentClassId = CreateEquipmentClassId(TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData()));
				
		key.setEquipmentclassid(equipmentClassId);
		
		data = data.selectOne();
		
		if (data != null)
		{
			throw new InValidDataException("InValidData002", String.format("EQUIPMENTCLASSID = %s", row.getString("EQUIPMENTCLASSID")));
		}
		
		SfEquipmentclassData newData = new SfEquipmentclassData();
		SfEquipmentclassKey newKey = newData.key();
		String dictionaryId = Generate.createID();
		
		newKey.setEquipmentclassid(equipmentClassId); 
		
		newData.setEnterpriseid(row.getString("ENTERPRISEID"));
		newData.setPlantid(row.getString("PLANTID"));
		newData.setEquipmentclassname(row.getString("EQUIPMENTCLASSNAME$$KO-KR"));
		newData.setDescription(row.getString("DESCRIPTION"));
		newData.setValidstate(row.getString("VALIDSTATE"));
		newData.setLasttxnid(TransactionId.CREATE);
		newData.setDictionaryid(dictionaryId);
				
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
			
		for (String lang : languageTypes) {
			if (!row.containsKey(SfEquipmentclassData.Equipmentclassname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(SfEquipmentclassData.Equipmentclassname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		return newData;
	}
	
	/***************************************************************************
	 * SF_EQUIPMENTCLASS UPDATE
	****************************************************************************/
	private SfEquipmentclassData getUpdateData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		
		SfEquipmentclassData data = new SfEquipmentclassData();
		SfEquipmentclassKey key = data.key();
		
		key.setEquipmentclassid(row.getString("EQUIPMENTCLASSID"));
		
		data = data.selectOne();
		
		if (data == null)
		{
			throw new InValidDataException("InValidData001", String.format("EQUIPMENTCLASSID = %s", row.getString("EQUIPMENTCLASSID")));
		}
		
		// 다국어
		String dictionaryId = data.getDictionaryid();
		if (StringUtils.isNullOrEmpty(dictionaryId))
		{
			dictionaryId = Generate.createID();
			data.setDictionaryid(dictionaryId);
		}
		
		data.setEnterpriseid(row.getString("ENTERPRISEID"));
		data.setPlantid(row.getString("PLANTID"));
		data.setEquipmentclassname(row.getString("EQUIPMENTCLASSNAME$$KO-KR"));
		data.setDescription(row.getString("DESCRIPTION"));
		data.setValidstate(row.getString("VALIDSTATE"));
		data.setLasttxnid(TransactionId.MODIFY);
		
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(SfEquipmentclassData.Equipmentclassname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(SfEquipmentclassData.Equipmentclassname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
			
		return data;
	}
	
	/***************************************************************************
	 * SF_EQUIPMENTCLASS DELETE
	****************************************************************************/
	private SfEquipmentclassData getDeleteData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		
		SfEquipmentclassData data = new SfEquipmentclassData();
		SfEquipmentclassKey key = data.key();
		
		key.setEquipmentclassid(row.getString("EQUIPMENTCLASSID"));
		
		data = data.selectOne();
		
		if (data == null) 
		{
			throw new MESException("InValidData003", String.format("EQUIPMENTCLASSID = %s", row.getString("EQUIPMENTCLASSID")));
		}
		
 		// 다국어
		String dictionaryId = data.getDictionaryid();
		CommonUtils.deleteDictionaryData(batch, dictionaryId);
		
		data.setLasttxnid(TransactionId.DELETE);
		
		return data;
	}
	
	/********************************************************************************************
	 * SF_EQUIPMENTCLASS EQUIPMENTCLASSID(설비그룹ID) 채번
	 * @param trans : 트랜잭션 정보
	*********************************************************************************************/
	private String CreateEquipmentClassId(TxnInfo trans) throws Throwable 
	{	
		List<String> list = new ArrayList<String>();
		
  		List<String> idList = IdService.createId("EquipmentClassId", 1, list, trans);
  		
  		return idList.get(0).toString();
	}

}
