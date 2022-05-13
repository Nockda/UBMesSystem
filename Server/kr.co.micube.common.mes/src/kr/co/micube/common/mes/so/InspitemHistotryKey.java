package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class InspitemHistotryKey extends SQLKey {

	InspitemHistotryKey() {
	}


	public String getTxnhistkey() {
		return this.repository().getString(InspitemHistotryData.Txnhistkey);
	}

	public InspitemHistotryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(InspitemHistotryData.Txnhistkey, Txnhistkey);
		return this;
	}

	public String getItemid() {
		return this.repository().getString(InspitemHistotryData.Itemid);
	}

	public InspitemHistotryKey setItemid(String Itemid) {
		this.repository().set(InspitemHistotryData.Itemid, Itemid);
		return this;
	}


}