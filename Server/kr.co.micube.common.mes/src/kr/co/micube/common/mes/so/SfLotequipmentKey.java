package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfLotequipmentKey extends SQLKey {

	SfLotequipmentKey() {
	}


	public String getLotid() {
		return this.repository().getString(SfLotequipmentData.Lotid);
	}

	public SfLotequipmentKey setLotid(String Lotid) {
		this.repository().set(SfLotequipmentData.Lotid, Lotid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfLotequipmentData.Txnhistkey);
	}

	public SfLotequipmentKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfLotequipmentData.Txnhistkey, Txnhistkey);
		return this;
	}


}