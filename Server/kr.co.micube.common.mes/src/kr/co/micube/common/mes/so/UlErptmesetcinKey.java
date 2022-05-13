package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlErptmesetcinKey extends SQLKey {

	UlErptmesetcinKey() {
	}


	public Integer getSeq() {
		return this.repository().getInteger(UlErptmesetcinData.Seq);
	}

	public UlErptmesetcinKey setSeq(Integer Seq) {
		this.repository().set(UlErptmesetcinData.Seq, Seq);
		return this;
	}


}