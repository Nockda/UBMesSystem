package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlEquipmentcheckdatadetailKey extends SQLKey {

	UlEquipmentcheckdatadetailKey() {
	}


	public Double getSeq() {
		return this.repository().getDouble(UlEquipmentcheckdatadetailData.Seq);
	}

	public UlEquipmentcheckdatadetailKey setSeq(Double Seq) {
		this.repository().set(UlEquipmentcheckdatadetailData.Seq, Seq);
		return this;
	}


}