package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfLabelmapKey extends SQLKey {

	SfLabelmapKey() {
	}


	public String getLabelid() {
		return this.repository().getString(SfLabelmapData.Labelid);
	}

	public SfLabelmapKey setLabelid(String Labelid) {
		this.repository().set(SfLabelmapData.Labelid, Labelid);
		return this;
	}

	public String getProductdefid() {
		return this.repository().getString(SfLabelmapData.Productdefid);
	}

	public SfLabelmapKey setProductdefid(String Productdefid) {
		this.repository().set(SfLabelmapData.Productdefid, Productdefid);
		return this;
	}

	public String getProductdefversion() {
		return this.repository().getString(SfLabelmapData.Productdefversion);
	}

	public SfLabelmapKey setProductdefversion(String Productdefversion) {
		this.repository().set(SfLabelmapData.Productdefversion, Productdefversion);
		return this;
	}


}