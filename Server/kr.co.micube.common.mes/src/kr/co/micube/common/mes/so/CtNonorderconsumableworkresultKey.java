package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtNonorderconsumableworkresultKey extends SQLKey {

	CtNonorderconsumableworkresultKey() {
	}


	public String getTxnhistkey() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Txnhistkey);
	}

	public CtNonorderconsumableworkresultKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtNonorderconsumableworkresultData.Txnhistkey, Txnhistkey);
		return this;
	}

	public String getConsumablelotid() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Consumablelotid);
	}

	public CtNonorderconsumableworkresultKey setConsumablelotid(String Consumablelotid) {
		this.repository().set(CtNonorderconsumableworkresultData.Consumablelotid, Consumablelotid);
		return this;
	}


}