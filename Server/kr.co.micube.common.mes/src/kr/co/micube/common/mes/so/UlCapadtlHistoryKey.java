package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlCapadtlHistoryKey extends SQLKey {

	UlCapadtlHistoryKey() {
	}


	public String getDocid() {
		return this.repository().getString(UlCapadtlHistoryData.Docid);
	}

	public UlCapadtlHistoryKey setDocid(String Docid) {
		this.repository().set(UlCapadtlHistoryData.Docid, Docid);
		return this;
	}

	public Integer getDocsequence() {
		return this.repository().getInteger(UlCapadtlHistoryData.Docsequence);
	}

	public UlCapadtlHistoryKey setDocsequence(Integer Docsequence) {
		this.repository().set(UlCapadtlHistoryData.Docsequence, Docsequence);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(UlCapadtlHistoryData.Txnhistkey);
	}

	public UlCapadtlHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(UlCapadtlHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}