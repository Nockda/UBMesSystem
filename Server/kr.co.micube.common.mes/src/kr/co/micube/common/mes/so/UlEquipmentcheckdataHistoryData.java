package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlEquipmentcheckdataHistoryData extends SQLData {

	public static final String Checkdate = "CHECKDATE";

	public static final String Equipcheckid = "EQUIPCHECKID";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Resulttype01 = "RESULTTYPE01";

	public static final String Resulttype02 = "RESULTTYPE02";

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

	public UlEquipmentcheckdataHistoryData() {
		this(new UlEquipmentcheckdataHistoryKey()); 
	}

	public UlEquipmentcheckdataHistoryData(UlEquipmentcheckdataHistoryKey key) {
		super(key, "UlEquipmentcheckdataHistory");
	}


	public String getResulttype01() {
		return this.repository().getString(UlEquipmentcheckdataHistoryData.Resulttype01);
	}

	public UlEquipmentcheckdataHistoryData setResulttype01(String Resulttype01) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Resulttype01, Resulttype01);
		return this;
	}

	public Double getResulttype02() {
		return this.repository().getDouble(UlEquipmentcheckdataHistoryData.Resulttype02);
	}

	public UlEquipmentcheckdataHistoryData setResulttype02(Double Resulttype02) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Resulttype02, Resulttype02);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlEquipmentcheckdataHistoryData.Description);
	}

	public UlEquipmentcheckdataHistoryData setDescription(String Description) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlEquipmentcheckdataHistoryData.Creator);
	}

	public UlEquipmentcheckdataHistoryData setCreator(String Creator) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlEquipmentcheckdataHistoryData.Createdtime);
	}

	public UlEquipmentcheckdataHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlEquipmentcheckdataHistoryData.Modifier);
	}

	public UlEquipmentcheckdataHistoryData setModifier(String Modifier) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlEquipmentcheckdataHistoryData.Modifiedtime);
	}

	public UlEquipmentcheckdataHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlEquipmentcheckdataHistoryData.Txnid);
	}

	public UlEquipmentcheckdataHistoryData setTxnid(String Txnid) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlEquipmentcheckdataHistoryData.Txnuser);
	}

	public UlEquipmentcheckdataHistoryData setTxnuser(String Txnuser) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlEquipmentcheckdataHistoryData.Txntime);
	}

	public UlEquipmentcheckdataHistoryData setTxntime(Date Txntime) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlEquipmentcheckdataHistoryData.Txngrouphistkey);
	}

	public UlEquipmentcheckdataHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlEquipmentcheckdataHistoryData.Txnreasoncodeclass);
	}

	public UlEquipmentcheckdataHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlEquipmentcheckdataHistoryData.Txnreasoncode);
	}

	public UlEquipmentcheckdataHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlEquipmentcheckdataHistoryData.Txncomment);
	}

	public UlEquipmentcheckdataHistoryData setTxncomment(String Txncomment) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlEquipmentcheckdataHistoryData.Validstate);
	}

	public UlEquipmentcheckdataHistoryData setValidstate(String Validstate) {
		this.repository().set(UlEquipmentcheckdataHistoryData.Validstate, Validstate);
		return this;
	}


}