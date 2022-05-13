package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlMaterialdeliverytempKey extends SQLKey {

	UlMaterialdeliverytempKey() {
	}


	public Integer getSeq() {
		return this.repository().getInteger(UlMaterialdeliverytempData.Seq);
	}

	public UlMaterialdeliverytempKey setSeq(Integer Seq) {
		this.repository().set(UlMaterialdeliverytempData.Seq, Seq);
		return this;
	}


}