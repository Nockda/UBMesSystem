package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlEquipmentcheckmapHistoryData extends SQLData {

	public static final String Equipmentclassid = "EQUIPMENTCLASSID";

	public static final String Equipcheckid = "EQUIPCHECKID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Checkpart = "CHECKPART";

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

	public UlEquipmentcheckmapHistoryData() {
		this(new UlEquipmentcheckmapHistoryKey()); 
	}

	public UlEquipmentcheckmapHistoryData(UlEquipmentcheckmapHistoryKey key) {
		super(key, "UlEquipmentcheckmapHistory");
	}


	public String getCheckpart() {
		return this.repository().getString(UlEquipmentcheckmapHistoryData.Checkpart);
	}

	public UlEquipmentcheckmapHistoryData setCheckpart(String Checkpart) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Checkpart, Checkpart);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlEquipmentcheckmapHistoryData.Description);
	}

	public UlEquipmentcheckmapHistoryData setDescription(String Description) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlEquipmentcheckmapHistoryData.Creator);
	}

	public UlEquipmentcheckmapHistoryData setCreator(String Creator) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlEquipmentcheckmapHistoryData.Createdtime);
	}

	public UlEquipmentcheckmapHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlEquipmentcheckmapHistoryData.Modifier);
	}

	public UlEquipmentcheckmapHistoryData setModifier(String Modifier) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlEquipmentcheckmapHistoryData.Modifiedtime);
	}

	public UlEquipmentcheckmapHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlEquipmentcheckmapHistoryData.Txnid);
	}

	public UlEquipmentcheckmapHistoryData setTxnid(String Txnid) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlEquipmentcheckmapHistoryData.Txnuser);
	}

	public UlEquipmentcheckmapHistoryData setTxnuser(String Txnuser) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlEquipmentcheckmapHistoryData.Txntime);
	}

	public UlEquipmentcheckmapHistoryData setTxntime(Date Txntime) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlEquipmentcheckmapHistoryData.Txngrouphistkey);
	}

	public UlEquipmentcheckmapHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlEquipmentcheckmapHistoryData.Txnreasoncodeclass);
	}

	public UlEquipmentcheckmapHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlEquipmentcheckmapHistoryData.Txnreasoncode);
	}

	public UlEquipmentcheckmapHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlEquipmentcheckmapHistoryData.Txncomment);
	}

	public UlEquipmentcheckmapHistoryData setTxncomment(String Txncomment) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlEquipmentcheckmapHistoryData.Validstate);
	}

	public UlEquipmentcheckmapHistoryData setValidstate(String Validstate) {
		this.repository().set(UlEquipmentcheckmapHistoryData.Validstate, Validstate);
		return this;
	}


}