package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlKanbanKey extends SQLKey {

	UlKanbanKey() {
	}


	public String getReqcode() {
		return this.repository().getString(UlKanbanData.Reqcode);
	}

	public UlKanbanKey setReqcode(String Reqcode) {
		this.repository().set(UlKanbanData.Reqcode, Reqcode);
		return this;
	}


}