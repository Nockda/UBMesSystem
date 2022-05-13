package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtUnitdefinitionHistoryKey extends SQLKey {

	CtUnitdefinitionHistoryKey() {
	}


	public String getUnitid() {
		return this.repository().getString(CtUnitdefinitionHistoryData.Unitid);
	}

	public CtUnitdefinitionHistoryKey setUnitid(String Unitid) {
		this.repository().set(CtUnitdefinitionHistoryData.Unitid, Unitid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(CtUnitdefinitionHistoryData.Txnhistkey);
	}

	public CtUnitdefinitionHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtUnitdefinitionHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}