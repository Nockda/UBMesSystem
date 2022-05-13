package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfEquipmentmaintitemKey extends SQLKey {

	SfEquipmentmaintitemKey() {
	}


	public String getEquipmentclassid() {
		return this.repository().getString(SfEquipmentmaintitemData.Equipmentclassid);
	}

	public SfEquipmentmaintitemKey setEquipmentclassid(String Equipmentclassid) {
		this.repository().set(SfEquipmentmaintitemData.Equipmentclassid, Equipmentclassid);
		return this;
	}

	public String getMaintitemid() {
		return this.repository().getString(SfEquipmentmaintitemData.Maintitemid);
	}

	public SfEquipmentmaintitemKey setMaintitemid(String Maintitemid) {
		this.repository().set(SfEquipmentmaintitemData.Maintitemid, Maintitemid);
		return this;
	}

	public String getMainttype() {
		return this.repository().getString(SfEquipmentmaintitemData.Mainttype);
	}

	public SfEquipmentmaintitemKey setMainttype(String Mainttype) {
		this.repository().set(SfEquipmentmaintitemData.Mainttype, Mainttype);
		return this;
	}


}