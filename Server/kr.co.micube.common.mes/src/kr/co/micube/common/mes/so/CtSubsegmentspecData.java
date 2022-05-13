package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtSubsegmentspecData extends SQLData {

	public static final String Specdefid = "SPECDEFID";

	public static final String Subprocesssegmentid = "SUBPROCESSSEGMENTID";

	public static final String Specsequence = "SPECSEQUENCE";

	public static final String Usersequence = "USERSEQUENCE";

	public static final String Isresult = "ISRESULT";

	public static final String Isoutsourcing = "ISOUTSOURCING";

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

	public static final String Ismeasure = "ISMEASURE";

	public static final String Specdefidversion = "SPECDEFIDVERSION";

	public CtSubsegmentspecData() {
		this(new CtSubsegmentspecKey()); 
	}

	public CtSubsegmentspecData(CtSubsegmentspecKey key) {
		super(key, "CtSubsegmentspec");
	}


	public String getUsersequence() {
		return this.repository().getString(CtSubsegmentspecData.Usersequence);
	}

	public CtSubsegmentspecData setUsersequence(String Usersequence) {
		this.repository().set(CtSubsegmentspecData.Usersequence, Usersequence);
		return this;
	}

	public String getIsresult() {
		return this.repository().getString(CtSubsegmentspecData.Isresult);
	}

	public CtSubsegmentspecData setIsresult(String Isresult) {
		this.repository().set(CtSubsegmentspecData.Isresult, Isresult);
		return this;
	}

	public String getIsoutsourcing() {
		return this.repository().getString(CtSubsegmentspecData.Isoutsourcing);
	}

	public CtSubsegmentspecData setIsoutsourcing(String Isoutsourcing) {
		this.repository().set(CtSubsegmentspecData.Isoutsourcing, Isoutsourcing);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtSubsegmentspecData.Description);
	}

	public CtSubsegmentspecData setDescription(String Description) {
		this.repository().set(CtSubsegmentspecData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtSubsegmentspecData.Creator);
	}

	public CtSubsegmentspecData setCreator(String Creator) {
		this.repository().set(CtSubsegmentspecData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtSubsegmentspecData.Createdtime);
	}

	public CtSubsegmentspecData setCreatedtime(Date Createdtime) {
		this.repository().set(CtSubsegmentspecData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtSubsegmentspecData.Modifier);
	}

	public CtSubsegmentspecData setModifier(String Modifier) {
		this.repository().set(CtSubsegmentspecData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtSubsegmentspecData.Modifiedtime);
	}

	public CtSubsegmentspecData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtSubsegmentspecData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtSubsegmentspecData.Lasttxnhistkey);
	}

	public CtSubsegmentspecData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtSubsegmentspecData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtSubsegmentspecData.Lasttxnid);
	}

	public CtSubsegmentspecData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtSubsegmentspecData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtSubsegmentspecData.Lasttxnuser);
	}

	public CtSubsegmentspecData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtSubsegmentspecData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtSubsegmentspecData.Lasttxntime);
	}

	public CtSubsegmentspecData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtSubsegmentspecData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtSubsegmentspecData.Lasttxncomment);
	}

	public CtSubsegmentspecData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtSubsegmentspecData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtSubsegmentspecData.Validstate);
	}

	public CtSubsegmentspecData setValidstate(String Validstate) {
		this.repository().set(CtSubsegmentspecData.Validstate, Validstate);
		return this;
	}

	public String getIsmeasure() {
		return this.repository().getString(CtSubsegmentspecData.Ismeasure);
	}

	public CtSubsegmentspecData setIsmeasure(String Ismeasure) {
		this.repository().set(CtSubsegmentspecData.Ismeasure, Ismeasure);
		return this;
	}


}