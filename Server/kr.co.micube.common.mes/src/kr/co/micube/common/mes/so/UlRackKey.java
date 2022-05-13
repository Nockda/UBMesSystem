package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlRackKey extends SQLKey {

	UlRackKey() {
	}


	public String getRackid() {
		return this.repository().getString(UlRackData.Rackid);
	}

	public UlRackKey setRackid(String Rackid) {
		this.repository().set(UlRackData.Rackid, Rackid);
		return this;
	}


}