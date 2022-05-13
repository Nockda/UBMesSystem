package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlErptmesmateetcinKey extends SQLKey {

	UlErptmesmateetcinKey() {
	}


	public Integer getSeq() {
		return this.repository().getInteger(UlErptmesmateetcinData.Seq);
	}

	public UlErptmesmateetcinKey setSeq(Integer Seq) {
		this.repository().set(UlErptmesmateetcinData.Seq, Seq);
		return this;
	}


}