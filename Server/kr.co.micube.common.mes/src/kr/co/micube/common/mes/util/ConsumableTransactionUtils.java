package kr.co.micube.common.mes.util;

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
import kr.co.micube.tool.so.support.ISQLUpsertBatch;

public class ConsumableTransactionUtils {
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
		newCode.setTransactiondetailcode(row.getString("TRANSACTIONDETAILCODE"));
		newCode.setQty(row.getDouble("QTY"));
		newCode.setTowarehouseid(row.getString("TOWAREHOUSEID"));
		newCode.setDescription(row.getString("DESCRIPTION"));
		newCode.setReferencekey(row.getString("REFERENCEKEY"));
		newCode.setCustomerid(row.getString("CUSTOMERID"));
		newCode.setTeamid(row.getString("TEAMID"));
		newCode.setCellid(row.getString("CELLID"));

		return newCode;
	}
	
}
