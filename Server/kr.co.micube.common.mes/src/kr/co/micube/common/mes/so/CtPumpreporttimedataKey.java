package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtPumpreporttimedataKey extends SQLKey {

	CtPumpreporttimedataKey() {
	}


	public String getLotid() {
		return this.repository().getString(CtPumpreporttimedataData.Lotid);
	}

	public CtPumpreporttimedataKey setLotid(String Lotid) {
		this.repository().set(CtPumpreporttimedataData.Lotid, Lotid);
		return this;
	}

	public String getInspectiondegree() {
		return this.repository().getString(CtPumpreporttimedataData.Inspectiondegree);
	}

	public CtPumpreporttimedataKey setInspectiondegree(String Inspectiondegree) {
		this.repository().set(CtPumpreporttimedataData.Inspectiondegree, Inspectiondegree);
		return this;
	}

	public String getMeasuretime() {
		return this.repository().getString(CtPumpreporttimedataData.Measuretime);
	}

	public CtPumpreporttimedataKey setMeasuretime(String Measuretime) {
		this.repository().set(CtPumpreporttimedataData.Measuretime, Measuretime);
		return this;
	}


}