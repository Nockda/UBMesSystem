package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfMaintitemKey extends SQLKey {

	SfMaintitemKey() {
	}


	public String getMaintitemid() {
		return this.repository().getString(SfMaintitemData.Maintitemid);
	}

	public SfMaintitemKey setMaintitemid(String Maintitemid) {
		this.repository().set(SfMaintitemData.Maintitemid, Maintitemid);
		return this;
	}


}