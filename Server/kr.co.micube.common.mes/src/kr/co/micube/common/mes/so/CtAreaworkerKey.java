package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtAreaworkerKey extends SQLKey {

	CtAreaworkerKey() {
	}


	public String getAreaid() {
		return this.repository().getString(CtAreaworkerData.Areaid);
	}

	public CtAreaworkerKey setAreaid(String Areaid) {
		this.repository().set(CtAreaworkerData.Areaid, Areaid);
		return this;
	}

	public String getUserid() {
		return this.repository().getString(CtAreaworkerData.Userid);
	}

	public CtAreaworkerKey setUserid(String Userid) {
		this.repository().set(CtAreaworkerData.Userid, Userid);
		return this;
	}


}