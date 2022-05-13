package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtAreaworkerData extends SQLData {

	public static final String Areaid = "AREAID";

	public static final String Userid = "USERID";

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

	public CtAreaworkerData() {
		this(new CtAreaworkerKey()); 
	}

	public CtAreaworkerData(CtAreaworkerKey key) {
		super(key, "CtAreaworker");
	}


	public String getDescription() {
		return this.repository().getString(CtAreaworkerData.Description);
	}

	public CtAreaworkerData setDescription(String Description) {
		this.repository().set(CtAreaworkerData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtAreaworkerData.Creator);
	}

	public CtAreaworkerData setCreator(String Creator) {
		this.repository().set(CtAreaworkerData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtAreaworkerData.Createdtime);
	}

	public CtAreaworkerData setCreatedtime(Date Createdtime) {
		this.repository().set(CtAreaworkerData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtAreaworkerData.Modifier);
	}

	public CtAreaworkerData setModifier(String Modifier) {
		this.repository().set(CtAreaworkerData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtAreaworkerData.Modifiedtime);
	}

	public CtAreaworkerData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtAreaworkerData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtAreaworkerData.Lasttxnhistkey);
	}

	public CtAreaworkerData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtAreaworkerData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtAreaworkerData.Lasttxnid);
	}

	public CtAreaworkerData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtAreaworkerData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtAreaworkerData.Lasttxnuser);
	}

	public CtAreaworkerData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtAreaworkerData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtAreaworkerData.Lasttxntime);
	}

	public CtAreaworkerData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtAreaworkerData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtAreaworkerData.Lasttxncomment);
	}

	public CtAreaworkerData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtAreaworkerData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtAreaworkerData.Validstate);
	}

	public CtAreaworkerData setValidstate(String Validstate) {
		this.repository().set(CtAreaworkerData.Validstate, Validstate);
		return this;
	}


}