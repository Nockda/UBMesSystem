package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlCellKey extends SQLKey {

	UlCellKey() {
	}


	public String getCellid() {
		return this.repository().getString(UlCellData.Cellid);
	}

	public UlCellKey setCellid(String Cellid) {
		this.repository().set(UlCellData.Cellid, Cellid);
		return this;
	}


}