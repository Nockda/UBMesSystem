package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtReceivinginspectionitemresultKey extends SQLKey {

	CtReceivinginspectionitemresultKey() {
	}


	public String getConsumabledefid() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Consumabledefid);
	}

	public CtReceivinginspectionitemresultKey setConsumabledefid(String Consumabledefid) {
		this.repository().set(CtReceivinginspectionitemresultData.Consumabledefid, Consumabledefid);
		return this;
	}

	public String getDeliveryno() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Deliveryno);
	}

	public CtReceivinginspectionitemresultKey setDeliveryno(String Deliveryno) {
		this.repository().set(CtReceivinginspectionitemresultData.Deliveryno, Deliveryno);
		return this;
	}

	public String getDeliveryserialno() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Deliveryserialno);
	}

	public CtReceivinginspectionitemresultKey setDeliveryserialno(String Deliveryserialno) {
		this.repository().set(CtReceivinginspectionitemresultData.Deliveryserialno, Deliveryserialno);
		return this;
	}

	public Integer getDeliverysequence() {
		return this.repository().getInteger(CtReceivinginspectionitemresultData.Deliverysequence);
	}

	public CtReceivinginspectionitemresultKey setDeliverysequence(Integer Deliverysequence) {
		this.repository().set(CtReceivinginspectionitemresultData.Deliverysequence, Deliverysequence);
		return this;
	}


}