package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlXmanageKey extends SQLKey {

	UlXmanageKey() {
	}


	public String getXnumber() {
		return this.repository().getString(UlXmanageData.Xnumber);
	}

	public UlXmanageKey setXnumber(String Xnumber) {
		this.repository().set(UlXmanageData.Xnumber, Xnumber);
		return this;
	}


}