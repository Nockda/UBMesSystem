package kr.co.micube.mes.material.rule;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.service.SfConsumableLotService;
import kr.co.micube.common.mes.so.CtConsumablelotgenealData;
import kr.co.micube.common.mes.so.CtConsumablelotgenealKey;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.common.mes.so.UlMaterialdeliveryData;
import kr.co.micube.common.mes.so.UlMaterialdeliveryKey;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.standard.service.IdService;
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
 * 프  로  그  램  명	: 자재관리 > 자재 > 자재LOT출고
 * 설               명	: 자재LOT를 출고 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-04-21
 * 수   정   이   력	: 2020-06-09 | scmo
 */
public class DeliveryMaterial extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		
		
		IDataSet dsReturn = this.getResponseDataset();
		IDataTable dtReturn = dsReturn.addTable("DATA");
		
	
		for (int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);
		
			String sConsumableLotId = row.getString("CONSUMABLELOTID");
			SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(sConsumableLotId);
			Double dConsumableLotQty = conLotData.getConsumablelotqty();
			
			if(dConsumableLotQty.equals(row.getDouble("CONSUMABLELOTQTY"))){
				batch.add(changeLocation(row, batch), SQLUpsertType.UPDATE);
				batch.add(createMaterialDelivery(row, batch), SQLUpsertType.INSERT);
			}
			else {
				List<String> argList = new ArrayList<>();
				TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
				String createId = IdService.createId("LotNo", 1, argList, txnInfo).get(0);
				batch.add(splitLot(row, batch, sConsumableLotId, createId), SQLUpsertType.INSERT);
				batch.add(changeLocationForSplit(row, batch), SQLUpsertType.UPDATE);
				batch.add(createMaterialDeliveryForSplit(row, batch, createId), SQLUpsertType.INSERT);
				batch.add(genealDataParent(row, batch, txnInfo), SQLUpsertType.INSERT);
				batch.add(genealDataChild(row, batch, createId, txnInfo), SQLUpsertType.INSERT);
				
				Map<String, Object> result = new HashMap<String, Object>();
				result.put("LOTID", createId);
				
				dtReturn.addRow(result);
			}	
			
		}
	
		batch.execute();
	}

	private UlMaterialdeliveryData createMaterialDelivery(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlMaterialdeliveryData code = new UlMaterialdeliveryData();
		UlMaterialdeliveryKey codeKey = code.key();
			
		codeKey.setSeq(row.getInteger("SEQ"));
	
		UlMaterialdeliveryData newCode = new UlMaterialdeliveryData();

		newCode.setReqseq(row.getInteger("REQSEQ"));
		newCode.setReqserl(row.getInteger("REQSERL"));
		newCode.setReqno(row.getString("REQNO"));
		newCode.setItemseq(row.getInteger("ITEMSEQ"));
		newCode.setItemno(row.getString("CONSUMABLEDEFID"));
		newCode.setOutwhseq(row.getInteger("OUTWHSEQ"));
		newCode.setInwhseq(row.getInteger("INWHSEQ"));
		newCode.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		newCode.setOutqty(row.getDouble("CONSUMABLELOTQTY"));
		newCode.setCompleteyn(Constant.NO);
		newCode.setTossyn(Constant.NO);
		newCode.setDepartmentid(row.getString("DEPTSEQ"));
			
		return newCode;
	}
	
	private UlMaterialdeliveryData createMaterialDeliveryForSplit(IDataRow row, ISQLUpsertBatch batch, String createId) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlMaterialdeliveryData code = new UlMaterialdeliveryData();
		UlMaterialdeliveryKey codeKey = code.key();
			
		codeKey.setSeq(row.getInteger("SEQ"));
	
		UlMaterialdeliveryData newCode = new UlMaterialdeliveryData();

		newCode.setReqseq(row.getInteger("REQSEQ"));
		newCode.setReqserl(row.getInteger("REQSERL"));
		newCode.setReqno(row.getString("REQNO"));
		newCode.setItemseq(row.getInteger("ITEMSEQ"));
		newCode.setItemno(row.getString("CONSUMABLEDEFID"));
		newCode.setOutwhseq(row.getInteger("OUTWHSEQ"));
		newCode.setInwhseq(row.getInteger("INWHSEQ"));
		newCode.setConsumablelotid(createId);
		newCode.setOutqty(row.getDouble("CONSUMABLELOTQTY"));
		newCode.setCompleteyn(Constant.NO);
		newCode.setTossyn(Constant.NO);
		newCode.setDepartmentid(row.getString("DEPTSEQ"));
			
		return newCode;
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

		code.setConsumablestate("InAvailable");
		code.setConsumablelotqty(row.getDouble("CONSUMABLELOTQTY"));

		return code;
	}
	
	private SfConsumablelotData changeLocationForSplit(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfConsumablelotData code = new SfConsumablelotData();
		SfConsumablelotKey codeKey = code.key();
		
		codeKey.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("CONSUMABLELOTID")));
		}
		
		SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(row.getString("CONSUMABLELOTID"));
		Double dConsumableLotQty = conLotData.getConsumablelotqty();
			
		code.setConsumablelotqty(dConsumableLotQty-row.getDouble("CONSUMABLELOTQTY"));

		return code;
	}
	
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
		newCode.setAreaid(conLotData.getAreaid());
		newCode.setWarehouseid(conLotData.getWarehouseid());
		newCode.setLocationid(conLotData.getLocationid());
		newCode.setConsumabledefid(conLotData.getConsumabledefid());
		newCode.setConsumabledefversion(conLotData.getConsumabledefversion());
		newCode.setConsumablestate("InAvailable");
		newCode.setCreatedqty(row.getDouble("CONSUMABLELOTQTY"));
		newCode.setConsumablelotqty(row.getDouble("CONSUMABLELOTQTY"));
		newCode.setOrderseq(conLotData.getOrderseq());
		newCode.setParentconsumablelotid(sConsumableLotId);
		newCode.setState("InMate");

		return newCode;
	}
	
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
		data.setQty(conLotData.getConsumablelotqty()-row.getDouble("CONSUMABLELOTQTY"));
		data.setTxnid(txnInfo.getTxnId());
		data.setTxnuser(txnInfo.getTxnUser());
		data.setTxntime(txnInfo.getTxnTime());
		data.setTxngrouphistkey(txnInfo.getGroupHistKey());
		data.setTxnreasoncodeclass(txnInfo.getTxnReasonCodeClass());
		data.setTxnreasoncode(txnInfo.getTxnReasonCode());
		data.setTxncomment(txnInfo.getTxnComment());	
		
		return data;
	}
	
	private CtConsumablelotgenealData genealDataChild(IDataRow row, ISQLUpsertBatch batch, String createId, TxnInfo txnInfo) throws InValidDataException, DatabaseException, MESException, SystemException
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
		data.setQty(row.getDouble("CONSUMABLELOTQTY"));
		data.setTxnid(txnInfo.getTxnId());
		data.setTxnuser(txnInfo.getTxnUser());
		data.setTxntime(txnInfo.getTxnTime());
		data.setTxngrouphistkey(txnInfo.getGroupHistKey());
		data.setTxnreasoncodeclass(txnInfo.getTxnReasonCodeClass());
		data.setTxnreasoncode(txnInfo.getTxnReasonCode());
		data.setTxncomment(txnInfo.getTxnComment());	
		
		return data;
	}
}
