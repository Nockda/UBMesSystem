package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtInterfacedefinitionData extends SQLData {

	public static final String Interfaceid = "INTERFACEID";

	public static final String Interfacename = "INTERFACENAME";

	public static final String Interfacetype = "INTERFACETYPE";

	public static final String Sourcetablename = "SOURCETABLENAME";

	public static final String Targettablename = "TARGETTABLENAME";

	public static final String Procedurename = "PROCEDURENAME";

	public static final String Executioncycle = "EXECUTIONCYCLE";

	public static final String Serverip = "SERVERIP";

	public static final String Linkname = "LINKNAME";

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

	public CtInterfacedefinitionData() {
		this(new CtInterfacedefinitionKey()); 
	}

	public CtInterfacedefinitionData(CtInterfacedefinitionKey key) {
		super(key, "CtInterfacedefinition");
	}


	public String getInterfacename() {
		return this.repository().getString(CtInterfacedefinitionData.Interfacename);
	}

	public CtInterfacedefinitionData setInterfacename(String Interfacename) {
		this.repository().set(CtInterfacedefinitionData.Interfacename, Interfacename);
		return this;
	}

	public String getInterfacetype() {
		return this.repository().getString(CtInterfacedefinitionData.Interfacetype);
	}

	public CtInterfacedefinitionData setInterfacetype(String Interfacetype) {
		this.repository().set(CtInterfacedefinitionData.Interfacetype, Interfacetype);
		return this;
	}

	public String getSourcetablename() {
		return this.repository().getString(CtInterfacedefinitionData.Sourcetablename);
	}

	public CtInterfacedefinitionData setSourcetablename(String Sourcetablename) {
		this.repository().set(CtInterfacedefinitionData.Sourcetablename, Sourcetablename);
		return this;
	}

	public String getTargettablename() {
		return this.repository().getString(CtInterfacedefinitionData.Targettablename);
	}

	public CtInterfacedefinitionData setTargettablename(String Targettablename) {
		this.repository().set(CtInterfacedefinitionData.Targettablename, Targettablename);
		return this;
	}

	public String getProcedurename() {
		return this.repository().getString(CtInterfacedefinitionData.Procedurename);
	}

	public CtInterfacedefinitionData setProcedurename(String Procedurename) {
		this.repository().set(CtInterfacedefinitionData.Procedurename, Procedurename);
		return this;
	}

	public String getExecutioncycle() {
		return this.repository().getString(CtInterfacedefinitionData.Executioncycle);
	}

	public CtInterfacedefinitionData setExecutioncycle(String Executioncycle) {
		this.repository().set(CtInterfacedefinitionData.Executioncycle, Executioncycle);
		return this;
	}

	public String getServerip() {
		return this.repository().getString(CtInterfacedefinitionData.Serverip);
	}

	public CtInterfacedefinitionData setServerip(String Serverip) {
		this.repository().set(CtInterfacedefinitionData.Serverip, Serverip);
		return this;
	}

	public String getLinkname() {
		return this.repository().getString(CtInterfacedefinitionData.Linkname);
	}

	public CtInterfacedefinitionData setLinkname(String Linkname) {
		this.repository().set(CtInterfacedefinitionData.Linkname, Linkname);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtInterfacedefinitionData.Description);
	}

	public CtInterfacedefinitionData setDescription(String Description) {
		this.repository().set(CtInterfacedefinitionData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtInterfacedefinitionData.Creator);
	}

	public CtInterfacedefinitionData setCreator(String Creator) {
		this.repository().set(CtInterfacedefinitionData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtInterfacedefinitionData.Createdtime);
	}

	public CtInterfacedefinitionData setCreatedtime(Date Createdtime) {
		this.repository().set(CtInterfacedefinitionData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtInterfacedefinitionData.Modifier);
	}

	public CtInterfacedefinitionData setModifier(String Modifier) {
		this.repository().set(CtInterfacedefinitionData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtInterfacedefinitionData.Modifiedtime);
	}

	public CtInterfacedefinitionData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtInterfacedefinitionData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtInterfacedefinitionData.Lasttxnhistkey);
	}

	public CtInterfacedefinitionData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtInterfacedefinitionData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtInterfacedefinitionData.Lasttxnid);
	}

	public CtInterfacedefinitionData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtInterfacedefinitionData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtInterfacedefinitionData.Lasttxnuser);
	}

	public CtInterfacedefinitionData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtInterfacedefinitionData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtInterfacedefinitionData.Lasttxntime);
	}

	public CtInterfacedefinitionData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtInterfacedefinitionData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtInterfacedefinitionData.Lasttxncomment);
	}

	public CtInterfacedefinitionData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtInterfacedefinitionData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtInterfacedefinitionData.Validstate);
	}

	public CtInterfacedefinitionData setValidstate(String Validstate) {
		this.repository().set(CtInterfacedefinitionData.Validstate, Validstate);
		return this;
	}


}