package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfConnectionHistoryKey extends SQLKey {

	SfConnectionHistoryKey() {
	}


	public String getTxnhistkey() {
		return this.repository().getString(SfConnectionHistoryData.Txnhistkey);
	}

	public SfConnectionHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfConnectionHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}