package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlSpecdetailKey extends SQLKey {

	UlSpecdetailKey() {
	}


	public String getSpecdefid() {
		return this.repository().getString(UlSpecdetailData.Specdefid);
	}

	public UlSpecdetailKey setSpecdefid(String Specdefid) {
		this.repository().set(UlSpecdetailData.Specdefid, Specdefid);
		return this;
	}

	public String getSubprocesssegmentid() {
		return this.repository().getString(UlSpecdetailData.Subprocesssegmentid);
	}

	public UlSpecdetailKey setSubprocesssegmentid(String Subprocesssegmentid) {
		this.repository().set(UlSpecdetailData.Subprocesssegmentid, Subprocesssegmentid);
		return this;
	}

	public String getItemid() {
		return this.repository().getString(UlSpecdetailData.Itemid);
	}

	public UlSpecdetailKey setItemid(String Itemid) {
		this.repository().set(UlSpecdetailData.Itemid, Itemid);
		return this;
	}


}