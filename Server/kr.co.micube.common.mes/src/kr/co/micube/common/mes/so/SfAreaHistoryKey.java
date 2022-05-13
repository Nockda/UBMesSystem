package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfAreaHistoryKey extends SQLKey {

	SfAreaHistoryKey() {
	}


	public String getAreaid() {
		return this.repository().getString(SfAreaHistoryData.Areaid);
	}

	public SfAreaHistoryKey setAreaid(String Areaid) {
		this.repository().set(SfAreaHistoryData.Areaid, Areaid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfAreaHistoryData.Txnhistkey);
	}

	public SfAreaHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfAreaHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}