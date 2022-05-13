package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlRoutingmasterKey extends SQLKey {

	UlRoutingmasterKey() {
	}


	public String getRoutingid() {
		return this.repository().getString(UlRoutingmasterData.Routingid);
	}

	public UlRoutingmasterKey setRoutingid(String Routingid) {
		this.repository().set(UlRoutingmasterData.Routingid, Routingid);
		return this;
	}


}