package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlEquipmentcheckmapHistoryKey extends SQLKey {

	UlEquipmentcheckmapHistoryKey() {
	}


	public String getEquipmentclassid() {
		return this.repository().getString(UlEquipmentcheckmapHistoryData.Equipmentclassid);
	}

	public UlEquipmentcheckmapHistoryKey setEquipmentclassid(String Equipmentclassid) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Equipmentclassid, Equipmentclassid);
		return this;
	}

	public String getEquipcheckid() {
		return this.repository().getString(UlEquipmentcheckmapHistoryData.Equipcheckid);
	}

	public UlEquipmentcheckmapHistoryKey setEquipcheckid(String Equipcheckid) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Equipcheckid, Equipcheckid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(UlEquipmentcheckmapHistoryData.Txnhistkey);
	}

	public UlEquipmentcheckmapHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}