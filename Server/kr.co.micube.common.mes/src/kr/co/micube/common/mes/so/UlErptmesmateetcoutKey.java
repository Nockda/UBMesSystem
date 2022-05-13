package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlErptmesmateetcoutKey extends SQLKey {

	UlErptmesmateetcoutKey() {
	}


	public Integer getSeq() {
		return this.repository().getInteger(UlErptmesmateetcoutData.Seq);
	}

	public UlErptmesmateetcoutKey setSeq(Integer Seq) {
		this.repository().set(UlErptmesmateetcoutData.Seq, Seq);
		return this;
	}


}