package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtSubsegmentspecHistoryKey extends SQLKey {

	CtSubsegmentspecHistoryKey() {
	}


	public String getSpecdefid() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Specdefid);
	}

	public CtSubsegmentspecHistoryKey setSpecdefid(String Specdefid) {
		this.repository().set(CtSubsegmentspecHistoryData.Specdefid, Specdefid);
		return this;
	}

	public String getSubprocesssegmentid() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Subprocesssegmentid);
	}

	public CtSubsegmentspecHistoryKey setSubprocesssegmentid(String Subprocesssegmentid) {
		this.repository().set(CtSubsegmentspecHistoryData.Subprocesssegmentid, Subprocesssegmentid);
		return this;
	}

	public Double getSpecsequence() {
		return this.repository().getDouble(CtSubsegmentspecHistoryData.Specsequence);
	}

	public CtSubsegmentspecHistoryKey setSpecsequence(Double Specsequence) {
		this.repository().set(CtSubsegmentspecHistoryData.Specsequence, Specsequence);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Txnhistkey);
	}

	public CtSubsegmentspecHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtSubsegmentspecHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}