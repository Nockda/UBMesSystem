package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlProdefficiencyKey extends SQLKey {

	UlProdefficiencyKey() {
	}


	public String getWorkdate() {
		return this.repository().getString(UlProdefficiencyData.Workdate);
	}

	public UlProdefficiencyKey setWorkdate(String Workdate) {
		this.repository().set(UlProdefficiencyData.Workdate, Workdate);
		return this;
	}

	public String getTeamid() {
		return this.repository().getString(UlProdefficiencyData.Teamid);
	}

	public UlProdefficiencyKey setTeamid(String Teamid) {
		this.repository().set(UlProdefficiencyData.Teamid, Teamid);
		return this;
	}


}