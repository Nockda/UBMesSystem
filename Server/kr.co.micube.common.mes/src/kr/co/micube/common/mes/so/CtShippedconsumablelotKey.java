package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtShippedconsumablelotKey extends SQLKey {

	CtShippedconsumablelotKey() {
	}


	public String getTxnhistkey() {
		return this.repository().getString(CtShippedconsumablelotData.Txnhistkey);
	}

	public CtShippedconsumablelotKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtShippedconsumablelotData.Txnhistkey, Txnhistkey);
		return this;
	}

	public String getConsumablelotid() {
		return this.repository().getString(CtShippedconsumablelotData.Consumablelotid);
	}

	public CtShippedconsumablelotKey setConsumablelotid(String Consumablelotid) {
		this.repository().set(CtShippedconsumablelotData.Consumablelotid, Consumablelotid);
		return this;
	}


}