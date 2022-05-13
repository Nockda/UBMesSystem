package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfProductdefinitionHistoryKey extends SQLKey {

	SfProductdefinitionHistoryKey() {
	}


	public String getProductdefid() {
		return this.repository().getString(SfProductdefinitionHistoryData.Productdefid);
	}

	public SfProductdefinitionHistoryKey setProductdefid(String Productdefid) {
		this.repository().set(SfProductdefinitionHistoryData.Productdefid, Productdefid);
		return this;
	}

	public String getProductdefversion() {
		return this.repository().getString(SfProductdefinitionHistoryData.Productdefversion);
	}

	public SfProductdefinitionHistoryKey setProductdefversion(String Productdefversion) {
		this.repository().set(SfProductdefinitionHistoryData.Productdefversion, Productdefversion);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfProductdefinitionHistoryData.Txnhistkey);
	}

	public SfProductdefinitionHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfProductdefinitionHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}