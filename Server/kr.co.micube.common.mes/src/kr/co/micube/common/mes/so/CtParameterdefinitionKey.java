package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtParameterdefinitionKey extends SQLKey {

	CtParameterdefinitionKey() {
	}


	public String getParameterid() {
		return this.repository().getString(CtParameterdefinitionData.Parameterid);
	}

	public CtParameterdefinitionKey setParameterid(String Parameterid) {
		this.repository().set(CtParameterdefinitionData.Parameterid, Parameterid);
		return this;
	}


}