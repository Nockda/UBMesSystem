package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfProcesssegmentData extends SQLData {

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Processsegmentversion = "PROCESSSEGMENTVERSION";

	public static final String Processsegmentclassid = "PROCESSSEGMENTCLASSID";

	public static final String Processsegmentname = "PROCESSSEGMENTNAME";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Areaid = "AREAID";

	public static final String Processsegmenttype = "PROCESSSEGMENTTYPE";

	public static final String Checkresult = "CHECKRESULT";

	public static final String Equipmentclassid = "EQUIPMENTCLASSID";

	public static final String Istrackinrequired = "ISTRACKINREQUIRED";

	public static final String Leadtime = "LEADTIME";

	public static final String Dictionaryid = "DICTIONARYID";

	public static final String Isuseuserlotserial = "ISUSEUSERLOTSERIAL";

	public static final String Lotcreateruleid = "LOTCREATERULEID";

	public static final String Ismainprocesssegment = "ISMAINPROCESSSEGMENT";

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

	public SfProcesssegmentData() {
		this(new SfProcesssegmentKey()); 
	}

	public SfProcesssegmentData(SfProcesssegmentKey key) {
		super(key, "SfProcesssegment");
	}


	public String getProcesssegmentclassid() {
		return this.repository().getString(SfProcesssegmentData.Processsegmentclassid);
	}

	public SfProcesssegmentData setProcesssegmentclassid(String Processsegmentclassid) {
		this.repository().set(SfProcesssegmentData.Processsegmentclassid, Processsegmentclassid);
		return this;
	}

	public String getProcesssegmentname() {
		return this.repository().getString(SfProcesssegmentData.Processsegmentname);
	}

	public SfProcesssegmentData setProcesssegmentname(String Processsegmentname) {
		this.repository().set(SfProcesssegmentData.Processsegmentname, Processsegmentname);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfProcesssegmentData.Enterpriseid);
	}

	public SfProcesssegmentData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfProcesssegmentData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfProcesssegmentData.Plantid);
	}

	public SfProcesssegmentData setPlantid(String Plantid) {
		this.repository().set(SfProcesssegmentData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfProcesssegmentData.Areaid);
	}

	public SfProcesssegmentData setAreaid(String Areaid) {
		this.repository().set(SfProcesssegmentData.Areaid, Areaid);
		return this;
	}

	public String getProcesssegmenttype() {
		return this.repository().getString(SfProcesssegmentData.Processsegmenttype);
	}

	public SfProcesssegmentData setProcesssegmenttype(String Processsegmenttype) {
		this.repository().set(SfProcesssegmentData.Processsegmenttype, Processsegmenttype);
		return this;
	}

	public String getCheckresult() {
		return this.repository().getString(SfProcesssegmentData.Checkresult);
	}

	public SfProcesssegmentData setCheckresult(String Checkresult) {
		this.repository().set(SfProcesssegmentData.Checkresult, Checkresult);
		return this;
	}

	public String getEquipmentclassid() {
		return this.repository().getString(SfProcesssegmentData.Equipmentclassid);
	}

	public SfProcesssegmentData setEquipmentclassid(String Equipmentclassid) {
		this.repository().set(SfProcesssegmentData.Equipmentclassid, Equipmentclassid);
		return this;
	}

	public String getIstrackinrequired() {
		return this.repository().getString(SfProcesssegmentData.Istrackinrequired);
	}

	public SfProcesssegmentData setIstrackinrequired(String Istrackinrequired) {
		this.repository().set(SfProcesssegmentData.Istrackinrequired, Istrackinrequired);
		return this;
	}

	public Double getLeadtime() {
		return this.repository().getDouble(SfProcesssegmentData.Leadtime);
	}

	public SfProcesssegmentData setLeadtime(Double Leadtime) {
		this.repository().set(SfProcesssegmentData.Leadtime, Leadtime);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfProcesssegmentData.Dictionaryid);
	}

	public SfProcesssegmentData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfProcesssegmentData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getIsuseuserlotserial() {
		return this.repository().getString(SfProcesssegmentData.Isuseuserlotserial);
	}

	public SfProcesssegmentData setIsuseuserlotserial(String Isuseuserlotserial) {
		this.repository().set(SfProcesssegmentData.Isuseuserlotserial, Isuseuserlotserial);
		return this;
	}

	public String getLotcreateruleid() {
		return this.repository().getString(SfProcesssegmentData.Lotcreateruleid);
	}

	public SfProcesssegmentData setLotcreateruleid(String Lotcreateruleid) {
		this.repository().set(SfProcesssegmentData.Lotcreateruleid, Lotcreateruleid);
		return this;
	}

	public String getIsmainprocesssegment() {
		return this.repository().getString(SfProcesssegmentData.Ismainprocesssegment);
	}

	public SfProcesssegmentData setIsmainprocesssegment(String Ismainprocesssegment) {
		this.repository().set(SfProcesssegmentData.Ismainprocesssegment, Ismainprocesssegment);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfProcesssegmentData.Description);
	}

	public SfProcesssegmentData setDescription(String Description) {
		this.repository().set(SfProcesssegmentData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfProcesssegmentData.Creator);
	}

	public SfProcesssegmentData setCreator(String Creator) {
		this.repository().set(SfProcesssegmentData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfProcesssegmentData.Createdtime);
	}

	public SfProcesssegmentData setCreatedtime(Date Createdtime) {
		this.repository().set(SfProcesssegmentData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfProcesssegmentData.Modifier);
	}

	public SfProcesssegmentData setModifier(String Modifier) {
		this.repository().set(SfProcesssegmentData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfProcesssegmentData.Modifiedtime);
	}

	public SfProcesssegmentData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfProcesssegmentData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfProcesssegmentData.Lasttxnhistkey);
	}

	public SfProcesssegmentData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfProcesssegmentData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfProcesssegmentData.Lasttxnid);
	}

	public SfProcesssegmentData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfProcesssegmentData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfProcesssegmentData.Lasttxnuser);
	}

	public SfProcesssegmentData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfProcesssegmentData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfProcesssegmentData.Lasttxntime);
	}

	public SfProcesssegmentData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfProcesssegmentData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfProcesssegmentData.Lasttxncomment);
	}

	public SfProcesssegmentData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfProcesssegmentData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getVersionstate() {
		return this.repository().getString(SfProcesssegmentData.Versionstate);
	}

	public SfProcesssegmentData setVersionstate(String Versionstate) {
		this.repository().set(SfProcesssegmentData.Versionstate, Versionstate);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfProcesssegmentData.Validstate);
	}

	public SfProcesssegmentData setValidstate(String Validstate) {
		this.repository().set(SfProcesssegmentData.Validstate, Validstate);
		return this;
	}


}