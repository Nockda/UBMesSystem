package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfLabeldefinitionKey extends SQLKey {

	SfLabeldefinitionKey() {
	}


	public String getLabelid() {
		return this.repository().getString(SfLabeldefinitionData.Labelid);
	}

	public SfLabeldefinitionKey setLabelid(String Labelid) {
		this.repository().set(SfLabeldefinitionData.Labelid, Labelid);
		return this;
	}


}