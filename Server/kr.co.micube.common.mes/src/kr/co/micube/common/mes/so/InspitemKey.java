package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class InspitemKey extends SQLKey {

	InspitemKey() {
	}


	public String getItemid() {
		return this.repository().getString(InspitemData.Itemid);
	}

	public InspitemKey setItemid(String Itemid) {
		this.repository().set(InspitemData.Itemid, Itemid);
		return this;
	}


}