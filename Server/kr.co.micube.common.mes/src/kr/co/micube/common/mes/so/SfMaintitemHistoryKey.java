package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfMaintitemHistoryKey extends SQLKey {

	SfMaintitemHistoryKey() {
	}


	public String getMaintitemid() {
		return this.repository().getString(SfMaintitemHistoryData.Maintitemid);
	}

	public SfMaintitemHistoryKey setMaintitemid(String Maintitemid) {
		this.repository().set(SfMaintitemHistoryData.Maintitemid, Maintitemid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfMaintitemHistoryData.Txnhistkey);
	}

	public SfMaintitemHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfMaintitemHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}