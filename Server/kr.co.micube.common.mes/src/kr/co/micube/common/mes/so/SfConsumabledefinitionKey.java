package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfConsumabledefinitionKey extends SQLKey {

	SfConsumabledefinitionKey() {
	}


	public String getConsumabledefid() {
		return this.repository().getString(SfConsumabledefinitionData.Consumabledefid);
	}

	public SfConsumabledefinitionKey setConsumabledefid(String Consumabledefid) {
		this.repository().set(SfConsumabledefinitionData.Consumabledefid, Consumabledefid);
		return this;
	}

	public String getConsumabledefversion() {
		return this.repository().getString(SfConsumabledefinitionData.Consumabledefversion);
	}

	public SfConsumabledefinitionKey setConsumabledefversion(String Consumabledefversion) {
		this.repository().set(SfConsumabledefinitionData.Consumabledefversion, Consumabledefversion);
		return this;
	}


}