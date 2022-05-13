package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfWarehouseHistoryData extends SQLData {

	public static final String Warehouseid = "WAREHOUSEID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Warehousename = "WAREHOUSENAME";

	public static final String Warehousetype = "WAREHOUSETYPE";

	public static final String Departmentid = "DEPARTMENTID";

	public static final String Dictionaryid = "DICTIONARYID";

	public static final String Description = "DESCRIPTION";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Modifier = "MODIFIER";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public SfWarehouseHistoryData() {
		this(new SfWarehouseHistoryKey()); 
	}

	public SfWarehouseHistoryData(SfWarehouseHistoryKey key) {
		super(key, "SfWarehouseHistory");
	}


	public String getWarehousename() {
		return this.repository().getString(SfWarehouseHistoryData.Warehousename);
	}

	public SfWarehouseHistoryData setWarehousename(String Warehousename) {
		this.repository().set(SfWarehouseHistoryData.Warehousename, Warehousename);
		return this;
	}

	public String getWarehousetype() {
		return this.repository().getString(SfWarehouseHistoryData.Warehousetype);
	}

	public SfWarehouseHistoryData setWarehousetype(String Warehousetype) {
		this.repository().set(SfWarehouseHistoryData.Warehousetype, Warehousetype);
		return this;
	}

	public String getDepartmentid() {
		return this.repository().getString(SfWarehouseHistoryData.Departmentid);
	}

	public SfWarehouseHistoryData setDepartmentid(String Departmentid) {
		this.repository().set(SfWarehouseHistoryData.Departmentid, Departmentid);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfWarehouseHistoryData.Dictionaryid);
	}

	public SfWarehouseHistoryData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfWarehouseHistoryData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfWarehouseHistoryData.Description);
	}

	public SfWarehouseHistoryData setDescription(String Description) {
		this.repository().set(SfWarehouseHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfWarehouseHistoryData.Creator);
	}

	public SfWarehouseHistoryData setCreator(String Creator) {
		this.repository().set(SfWarehouseHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfWarehouseHistoryData.Createdtime);
	}

	public SfWarehouseHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(SfWarehouseHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfWarehouseHistoryData.Modifier);
	}

	public SfWarehouseHistoryData setModifier(String Modifier) {
		this.repository().set(SfWarehouseHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfWarehouseHistoryData.Modifiedtime);
	}

	public SfWarehouseHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfWarehouseHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(SfWarehouseHistoryData.Txnid);
	}

	public SfWarehouseHistoryData setTxnid(String Txnid) {
		this.repository().set(SfWarehouseHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfWarehouseHistoryData.Txnuser);
	}

	public SfWarehouseHistoryData setTxnuser(String Txnuser) {
		this.repository().set(SfWarehouseHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfWarehouseHistoryData.Txntime);
	}

	public SfWarehouseHistoryData setTxntime(Date Txntime) {
		this.repository().set(SfWarehouseHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfWarehouseHistoryData.Txngrouphistkey);
	}

	public SfWarehouseHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfWarehouseHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfWarehouseHistoryData.Txnreasoncodeclass);
	}

	public SfWarehouseHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfWarehouseHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfWarehouseHistoryData.Txnreasoncode);
	}

	public SfWarehouseHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfWarehouseHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfWarehouseHistoryData.Txncomment);
	}

	public SfWarehouseHistoryData setTxncomment(String Txncomment) {
		this.repository().set(SfWarehouseHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfWarehouseHistoryData.Validstate);
	}

	public SfWarehouseHistoryData setValidstate(String Validstate) {
		this.repository().set(SfWarehouseHistoryData.Validstate, Validstate);
		return this;
	}


}