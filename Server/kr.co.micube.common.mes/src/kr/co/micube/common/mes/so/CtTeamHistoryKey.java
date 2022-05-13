package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtTeamHistoryKey extends SQLKey {

	CtTeamHistoryKey() {
	}


	public String getTeamid() {
		return this.repository().getString(CtTeamHistoryData.Teamid);
	}

	public CtTeamHistoryKey setTeamid(String Teamid) {
		this.repository().set(CtTeamHistoryData.Teamid, Teamid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(CtTeamHistoryData.Txnhistkey);
	}

	public CtTeamHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtTeamHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}