package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlSpecidHistoryKey extends SQLKey {

	UlSpecidHistoryKey() {
	}


	public String getSpecdefid() {
		return this.repository().getString(UlSpecidHistoryData.Specdefid);
	}

	public UlSpecidHistoryKey setSpecdefid(String Specdefid) {
		this.repository().set(UlSpecidHistoryData.Specdefid, Specdefid);
		return this;
	}

	public Integer getSeq() {
		return this.repository().getInteger(UlSpecidHistoryData.Seq);
	}

	public UlSpecidHistoryKey setSeq(Integer Seq) {
		this.repository().set(UlSpecidHistoryData.Seq, Seq);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(UlSpecidHistoryData.Txnhistkey);
	}

	public UlSpecidHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(UlSpecidHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}