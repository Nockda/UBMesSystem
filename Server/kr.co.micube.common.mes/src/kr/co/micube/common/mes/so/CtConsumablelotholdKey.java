package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtConsumablelotholdKey extends SQLKey {

	CtConsumablelotholdKey() {
	}


	public String getConsumablelotid() {
		return this.repository().getString(CtConsumablelotholdData.Consumablelotid);
	}

	public CtConsumablelotholdKey setConsumablelotid(String Consumablelotid) {
		this.repository().set(CtConsumablelotholdData.Consumablelotid, Consumablelotid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(CtConsumablelotholdData.Txnhistkey);
	}

	public CtConsumablelotholdKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtConsumablelotholdData.Txnhistkey, Txnhistkey);
		return this;
	}


}