package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class WorkorderHistotryKey extends SQLKey {

	WorkorderHistotryKey() {
	}


	public String getWorkorderid() {
		return this.repository().getString(WorkorderHistotryData.Workorderid);
	}

	public WorkorderHistotryKey setWorkorderid(String Workorderid) {
		this.repository().set(WorkorderHistotryData.Workorderid, Workorderid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(WorkorderHistotryData.Txnhistkey);
	}

	public WorkorderHistotryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(WorkorderHistotryData.Txnhistkey, Txnhistkey);
		return this;
	}


}