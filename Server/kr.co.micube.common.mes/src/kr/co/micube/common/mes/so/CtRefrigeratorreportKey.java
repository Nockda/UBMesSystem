package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtRefrigeratorreportKey extends SQLKey {

	CtRefrigeratorreportKey() {
	}


	public String getLotid() {
		return this.repository().getString(CtRefrigeratorreportData.Lotid);
	}

	public CtRefrigeratorreportKey setLotid(String Lotid) {
		this.repository().set(CtRefrigeratorreportData.Lotid, Lotid);
		return this;
	}

	public String getInspectiondegree() {
		return this.repository().getString(CtRefrigeratorreportData.Inspectiondegree);
	}

	public CtRefrigeratorreportKey setInspectiondegree(String Inspectiondegree) {
		this.repository().set(CtRefrigeratorreportData.Inspectiondegree, Inspectiondegree);
		return this;
	}


}