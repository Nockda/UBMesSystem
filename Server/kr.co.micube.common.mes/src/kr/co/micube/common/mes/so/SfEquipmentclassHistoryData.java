package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfEquipmentclassHistoryData extends SQLData {

	public static final String Equipmentclassid = "EQUIPMENTCLASSID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Equipmentclassname = "EQUIPMENTCLASSNAME";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Equipmentclasstype = "EQUIPMENTCLASSTYPE";

	public static final String Parentequipmentclassid = "PARENTEQUIPMENTCLASSID";

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

	public SfEquipmentclassHistoryData() {
		this(new SfEquipmentclassHistoryKey()); 
	}

	public SfEquipmentclassHistoryData(SfEquipmentclassHistoryKey key) {
		super(key, "SfEquipmentclassHistory");
	}


	public String getEquipmentclassname() {
		return this.repository().getString(SfEquipmentclassHistoryData.Equipmentclassname);
	}

	public SfEquipmentclassHistoryData setEquipmentclassname(String Equipmentclassname) {
		this.repository().set(SfEquipmentclassHistoryData.Equipmentclassname, Equipmentclassname);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfEquipmentclassHistoryData.Enterpriseid);
	}

	public SfEquipmentclassHistoryData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfEquipmentclassHistoryData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfEquipmentclassHistoryData.Plantid);
	}

	public SfEquipmentclassHistoryData setPlantid(String Plantid) {
		this.repository().set(SfEquipmentclassHistoryData.Plantid, Plantid);
		return this;
	}

	public String getEquipmentclasstype() {
		return this.repository().getString(SfEquipmentclassHistoryData.Equipmentclasstype);
	}

	public SfEquipmentclassHistoryData setEquipmentclasstype(String Equipmentclasstype) {
		this.repository().set(SfEquipmentclassHistoryData.Equipmentclasstype, Equipmentclasstype);
		return this;
	}

	public String getParentequipmentclassid() {
		return this.repository().getString(SfEquipmentclassHistoryData.Parentequipmentclassid);
	}

	public SfEquipmentclassHistoryData setParentequipmentclassid(String Parentequipmentclassid) {
		this.repository().set(SfEquipmentclassHistoryData.Parentequipmentclassid, Parentequipmentclassid);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfEquipmentclassHistoryData.Dictionaryid);
	}

	public SfEquipmentclassHistoryData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfEquipmentclassHistoryData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfEquipmentclassHistoryData.Description);
	}

	public SfEquipmentclassHistoryData setDescription(String Description) {
		this.repository().set(SfEquipmentclassHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfEquipmentclassHistoryData.Creator);
	}

	public SfEquipmentclassHistoryData setCreator(String Creator) {
		this.repository().set(SfEquipmentclassHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfEquipmentclassHistoryData.Createdtime);
	}

	public SfEquipmentclassHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(SfEquipmentclassHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfEquipmentclassHistoryData.Modifier);
	}

	public SfEquipmentclassHistoryData setModifier(String Modifier) {
		this.repository().set(SfEquipmentclassHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfEquipmentclassHistoryData.Modifiedtime);
	}

	public SfEquipmentclassHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfEquipmentclassHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(SfEquipmentclassHistoryData.Txnid);
	}

	public SfEquipmentclassHistoryData setTxnid(String Txnid) {
		this.repository().set(SfEquipmentclassHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfEquipmentclassHistoryData.Txnuser);
	}

	public SfEquipmentclassHistoryData setTxnuser(String Txnuser) {
		this.repository().set(SfEquipmentclassHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfEquipmentclassHistoryData.Txntime);
	}

	public SfEquipmentclassHistoryData setTxntime(Date Txntime) {
		this.repository().set(SfEquipmentclassHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfEquipmentclassHistoryData.Txngrouphistkey);
	}

	public SfEquipmentclassHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfEquipmentclassHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfEquipmentclassHistoryData.Txnreasoncodeclass);
	}

	public SfEquipmentclassHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfEquipmentclassHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfEquipmentclassHistoryData.Txnreasoncode);
	}

	public SfEquipmentclassHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfEquipmentclassHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfEquipmentclassHistoryData.Txncomment);
	}

	public SfEquipmentclassHistoryData setTxncomment(String Txncomment) {
		this.repository().set(SfEquipmentclassHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfEquipmentclassHistoryData.Validstate);
	}

	public SfEquipmentclassHistoryData setValidstate(String Validstate) {
		this.repository().set(SfEquipmentclassHistoryData.Validstate, Validstate);
		return this;
	}


}