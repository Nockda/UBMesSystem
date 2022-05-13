package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtTeamKey extends SQLKey {

	CtTeamKey() {
	}


	public String getTeamid() {
		return this.repository().getString(CtTeamData.Teamid);
	}

	public CtTeamKey setTeamid(String Teamid) {
		this.repository().set(CtTeamData.Teamid, Teamid);
		return this;
	}


}