package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfWarehouseData extends SQLData {

	public static final String Warehouseid = "WAREHOUSEID";

	public static final String Warehousename = "WAREHOUSENAME";

	public static final String Warehousetype = "WAREHOUSETYPE";

	public static final String Departmentid = "DEPARTMENTID";

	public static final String Dictionaryid = "DICTIONARYID";

	public static final String Description = "DESCRIPTION";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Modifier = "MODIFIER";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Lasttxnid = "LASTTXNID";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public static final String Warehouseseq = "WAREHOUSESEQ";

	public SfWarehouseData() {
		this(new SfWarehouseKey()); 
	}

	public SfWarehouseData(SfWarehouseKey key) {
		super(key, "SfWarehouse");
	}


	public String getWarehousename() {
		return this.repository().getString(SfWarehouseData.Warehousename);
	}

	public SfWarehouseData setWarehousename(String Warehousename) {
		this.repository().set(SfWarehouseData.Warehousename, Warehousename);
		return this;
	}

	public String getWarehousetype() {
		return this.repository().getString(SfWarehouseData.Warehousetype);
	}

	public SfWarehouseData setWarehousetype(String Warehousetype) {
		this.repository().set(SfWarehouseData.Warehousetype, Warehousetype);
		return this;
	}

	public String getDepartmentid() {
		return this.repository().getString(SfWarehouseData.Departmentid);
	}

	public SfWarehouseData setDepartmentid(String Departmentid) {
		this.repository().set(SfWarehouseData.Departmentid, Departmentid);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfWarehouseData.Dictionaryid);
	}

	public SfWarehouseData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfWarehouseData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfWarehouseData.Description);
	}

	public SfWarehouseData setDescription(String Description) {
		this.repository().set(SfWarehouseData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfWarehouseData.Creator);
	}

	public SfWarehouseData setCreator(String Creator) {
		this.repository().set(SfWarehouseData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfWarehouseData.Createdtime);
	}

	public SfWarehouseData setCreatedtime(Date Createdtime) {
		this.repository().set(SfWarehouseData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfWarehouseData.Modifier);
	}

	public SfWarehouseData setModifier(String Modifier) {
		this.repository().set(SfWarehouseData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfWarehouseData.Modifiedtime);
	}

	public SfWarehouseData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfWarehouseData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfWarehouseData.Lasttxnhistkey);
	}

	public SfWarehouseData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfWarehouseData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfWarehouseData.Lasttxnid);
	}

	public SfWarehouseData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfWarehouseData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfWarehouseData.Lasttxnuser);
	}

	public SfWarehouseData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfWarehouseData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfWarehouseData.Lasttxntime);
	}

	public SfWarehouseData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfWarehouseData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfWarehouseData.Lasttxncomment);
	}

	public SfWarehouseData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfWarehouseData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfWarehouseData.Validstate);
	}

	public SfWarehouseData setValidstate(String Validstate) {
		this.repository().set(SfWarehouseData.Validstate, Validstate);
		return this;
	}

	public Integer getWarehouseseq() {
		return this.repository().getInteger(SfWarehouseData.Warehouseseq);
	}

	public SfWarehouseData setWarehouseseq(Integer Warehouseseq) {
		this.repository().set(SfWarehouseData.Warehouseseq, Warehouseseq);
		return this;
	}


}