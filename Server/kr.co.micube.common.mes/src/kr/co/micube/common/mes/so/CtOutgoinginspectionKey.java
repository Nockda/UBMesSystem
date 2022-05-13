package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtOutgoinginspectionKey extends SQLKey {

	CtOutgoinginspectionKey() {
	}


	public String getLotid() {
		return this.repository().getString(CtOutgoinginspectionData.Lotid);
	}

	public CtOutgoinginspectionKey setLotid(String Lotid) {
		this.repository().set(CtOutgoinginspectionData.Lotid, Lotid);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(CtOutgoinginspectionData.Processsegmentid);
	}

	public CtOutgoinginspectionKey setProcesssegmentid(String Processsegmentid) {
		this.repository().set(CtOutgoinginspectionData.Processsegmentid, Processsegmentid);
		return this;
	}

	public Double getInspectiondegree() {
		return this.repository().getDouble(CtOutgoinginspectionData.Inspectiondegree);
	}

	public CtOutgoinginspectionKey setInspectiondegree(Double Inspectiondegree) {
		this.repository().set(CtOutgoinginspectionData.Inspectiondegree, Inspectiondegree);
		return this;
	}


}