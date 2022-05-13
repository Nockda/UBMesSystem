package kr.co.micube.mes.material.rule;

import java.util.Date;
import java.util.HashMap;
import java.util.Map;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.CtConsumabletransactionData;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.common.mes.so.UlErptmesspudelvData;
import kr.co.micube.common.mes.so.UlOrderdetailData;
import kr.co.micube.common.mes.so.UlOrderdetailKey;
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
 * 프  로  그  램  명	: 자재관리 > 자재 > 자재LOT입고확정
 * 설               명	: 자재LOT를 확정
 * 생      성      자	: scmo
 * 생      성      일	: 2020-05-08
 * 수   정   이   력	: 
 */
public class ChangeConsumableState extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		//String state = null;
		
		for (int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);
			
			batch.add(logErpData(row,batch), SQLUpsertType.INSERT);	
			ChangeConsumableStateNew(row);
			ChangeTossYn(row);
			//batch.add(createConsumableTransaction(row,batch), SQLUpsertType.INSERT);
			
			ISQLCondition cond = new SQLCondition(false);
			cond.set(SfConsumablelotData.Orderseq, row.getInteger("ORDERSEQ"));
			SfConsumablelotData cd = new SfConsumablelotData();					
			ISQLDataList<SfConsumablelotData> ret = cd.select(cond);
			for (int j = 0, jlen = ret.size(); j < jlen; j++) {
				SfConsumablelotData data = ret.get(j);	
				batch.add(createConsumableTransaction(row, data, batch), SQLUpsertType.INSERT);
			}
			cond.clear();
			
		}
		
		batch.execute();
	}
	
	private UlErptmesspudelvData logErpData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlErptmesspudelvData code = new UlErptmesspudelvData();
		//UlErptmesspudelvKey codeKey = code.key();
		
		code.setCrtdatetime(new Date());
		code.setRecvyn("N");
		code.setDelvseq(row.getInteger("DELVSEQ"));
		code.setDelvserl(row.getInteger("DELVSERL"));
		code.setDelvno(row.getString("DELVNO"));
		code.setIndate(row.getString("INDATE"));
		code.setItemseq(row.getInteger("ITEMSEQ"));
		code.setItemno(row.getString("ITEMNO"));
		code.setDelvqty(row.getDouble("DELVQTY"));
		code.setOkqty(row.getDouble("OKQTY"));
		code.setBadqty(row.getDouble("BADQTY"));
		code.setWhseq(row.getInteger("WHSEQ"));
		code.setEmpseq(row.getInteger("EMPSEQ"));
		code.setTossyn(Constant.NO);
		code.setInterfacetxnhistkey(Generate.createTimeKey());
		
		return code;
	}

	private void ChangeConsumableStateNew(IDataRow row) throws DatabaseException
	{
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfConsumablelotData.Orderseq, row.getInteger("ORDERSEQ"));
		
		SfConsumablelotData cd = new SfConsumablelotData();
				
		ISQLDataList<SfConsumablelotData> ret = cd.select(cond);
		for (int i = 0, len = ret.size(); i < len; i++) {
			SfConsumablelotData data = ret.get(i);
			//SfConsumablelotKey key = data.key();
			data.setConsumablestate(Constant.CONSUMABLESTATE_AVAILABLE);
			data.update();
		}
	}
	
	private void ChangeTossYn(IDataRow row) throws DatabaseException
	{
		UlOrderdetailData cd = new UlOrderdetailData();
		UlOrderdetailKey key = cd.key();
		
		key.setSeq(row.getInteger("ORDERSEQ"));
		cd = cd.selectOne();
		cd.setTossyn(Constant.YES);
		cd.update();
	}
	
	private CtConsumabletransactionData createConsumableTransaction(IDataRow row, SfConsumablelotData lotData, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{	
		SfConsumablelotKey cdKey = lotData.key();
	
		Map<String, Object> rowMap = new HashMap<String, Object>();
		rowMap.put("TXNHISTKEY", Generate.createTimeKey());
		rowMap.put("ENTERPRISEID", lotData.getEnterpriseid());
		rowMap.put("PLANTID", lotData.getPlantid());
		rowMap.put("AREAID", lotData.getAreaid());
		rowMap.put("EQUIPMENTID", lotData.getEquipmentid());
		rowMap.put("WAREHOUSEID", lotData.getWarehouseid());
		rowMap.put("CONSUMABLEDEFID", lotData.getConsumabledefid());
		rowMap.put("CONSUMABLEDEFVERSION", lotData.getConsumabledefversion());
		rowMap.put("CONSUMABLELOTID", cdKey.getConsumablelotid());
		rowMap.put("TRANSACTIONTYPE", "In");
		rowMap.put("TRANSACTIONCODE", "IB");
		rowMap.put("QTY", lotData.getCreatedqty());
		rowMap.put("TOWAREHOUSEID", Constant.EMPTY);
		rowMap.put("TRANSACTIONDETAILCODE", Constant.EMPTY);
		rowMap.put("TEAMID", Constant.EMPTY);
		
		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlOrderdetailData.Seq, row.getInteger("ORDERSEQ"));
		UlOrderdetailData od = new UlOrderdetailData();
		ISQLDataList<UlOrderdetailData> odList  = od.select(cond);
		od = odList.get(0);
		cond.clear();

		rowMap.put("CUSTOMERID", od.getCustseq());
		rowMap.put("REFERENCEKEY", od.getDelvno());
		rowMap.put("CELLID", lotData.getLocationid());
	
		IDataSet ds = new DataSet();
		IDataTable dt = ds.addTable("transaction");
		dt.addRow(rowMap);
		
		CtConsumabletransactionData data = ConsumableTransactionUtils.getInsertData(dt.getFirstRow(), null);
		return data;
	}
}
