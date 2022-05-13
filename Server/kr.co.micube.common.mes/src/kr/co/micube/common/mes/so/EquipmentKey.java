package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class EquipmentKey extends SQLKey {

	EquipmentKey() {
	}


	public String getEquipmentid() {
		return this.repository().getString(EquipmentData.Equipmentid);
	}

	public EquipmentKey setEquipmentid(String Equipmentid) {
		this.repository().set(EquipmentData.Equipmentid, Equipmentid);
		return this;
	}


}