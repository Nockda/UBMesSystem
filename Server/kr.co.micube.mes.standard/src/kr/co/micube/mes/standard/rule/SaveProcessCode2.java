package kr.co.micube.mes.standard.rule;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.SfProcesssegmentData;
import kr.co.micube.common.mes.so.SfProcesssegmentKey;
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
 * 프  로  그  램  명   : 기준정보 > 코드관리 > 공정코드
 * 설               명   : 
 * 생      성      자   : 
 * 생      성      일   : 
 * 수   정   이   력   : 2020-06-04 유태근 / 신규 입력필드 추가 및 다국어 저장방식 변경
 */

public class SaveProcessCode2 extends  DatasetRule {

	@Override
	public void doEvent() throws Throwable {
		// Get Message
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
	
	//Insert
	private SfProcesssegmentData getInsertData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		
		SfProcesssegmentData code = new SfProcesssegmentData();
		SfProcesssegmentKey codeKey = code.key();
		
		codeKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		codeKey.setProcesssegmentversion("*"); // 버전관리 없음, Default : 00001
		
		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("PROCESSSEGMENTID = %s", row.getString("PROCESSSEGMENTID")));
		}
		
		SfProcesssegmentData newCode = new SfProcesssegmentData();
		SfProcesssegmentKey newCodeKey = newCode.key();
		String dictionaryId = row.getString("PROCESSSEGMENTID");
		
		
		
		newCodeKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		newCodeKey.setProcesssegmentversion("*"); // 버전관리 없음, Default : 00001
		
		newCode.setProcesssegmentname(row.getString("PROCESSSEGMENTNAME$$KO-KR"));
		newCode.setProcesssegmentclassid(row.getString("PROCESSSEGMENTCLASSID"));
		newCode.setDescription(row.getString("DESCRIPTION"));
		newCode.setProcesssegmenttype(row.getString("PROCESSSEGMENTTYPE"));
		newCode.setCheckresult(row.getString("CHECKRESULT"));
		newCode.setIsuseuserlotserial(row.getString("ISUSEUSERLOTSERIAL"));
		newCode.setLotcreateruleid(row.getString("LOTCREATERULEID"));
		newCode.setValidstate(row.getString("VALIDSTATE"));
		newCode.setPlantid(row.getString("PLANTID"));
		newCode.setEnterpriseid(row.getString("ENTERPRISEID"));
		newCode.setIsmainprocesssegment(row.getString("ISMAINPROCESSSEGMENT"));
		newCode.setLasttxnid(TransactionId.CREATE);
		newCode.setDictionaryid(dictionaryId);
				
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
			
		for (String lang : languageTypes) {
			if (!row.containsKey(SfProcesssegmentData.Processsegmentname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(SfProcesssegmentData.Processsegmentname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryDataClsssAppend(batch, dictionaryId, dictionaryMap, "GRID");
		
		return newCode;
	}
	
	//Update
	private SfProcesssegmentData getUpdateData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		
		SfProcesssegmentData code = new SfProcesssegmentData();
		SfProcesssegmentKey codeKey = code.key();
		
		codeKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		codeKey.setProcesssegmentversion("*");
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("PROCESSSEGMENTID = %s", row.getString("PROCESSSEGMENTID")));
		}
		
		// 다국어
		String dictionaryId = code.getDictionaryid();
		if(StringUtils.isNullOrEmpty(dictionaryId))
		{
			dictionaryId = Generate.createID();
			code.setDictionaryid(dictionaryId);
		}
		
		code.setProcesssegmentname(row.getString("PROCESSSEGMENTNAME$$KO-KR"));
		code.setProcesssegmentclassid(row.getString("PROCESSSEGMENTCLASSID"));
		code.setDescription(row.getString("DESCRIPTION"));
		code.setProcesssegmenttype(row.getString("PROCESSSEGMENTTYPE"));
		code.setIsmainprocesssegment(row.getString("ISMAINPROCESSSEGMENT"));
		code.setCheckresult(row.getString("CHECKRESULT"));
		code.setIsuseuserlotserial(row.getString("ISUSEUSERLOTSERIAL"));
		code.setLotcreateruleid(row.getString("LOTCREATERULEID"));
		code.setPlantid(row.getString("PLANTID"));
		code.setEnterpriseid(row.getString("ENTERPRISEID"));
		code.setValidstate(row.getString("VALIDSTATE"));
		code.setLasttxnid(TransactionId.MODIFY);
		
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		
		for (String lang : languageTypes) {
			if (!row.containsKey(SfProcesssegmentData.Processsegmentname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(SfProcesssegmentData.Processsegmentname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryDataClsssAppend(batch, dictionaryId, dictionaryMap, "GRID");
			
		return code;
	}
	
	//Delete
	private SfProcesssegmentData getDeleteData(IDataRow row, ISQLUpsertBatch batch)throws InValidDataException, DatabaseException, MESException, SystemException {
		
		SfProcesssegmentData code = new SfProcesssegmentData();
		SfProcesssegmentKey codeKey = code.key();
		
		codeKey.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
		codeKey.setProcesssegmentversion("*");
		
		code = code.selectOne();
		
		if(code == null) 
		{
			throw new MESException("InValidData003", String.format("PROCESSSEGMENTID = %s", row.getString("PROCESSSEGMENTID")));
		}
		
		//다국어
		String dictionaryId = code.getDictionaryid();
		CommonUtils.deleteDictionaryData(batch, dictionaryId);
		
		return code;
	}

}
