package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlEquipmentcheckmapKey extends SQLKey {

	UlEquipmentcheckmapKey() {
	}


	public String getEquipmentclassid() {
		return this.repository().getString(UlEquipmentcheckmapData.Equipmentclassid);
	}

	public UlEquipmentcheckmapKey setEquipmentclassid(String Equipmentclassid) {
		this.repository().set(UlEquipmentcheckmapData.Equipmentclassid, Equipmentclassid);
		return this;
	}

	public String getEquipcheckid() {
		return this.repository().getString(UlEquipmentcheckmapData.Equipcheckid);
	}

	public UlEquipmentcheckmapKey setEquipcheckid(String Equipcheckid) {
		this.repository().set(UlEquipmentcheckmapData.Equipcheckid, Equipcheckid);
		return this;
	}


}