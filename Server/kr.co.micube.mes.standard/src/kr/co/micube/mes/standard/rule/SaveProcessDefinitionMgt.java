package kr.co.micube.mes.standard.rule;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.so.SfProductdefinitionData;
import kr.co.micube.common.mes.so.SfProductdefinitionKey;
import kr.co.micube.common.mes.util.CommonUtils;
import kr.co.micube.common.mes.util.LanguageUtils;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.common.util.QueryProvider;
import kr.co.micube.commons.factory.so.ProcessdefinitionData;
import kr.co.micube.commons.factory.so.ProcessdefinitionKey;
import kr.co.micube.commons.factory.so.ProcesspathData;
import kr.co.micube.commons.factory.so.ProcesspathKey;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.util.Generate;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;


/*
 * 프  로  그  램  명   : 기준정보 > 항목관리 > 품목 라우터 관리
 * 설               명   : 
 * 생      성      자   : 
 * 생      성      일   : 2020-05-20 강유라
 * 수   정   이   력   : 
 */

public class SaveProcessDefinitionMgt extends DatasetRule{

	@Override
	public void doEvent() throws Throwable {
		IMessage msg = this.getMessage().get();
		
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);
		
		//저장 로직 구분
		String type = body.getString("type");
		
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		//다국어 저장용
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		String state = null;
		
		if(type.equals("processDef"))
		{//sf_processdefinition, sf_processpath 저장
			for (int i = 0, len = dt.size(); i < len; i++) {
				
				row = dt.getRow(i);
				state = row.getString("_STATE_");

				switch (state) {
				case UpsertState.INSERT:
					getInsertProcessDefData(row, batch);
					break;

				case UpsertState.UPDATE:
					getUpdateProcessDefData(row, batch);
					break;
					
				case UpsertState.DELETE:
					getDeleteProcessDefData(row, batch);
					break;
				}	
			}
			
			batch.execute();
			
		}
		else if(type.equals("productMapping"))
		{//sf_productdefinition 저장
			for (int i = 0, len = dt.size(); i < len; i++) {
				
				row = dt.getRow(i);
				state = row.getString("_STATE_");

				switch (state) {
				case UpsertState.INSERT:
					getInsertProductMappingData(row);
					break;

				/*=> processdefId 에 매핑되어있는 품목아이디 수정 불가 / 삭제 후 추가
				case UpsertState.UPDATE:
					getUpdateProductMappingData(row);
					break;
				*/
					
				case UpsertState.DELETE:
					getDeleteProductMappingData(row);
					break;
				}
			}
			
		}
		
	}

	//sf_processDefinition, sf_processPath Insert
	private void getInsertProcessDefData(IDataRow row, ISQLUpsertBatch batch) throws Throwable
	{
		//sf_processDefinition Insert
		ProcessdefinitionData processDefData = new ProcessdefinitionData();
		ProcessdefinitionKey processDefKey = processDefData.key();
		
		processDefKey.setProcessdefid(row.getString("PROCESSDEFID"));
		processDefKey.setProcessdefversion("*");
	
		processDefData = processDefData.selectOne();
		
		if(processDefData != null)
		{		
			throw new InValidDataException("InValidData002", String.format("ProcessdefId = %s", row.getString("PROCESSDEFID")));

		}

		String dictionaryId = Generate.createID();
		
		ProcessdefinitionData newProcessDefData = new ProcessdefinitionData();
		ProcessdefinitionKey newProcessDefKey = newProcessDefData.key();
		
		newProcessDefKey.setProcessdefid(row.getString("PROCESSDEFID"));
		newProcessDefKey.setProcessdefversion("*");
		newProcessDefData.setProcessdefname(dictionaryId);		
		newProcessDefData.setProcessdeftype("MAIN");
		newProcessDefData.setValidstate("Valid");
		newProcessDefData.setLasttxnid(TransactionId.CREATE);
		newProcessDefData.setProcessclassid(row.getString("PROCESSCLASSID"));
		
		//다국어 처리
		Map<String, String> dictionaryMap = new HashMap<String, String>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(ProcessdefinitionData.Processdefname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(ProcessdefinitionData.Processdefname.toUpperCase() + "$$" + lang.toUpperCase()));
		}

		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
	
		newProcessDefData.insert();
		
		//sf_processPath Insert
		SimpleDateFormat format = new SimpleDateFormat("yyyyMMddHHmmss");
		Date now = new Date();
		
		String strDate = format.format(now); 
		String processPathId = strDate + row.getString("PROCESSSEGMENTID");
		
		ProcesspathData processPathData = new ProcesspathData();
		ProcesspathKey processPathKey = processPathData.key();
		
		processPathKey.setProcesspathid(processPathId);
		
		processPathData.setProcessdefid(row.getString("PROCESSDEFID"));
		processPathData.setProcessdefversion("*");
		processPathData.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		processPathData.setProcesssegmentversion(row.getString("PROCESSSEGMENTVERSION"));
		processPathData.setPathsequence(1);
		processPathData.setUsersequence("1");
		processPathData.setPathtype("StartEnd");
		processPathData.setValidstate("Valid");
		processPathData.setLasttxnid(TransactionId.CREATE);
		
		processPathData.insert();
				
	}
	
	
	//sf_processDefinition, sf_processPath Update
	private void getUpdateProcessDefData(IDataRow row, ISQLUpsertBatch batch) throws Throwable
	{
		//sf_processDefinition Update
		ProcessdefinitionData processDefData = new ProcessdefinitionData();
		ProcessdefinitionKey processDefKey = processDefData.key();
		
		processDefKey.setProcessdefid(row.getString("PROCESSDEFID"));
		processDefKey.setProcessdefversion("*");
	
		processDefData = processDefData.selectOne();		
		
		if (processDefData == null)
		{
			throw new InValidDataException("InValidData001", String.format("ProcessdefId = %s", row.getString("PROCESSDEFID")));
		}
		
		String dictionaryId = processDefData.getProcessdefname();
		
		if (StringUtils.isNullOrEmpty(dictionaryId))
		{
			dictionaryId = Generate.createID();
			processDefData.setProcessdefname(dictionaryId);
		}
		
		processDefData.setProcessclassid(row.getString("PROCESSCLASSID"));
		
		
		//다국어 처리
		Map<String, String> dictionaryMap = new HashMap<String, String>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(ProcessdefinitionData.Processdefname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(ProcessdefinitionData.Processdefname.toUpperCase() + "$$" + lang.toUpperCase()));
		}

		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		processDefData.setLasttxnid(TransactionId.MODIFY);
		processDefData.update();
		
		//sf_processPath Update
		Map<String, Object> processDefMap = new HashMap<>();
		processDefMap.put("PROCESSDEFID", row.getString("PROCESSDEFID"));
		processDefMap.put("PROCESSDEFVERSION", "*");
		
		List<Map<String, Object>> resultMap = QueryProvider.select("GetProcessPathByProcessDefInfo", "00001", processDefMap);
		String processPathId = "";
		
		if (resultMap.size() > 0)
			processPathId = resultMap.get(0).get("PROCESSPATHID").toString();
		
		ProcesspathData processPathData = new ProcesspathData();
		ProcesspathKey processPathKey = processPathData.key();
		
		processPathKey.setProcesspathid(processPathId);
		processPathData = processPathData.selectOne();
		
		if (processPathData == null)
		{
			throw new InValidDataException("InValidData001", String.format("processpathId = %s", row.getString("PROCESSPATHID")));
		}
		
		processPathData.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		processPathData.setProcesssegmentversion(row.getString("PROCESSSEGMENTVERSION"));
		processPathData.setLasttxnid(TransactionId.MODIFY);
		processPathData.update();
		
	}
	
	//sf_processDefinition, sf_processPath Delete / sf_productDefinition Update
	private void getDeleteProcessDefData(IDataRow row, ISQLUpsertBatch batch) throws Throwable
	{
		//sf_processDefinition Delete
		ProcessdefinitionData processDefData = new ProcessdefinitionData();
		ProcessdefinitionKey processDefKey = processDefData.key();
		
		processDefKey.setProcessdefid(row.getString("PROCESSDEFID"));
		processDefKey.setProcessdefversion("*");
	
		processDefData = processDefData.selectOne();		
		
		if (processDefData == null)
		{
			throw new InValidDataException("InValidData003", String.format("ProcessdefId = %s", row.getString("PROCESSDEFID")));
		}
		
		//다국어 처리
		String dictionaryId = processDefData.getProcessdefname();
		CommonUtils.deleteDictionaryData(batch, dictionaryId);
		
		processDefData.setLasttxnid(TransactionId.DELETE);
		
		
		//sf_processPath Delete
		Map<String, Object> processDefMap = new HashMap<>();
		processDefMap.put("PROCESSDEFID", row.getString("PROCESSDEFID"));
		processDefMap.put("PROCESSDEFVERSION", "*");
		
		List<Map<String, Object>> resultMap = QueryProvider.select("GetProcessPathByProcessDefInfo", "00001", processDefMap);
		String processPathId = "";
		
		if (resultMap.size() > 0)
			processPathId = resultMap.get(0).get("PROCESSPATHID").toString();
		
		ProcesspathData processPathData = new ProcesspathData();
		ProcesspathKey processPathKey = processPathData.key();
		
		processPathKey.setProcesspathid(processPathId);
		processPathData = processPathData.selectOne();
		
		if (processPathData == null)
		{
			throw new InValidDataException("InValidData003", String.format("processpathId = %s", row.getString("PROCESSPATHID")));
		}
		
		processPathData.setLasttxnid(TransactionId.DELETE);
		
			
		//sf_productDefinition Update => ProcessDefId,ProcessDefVersion null
		List<Map<String, Object>> productResultMap = QueryProvider.select("SelectProductMappingListByProcessDefInfo", "00001", processDefMap);
		
		if (productResultMap.size() > 0)
		{
			for (Map<String, Object> map : productResultMap) {
				
				SfProductdefinitionData productData = new SfProductdefinitionData();
				SfProductdefinitionKey productKey = productData.key();
				
				productKey.setProductdefid(map.get("PRODUCTDEFID").toString());
				productKey.setProductdefversion(map.get("PRODUCTDEFVERSION").toString());
				
				productData = productData.selectOne();
				
				productData.setProcessdefid(null);
				productData.setProcessdefversion(null);
				
				productData.setLasttxnid(TransactionId.MODIFY);
				productData.update();
			}			
		}
		
		processDefData.delete();//SelectProductMappingListByProcessDefInfo 조회 후 삭제(Inner Join)
		processPathData.delete();
		
	}
	
	//sf_productDefinition Update => ProcessDefId,ProcessDefVersion
	private void getInsertProductMappingData(IDataRow row) throws Throwable
	{
		SfProductdefinitionData productData = new SfProductdefinitionData();
		SfProductdefinitionKey productKey = productData.key();
		
		productKey.setProductdefid(row.getString("PRODUCTDEFID"));
		productKey.setProductdefversion(row.getString("PRODUCTDEFVERSION"));
		
		productData = productData.selectOne();
		
		if (productData == null)
		{
			throw new InValidDataException("InValidData002", String.format("Productdefid = %s, Productdefversion = %s", row.getString("PARTNUMBER"),row.getString("PRODUCTDEFVERSION")));
		}
		
		productData.setPartnumber(row.getString("PARTNUMBER"));
		productData.setProcessdefid(row.getString("PROCESSDEFID"));
		productData.setProcessdefversion(row.getString("PROCESSDEFVERSION"));	
		productData.setLasttxnid(TransactionId.MODIFY);
		
		productData.update();
		
	}
	
	/*
	 * private void getUpdateProductMappingData(IDataRow row) throws Throwable {
	 * 
	 * 
	 * }
	 */
	
	//sf_productDefinition Update => ProcessDefId,ProcessDefVersion null
	private void getDeleteProductMappingData(IDataRow row) throws Throwable
	{
		SfProductdefinitionData productData = new SfProductdefinitionData();
		SfProductdefinitionKey productKey = productData.key();
		
		productKey.setProductdefid(row.getString("PRODUCTDEFID"));
		productKey.setProductdefversion(row.getString("PRODUCTDEFVERSION"));
		
		productData = productData.selectOne();
		
		if (productData == null)
		{
			throw new InValidDataException("InValidData003", String.format("Productdefid = %s, Productdefversion = %s", row.getString("PRODUCTDEFID"),row.getString("PRODUCTDEFVERSION")));
		}
		
		productData.setProcessdefid(null);
		productData.setProcessdefversion(null);	
		productData.setLasttxnid(TransactionId.MODIFY);
		
		productData.update();
		
	}
}
