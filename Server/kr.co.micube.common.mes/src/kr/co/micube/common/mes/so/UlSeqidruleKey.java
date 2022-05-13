package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlSeqidruleKey extends SQLKey {

	UlSeqidruleKey() {
	}


	public String getSeqid() {
		return this.repository().getString(UlSeqidruleData.Seqid);
	}

	public UlSeqidruleKey setSeqid(String Seqid) {
		this.repository().set(UlSeqidruleData.Seqid, Seqid);
		return this;
	}


}