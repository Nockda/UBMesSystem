package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlCapaHistoryKey extends SQLKey {

	UlCapaHistoryKey() {
	}


	public String getDocid() {
		return this.repository().getString(UlCapaHistoryData.Docid);
	}

	public UlCapaHistoryKey setDocid(String Docid) {
		this.repository().set(UlCapaHistoryData.Docid, Docid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(UlCapaHistoryData.Txnhistkey);
	}

	public UlCapaHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(UlCapaHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}