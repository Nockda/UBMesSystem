package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlRackdetailKey extends SQLKey {

	UlRackdetailKey() {
	}


	public String getCellid() {
		return this.repository().getString(UlRackdetailData.Cellid);
	}

	public UlRackdetailKey setCellid(String Cellid) {
		this.repository().set(UlRackdetailData.Cellid, Cellid);
		return this;
	}


}