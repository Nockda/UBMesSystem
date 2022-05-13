package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtModelstandardinfoHistoryKey extends SQLKey {

	CtModelstandardinfoHistoryKey() {
	}


	public String getProcesssegmentid() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Processsegmentid);
	}

	public CtModelstandardinfoHistoryKey setProcesssegmentid(String Processsegmentid) {
		this.repository().set(CtModelstandardinfoHistoryData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getModelid() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Modelid);
	}

	public CtModelstandardinfoHistoryKey setModelid(String Modelid) {
		this.repository().set(CtModelstandardinfoHistoryData.Modelid, Modelid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Txnhistkey);
	}

	public CtModelstandardinfoHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtModelstandardinfoHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}