package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlProcessworkresultKey extends SQLKey {

	UlProcessworkresultKey() {
	}


	public String getTxnhistkey() {
		return this.repository().getString(UlProcessworkresultData.Txnhistkey);
	}

	public UlProcessworkresultKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(UlProcessworkresultData.Txnhistkey, Txnhistkey);
		return this;
	}


}