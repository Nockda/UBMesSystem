package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtAreaworkerHistoryKey extends SQLKey {

	CtAreaworkerHistoryKey() {
	}


	public String getTxnhistkey() {
		return this.repository().getString(CtAreaworkerHistoryData.Txnhistkey);
	}

	public CtAreaworkerHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtAreaworkerHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(CtAreaworkerHistoryData.Areaid);
	}

	public CtAreaworkerHistoryKey setAreaid(String Areaid) {
		this.repository().set(CtAreaworkerHistoryData.Areaid, Areaid);
		return this;
	}

	public String getUserid() {
		return this.repository().getString(CtAreaworkerHistoryData.Userid);
	}

	public CtAreaworkerHistoryKey setUserid(String Userid) {
		this.repository().set(CtAreaworkerHistoryData.Userid, Userid);
		return this;
	}


}