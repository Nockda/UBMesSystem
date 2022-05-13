package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlEquipmentchecklistKey extends SQLKey {

	UlEquipmentchecklistKey() {
	}


	public String getEquipcheckid() {
		return this.repository().getString(UlEquipmentchecklistData.Equipcheckid);
	}

	public UlEquipmentchecklistKey setEquipcheckid(String Equipcheckid) {
		this.repository().set(UlEquipmentchecklistData.Equipcheckid, Equipcheckid);
		return this;
	}


}