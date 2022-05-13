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
import kr.co.micube.common.mes.service.SfConsumableLotService;
import kr.co.micube.common.mes.so.CtConsumabletransactionData;
import kr.co.micube.common.mes.so.SfConsumabledefinitionData;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.common.mes.so.SfUserData;
import kr.co.micube.common.mes.so.UlErptmeslgmvData;
import kr.co.micube.common.mes.so.UlKanbanmappinglotData;
import kr.co.micube.common.mes.so.UlKanbanmappinglotKey;
import kr.co.micube.common.mes.util.ConsumableTransactionUtils;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.standard.service.IdService;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.tool.message.dataset.DataSet;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLData;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 자재관리 > 자재재고관리 > 간반요청출고관리
 * 설               명	: 자재출고시 Lot분할 및 라벨재발행
 * 생      성      자	: jylee
 * 생      성      일	: 2020-07-01
 * 수   정   이   력	: 
 */
public class SplitLotAndLabel extends DatasetRule {

	//private IDataTable gridReq; 
	//private IDataTable gridLot;
	
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		//this.gridReq = ds.getTable("gridmaster");
		//this.gridLot = ds.getTable("gridlot");
		
		TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		
		
		IDataSet dsReturn = this.getResponseDataset();
		IDataTable dtReturn = dsReturn.addTable("DATA");
	
		//Paramerter
		//QTY => 요청수량
		//CONSUMABLELOTQTY => 투입할 자재LOT 수량
		
		Double beforeConsumableLotQty = null;
		
	
	
		for (int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);

			String sConsumableLotId = row.getString("CONSUMABLELOTID");
			//SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(sConsumableLotId);
			//String sConsumableLotDefId = conLotData.getConsumabledefid();
			
			if((row.getDouble("QTY")) >= (row.getDouble("CONSUMABLELOTQTY"))){
				batch.add(changeLocation(row, batch), SQLUpsertType.UPDATE);
				batch.add(saveLotData(row, sConsumableLotId), SQLUpsertType.INSERT);
				batch.add(createConsumableTransactionOut(row, sConsumableLotId, batch),SQLUpsertType.INSERT);
				batch.add(createConsumableTransactionIn(row, sConsumableLotId, batch),SQLUpsertType.INSERT); 
				batch.add(getLogErpData(row, batch, txnInfo.getTxnUser()), SQLUpsertType.INSERT);
				
				int count = 0;
				count++;
				for(int k = 0; k < count; k++) {
					beforeConsumableLotQty = beforeConsumableLotQty+ row.getDouble("CONSUMABLELOTQTY");
				}
			}
			else {
				List<String> argList = new ArrayList<>();
				String createId = IdService.createId("LotNo", 1, argList, txnInfo).get(0);
				
				batch.add(splitLot(row, batch, sConsumableLotId, createId, beforeConsumableLotQty), SQLUpsertType.INSERT);
				batch.add(changeLocationForSplit(row, batch, beforeConsumableLotQty), SQLUpsertType.UPDATE);
				batch.add(saveLotDataForSplit(row, createId, beforeConsumableLotQty), SQLUpsertType.INSERT);
				batch.add(createConsumableTransactionOutForSplit(row, createId, batch),SQLUpsertType.INSERT);
				batch.add(createConsumableTransactionInForSplit(row, createId, batch),SQLUpsertType.INSERT);
				batch.add(getLogErpDataForSplit(row, createId, batch, txnInfo.getTxnUser()), SQLUpsertType.INSERT);
				
				Map<String, Object> result = new HashMap<String, Object>();
				result.put("LOTID", createId);
				
				dtReturn.addRow(result);
			}
			
		}
	
		batch.execute();
	}
	private SfConsumablelotData changeLocation(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfConsumablelotData code = new SfConsumablelotData();
		SfConsumablelotKey codeKey = code.key();
		
		codeKey.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("CONSUMABLELOTID")));
		}
			
		code.setWarehouseid(row.getString("TOWAREHOUSEID"));
		code.setLocationid(row.getString("CELLID"));
		code.setConsumablestate("Available");
		code.setConsumablelotqty(row.getDouble("CONSUMABLELOTQTY"));

		return code;
	}
	
	private SfConsumablelotData changeLocationForSplit(IDataRow row, ISQLUpsertBatch batch, Double beforeConsumableLotQty) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfConsumablelotData code = new SfConsumablelotData();
		SfConsumablelotKey codeKey = code.key();
		
		codeKey.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("CONSUMABLELOTID")));
		}
		
		SplitLotAndLabel currentClass = new SplitLotAndLabel();
		Double qty = currentClass.changeConsumableLotQty(row, beforeConsumableLotQty);
		
		//code.setConsumablelotqty(row.getDouble("CONSUMABLELOTQTY")-row.getDouble("QTY"));
		
		code.setConsumablelotqty(qty);
		
		return code;
	}
	
	private SfConsumablelotData splitLot(IDataRow row, ISQLUpsertBatch batch, String sConsumableLotId, String createId, Double beforeConsumableLotQty) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfConsumablelotData code = new SfConsumablelotData();
		SfConsumablelotKey codeKey = code.key();
			
		codeKey.setConsumablelotid(createId);

		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("CONSUMABLELOTID")));
		}
		
		SfConsumablelotData newCode = new SfConsumablelotData();
		SfConsumablelotKey newCodeKey = newCode.key();

		
		newCodeKey.setConsumablelotid(createId);
		
		SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(sConsumableLotId);
		//Double dConsumableLotQty = conLotData.get

		Double splitLotQty=changeConsumableLotQty(row, beforeConsumableLotQty);
	
		newCode.setEnterpriseid(conLotData.getEnterpriseid());
		newCode.setPlantid(conLotData.getPlantid());
		newCode.setAreaid(conLotData.getAreaid());
		newCode.setWarehouseid(conLotData.getWarehouseid());
		newCode.setLocationid(row.getString("CELLID"));
		newCode.setConsumabledefid(row.getString("CONSUMABLEDEFID"));
		newCode.setConsumabledefversion(conLotData.getConsumabledefversion());
		newCode.setConsumablestate(Constant.CONSUMABLESTATE_AVAILABLE);
		
		//newCode.setCreatedqty(row.getDouble("QTY"));
		//newCode.setConsumablelotqty(row.getDouble("QTY"));
		
		newCode.setCreatedqty(splitLotQty);
		newCode.setConsumablelotqty(splitLotQty);
		
		newCode.setOrderseq(conLotData.getOrderseq());
		newCode.setParentconsumablelotid(sConsumableLotId);
		newCode.setState("InMate");

		return newCode;
	}
	
	private Double changeConsumableLotQty(IDataRow row, Double beforeConsumableLotQty) {
		
		Double splitLotQty = null;
		
		if(beforeConsumableLotQty==null) {
			splitLotQty = row.getDouble("QTY");
		}else {
			splitLotQty = row.getDouble("QTY") - beforeConsumableLotQty;
		}
		return splitLotQty;
	}
	
	//자재LOT정보 저장 
	private ISQLData saveLotData(IDataRow row, String sConsumableLotId) throws InValidDataException, DatabaseException, MESException, SystemException { 
				
		
				UlKanbanmappinglotData code = new UlKanbanmappinglotData();
				 UlKanbanmappinglotKey codeKey = code.key();
		  
		
				  codeKey.setReqcode(row.getString("REQCODE"));
				  codeKey.setLotid(sConsumableLotId);
				  
				  code = code.selectOne();
				  
				  if (code != null) 
				  { 
					  throw new InValidDataException("InValidData002", String.format("REQCODE = %s", row.getString("REQCODE"))); 
				  }
				  
				  UlKanbanmappinglotData newCode = new UlKanbanmappinglotData();
				  UlKanbanmappinglotKey newCodeKey = newCode.key();
				  
				  newCodeKey.setReqcode(row.getString("REQCODE"));
				  newCodeKey.setLotid(sConsumableLotId);
				  
				  newCode.setCellid(row.getString("CELLID"));
				  newCode.setUnit(row.getString("UNITNAME"));
				  newCode.setQty(row.getDouble("CONSUMABLELOTQTY"));
				  return newCode;
		}
	
	//자재LOT정보 저장 
	private ISQLData saveLotDataForSplit(IDataRow row, String createId, Double beforeConsumableLotQty) throws InValidDataException, DatabaseException, MESException, SystemException { 
					
			
			UlKanbanmappinglotData code = new UlKanbanmappinglotData();
			UlKanbanmappinglotKey codeKey = code.key();
			  
			
				codeKey.setReqcode(row.getString("REQCODE"));
				codeKey.setLotid(createId);
					  
					  code = code.selectOne();
					  
					  if (code != null) 
					  { 
						  throw new InValidDataException("InValidData002", String.format("REQCODE = %s", row.getString("REQCODE"))); 
					  }
					  
					  UlKanbanmappinglotData newCode = new UlKanbanmappinglotData();
					  UlKanbanmappinglotKey newCodeKey = newCode.key();
					  
						SplitLotAndLabel currentClass = new SplitLotAndLabel();
						Double qty = currentClass.changeConsumableLotQty(row, beforeConsumableLotQty);
					  
					  newCodeKey.setReqcode(row.getString("REQCODE"));
					  newCodeKey.setLotid(createId);
					  
					  newCode.setCellid(row.getString("CELLID"));
					  newCode.setUnit(row.getString("UNITNAME"));
					  //newCode.setQty(row.getDouble("QTY"));
					  newCode.setQty(qty);
					  
				return newCode;
			}
		
	// ERP창고이동
	private UlErptmeslgmvData getLogErpData(IDataRow lotRow, ISQLUpsertBatch batch, String sUserId) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlErptmeslgmvData code = new UlErptmeslgmvData();
			//UlErptmeslgmvKey codeKey = code.key();
			
			Date today = new Date();
			SimpleDateFormat f = new SimpleDateFormat("yyyyMMdd");
			
			code.setCrtdatetime(today);
			code.setRecvyn(Constant.NO);
			code.setMvdate(f.format(today).toString());
			
			ISQLCondition cond = new SQLCondition(false);
			
			SfConsumabledefinitionData mateData = new SfConsumabledefinitionData();
			cond.set(SfConsumabledefinitionData.Consumabledefid, lotRow.getString("CONSUMABLEDEFID"));
			ISQLDataList<SfConsumabledefinitionData> mateDataList = mateData.select(cond);
			mateData = mateDataList.get(0);
			cond.clear();

			code.setItemseq(mateData.getErp_consumabledefid());
			code.setItemno(lotRow.getString("CONSUMABLEDEFID"));
			code.setMvqty(lotRow.getDouble("CONSUMABLELOTQTY"));
			code.setOutwhseq(Integer.parseInt("1"));
			code.setInwhseq(lotRow.getInteger("TOWAREHOUSEID"));
			code.setMvtype(8012001);
			
			SfUserData userData = new SfUserData();
			
			cond.set(SfUserData.Userid, sUserId);
			ISQLDataList<SfUserData> userDataList = userData.select(cond);
			userData = userDataList.get(0);
			cond.clear();
			
			code.setEmpseq(Integer.parseInt(userData.getErp_empno()));
			
			String sConsumableType = lotRow.getString("CONSUMABLETYPE");
			if(sConsumableType.equals("Material"))
			{
				code.setIsmatyn("0");
			}
			else
			{
				code.setIsmatyn("1");
			}
			
			code.setTossyn(Constant.NO);
			code.setInterfacetxnhistkey(Generate.createTimeKey());
			
			return code;
		}
	
	// ERP창고이동 - Split
	private UlErptmeslgmvData getLogErpDataForSplit(IDataRow lotRow, String sConsumableLotId, ISQLUpsertBatch batch, String sUserId) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlErptmeslgmvData code = new UlErptmeslgmvData();
		//UlErptmeslgmvKey codeKey = code.key();
		
		Date today = new Date();
		SimpleDateFormat f = new SimpleDateFormat("yyyyMMdd");
		
		code.setCrtdatetime(today);
		code.setRecvyn(Constant.NO);
		code.setMvdate(f.format(today).toString());
		
		ISQLCondition cond = new SQLCondition(false);
		
		//SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(sConsumableLotId);

		
		SfConsumabledefinitionData mateData = new SfConsumabledefinitionData();
		cond.set(SfConsumabledefinitionData.Consumabledefid, lotRow.getString("CONSUMABLEDEFID"));
		ISQLDataList<SfConsumabledefinitionData> mateDataList = mateData.select(cond);
		mateData = mateDataList.get(0);
		cond.clear();

		code.setItemseq(mateData.getErp_consumabledefid());
		code.setItemno(lotRow.getString("CONSUMABLEDEFID"));
		code.setMvqty(lotRow.getDouble("QTY"));
		code.setOutwhseq(Integer.parseInt("1"));
		code.setInwhseq(lotRow.getInteger("TOWAREHOUSEID"));
		code.setMvtype(8012001);
		
		SfUserData userData = new SfUserData();
		
		cond.set(SfUserData.Userid, sUserId);
		ISQLDataList<SfUserData> userDataList = userData.select(cond);
		userData = userDataList.get(0);
		cond.clear();
		
		code.setEmpseq(Integer.parseInt(userData.getErp_empno()));
		
		String sConsumableType = lotRow.getString("CONSUMABLETYPE");
		if(sConsumableType.equals("Material"))
		{
			code.setIsmatyn("0");
		}
		else
		{
			code.setIsmatyn("1");
		}
		
		code.setTossyn(Constant.NO);
		code.setInterfacetxnhistkey(Generate.createTimeKey());
		
		return code;
	}
	
	//입출력이력(OUT)
	private CtConsumabletransactionData createConsumableTransactionOut(IDataRow lotRow, String lotId, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{	
	
		Map<String, Object> rowMap = new HashMap<String, Object>();
		rowMap.put("TXNHISTKEY", Generate.createTimeKey());
		
		SfConsumabledefinitionData item = SfConsumableDefinitionService.getConsumabledefinition(lotRow.getString("CONSUMABLEDEFID"), Constant.ASTERISK);
		
		rowMap.put("ENTERPRISEID", item.getEnterpriseid());
		rowMap.put("PLANTID", item.getPlantid());
		rowMap.put("AREAID", Constant.EMPTY);
		rowMap.put("EQUIPMENTID", Constant.EMPTY);
		rowMap.put("WAREHOUSEID", lotRow.getInteger("FROMWAREHOUSEID"));
		rowMap.put("CONSUMABLEDEFID", lotRow.getString("CONSUMABLEDEFID"));
		rowMap.put("CONSUMABLEDEFVERSION", Constant.ASTERISK);
		rowMap.put("CONSUMABLELOTID", lotId);
		rowMap.put("TRANSACTIONTYPE", "Out");
		rowMap.put("TRANSACTIONCODE", "OKB");
		rowMap.put("QTY", lotRow.getDouble("CONSUMABLELOTQTY"));
		rowMap.put("TOWAREHOUSEID", lotRow.getInteger("TOWAREHOUSEID"));
		rowMap.put("TRANSACTIONDETAILCODE", Constant.EMPTY);
		rowMap.put("TEAMID", Constant.EMPTY);
		rowMap.put("CUSTOMERID", Constant.EMPTY);
		rowMap.put("REFERENCEKEY", lotRow.getString("REQCODE"));
		rowMap.put("CELLID", Constant.EMPTY);
	
		IDataSet ds = new DataSet();
		IDataTable dt = ds.addTable("transaction");
		dt.addRow(rowMap);
		
		CtConsumabletransactionData data = ConsumableTransactionUtils.getInsertData(dt.getFirstRow(), null);
		return data;
	}
	
	//입출력이력(IN)
	private CtConsumabletransactionData createConsumableTransactionIn(IDataRow lotRow, String lotId, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{	
		Map<String, Object> rowMap = new HashMap<String, Object>();
		rowMap.put("TXNHISTKEY", Generate.createTimeKey());
			
		SfConsumabledefinitionData item = SfConsumableDefinitionService.getConsumabledefinition(lotRow.getString("CONSUMABLEDEFID"), Constant.ASTERISK);
		
		rowMap.put("ENTERPRISEID", item.getEnterpriseid());
		rowMap.put("PLANTID", item.getPlantid());
		rowMap.put("AREAID", Constant.EMPTY);
		rowMap.put("EQUIPMENTID", Constant.EMPTY);
		rowMap.put("WAREHOUSEID", lotRow.getInteger("TOWAREHOUSEID"));
		rowMap.put("CONSUMABLEDEFID", lotRow.getString("CONSUMABLEDEFID"));
		rowMap.put("CONSUMABLEDEFVERSION", Constant.ASTERISK);
		rowMap.put("CONSUMABLELOTID", lotId);
		rowMap.put("TRANSACTIONTYPE", "In");
		rowMap.put("TRANSACTIONCODE", "IR");
		rowMap.put("QTY", lotRow.getDouble("CONSUMABLELOTQTY"));
		rowMap.put("TOWAREHOUSEID", Constant.EMPTY);
		rowMap.put("TOWAREHOUSEID", Constant.EMPTY);
		rowMap.put("TRANSACTIONDETAILCODE", Constant.EMPTY);
		rowMap.put("TEAMID", Constant.EMPTY);
		rowMap.put("CUSTOMERID", Constant.EMPTY);
		rowMap.put("REFERENCEKEY", lotRow.getString("REQCODE"));
		rowMap.put("CELLID", Constant.EMPTY);
	
		IDataSet ds = new DataSet();
		IDataTable dt = ds.addTable("transaction");
		dt.addRow(rowMap);
		
		CtConsumabletransactionData data = ConsumableTransactionUtils.getInsertData(dt.getFirstRow(), null);
		return data;
	}

	//Split입출력이력(OUT) - Split
	private CtConsumabletransactionData createConsumableTransactionOutForSplit(IDataRow lotRow, String lotId, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{	
		
			Map<String, Object> rowMap = new HashMap<String, Object>();
			rowMap.put("TXNHISTKEY", Generate.createTimeKey());
			
			SfConsumabledefinitionData item = SfConsumableDefinitionService.getConsumabledefinition(lotRow.getString("CONSUMABLEDEFID"), Constant.ASTERISK);
			
			rowMap.put("ENTERPRISEID", item.getEnterpriseid());
			rowMap.put("PLANTID", item.getPlantid());
			rowMap.put("AREAID", Constant.EMPTY);
			rowMap.put("EQUIPMENTID", Constant.EMPTY);
			rowMap.put("WAREHOUSEID", lotRow.getInteger("FROMWAREHOUSEID"));
			rowMap.put("CONSUMABLEDEFID", lotRow.getString("CONSUMABLEDEFID"));
			rowMap.put("CONSUMABLEDEFVERSION", Constant.ASTERISK);
			rowMap.put("CONSUMABLELOTID", lotId);
			rowMap.put("TRANSACTIONTYPE", "Out");
			rowMap.put("TRANSACTIONCODE", "OKB");
			rowMap.put("QTY", lotRow.getDouble("QTY"));
			rowMap.put("TOWAREHOUSEID", lotRow.getInteger("TOWAREHOUSEID"));
			rowMap.put("TRANSACTIONDETAILCODE", Constant.EMPTY);
			rowMap.put("TEAMID", Constant.EMPTY);
			rowMap.put("CUSTOMERID", Constant.EMPTY);
			rowMap.put("REFERENCEKEY", lotRow.getString("REQCODE"));
			rowMap.put("CELLID", Constant.EMPTY);
		
			IDataSet ds = new DataSet();
			IDataTable dt = ds.addTable("transaction");
			dt.addRow(rowMap);
			
			CtConsumabletransactionData data = ConsumableTransactionUtils.getInsertData(dt.getFirstRow(), null);
			return data;
		}
	
	//Split입출력이력(IN) - Split
	private CtConsumabletransactionData createConsumableTransactionInForSplit(IDataRow lotRow, String lotId, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{	
		Map<String, Object> rowMap = new HashMap<String, Object>();
		rowMap.put("TXNHISTKEY", Generate.createTimeKey());
			
		SfConsumabledefinitionData item = SfConsumableDefinitionService.getConsumabledefinition(lotRow.getString("CONSUMABLEDEFID"), Constant.ASTERISK);
		
		rowMap.put("ENTERPRISEID", item.getEnterpriseid());
		rowMap.put("PLANTID", item.getPlantid());
		rowMap.put("AREAID", Constant.EMPTY);
		rowMap.put("EQUIPMENTID", Constant.EMPTY);
		rowMap.put("WAREHOUSEID", lotRow.getInteger("TOWAREHOUSEID"));
		rowMap.put("CONSUMABLEDEFID", lotRow.getString("CONSUMABLEDEFID"));
		rowMap.put("CONSUMABLEDEFVERSION", Constant.ASTERISK);
		rowMap.put("CONSUMABLELOTID", lotId);
		rowMap.put("TRANSACTIONTYPE", "In");
		rowMap.put("TRANSACTIONCODE", "IR");
		rowMap.put("QTY", lotRow.getDouble("QTY"));
		rowMap.put("TOWAREHOUSEID", Constant.EMPTY);
		rowMap.put("TOWAREHOUSEID", Constant.EMPTY);
		rowMap.put("TRANSACTIONDETAILCODE", Constant.EMPTY);
		rowMap.put("TEAMID", Constant.EMPTY);
		rowMap.put("CUSTOMERID", Constant.EMPTY);
		rowMap.put("REFERENCEKEY", lotRow.getString("REQCODE"));
		rowMap.put("CELLID", Constant.EMPTY);
	
		IDataSet ds = new DataSet();
		IDataTable dt = ds.addTable("transaction");
		dt.addRow(rowMap);
		
		CtConsumabletransactionData data = ConsumableTransactionUtils.getInsertData(dt.getFirstRow(), null);
		return data;
	}
	
		
}

