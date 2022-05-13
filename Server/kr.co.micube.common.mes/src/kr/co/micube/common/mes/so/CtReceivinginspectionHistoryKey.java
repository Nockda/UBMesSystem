package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtReceivinginspectionHistoryKey extends SQLKey {

	CtReceivinginspectionHistoryKey() {
	}


	public String getConsumabledefid() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Consumabledefid);
	}

	public CtReceivinginspectionHistoryKey setConsumabledefid(String Consumabledefid) {
		this.repository().set(CtReceivinginspectionHistoryData.Consumabledefid, Consumabledefid);
		return this;
	}

	public String getDeliveryno() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Deliveryno);
	}

	public CtReceivinginspectionHistoryKey setDeliveryno(String Deliveryno) {
		this.repository().set(CtReceivinginspectionHistoryData.Deliveryno, Deliveryno);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Txnhistkey);
	}

	public CtReceivinginspectionHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtReceivinginspectionHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}

	public Integer getDeliverysequence() {
		return this.repository().getInteger(CtReceivinginspectionHistoryData.Deliverysequence);
	}

	public CtReceivinginspectionHistoryKey setDeliverysequence(Integer Deliverysequence) {
		this.repository().set(CtReceivinginspectionHistoryData.Deliverysequence, Deliverysequence);
		return this;
	}


}