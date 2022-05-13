package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfEquipmentclassKey extends SQLKey {

	SfEquipmentclassKey() {
	}


	public String getEquipmentclassid() {
		return this.repository().getString(SfEquipmentclassData.Equipmentclassid);
	}

	public SfEquipmentclassKey setEquipmentclassid(String Equipmentclassid) {
		this.repository().set(SfEquipmentclassData.Equipmentclassid, Equipmentclassid);
		return this;
	}


}