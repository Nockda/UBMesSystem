package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtSubprocessworkerHistoryData extends SQLData {

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Subprocesssegmentid = "SUBPROCESSSEGMENTID";

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

	public CtSubprocessworkerHistoryData() {
		this(new CtSubprocessworkerHistoryKey()); 
	}

	public CtSubprocessworkerHistoryData(CtSubprocessworkerHistoryKey key) {
		super(key, "CtSubprocessworkerHistory");
	}


	public String getDescription() {
		return this.repository().getString(CtSubprocessworkerHistoryData.Description);
	}

	public CtSubprocessworkerHistoryData setDescription(String Description) {
		this.repository().set(CtSubprocessworkerHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtSubprocessworkerHistoryData.Creator);
	}

	public CtSubprocessworkerHistoryData setCreator(String Creator) {
		this.repository().set(CtSubprocessworkerHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtSubprocessworkerHistoryData.Createdtime);
	}

	public CtSubprocessworkerHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtSubprocessworkerHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtSubprocessworkerHistoryData.Modifier);
	}

	public CtSubprocessworkerHistoryData setModifier(String Modifier) {
		this.repository().set(CtSubprocessworkerHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtSubprocessworkerHistoryData.Modifiedtime);
	}

	public CtSubprocessworkerHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtSubprocessworkerHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtSubprocessworkerHistoryData.Txnid);
	}

	public CtSubprocessworkerHistoryData setTxnid(String Txnid) {
		this.repository().set(CtSubprocessworkerHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtSubprocessworkerHistoryData.Txnuser);
	}

	public CtSubprocessworkerHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtSubprocessworkerHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtSubprocessworkerHistoryData.Txntime);
	}

	public CtSubprocessworkerHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtSubprocessworkerHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtSubprocessworkerHistoryData.Txngrouphistkey);
	}

	public CtSubprocessworkerHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtSubprocessworkerHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtSubprocessworkerHistoryData.Txnreasoncodeclass);
	}

	public CtSubprocessworkerHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtSubprocessworkerHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtSubprocessworkerHistoryData.Txnreasoncode);
	}

	public CtSubprocessworkerHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtSubprocessworkerHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtSubprocessworkerHistoryData.Txncomment);
	}

	public CtSubprocessworkerHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtSubprocessworkerHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtSubprocessworkerHistoryData.Validstate);
	}

	public CtSubprocessworkerHistoryData setValidstate(String Validstate) {
		this.repository().set(CtSubprocessworkerHistoryData.Validstate, Validstate);
		return this;
	}


}