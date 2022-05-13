package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtSpecdefinitionversionKey extends SQLKey {

	CtSpecdefinitionversionKey() {
	}


	public String getSpecdefid() {
		return this.repository().getString(CtSpecdefinitionversionData.Specdefid);
	}

	public CtSpecdefinitionversionKey setSpecdefid(String Specdefid) {
		this.repository().set(CtSpecdefinitionversionData.Specdefid, Specdefid);
		return this;
	}

	public String getSpecdefidversion() {
		return this.repository().getString(CtSpecdefinitionversionData.Specdefidversion);
	}

	public CtSpecdefinitionversionKey setSpecdefidversion(String Specdefidversion) {
		this.repository().set(CtSpecdefinitionversionData.Specdefidversion, Specdefidversion);
		return this;
	}


}