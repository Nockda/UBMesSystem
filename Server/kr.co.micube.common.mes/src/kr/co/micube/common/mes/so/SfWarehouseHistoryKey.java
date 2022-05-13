package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfWarehouseHistoryKey extends SQLKey {

	SfWarehouseHistoryKey() {
	}


	public String getWarehouseid() {
		return this.repository().getString(SfWarehouseHistoryData.Warehouseid);
	}

	public SfWarehouseHistoryKey setWarehouseid(String Warehouseid) {
		this.repository().set(SfWarehouseHistoryData.Warehouseid, Warehouseid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfWarehouseHistoryData.Txnhistkey);
	}

	public SfWarehouseHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfWarehouseHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}