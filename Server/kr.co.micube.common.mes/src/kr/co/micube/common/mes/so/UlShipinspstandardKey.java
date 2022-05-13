package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlShipinspstandardKey extends SQLKey {

	UlShipinspstandardKey() {
	}


	public Integer getRevno() {
		return this.repository().getInteger(UlShipinspstandardData.Revno);
	}

	public UlShipinspstandardKey setRevno(Integer Revno) {
		this.repository().set(UlShipinspstandardData.Revno, Revno);
		return this;
	}

	public String getInspectionid() {
		return this.repository().getString(UlShipinspstandardData.Inspectionid);
	}

	public UlShipinspstandardKey setInspectionid(String Inspectionid) {
		this.repository().set(UlShipinspstandardData.Inspectionid, Inspectionid);
		return this;
	}


}