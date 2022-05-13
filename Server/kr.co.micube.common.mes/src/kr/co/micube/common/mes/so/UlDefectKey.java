package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlDefectKey extends SQLKey {

	UlDefectKey() {
	}


	public String getDocid() {
		return this.repository().getString(UlDefectData.Docid);
	}

	public UlDefectKey setDocid(String Docid) {
		this.repository().set(UlDefectData.Docid, Docid);
		return this;
	}


}