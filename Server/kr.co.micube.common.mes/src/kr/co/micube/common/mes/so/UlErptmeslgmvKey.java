package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlErptmeslgmvKey extends SQLKey {

	UlErptmeslgmvKey() {
	}


	public Integer getSeq() {
		return this.repository().getInteger(UlErptmeslgmvData.Seq);
	}

	public UlErptmeslgmvKey setSeq(Integer Seq) {
		this.repository().set(UlErptmeslgmvData.Seq, Seq);
		return this;
	}


}