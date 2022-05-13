package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfLabelmapHistoryKey extends SQLKey {

	SfLabelmapHistoryKey() {
	}


	public String getLabelid() {
		return this.repository().getString(SfLabelmapHistoryData.Labelid);
	}

	public SfLabelmapHistoryKey setLabelid(String Labelid) {
		this.repository().set(SfLabelmapHistoryData.Labelid, Labelid);
		return this;
	}

	public String getProductdefid() {
		return this.repository().getString(SfLabelmapHistoryData.Productdefid);
	}

	public SfLabelmapHistoryKey setProductdefid(String Productdefid) {
		this.repository().set(SfLabelmapHistoryData.Productdefid, Productdefid);
		return this;
	}

	public String getProductdefversion() {
		return this.repository().getString(SfLabelmapHistoryData.Productdefversion);
	}

	public SfLabelmapHistoryKey setProductdefversion(String Productdefversion) {
		this.repository().set(SfLabelmapHistoryData.Productdefversion, Productdefversion);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfLabelmapHistoryData.Txnhistkey);
	}

	public SfLabelmapHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfLabelmapHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}