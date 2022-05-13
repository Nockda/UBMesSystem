package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfMaintitemHistoryData extends SQLData {

	public static final String Maintitemid = "MAINTITEMID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Maintitemname = "MAINTITEMNAME";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Maintitemclassid = "MAINTITEMCLASSID";

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

	public SfMaintitemHistoryData() {
		this(new SfMaintitemHistoryKey()); 
	}

	public SfMaintitemHistoryData(SfMaintitemHistoryKey key) {
		super(key, "SfMaintitemHistory");
	}


	public String getMaintitemname() {
		return this.repository().getString(SfMaintitemHistoryData.Maintitemname);
	}

	public SfMaintitemHistoryData setMaintitemname(String Maintitemname) {
		this.repository().set(SfMaintitemHistoryData.Maintitemname, Maintitemname);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfMaintitemHistoryData.Enterpriseid);
	}

	public SfMaintitemHistoryData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfMaintitemHistoryData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfMaintitemHistoryData.Plantid);
	}

	public SfMaintitemHistoryData setPlantid(String Plantid) {
		this.repository().set(SfMaintitemHistoryData.Plantid, Plantid);
		return this;
	}

	public String getMaintitemclassid() {
		return this.repository().getString(SfMaintitemHistoryData.Maintitemclassid);
	}

	public SfMaintitemHistoryData setMaintitemclassid(String Maintitemclassid) {
		this.repository().set(SfMaintitemHistoryData.Maintitemclassid, Maintitemclassid);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfMaintitemHistoryData.Dictionaryid);
	}

	public SfMaintitemHistoryData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfMaintitemHistoryData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfMaintitemHistoryData.Description);
	}

	public SfMaintitemHistoryData setDescription(String Description) {
		this.repository().set(SfMaintitemHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfMaintitemHistoryData.Creator);
	}

	public SfMaintitemHistoryData setCreator(String Creator) {
		this.repository().set(SfMaintitemHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfMaintitemHistoryData.Createdtime);
	}

	public SfMaintitemHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(SfMaintitemHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfMaintitemHistoryData.Modifier);
	}

	public SfMaintitemHistoryData setModifier(String Modifier) {
		this.repository().set(SfMaintitemHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfMaintitemHistoryData.Modifiedtime);
	}

	public SfMaintitemHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfMaintitemHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(SfMaintitemHistoryData.Txnid);
	}

	public SfMaintitemHistoryData setTxnid(String Txnid) {
		this.repository().set(SfMaintitemHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfMaintitemHistoryData.Txnuser);
	}

	public SfMaintitemHistoryData setTxnuser(String Txnuser) {
		this.repository().set(SfMaintitemHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfMaintitemHistoryData.Txntime);
	}

	public SfMaintitemHistoryData setTxntime(Date Txntime) {
		this.repository().set(SfMaintitemHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfMaintitemHistoryData.Txngrouphistkey);
	}

	public SfMaintitemHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfMaintitemHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfMaintitemHistoryData.Txnreasoncodeclass);
	}

	public SfMaintitemHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfMaintitemHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfMaintitemHistoryData.Txnreasoncode);
	}

	public SfMaintitemHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfMaintitemHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfMaintitemHistoryData.Txncomment);
	}

	public SfMaintitemHistoryData setTxncomment(String Txncomment) {
		this.repository().set(SfMaintitemHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfMaintitemHistoryData.Validstate);
	}

	public SfMaintitemHistoryData setValidstate(String Validstate) {
		this.repository().set(SfMaintitemHistoryData.Validstate, Validstate);
		return this;
	}


}