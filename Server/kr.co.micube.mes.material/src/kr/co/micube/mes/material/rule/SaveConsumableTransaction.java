package kr.co.micube.mes.material.rule;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.service.SfConsumableDefinitionService;
import kr.co.micube.common.mes.service.SfProductDefinitionService;
import kr.co.micube.common.mes.so.CtConsumabletransactionData;
import kr.co.micube.common.mes.so.CtConsumabletransactionKey;
import kr.co.micube.common.mes.so.SfConsumabledefinitionData;
import kr.co.micube.common.mes.so.SfProductdefinitionData;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: ConsumableLot 트랜잭션 저장
 * 설               명	: SF_CONSUMABLELOT테이블에 사용되는 모든 트랜잭션 행위를 저장한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-06-12
 * 수   정   이   력	: 
 */
public class SaveConsumableTransaction extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		//String state = null;
		
		row = dt.getRow(0);
		//state = row.getString("_STATE_");
		
		for (int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);

			batch.add(getInsertData(row, batch), SQLUpsertType.INSERT);
		}

		batch.execute();
	}
	
	public static CtConsumabletransactionData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		CtConsumabletransactionData code = new CtConsumabletransactionData();
		CtConsumabletransactionKey codeKey = code.key();
			
		codeKey.setTxnhistkey(row.getString("TXNHISTKEY"));

		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("TXNHISTKEY")));
		}
		
		CtConsumabletransactionData newCode = new CtConsumabletransactionData();
		CtConsumabletransactionKey newCodeKey = newCode.key();

		newCodeKey.setTxnhistkey(row.getString("TXNHISTKEY"));
		
		newCode.setConsumabledefid(row.getString("CONSUMABLEDEFID"));
		
		String sConsumabledefid = row.getString("CONSUMABLEDEFID");
		SfConsumabledefinitionData conData = SfConsumableDefinitionService.getConsumabledefinition(sConsumabledefid, Constant.ASTERISK);
		if(conData.getConsumabletype().equals("Material"))
		{
			newCode.setEnterpriseid(conData.getEnterpriseid());
			newCode.setPlantid(conData.getPlantid());
			newCode.setAreaid(null);
		}
		else
		{
			SfProductdefinitionData prodData = SfProductDefinitionService.getProductdefinition(sConsumabledefid, Constant.ASTERISK);
			newCode.setEnterpriseid(prodData.getEnterpriseid());
			newCode.setPlantid(prodData.getPlantid());
			newCode.setAreaid(prodData.getAreaid());
		}
		newCode.setEquipmentid(row.getString("EQUIPMENTID"));
		newCode.setWarehouseid(row.getString("WAREHOUSEID"));
		newCode.setLocationid(row.getString("LOCATIONID"));
		newCode.setConsumabledefversion(Constant.ASTERISK);
		newCode.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		newCode.setTransactiontype(row.getString("TRANSACTIONTYPE"));
		newCode.setTransactioncode(row.getString("TRANSACTIONCODE"));
		newCode.setQty(row.getDouble("QTY"));
		newCode.setTowarehouseid(row.getString("TOWAREHOUSEID"));
		newCode.setDescription(row.getString("DESCRIPTION"));

		return newCode;
	}
}
