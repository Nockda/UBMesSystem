package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlXmanageHistoryKey extends SQLKey {

	UlXmanageHistoryKey() {
	}


	public String getXnumber() {
		return this.repository().getString(UlXmanageHistoryData.Xnumber);
	}

	public UlXmanageHistoryKey setXnumber(String Xnumber) {
		this.repository().set(UlXmanageHistoryData.Xnumber, Xnumber);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(UlXmanageHistoryData.Txnhistkey);
	}

	public UlXmanageHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(UlXmanageHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}