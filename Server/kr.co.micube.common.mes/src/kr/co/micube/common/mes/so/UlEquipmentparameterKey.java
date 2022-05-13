package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlEquipmentparameterKey extends SQLKey {

	UlEquipmentparameterKey() {
	}


	public String getParameterid() {
		return this.repository().getString(UlEquipmentparameterData.Parameterid);
	}

	public UlEquipmentparameterKey setParameterid(String Parameterid) {
		this.repository().set(UlEquipmentparameterData.Parameterid, Parameterid);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(UlEquipmentparameterData.Equipmentid);
	}

	public UlEquipmentparameterKey setEquipmentid(String Equipmentid) {
		this.repository().set(UlEquipmentparameterData.Equipmentid, Equipmentid);
		return this;
	}


}