package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlEquipmentchecklistHistoryKey extends SQLKey {

	UlEquipmentchecklistHistoryKey() {
	}


	public String getEquipcheckid() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Equipcheckid);
	}

	public UlEquipmentchecklistHistoryKey setEquipcheckid(String Equipcheckid) {
		this.repository().set(UlEquipmentchecklistHistoryData.Equipcheckid, Equipcheckid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Txnhistkey);
	}

	public UlEquipmentchecklistHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(UlEquipmentchecklistHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}