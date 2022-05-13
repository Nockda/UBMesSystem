package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfProductdefinitionKey extends SQLKey {

	SfProductdefinitionKey() {
	}


	public String getProductdefid() {
		return this.repository().getString(SfProductdefinitionData.Productdefid);
	}

	public SfProductdefinitionKey setProductdefid(String Productdefid) {
		this.repository().set(SfProductdefinitionData.Productdefid, Productdefid);
		return this;
	}

	public String getProductdefversion() {
		return this.repository().getString(SfProductdefinitionData.Productdefversion);
	}

	public SfProductdefinitionKey setProductdefversion(String Productdefversion) {
		this.repository().set(SfProductdefinitionData.Productdefversion, Productdefversion);
		return this;
	}


}