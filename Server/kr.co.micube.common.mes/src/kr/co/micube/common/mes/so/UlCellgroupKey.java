package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlCellgroupKey extends SQLKey {

	UlCellgroupKey() {
	}


	public String getCellgroupid() {
		return this.repository().getString(UlCellgroupData.Cellgroupid);
	}

	public UlCellgroupKey setCellgroupid(String Cellgroupid) {
		this.repository().set(UlCellgroupData.Cellgroupid, Cellgroupid);
		return this;
	}


}