package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfProcesssegmentHistoryData extends SQLData {

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Processsegmentversion = "PROCESSSEGMENTVERSION";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Processsegmentname = "PROCESSSEGMENTNAME";

	public static final String Processsegmentclassid = "PROCESSSEGMENTCLASSID";

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

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Versionstate = "VERSIONSTATE";

	public static final String Validstate = "VALIDSTATE";

	public SfProcesssegmentHistoryData() {
		this(new SfProcesssegmentHistoryKey()); 
	}

	public SfProcesssegmentHistoryData(SfProcesssegmentHistoryKey key) {
		super(key, "SfProcesssegmentHistory");
	}


	public String getProcesssegmentname() {
		return this.repository().getString(SfProcesssegmentHistoryData.Processsegmentname);
	}

	public SfProcesssegmentHistoryData setProcesssegmentname(String Processsegmentname) {
		this.repository().set(SfProcesssegmentHistoryData.Processsegmentname, Processsegmentname);
		return this;
	}

	public String getProcesssegmentclassid() {
		return this.repository().getString(SfProcesssegmentHistoryData.Processsegmentclassid);
	}

	public SfProcesssegmentHistoryData setProcesssegmentclassid(String Processsegmentclassid) {
		this.repository().set(SfProcesssegmentHistoryData.Processsegmentclassid, Processsegmentclassid);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfProcesssegmentHistoryData.Enterpriseid);
	}

	public SfProcesssegmentHistoryData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfProcesssegmentHistoryData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfProcesssegmentHistoryData.Plantid);
	}

	public SfProcesssegmentHistoryData setPlantid(String Plantid) {
		this.repository().set(SfProcesssegmentHistoryData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfProcesssegmentHistoryData.Areaid);
	}

	public SfProcesssegmentHistoryData setAreaid(String Areaid) {
		this.repository().set(SfProcesssegmentHistoryData.Areaid, Areaid);
		return this;
	}

	public String getProcesssegmenttype() {
		return this.repository().getString(SfProcesssegmentHistoryData.Processsegmenttype);
	}

	public SfProcesssegmentHistoryData setProcesssegmenttype(String Processsegmenttype) {
		this.repository().set(SfProcesssegmentHistoryData.Processsegmenttype, Processsegmenttype);
		return this;
	}

	public String getCheckresult() {
		return this.repository().getString(SfProcesssegmentHistoryData.Checkresult);
	}

	public SfProcesssegmentHistoryData setCheckresult(String Checkresult) {
		this.repository().set(SfProcesssegmentHistoryData.Checkresult, Checkresult);
		return this;
	}

	public String getEquipmentclassid() {
		return this.repository().getString(SfProcesssegmentHistoryData.Equipmentclassid);
	}

	public SfProcesssegmentHistoryData setEquipmentclassid(String Equipmentclassid) {
		this.repository().set(SfProcesssegmentHistoryData.Equipmentclassid, Equipmentclassid);
		return this;
	}

	public String getIstrackinrequired() {
		return this.repository().getString(SfProcesssegmentHistoryData.Istrackinrequired);
	}

	public SfProcesssegmentHistoryData setIstrackinrequired(String Istrackinrequired) {
		this.repository().set(SfProcesssegmentHistoryData.Istrackinrequired, Istrackinrequired);
		return this;
	}

	public Double getLeadtime() {
		return this.repository().getDouble(SfProcesssegmentHistoryData.Leadtime);
	}

	public SfProcesssegmentHistoryData setLeadtime(Double Leadtime) {
		this.repository().set(SfProcesssegmentHistoryData.Leadtime, Leadtime);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfProcesssegmentHistoryData.Dictionaryid);
	}

	public SfProcesssegmentHistoryData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfProcesssegmentHistoryData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getIsuseuserlotserial() {
		return this.repository().getString(SfProcesssegmentHistoryData.Isuseuserlotserial);
	}

	public SfProcesssegmentHistoryData setIsuseuserlotserial(String Isuseuserlotserial) {
		this.repository().set(SfProcesssegmentHistoryData.Isuseuserlotserial, Isuseuserlotserial);
		return this;
	}

	public String getLotcreateruleid() {
		return this.repository().getString(SfProcesssegmentHistoryData.Lotcreateruleid);
	}

	public SfProcesssegmentHistoryData setLotcreateruleid(String Lotcreateruleid) {
		this.repository().set(SfProcesssegmentHistoryData.Lotcreateruleid, Lotcreateruleid);
		return this;
	}

	public String getIsmainprocesssegment() {
		return this.repository().getString(SfProcesssegmentHistoryData.Ismainprocesssegment);
	}

	public SfProcesssegmentHistoryData setIsmainprocesssegment(String Ismainprocesssegment) {
		this.repository().set(SfProcesssegmentHistoryData.Ismainprocesssegment, Ismainprocesssegment);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfProcesssegmentHistoryData.Description);
	}

	public SfProcesssegmentHistoryData setDescription(String Description) {
		this.repository().set(SfProcesssegmentHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfProcesssegmentHistoryData.Creator);
	}

	public SfProcesssegmentHistoryData setCreator(String Creator) {
		this.repository().set(SfProcesssegmentHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfProcesssegmentHistoryData.Createdtime);
	}

	public SfProcesssegmentHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(SfProcesssegmentHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfProcesssegmentHistoryData.Modifier);
	}

	public SfProcesssegmentHistoryData setModifier(String Modifier) {
		this.repository().set(SfProcesssegmentHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfProcesssegmentHistoryData.Modifiedtime);
	}

	public SfProcesssegmentHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfProcesssegmentHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(SfProcesssegmentHistoryData.Txnid);
	}

	public SfProcesssegmentHistoryData setTxnid(String Txnid) {
		this.repository().set(SfProcesssegmentHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfProcesssegmentHistoryData.Txnuser);
	}

	public SfProcesssegmentHistoryData setTxnuser(String Txnuser) {
		this.repository().set(SfProcesssegmentHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfProcesssegmentHistoryData.Txntime);
	}

	public SfProcesssegmentHistoryData setTxntime(Date Txntime) {
		this.repository().set(SfProcesssegmentHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfProcesssegmentHistoryData.Txngrouphistkey);
	}

	public SfProcesssegmentHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfProcesssegmentHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfProcesssegmentHistoryData.Txnreasoncodeclass);
	}

	public SfProcesssegmentHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfProcesssegmentHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfProcesssegmentHistoryData.Txnreasoncode);
	}

	public SfProcesssegmentHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfProcesssegmentHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfProcesssegmentHistoryData.Txncomment);
	}

	public SfProcesssegmentHistoryData setTxncomment(String Txncomment) {
		this.repository().set(SfProcesssegmentHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getVersionstate() {
		return this.repository().getString(SfProcesssegmentHistoryData.Versionstate);
	}

	public SfProcesssegmentHistoryData setVersionstate(String Versionstate) {
		this.repository().set(SfProcesssegmentHistoryData.Versionstate, Versionstate);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfProcesssegmentHistoryData.Validstate);
	}

	public SfProcesssegmentHistoryData setValidstate(String Validstate) {
		this.repository().set(SfProcesssegmentHistoryData.Validstate, Validstate);
		return this;
	}


}