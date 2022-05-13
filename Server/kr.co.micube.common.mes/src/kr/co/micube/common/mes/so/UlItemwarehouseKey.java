package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlItemwarehouseKey extends SQLKey {

	UlItemwarehouseKey() {
	}


	public String getItemid() {
		return this.repository().getString(UlItemwarehouseData.Itemid);
	}

	public UlItemwarehouseKey setItemid(String Itemid) {
		this.repository().set(UlItemwarehouseData.Itemid, Itemid);
		return this;
	}

	public String getCodeid() {
		return this.repository().getString(UlItemwarehouseData.Codeid);
	}

	public UlItemwarehouseKey setCodeid(String Codeid) {
		this.repository().set(UlItemwarehouseData.Codeid, Codeid);
		return this;
	}


}