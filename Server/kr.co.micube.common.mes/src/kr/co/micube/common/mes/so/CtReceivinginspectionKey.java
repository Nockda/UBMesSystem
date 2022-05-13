package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtReceivinginspectionKey extends SQLKey {

	CtReceivinginspectionKey() {
	}


	public String getConsumabledefid() {
		return this.repository().getString(CtReceivinginspectionData.Consumabledefid);
	}

	public CtReceivinginspectionKey setConsumabledefid(String Consumabledefid) {
		this.repository().set(CtReceivinginspectionData.Consumabledefid, Consumabledefid);
		return this;
	}

	public String getDeliveryno() {
		return this.repository().getString(CtReceivinginspectionData.Deliveryno);
	}

	public CtReceivinginspectionKey setDeliveryno(String Deliveryno) {
		this.repository().set(CtReceivinginspectionData.Deliveryno, Deliveryno);
		return this;
	}

	public Integer getDeliverysequence() {
		return this.repository().getInteger(CtReceivinginspectionData.Deliverysequence);
	}

	public CtReceivinginspectionKey setDeliverysequence(Integer Deliverysequence) {
		this.repository().set(CtReceivinginspectionData.Deliverysequence, Deliverysequence);
		return this;
	}


}