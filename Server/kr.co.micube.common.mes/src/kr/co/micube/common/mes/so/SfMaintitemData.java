package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfMaintitemData extends SQLData {

	public static final String Maintitemid = "MAINTITEMID";

	public static final String Maintitemname = "MAINTITEMNAME";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Maintitemclassid = "MAINTITEMCLASSID";

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

	public SfMaintitemData() {
		this(new SfMaintitemKey()); 
	}

	public SfMaintitemData(SfMaintitemKey key) {
		super(key, "SfMaintitem");
	}


	public String getMaintitemname() {
		return this.repository().getString(SfMaintitemData.Maintitemname);
	}

	public SfMaintitemData setMaintitemname(String Maintitemname) {
		this.repository().set(SfMaintitemData.Maintitemname, Maintitemname);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfMaintitemData.Enterpriseid);
	}

	public SfMaintitemData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfMaintitemData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfMaintitemData.Plantid);
	}

	public SfMaintitemData setPlantid(String Plantid) {
		this.repository().set(SfMaintitemData.Plantid, Plantid);
		return this;
	}

	public String getMaintitemclassid() {
		return this.repository().getString(SfMaintitemData.Maintitemclassid);
	}

	public SfMaintitemData setMaintitemclassid(String Maintitemclassid) {
		this.repository().set(SfMaintitemData.Maintitemclassid, Maintitemclassid);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfMaintitemData.Dictionaryid);
	}

	public SfMaintitemData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfMaintitemData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfMaintitemData.Description);
	}

	public SfMaintitemData setDescription(String Description) {
		this.repository().set(SfMaintitemData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfMaintitemData.Creator);
	}

	public SfMaintitemData setCreator(String Creator) {
		this.repository().set(SfMaintitemData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfMaintitemData.Createdtime);
	}

	public SfMaintitemData setCreatedtime(Date Createdtime) {
		this.repository().set(SfMaintitemData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfMaintitemData.Modifier);
	}

	public SfMaintitemData setModifier(String Modifier) {
		this.repository().set(SfMaintitemData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfMaintitemData.Modifiedtime);
	}

	public SfMaintitemData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfMaintitemData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfMaintitemData.Lasttxnhistkey);
	}

	public SfMaintitemData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfMaintitemData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfMaintitemData.Lasttxnid);
	}

	public SfMaintitemData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfMaintitemData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfMaintitemData.Lasttxnuser);
	}

	public SfMaintitemData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfMaintitemData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfMaintitemData.Lasttxntime);
	}

	public SfMaintitemData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfMaintitemData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfMaintitemData.Lasttxncomment);
	}

	public SfMaintitemData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfMaintitemData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfMaintitemData.Validstate);
	}

	public SfMaintitemData setValidstate(String Validstate) {
		this.repository().set(SfMaintitemData.Validstate, Validstate);
		return this;
	}


}