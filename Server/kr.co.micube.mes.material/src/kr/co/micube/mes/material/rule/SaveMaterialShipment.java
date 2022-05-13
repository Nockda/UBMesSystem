package kr.co.micube.mes.material.rule;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.service.SfConsumableLotService;
import kr.co.micube.common.mes.so.CtConsumablelotgenealData;
import kr.co.micube.common.mes.so.CtConsumablelotgenealKey;
import kr.co.micube.common.mes.so.CtConsumabletransactionData;
import kr.co.micube.common.mes.so.CtConsumabletransactionKey;
import kr.co.micube.common.mes.so.CtShippedconsumablelotData;
import kr.co.micube.common.mes.so.CtShippedconsumablelotKey;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 자재관리 > 자재재고관리 > 부품출하등록
 * 설               명	: 자재출하처리 (수량, 상태 변경)
 * 생      성      자	: jylee
 * 생      성      일	: 2020-07-09
 * 수   정   이   력	: 
 */
public class SaveMaterialShipment extends DatasetRule {

	@Override
	public void doEvent() throws Throwable {
		
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		//TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
		
		IDataRow row = null;
		
		for(int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);
				batch.add(getUpsertData(row, batch),SQLUpsertType.UPDATE);
				batch.add(getInsertData(row, batch), SQLUpsertType.INSERT);
				batch.add(getInsertTransaction(row, batch), SQLUpsertType.INSERT);
		}
		
		batch.execute();
	}
	
	private CtShippedconsumablelotData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException 
	{
		CtShippedconsumablelotData code = new CtShippedconsumablelotData();
		CtShippedconsumablelotKey codeKey = code.key();
		
		codeKey.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		codeKey.setTxnhistkey(Generate.createTimeKey());
		
		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("CONSUMABLELOTID")));
		}
		
		CtShippedconsumablelotData newCode = new CtShippedconsumablelotData();
		CtShippedconsumablelotKey newCodeKey = newCode.key();
		
		newCodeKey.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		newCodeKey.setTxnhistkey(Generate.createTimeKey());
		
		SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(row.getString("CONSUMABLELOTID"));
		
		newCode.setEnterpriseid(conLotData.getEnterpriseid());
	
		newCode.setPlantid(conLotData.getPlantid());
		newCode.setAreaid(conLotData.getAreaid());
		newCode.setWarehouseid(conLotData.getWarehouseid());
		newCode.setLocationid(conLotData.getLocationid());
		newCode.setQty(conLotData.getConsumablelotqty());
		newCode.setShippedqty(row.getDouble("SHIPMENTQTY"));
		newCode.setDescription(conLotData.getDescription());

		return newCode;
		
	}
	
	private SfConsumablelotData getUpsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException 
	{
		SfConsumablelotData code = new SfConsumablelotData();
		SfConsumablelotKey codeKey = code.key();
		
		SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(row.getString("CONSUMABLELOTID"));
		
		codeKey.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("CONSUMABLELOTID")));
		}
		
		double totalQty = conLotData.getConsumablelotqty() - row.getDouble("SHIPMENTQTY");
		
		code.setConsumablelotqty(totalQty);
		
		if(totalQty == 0) {
			code.setConsumablestate(Constant.LOTSTATE_SHIPPED);
		}
	
		return code;
	}
	
	private CtConsumabletransactionData getInsertTransaction(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException 
	{
		CtConsumabletransactionData code = new CtConsumabletransactionData();
		CtConsumabletransactionKey codeKey = code.key();
		
		SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(row.getString("CONSUMABLELOTID"));
		
				
		codeKey.setTxnhistkey(Generate.createTimeKey());
		
		code.setEnterpriseid(conLotData.getEnterpriseid());
		code.setPlantid(conLotData.getPlantid());
		code.setAreaid(conLotData.getAreaid());
		code.setEquipmentid(conLotData.getEquipmentid());
		code.setWarehouseid(conLotData.getWarehouseid());
		code.setLocationid(conLotData.getLocationid());
		code.setConsumabledefid(conLotData.getConsumabledefid());
		code.setConsumabledefversion(conLotData.getConsumabledefversion());
		code.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		code.setTransactiontype("Out");
		code.setTransactioncode("OS");
		code.setQty(row.getDouble("SHIPMENTQTY"));
		code.setTowarehouseid(conLotData.getWarehouseid());
		code.setDescription(conLotData.getDescription());
		
		
		return code;
		
	}
	
	// 미사용
	private CtConsumablelotgenealData genealDataParent(IDataRow row, ISQLUpsertBatch batch, TxnInfo txnInfo) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		CtConsumablelotgenealData data = new CtConsumablelotgenealData();
		CtConsumablelotgenealKey key = data.key();
		
		key.setTxnhistkey(Generate.createTimeKey());
		key.setConsumablelotid(row.getString("CONSUMABLELOTID"));
			
		SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(row.getString("CONSUMABLELOTID"));

		data.setEnterpriseid(conLotData.getEnterpriseid());
		data.setPlantid(conLotData.getPlantid());
		data.setAreaid(conLotData.getAreaid());
		data.setWarehouseid(conLotData.getWarehouseid());
		data.setConsumabledefid(conLotData.getConsumabledefid());
		data.setConsumabledefversion(conLotData.getConsumabledefversion());
		data.setDestinationlotid(row.getString("CONSUMABLELOTID"));
		data.setTxntype(Constant.IDDEFCATEGORY_SPLIT);
		data.setOriginalqty(conLotData.getConsumablelotqty());
		data.setQty(row.getDouble("CONSUMABLELOTQTY") - row.getDouble("SHIPMENTQTY"));
		data.setTxnid(txnInfo.getTxnId());
		data.setTxnuser(txnInfo.getTxnUser());
		data.setTxntime(txnInfo.getTxnTime());
		data.setTxngrouphistkey(txnInfo.getGroupHistKey());
		data.setTxnreasoncodeclass(txnInfo.getTxnReasonCodeClass());
		data.setTxnreasoncode(txnInfo.getTxnReasonCode());
		data.setTxncomment(txnInfo.getTxnComment());	
		
		return data;
	}
	// 미사용
	private CtConsumablelotgenealData genealDataChild(IDataRow row, String createId, ISQLUpsertBatch batch, TxnInfo txnInfo) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		CtConsumablelotgenealData data = new CtConsumablelotgenealData();
		CtConsumablelotgenealKey key = data.key();
		
		key.setTxnhistkey(Generate.createTimeKey());
		key.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		
		SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(row.getString("CONSUMABLELOTID"));
		
		data.setEnterpriseid(conLotData.getEnterpriseid());
		data.setPlantid(conLotData.getPlantid());
		data.setAreaid(conLotData.getAreaid());
		data.setWarehouseid(conLotData.getWarehouseid());
		data.setConsumabledefid(conLotData.getConsumabledefid());
		data.setConsumabledefversion(conLotData.getConsumabledefversion());
		data.setDestinationlotid(createId);
		data.setTxntype(Constant.IDDEFCATEGORY_SPLIT);
		data.setOriginalqty(conLotData.getConsumablelotqty());
		data.setQty(row.getDouble("SHIPMENTQTY"));
		data.setTxnid(txnInfo.getTxnId());
		data.setTxnuser(txnInfo.getTxnUser());
		data.setTxntime(txnInfo.getTxnTime());
		data.setTxngrouphistkey(txnInfo.getGroupHistKey());
		data.setTxnreasoncodeclass(txnInfo.getTxnReasonCodeClass());
		data.setTxnreasoncode(txnInfo.getTxnReasonCode());
		data.setTxncomment(txnInfo.getTxnComment());	
		
		return data;
	}
	// 미사용
	private SfConsumablelotData splitLot(IDataRow row, ISQLUpsertBatch batch, String sConsumableLotId, String createId) throws InValidDataException, DatabaseException, MESException, SystemException
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
		
		
		newCode.setEnterpriseid(conLotData.getEnterpriseid());
		newCode.setPlantid(conLotData.getPlantid());
		newCode.setAreaid(Constant.EMPTY);
		
		newCode.setWarehouseid(Constant.EMPTY);
		newCode.setLocationid(Constant.EMPTY);
		newCode.setConsumabledefid(row.getString("CONSUMABLEDEFID"));
		newCode.setConsumabledefversion(conLotData.getConsumabledefversion());
		newCode.setConsumablestate(Constant.LOTSTATE_SHIPPED);
		newCode.setCreatedqty(row.getDouble("SHIPMENTQTY"));
		newCode.setConsumablelotqty(row.getDouble("SHIPMENTQTY"));
		newCode.setIshold(Constant.NO);
		//newCode.setOrderseq(conLotData.getOrderseq());
		newCode.setParentconsumablelotid(sConsumableLotId);
		newCode.setState("InProd");

		return newCode;
	}
	// 미사용
	private SfConsumablelotData changeLocationForSplit(IDataRow row, String sConsumableLotId, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfConsumablelotData code = new SfConsumablelotData();
		SfConsumablelotKey codeKey = code.key();
		
		SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(sConsumableLotId);
		
		codeKey.setConsumablelotid(sConsumableLotId);
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", sConsumableLotId));
		}
		code.setWarehouseid(conLotData.getWarehouseid());
		code.setLocationid(conLotData.getLocationid());
		code.setConsumablestate("Available");	
		code.setConsumablelotqty(row.getDouble("CONSUMABLELOTQTY")-row.getDouble("SHIPMENTQTY"));

		return code;
	}
	
}
