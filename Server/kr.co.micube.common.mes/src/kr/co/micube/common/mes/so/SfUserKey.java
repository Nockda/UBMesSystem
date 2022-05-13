package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfUserKey extends SQLKey {

	SfUserKey() {
	}


	public String getUserid() {
		return this.repository().getString(SfUserData.Userid);
	}

	public SfUserKey setUserid(String Userid) {
		this.repository().set(SfUserData.Userid, Userid);
		return this;
	}


}