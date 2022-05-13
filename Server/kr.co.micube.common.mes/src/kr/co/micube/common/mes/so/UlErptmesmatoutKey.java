package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlErptmesmatoutKey extends SQLKey {

	UlErptmesmatoutKey() {
	}


	public Integer getSeq() {
		return this.repository().getInteger(UlErptmesmatoutData.Seq);
	}

	public UlErptmesmatoutKey setSeq(Integer Seq) {
		this.repository().set(UlErptmesmatoutData.Seq, Seq);
		return this;
	}


}