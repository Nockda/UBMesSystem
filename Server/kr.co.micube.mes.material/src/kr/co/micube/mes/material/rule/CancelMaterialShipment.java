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
 * 설               명	: 등록취소처리 (수량, 상태 변경)
 * 생      성      자	: scmo
 * 생      성      일	: 2020-08-13
 * 수   정   이   력	: 
 */
public class CancelMaterialShipment extends DatasetRule {

	@Override
	public void doEvent() throws Throwable {
		
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		ISQLUpsertBatch batch = new SQLUpsertBatch();
			
		IDataRow row = null;
		
		for(int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);
				batch.add(getUpsertData(row, batch),SQLUpsertType.UPDATE);
				batch.add(getDeleteData(row, batch), SQLUpsertType.DELETE);
				batch.add(getInsertTransaction(row, batch), SQLUpsertType.INSERT);
		}
		
		batch.execute();
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
		
		double totalQty = conLotData.getConsumablelotqty() + row.getDouble("SHIPPEDQTY");
		
		code.setConsumablelotqty(totalQty);
		code.setConsumablestate(Constant.CONSUMABLESTATE_AVAILABLE);
		
		return code;
	}
	
	private CtShippedconsumablelotData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException 
	{
		CtShippedconsumablelotData code = new CtShippedconsumablelotData();
		CtShippedconsumablelotKey codeKey = code.key();
		
		codeKey.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		codeKey.setTxnhistkey(row.getString("TXNHISTKEY"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("CONSUMABLELOTID") + "|" + row.getString("TXNHISTKEY")));
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
		code.setTransactiontype("In");
		code.setTransactioncode("OSC");	//부품출하취소
		code.setQty(row.getDouble("SHIPPEDQTY"));
		code.setTowarehouseid(conLotData.getWarehouseid());
		code.setDescription(conLotData.getDescription());

		return code;
	}
}
