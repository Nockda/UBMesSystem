package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfLotKey extends SQLKey {

	SfLotKey() {
	}


	public String getLotid() {
		return this.repository().getString(SfLotData.Lotid);
	}

	public SfLotKey setLotid(String Lotid) {
		this.repository().set(SfLotData.Lotid, Lotid);
		return this;
	}


}