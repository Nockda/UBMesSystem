package kr.co.micube.mes.material.rule;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.service.SfConsumableDefinitionService;
import kr.co.micube.common.mes.so.CtConsumabletransactionData;
import kr.co.micube.common.mes.so.SfConsumabledefinitionData;
import kr.co.micube.common.mes.so.SfConsumabledefinitionKey;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.common.mes.so.SfUserData;
import kr.co.micube.common.mes.so.UlErptmesetcinData;
import kr.co.micube.common.mes.so.UlErptmesmateetcinData;
import kr.co.micube.common.mes.so.UlMaterialetcinoutData;
import kr.co.micube.common.mes.util.ConsumableTransactionUtils;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.so.EnterpriseData;
import kr.co.micube.commons.factory.so.PlantData;
import kr.co.micube.commons.factory.standard.service.IdService;
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
 * 프  로  그  램  명	: 자재관리 > 자재 > 기타입출고 > 입고 처리
 * 설               명	: 기타입출고 - 입고처리 팝업
 * 생      성      자	: 주시은
 * 생      성      일	: 2021-07-09
 * 수   정   이   력	: 
 */
public class CreateConsumableLotByEtc_Grid extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		
		IMessage msg = this.getMessage().get(); 
		IData jmsg = msg.get(); 
		IData body = jmsg.get(MessageFormat.Body);

		List<String> argList = new ArrayList<>();
		TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
		
		// UI에서 보내는 DataTable (dtEtcIn)
		IDataSet ds = this.getRequestDataset();      
		IDataTable dt = ds.getTable("dtEtcIn");
		System.out.println(dt);
		
		for(int i=0; i<dt.size(); i++) {
			
			IDataRow dtRow = dt.getRow(i);
			
			String sInType = dtRow.getString("INOUTTYPE");
			String sConsumableType = dtRow.getString("ITEMDEFTYPE");
			String sCreateId = "";
			
			if(sConsumableType.equals("Material"))
			{
				sCreateId = IdService.createId("LotNo", 1, argList, txnInfo).get(0);
			}
			else 
			{
				sCreateId = IdService.createId("PLotNo", 1, argList, txnInfo).get(0);
			}
			
			String sPartnumber = dtRow.getString("PRODUCTDEFID");
			SfConsumabledefinitionData defData = SfConsumableDefinitionService.getConsumabledefinitionByPartnumber(sPartnumber);
			SfConsumabledefinitionKey defKey = defData.key();
			String sConsumableDefId = defKey.getConsumabledefid();
			String sWarehouseId = dtRow.getString("WAREHOUSEID");
			String sLocationId = dtRow.getString("CELLID");
			String sConsumableState = body.getString("consumablestate");
			Double dCreatedQty = dtRow.getDouble("CONSUMABLELOTQTY");
			String sDescription = dtRow.getString("DESCRIPTION");
			String sUserId = txnInfo.getTxnUser();
			
			// erp, consumableLot 테이블에 뿌릴 TxnHistKey
			String sTxnHistKey = Generate.createTimeKey();
			
			// 자재Lot 테이블에 데이터 insert
			SfConsumablelotData code = new SfConsumablelotData();
			SfConsumablelotKey codeKey = code.key();
			
			codeKey.setConsumablelotid(sCreateId);
			
			EnterpriseData enterpriseData = new EnterpriseData();
			ISQLDataList<EnterpriseData> enterpriseDataList = enterpriseData.selectAll();
			enterpriseData = enterpriseDataList.get(0);
			
			
			PlantData plantData = new PlantData();
			ISQLDataList<PlantData> plantDataList = plantData.selectAll();
			plantData = plantDataList.get(0);
			
			code.setEnterpriseid(enterpriseData.getEnterpriseid());
			code.setPlantid(plantData.getPlantid());
			code.setAreaid(Constant.ASTERISK);
			code.setWarehouseid(sWarehouseId);
			code.setLocationid(sLocationId);
			code.setConsumabledefid(sConsumableDefId);
			code.setConsumabledefversion(Constant.ASTERISK);
			code.setConsumablestate(sConsumableState);
			code.setCreatedqty(dCreatedQty);
			code.setConsumablelotqty(dCreatedQty);
			
			if(sConsumableType.equals("Material"))
			{
				code.setState("InMate");
			}
			else
			{
				code.setState("InProd");
			}
			
			code.insert();
			
			// 자재InOut 테이블에 insert
			UlMaterialetcinoutData newCode = new UlMaterialetcinoutData();	
			newCode.setConsumabledefid(sConsumableDefId);
			newCode.setConsumablelotid(sCreateId);
			newCode.setInoutgubun("In");
			newCode.setInouttype(sInType);
			newCode.setWarehouseid(sWarehouseId);
			newCode.setLocationid(sLocationId);
			newCode.setProcessqty(dCreatedQty);
			newCode.setDescription(sDescription);
			
			newCode.insert();
			
			if(sConsumableType.equals("Material"))
			{
				logErpDataForMate(sCreateId, sInType, sConsumableDefId, sPartnumber, dCreatedQty, sWarehouseId, sUserId, sDescription, sTxnHistKey);
			}
			else
			{
				logErpDataForProd(sCreateId, sInType, sConsumableDefId, sPartnumber, dCreatedQty, sWarehouseId, sUserId, sDescription, sTxnHistKey);
			}
			
			saveConsumableTransaction(sCreateId, sInType, sConsumableDefId, dCreatedQty, sWarehouseId, sLocationId, sTxnHistKey);	
			
			Map<String, Object> result = new HashMap<String, Object>();
			result.put("LOTID", sCreateId);
			result.put("ITEMDEFTYPE", sConsumableType);
			IDataSet dsReturn = this.getResponseDataset();
			IDataTable dtReturn = dsReturn.addTable("DATA");
			dtReturn.addRow(result);
		}

	}
	
	private void logErpDataForMate(String sCreateId, String sInType, String sConsumableDefId, String sPartnumber, Double dCreatedQty, String sWarehouseId, String sUserId, String sDescription, String sTxnHistKey) throws DatabaseException
	{
		UlErptmesmateetcinData newCode = new UlErptmesmateetcinData();
		//UlErptmesmateetcinKey newCodeKey = newCode.key();
		
		Date today = new Date();
		SimpleDateFormat f = new SimpleDateFormat("yyyyMMdd");
		
		newCode.setMeskey(sCreateId);
		newCode.setAudtype("A");
		newCode.setCrtdatetime(today);
		newCode.setRecvyn(Constant.NO);
		newCode.setIndate(f.format(today));
		newCode.setEtcintype(Integer.parseInt(sInType));
		newCode.setItemseq(Integer.parseInt(sConsumableDefId));
		newCode.setItemno(sPartnumber);
		newCode.setInqty(dCreatedQty);
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
	
	private void logErpDataForProd(String sCreateId, String sInType, String sConsumableDefId, String sPartnumber, Double dCreatedQty, String sWarehouseId, String sUserId, String sDescription, String sTxnHistKey) throws DatabaseException
	{
		UlErptmesetcinData newCode = new UlErptmesetcinData();
		//UlErptmesetcinKey newCodeKey = newCode.key();
		
		Date today = new Date();
		SimpleDateFormat f = new SimpleDateFormat("yyyyMMdd");
		
		newCode.setMeskey(sCreateId);
		newCode.setAudtype("A");
		newCode.setCrtdatetime(today);
		newCode.setRecvyn(Constant.NO);
		newCode.setIndate(f.format(today));
		newCode.setEtcintype(Integer.parseInt(sInType));	
		newCode.setItemseq(Integer.parseInt(sConsumableDefId));
		newCode.setItemno(sPartnumber);
		newCode.setInqty(dCreatedQty);
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
	
	private void saveConsumableTransaction(String sCreateId, String sInType, String sConsumableDefId, Double dCreatedQty, String sWarehouseId, String sLocationId, String sTxnHistKey) throws InValidDataException, MESException, SystemException
	{
		EnterpriseData enterpriseData = new EnterpriseData();
		ISQLDataList<EnterpriseData> enterpriseDataList = enterpriseData.selectAll();
		enterpriseData = enterpriseDataList.get(0);
				
		PlantData plantData = new PlantData();
		ISQLDataList<PlantData> plantDataList = plantData.selectAll();
		plantData = plantDataList.get(0);
		
		Map<String, Object> rowMap = new HashMap<String, Object>();
		rowMap.put("TXNHISTKEY", sTxnHistKey);
		rowMap.put("ENTERPRISEID", enterpriseData.getEnterpriseid());
		rowMap.put("PLANTID", plantData.getPlantid());
		rowMap.put("AREAID", Constant.EMPTY);
		rowMap.put("EQUIPMENTID", Constant.EMPTY);
		rowMap.put("WAREHOUSEID", sWarehouseId);
		rowMap.put("CONSUMABLEDEFID", sConsumableDefId);
		rowMap.put("CONSUMABLEDEFVERSION", Constant.ASTERISK);
		rowMap.put("CONSUMABLELOTID", sCreateId);
		rowMap.put("TRANSACTIONTYPE", "In");
		rowMap.put("TRANSACTIONCODE", "IE");
		rowMap.put("QTY", dCreatedQty);
		rowMap.put("TOWAREHOUSEID", Constant.EMPTY);
		rowMap.put("TRANSACTIONDETAILCODE", sInType);
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
