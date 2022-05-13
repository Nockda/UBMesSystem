package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlQmfileKey extends SQLKey {

	UlQmfileKey() {
	}


	public Integer getSeqnumber() {
		return this.repository().getInteger(UlQmfileData.Seqnumber);
	}

	public UlQmfileKey setSeqnumber(Integer Seqnumber) {
		this.repository().set(UlQmfileData.Seqnumber, Seqnumber);
		return this;
	}

	public String getDocid() {
		return this.repository().getString(UlQmfileData.Docid);
	}

	public UlQmfileKey setDocid(String Docid) {
		this.repository().set(UlQmfileData.Docid, Docid);
		return this;
	}


}