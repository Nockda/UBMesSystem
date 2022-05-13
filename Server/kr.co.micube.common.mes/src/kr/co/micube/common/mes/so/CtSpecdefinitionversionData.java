package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtSpecdefinitionversionData extends SQLData {

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Reasonforchange = "REASONFORCHANGE";

	public static final String Specdefid = "SPECDEFID";

	public static final String Validstate = "VALIDSTATE";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Specdefidversion = "SPECDEFIDVERSION";

	public static final String Creator = "CREATOR";

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Modifier = "MODIFIER";

	public static final String Lasttxnid = "LASTTXNID";

	public CtSpecdefinitionversionData() {
		this(new CtSpecdefinitionversionKey()); 
	}

	public CtSpecdefinitionversionData(CtSpecdefinitionversionKey key) {
		super(key, "CtSpecdefinitionversion");
	}


	public String getLasttxncomment() {
		return this.repository().getString(CtSpecdefinitionversionData.Lasttxncomment);
	}

	public CtSpecdefinitionversionData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtSpecdefinitionversionData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtSpecdefinitionversionData.Lasttxnuser);
	}

	public CtSpecdefinitionversionData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtSpecdefinitionversionData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public String getReasonforchange() {
		return this.repository().getString(CtSpecdefinitionversionData.Reasonforchange);
	}

	public CtSpecdefinitionversionData setReasonforchange(String Reasonforchange) {
		this.repository().set(CtSpecdefinitionversionData.Reasonforchange, Reasonforchange);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtSpecdefinitionversionData.Validstate);
	}

	public CtSpecdefinitionversionData setValidstate(String Validstate) {
		this.repository().set(CtSpecdefinitionversionData.Validstate, Validstate);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtSpecdefinitionversionData.Createdtime);
	}

	public CtSpecdefinitionversionData setCreatedtime(Date Createdtime) {
		this.repository().set(CtSpecdefinitionversionData.Createdtime, Createdtime);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtSpecdefinitionversionData.Lasttxntime);
	}

	public CtSpecdefinitionversionData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtSpecdefinitionversionData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtSpecdefinitionversionData.Creator);
	}

	public CtSpecdefinitionversionData setCreator(String Creator) {
		this.repository().set(CtSpecdefinitionversionData.Creator, Creator);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtSpecdefinitionversionData.Lasttxnhistkey);
	}

	public CtSpecdefinitionversionData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtSpecdefinitionversionData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtSpecdefinitionversionData.Modifiedtime);
	}

	public CtSpecdefinitionversionData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtSpecdefinitionversionData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtSpecdefinitionversionData.Modifier);
	}

	public CtSpecdefinitionversionData setModifier(String Modifier) {
		this.repository().set(CtSpecdefinitionversionData.Modifier, Modifier);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtSpecdefinitionversionData.Lasttxnid);
	}

	public CtSpecdefinitionversionData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtSpecdefinitionversionData.Lasttxnid, Lasttxnid);
		return this;
	}


}