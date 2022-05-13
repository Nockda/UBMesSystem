package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlWarehouseData extends SQLData {

	public static final String Warehousecode = "WAREHOUSECODE";

	public static final String Warehousenameeng = "WAREHOUSENAMEENG";

	public static final String Warehousenamejpn = "WAREHOUSENAMEJPN";

	public static final String Warehousenamekor = "WAREHOUSENAMEKOR";

	public static final String Validstate = "VALIDSTATE";

	public static final String Modifier = "MODIFIER";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Description = "DESCRIPTION";

	public static final String Modifiedtime = "MODIFIEDTIME";
	
	public static final String Warehousetype = "WAREHOUSETYPE";
	
	public static final String Departmentid = "DEPARTMENTID";

	public UlWarehouseData() {
		this(new UlWarehouseKey()); 
	}

	public UlWarehouseData(UlWarehouseKey key) {
		super(key, "UlWarehouse");
	}

	public String getWarehousenameeng() {
		return this.repository().getString(UlWarehouseData.Warehousenameeng);
	}

	public UlWarehouseData setWarehousenameeng(String Warehousenameeng) {
		this.repository().set(UlWarehouseData.Warehousenameeng, Warehousenameeng);
		return this;
	}

	public String getWarehousenamejpn() {
		return this.repository().getString(UlWarehouseData.Warehousenamejpn);
	}

	public UlWarehouseData setWarehousenamejpn(String Warehousenamejpn) {
		this.repository().set(UlWarehouseData.Warehousenamejpn, Warehousenamejpn);
		return this;
	}

	public String getWarehousenamekor() {
		return this.repository().getString(UlWarehouseData.Warehousenamekor);
	}

	public UlWarehouseData setWarehousenamekor(String Warehousenamekor) {
		this.repository().set(UlWarehouseData.Warehousenamekor, Warehousenamekor);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlWarehouseData.Validstate);
	}

	public UlWarehouseData setValidstate(String Validstate) {
		this.repository().set(UlWarehouseData.Validstate, Validstate);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlWarehouseData.Modifier);
	}

	public UlWarehouseData setModifier(String Modifier) {
		this.repository().set(UlWarehouseData.Modifier, Modifier);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlWarehouseData.Creator);
	}

	public UlWarehouseData setCreator(String Creator) {
		this.repository().set(UlWarehouseData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlWarehouseData.Createdtime);
	}

	public UlWarehouseData setCreatedtime(Date Createdtime) {
		this.repository().set(UlWarehouseData.Createdtime, Createdtime);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlWarehouseData.Description);
	}

	public UlWarehouseData setDescription(String Description) {
		this.repository().set(UlWarehouseData.Description, Description);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlWarehouseData.Modifiedtime);
	}

	public UlWarehouseData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlWarehouseData.Modifiedtime, Modifiedtime);
		return this;
	}
	
	public Date getWarehousetype() {
		return this.repository().getDate(UlWarehouseData.Warehousetype);
	}

	public UlWarehouseData setWarehousetype(String Warehousetype) {
		this.repository().set(UlWarehouseData.Warehousetype, Warehousetype);
		return this;
	}
	
	public Date getDepartmentid() {
		return this.repository().getDate(UlWarehouseData.Departmentid);
	}

	public UlWarehouseData setDepartmentid(String Departmentid) {
		this.repository().set(UlWarehouseData.Departmentid, Departmentid);
		return this;
	}

}