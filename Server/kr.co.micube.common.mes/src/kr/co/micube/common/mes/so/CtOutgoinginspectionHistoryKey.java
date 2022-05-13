package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtOutgoinginspectionHistoryKey extends SQLKey {

	CtOutgoinginspectionHistoryKey() {
	}


	public String getLotid() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Lotid);
	}

	public CtOutgoinginspectionHistoryKey setLotid(String Lotid) {
		this.repository().set(CtOutgoinginspectionHistoryData.Lotid, Lotid);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Processsegmentid);
	}

	public CtOutgoinginspectionHistoryKey setProcesssegmentid(String Processsegmentid) {
		this.repository().set(CtOutgoinginspectionHistoryData.Processsegmentid, Processsegmentid);
		return this;
	}

	public Double getInspectiondegree() {
		return this.repository().getDouble(CtOutgoinginspectionHistoryData.Inspectiondegree);
	}

	public CtOutgoinginspectionHistoryKey setInspectiondegree(Double Inspectiondegree) {
		this.repository().set(CtOutgoinginspectionHistoryData.Inspectiondegree, Inspectiondegree);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Txnhistkey);
	}

	public CtOutgoinginspectionHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtOutgoinginspectionHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}