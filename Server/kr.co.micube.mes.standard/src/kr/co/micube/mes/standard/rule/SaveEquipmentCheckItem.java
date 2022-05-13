package kr.co.micube.mes.standard.rule;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.so.SfMaintitemData;
import kr.co.micube.common.mes.so.SfMaintitemKey;
import kr.co.micube.common.mes.util.CommonUtils;
import kr.co.micube.common.mes.util.LanguageUtils;
import kr.co.micube.core.util.Generate;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveEquipmentCheckItem extends DatasetRule {

	@Override
	public void doEvent() throws Throwable {
		// Get Message
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		
		for (int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);
			String state = row.getString("_STATE_");
			String Checkitemid = row.getString("MAINTITEMID");
			
			String validState = row.getString("VALIDSTATE");
			
			SfMaintitemData md = new SfMaintitemData();
			SfMaintitemKey mdKey = md.key();
			
			mdKey.setMaintitemid(Checkitemid);
			
			md = md.selectOne();
			
			String dictionaryId = "";
			/*
			if(StringUtils.isNullOrEmpty(dictionaryId))
			{
				dictionaryId = Generate.createID();
				equipmentData.setEquipmentname(dictionaryId);
				
			}
			*/
			if(md ==  null)
			{
				dictionaryId = Generate.createID();
				md =  new SfMaintitemData();
				mdKey = md.key();
				mdKey.setMaintitemid(Checkitemid);
				md.setMaintitemname(row.getString("MAINTITEMNAME$$KO-KR"));
				md.setDictionaryid(dictionaryId);
				md.setValidstate(validState);
				md.setEnterpriseid("ULVAC");
				md.setPlantid("P1");
				batch.add(md, SQLUpsertType.INSERT);
			}
			else if(md != null && state.equals("deleted"))
			{
				batch.add(md, SQLUpsertType.DELETE);
			}
			else
			{
				if(md.getDictionaryid() == "" || md.getDictionaryid() == null)
				{
					dictionaryId = Generate.createID();
				}
				else 
				{
					dictionaryId = md.getDictionaryid();
				}
				md = md.selectOne();
				md.setDictionaryid(dictionaryId);
				md.setMaintitemname(row.getString("MAINTITEMNAME$$KO-KR"));
				md.setValidstate(validState);
				batch.add(md, SQLUpsertType.UPDATE);
			}
			
			Map<String, String> dictionaryMap = new HashMap<>();
			
			List<String> languageTypes = LanguageUtils.getLanguageTypes();
			
			for (String lang : languageTypes) {
				if (!row.containsKey(SfMaintitemData.Maintitemname.toUpperCase() + "$$" + lang.toUpperCase()))
					continue;
				
				dictionaryMap.put(lang, row.getString(SfMaintitemData.Maintitemname.toUpperCase() + "$$" + lang.toUpperCase()));
			}

			//2019-12-27 기준정보 다국어는 description 컬럼에 해당 테이블 명을 update
			CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);			

		}
		
		batch.execute();
		
	}

}
