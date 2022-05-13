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
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.common.mes.so.SfUserData;
import kr.co.micube.common.mes.so.UlErptmeslgmvData;
import kr.co.micube.common.mes.so.UlMaterialmoveData;
import kr.co.micube.common.mes.util.ConsumableTransactionUtils;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
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
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;


/*
 * 프  로  그  램  명	: 자재관리 > 입출고 > 창고이동처리
 * 설               명	: 자재LOT를 이동처리 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-06-01
 * 수   정   이   력	: 2020-06-29 | scmo | 창고이동팝업변경에 따른 Rule 수정.
 */
public class MoveMaterial extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		
		TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
		
		for (int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);

			batch.add(getMatarialMoveData(row, batch), SQLUpsertType.INSERT);
			batch.add(getLogErpData(row, batch, txnInfo.getTxnUser()), SQLUpsertType.INSERT);
			batch.add(getConsumableTransactionOut(row, batch), SQLUpsertType.INSERT);
			batch.add(getConsumableTransactionIn(row, batch), SQLUpsertType.INSERT);
			batch.add(getUpdateData(row,batch), SQLUpsertType.UPDATE);
		}
	
		batch.execute();
	}
	
	private UlMaterialmoveData getMatarialMoveData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlMaterialmoveData newCode = new UlMaterialmoveData();
		//UlMaterialmoveKey newCodeKey = newCode.key();
		
		//Date today = new Date();
		//SimpleDateFormat f = new SimpleDateFormat("yyyyMMdd");
		
		String sPartnumber = row.getString("CONSUMABLEDEFID");
		SfConsumabledefinitionData defData = SfConsumableDefinitionService.getConsumabledefinitionByPartnumber(sPartnumber);
		SfConsumabledefinitionKey defKey = defData.key();
		String sConsumableDefId = defKey.getConsumabledefid();
		
		newCode.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		newCode.setConsumabledefid(sConsumableDefId);
		newCode.setMoveqty(row.getDouble("CONSUMABLELOTQTY"));
		newCode.setFromwarehouseid(row.getString("WAREHOUSEID"));
		newCode.setFromcellid(row.getString("CELLID"));
		newCode.setTowarehouseid(row.getString("TOWAREHOUSEID"));
		newCode.setTocellid(row.getString("TOCELLID"));
		newCode.setDescription(row.getString("DESCRIPTION"));
		newCode.setMovetype(row.getString("MOVETYPE"));
		
		return newCode;
	}
	
	private UlErptmeslgmvData getLogErpData(IDataRow row, ISQLUpsertBatch batch, String sUserId) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlErptmeslgmvData code = new UlErptmeslgmvData();
		//UlErptmeslgmvKey codeKey = code.key();
		
		Date today = new Date();
		SimpleDateFormat f = new SimpleDateFormat("yyyyMMdd");
		
		code.setCrtdatetime(today);
		code.setRecvyn(Constant.NO);
		code.setMvdate(f.format(today).toString());
		
		ISQLCondition cond = new SQLCondition(false);
		
		String sPartnumber = row.getString("CONSUMABLEDEFID");
		SfConsumabledefinitionData defData = SfConsumableDefinitionService.getConsumabledefinitionByPartnumber(sPartnumber);
		SfConsumabledefinitionKey defKey = defData.key();
		String sConsumableDefId = defKey.getConsumabledefid();

		code.setItemseq(Integer.parseInt(sConsumableDefId));
		code.setItemno(sPartnumber);
		code.setMvqty(row.getDouble("CONSUMABLELOTQTY"));
		code.setOutwhseq(row.getInteger("WAREHOUSEID"));
		code.setInwhseq(row.getInteger("TOWAREHOUSEID"));
		code.setMvtype(row.getInteger("MOVETYPE"));
		code.setRemark(row.getString("DESCRIPTION"));
		code.setLotno(row.getString("CONSUMABLELOTID"));
		
		SfUserData userData = new SfUserData();
		
		cond.set(SfUserData.Userid, sUserId);
		ISQLDataList<SfUserData> userDataList = userData.select(cond);
		userData = userDataList.get(0);
		cond.clear();
		
		code.setEmpseq(Integer.parseInt(userData.getErp_empno()));
		
		String sConsumableType = row.getString("CONSUMABLETYPE");
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
	
	private CtConsumabletransactionData getConsumableTransactionOut(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfConsumablelotData lotData = SfConsumableLotService.getConsumablelot(row.getString("CONSUMABLELOTID"));
		
		Map<String, Object> rowMap = new HashMap<String, Object>();
		rowMap.put("TXNHISTKEY", Generate.createTimeKey());
		rowMap.put("ENTERPRISEID", lotData.getEnterpriseid());
		rowMap.put("PLANTID", lotData.getPlantid());
		rowMap.put("AREAID", lotData.getAreaid());
		rowMap.put("EQUIPMENTID", lotData.getEquipmentid());
		rowMap.put("WAREHOUSEID", row.getString("WAREHOUSEID"));
		rowMap.put("CONSUMABLEDEFID", lotData.getConsumabledefid());
		rowMap.put("CONSUMABLEDEFVERSION", lotData.getConsumabledefversion());
		rowMap.put("CONSUMABLELOTID", row.getString("CONSUMABLELOTID"));
		rowMap.put("TRANSACTIONTYPE", "Out");
		rowMap.put("TRANSACTIONCODE", "IM");
		rowMap.put("QTY", row.getDouble("CONSUMABLELOTQTY"));
		rowMap.put("TOWAREHOUSEID", row.getString("TOWAREHOUSEID"));
		rowMap.put("TRANSACTIONDETAILCODE", row.getString("MOVETYPE"));
		rowMap.put("TEAMID", "");
		rowMap.put("CUSTOMERID", "");
		rowMap.put("REFERENCEKEY", Constant.EMPTY);
		rowMap.put("CELLID", row.getString("CELLID"));
	
		IDataSet ds = new DataSet();
		IDataTable dt = ds.addTable("transaction");
		dt.addRow(rowMap);
		
		CtConsumabletransactionData data = ConsumableTransactionUtils.getInsertData(dt.getFirstRow(), null);
		
		return data;
	}
	
	private CtConsumabletransactionData getConsumableTransactionIn(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfConsumablelotData lotData = SfConsumableLotService.getConsumablelot(row.getString("CONSUMABLELOTID"));
		
		Map<String, Object> rowMap = new HashMap<String, Object>();
		rowMap.put("TXNHISTKEY", Generate.createTimeKey());
		rowMap.put("ENTERPRISEID", lotData.getEnterpriseid());
		rowMap.put("PLANTID", lotData.getPlantid());
		rowMap.put("AREAID", lotData.getAreaid());
		rowMap.put("EQUIPMENTID", lotData.getEquipmentid());
		rowMap.put("WAREHOUSEID", row.getString("TOWAREHOUSEID"));
		rowMap.put("CONSUMABLEDEFID", lotData.getConsumabledefid());
		rowMap.put("CONSUMABLEDEFVERSION", lotData.getConsumabledefversion());
		rowMap.put("CONSUMABLELOTID", row.getString("CONSUMABLELOTID"));
		rowMap.put("TRANSACTIONTYPE", "In");
		rowMap.put("TRANSACTIONCODE", "IR");
		rowMap.put("QTY", row.getDouble("CONSUMABLELOTQTY"));
		rowMap.put("TOWAREHOUSEID", Constant.EMPTY);
		rowMap.put("TRANSACTIONDETAILCODE", row.getString("MOVETYPE"));
		rowMap.put("TEAMID", "");
		rowMap.put("CUSTOMERID", "");
		rowMap.put("REFERENCEKEY", Constant.EMPTY);
		rowMap.put("CELLID", row.getString("TOCELLID"));
	
		IDataSet ds = new DataSet();
		IDataTable dt = ds.addTable("transaction");
		dt.addRow(rowMap);
		
		CtConsumabletransactionData data = ConsumableTransactionUtils.getInsertData(dt.getFirstRow(), null);
		
		return data;
	}
	
	private SfConsumablelotData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
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
		code.setLocationid(row.getString("TOCELLID"));

		return code;
	}
}
