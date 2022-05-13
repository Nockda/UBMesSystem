package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlEquipmentchecklistHistoryData extends SQLData {

	public static final String Equipcheckid = "EQUIPCHECKID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Equipcheckname = "EQUIPCHECKNAME";

	public static final String Checktype = "CHECKTYPE";

	public static final String Checkway = "CHECKWAY";

	public static final String Checkcycle = "CHECKCYCLE";

	public static final String Checkcount = "CHECKCOUNT";

	public static final String Resultway = "RESULTWAY";

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

	public UlEquipmentchecklistHistoryData() {
		this(new UlEquipmentchecklistHistoryKey()); 
	}

	public UlEquipmentchecklistHistoryData(UlEquipmentchecklistHistoryKey key) {
		super(key, "UlEquipmentchecklistHistory");
	}


	public String getEquipcheckname() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Equipcheckname);
	}

	public UlEquipmentchecklistHistoryData setEquipcheckname(String Equipcheckname) {
		this.repository().set(UlEquipmentchecklistHistoryData.Equipcheckname, Equipcheckname);
		return this;
	}

	public String getChecktype() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Checktype);
	}

	public UlEquipmentchecklistHistoryData setChecktype(String Checktype) {
		this.repository().set(UlEquipmentchecklistHistoryData.Checktype, Checktype);
		return this;
	}

	public String getCheckway() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Checkway);
	}

	public UlEquipmentchecklistHistoryData setCheckway(String Checkway) {
		this.repository().set(UlEquipmentchecklistHistoryData.Checkway, Checkway);
		return this;
	}

	public String getCheckcycle() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Checkcycle);
	}

	public UlEquipmentchecklistHistoryData setCheckcycle(String Checkcycle) {
		this.repository().set(UlEquipmentchecklistHistoryData.Checkcycle, Checkcycle);
		return this;
	}

	public Double getCheckcount() {
		return this.repository().getDouble(UlEquipmentchecklistHistoryData.Checkcount);
	}

	public UlEquipmentchecklistHistoryData setCheckcount(Double Checkcount) {
		this.repository().set(UlEquipmentchecklistHistoryData.Checkcount, Checkcount);
		return this;
	}

	public String getResultway() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Resultway);
	}

	public UlEquipmentchecklistHistoryData setResultway(String Resultway) {
		this.repository().set(UlEquipmentchecklistHistoryData.Resultway, Resultway);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Dictionaryid);
	}

	public UlEquipmentchecklistHistoryData setDictionaryid(String Dictionaryid) {
		this.repository().set(UlEquipmentchecklistHistoryData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Description);
	}

	public UlEquipmentchecklistHistoryData setDescription(String Description) {
		this.repository().set(UlEquipmentchecklistHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Creator);
	}

	public UlEquipmentchecklistHistoryData setCreator(String Creator) {
		this.repository().set(UlEquipmentchecklistHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlEquipmentchecklistHistoryData.Createdtime);
	}

	public UlEquipmentchecklistHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(UlEquipmentchecklistHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Modifier);
	}

	public UlEquipmentchecklistHistoryData setModifier(String Modifier) {
		this.repository().set(UlEquipmentchecklistHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlEquipmentchecklistHistoryData.Modifiedtime);
	}

	public UlEquipmentchecklistHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlEquipmentchecklistHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Txnid);
	}

	public UlEquipmentchecklistHistoryData setTxnid(String Txnid) {
		this.repository().set(UlEquipmentchecklistHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Txnuser);
	}

	public UlEquipmentchecklistHistoryData setTxnuser(String Txnuser) {
		this.repository().set(UlEquipmentchecklistHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlEquipmentchecklistHistoryData.Txntime);
	}

	public UlEquipmentchecklistHistoryData setTxntime(Date Txntime) {
		this.repository().set(UlEquipmentchecklistHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Txngrouphistkey);
	}

	public UlEquipmentchecklistHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlEquipmentchecklistHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Txnreasoncodeclass);
	}

	public UlEquipmentchecklistHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlEquipmentchecklistHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Txnreasoncode);
	}

	public UlEquipmentchecklistHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlEquipmentchecklistHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Txncomment);
	}

	public UlEquipmentchecklistHistoryData setTxncomment(String Txncomment) {
		this.repository().set(UlEquipmentchecklistHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlEquipmentchecklistHistoryData.Validstate);
	}

	public UlEquipmentchecklistHistoryData setValidstate(String Validstate) {
		this.repository().set(UlEquipmentchecklistHistoryData.Validstate, Validstate);
		return this;
	}


}