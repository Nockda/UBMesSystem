package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlErptmesetcoutKey extends SQLKey {

	UlErptmesetcoutKey() {
	}


	public Integer getSeq() {
		return this.repository().getInteger(UlErptmesetcoutData.Seq);
	}

	public UlErptmesetcoutKey setSeq(Integer Seq) {
		this.repository().set(UlErptmesetcoutData.Seq, Seq);
		return this;
	}


}