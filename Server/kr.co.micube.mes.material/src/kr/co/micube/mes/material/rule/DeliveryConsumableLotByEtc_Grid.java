package kr.co.micube.mes.material.rule;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.service.SfConsumableDefinitionService;
import kr.co.micube.common.mes.service.SfConsumableLotService;
import kr.co.micube.common.mes.so.CtConsumabletransactionData;
import kr.co.micube.common.mes.so.SfConsumabledefinitionData;
import kr.co.micube.common.mes.so.SfConsumabledefinitionKey;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfUserData;
import kr.co.micube.common.mes.so.UlErptmesetcoutData;
import kr.co.micube.common.mes.so.UlErptmesmateetcoutData;
import kr.co.micube.common.mes.so.UlMaterialetcinoutData;
import kr.co.micube.common.mes.util.ConsumableTransactionUtils;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.standard.info.ConsumeConsumableLotInfo;
import kr.co.micube.commons.factory.standard.service.ConsumableLotService;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.tool.message.dataset.DataSet;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.support.ISQLDataList;



/*
 * 프  로  그  램  명	: 자재관리 > 자재 > 기타입출고 > 출고 처리
 * 설               명	: 기타입출고 - 출고처리 팝업
 * 생      성      자	: 주시은
 * 생      성      일	: 2021-07-12
 * 수   정   이   력	: 
 */
public class DeliveryConsumableLotByEtc_Grid extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		
		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);
		
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("dtEtcOut");
		
		System.out.println(dt);
		
		for(int i=0; i<dt.size(); i++) {
			
			IDataRow dtRow = dt.getRow(i);

			String sOutType = dtRow.getString("INOUTTYPE");
			String sConsumableLotId = dtRow.getString("CONSUMABLELOTID");
			String sPartnumber = dtRow.getString("CONSUMABLEDEFID");
			SfConsumabledefinitionData defData = SfConsumableDefinitionService.getConsumabledefinitionByPartnumber(sPartnumber);
			SfConsumabledefinitionKey defKey = defData.key();
			String sConsumableDefId = defKey.getConsumabledefid();
			String sWarehouseId = dtRow.getString("WAREHOUSEID");
			String sLocationId = dtRow.getString("CELLID");
			Double dCreatedQty = dtRow.getDouble("CONSUMABLELOTQTY");
			String sDescription = dtRow.getString("DESCRIPTION");
			String sConsumableType = dtRow.getString("ITEMDEFTYPE");
			String sUserId = body.getString("userid");
			
			// erp, consumableLot 테이블에 뿌릴 TxnHistKey
			String sTxnHistKey = Generate.createTimeKey();
			
			ConsumeConsumableLotInfo lotInfo = new ConsumeConsumableLotInfo();
			lotInfo.setConsumableLotId(sConsumableLotId);
			lotInfo.setConsumedQty(dCreatedQty);
			
			TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

			txnInfo.setTxnReasonCode("EtcOut");
			
			ConsumableLotService.consumeConsumableLot(lotInfo, txnInfo);

			UlMaterialetcinoutData newCode = new UlMaterialetcinoutData();
			newCode.setConsumabledefid(sConsumableDefId);
			newCode.setConsumablelotid(sConsumableLotId);
			newCode.setInoutgubun("Out");
			newCode.setInouttype(sOutType);
			newCode.setWarehouseid(sWarehouseId); 
			newCode.setLocationid(sLocationId);
			newCode.setProcessqty(dCreatedQty); 
			newCode.setDescription(sDescription);
			  
			newCode.insert();
			
			if(sConsumableType.equals("Material"))
			{
				logErpDataForMate(sConsumableLotId, sOutType, sConsumableDefId, sPartnumber, dCreatedQty, sWarehouseId,sUserId, sDescription, sTxnHistKey);
			}
			else
			{
				logErpDataForProd(sConsumableLotId, sOutType, sConsumableDefId, sPartnumber, dCreatedQty, sWarehouseId,sUserId, sDescription, sTxnHistKey);
			}
			
			saveConsumableTransaction(sConsumableLotId, sOutType, sConsumableDefId, dCreatedQty, sWarehouseId, sLocationId, sTxnHistKey);
		}
		
	}
	
	private void logErpDataForMate(String sConsumableLotId, String sOutType, String sConsumableDefId, String sPartnumber, Double dCreatedQty, String sWarehouseId, String sUserId, String sDescription, String sTxnHistKey) throws DatabaseException
	{
		UlErptmesmateetcoutData newCode = new UlErptmesmateetcoutData();
		//UlErptmesmateetcoutKey newCodeKey = newCode.key();
		
		Date today = new Date();
		SimpleDateFormat f = new SimpleDateFormat("yyyyMMdd");
		
		newCode.setMeskey(sConsumableLotId);
		newCode.setAudtype("A");
		newCode.setCrtdatetime(today);
		newCode.setRecvyn(Constant.NO);
		newCode.setOutdate(f.format(today));
		newCode.setEtcouttype(Integer.parseInt(sOutType));	
		newCode.setItemseq(Integer.parseInt(sConsumableDefId));
		newCode.setItemno(sPartnumber);
		newCode.setOutqty(dCreatedQty);
		newCode.setWhseq(Integer.parseInt(sWarehouseId));
		newCode.setRemark(sDescription);
		
		SfUserData userData = new SfUserData();
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfUserData.Userid, sUserId);
		ISQLDataList<SfUserData> userDataList = userData.select(cond);
		userData = userDataList.get(0);
		
		newCode.setEmpseq(Integer.parseInt(userData.getErp_empno()));
		newCode.setTossyn(Constant.NO);
		newCode.setInterfacetxnhistkey(sTxnHistKey);
		
		newCode.insert();
	}
	
	private void logErpDataForProd(String sConsumableLotId, String sOutType, String sConsumableDefId, String sPartnumber, Double dCreatedQty, String sWarehouseId, String sUserId, String sDescription, String sTxnHistKey) throws DatabaseException
	{
		UlErptmesetcoutData newCode = new UlErptmesetcoutData();
		//UlErptmesetcoutKey newCodeKey = newCode.key();
		
		Date today = new Date();
		SimpleDateFormat f = new SimpleDateFormat("yyyyMMdd");
		
		newCode.setCrtdatetime(today);
		newCode.setRecvyn(Constant.NO);
		newCode.setOutdate(f.format(today));
		newCode.setEtcouttype(Integer.parseInt(sOutType));	
		newCode.setItemseq(Integer.parseInt(sConsumableDefId));
		newCode.setItemno(sPartnumber);
		newCode.setOutqty(dCreatedQty);
		newCode.setWhseq(Integer.parseInt(sWarehouseId));
		newCode.setRemark(sDescription);
		
		SfUserData userData = new SfUserData();
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfUserData.Userid, sUserId);
		ISQLDataList<SfUserData> userDataList = userData.select(cond);
		userData = userDataList.get(0);
		
		newCode.setEmpseq(Integer.parseInt(userData.getErp_empno()));
		newCode.setTossyn(Constant.NO);
		newCode.setInterfacetxnhistkey(sTxnHistKey);
		
		newCode.insert();
	}
	
	private void saveConsumableTransaction(String sConsumableLotId, String sOutType, String sConsumableDefId, Double dCreatedQty, String sWarehouseId, String sLocationId, String sTxnHistKey) throws InValidDataException, MESException, SystemException
	{
		SfConsumablelotData lotData = SfConsumableLotService.getConsumablelot(sConsumableLotId);
		
		Map<String, Object> rowMap = new HashMap<String, Object>();
		rowMap.put("TXNHISTKEY", sTxnHistKey);
		rowMap.put("ENTERPRISEID", lotData.getEnterpriseid());
		rowMap.put("PLANTID", lotData.getPlantid());
		rowMap.put("AREAID", lotData.getAreaid());
		rowMap.put("EQUIPMENTID", lotData.getEquipmentid());
		rowMap.put("WAREHOUSEID", sWarehouseId);
		rowMap.put("CONSUMABLEDEFID", sConsumableDefId);
		rowMap.put("CONSUMABLEDEFVERSION", Constant.ASTERISK);
		rowMap.put("CONSUMABLELOTID", sConsumableLotId);
		rowMap.put("TRANSACTIONTYPE", "Out");
		rowMap.put("TRANSACTIONCODE", "OE");
		rowMap.put("QTY", dCreatedQty);
		rowMap.put("TOWAREHOUSEID", Constant.EMPTY);
		rowMap.put("TRANSACTIONDETAILCODE", sOutType);
		rowMap.put("TEAMID", Constant.EMPTY);
		rowMap.put("CUSTOMERID", Constant.EMPTY);
		rowMap.put("REFERENCEKEY", Constant.EMPTY);
		rowMap.put("CELLID", sLocationId);
	
		IDataSet ds = new DataSet();
		IDataTable dt = ds.addTable("transaction");
		dt.addRow(rowMap);
		
		CtConsumabletransactionData data = ConsumableTransactionUtils.getInsertData(dt.getFirstRow(), null);
		
		data.insert();
	}
	
	
}
