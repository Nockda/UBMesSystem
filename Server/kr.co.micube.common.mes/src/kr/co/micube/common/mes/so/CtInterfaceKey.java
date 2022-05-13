package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtInterfaceKey extends SQLKey {

	CtInterfaceKey() {
	}


	public String getInterfaceid() {
		return this.repository().getString(CtInterfaceData.Interfaceid);
	}

	public CtInterfaceKey setInterfaceid(String Interfaceid) {
		this.repository().set(CtInterfaceData.Interfaceid, Interfaceid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(CtInterfaceData.Txnhistkey);
	}

	public CtInterfaceKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtInterfaceData.Txnhistkey, Txnhistkey);
		return this;
	}


}