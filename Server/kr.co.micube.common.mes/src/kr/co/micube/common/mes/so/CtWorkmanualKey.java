package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtWorkmanualKey extends SQLKey {

	CtWorkmanualKey() {
	}


	public String getManualno() {
		return this.repository().getString(CtWorkmanualData.Manualno);
	}

	public CtWorkmanualKey setManualno(String Manualno) {
		this.repository().set(CtWorkmanualData.Manualno, Manualno);
		return this;
	}


}