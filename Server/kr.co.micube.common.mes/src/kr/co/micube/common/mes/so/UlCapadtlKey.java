package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlCapadtlKey extends SQLKey {

	UlCapadtlKey() {
	}


	public String getDocid() {
		return this.repository().getString(UlCapadtlData.Docid);
	}

	public UlCapadtlKey setDocid(String Docid) {
		this.repository().set(UlCapadtlData.Docid, Docid);
		return this;
	}

	public Integer getDocsequence() {
		return this.repository().getInteger(UlCapadtlData.Docsequence);
	}

	public UlCapadtlKey setDocsequence(Integer Docsequence) {
		this.repository().set(UlCapadtlData.Docsequence, Docsequence);
		return this;
	}


}