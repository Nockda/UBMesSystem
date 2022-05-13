package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlEquipmentcheckdataHistoryKey extends SQLKey {

	UlEquipmentcheckdataHistoryKey() {
	}


	public String getCheckdate() {
		return this.repository().getString(UlEquipmentcheckdataHistoryData.Checkdate);
	}

	public UlEquipmentcheckdataHistoryKey setCheckdate(String Checkdate) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Checkdate, Checkdate);
		return this;
	}

	public String getEquipcheckid() {
		return this.repository().getString(UlEquipmentcheckdataHistoryData.Equipcheckid);
	}

	public UlEquipmentcheckdataHistoryKey setEquipcheckid(String Equipcheckid) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Equipcheckid, Equipcheckid);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(UlEquipmentcheckdataHistoryData.Equipmentid);
	}

	public UlEquipmentcheckdataHistoryKey setEquipmentid(String Equipmentid) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Equipmentid, Equipmentid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(UlEquipmentcheckdataHistoryData.Txnhistkey);
	}

	public UlEquipmentcheckdataHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}