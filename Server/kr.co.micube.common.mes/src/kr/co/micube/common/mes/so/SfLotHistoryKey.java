package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfLotHistoryKey extends SQLKey {

	SfLotHistoryKey() {
	}


	public String getLotid() {
		return this.repository().getString(SfLotHistoryData.Lotid);
	}

	public SfLotHistoryKey setLotid(String Lotid) {
		this.repository().set(SfLotHistoryData.Lotid, Lotid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfLotHistoryData.Txnhistkey);
	}

	public SfLotHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfLotHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}