package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtSpecdefinitionKey extends SQLKey {

	CtSpecdefinitionKey() {
	}


	public String getSpecdefid() {
		return this.repository().getString(CtSpecdefinitionData.Specdefid);
	}

	public CtSpecdefinitionKey setSpecdefid(String Specdefid) {
		this.repository().set(CtSpecdefinitionData.Specdefid, Specdefid);
		return this;
	}


}