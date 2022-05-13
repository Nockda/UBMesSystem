package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfWorkorderHistoryKey extends SQLKey {

	SfWorkorderHistoryKey() {
	}


	public String getWorkorderid() {
		return this.repository().getString(SfWorkorderHistoryData.Workorderid);
	}

	public SfWorkorderHistoryKey setWorkorderid(String Workorderid) {
		this.repository().set(SfWorkorderHistoryData.Workorderid, Workorderid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfWorkorderHistoryData.Txnhistkey);
	}

	public SfWorkorderHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfWorkorderHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}