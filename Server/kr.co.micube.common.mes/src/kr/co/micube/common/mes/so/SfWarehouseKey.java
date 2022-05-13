package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfWarehouseKey extends SQLKey {

	SfWarehouseKey() {
	}


	public String getWarehouseid() {
		return this.repository().getString(SfWarehouseData.Warehouseid);
	}

	public SfWarehouseKey setWarehouseid(String Warehouseid) {
		this.repository().set(SfWarehouseData.Warehouseid, Warehouseid);
		return this;
	}


}