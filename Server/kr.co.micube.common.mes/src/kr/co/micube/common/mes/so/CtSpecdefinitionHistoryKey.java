package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtSpecdefinitionHistoryKey extends SQLKey {

	CtSpecdefinitionHistoryKey() {
	}


	public String getTxnhistkey() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Txnhistkey);
	}

	public CtSpecdefinitionHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtSpecdefinitionHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}

	public String getSpecdefid() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Specdefid);
	}

	public CtSpecdefinitionHistoryKey setSpecdefid(String Specdefid) {
		this.repository().set(CtSpecdefinitionHistoryData.Specdefid, Specdefid);
		return this;
	}


}