package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtUnitdefinitionKey extends SQLKey {

	CtUnitdefinitionKey() {
	}


	public String getUnitid() {
		return this.repository().getString(CtUnitdefinitionData.Unitid);
	}

	public CtUnitdefinitionKey setUnitid(String Unitid) {
		this.repository().set(CtUnitdefinitionData.Unitid, Unitid);
		return this;
	}


}