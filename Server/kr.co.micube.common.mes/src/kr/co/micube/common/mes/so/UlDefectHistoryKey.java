package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlDefectHistoryKey extends SQLKey {

	UlDefectHistoryKey() {
	}


	public String getDocid() {
		return this.repository().getString(UlDefectHistoryData.Docid);
	}

	public UlDefectHistoryKey setDocid(String Docid) {
		this.repository().set(UlDefectHistoryData.Docid, Docid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(UlDefectHistoryData.Txnhistkey);
	}

	public UlDefectHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(UlDefectHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}