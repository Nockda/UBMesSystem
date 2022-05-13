package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlErptmesspudelvKey extends SQLKey {

	UlErptmesspudelvKey() {
	}


	public Integer getSeq() {
		return this.repository().getInteger(UlErptmesspudelvData.Seq);
	}

	public UlErptmesspudelvKey setSeq(Integer Seq) {
		this.repository().set(UlErptmesspudelvData.Seq, Seq);
		return this;
	}


}