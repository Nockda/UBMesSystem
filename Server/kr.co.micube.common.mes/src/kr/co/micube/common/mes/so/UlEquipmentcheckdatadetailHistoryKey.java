package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlEquipmentcheckdatadetailHistoryKey extends SQLKey {

	UlEquipmentcheckdatadetailHistoryKey() {
	}


	public Double getSeq() {
		return this.repository().getDouble(UlEquipmentcheckdatadetailHistoryData.Seq);
	}

	public UlEquipmentcheckdatadetailHistoryKey setSeq(Double Seq) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Seq, Seq);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(UlEquipmentcheckdatadetailHistoryData.Txnhistkey);
	}

	public UlEquipmentcheckdatadetailHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}