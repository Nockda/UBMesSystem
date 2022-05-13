package kr.co.micube.mes.material.rule;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.service.SfConsumableDefinitionService;
import kr.co.micube.common.mes.so.CtConsumabletransactionData;
import kr.co.micube.common.mes.so.SfConsumabledefinitionData;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.common.mes.so.SfUserData;
import kr.co.micube.common.mes.so.UlErptmesmatoutData;
import kr.co.micube.common.mes.so.UlMaterialdeliveryData;
import kr.co.micube.common.mes.so.UlMaterialdeliveryKey;
import kr.co.micube.common.mes.util.ConsumableTransactionUtils;
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
 * 프  로  그  램  명	: 자재관리 > 자재 > 자재LOT출고
 * 설               명	: 자재LOT를 출고 한다.(확정)
 * 생      성      자	: scmo
 * 생      성      일	: 2020-04-21
 * 수   정   이   력	: 2020-06-09 | scmo
 */
public class DeliveryMaterialConfirm extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;

		for (int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);
					
			
			batch.add(updateMaterialDelivery(row, batch), SQLUpsertType.UPDATE);
			batch.add(logErpData(row,batch), SQLUpsertType.INSERT);
			batch.add(changeLotState(row,batch), SQLUpsertType.UPDATE);
			batch.add(createConsumableTransactionOut(row,batch), SQLUpsertType.INSERT);
			batch.add(createConsumableTransactionIn(row,batch), SQLUpsertType.INSERT);
		}
		
		batch.execute();
	}
	
	private UlMaterialdeliveryData updateMaterialDelivery(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlMaterialdeliveryData code = new UlMaterialdeliveryData();
		UlMaterialdeliveryKey codeKey = code.key();
			
		codeKey.setSeq(row.getInteger("SEQ"));

		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getInteger("SEQ").toString()));
		}

		code.setCompleteyn(Constant.YES);
		
		return code;
	} 
	
	private UlErptmesmatoutData logErpData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlErptmesmatoutData code = new UlErptmesmatoutData();
		
		code.setCrtdatetime(new Date());
		code.setRecvyn(Constant.NO);
		code.setOutreqseq(row.getInteger("REQSEQ"));
		code.setOutreqitemserl(row.getInteger("REQSERL"));
		
		Date today = new Date();
		SimpleDateFormat f = new SimpleDateFormat("yyyyMMdd");
		
		code.setOutdate(f.format(today));
		code.setOutwhseq(row.getInteger("OUTWHSEQ"));
		code.setInwhseq(row.getInteger("INWHSEQ"));
		code.setDeptseq(row.getInteger("DEPTSEQ"));
		
		ISQLCondition cond = new SQLCondition(false);
		SfUserData userData = new SfUserData();
		cond.set(SfUserData.Userid, row.getString("RECEIVERID"));
		ISQLDataList<SfUserData> userDataList = userData.select(cond);
		userData = userDataList.get(0);
		cond.clear();
		
		code.setEmpseq(Integer.parseInt(userData.getErp_empno()));
		code.setItemseq(row.getInteger("ITEMSEQ"));
		code.setItemno(row.getString("CONSUMABLEDEFID"));
		code.setUnitseq(row.getInteger("UNITSEQ"));
		code.setOutqty(row.getDouble("OUTQTY"));
		code.setTossyn(Constant.NO);
		code.setInterfacetxnhistkey(Generate.createTimeKey());
	
		return code;
	}
	
	private SfConsumablelotData changeLotState(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfConsumablelotData code = new SfConsumablelotData();
		SfConsumablelotKey codeKey = code.key();
		
		codeKey.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("CONSUMABLELOTID")));
		}
			
		code.setWarehouseid(row.getString("INWHSEQ"));
		code.setLocationid(null);
		code.setConsumablestate(Constant.CONSUMABLESTATE_AVAILABLE);

		return code;
	}
	
	private CtConsumabletransactionData createConsumableTransactionOut(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{	
		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlMaterialdeliveryData.Seq, row.getInteger("SEQ"));
		UlMaterialdeliveryData md = new UlMaterialdeliveryData();
		ISQLDataList<UlMaterialdeliveryData> mdList = md.select(cond);
		md = mdList.get(0);
		cond.clear();
		
		Map<String, Object> rowMap = new HashMap<String, Object>();
		rowMap.put("TXNHISTKEY", Generate.createTimeKey());
		
		SfConsumabledefinitionData item = SfConsumableDefinitionService.getConsumabledefinition(md.getItemseq().toString(), Constant.ASTERISK);
		
		rowMap.put("ENTERPRISEID", item.getEnterpriseid());
		rowMap.put("PLANTID", item.getPlantid());
		rowMap.put("AREAID", Constant.EMPTY);
		rowMap.put("EQUIPMENTID", Constant.EMPTY);
		rowMap.put("WAREHOUSEID", md.getOutwhseq());
		rowMap.put("CONSUMABLEDEFID", md.getItemseq().toString());
		rowMap.put("CONSUMABLEDEFVERSION", Constant.ASTERISK);
		rowMap.put("CONSUMABLELOTID", md.getConsumablelotid());
		rowMap.put("TRANSACTIONTYPE", "Out");
		rowMap.put("TRANSACTIONCODE", "OR");
		rowMap.put("QTY", md.getOutqty());
		rowMap.put("TOWAREHOUSEID", md.getInwhseq());
		rowMap.put("TRANSACTIONDETAILCODE", Constant.EMPTY);
		rowMap.put("TEAMID", Constant.EMPTY);
		rowMap.put("CUSTOMERID", Constant.EMPTY);
		rowMap.put("REFERENCEKEY", md.getReqno());
		rowMap.put("CELLID", Constant.EMPTY);
	
		IDataSet ds = new DataSet();
		IDataTable dt = ds.addTable("transaction");
		dt.addRow(rowMap);
		
		CtConsumabletransactionData data = ConsumableTransactionUtils.getInsertData(dt.getFirstRow(), null);
		return data;
	}
	
	private CtConsumabletransactionData createConsumableTransactionIn(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{	
		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlMaterialdeliveryData.Seq, row.getInteger("SEQ"));
		UlMaterialdeliveryData md = new UlMaterialdeliveryData();
		ISQLDataList<UlMaterialdeliveryData> mdList = md.select(cond);
		md = mdList.get(0);
		cond.clear();
		
		Map<String, Object> rowMap = new HashMap<String, Object>();
		rowMap.put("TXNHISTKEY", Generate.createTimeKey());
			
		SfConsumabledefinitionData item = SfConsumableDefinitionService.getConsumabledefinition(md.getItemseq().toString(), Constant.ASTERISK);
		
		rowMap.put("ENTERPRISEID", item.getEnterpriseid());
		rowMap.put("PLANTID", item.getPlantid());
		rowMap.put("AREAID", Constant.EMPTY);
		rowMap.put("EQUIPMENTID", Constant.EMPTY);
		rowMap.put("WAREHOUSEID", md.getInwhseq());
		rowMap.put("CONSUMABLEDEFID", md.getItemseq().toString());
		rowMap.put("CONSUMABLEDEFVERSION", Constant.ASTERISK);
		rowMap.put("CONSUMABLELOTID", md.getConsumablelotid());
		rowMap.put("TRANSACTIONTYPE", "In");
		rowMap.put("TRANSACTIONCODE", "IR");
		rowMap.put("QTY", md.getOutqty());
		rowMap.put("TOWAREHOUSEID", Constant.EMPTY);
		rowMap.put("TRANSACTIONDETAILCODE", Constant.EMPTY);
		rowMap.put("TEAMID", Constant.EMPTY);
		rowMap.put("CUSTOMERID", Constant.EMPTY);
		rowMap.put("REFERENCEKEY", md.getReqno());
		rowMap.put("CELLID", Constant.EMPTY);
		
		SfUserData userData = new SfUserData();
		cond.set(SfUserData.Userid, row.getString("RECEIVERID"));
		ISQLDataList<SfUserData> userDataList = userData.select(cond);
		userData = userDataList.get(0);
		
		rowMap.put("DESCRIPTION", userData.getUsername());	//인수자
		
		IDataSet ds = new DataSet();
		IDataTable dt = ds.addTable("transaction");
		dt.addRow(rowMap);
		
		CtConsumabletransactionData data = ConsumableTransactionUtils.getInsertData(dt.getFirstRow(), null);
		return data;
	}
}
