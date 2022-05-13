package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtSpecdefinitionData extends SQLData {

	public static final String Specdefid = "SPECDEFID";

	public static final String Specdefname = "SPECDEFNAME";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Processsegmentid = "PROCESSSEGMENTID";

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

	public static final String Isdivide = "ISDIVIDE";

	public CtSpecdefinitionData() {
		this(new CtSpecdefinitionKey()); 
	}

	public CtSpecdefinitionData(CtSpecdefinitionKey key) {
		super(key, "CtSpecdefinition");
	}


	public String getSpecdefname() {
		return this.repository().getString(CtSpecdefinitionData.Specdefname);
	}

	public CtSpecdefinitionData setSpecdefname(String Specdefname) {
		this.repository().set(CtSpecdefinitionData.Specdefname, Specdefname);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(CtSpecdefinitionData.Enterpriseid);
	}

	public CtSpecdefinitionData setEnterpriseid(String Enterpriseid) {
		this.repository().set(CtSpecdefinitionData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(CtSpecdefinitionData.Plantid);
	}

	public CtSpecdefinitionData setPlantid(String Plantid) {
		this.repository().set(CtSpecdefinitionData.Plantid, Plantid);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(CtSpecdefinitionData.Processsegmentid);
	}

	public CtSpecdefinitionData setProcesssegmentid(String Processsegmentid) {
		this.repository().set(CtSpecdefinitionData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(CtSpecdefinitionData.Dictionaryid);
	}

	public CtSpecdefinitionData setDictionaryid(String Dictionaryid) {
		this.repository().set(CtSpecdefinitionData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtSpecdefinitionData.Description);
	}

	public CtSpecdefinitionData setDescription(String Description) {
		this.repository().set(CtSpecdefinitionData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtSpecdefinitionData.Creator);
	}

	public CtSpecdefinitionData setCreator(String Creator) {
		this.repository().set(CtSpecdefinitionData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtSpecdefinitionData.Createdtime);
	}

	public CtSpecdefinitionData setCreatedtime(Date Createdtime) {
		this.repository().set(CtSpecdefinitionData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtSpecdefinitionData.Modifier);
	}

	public CtSpecdefinitionData setModifier(String Modifier) {
		this.repository().set(CtSpecdefinitionData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtSpecdefinitionData.Modifiedtime);
	}

	public CtSpecdefinitionData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtSpecdefinitionData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtSpecdefinitionData.Lasttxnhistkey);
	}

	public CtSpecdefinitionData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtSpecdefinitionData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtSpecdefinitionData.Lasttxnid);
	}

	public CtSpecdefinitionData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtSpecdefinitionData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtSpecdefinitionData.Lasttxnuser);
	}

	public CtSpecdefinitionData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtSpecdefinitionData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtSpecdefinitionData.Lasttxntime);
	}

	public CtSpecdefinitionData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtSpecdefinitionData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtSpecdefinitionData.Lasttxncomment);
	}

	public CtSpecdefinitionData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtSpecdefinitionData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtSpecdefinitionData.Validstate);
	}

	public CtSpecdefinitionData setValidstate(String Validstate) {
		this.repository().set(CtSpecdefinitionData.Validstate, Validstate);
		return this;
	}

	public String getIsdivide() {
		return this.repository().getString(CtSpecdefinitionData.Isdivide);
	}

	public CtSpecdefinitionData setIsdivide(String Isdivide) {
		this.repository().set(CtSpecdefinitionData.Isdivide, Isdivide);
		return this;
	}


}