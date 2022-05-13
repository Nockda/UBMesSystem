package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlRoutingitemKey extends SQLKey {

	UlRoutingitemKey() {
	}


	public String getItemid() {
		return this.repository().getString(UlRoutingitemData.Itemid);
	}

	public UlRoutingitemKey setItemid(String Itemid) {
		this.repository().set(UlRoutingitemData.Itemid, Itemid);
		return this;
	}

	public String getRoutingid() {
		return this.repository().getString(UlRoutingitemData.Routingid);
	}

	public UlRoutingitemKey setRoutingid(String Routingid) {
		this.repository().set(UlRoutingitemData.Routingid, Routingid);
		return this;
	}


}