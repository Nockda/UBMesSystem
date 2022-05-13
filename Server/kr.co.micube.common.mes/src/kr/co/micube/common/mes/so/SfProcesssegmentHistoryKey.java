package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfProcesssegmentHistoryKey extends SQLKey {

	SfProcesssegmentHistoryKey() {
	}


	public String getProcesssegmentid() {
		return this.repository().getString(SfProcesssegmentHistoryData.Processsegmentid);
	}

	public SfProcesssegmentHistoryKey setProcesssegmentid(String Processsegmentid) {
		this.repository().set(SfProcesssegmentHistoryData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getProcesssegmentversion() {
		return this.repository().getString(SfProcesssegmentHistoryData.Processsegmentversion);
	}

	public SfProcesssegmentHistoryKey setProcesssegmentversion(String Processsegmentversion) {
		this.repository().set(SfProcesssegmentHistoryData.Processsegmentversion, Processsegmentversion);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfProcesssegmentHistoryData.Txnhistkey);
	}

	public SfProcesssegmentHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfProcesssegmentHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}