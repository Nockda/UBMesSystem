package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlCapadtlData extends SQLData {

	public static final String Docid = "DOCID";

	public static final String Docsequence = "DOCSEQUENCE";

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

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Lasttxnid = "LASTTXNID";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public static final String Actiondate = "ACTIONDATE";

	public UlCapadtlData() {
		this(new UlCapadtlKey()); 
	}

	public UlCapadtlData(UlCapadtlKey key) {
		super(key, "UlCapadtl");
	}


	public String getTeamid() {
		return this.repository().getString(UlCapadtlData.Teamid);
	}

	public UlCapadtlData setTeamid(String Teamid) {
		this.repository().set(UlCapadtlData.Teamid, Teamid);
		return this;
	}

	public String getDefecttype() {
		return this.repository().getString(UlCapadtlData.Defecttype);
	}

	public UlCapadtlData setDefecttype(String Defecttype) {
		this.repository().set(UlCapadtlData.Defecttype, Defecttype);
		return this;
	}

	public String getReasonteamid() {
		return this.repository().getString(UlCapadtlData.Reasonteamid);
	}

	public UlCapadtlData setReasonteamid(String Reasonteamid) {
		this.repository().set(UlCapadtlData.Reasonteamid, Reasonteamid);
		return this;
	}

	public String getReasontype() {
		return this.repository().getString(UlCapadtlData.Reasontype);
	}

	public UlCapadtlData setReasontype(String Reasontype) {
		this.repository().set(UlCapadtlData.Reasontype, Reasontype);
		return this;
	}

	public String getReasondesc() {
		return this.repository().getString(UlCapadtlData.Reasondesc);
	}

	public UlCapadtlData setReasondesc(String Reasondesc) {
		this.repository().set(UlCapadtlData.Reasondesc, Reasondesc);
		return this;
	}

	public String getActiondesc() {
		return this.repository().getString(UlCapadtlData.Actiondesc);
	}

	public UlCapadtlData setActiondesc(String Actiondesc) {
		this.repository().set(UlCapadtlData.Actiondesc, Actiondesc);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlCapadtlData.Description);
	}

	public UlCapadtlData setDescription(String Description) {
		this.repository().set(UlCapadtlData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlCapadtlData.Creator);
	}

	public UlCapadtlData setCreator(String Creator) {
		this.repository().set(UlCapadtlData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlCapadtlData.Createdtime);
	}

	public UlCapadtlData setCreatedtime(Date Createdtime) {
		this.repository().set(UlCapadtlData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlCapadtlData.Modifier);
	}

	public UlCapadtlData setModifier(String Modifier) {
		this.repository().set(UlCapadtlData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlCapadtlData.Modifiedtime);
	}

	public UlCapadtlData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlCapadtlData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(UlCapadtlData.Lasttxnhistkey);
	}

	public UlCapadtlData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(UlCapadtlData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(UlCapadtlData.Lasttxnid);
	}

	public UlCapadtlData setLasttxnid(String Lasttxnid) {
		this.repository().set(UlCapadtlData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(UlCapadtlData.Lasttxnuser);
	}

	public UlCapadtlData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(UlCapadtlData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(UlCapadtlData.Lasttxntime);
	}

	public UlCapadtlData setLasttxntime(Date Lasttxntime) {
		this.repository().set(UlCapadtlData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(UlCapadtlData.Lasttxncomment);
	}

	public UlCapadtlData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(UlCapadtlData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlCapadtlData.Validstate);
	}

	public UlCapadtlData setValidstate(String Validstate) {
		this.repository().set(UlCapadtlData.Validstate, Validstate);
		return this;
	}

	public Date getActiondate() {
		return this.repository().getDate(UlCapadtlData.Actiondate);
	}

	public UlCapadtlData setActiondate(Date Actiondate) {
		this.repository().set(UlCapadtlData.Actiondate, Actiondate);
		return this;
	}


}