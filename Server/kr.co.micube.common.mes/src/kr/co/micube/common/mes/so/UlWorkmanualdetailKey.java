package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlWorkmanualdetailKey extends SQLKey {

	UlWorkmanualdetailKey() {
	}


	public String getWorkmanualid() {
		return this.repository().getString(UlWorkmanualdetailData.Workmanualid);
	}

	public UlWorkmanualdetailKey setWorkmanualid(String Workmanualid) {
		this.repository().set(UlWorkmanualdetailData.Workmanualid, Workmanualid);
		return this;
	}

	public String getRevisionid() {
		return this.repository().getString(UlWorkmanualdetailData.Revisionid);
	}

	public UlWorkmanualdetailKey setRevisionid(String Revisionid) {
		this.repository().set(UlWorkmanualdetailData.Revisionid, Revisionid);
		return this;
	}


}