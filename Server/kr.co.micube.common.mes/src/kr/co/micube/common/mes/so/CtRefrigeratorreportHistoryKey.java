package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtRefrigeratorreportHistoryKey extends SQLKey {

	CtRefrigeratorreportHistoryKey() {
	}


	public String getLotid() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Lotid);
	}

	public CtRefrigeratorreportHistoryKey setLotid(String Lotid) {
		this.repository().set(CtRefrigeratorreportHistoryData.Lotid, Lotid);
		return this;
	}

	public String getInspectiondegree() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Inspectiondegree);
	}

	public CtRefrigeratorreportHistoryKey setInspectiondegree(String Inspectiondegree) {
		this.repository().set(CtRefrigeratorreportHistoryData.Inspectiondegree, Inspectiondegree);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Txnhistkey);
	}

	public CtRefrigeratorreportHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtRefrigeratorreportHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}