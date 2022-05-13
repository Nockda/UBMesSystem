package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfConsumablelotHistoryKey extends SQLKey {

	SfConsumablelotHistoryKey() {
	}


	public String getConsumablelotid() {
		return this.repository().getString(SfConsumablelotHistoryData.Consumablelotid);
	}

	public SfConsumablelotHistoryKey setConsumablelotid(String Consumablelotid) {
		this.repository().set(SfConsumablelotHistoryData.Consumablelotid, Consumablelotid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfConsumablelotHistoryData.Txnhistkey);
	}

	public SfConsumablelotHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfConsumablelotHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}