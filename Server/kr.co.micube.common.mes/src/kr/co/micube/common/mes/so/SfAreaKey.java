package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfAreaKey extends SQLKey {

	SfAreaKey() {
	}


	public String getAreaid() {
		return this.repository().getString(SfAreaData.Areaid);
	}

	public SfAreaKey setAreaid(String Areaid) {
		this.repository().set(SfAreaData.Areaid, Areaid);
		return this;
	}


}