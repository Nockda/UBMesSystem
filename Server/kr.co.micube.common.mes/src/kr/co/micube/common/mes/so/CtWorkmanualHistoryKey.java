package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtWorkmanualHistoryKey extends SQLKey {

	CtWorkmanualHistoryKey() {
	}


	public String getManualno() {
		return this.repository().getString(CtWorkmanualHistoryData.Manualno);
	}

	public CtWorkmanualHistoryKey setManualno(String Manualno) {
		this.repository().set(CtWorkmanualHistoryData.Manualno, Manualno);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(CtWorkmanualHistoryData.Txnhistkey);
	}

	public CtWorkmanualHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtWorkmanualHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}