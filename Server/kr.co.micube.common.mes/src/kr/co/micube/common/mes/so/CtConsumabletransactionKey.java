package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtConsumabletransactionKey extends SQLKey {

	CtConsumabletransactionKey() {
	}


	public String getTxnhistkey() {
		return this.repository().getString(CtConsumabletransactionData.Txnhistkey);
	}

	public CtConsumabletransactionKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtConsumabletransactionData.Txnhistkey, Txnhistkey);
		return this;
	}


}