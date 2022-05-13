package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfConsumablelotKey extends SQLKey {

	SfConsumablelotKey() {
	}


	public String getConsumablelotid() {
		return this.repository().getString(SfConsumablelotData.Consumablelotid);
	}

	public SfConsumablelotKey setConsumablelotid(String Consumablelotid) {
		this.repository().set(SfConsumablelotData.Consumablelotid, Consumablelotid);
		return this;
	}


}