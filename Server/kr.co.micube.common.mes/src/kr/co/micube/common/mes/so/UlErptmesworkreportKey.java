package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlErptmesworkreportKey extends SQLKey {

	UlErptmesworkreportKey() {
	}


	public Integer getSeq() {
		return this.repository().getInteger(UlErptmesworkreportData.Seq);
	}

	public UlErptmesworkreportKey setSeq(Integer Seq) {
		this.repository().set(UlErptmesworkreportData.Seq, Seq);
		return this;
	}


}