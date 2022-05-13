package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfConsumemateriallottempData extends SQLData {

	public static final String Lotid = "LOTID";

	public static final String Materiallotid = "MATERIALLOTID";

	public static final String Materialtype = "MATERIALTYPE";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Areaid = "AREAID";

	public static final String Materialdefid = "MATERIALDEFID";

	public static final String Consumedqty = "CONSUMEDQTY";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Locationid = "LOCATIONID";

	public static final String Productdefid = "PRODUCTDEFID";

	public static final String Processdefid = "PROCESSDEFID";

	public static final String Productdefversion = "PRODUCTDEFVERSION";

	public static final String Processdefversion = "PROCESSDEFVERSION";

	public static final String Processpathid = "PROCESSPATHID";

	public static final String Usersequence = "USERSEQUENCE";

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Processsegmentversion = "PROCESSSEGMENTVERSION";

	public static final String Serialno = "SERIALNO";

	public static final String Goodqty = "GOODQTY";

	public static final String Badqty = "BADQTY";

	public static final String Description = "DESCRIPTION";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public SfConsumemateriallottempData() {
		this(new SfConsumemateriallottempKey()); 
	}

	public SfConsumemateriallottempData(SfConsumemateriallottempKey key) {
		super(key, "SfConsumemateriallottemp");
		this.txnInfo().setHistoryTable(true);
	}


	public String getEnterpriseid() {
		return this.repository().getString(SfConsumemateriallottempData.Enterpriseid);
	}

	public SfConsumemateriallottempData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfConsumemateriallottempData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfConsumemateriallottempData.Plantid);
	}

	public SfConsumemateriallottempData setPlantid(String Plantid) {
		this.repository().set(SfConsumemateriallottempData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfConsumemateriallottempData.Areaid);
	}

	public SfConsumemateriallottempData setAreaid(String Areaid) {
		this.repository().set(SfConsumemateriallottempData.Areaid, Areaid);
		return this;
	}

	public String getMaterialdefid() {
		return this.repository().getString(SfConsumemateriallottempData.Materialdefid);
	}

	public SfConsumemateriallottempData setMaterialdefid(String Materialdefid) {
		this.repository().set(SfConsumemateriallottempData.Materialdefid, Materialdefid);
		return this;
	}

	public Double getConsumedqty() {
		return this.repository().getDouble(SfConsumemateriallottempData.Consumedqty);
	}

	public SfConsumemateriallottempData setConsumedqty(Double Consumedqty) {
		this.repository().set(SfConsumemateriallottempData.Consumedqty, Consumedqty);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(SfConsumemateriallottempData.Equipmentid);
	}

	public SfConsumemateriallottempData setEquipmentid(String Equipmentid) {
		this.repository().set(SfConsumemateriallottempData.Equipmentid, Equipmentid);
		return this;
	}

	public String getLocationid() {
		return this.repository().getString(SfConsumemateriallottempData.Locationid);
	}

	public SfConsumemateriallottempData setLocationid(String Locationid) {
		this.repository().set(SfConsumemateriallottempData.Locationid, Locationid);
		return this;
	}

	public String getProductdefid() {
		return this.repository().getString(SfConsumemateriallottempData.Productdefid);
	}

	public SfConsumemateriallottempData setProductdefid(String Productdefid) {
		this.repository().set(SfConsumemateriallottempData.Productdefid, Productdefid);
		return this;
	}

	public String getProcessdefid() {
		return this.repository().getString(SfConsumemateriallottempData.Processdefid);
	}

	public SfConsumemateriallottempData setProcessdefid(String Processdefid) {
		this.repository().set(SfConsumemateriallottempData.Processdefid, Processdefid);
		return this;
	}

	public String getProductdefversion() {
		return this.repository().getString(SfConsumemateriallottempData.Productdefversion);
	}

	public SfConsumemateriallottempData setProductdefversion(String Productdefversion) {
		this.repository().set(SfConsumemateriallottempData.Productdefversion, Productdefversion);
		return this;
	}

	public String getProcessdefversion() {
		return this.repository().getString(SfConsumemateriallottempData.Processdefversion);
	}

	public SfConsumemateriallottempData setProcessdefversion(String Processdefversion) {
		this.repository().set(SfConsumemateriallottempData.Processdefversion, Processdefversion);
		return this;
	}

	public String getProcesspathid() {
		return this.repository().getString(SfConsumemateriallottempData.Processpathid);
	}

	public SfConsumemateriallottempData setProcesspathid(String Processpathid) {
		this.repository().set(SfConsumemateriallottempData.Processpathid, Processpathid);
		return this;
	}

	public String getUsersequence() {
		return this.repository().getString(SfConsumemateriallottempData.Usersequence);
	}

	public SfConsumemateriallottempData setUsersequence(String Usersequence) {
		this.repository().set(SfConsumemateriallottempData.Usersequence, Usersequence);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(SfConsumemateriallottempData.Processsegmentid);
	}

	public SfConsumemateriallottempData setProcesssegmentid(String Processsegmentid) {
		this.repository().set(SfConsumemateriallottempData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getProcesssegmentversion() {
		return this.repository().getString(SfConsumemateriallottempData.Processsegmentversion);
	}

	public SfConsumemateriallottempData setProcesssegmentversion(String Processsegmentversion) {
		this.repository().set(SfConsumemateriallottempData.Processsegmentversion, Processsegmentversion);
		return this;
	}

	public String getSerialno() {
		return this.repository().getString(SfConsumemateriallottempData.Serialno);
	}

	public SfConsumemateriallottempData setSerialno(String Serialno) {
		this.repository().set(SfConsumemateriallottempData.Serialno, Serialno);
		return this;
	}

	public Double getGoodqty() {
		return this.repository().getDouble(SfConsumemateriallottempData.Goodqty);
	}

	public SfConsumemateriallottempData setGoodqty(Double Goodqty) {
		this.repository().set(SfConsumemateriallottempData.Goodqty, Goodqty);
		return this;
	}

	public Double getBadqty() {
		return this.repository().getDouble(SfConsumemateriallottempData.Badqty);
	}

	public SfConsumemateriallottempData setBadqty(Double Badqty) {
		this.repository().set(SfConsumemateriallottempData.Badqty, Badqty);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfConsumemateriallottempData.Description);
	}

	public SfConsumemateriallottempData setDescription(String Description) {
		this.repository().set(SfConsumemateriallottempData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfConsumemateriallottempData.Creator);
	}

	public SfConsumemateriallottempData setCreator(String Creator) {
		this.repository().set(SfConsumemateriallottempData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfConsumemateriallottempData.Createdtime);
	}

	public SfConsumemateriallottempData setCreatedtime(Date Createdtime) {
		this.repository().set(SfConsumemateriallottempData.Createdtime, Createdtime);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfConsumemateriallottempData.Txnuser);
	}

	public SfConsumemateriallottempData setTxnuser(String Txnuser) {
		this.repository().set(SfConsumemateriallottempData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfConsumemateriallottempData.Txntime);
	}

	public SfConsumemateriallottempData setTxntime(Date Txntime) {
		this.repository().set(SfConsumemateriallottempData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfConsumemateriallottempData.Txngrouphistkey);
	}

	public SfConsumemateriallottempData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfConsumemateriallottempData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfConsumemateriallottempData.Txnreasoncodeclass);
	}

	public SfConsumemateriallottempData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfConsumemateriallottempData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfConsumemateriallottempData.Txnreasoncode);
	}

	public SfConsumemateriallottempData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfConsumemateriallottempData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfConsumemateriallottempData.Txncomment);
	}

	public SfConsumemateriallottempData setTxncomment(String Txncomment) {
		this.repository().set(SfConsumemateriallottempData.Txncomment, Txncomment);
		return this;
	}


}