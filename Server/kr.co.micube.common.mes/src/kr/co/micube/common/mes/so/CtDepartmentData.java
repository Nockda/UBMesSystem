package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtDepartmentData extends SQLData {

	public static final String Departmentid = "DEPARTMENTID";

	public static final String Departmentname = "DEPARTMENTNAME";

	public static final String Dictionaryid = "DICTIONARYID";

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

	public CtDepartmentData() {
		this(new CtDepartmentKey()); 
	}

	public CtDepartmentData(CtDepartmentKey key) {
		super(key, "CtDepartment");
	}


	public String getDepartmentname() {
		return this.repository().getString(CtDepartmentData.Departmentname);
	}

	public CtDepartmentData setDepartmentname(String Departmentname) {
		this.repository().set(CtDepartmentData.Departmentname, Departmentname);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(CtDepartmentData.Dictionaryid);
	}

	public CtDepartmentData setDictionaryid(String Dictionaryid) {
		this.repository().set(CtDepartmentData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtDepartmentData.Description);
	}

	public CtDepartmentData setDescription(String Description) {
		this.repository().set(CtDepartmentData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtDepartmentData.Creator);
	}

	public CtDepartmentData setCreator(String Creator) {
		this.repository().set(CtDepartmentData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtDepartmentData.Createdtime);
	}

	public CtDepartmentData setCreatedtime(Date Createdtime) {
		this.repository().set(CtDepartmentData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtDepartmentData.Modifier);
	}

	public CtDepartmentData setModifier(String Modifier) {
		this.repository().set(CtDepartmentData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtDepartmentData.Modifiedtime);
	}

	public CtDepartmentData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtDepartmentData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtDepartmentData.Lasttxnhistkey);
	}

	public CtDepartmentData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtDepartmentData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtDepartmentData.Lasttxnid);
	}

	public CtDepartmentData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtDepartmentData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtDepartmentData.Lasttxnuser);
	}

	public CtDepartmentData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtDepartmentData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtDepartmentData.Lasttxntime);
	}

	public CtDepartmentData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtDepartmentData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtDepartmentData.Lasttxncomment);
	}

	public CtDepartmentData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtDepartmentData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtDepartmentData.Validstate);
	}

	public CtDepartmentData setValidstate(String Validstate) {
		this.repository().set(CtDepartmentData.Validstate, Validstate);
		return this;
	}


}