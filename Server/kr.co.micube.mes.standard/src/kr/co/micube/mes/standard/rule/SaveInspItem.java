package kr.co.micube.mes.standard.rule;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.so.CtParameterdefinitionData;
import kr.co.micube.common.mes.so.CtParameterdefinitionKey;
import kr.co.micube.common.mes.util.CommonUtils;
import kr.co.micube.common.mes.util.LanguageUtils;
import kr.co.micube.common.util.QueryProvider;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveInspItem extends DatasetRule {

	@Override
	public void doEvent() throws Throwable {
		// Get Message
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		
		//파라미터 아이디 마지막 시리얼 넘버 불러오기
		List<Map<String, Object>> resultMap = QueryProvider.select("GetLastSerialParameterId", "00001");
		String serialNoSTR = resultMap.get(0).get("NO").toString();
		int serialNoInt = Integer.parseInt(serialNoSTR);
		int serial = 1;
		
		for (int j = 0, len = dt.size(); j<len; j++) {
			row = dt.getRow(j);
			String state = row.getString("_STATE_");
			String itemid = null;
			if(row.getString("PARAMETERID").equals(null)) { //파라미터 아이디가 없는 경우 안채우고, 있다면 row에서 가져옴
			}else {
			itemid = row.getString("PARAMETERID");
			}
			String itemname = row.getString("PARAMETERNAME$$KO-KR");
			String unit = row.getString("UNIT");
			String inputtype = row.getString("INPUTTYPE");
			Double decimalPlace = row.getDouble("DECIMALPLACE");
			String validState = row.getString("VALIDSTATE");
			String parameterType = row.getString("PARAMETERTYPE");
			String codeClassId = row.getString("CODECLASSID");
			String isNotRequired = row.getString("ISNOTREQUIRED");

			CtParameterdefinitionData para = new CtParameterdefinitionData();
			CtParameterdefinitionKey parakey = para.key();
			
			if(row.getString("PARAMETERID").length() == 0) {
				//파라미터 아이디가 없는 경우에는 마지막 숫자를 불러와서 +1 해줌
				serialNoInt = serialNoInt + serial;
				serial = serial + 1;
				serialNoSTR = "IT" + String.format("%05d", serialNoInt);
				itemid = serialNoSTR;
				
				para =  new CtParameterdefinitionData();
				parakey = para.key();
				parakey.setParameterid(serialNoSTR);
				para.setParametername(itemname);
				para.setDictionaryid(serialNoSTR);
 				para.setUnit(unit);
				para.setInputtype(inputtype);
				para.setDecimalplace(decimalPlace);
				para.setValidstate(validState);
				para.setParametertype(parameterType);
				para.setCodeclassid(codeClassId);
				para.setIsnotrequired(isNotRequired);
				batch.add(para, SQLUpsertType.INSERT);
			} else {
				parakey.setParameterid(itemid);
				para = para.selectOne();
				String dictionaryId = "";
				
				if(para != null && state.equals("deleted"))
				{
					//parameterid가 있고 state가 deleted면 delete
					batch.add(para, SQLUpsertType.DELETE);
					
					if(para.getDictionaryid() == "" || para.getDictionaryid() == null)
					{
						dictionaryId =itemid;
					}
					else 
					{
						dictionaryId = para.getDictionaryid();
					}
					CommonUtils.deleteDictionaryData(batch, dictionaryId);
				}
				else
				{
					//나머지는 update
					if(para.getDictionaryid() == "" || para.getDictionaryid() == null)
					{
						dictionaryId =itemid;
					}
					else 
					{
						dictionaryId = para.getDictionaryid();
					}
					para = para.selectOne();
					para.setDictionaryid(dictionaryId);
					para.setUnit(unit);
					para.setParametername(itemname);
					para.setInputtype(inputtype);
					para.setDecimalplace(decimalPlace);
					para.setValidstate(validState);
					para.setParametertype(parameterType);
					para.setCodeclassid(codeClassId);
					para.setIsnotrequired(isNotRequired);
					batch.add(para, SQLUpsertType.UPDATE);
				}
			}
			
			Map<String, String> dictionaryMap = new HashMap<>();
			List<String> languageTypes = LanguageUtils.getLanguageTypes();
			for (String lang : languageTypes) {
				if (!row.containsKey(CtParameterdefinitionData.Parametername.toUpperCase() + "$$" + lang.toUpperCase()))
					continue;
				
				dictionaryMap.put(lang, row.getString(CtParameterdefinitionData.Parametername.toUpperCase() + "$$" + lang.toUpperCase()));
			}

			//2019-12-27 기준정보 다국어는 description 컬럼에 해당 테이블 명을 update
			CommonUtils.appendDictionaryDataClsssAppend(batch, itemid, dictionaryMap, "GRID");	
		}
		batch.execute();
	}
}
