package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlMaterialdeliveryreqKey extends SQLKey {

	UlMaterialdeliveryreqKey() {
	}


	public Integer getSeq() {
		return this.repository().getInteger(UlMaterialdeliveryreqData.Seq);
	}

	public UlMaterialdeliveryreqKey setSeq(Integer Seq) {
		this.repository().set(UlMaterialdeliveryreqData.Seq, Seq);
		return this;
	}


}