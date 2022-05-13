package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlErptmesmatinputKey extends SQLKey {

	UlErptmesmatinputKey() {
	}


	public Integer getSeq() {
		return this.repository().getInteger(UlErptmesmatinputData.Seq);
	}

	public UlErptmesmatinputKey setSeq(Integer Seq) {
		this.repository().set(UlErptmesmatinputData.Seq, Seq);
		return this;
	}


}