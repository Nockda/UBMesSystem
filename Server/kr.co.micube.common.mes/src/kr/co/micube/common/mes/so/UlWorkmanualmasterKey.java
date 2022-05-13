package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlWorkmanualmasterKey extends SQLKey {

	UlWorkmanualmasterKey() {
	}


	public String getWorkmanualid() {
		return this.repository().getString(UlWorkmanualmasterData.Workmanualid);
	}

	public UlWorkmanualmasterKey setWorkmanualid(String Workmanualid) {
		this.repository().set(UlWorkmanualmasterData.Workmanualid, Workmanualid);
		return this;
	}


}