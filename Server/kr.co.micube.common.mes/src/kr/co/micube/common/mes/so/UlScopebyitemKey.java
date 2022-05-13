package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlScopebyitemKey extends SQLKey {

	UlScopebyitemKey() {
	}


	public String getItemid() {
		return this.repository().getString(UlScopebyitemData.Itemid);
	}

	public UlScopebyitemKey setItemid(String Itemid) {
		this.repository().set(UlScopebyitemData.Itemid, Itemid);
		return this;
	}


}