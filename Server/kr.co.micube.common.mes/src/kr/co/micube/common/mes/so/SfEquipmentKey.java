package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfEquipmentKey extends SQLKey {

	SfEquipmentKey() {
	}


	public String getEquipmentid() {
		return this.repository().getString(SfEquipmentData.Equipmentid);
	}

	public SfEquipmentKey setEquipmentid(String Equipmentid) {
		this.repository().set(SfEquipmentData.Equipmentid, Equipmentid);
		return this;
	}


}