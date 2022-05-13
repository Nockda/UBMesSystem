package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtConsumablelotgenealKey extends SQLKey {

	CtConsumablelotgenealKey() {
	}


	public String getTxnhistkey() {
		return this.repository().getString(CtConsumablelotgenealData.Txnhistkey);
	}

	public CtConsumablelotgenealKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtConsumablelotgenealData.Txnhistkey, Txnhistkey);
		return this;
	}

	public String getConsumablelotid() {
		return this.repository().getString(CtConsumablelotgenealData.Consumablelotid);
	}

	public CtConsumablelotgenealKey setConsumablelotid(String Consumablelotid) {
		this.repository().set(CtConsumablelotgenealData.Consumablelotid, Consumablelotid);
		return this;
	}


}