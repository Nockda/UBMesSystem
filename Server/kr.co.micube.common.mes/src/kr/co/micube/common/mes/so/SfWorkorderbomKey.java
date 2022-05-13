package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfWorkorderbomKey extends SQLKey {

	SfWorkorderbomKey() {
	}


	public String getWorkorderid() {
		return this.repository().getString(SfWorkorderbomData.Workorderid);
	}

	public SfWorkorderbomKey setWorkorderid(String Workorderid) {
		this.repository().set(SfWorkorderbomData.Workorderid, Workorderid);
		return this;
	}

	public String getConsumabledefid() {
		return this.repository().getString(SfWorkorderbomData.Consumabledefid);
	}

	public SfWorkorderbomKey setConsumabledefid(String Consumabledefid) {
		this.repository().set(SfWorkorderbomData.Consumabledefid, Consumabledefid);
		return this;
	}

	public String getConsumabledefversion() {
		return this.repository().getString(SfWorkorderbomData.Consumabledefversion);
	}

	public SfWorkorderbomKey setConsumabledefversion(String Consumabledefversion) {
		this.repository().set(SfWorkorderbomData.Consumabledefversion, Consumabledefversion);
		return this;
	}


}