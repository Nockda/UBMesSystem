package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlKanbanmappinglotKey extends SQLKey {

	UlKanbanmappinglotKey() {
	}


	public String getReqcode() {
		return this.repository().getString(UlKanbanmappinglotData.Reqcode);
	}

	public UlKanbanmappinglotKey setReqcode(String Reqcode) {
		this.repository().set(UlKanbanmappinglotData.Reqcode, Reqcode);
		return this;
	}

	public String getLotid() {
		return this.repository().getString(UlKanbanmappinglotData.Lotid);
	}

	public UlKanbanmappinglotKey setLotid(String Lotid) {
		this.repository().set(UlKanbanmappinglotData.Lotid, Lotid);
		return this;
	}


}