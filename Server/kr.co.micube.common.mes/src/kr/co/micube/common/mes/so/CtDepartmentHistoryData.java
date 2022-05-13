package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtDepartmentHistoryData extends SQLData {

	public static final String Departmentid = "DEPARTMENTID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Departmentname = "DEPARTMENTNAME";

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

	public CtDepartmentHistoryData() {
		this(new CtDepartmentHistoryKey()); 
	}

	public CtDepartmentHistoryData(CtDepartmentHistoryKey key) {
		super(key, "CtDepartmentHistory");
	}


	public String getDepartmentname() {
		return this.repository().getString(CtDepartmentHistoryData.Departmentname);
	}

	public CtDepartmentHistoryData setDepartmentname(String Departmentname) {
		this.repository().set(CtDepartmentHistoryData.Departmentname, Departmentname);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(CtDepartmentHistoryData.Dictionaryid);
	}

	public CtDepartmentHistoryData setDictionaryid(String Dictionaryid) {
		this.repository().set(CtDepartmentHistoryData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtDepartmentHistoryData.Description);
	}

	public CtDepartmentHistoryData setDescription(String Description) {
		this.repository().set(CtDepartmentHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtDepartmentHistoryData.Creator);
	}

	public CtDepartmentHistoryData setCreator(String Creator) {
		this.repository().set(CtDepartmentHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtDepartmentHistoryData.Createdtime);
	}

	public CtDepartmentHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtDepartmentHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtDepartmentHistoryData.Modifier);
	}

	public CtDepartmentHistoryData setModifier(String Modifier) {
		this.repository().set(CtDepartmentHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtDepartmentHistoryData.Modifiedtime);
	}

	public CtDepartmentHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtDepartmentHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtDepartmentHistoryData.Txnid);
	}

	public CtDepartmentHistoryData setTxnid(String Txnid) {
		this.repository().set(CtDepartmentHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtDepartmentHistoryData.Txnuser);
	}

	public CtDepartmentHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtDepartmentHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtDepartmentHistoryData.Txntime);
	}

	public CtDepartmentHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtDepartmentHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtDepartmentHistoryData.Txngrouphistkey);
	}

	public CtDepartmentHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtDepartmentHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtDepartmentHistoryData.Txnreasoncodeclass);
	}

	public CtDepartmentHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtDepartmentHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtDepartmentHistoryData.Txnreasoncode);
	}

	public CtDepartmentHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtDepartmentHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtDepartmentHistoryData.Txncomment);
	}

	public CtDepartmentHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtDepartmentHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtDepartmentHistoryData.Validstate);
	}

	public CtDepartmentHistoryData setValidstate(String Validstate) {
		this.repository().set(CtDepartmentHistoryData.Validstate, Validstate);
		return this;
	}


}