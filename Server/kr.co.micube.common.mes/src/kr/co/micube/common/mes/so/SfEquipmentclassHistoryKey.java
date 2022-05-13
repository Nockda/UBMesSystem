package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfEquipmentclassHistoryKey extends SQLKey {

	SfEquipmentclassHistoryKey() {
	}


	public String getEquipmentclassid() {
		return this.repository().getString(SfEquipmentclassHistoryData.Equipmentclassid);
	}

	public SfEquipmentclassHistoryKey setEquipmentclassid(String Equipmentclassid) {
		this.repository().set(SfEquipmentclassHistoryData.Equipmentclassid, Equipmentclassid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfEquipmentclassHistoryData.Txnhistkey);
	}

	public SfEquipmentclassHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfEquipmentclassHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}