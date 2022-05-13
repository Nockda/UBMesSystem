package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlIqcinsplistKey extends SQLKey {

	UlIqcinsplistKey() {
	}


	public String getItemid() {
		return this.repository().getString(UlIqcinsplistData.Itemid);
	}

	public UlIqcinsplistKey setItemid(String Itemid) {
		this.repository().set(UlIqcinsplistData.Itemid, Itemid);
		return this;
	}


}