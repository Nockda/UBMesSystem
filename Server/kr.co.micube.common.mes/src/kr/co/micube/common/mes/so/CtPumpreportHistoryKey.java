package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtPumpreportHistoryKey extends SQLKey {

	CtPumpreportHistoryKey() {
	}


	public String getLotid() {
		return this.repository().getString(CtPumpreportHistoryData.Lotid);
	}

	public CtPumpreportHistoryKey setLotid(String Lotid) {
		this.repository().set(CtPumpreportHistoryData.Lotid, Lotid);
		return this;
	}

	public String getInspectiondegree() {
		return this.repository().getString(CtPumpreportHistoryData.Inspectiondegree);
	}

	public CtPumpreportHistoryKey setInspectiondegree(String Inspectiondegree) {
		this.repository().set(CtPumpreportHistoryData.Inspectiondegree, Inspectiondegree);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(CtPumpreportHistoryData.Txnhistkey);
	}

	public CtPumpreportHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtPumpreportHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}