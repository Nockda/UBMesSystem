package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlMaterialetcinoutKey extends SQLKey {

	UlMaterialetcinoutKey() {
	}


	public Integer getSeq() {
		return this.repository().getInteger(UlMaterialetcinoutData.Seq);
	}

	public UlMaterialetcinoutKey setSeq(Integer Seq) {
		this.repository().set(UlMaterialetcinoutData.Seq, Seq);
		return this;
	}


}