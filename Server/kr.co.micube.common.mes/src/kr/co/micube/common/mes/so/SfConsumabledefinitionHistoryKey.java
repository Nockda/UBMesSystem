package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfConsumabledefinitionHistoryKey extends SQLKey {

	SfConsumabledefinitionHistoryKey() {
	}


	public String getConsumabledefid() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Consumabledefid);
	}

	public SfConsumabledefinitionHistoryKey setConsumabledefid(String Consumabledefid) {
		this.repository().set(SfConsumabledefinitionHistoryData.Consumabledefid, Consumabledefid);
		return this;
	}

	public String getConsumabledefversion() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Consumabledefversion);
	}

	public SfConsumabledefinitionHistoryKey setConsumabledefversion(String Consumabledefversion) {
		this.repository().set(SfConsumabledefinitionHistoryData.Consumabledefversion, Consumabledefversion);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Txnhistkey);
	}

	public SfConsumabledefinitionHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfConsumabledefinitionHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}