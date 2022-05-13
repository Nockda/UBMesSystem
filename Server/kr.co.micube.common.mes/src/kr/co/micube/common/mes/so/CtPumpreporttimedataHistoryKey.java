package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtPumpreporttimedataHistoryKey extends SQLKey {

	CtPumpreporttimedataHistoryKey() {
	}


	public String getLotid() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Lotid);
	}

	public CtPumpreporttimedataHistoryKey setLotid(String Lotid) {
		this.repository().set(CtPumpreporttimedataHistoryData.Lotid, Lotid);
		return this;
	}

	public String getInspectiondegree() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Inspectiondegree);
	}

	public CtPumpreporttimedataHistoryKey setInspectiondegree(String Inspectiondegree) {
		this.repository().set(CtPumpreporttimedataHistoryData.Inspectiondegree, Inspectiondegree);
		return this;
	}

	public String getMeasuretime() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Measuretime);
	}

	public CtPumpreporttimedataHistoryKey setMeasuretime(String Measuretime) {
		this.repository().set(CtPumpreporttimedataHistoryData.Measuretime, Measuretime);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Txnhistkey);
	}

	public CtPumpreporttimedataHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtPumpreporttimedataHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}