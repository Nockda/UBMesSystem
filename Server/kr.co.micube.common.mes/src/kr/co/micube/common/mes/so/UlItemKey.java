package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlItemKey extends SQLKey {

	UlItemKey() {
	}


	public String getItemid() {
		return this.repository().getString(UlItemData.Itemid);
	}

	public UlItemKey setItemid(String Itemid) {
		this.repository().set(UlItemData.Itemid, Itemid);
		return this;
	}

	public String getUserid() {
		return this.repository().getString(UlItemData.Userid);
	}

	public UlItemKey setUserid(String Userid) {
		this.repository().set(UlItemData.Userid, Userid);
		return this;
	}


}