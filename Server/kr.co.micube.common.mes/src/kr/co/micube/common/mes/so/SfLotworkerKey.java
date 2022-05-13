package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfLotworkerKey extends SQLKey {

	SfLotworkerKey() {
	}


	public String getLotid() {
		return this.repository().getString(SfLotworkerData.Lotid);
	}

	public SfLotworkerKey setLotid(String Lotid) {
		this.repository().set(SfLotworkerData.Lotid, Lotid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfLotworkerData.Txnhistkey);
	}

	public SfLotworkerKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfLotworkerData.Txnhistkey, Txnhistkey);
		return this;
	}


}