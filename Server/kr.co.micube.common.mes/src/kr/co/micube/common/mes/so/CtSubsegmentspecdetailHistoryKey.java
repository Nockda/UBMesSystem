package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtSubsegmentspecdetailHistoryKey extends SQLKey {

	CtSubsegmentspecdetailHistoryKey() {
	}


	public Double getSpecsequence() {
		return this.repository().getDouble(CtSubsegmentspecdetailHistoryData.Specsequence);
	}

	public CtSubsegmentspecdetailHistoryKey setSpecsequence(Double Specsequence) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Specsequence, Specsequence);
		return this;
	}

	public String getParameterid() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Parameterid);
	}

	public CtSubsegmentspecdetailHistoryKey setParameterid(String Parameterid) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Parameterid, Parameterid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Txnhistkey);
	}

	public CtSubsegmentspecdetailHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}

	public String getSpecdefid() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Specdefid);
	}

	public CtSubsegmentspecdetailHistoryKey setSpecdefid(String Specdefid) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Specdefid, Specdefid);
		return this;
	}


}