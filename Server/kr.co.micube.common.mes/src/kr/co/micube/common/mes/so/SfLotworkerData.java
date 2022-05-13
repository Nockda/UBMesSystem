package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfLotworkerData extends SQLData {

	public static final String Lotid = "LOTID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Areaid = "AREAID";

	public static final String Productdefid = "PRODUCTDEFID";

	public static final String Productdefversion = "PRODUCTDEFVERSION";

	public static final String Processdefid = "PROCESSDEFID";

	public static final String Processdefversion = "PROCESSDEFVERSION";

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Processsegmentversion = "PROCESSSEGMENTVERSION";

	public static final String Subprocesssegmentid = "SUBPROCESSSEGMENTID";

	public static final String Processpathid = "PROCESSPATHID";

	public static final String Usersequence = "USERSEQUENCE";

	public static final String Userid = "USERID";

	public static final String Description = "DESCRIPTION";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Modifier = "MODIFIER";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Equipmentid = "EQUIPMENTID";

	public SfLotworkerData() {
		this(new SfLotworkerKey()); 
	}

	public SfLotworkerData(SfLotworkerKey key) {
		super(key, "SfLotworker");
		this.txnInfo().setHistoryTable(true);
	}


	public String getEnterpriseid() {
		return this.repository().getString(SfLotworkerData.Enterpriseid);
	}

	public SfLotworkerData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfLotworkerData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfLotworkerData.Plantid);
	}

	public SfLotworkerData setPlantid(String Plantid) {
		this.repository().set(SfLotworkerData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfLotworkerData.Areaid);
	}

	public SfLotworkerData setAreaid(String Areaid) {
		this.repository().set(SfLotworkerData.Areaid, Areaid);
		return this;
	}

	public String getProductdefid() {
		return this.repository().getString(SfLotworkerData.Productdefid);
	}

	public SfLotworkerData setProductdefid(String Productdefid) {
		this.repository().set(SfLotworkerData.Productdefid, Productdefid);
		return this;
	}

	public String getProductdefversion() {
		return this.repository().getString(SfLotworkerData.Productdefversion);
	}

	public SfLotworkerData setProductdefversion(String Productdefversion) {
		this.repository().set(SfLotworkerData.Productdefversion, Productdefversion);
		return this;
	}

	public String getProcessdefid() {
		return this.repository().getString(SfLotworkerData.Processdefid);
	}

	public SfLotworkerData setProcessdefid(String Processdefid) {
		this.repository().set(SfLotworkerData.Processdefid, Processdefid);
		return this;
	}

	public String getProcessdefversion() {
		return this.repository().getString(SfLotworkerData.Processdefversion);
	}

	public SfLotworkerData setProcessdefversion(String Processdefversion) {
		this.repository().set(SfLotworkerData.Processdefversion, Processdefversion);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(SfLotworkerData.Processsegmentid);
	}

	public SfLotworkerData setProcesssegmentid(String Processsegmentid) {
		this.repository().set(SfLotworkerData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getProcesssegmentversion() {
		return this.repository().getString(SfLotworkerData.Processsegmentversion);
	}

	public SfLotworkerData setProcesssegmentversion(String Processsegmentversion) {
		this.repository().set(SfLotworkerData.Processsegmentversion, Processsegmentversion);
		return this;
	}

	public String getSubprocesssegmentid() {
		return this.repository().getString(SfLotworkerData.Subprocesssegmentid);
	}

	public SfLotworkerData setSubprocesssegmentid(String Subprocesssegmentid) {
		this.repository().set(SfLotworkerData.Subprocesssegmentid, Subprocesssegmentid);
		return this;
	}

	public String getProcesspathid() {
		return this.repository().getString(SfLotworkerData.Processpathid);
	}

	public SfLotworkerData setProcesspathid(String Processpathid) {
		this.repository().set(SfLotworkerData.Processpathid, Processpathid);
		return this;
	}

	public String getUsersequence() {
		return this.repository().getString(SfLotworkerData.Usersequence);
	}

	public SfLotworkerData setUsersequence(String Usersequence) {
		this.repository().set(SfLotworkerData.Usersequence, Usersequence);
		return this;
	}

	public String getUserid() {
		return this.repository().getString(SfLotworkerData.Userid);
	}

	public SfLotworkerData setUserid(String Userid) {
		this.repository().set(SfLotworkerData.Userid, Userid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfLotworkerData.Description);
	}

	public SfLotworkerData setDescription(String Description) {
		this.repository().set(SfLotworkerData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfLotworkerData.Creator);
	}

	public SfLotworkerData setCreator(String Creator) {
		this.repository().set(SfLotworkerData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfLotworkerData.Createdtime);
	}

	public SfLotworkerData setCreatedtime(Date Createdtime) {
		this.repository().set(SfLotworkerData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfLotworkerData.Modifier);
	}

	public SfLotworkerData setModifier(String Modifier) {
		this.repository().set(SfLotworkerData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfLotworkerData.Modifiedtime);
	}

	public SfLotworkerData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfLotworkerData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfLotworkerData.Txngrouphistkey);
	}

	public SfLotworkerData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfLotworkerData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(SfLotworkerData.Txnid);
	}

	public SfLotworkerData setTxnid(String Txnid) {
		this.repository().set(SfLotworkerData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfLotworkerData.Txnuser);
	}

	public SfLotworkerData setTxnuser(String Txnuser) {
		this.repository().set(SfLotworkerData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfLotworkerData.Txntime);
	}

	public SfLotworkerData setTxntime(Date Txntime) {
		this.repository().set(SfLotworkerData.Txntime, Txntime);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfLotworkerData.Txnreasoncodeclass);
	}

	public SfLotworkerData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfLotworkerData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfLotworkerData.Txnreasoncode);
	}

	public SfLotworkerData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfLotworkerData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfLotworkerData.Txncomment);
	}

	public SfLotworkerData setTxncomment(String Txncomment) {
		this.repository().set(SfLotworkerData.Txncomment, Txncomment);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(SfLotworkerData.Equipmentid);
	}

	public SfLotworkerData setEquipmentid(String Equipmentid) {
		this.repository().set(SfLotworkerData.Equipmentid, Equipmentid);
		return this;
	}


}