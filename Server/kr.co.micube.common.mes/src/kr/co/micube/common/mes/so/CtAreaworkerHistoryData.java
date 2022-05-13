package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtAreaworkerHistoryData extends SQLData {

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Areaid = "AREAID";

	public static final String Userid = "USERID";

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

	public CtAreaworkerHistoryData() {
		this(new CtAreaworkerHistoryKey()); 
	}

	public CtAreaworkerHistoryData(CtAreaworkerHistoryKey key) {
		super(key, "CtAreaworkerHistory");
	}


	public String getDescription() {
		return this.repository().getString(CtAreaworkerHistoryData.Description);
	}

	public CtAreaworkerHistoryData setDescription(String Description) {
		this.repository().set(CtAreaworkerHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtAreaworkerHistoryData.Creator);
	}

	public CtAreaworkerHistoryData setCreator(String Creator) {
		this.repository().set(CtAreaworkerHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtAreaworkerHistoryData.Createdtime);
	}

	public CtAreaworkerHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtAreaworkerHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtAreaworkerHistoryData.Modifier);
	}

	public CtAreaworkerHistoryData setModifier(String Modifier) {
		this.repository().set(CtAreaworkerHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtAreaworkerHistoryData.Modifiedtime);
	}

	public CtAreaworkerHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtAreaworkerHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtAreaworkerHistoryData.Txnid);
	}

	public CtAreaworkerHistoryData setTxnid(String Txnid) {
		this.repository().set(CtAreaworkerHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtAreaworkerHistoryData.Txnuser);
	}

	public CtAreaworkerHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtAreaworkerHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtAreaworkerHistoryData.Txntime);
	}

	public CtAreaworkerHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtAreaworkerHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtAreaworkerHistoryData.Txngrouphistkey);
	}

	public CtAreaworkerHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtAreaworkerHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtAreaworkerHistoryData.Txnreasoncodeclass);
	}

	public CtAreaworkerHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtAreaworkerHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtAreaworkerHistoryData.Txnreasoncode);
	}

	public CtAreaworkerHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtAreaworkerHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtAreaworkerHistoryData.Txncomment);
	}

	public CtAreaworkerHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtAreaworkerHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtAreaworkerHistoryData.Validstate);
	}

	public CtAreaworkerHistoryData setValidstate(String Validstate) {
		this.repository().set(CtAreaworkerHistoryData.Validstate, Validstate);
		return this;
	}


}