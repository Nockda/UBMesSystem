package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlMaterialinitKey extends SQLKey {

	UlMaterialinitKey() {
	}


	public String getConsumablelotid() {
		return this.repository().getString(UlMaterialinitData.Consumablelotid);
	}

	public UlMaterialinitKey setConsumablelotid(String Consumablelotid) {
		this.repository().set(UlMaterialinitData.Consumablelotid, Consumablelotid);
		return this;
	}


}