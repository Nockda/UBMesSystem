package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlEquipmentcheckdataKey extends SQLKey {

	UlEquipmentcheckdataKey() {
	}


	public String getCheckdate() {
		return this.repository().getString(UlEquipmentcheckdataData.Checkdate);
	}

	public UlEquipmentcheckdataKey setCheckdate(String Checkdate) {
		this.repository().set(UlEquipmentcheckdataData.Checkdate, Checkdate);
		return this;
	}

	public String getEquipcheckid() {
		return this.repository().getString(UlEquipmentcheckdataData.Equipcheckid);
	}

	public UlEquipmentcheckdataKey setEquipcheckid(String Equipcheckid) {
		this.repository().set(UlEquipmentcheckdataData.Equipcheckid, Equipcheckid);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(UlEquipmentcheckdataData.Equipmentid);
	}

	public UlEquipmentcheckdataKey setEquipmentid(String Equipmentid) {
		this.repository().set(UlEquipmentcheckdataData.Equipmentid, Equipmentid);
		return this;
	}


}