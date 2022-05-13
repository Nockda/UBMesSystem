package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class WorkorderKey extends SQLKey {

	WorkorderKey() {
	}


	public String getWorkorderid() {
		return this.repository().getString(WorkorderData.Workorderid);
	}

	public WorkorderKey setWorkorderid(String Workorderid) {
		this.repository().set(WorkorderData.Workorderid, Workorderid);
		return this;
	}


}