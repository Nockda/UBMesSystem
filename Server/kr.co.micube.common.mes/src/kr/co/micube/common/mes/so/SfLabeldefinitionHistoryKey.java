package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfLabeldefinitionHistoryKey extends SQLKey {

	SfLabeldefinitionHistoryKey() {
	}


	public String getLabelid() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Labelid);
	}

	public SfLabeldefinitionHistoryKey setLabelid(String Labelid) {
		this.repository().set(SfLabeldefinitionHistoryData.Labelid, Labelid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Txnhistkey);
	}

	public SfLabeldefinitionHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfLabeldefinitionHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}