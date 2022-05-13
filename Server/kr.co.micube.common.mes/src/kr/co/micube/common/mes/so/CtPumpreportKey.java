package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtPumpreportKey extends SQLKey {

	CtPumpreportKey() {
	}


	public String getLotid() {
		return this.repository().getString(CtPumpreportData.Lotid);
	}

	public CtPumpreportKey setLotid(String Lotid) {
		this.repository().set(CtPumpreportData.Lotid, Lotid);
		return this;
	}

	public String getInspectiondegree() {
		return this.repository().getString(CtPumpreportData.Inspectiondegree);
	}

	public CtPumpreportKey setInspectiondegree(String Inspectiondegree) {
		this.repository().set(CtPumpreportData.Inspectiondegree, Inspectiondegree);
		return this;
	}


}