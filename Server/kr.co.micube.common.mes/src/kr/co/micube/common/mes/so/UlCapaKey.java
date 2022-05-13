package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlCapaKey extends SQLKey {

	UlCapaKey() {
	}


	public String getDocid() {
		return this.repository().getString(UlCapaData.Docid);
	}

	public UlCapaKey setDocid(String Docid) {
		this.repository().set(UlCapaData.Docid, Docid);
		return this;
	}


}