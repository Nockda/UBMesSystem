package kr.co.micube.mes.standard.rule;

import java.text.ParseException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.SfEquipmentData;
import kr.co.micube.common.mes.so.SfEquipmentKey;
import kr.co.micube.common.mes.util.CommonUtils;
import kr.co.micube.common.mes.util.LanguageUtils;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.standard.service.IdService;
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
 * 프  로  그  램  명	: 기준정보 > 코드관리 > 설비코드
 * 설               명	: 설비를 등록하는 룰이다.
 * 생      성      자	: 유태근
 * 생      성      일	: 2020-06-05
 * 수   정   이   력	: 
 */
public class SaveEquipment extends DatasetRule {
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
	 * SF_EQUIPMENT INSERT
	****************************************************************************/
	private SfEquipmentData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws ParseException, Throwable
	{
		SfEquipmentData data = new SfEquipmentData();
		SfEquipmentKey key = data.key();
		
		String equipmentId = CreateEquipmentId(TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData()), row.getString("EQUIPMENTCLASSID"));

		key.setEquipmentid(equipmentId);

		
		
		data = data.selectOne();
		int num = Integer.parseInt(equipmentId.substring(4,7));
		String equipment_head = equipmentId.substring(0,4);
		while(data != null) // 체번 중복 체크
		{
			num = num+1;
			equipmentId = String.format("%03d", num); 
			data = new SfEquipmentData();
			key = data.key();
			equipmentId = equipment_head + equipmentId;
			key.setEquipmentid(equipmentId);
			
			data = data.selectOne();
			

		}
		
		
		
		
		SfEquipmentData newData = new SfEquipmentData();
		SfEquipmentKey newKey = newData.key();
		String dictionaryId = Generate.createID();

		newKey.setEquipmentid(equipmentId);	
		
		newData.setEnterpriseid(row.getString("ENTERPRISEID"));
		newData.setEquipmentname(row.getString("EQUIPMENTNAME$$KO-KR"));
		newData.setPlantid(row.getString("PLANTID"));
		newData.setEquipmenttype(row.getString("EQUIPMENTTYPE"));
		newData.setEquipmentclassid(row.getString("EQUIPMENTCLASSID"));
		newData.setAreaid(row.getString("AREAID"));
		newData.setProcessdefid(row.getString("PROCESSDEFID"));
		newData.setDepartment(row.getString("DEPARTMENT"));
		newData.setAssetno(row.getString("ASSETNO"));
		newData.setIfstate(row.getString("IFSTATE"));
		newData.setState(row.getString("STATE"));
		newData.setIsdailycheck(row.getString("ISDAILYCHECK"));
		newData.setDescription(row.getString("DESCRIPTION"));
		newData.setValidstate(row.getString("VALIDSTATE"));
		newData.setLasttxnid(TransactionId.CREATE);
		newData.setDictionaryid(dictionaryId);
		
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
			
		for (String lang : languageTypes) {
			if (!row.containsKey(SfEquipmentData.Equipmentname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(SfEquipmentData.Equipmentname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		return newData;
	}
		
	/***************************************************************************
	 * SF_EQUIPMENT UPDATE
	****************************************************************************/
	private SfEquipmentData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfEquipmentData data = new SfEquipmentData();
		SfEquipmentKey key = data.key();

		key.setEquipmentid(row.getString("EQUIPMENTID"));
		
		data = data.selectOne();
		
		if (data == null)
		{
			throw new InValidDataException("InValidData001", String.format("EQUIPMENTID = %s", row.getString("EQUIPMENTID")));
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
		data.setEquipmentname(row.getString("EQUIPMENTNAME$$KO-KR"));
		data.setEquipmenttype(row.getString("EQUIPMENTTYPE"));
		data.setEquipmentclassid(row.getString("EQUIPMENTCLASSID"));
		data.setAreaid(row.getString("AREAID"));
		data.setProcessdefid(row.getString("PROCESSDEFID"));
		data.setDepartment(row.getString("DEPARTMENT"));
		data.setAssetno(row.getString("ASSETNO"));
		data.setIfstate(row.getString("IFSTATE"));
		
		data.setState(row.getString("STATE"));
		data.setIsdailycheck(row.getString("ISDAILYCHECK"));
		data.setDescription(row.getString("DESCRIPTION"));
		data.setValidstate(row.getString("VALIDSTATE"));
		data.setLasttxnid(TransactionId.MODIFY);
		
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
			
		for (String lang : languageTypes) {
			if (!row.containsKey(SfEquipmentData.Equipmentname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(SfEquipmentData.Equipmentname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);

		return data;
	}

	/***************************************************************************
	 * SF_EQUIPMENT DELETE
	****************************************************************************/
	private SfEquipmentData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfEquipmentData data = new SfEquipmentData();
		SfEquipmentKey key = data.key();

		key.setEquipmentid(row.getString("EQUIPMENTID"));
		
		data = data.selectOne();
		
		if (data == null)
		{
			throw new InValidDataException("InValidData003", String.format("EQUIPMENTID = %s", row.getString("EQUIPMENTID")));
		}
		
 		// 다국어
		String dictionaryId = data.getDictionaryid();
		CommonUtils.deleteDictionaryData(batch, dictionaryId);
		
		data.setLasttxnid(TransactionId.DELETE);
		
		return data;
	}
		
	/********************************************************************************************
	 * SF_EQUIPMENT EQUIPMENTID(설비ID) 채번
	 * @param trans : 트랜잭션 정보
	*********************************************************************************************/
	private String CreateEquipmentId(TxnInfo trans, String eqpClassId) throws Throwable 
	{		
		List<String> list = new ArrayList<String>();
		list.add(eqpClassId);
		
		List<String> idList = IdService.createId("EquipmentId", 1, list, trans);
		
		return idList.get(0).toString();
	}
}
