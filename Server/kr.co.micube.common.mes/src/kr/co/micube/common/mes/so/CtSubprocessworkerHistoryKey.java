package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtSubprocessworkerHistoryKey extends SQLKey {

	CtSubprocessworkerHistoryKey() {
	}


	public String getTxnhistkey() {
		return this.repository().getString(CtSubprocessworkerHistoryData.Txnhistkey);
	}

	public CtSubprocessworkerHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtSubprocessworkerHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(CtSubprocessworkerHistoryData.Processsegmentid);
	}

	public CtSubprocessworkerHistoryKey setProcesssegmentid(String Processsegmentid) {
		this.repository().set(CtSubprocessworkerHistoryData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getSubprocesssegmentid() {
		return this.repository().getString(CtSubprocessworkerHistoryData.Subprocesssegmentid);
	}

	public CtSubprocessworkerHistoryKey setSubprocesssegmentid(String Subprocesssegmentid) {
		this.repository().set(CtSubprocessworkerHistoryData.Subprocesssegmentid, Subprocesssegmentid);
		return this;
	}

	public String getUserid() {
		return this.repository().getString(CtSubprocessworkerHistoryData.Userid);
	}

	public CtSubprocessworkerHistoryKey setUserid(String Userid) {
		this.repository().set(CtSubprocessworkerHistoryData.Userid, Userid);
		return this;
	}


}