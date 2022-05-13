package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlCapadtlHistoryData extends SQLData {

	public static final String Docid = "DOCID";

	public static final String Docsequence = "DOCSEQUENCE";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Teamid = "TEAMID";

	public static final String Defecttype = "DEFECTTYPE";

	public static final String Reasonteamid = "REASONTEAMID";

	public static final String Reasontype = "REASONTYPE";

	public static final String Reasondesc = "REASONDESC";

	public static final String Actiondesc = "ACTIONDESC";

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

	public static final String Actiondate = "ACTIONDATE";

	public UlCapadtlHistoryData() {
		this(new UlCapadtlHistoryKey()); 
	}

	public UlCapadtlHistoryData(UlCapadtlHistoryKey key) {
		super(key, "UlCapadtlHistory");
	}


	public String getTeamid() {
		return this.repository().getString(UlCapadtlHistoryData.Teamid);
	}

	public UlCapadtlHistoryData setTeamid(String Teamid) {
		this.repository().set(UlCapadtlHistoryData.Teamid, Teamid);
		return this;
	}

	public String getDefecttype() {
		return this.repository().getString(UlCapadtlHistoryData.Defecttype);
	}

	public UlCapadtlHistoryData setDefecttype(String Defecttype) {
		this.repository().set(UlCapadtlHistoryData.Defecttype, Defecttype);
		return this;
	}

	public String getReasonteamid() {
		return this.repository().getString(UlCapadtlHistoryData.Reasonteamid);
	}

	public UlCapadtlHistoryData setReasonteamid(String Reasonteamid) {
		this.repository().set(UlCapadtlHistoryData.Reasonteamid, Reasonteamid);
		return this;
	}

	public String getReasontype() {
		return this.repository().getString(UlCapadtlHistoryData.Reasontype);
	}

	public UlCapadtlHistoryData setReasontype(String Reasontype) {
		this.repository().set(UlCapadtlHistoryData.Reasontype, Reasontype);
		return this;
	}

	public String getReasondesc() {
		return this.repository().getString(UlCapadtlHistoryData.Reasondesc);
	}

	public UlCapadtlHistoryData setReasondesc(String Reasondesc) {
		this.repository().set(UlCapadtlHistoryData.Reasondesc, Reasondesc);
		return this;
	}

	public String getActiondesc() {
		return this.repository().getString(UlCapadtlHistoryData.Actiondesc);
	}

	public UlCapadtlHistoryData setActiondesc(String Actiondesc) {
		this.repository().set(UlCapadtlHistoryData.Actiondesc, Actiondesc);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlCapadtlHistoryData.Description);
	}

	public UlCapadtlHistoryData setDescription(String Description) {
		this.repository().set(UlCapadtlHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlCapadtlHistoryData.Creator);
	}

	public UlCapadtlHistoryData setCreator(String Creator) {
		this.repository().set(UlCapadtlHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlCapadtlHistoryData.Createdtime);
	}

	public UlCapadtlHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(UlCapadtlHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlCapadtlHistoryData.Modifier);
	}

	public UlCapadtlHistoryData setModifier(String Modifier) {
		this.repository().set(UlCapadtlHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlCapadtlHistoryData.Modifiedtime);
	}

	public UlCapadtlHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlCapadtlHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlCapadtlHistoryData.Txnid);
	}

	public UlCapadtlHistoryData setTxnid(String Txnid) {
		this.repository().set(UlCapadtlHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlCapadtlHistoryData.Txnuser);
	}

	public UlCapadtlHistoryData setTxnuser(String Txnuser) {
		this.repository().set(UlCapadtlHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlCapadtlHistoryData.Txntime);
	}

	public UlCapadtlHistoryData setTxntime(Date Txntime) {
		this.repository().set(UlCapadtlHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlCapadtlHistoryData.Txngrouphistkey);
	}

	public UlCapadtlHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlCapadtlHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlCapadtlHistoryData.Txnreasoncodeclass);
	}

	public UlCapadtlHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlCapadtlHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlCapadtlHistoryData.Txnreasoncode);
	}

	public UlCapadtlHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlCapadtlHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlCapadtlHistoryData.Txncomment);
	}

	public UlCapadtlHistoryData setTxncomment(String Txncomment) {
		this.repository().set(UlCapadtlHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlCapadtlHistoryData.Validstate);
	}

	public UlCapadtlHistoryData setValidstate(String Validstate) {
		this.repository().set(UlCapadtlHistoryData.Validstate, Validstate);
		return this;
	}

	public Date getActiondate() {
		return this.repository().getDate(UlCapadtlHistoryData.Actiondate);
	}

	public UlCapadtlHistoryData setActiondate(Date Actiondate) {
		this.repository().set(UlCapadtlHistoryData.Actiondate, Actiondate);
		return this;
	}


}