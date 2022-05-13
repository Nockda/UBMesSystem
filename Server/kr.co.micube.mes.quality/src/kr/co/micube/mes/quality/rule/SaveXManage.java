package kr.co.micube.mes.quality.rule;

import java.io.UnsupportedEncodingException;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Base64;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlCapaData;
import kr.co.micube.common.mes.so.UlCapaKey;
import kr.co.micube.common.mes.so.UlQmfileData;
import kr.co.micube.common.mes.so.UlQmfileKey;
import kr.co.micube.common.mes.so.UlXmanageData;
import kr.co.micube.common.mes.so.UlXmanageKey;
import kr.co.micube.common.mes.util.TransactionUtils;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.common.util.QueryProvider;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.so.IdclassserialData;
import kr.co.micube.commons.factory.so.IdclassserialKey;
import kr.co.micube.commons.factory.so.IdclasssplitData;
import kr.co.micube.commons.factory.so.IdclasssplitKey;
import kr.co.micube.commons.factory.standard.service.IdService;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명   : 품질 관리 > 클레임 관리 > X번 관리대장
 * 설               명   : 
 * 생      성      자   : 정승원
 * 생      성      일   : 2020-04-23
 * 수   정   이   력   : 2020-06-04 유태근 / VARCHAR → DATE로 변경된 컬럼들 저장될 수 있도록 수정
 * 				: 2021-12-20 이현석 / 마지막 xnumber 삭제 시에 채번 원상복귀
 */

public class SaveXManage extends DatasetRule{
   public void doEvent() throws Throwable {
      IDataSet ds = this.getRequestDataset();      
      IDataTable xManageDt = ds.getTable("xManageList");
      IDataTable xFileDt = ds.getTable("xFileList");
      
      IMessage msg = this.getMessage().get();
      IData jmsg = msg.get();
      IData body = jmsg.get(MessageFormat.Body);
      IData txnData = this.getMessage().getTxnData();
      TxnInfo txnInfo = TransactionUtils.getTransactionInfo(txnData);
      Date nowDate = SQLService.toDate();
      ISQLUpsertBatch batch = new SQLUpsertBatch();
      String toolbarAction = body.get("toolbarAction");
      String userId = body.get("userId");
      String xNumber = null;
      
      
      //X번관리 처리
      if(xManageDt != null && xManageDt.size() > 0)
      {
         for (int i = 0; i < xManageDt.size(); i++) 
         {
            IDataRow xRow = xManageDt.getRow(i);
            
            switch(toolbarAction)
            {
            case "Save": //저장
               
               xNumber = xRow.getString("XNUMBER");
               
               String state = xRow.getString("_STATE_");
               switch (state) 
               {
               case UpsertState.INSERT:
                  
            	  String yy = FiscalYear();
                  List<String> list = new ArrayList<String>();
                  list.add(yy);
                  List<String> idList = IdService.createId("XManageNumber", 1, list, txnInfo);
                  xNumber = idList.get(0).toString();
                  
                  batch.add(getInsertXmanageData(xRow, xNumber, nowDate, userId), SQLUpsertType.INSERT);
                  break;
               case UpsertState.UPDATE:
                   batch.add(getUpdateXmanageData(xRow, null, nowDate, null, null, batch), SQLUpsertType.UPDATE);
                  break;
               case UpsertState.DELETE:
                  batch.add(getDeleteXmanageData(xRow), SQLUpsertType.DELETE);
                  break;
               }
               break;
            case "RepairRequest": //수리의뢰발행
            	batch.add(getUpdateXmanageData(xRow, "RepairRequest", nowDate, null, null, batch), SQLUpsertType.UPDATE);            	
            	break;
            case "ClaimRequest": //Claim 의뢰

               String docId = CreatePublishNumber(txnInfo);
               
               String y = FiscalYear();
               List<String> cList = new ArrayList<String>();
               cList.add(y);
               List<String> idcList = IdService.createId("ClaimNumber", 1, cList, txnInfo);
               String claimNo = idcList.get(0).toString();
               
               batch.add(getUpdateXmanageData(xRow, null, nowDate, docId, claimNo, batch), SQLUpsertType.UPDATE);
               
               break;
            case "IssueComplete": //조치완료
               batch.add(getUpdateXmanageData(xRow, "Complete", nowDate, null, null, batch), SQLUpsertType.UPDATE);
               break;
            case "PublishCancel": //발행취소
               batch.add(getUpdateXmanageData(xRow, "Cancel", nowDate, null, null, batch), SQLUpsertType.UPDATE);
               break;
            }         
         }
         
      }
      
      
      //파일 처리
      if(xFileDt != null && xFileDt.size() > 0)
      {
         for(int i = 0; i < xFileDt.size(); i++)
         {
            IDataRow fRow = xFileDt.getRow(i);
            String fState = fRow.getString("_STATE_");
            
            switch(fState)
            {
            case UpsertState.INSERT:
               batch.add(getInsertQmFileData(fRow, xNumber), SQLUpsertType.INSERT);
               break;
            case UpsertState.UPDATE:
               batch.add(getUpdateQmFileData(fRow), SQLUpsertType.UPDATE);
               break;
            case UpsertState.DELETE:
               batch.add(getDeleteQmFileData(fRow), SQLUpsertType.DELETE);
               break;
            }
         }
      }
      
      
      batch.execute();
   }
   
   
   /********************************************************************************************
    * UL_XMANAGE INSERT
   *********************************************************************************************/
   private UlXmanageData getInsertXmanageData(IDataRow row, String xNumber, Date now, String user) throws InValidDataException, DatabaseException, MESException, SystemException, ParseException
   {
	   SimpleDateFormat transFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
      
	   UlXmanageData xMgnt = new UlXmanageData();
	   UlXmanageKey xMgntKey = xMgnt.key();
	   xMgntKey.setXnumber(xNumber);
      
	   xMgnt = xMgnt.selectOne();
	   if(xMgnt != null)
	   {
		   //X번호가 이미 존재합니다.
		   throw new InValidDataException("InValidData002", String.format("XNumber : %s", xNumber));
	   }
      
	   xMgnt = new UlXmanageData();
	   xMgntKey = xMgnt.key();
      
	   //X번호
	   xMgntKey.setXnumber(xNumber);
	   //발행일자
	   xMgnt.setPublishdate(now);
	   //보고서
	   xMgnt.setIsreport(row.getString("ISREPORT"));
	   //발행자
	   xMgnt.setPublisher(user);
	   //진행상태
	   xMgnt.setProgressstate("Request");
	   //유/무상
	   xMgnt.setChargetype(row.getString("CHARGETYPE"));
	   //유형
	   xMgnt.setXtype(row.getString("XTYPE"));
	   //Trouble분류
	   xMgnt.setTroubletype(row.getString("TROUBLETYPE"));
	   //제품군
	   xMgnt.setItemfamily(row.getString("ITEMFAMILY"));
	   //제조사
	   xMgnt.setManufacturerid(row.getString("MANUFACTURERID"));
	   //기종
	   xMgnt.setModelid(row.getString("MODELID"));
	   //제조번호
	   xMgnt.setManufacturenumber(row.getString("MANUFACTURENUMBER"));
	   //ETM(H)
	   xMgnt.setEtmhour(row.getDouble("ETMHOUR").intValue());
	   //지역
	   xMgnt.setCustomerregionid(row.getString("CUSTOMERREGIONID"));
	   //거래선
	   xMgnt.setCustomerbase(row.getString("CUSTOMERBASE"));
	   //장치사
	   xMgnt.setDevicecustomerid(row.getString("DEVICECUSTOMERID"));
	   //고객사
	   xMgnt.setCustomerid(row.getString("CUSTOMERID"));
	   //LINE
	   xMgnt.setLineid(row.getString("LINEID"));
	   //소재지
	   xMgnt.setCustomerlocation(row.getString("CUSTOMERLOCATION"));
	   //담당자
	   xMgnt.setCustomermanager(row.getString("CUSTOMERMANAGER"));
	   //연락처
	   xMgnt.setTellnumber(row.getString("TELLNUMBER"));
	   //고정비
	   xMgnt.setFixedcost(row.getDouble("FIXEDCOST"));
	   //변동비
	   xMgnt.setVariablecost(row.getDouble("VARIABLECOST"));     
	   //처리월
	   xMgnt.setProcessmonth(row.getString("PROCESSMONTH"));
	   //수주액
	   xMgnt.setOrderprice(row.getDouble("ORDERPRICE"));
	   //수주월
	   xMgnt.setOrdermonth(row.getInteger("ORDERMONTH"));   
	   //매출액
	   xMgnt.setSalesprice(row.getDouble("SALESPRICE"));
	   //매출월
	   xMgnt.setSalesmonth(row.getInteger("SALESMONTH"));
	   //발생일
	   try
	   {
		   xMgnt.setOccurdate(transFormat.parse(row.getString("OCCURDATE")));
	   }
	   catch(Exception ex)
	   {
		   System.out.println(ex.toString());
		   xMgnt.setOccurdate(null);
	   }
	   //현상
	   xMgnt.setStatedesc(row.getString("STATEDESC"));
	   //대응
	   xMgnt.setResponsedesc(row.getString("RESPONSEDESC"));
	   //대응처
	   xMgnt.setResponsefrom(row.getString("RESPONSEFROM"));
	   //Claim 내용
	   xMgnt.setClaimcontent(row.getString("CLAIMCONTENT"));
	   //완료일
	   try
	   {
		   xMgnt.setCompletedate(transFormat.parse(row.getString("COMPLETEDATE")));
	   }
	   catch(Exception ex)
	   {
		   System.out.println(ex.toString());
		   xMgnt.setCompletedate(null);
	   }
      
	   //심사여부
	   xMgnt.setIsexam(row.getString("ISEXAM"));
	   //진행현황
	   xMgnt.setProgressdesc(row.getString("PROGRESSDESC"));
	   //희망납기일
	   try
	   {
		   xMgnt.setHopedeleverydate(transFormat.parse(row.getString("HOPEDELEVERYDATE")));
	   }
	   catch(Exception ex)
	   {
		   System.out.println(ex.toString());
		   xMgnt.setHopedeleverydate(null);
	   }
	   
	   //수량
	   xMgnt.setQty(row.getDouble("QTY"));
	   
	   // 2020-07-15 유태근 - 제품입고일자, 입고확인자 추가
	   //제품입고일자
	   try
	   {
		   xMgnt.setIndate(transFormat.parse(row.getString("INDATE")));
	   }
	   catch(Exception ex)
	   {
		   System.out.println(ex.toString());
		   xMgnt.setIndate(null);
	   }
	   //입고확인자
	   xMgnt.setConfirmuser(row.getString("CONFIRMUSER"));
	   
	   return xMgnt;
   }
   
   /********************************************************************************************
    * UL_XMANAGE UPDATE
   *********************************************************************************************/
   private UlXmanageData getUpdateXmanageData(IDataRow row, String state, Date now, String docId, String claimNo, ISQLUpsertBatch batch) throws Throwable
   {
	   SimpleDateFormat transFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
	   String strReqConfDate = GetReqConfgDate(now, transFormat);
      
	   UlXmanageData xMgnt = new UlXmanageData();
	   UlXmanageKey xMgntKey = xMgnt.key();
	   xMgntKey.setXnumber(row.getString("XNUMBER"));
      
	   xMgnt = xMgnt.selectOne();
	   if(xMgnt == null)
	   {
		   throw new InValidDataException("InValidData001", String.format("XNumber : %s", row.getString("XNUMBER")));
	   }
      
	   //Claim 의뢰
	   if(!StringUtils.isNullOrEmpty(claimNo) && !StringUtils.isNullOrEmpty(docId))
	   {
		   //X번 클레임 번호 Update
		   xMgnt.setClaimnumber(claimNo);
		   xMgnt.setRequestdate(now);
         
		   //시정예방조치서 신규 Insert
		   UlCapaData capa = new UlCapaData();
		   UlCapaKey capaKey = capa.key();
		   capaKey.setDocid(docId);
         
		   capa = capa.selectOne();
		   if(capa != null)
		   {
			   throw new InValidDataException("InValidData002", String.format("DocId : %s", docId));
		   }
         
		   capa = new UlCapaData();
		   capaKey = capa.key();
		   //발행번호
		   capaKey.setDocid(docId);
		   //Claim No
		   capa.setClaimnumber(claimNo);
		   //X번호
		   capa.setXnumber(row.getString("XNUMBER"));
		   //발행일자
		   capa.setPublishdate(now);
		   //회답희망일
		   capa.setReqconfdate(StandardDateFormat(strReqConfDate));
		   //Claim 발생일
		   capa.setClaimdate(now);
		   //진행상태
		   capa.setProgressstate("ClaimRequest");
		   //고객사
		   capa.setCustomerid(row.getString("CUSTOMERID"));
		   //Claim 내용
		   capa.setClaimdesc(row.getString("PROGRESSDESC"));
		   //고정비
		   capa.setFixedcost(row.getDouble("FIXEDCOST"));
		   //변동비
		   capa.setVariablecost(row.getDouble("VARIABLECOST"));
		   
		   // 2020-07-15 유태근 - 제품입고일자, 입고확인자 추가
		   //제품입고일자
		   capa.setIndate(StringUtils.isNullOrEmpty(row.getString("INDATE")) ? null : StandardDateFormat(row.getString("INDATE")));		  
		   //입고확인자
		   capa.setConfirmuser(row.getString("CONFIRMUSER"));   
         
		   batch.add(capa, SQLUpsertType.INSERT);
         
		   //X번 고정비 UPDATE
		   xMgnt.setFixedcost(row.getDouble("FIXEDCOST"));
		   //X번 변동비 UPDATE
		   xMgnt.setVariablecost(row.getDouble("VARIABLECOST"));
	   }
      
	   //조치완료, 발행취소
	   if(!StringUtils.isNullOrEmpty(state))
	   {
		   switch(state)
		   {
		   case "Complete":
			   xMgnt.setProgressstate(state);
			   xMgnt.setCompletedate(now);
			   break;
		   case "Cancel":
			   xMgnt.setProgressstate(state);
			   break;
		   case "RepairRequest":
			   xMgnt.setRequestdate(now);
			   break;
		   }
	   }
      
	   //일반적인 update
	   if(StringUtils.isNullOrEmpty(state) && StringUtils.isNullOrEmpty(claimNo) && StringUtils.isNullOrEmpty(docId))
	   {
		   //보고서
		   xMgnt.setIsreport(row.getString("ISREPORT"));
		   //유/무상
		   xMgnt.setChargetype(row.getString("CHARGETYPE"));
		   //유형
		   xMgnt.setXtype(row.getString("XTYPE"));
		   //Trouble분류
		   xMgnt.setTroubletype(row.getString("TROUBLETYPE"));
		   //제품군
		   xMgnt.setItemfamily(row.getString("ITEMFAMILY"));
		   //제조사
		   xMgnt.setManufacturerid(row.getString("MANUFACTURERID"));
		   //기종
		   xMgnt.setModelid(row.getString("MODELID"));
		   //제조번호
		   xMgnt.setManufacturenumber(row.getString("MANUFACTURENUMBER"));
		   //ETM(H)
		   xMgnt.setEtmhour(row.getDouble("ETMHOUR").intValue());
		   //지역
		   xMgnt.setCustomerregionid(row.getString("CUSTOMERREGIONID"));
		   //거래선
		   xMgnt.setCustomerbase(row.getString("CUSTOMERBASE"));
		   //장치사
		   xMgnt.setDevicecustomerid(row.getString("DEVICECUSTOMERID"));
		   //고객사
		   xMgnt.setCustomerid(row.getString("CUSTOMERID"));
		   //LINE
		   xMgnt.setLineid(row.getString("LINEID"));
		   //소재지
		   xMgnt.setCustomerlocation(row.getString("CUSTOMERLOCATION"));
		   //담당자
		   xMgnt.setCustomermanager(row.getString("CUSTOMERMANAGER"));
		   //연락처
		   xMgnt.setTellnumber(row.getString("TELLNUMBER"));
		   //고정비
		   xMgnt.setFixedcost(row.getDouble("FIXEDCOST"));
		   //변동비
		   xMgnt.setVariablecost(row.getDouble("VARIABLECOST"));
		   //처리월
		   xMgnt.setProcessmonth(row.getString("PROCESSMONTH"));        
		   //수주액
		   xMgnt.setOrderprice(row.getDouble("ORDERPRICE"));
		   //수주월
		   xMgnt.setOrdermonth(row.getInteger("ORDERMONTH"));   
		   //매출액
		   xMgnt.setSalesprice(row.getDouble("SALESPRICE"));
		   //매출월
		   xMgnt.setSalesmonth(row.getInteger("SALESMONTH"));
		   //발생일
		   try
		   {
			   xMgnt.setOccurdate(transFormat.parse(row.getString("OCCURDATE")));
		   }
		   catch(Exception ex)
		   {
			   System.out.println(ex.toString());
			   xMgnt.setOccurdate(null);
		   }
		   //현상
		   xMgnt.setStatedesc(row.getString("STATEDESC"));
		   //대응
		   xMgnt.setResponsedesc(row.getString("RESPONSEDESC"));
		   //대응처
		   xMgnt.setResponsefrom(row.getString("RESPONSEFROM"));
		   //Claim 내용
		   xMgnt.setClaimcontent(row.getString("CLAIMCONTENT"));

		   //완료일
		   try
		   {
			   xMgnt.setCompletedate(transFormat.parse(row.getString("COMPLETEDATE")));
		   }
		   catch(Exception ex)
		   {
			   System.out.println(ex.toString());
			   xMgnt.setCompletedate(null);
		   }
         
		   //심사여부
		   xMgnt.setIsexam(row.getString("ISEXAM"));
		   //진행현황
		   xMgnt.setProgressdesc(row.getString("PROGRESSDESC"));
		   //출하일자
		   xMgnt.setShipmentdate(StringUtils.isNullOrEmpty(row.getString("SHIPMENTDATE")) ? null : StandardDateFormat(row.getString("SHIPMENTDATE")));	
		   //희망납기일
		   try
		   {
			   xMgnt.setHopedeleverydate(transFormat.parse(row.getString("HOPEDELEVERYDATE")));
		   }
		   catch(Exception ex)
		   {
			   System.out.println(ex.toString());
			   xMgnt.setHopedeleverydate(null);
		   }
		   //수량
		   xMgnt.setQty(row.getDouble("QTY"));
         
		   if(!StringUtils.isNullOrEmpty(row.getString("CLAIMNUMBER")))
		   {
			   UlCapaData capaData = new UlCapaData();
			   ISQLCondition cond = new SQLCondition(false);
			   cond.set(UlCapaData.Claimnumber, row.getString("CLAIMNUMBER"));
        	 
			   ISQLDataList<UlCapaData> capaDataList = capaData.select(cond);
			   if(capaDataList != null && capaDataList.size() > 0)
			   {
				   for(int i = 0; i< capaDataList.size(); i++)
				   {
    				  capaData = capaDataList.get(i);
    				  
    				  //고객사
    				  capaData.setCustomerid(row.getString("CUSTOMERID"));
    				  //Claim 내용(진행현황)
    				  capaData.setClaimdesc(row.getString("PROGRESSDESC"));
    				  //고정비
    				  capaData.setFixedcost(row.getDouble("FIXEDCOST"));
    				  //변동비
    				  capaData.setVariablecost(row.getDouble("VARIABLECOST"));
    				  //제품입고일자
    				  capaData.setIndate(StringUtils.isNullOrEmpty(row.getString("INDATE")) ? null : StandardDateFormat(row.getString("INDATE")));		  
    				  //입고확인자
    				  capaData.setConfirmuser(row.getString("CONFIRMUSER"));   
    				  batch.add(capaData, SQLUpsertType.UPDATE);
				   }
			   }
		   }
	   }
	   
	   // 2020-07-15 유태근 - 제품입고일자, 입고확인자 추가
	   //제품입고일자
	   try
	   {
		   xMgnt.setIndate(transFormat.parse(row.getString("INDATE")));
	   }
	   catch(Exception ex)
	   {
		   System.out.println(ex.toString());
		   xMgnt.setIndate(null);
	   }
	   //입고확인자
	   xMgnt.setConfirmuser(row.getString("CONFIRMUSER"));
      
	   return xMgnt;
   }
   
   /********************************************************************************************
    * UL_XMANAGE DELETE
   *********************************************************************************************/
   private UlXmanageData getDeleteXmanageData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
   {
	   UlXmanageData xMgnt = new UlXmanageData();
	   UlXmanageKey xMgntKey = xMgnt.key();
	  
	   xMgntKey.setXnumber(row.getString("XNUMBER"));
      
	   xMgnt = xMgnt.selectOne();
	   if(xMgnt == null)
	   {
		   throw new InValidDataException("InValidData003", String.format("XNumber : %s", row.getString("XNUMBER")));
	   }
	   
	   //x번호가 마지막 번호 일 경우 재사용
	   IdclassserialData id = new IdclassserialData();
	   IdclassserialKey idkey = id.key();
	   
	   idkey.setIdclassid("XManageNumber");
	   
	   DateFormat datePrefix = new SimpleDateFormat("yy");
	   Date nowDate = new Date();
	   String tempDate = datePrefix.format(nowDate);
	   String dtPrefix = "XK" + tempDate.toString() + '-';
	   Map<String, Object> param = new HashMap<String, Object>();
	   param.put("LOTCREATERULE", "XManageNumber");
	   param.put("PREFIX", dtPrefix);
	   List<Map<String, Object>> resultlot = QueryProvider.select("SelectCancelLot", "00002", param);
	   String xNumber = row.getString("XNUMBER").replaceAll("[^0-9]", "").substring(2);

	   String checkMaxNumber = String.valueOf(resultlot.get(0).get("LASTSERIALNO"));
	   String xnumprefix = String.valueOf(resultlot.get(0).get("PREFIX"));

	   if(checkMaxNumber.equals(xNumber)) {
		   idkey.setPrefix(xnumprefix);
		   Integer intmax = Integer.parseInt(checkMaxNumber);
		   String updatedSerial =String.format("%04d", intmax-1);
		   id.setLastserialno(updatedSerial); 
		   id.update();
		   
		   //idclasssplit 테이블에서 해당 lotid 삭제
		   IdclasssplitData idclassData = new IdclasssplitData();
		   IdclasssplitKey idclassKey = idclassData.key();
		   
		   idclassKey.setPrefix(row.getString("XNUMBER"));
		   idclassKey.setIdclassid("XManageNumber");
		   idclassData.delete();
	   }


	   return xMgnt;
   }
   
   /********************************************************************************************
    * UL_QMFILE INSERT
   *********************************************************************************************/
   private UlQmfileData getInsertQmFileData(IDataRow row, String docNo) throws InValidDataException, DatabaseException, MESException, SystemException
   {
      String docId = null;
      if(StringUtils.isNullOrEmpty(docNo))
      {
         docId = row.getString("DOCID");
      }
      else
      {
         docId = docNo;
      }
      
      UlQmfileData fileData = new UlQmfileData();
      UlQmfileKey fileKey = fileData.key();
      fileKey.setDocid(docId);
      fileKey.setSeqnumber(row.getInteger("SEQNUMBER"));
      
      fileData = fileData.selectOne();
      if(fileData != null)
      {
         throw new InValidDataException("InValidData002", String.format("DocId= %s, Seq = %s", docNo, row.getString("SEQNUMBER")));
      }
      
      fileData = new UlQmfileData();
      fileKey = fileData.key();
      
      fileKey.setDocid(docId);
      fileKey.setSeqnumber(row.getInteger("SEQNUMBER"));
      fileData.setFilename(row.getString("FILENAME"));
      try {
         fileData.setFiledata((Base64.getDecoder().decode(row.getString("FILEDATA").getBytes("UTF-8"))));
      } catch (UnsupportedEncodingException e) {
         // TODO Auto-generated catch block
         e.printStackTrace();
      }
      fileData.setDescription(row.getString("DESCRIPTION"));
      
      return fileData;
   }
   
   /********************************************************************************************
    * UL_QMFILE UPDATE
   *********************************************************************************************/
   private UlQmfileData getUpdateQmFileData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
   {
      UlQmfileData fileData = new UlQmfileData();
      UlQmfileKey fileKey = fileData.key();
      fileKey.setDocid(row.getString("DOCID"));
      fileKey.setSeqnumber(row.getInteger("SEQNUMBER"));
      
      fileData = fileData.selectOne();
      if(fileData == null)
      {
         throw new InValidDataException("InValidData001", String.format("DocId= %s, Seq = %s", row.getString("DOCID"), row.getString("SEQNUMBER")));
      }
      
      fileData.setDescription(row.getString("DESCRIPTION"));
      
      return fileData;
   }
   
   /********************************************************************************************
    * UL_QMFILE DELETE
   *********************************************************************************************/
   private UlQmfileData getDeleteQmFileData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
   {
      UlQmfileData fileData = new UlQmfileData();
      UlQmfileKey fileKey = fileData.key();
      fileKey.setDocid(row.getString("DOCID"));
      fileKey.setSeqnumber(row.getInteger("SEQNUMBER"));
      
      fileData = fileData.selectOne();
      if(fileData == null)
      {
         throw new InValidDataException("InValidData003", String.format("DocId= %s, Seq = %s", row.getString("DOCID"), row.getString("SEQNUMBER")));
      }
      
      return fileData;
   }
   
   /********************************************************************************************
    * UL_CAPA DOCID(발행번호) 채번
   *********************************************************************************************/
   private String CreatePublishNumber(TxnInfo trans) throws Throwable 
   {   
      // YK + 20(년도) + -(하이픈) + 00001(일련번호 5자리)로 구성
      // SimpleDateFormat dateFormat = new SimpleDateFormat("yyyyMMdd");
      // Date today = new Date();
      
      String year = FiscalYear();//dateFormat.format(today).substring(2, 4);
      
      List<String> list = new ArrayList<String>();
      list.add(year);
      
      List<String> idList = IdService.createId("PublishSequence", 1, list, trans);

      return idList.get(0).toString();
   }
   
   /********************************************************************************************
    * 회답희망일 계산
   *********************************************************************************************/
   private String GetReqConfgDate(Date date, SimpleDateFormat fmt)
   {
	   Calendar cal = new GregorianCalendar();
	   cal.add(Calendar.DAY_OF_MONTH, 15);
	   	   
	   return fmt.format(cal.getTime());
   }
   
	/********************************************************************************************
	 * 날짜 데이터 포멧 yyyy-MM-dd로 변경
	*********************************************************************************************/
	private Date StandardDateFormat(String date) throws Throwable 
	{
		SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");

		Date formatDate = format.parse(date);

		return formatDate;
	}
	
	/********************************************************************************************
	 * 회계년도 계산
	*********************************************************************************************/
	private String FiscalYear() throws Throwable 
	{
		Calendar cal = Calendar.getInstance();
		cal.setTime(new Date());
		int month = cal.get(Calendar.MONTH);
		if(month < 6)
		{
			cal.add(Calendar.YEAR, -1);
		}
		int year = cal.get(Calendar.YEAR);
		return String.valueOf(year).substring(2);
	}
}