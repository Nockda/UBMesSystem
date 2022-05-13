package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlWarehouseKey extends SQLKey {

	UlWarehouseKey() {
	}


	public String getWarehousecode() {
		return this.repository().getString(UlWarehouseData.Warehousecode);
	}

	public UlWarehouseKey setWarehousecode(String Warehousecode) {
		this.repository().set(UlWarehouseData.Warehousecode, Warehousecode);
		return this;
	}


}