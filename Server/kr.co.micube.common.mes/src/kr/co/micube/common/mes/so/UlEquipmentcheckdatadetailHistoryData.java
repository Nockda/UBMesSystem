package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlEquipmentcheckdatadetailHistoryData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Occurdate = "OCCURDATE";

	public static final String Occurdescription = "OCCURDESCRIPTION";

	public static final String Actiondate = "ACTIONDATE";

	public static final String Actiondescription = "ACTIONDESCRIPTION";

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

	public UlEquipmentcheckdatadetailHistoryData() {
		this(new UlEquipmentcheckdatadetailHistoryKey()); 
	}

	public UlEquipmentcheckdatadetailHistoryData(UlEquipmentcheckdatadetailHistoryKey key) {
		super(key, "UlEquipmentcheckdatadetailHistory");
	}


	public String getEquipmentid() {
		return this.repository().getString(UlEquipmentcheckdatadetailHistoryData.Equipmentid);
	}

	public UlEquipmentcheckdatadetailHistoryData setEquipmentid(String Equipmentid) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Equipmentid, Equipmentid);
		return this;
	}

	public Date getOccurdate() {
		return this.repository().getDate(UlEquipmentcheckdatadetailHistoryData.Occurdate);
	}

	public UlEquipmentcheckdatadetailHistoryData setOccurdate(Date Occurdate) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Occurdate, Occurdate);
		return this;
	}

	public String getOccurdescription() {
		return this.repository().getString(UlEquipmentcheckdatadetailHistoryData.Occurdescription);
	}

	public UlEquipmentcheckdatadetailHistoryData setOccurdescription(String Occurdescription) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Occurdescription, Occurdescription);
		return this;
	}

	public Date getActiondate() {
		return this.repository().getDate(UlEquipmentcheckdatadetailHistoryData.Actiondate);
	}

	public UlEquipmentcheckdatadetailHistoryData setActiondate(Date Actiondate) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Actiondate, Actiondate);
		return this;
	}

	public String getActiondescription() {
		return this.repository().getString(UlEquipmentcheckdatadetailHistoryData.Actiondescription);
	}

	public UlEquipmentcheckdatadetailHistoryData setActiondescription(String Actiondescription) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Actiondescription, Actiondescription);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlEquipmentcheckdatadetailHistoryData.Description);
	}

	public UlEquipmentcheckdatadetailHistoryData setDescription(String Description) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlEquipmentcheckdatadetailHistoryData.Creator);
	}

	public UlEquipmentcheckdatadetailHistoryData setCreator(String Creator) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlEquipmentcheckdatadetailHistoryData.Createdtime);
	}

	public UlEquipmentcheckdatadetailHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlEquipmentcheckdatadetailHistoryData.Modifier);
	}

	public UlEquipmentcheckdatadetailHistoryData setModifier(String Modifier) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlEquipmentcheckdatadetailHistoryData.Modifiedtime);
	}

	public UlEquipmentcheckdatadetailHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlEquipmentcheckdatadetailHistoryData.Txnid);
	}

	public UlEquipmentcheckdatadetailHistoryData setTxnid(String Txnid) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlEquipmentcheckdatadetailHistoryData.Txnuser);
	}

	public UlEquipmentcheckdatadetailHistoryData setTxnuser(String Txnuser) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlEquipmentcheckdatadetailHistoryData.Txntime);
	}

	public UlEquipmentcheckdatadetailHistoryData setTxntime(Date Txntime) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlEquipmentcheckdatadetailHistoryData.Txngrouphistkey);
	}

	public UlEquipmentcheckdatadetailHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlEquipmentcheckdatadetailHistoryData.Txnreasoncodeclass);
	}

	public UlEquipmentcheckdatadetailHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlEquipmentcheckdatadetailHistoryData.Txnreasoncode);
	}

	public UlEquipmentcheckdatadetailHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlEquipmentcheckdatadetailHistoryData.Txncomment);
	}

	public UlEquipmentcheckdatadetailHistoryData setTxncomment(String Txncomment) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlEquipmentcheckdatadetailHistoryData.Validstate);
	}

	public UlEquipmentcheckdatadetailHistoryData setValidstate(String Validstate) {
		this.repository().set(UlEquipmentcheckdatadetailHistoryData.Validstate, Validstate);
		return this;
	}


}