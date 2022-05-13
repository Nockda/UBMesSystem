package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtSubprocessworkerData extends SQLData {

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Subprocesssegmentid = "SUBPROCESSSEGMENTID";

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

	public CtSubprocessworkerData() {
		this(new CtSubprocessworkerKey()); 
	}

	public CtSubprocessworkerData(CtSubprocessworkerKey key) {
		super(key, "CtSubprocessworker");
	}


	public String getDescription() {
		return this.repository().getString(CtSubprocessworkerData.Description);
	}

	public CtSubprocessworkerData setDescription(String Description) {
		this.repository().set(CtSubprocessworkerData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtSubprocessworkerData.Creator);
	}

	public CtSubprocessworkerData setCreator(String Creator) {
		this.repository().set(CtSubprocessworkerData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtSubprocessworkerData.Createdtime);
	}

	public CtSubprocessworkerData setCreatedtime(Date Createdtime) {
		this.repository().set(CtSubprocessworkerData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtSubprocessworkerData.Modifier);
	}

	public CtSubprocessworkerData setModifier(String Modifier) {
		this.repository().set(CtSubprocessworkerData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtSubprocessworkerData.Modifiedtime);
	}

	public CtSubprocessworkerData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtSubprocessworkerData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtSubprocessworkerData.Lasttxnhistkey);
	}

	public CtSubprocessworkerData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtSubprocessworkerData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtSubprocessworkerData.Lasttxnid);
	}

	public CtSubprocessworkerData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtSubprocessworkerData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtSubprocessworkerData.Lasttxnuser);
	}

	public CtSubprocessworkerData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtSubprocessworkerData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtSubprocessworkerData.Lasttxntime);
	}

	public CtSubprocessworkerData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtSubprocessworkerData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtSubprocessworkerData.Lasttxncomment);
	}

	public CtSubprocessworkerData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtSubprocessworkerData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtSubprocessworkerData.Validstate);
	}

	public CtSubprocessworkerData setValidstate(String Validstate) {
		this.repository().set(CtSubprocessworkerData.Validstate, Validstate);
		return this;
	}


}