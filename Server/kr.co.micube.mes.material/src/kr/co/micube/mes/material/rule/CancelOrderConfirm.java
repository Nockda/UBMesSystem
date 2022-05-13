package kr.co.micube.mes.material.rule;

import java.text.ParseException;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.CtConsumabletransactionData;
import kr.co.micube.common.mes.so.CtReceivinginspectionData;
import kr.co.micube.common.mes.so.SfAreaData;
import kr.co.micube.common.mes.so.SfAreaKey;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.common.mes.so.UlErptmesspudelvData;
import kr.co.micube.common.mes.so.UlOrderdetailData;
import kr.co.micube.common.mes.so.UlOrderdetailKey;
import kr.co.micube.common.mes.util.ConsumableTransactionUtils;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.standard.info.ConsumeConsumableLotInfo;
import kr.co.micube.commons.factory.standard.service.ConsumableLotService;
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
 * 프  로  그  램  명	: 자재관리 > 자재 > 자재LOT입고완료 취소
 * 설               명	: ERP전송완료 된 건 삭제
 * 생      성      자	: scmo
 * 생      성      일	: 2020-08-07
 * 수   정   이   력	: 
 */
public class CancelOrderConfirm extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();		
		IDataRow row = null;

		row = dt.getRow(0);
		TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
		
		ConsumableLotConsumedAll(row, txnInfo);
		DeleteOrderDetailData(row);
		UpdateReceivingInspection(row);
	}
	
	private void DeleteOrderDetailData(IDataRow row) throws DatabaseException
	{	
		UlOrderdetailData cd = new UlOrderdetailData();
		UlOrderdetailKey key = cd.key();
		
		key.setSeq(row.getInteger("ORDERSEQ"));
		cd = cd.selectOne();
		cd.delete();
	}
	

	private void ConsumableLotConsumedAll(IDataRow row, TxnInfo txnInfo) throws Throwable
	{
		ISQLCondition cond = new SQLCondition(false);
		cond.set(SfConsumablelotData.Orderseq, row.getInteger("ORDERSEQ"));
		cond.set(SfConsumablelotData.Warehouseid, row.getString("WHSEQ"));
		
		SfConsumablelotData cd = new SfConsumablelotData();
				
		ISQLDataList<SfConsumablelotData> ret = cd.select(cond);
		for (int i = 0, len = ret.size(); i < len; i++) {
			SfConsumablelotData data = ret.get(i);
			SfConsumablelotKey key = data.key();
			
			ConsumeConsumableLotInfo lotInfo = new ConsumeConsumableLotInfo();
			lotInfo.setConsumableLotId(key.getConsumablelotid());
			lotInfo.setConsumedQty(data.getConsumablelotqty());
			txnInfo.setTxnReasonCode("CancelConfirm");
			ConsumableLotService.consumeConsumableLot(lotInfo, txnInfo);		
			
			createConsumableTransaction(row, data);
		}
	}
	
	private void UpdateReceivingInspection(IDataRow row)throws DatabaseException
	{
		ISQLCondition cond = new SQLCondition(false);
		cond.set(CtReceivinginspectionData.Deliveryno, row.getString("DELVNO"));
		cond.set(CtReceivinginspectionData.Deliverysequence, row.getString("DELVSERL"));
		cond.set(CtReceivinginspectionData.Consumabledefid, row.getString("ITEMSEQ"));
		
		CtReceivinginspectionData cd = new CtReceivinginspectionData();
		ISQLDataList<CtReceivinginspectionData> cdList  = cd.select(cond);
		
		if(cdList.size() > 0)
		{
			cd = cdList.get(0);
			cond.clear();
			
			cd.setDescription("Canceled");
			cd.update();
		}
	}
	
	private void createConsumableTransaction(IDataRow row, SfConsumablelotData lotData) throws InValidDataException, MESException, SystemException
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
		rowMap.put("TRANSACTIONCODE", "IBC");
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
		data.insert();
	}
}
