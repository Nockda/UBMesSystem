package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfWorkorderKey extends SQLKey {

	SfWorkorderKey() {
	}


	public String getWorkorderid() {
		return this.repository().getString(SfWorkorderData.Workorderid);
	}

	public SfWorkorderKey setWorkorderid(String Workorderid) {
		this.repository().set(SfWorkorderData.Workorderid, Workorderid);
		return this;
	}


}