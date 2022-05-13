package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlSpecidKey extends SQLKey {

	UlSpecidKey() {
	}


	public String getSpecdefid() {
		return this.repository().getString(UlSpecidData.Specdefid);
	}

	public UlSpecidKey setSpecdefid(String Specdefid) {
		this.repository().set(UlSpecidData.Specdefid, Specdefid);
		return this;
	}

	public Integer getSeq() {
		return this.repository().getInteger(UlSpecidData.Seq);
	}

	public UlSpecidKey setSeq(Integer Seq) {
		this.repository().set(UlSpecidData.Seq, Seq);
		return this;
	}


}