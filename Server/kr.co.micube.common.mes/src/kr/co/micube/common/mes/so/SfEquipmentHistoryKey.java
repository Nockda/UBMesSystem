package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfEquipmentHistoryKey extends SQLKey {

	SfEquipmentHistoryKey() {
	}


	public String getEquipmentid() {
		return this.repository().getString(SfEquipmentHistoryData.Equipmentid);
	}

	public SfEquipmentHistoryKey setEquipmentid(String Equipmentid) {
		this.repository().set(SfEquipmentHistoryData.Equipmentid, Equipmentid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfEquipmentHistoryData.Txnhistkey);
	}

	public SfEquipmentHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfEquipmentHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}