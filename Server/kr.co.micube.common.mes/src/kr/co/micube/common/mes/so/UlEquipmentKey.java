package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlEquipmentKey extends SQLKey {

	UlEquipmentKey() {
	}


	public String getEquipcode() {
		return this.repository().getString(UlEquipmentData.Equipcode);
	}

	public UlEquipmentKey setEquipcode(String Equipcode) {
		this.repository().set(UlEquipmentData.Equipcode, Equipcode);
		return this;
	}


}