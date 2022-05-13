package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtProcesssegmentmodelData extends SQLData {

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Processsegmentversion = "PROCESSSEGMENTVERSION";

	public static final String Modelid = "MODELID";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

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

	public static final String Versionstate = "VERSIONSTATE";

	public static final String Validstate = "VALIDSTATE";

	public CtProcesssegmentmodelData() {
		this(new CtProcesssegmentmodelKey()); 
	}

	public CtProcesssegmentmodelData(CtProcesssegmentmodelKey key) {
		super(key, "CtProcesssegmentmodel");
	}


	public String getEnterpriseid() {
		return this.repository().getString(CtProcesssegmentmodelData.Enterpriseid);
	}

	public CtProcesssegmentmodelData setEnterpriseid(String Enterpriseid) {
		this.repository().set(CtProcesssegmentmodelData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(CtProcesssegmentmodelData.Plantid);
	}

	public CtProcesssegmentmodelData setPlantid(String Plantid) {
		this.repository().set(CtProcesssegmentmodelData.Plantid, Plantid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtProcesssegmentmodelData.Description);
	}

	public CtProcesssegmentmodelData setDescription(String Description) {
		this.repository().set(CtProcesssegmentmodelData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtProcesssegmentmodelData.Creator);
	}

	public CtProcesssegmentmodelData setCreator(String Creator) {
		this.repository().set(CtProcesssegmentmodelData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtProcesssegmentmodelData.Createdtime);
	}

	public CtProcesssegmentmodelData setCreatedtime(Date Createdtime) {
		this.repository().set(CtProcesssegmentmodelData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtProcesssegmentmodelData.Modifier);
	}

	public CtProcesssegmentmodelData setModifier(String Modifier) {
		this.repository().set(CtProcesssegmentmodelData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtProcesssegmentmodelData.Modifiedtime);
	}

	public CtProcesssegmentmodelData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtProcesssegmentmodelData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtProcesssegmentmodelData.Lasttxnhistkey);
	}

	public CtProcesssegmentmodelData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtProcesssegmentmodelData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtProcesssegmentmodelData.Lasttxnid);
	}

	public CtProcesssegmentmodelData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtProcesssegmentmodelData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtProcesssegmentmodelData.Lasttxnuser);
	}

	public CtProcesssegmentmodelData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtProcesssegmentmodelData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtProcesssegmentmodelData.Lasttxntime);
	}

	public CtProcesssegmentmodelData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtProcesssegmentmodelData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtProcesssegmentmodelData.Lasttxncomment);
	}

	public CtProcesssegmentmodelData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtProcesssegmentmodelData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getVersionstate() {
		return this.repository().getString(CtProcesssegmentmodelData.Versionstate);
	}

	public CtProcesssegmentmodelData setVersionstate(String Versionstate) {
		this.repository().set(CtProcesssegmentmodelData.Versionstate, Versionstate);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtProcesssegmentmodelData.Validstate);
	}

	public CtProcesssegmentmodelData setValidstate(String Validstate) {
		this.repository().set(CtProcesssegmentmodelData.Validstate, Validstate);
		return this;
	}


}