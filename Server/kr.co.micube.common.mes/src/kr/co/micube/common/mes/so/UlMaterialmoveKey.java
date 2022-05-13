package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlMaterialmoveKey extends SQLKey {

	UlMaterialmoveKey() {
	}


	public Integer getSeq() {
		return this.repository().getInteger(UlMaterialmoveData.Seq);
	}

	public UlMaterialmoveKey setSeq(Integer Seq) {
		this.repository().set(UlMaterialmoveData.Seq, Seq);
		return this;
	}


}