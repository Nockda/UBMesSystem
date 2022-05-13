package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlMaterialdeliveryKey extends SQLKey {

	UlMaterialdeliveryKey() {
	}


	public Integer getSeq() {
		return this.repository().getInteger(UlMaterialdeliveryData.Seq);
	}

	public UlMaterialdeliveryKey setSeq(Integer Seq) {
		this.repository().set(UlMaterialdeliveryData.Seq, Seq);
		return this;
	}


}