package kr.co.micube.common.mes.util;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.ZoneId;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.TimeZone;

import kr.co.micube.common.mes.constant.DefaultValue;
import kr.co.micube.common.mes.constant.ValidState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.so.CtModelstandardinfoData;
import kr.co.micube.common.mes.so.CtModelstandardinfoKey;
import kr.co.micube.common.mes.so.SfProcesssegmentData;
import kr.co.micube.common.mes.so.SfProcesssegmentKey;
import kr.co.micube.common.mes.so.SfProductdefinitionData;
import kr.co.micube.common.mes.so.SfProductdefinitionKey;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.common.util.QueryProvider;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.so.IdclassserialData;
import kr.co.micube.commons.factory.so.IdclassserialKey;
import kr.co.micube.commons.factory.standard.service.IdService;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.mes.DictionaryData;
import kr.co.micube.tool.so.mes.DictionaryKey;
import kr.co.micube.tool.so.mes.MessageData;
import kr.co.micube.tool.so.mes.MessageKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;


public class CommonUtils {
	public static ISQLUpsertBatch appendDictionaryData(ISQLUpsertBatch batch, String dictionaryId, Map<String, String> dictionaryMap) throws SystemException
	{
		return appendDictionaryData(batch, dictionaryId, DefaultValue.MASTERDICTIONARYCLASS, dictionaryMap);
	}
	
	
	public static ISQLUpsertBatch appendDictionaryDataClsssAppend(ISQLUpsertBatch batch, String dictionaryId, Map<String, String> dictionaryMap, String dictionaryClassId) throws SystemException
	{
		return appendDictionaryData(batch, dictionaryId, dictionaryClassId, dictionaryMap);
	}
	
	public static ISQLUpsertBatch appendDictionaryData(ISQLUpsertBatch batch, String dictionaryId, String dictionaryClassId, Map<String, String> dictionaryMap) throws SystemException
	{
		Iterator<String> it = dictionaryMap.keySet().iterator();
		
		while (it.hasNext()) {
			String LangType = it.next();
			
			DictionaryData dictionaryData = new DictionaryData();
			DictionaryKey dictionaryKey = dictionaryData.key();
			
			dictionaryKey.setDictionaryid(dictionaryId);
			dictionaryKey.setLanguagetype(LangType);
			
			dictionaryData = dictionaryData.selectOne();
			
			if (dictionaryData == null)
			{
				if (StringUtils.isNullOrEmpty(dictionaryId))
					dictionaryId = Generate.createID();
				
				dictionaryData = new DictionaryData();
				dictionaryKey = dictionaryData.key();
				
				//dictionaryData.setDictionaryid(dictionaryId);
				//dictionaryData.setLanguagetype(LangType);
				dictionaryKey.setDictionaryid(dictionaryId);
				dictionaryKey.setLanguagetype(LangType);
				dictionaryData.setDictionaryclassid(dictionaryClassId);
				dictionaryData.setDictionaryname(dictionaryMap.get(LangType));
				dictionaryData.setValidstate(ValidState.VALID);
				
				batch.add(dictionaryData, SQLUpsertType.INSERT);
			}
			else
			{
				//dictionaryData.setDictionaryid(dictionaryId);
				//dictionaryData.setLanguagetype(LangType);
				dictionaryKey.setLanguagetype(LangType);
				dictionaryData.setDictionaryclassid(dictionaryClassId);
				dictionaryData.setDictionaryname(dictionaryMap.get(LangType));
				dictionaryData.setValidstate(ValidState.VALID);
				
				batch.add(dictionaryData, SQLUpsertType.UPDATE);
			}
		}		
		
		
		return batch;
	}
	public static Date GetDatabaseDatetime(IMessage msg) throws DatabaseException, ParseException
	{
		
		
		IData jmsg = msg.get();
		
		TxnInfo txnInfo = TransactionUtils.getTransactionInfo(jmsg.get(MessageFormat.Transaction));
		
		String clientTimeZoneId = txnInfo.getTransaction().get(MessageFormat.Transaction_ClientTimeZoneID);
		
		Date ddt = SQLService.toDate();
		
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		Date sdt = sdf.parse(new SimpleDateFormat("yyyy-MM-dd HH:mm:ss").format(ddt));
		
		
		SimpleDateFormat cdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		TimeZone ctz = TimeZone.getTimeZone(ZoneId.of(clientTimeZoneId));
		cdf.setTimeZone(ctz);
		
		String cdtString = cdf.format(sdt);
		
		Date rd = sdf.parse(cdtString);
		
		
		return rd;
	}	
	public static ISQLUpsertBatch deleteDictionaryData(ISQLUpsertBatch batch, String dictionaryId) throws SystemException
	{
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		for (String lang : languageTypes) {
			DictionaryData dictionaryData = new DictionaryData();
			DictionaryKey dictionaryKey = dictionaryData.key();
			
			dictionaryKey.setDictionaryid(dictionaryId);
			dictionaryKey.setLanguagetype(lang);
			dictionaryData = dictionaryData.selectOne();
			
			if (dictionaryData != null)
				batch.add(dictionaryData, SQLUpsertType.DELETE);
		}
		
		
		return batch;
	}
	
	public static String GenerateLotid(String ProductDefid,String ProcessSegmentID, TxnInfo txninfo,String UserDefine,String CreateRuleID)throws Throwable
	{
		SfProcesssegmentData segment = new SfProcesssegmentData();
		SfProcesssegmentKey segmentKey = segment.key();
		
		segmentKey.setProcesssegmentid(ProcessSegmentID);
		segmentKey.setProcesssegmentversion("*");
		
		segment = segment.selectOne();
		
		String LotCreateRule = "";
		if(CreateRuleID.equals(""))
		{
			LotCreateRule = segment.getLotcreateruleid();
		}
		else
		{
			LotCreateRule = CreateRuleID;
		}
		
		if(LotCreateRule.length() ==0)
		{
			LotCreateRule = "PLotNo";
		}
		
		String Lotid = null;
		
		switch (LotCreateRule) {
			case "CompLotNo": //컴프레셔
				Lotid = GenerateCompressor(ProductDefid,LotCreateRule,ProcessSegmentID,txninfo);
				break;
			//RefLotNo,ServiceMotorLotNo,DisplaysorLotNo 같은 함수로 변경
			case "RefLotNo": //냉동기
			case "ServiceMotorLotNo": //서비스모터
			case "DisplaysorLotNo": //디스플레이서
				Lotid = GenerateRep(ProductDefid,LotCreateRule,ProcessSegmentID,txninfo);
				break;
				/*
			case "DisplaysorLotNo": //디스플레이서
				Lotid = GenerateDisplaysor(ProductDefid,LotCreateRule,ProcessSegmentID,txninfo);
				break;
				*/				
			case "CylinderLotNo": //냉동기
				Lotid = GenerateCylinder(ProductDefid,LotCreateRule,ProcessSegmentID,txninfo,UserDefine);
				break;		
			case "PumpLotNo":
			case "MBSCLotNo":
				Lotid = GeneratePumpMBSC(LotCreateRule,txninfo,UserDefine);
				break;
			case "CmsLotNo": //CMS조립
				Lotid = GenerateCms(ProductDefid,LotCreateRule,ProcessSegmentID,txninfo);
				break;
			case "LN2LotNo": // LN2
				Lotid = GenerateLN2(LotCreateRule,txninfo,UserDefine);
				break;				
			default: //일반생산Lot, 펌프,MBS-C조립
				Lotid = GenerateDefault(LotCreateRule,txninfo,UserDefine);
				break;
		}
		
		return Lotid.replace(" ", "");
	}
	
	private static String GenerateLN2(String CreateRuleID, TxnInfo txn,String UserDefine)throws Throwable
	{
		
		Map<String, Object> map = new HashMap<>();
		map.put("IDCLASSID", CreateRuleID);
		
		List<Map<String, Object>> resultMap = QueryProvider.select("SelectLN2CheckLastSerial", "00001", map);
		
		if (resultMap.size() == 0)
		{
			return null;			
		}
		
		String isLast = (String)resultMap.get(0).get("ISLAST");
		String currentDate = (String)resultMap.get(0).get("CURRENTDATE");
		String lastSerialNo = (String)resultMap.get(0).get("LASTSERIALNO");
		String initSerial = (String)resultMap.get(0).get("INITSERIAL");
		Integer initSerialLength = Integer.parseInt(resultMap.get(0).get("LENGTH").toString());	
			
		IdclassserialData id = new IdclassserialData();
		IdclassserialKey idkey = id.key();
		
		idkey.setIdclassid(CreateRuleID);
		idkey.setPrefix("");
		
		id = id.selectOne();
		
		if (id == null)
		{
			return null;
		}
		
		// 마지막 시퀀스 9999 일 때, 0000 으로 초기화 
		if (isLast.equals("Y")) {
			id.setLastserialno(initSerial); 
			id.update();
			
			lastSerialNo = initSerial;
		}			
	
		String lotid = "";
		String mark = "K";
		
		// 마지막 시퀀스 + 1
		Integer increasedSerialNo = (Integer.parseInt(lastSerialNo) + 1);		
		Integer increasedSerialNoLength = increasedSerialNo.toString().length();			
					
		String updatedSerialNo = "";
		
		for (int i = 0, len = initSerialLength - increasedSerialNoLength; i < len; i++) {
			updatedSerialNo += "0";
		}
		
		updatedSerialNo += increasedSerialNo.toString();
		
		id.setLastserialno(updatedSerialNo); 
		id.update();
		
		lotid = currentDate + updatedSerialNo + mark;
		
		return lotid;
	}
	
	private static String GeneratePumpMBSC(String CreateRuleID, TxnInfo txn,String UserDefine)throws Throwable
	{
		Map<String, Object> map = new HashMap<>();
		map.put("IDCLASSID", CreateRuleID);
		
		List<Map<String, Object>> resultMap = QueryProvider.select("SelectPumpMBSCCheckLastSerial", "00001", map);
		
		String lotid = "";
		String isLast = "";
		
		List<String> argList = new ArrayList<>();
		
		if (resultMap.size() == 0)
		{
			lotid = IdService.createId(CreateRuleID, 1, argList, txn).get(0);
			
		}
		else
		{
			isLast = (String)resultMap.get(0).get("ISLAST") ;
			if(isLast.equals("Y"))
			{
				lotid = (String)resultMap.get(0).get("LOTID") + 'A' ;
				IdclassserialData id = new IdclassserialData();
				IdclassserialKey idkey = id.key();
				
				idkey.setIdclassid(CreateRuleID);
				idkey.setPrefix("");
				
				id = id.selectOne();
				
				if(id != null)
				{
					id.setLastserialno((String)resultMap.get(0).get("INITSERIAL")); 
					id.update();
				}
				
			}
			else
			{
				//	PumpLot Serial = 999 다음 LOT은 001 생성 되어야 함.
				//  MbscLot Serial = 9999 다음 LOT은 0001 생성 되어야함.
				checkPumpMbscLotSerial(map, CreateRuleID);
				lotid = IdService.createId(CreateRuleID, 1, argList, txn).get(0);
			}
		}
		
		
	
		return  lotid;
		
	}	
	private static String GenerateDefault(String CreateRuleID, TxnInfo txn,String UserDefine)throws Throwable
	{
	
		List<String> argList = new ArrayList<>();
	
		return  IdService.createId(CreateRuleID, 1, argList, txn).get(0);
		
	}
	private static String GenerateCylinder(String ProductDefid,String CreateRuleID,String ProcessSegmentid, TxnInfo txn,String UserDefine)throws Throwable
	{
		CtModelstandardinfoData modelStandard = GetModelStandard(ProductDefid,ProcessSegmentid);
		
		String Standard = modelStandard.getStandard1();
		String Standard2 = StringUtils.ConvertNulltoEmpty(modelStandard.getStandard2());
		String Standard3 = StringUtils.ConvertNulltoEmpty(modelStandard.getStandard3());
		String Year = accountingDateForLot();
		
		List<String> argList = new ArrayList<>();
		argList.add(Year);
		argList.add(Standard);
		argList.add(UserDefine);
		argList.add(Standard2);
		argList.add(Standard3);
		
		return  IdService.createId(CreateRuleID, 1, argList, txn).get(0);
	}
	private static String GenerateDisplaysor(String ProductDefid,String CreateRuleID,String ProcessSegmentid, TxnInfo txn)throws Throwable
	{
		CtModelstandardinfoData modelStandard = GetModelStandard(ProductDefid,ProcessSegmentid);
		
		String Standard = modelStandard.getStandard1();
		
		List<String> argList = new ArrayList<>();
		argList.add(Standard);
		
		return  IdService.createId(CreateRuleID, 1, argList, txn).get(0);
		
	}
	//냉동기
	private static String GenerateRep(String ProductDefid,String CreateRuleID,String ProcessSegmentid, TxnInfo txn)throws Throwable
	{
		//기준1+계산값+순번+기준2
		
		CtModelstandardinfoData modelStandard = GetModelStandard(ProductDefid,ProcessSegmentid);
		
		String Standard = modelStandard.getStandard1();
		String Standard2 = StringUtils.ConvertNulltoEmpty(modelStandard.getStandard2());
		
		Map<String, Object> map = new HashMap<>();
		map.put("IDCLASSID", CreateRuleID);
		map.put("STANDARD", Standard);
		
		List<Map<String, Object>> resultMap = QueryProvider.select("SelectlotSerialForRep", "00001", map);
		
		String calValue = "";
		
		if (resultMap.size() == 0)
			calValue = " ";
		else
			calValue = (String)resultMap.get(0).get("CALVALUE") ;
		
		List<String> argList = new ArrayList<>();
		argList.add(Standard);
		argList.add(calValue);
		if(!CreateRuleID.equals("DisplaysorLotNo"))
		{
			argList.add(Standard2);
		}
		
		if(!CreateRuleID.equals("DisplaysorLotNo"))	
			return  IdService.createId(CreateRuleID, 1, argList, txn).get(0);
		else 
			return  IdService.createId(CreateRuleID, 1, argList, txn).get(0) + (Standard2.equals(null) ? "" : Standard2);
	}
	//컴프레셔
	private static String GenerateCompressor(String ProductDefid,String CreateRuleID,String ProcessSegmentid, TxnInfo txn)throws Throwable
	{
		//기준서1 + 순번 + 기준2
		
		CtModelstandardinfoData modelStandard = GetModelStandard(ProductDefid,ProcessSegmentid);
		
		List<String> argList = new ArrayList<>();
		argList.add(modelStandard.getStandard1());
		argList.add(StringUtils.ConvertNulltoEmpty(modelStandard.getStandard2()));

		return  IdService.createId(CreateRuleID, 1, argList, txn).get(0);
	}
	
	//Cms
	private static String GenerateCms(String ProductDefid,String CreateRuleID,String ProcessSegmentid, TxnInfo txn)throws Throwable
	{
		//기준서1 + 순번
		CtModelstandardinfoData modelStandard = GetModelStandard(ProductDefid,ProcessSegmentid);
		
		List<String> argList = new ArrayList<>();
		argList.add(modelStandard.getStandard1());
		
		return  IdService.createId(CreateRuleID, 1, argList, txn).get(0);
	}
	
	private static CtModelstandardinfoData GetModelStandard(String ProductDefid,String ProcessSegmentid)throws Throwable
	{
		SfProductdefinitionData pd = new SfProductdefinitionData();
		SfProductdefinitionKey pdkey = pd.key();
		
		pdkey.setProductdefid(ProductDefid );
		pdkey.setProductdefversion("*");

		pd = pd.selectOne();
		
		if(pd == null)
		{
			//NotExistProduct 해당 품목이 존재 하지 않습니다. {0}
			throw new InValidDataException("NotExistProduct", String.format("Product ID : %s", ProductDefid));
		}
		String Modelid = pd.getModelid();
		
		if(Modelid == null || Modelid.equals(""))
		{
			//NotExisModelByProduct 해당 품목에 기종이 매핑 되지 않았습니다.. {0}
			throw new InValidDataException("NotExisModelByProduct", String.format("Product ID : %s", ProductDefid));
		}
		
		CtModelstandardinfoData modelStandard = new CtModelstandardinfoData();
		CtModelstandardinfoKey modelStandardKey = modelStandard.key();
		
		modelStandardKey.setModelid(Modelid);
		modelStandardKey.setProcesssegmentid(ProcessSegmentid);
		
		modelStandard = modelStandard.selectOne();
		
		if(modelStandard == null)
		{
			//NotExistStandardByModel 해당 기종에 기준서가 등록되지 않았습니다.{0}	
			throw new InValidDataException("NotExistStandardByModel", String.format("Model ID : %s", Modelid));
		}		
		
		return modelStandard;
	}
	/*
	public static ISQLUpsertBatch appendMessageData(ISQLUpsertBatch batch, String messageId, Map<String, String> messageMap) throws SystemException
	{
		Iterator<String> it = messageMap.keySet().iterator();
		
		while (it.hasNext()) {
			String LangType = it.next();
			
			DictionaryData dictionaryData = new DictionaryData();
			DictionaryKey dictionaryKey = dictionaryData.Key();
			
			dictionaryKey.setDictionaryid(messageId);
			dictionaryKey.setLanguagetype(LangType);
			
			dictionaryData = dictionaryData.selectOne();
			
			if (dictionaryData == null)
			{
				if (StringUtils.isNullOrEmpty(messageId))
					messageId = Generate.createID();
				
				dictionaryData = new DictionaryData();
				
				//dictionaryData.setDictionaryid(messageId);
				//dictionaryData.setLanguagetype(LangType);
				dictionaryKey.setDictionaryid(messageId);
				dictionaryKey.setLanguagetype(LangType);
				dictionaryData.setDictionaryclassid(DefaultValue.MASTERMESSAGECLASS);
				dictionaryData.setDictionaryname(messageMap.get(LangType));
				dictionaryData.setValidstate(ValidState.VALID);
				
				batch.add(dictionaryData, SQLUpsertType.INSERT);
			}
			else
			{
				//dictionaryData.setDictionaryid(dictionaryId);
				//dictionaryData.setLanguagetype(LangType);
				dictionaryKey.setLanguagetype(LangType);
				dictionaryData.setDictionaryclassid(DefaultValue.MASTERMESSAGECLASS);
				dictionaryData.setDictionaryname(messageMap.get(LangType));
				
				dictionaryData.setValidstate(ValidState.VALID);
				
				batch.add(dictionaryData, SQLUpsertType.UPDATE);
			}
		}		
		
		
		return batch;
	}
	*/
	
	public static ISQLUpsertBatch appendToolTipData(ISQLUpsertBatch batch, String messageId, Map<String, String> messageMap) throws SystemException
	{
		Iterator<String> it = messageMap.keySet().iterator();
		
		while (it.hasNext()) {
			String LangType = it.next();
			
			MessageData messageData = new MessageData();
			MessageKey messageKey = messageData.key();
			
			messageKey.setMessageid(messageId);
			messageKey.setLanguagetype(LangType);
			
			messageData = messageData.selectOne();
			
			if (messageData == null)
			{
				if (StringUtils.isNullOrEmpty(messageId))
					messageId = Generate.createID();
				
				messageData = new MessageData();
				MessageKey newMessageKey = messageData.key();
				newMessageKey.setMessageid(messageId);
				newMessageKey.setLanguagetype(LangType);
				messageData.setMessageclassid(DefaultValue.MASTERMESSAGECLASS);
				messageData.setMessagename(messageMap.get(LangType));
				messageData.setDescription(messageMap.get(LangType));
				messageData.setValidstate(ValidState.VALID);
				
				batch.add(messageData, SQLUpsertType.INSERT);
			}
			else
			{
				messageData.setMessageclassid(DefaultValue.MASTERMESSAGECLASS);
				messageData.setMessagename(messageMap.get(LangType));
				messageData.setDescription(messageMap.get(LangType));
				
				messageData.setValidstate(ValidState.VALID);
								
				batch.add(messageData, SQLUpsertType.UPDATE);
			}
		}		
		
		
		return batch;
	}
	
	public static ISQLUpsertBatch deleteToolTipData(ISQLUpsertBatch batch, String messageId) throws SystemException
	{
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
		for (String lang : languageTypes) {
			MessageData messageData = new MessageData();
			MessageKey messageKey = messageData.key();
			
			messageKey.setMessageid(messageId);
			messageKey.setLanguagetype(lang);
			messageData = messageData.selectOne();
			
			if (messageData != null)
				batch.add(messageData, SQLUpsertType.DELETE);
		}
		
		
		return batch;
	}

	public static void checkPumpMbscLotSerial(Map map, String CreateRuleID) throws DatabaseException {
		// 공정별  시리얼넘버 확인
		List<Map<String, Object>> resultMap = QueryProvider.select("SelectPumpLotCurrentSerial", "00001", map);
		
		if(resultMap.size() > 0) {
			
		String idclassId = (String)resultMap.get(0).get("IDCLASSID");
		String lastSerialNo = (String)resultMap.get(0).get("LASTSERIALNO");
		String prefix = (String)resultMap.get(0).get("PREFIX");
		
		switch(idclassId) 
			{
			case "PumpLotNo" : // 펌프조립 공정
				pump999Delete(idclassId, prefix, lastSerialNo);
			break;
			
			case "MBSCLotNo" : // MBS-C공정
				mbsc9999Delete(idclassId, prefix, lastSerialNo);
			break;
			}
		}
	}
	
	// 펌프조립 공정 lastSerialNo가 999일경우 삭제
	private static void pump999Delete(String idclassId, String prefix, String lastSerialNo) throws DatabaseException {
		
		if(lastSerialNo.equals("999")) {
			IdclassserialData id = new IdclassserialData();
			IdclassserialKey idkey = id.key();
			
			idkey.setIdclassid(idclassId);
			idkey.setPrefix(prefix);
			
			id.selectOne();
			id.delete();
		}
		
	}
	// MBS-C 공정 lastSerialNo가 9999일경우 삭제
	private static void mbsc9999Delete(String idclassId, String prefix, String lastSerialNo) throws DatabaseException {
		
		if(lastSerialNo.equals("9999")) {
			IdclassserialData id = new IdclassserialData();
			IdclassserialKey idkey = id.key();
			
			idkey.setIdclassid(idclassId);
			idkey.setPrefix(prefix);
			
			id.selectOne();
			id.delete();
		}
		
	}
	
	//lot채번시 고객사 회계연도 규칙을 지정 (현재 실린더lot만 적용)
	// 01 ~ 06월 => 작년 / 07 ~ 12월 => 올해
	// Ex) 2021년 01월 => 20년도 / 2021년 07월 => 21년도
	private static String accountingDateForLot() {
		
		String year = "";
		String yy = "";
		
		LocalDate currentDate = LocalDate.now(); // 현재 날짜
		//currentDate = LocalDate.of(2021, 7, 25); // 날짜지정 
		int month = currentDate.getMonthValue();
		
		// 1월 ~ 6월
		if(month == 1 || month == 2 || month == 3 || month == 4 || month == 5 || month == 6) {
			year = Integer.toString(currentDate.minusYears(1).getYear());
		}
		// 7월 ~ 12월
		else {
			year = Integer.toString(currentDate.getYear());
		}
		
		yy = year.substring(2);
		
		return yy;
	}
}
