package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlOrderdetailKey extends SQLKey {

	UlOrderdetailKey() {
	}


	public Integer getSeq() {
		return this.repository().getInteger(UlOrderdetailData.Seq);
	}

	public UlOrderdetailKey setSeq(Integer Seq) {
		this.repository().set(UlOrderdetailData.Seq, Seq);
		return this;
	}


}