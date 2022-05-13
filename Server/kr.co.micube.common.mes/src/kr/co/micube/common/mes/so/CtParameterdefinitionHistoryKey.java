package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtParameterdefinitionHistoryKey extends SQLKey {

	CtParameterdefinitionHistoryKey() {
	}


	public String getParameterid() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Parameterid);
	}

	public CtParameterdefinitionHistoryKey setParameterid(String Parameterid) {
		this.repository().set(CtParameterdefinitionHistoryData.Parameterid, Parameterid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Txnhistkey);
	}

	public CtParameterdefinitionHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtParameterdefinitionHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}