package kr.co.micube.mes.material.rule;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.CtConsumabletransactionData;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.common.mes.so.UlMaterialinitData;
import kr.co.micube.common.mes.so.UlMaterialinitKey;
import kr.co.micube.common.mes.util.ConsumableTransactionUtils;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.so.EnterpriseData;
import kr.co.micube.commons.factory.so.PlantData;
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
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 자재관리 > 자재 > 초기자재LOT생성(ERP연동하지 않는다)
 * 설               명	: 초기 자재LOT를 등록 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-05-26
 * 수   정   이   력	: 
 */
public class CreateConsumableLotByInit extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		String state = null;
		
		for (int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);
			state = row.getString("_STATE_");
			
			switch (state) {
				case UpsertState.INSERT:
					List<String> argList = new ArrayList<>();
					TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
					String createId = "";
					if(row.getString("LOTCREATERULETYPE").equals("Auto"))
					{
						if(row.getString("CONSUMABLETYPE").equals("Material"))
						{
							createId = IdService.createId("LotNo", 1, argList, txnInfo).get(0);
						}
						else
						{
							createId = IdService.createId("PLotNo", 1, argList, txnInfo).get(0);
						}	
					}
					else
					{
						createId = row.getString("CONSUMABLELOTID");
					}
					batch.add(getInsertData(row, batch, createId), SQLUpsertType.INSERT);
					batch.add(getInsertDataToLog(row, batch, createId), SQLUpsertType.INSERT);
					batch.add(createConsumableTransaction(row, batch, createId), SQLUpsertType.INSERT);
					break;
			}
		}
		
		batch.execute();
	}
		
	// Insert Code
	private SfConsumablelotData getInsertData(IDataRow row, ISQLUpsertBatch batch, String createId) throws InValidDataException, DatabaseException, MESException, SystemException
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
		
		EnterpriseData enterpriseData = new EnterpriseData();
		ISQLDataList<EnterpriseData> enterpriseDataList = enterpriseData.selectAll();
		enterpriseData = enterpriseDataList.get(0);
		
		
		PlantData plantData = new PlantData();
		ISQLDataList<PlantData> plantDataList = plantData.selectAll();
		plantData = plantDataList.get(0);
		
		newCode.setEnterpriseid(enterpriseData.getEnterpriseid());
		newCode.setPlantid(plantData.getPlantid());
		newCode.setAreaid(Constant.ASTERISK);
		newCode.setWarehouseid(row.getString("WAREHOUSEID"));
		newCode.setLocationid(row.getString("LOCATIONID"));
		newCode.setConsumabledefid(row.getString("CONSUMABLEDEFID"));
		newCode.setConsumabledefversion(Constant.ASTERISK);
		newCode.setConsumablestate(row.getString("CONSUMABLESTATE"));
		newCode.setCreatedqty(row.getDouble("CREATEDQTY"));
		newCode.setConsumablelotqty(row.getDouble("CREATEDQTY"));
		newCode.setState(row.getString("STATE"));

		return newCode;
	}
	
	private UlMaterialinitData getInsertDataToLog(IDataRow row, ISQLUpsertBatch batch, String createId) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlMaterialinitData code = new UlMaterialinitData();
		UlMaterialinitKey codeKey = code.key();
			
		codeKey.setConsumablelotid(createId);

		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("CONSUMABLELOTID")));
		}
		
		UlMaterialinitData newCode = new UlMaterialinitData();
		UlMaterialinitKey newCodeKey = newCode.key();

		newCodeKey.setConsumablelotid(createId);
		
		newCode.setWarehouseid(row.getString("WAREHOUSEID"));
		newCode.setLocationid(row.getString("LOCATIONID"));
		newCode.setConsumabledefid(row.getString("CONSUMABLEDEFID"));
		newCode.setCreatedqty(row.getDouble("CREATEDQTY"));

		return newCode;
	}
	
	private CtConsumabletransactionData createConsumableTransaction(IDataRow row, ISQLUpsertBatch batch, String createId) throws InValidDataException, DatabaseException, MESException, SystemException
	{	
		EnterpriseData enterpriseData = new EnterpriseData();
		ISQLDataList<EnterpriseData> enterpriseDataList = enterpriseData.selectAll();
		enterpriseData = enterpriseDataList.get(0);
				
		PlantData plantData = new PlantData();
		ISQLDataList<PlantData> plantDataList = plantData.selectAll();
		plantData = plantDataList.get(0);
	
		Map<String, Object> rowMap = new HashMap<String, Object>();
		rowMap.put("TXNHISTKEY", Generate.createTimeKey());
		rowMap.put("ENTERPRISEID", enterpriseData.getEnterpriseid());
		rowMap.put("PLANTID", plantData.getPlantid());
		rowMap.put("AREAID", Constant.EMPTY);
		rowMap.put("EQUIPMENTID", Constant.EMPTY);
		rowMap.put("WAREHOUSEID", row.getString("WAREHOUSEID"));
		rowMap.put("CONSUMABLEDEFID", row.getString("CONSUMABLEDEFID"));
		rowMap.put("CONSUMABLEDEFVERSION",Constant.ASTERISK);
		rowMap.put("CONSUMABLELOTID", createId);
		rowMap.put("TRANSACTIONTYPE", "In");
		rowMap.put("TRANSACTIONCODE", "II");
		rowMap.put("QTY", row.getDouble("CREATEDQTY"));
		rowMap.put("TOWAREHOUSEID", Constant.EMPTY);
		rowMap.put("TRANSACTIONDETAILCODE", Constant.EMPTY);
		rowMap.put("TEAMID", Constant.EMPTY);
		rowMap.put("CUSTOMERID", Constant.EMPTY);
		rowMap.put("REFERENCEKEY", Constant.EMPTY);
		rowMap.put("CELLID", row.getString("LOCATIONID"));
		
		IDataSet ds = new DataSet();
		IDataTable dt = ds.addTable("transaction");
		dt.addRow(rowMap);
		
		CtConsumabletransactionData data = ConsumableTransactionUtils.getInsertData(dt.getFirstRow(), null);
		return data;
	}
}
