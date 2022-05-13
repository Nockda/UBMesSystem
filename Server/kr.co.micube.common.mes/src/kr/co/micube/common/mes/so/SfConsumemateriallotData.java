package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfConsumemateriallotData extends SQLData {

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

	public SfConsumemateriallotData() {
		this(new SfConsumemateriallotKey()); 
	}

	public SfConsumemateriallotData(SfConsumemateriallotKey key) {
		super(key, "SfConsumemateriallot");
		this.txnInfo().setHistoryTable(true);
	}


	public String getEnterpriseid() {
		return this.repository().getString(SfConsumemateriallotData.Enterpriseid);
	}

	public SfConsumemateriallotData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfConsumemateriallotData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfConsumemateriallotData.Plantid);
	}

	public SfConsumemateriallotData setPlantid(String Plantid) {
		this.repository().set(SfConsumemateriallotData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfConsumemateriallotData.Areaid);
	}

	public SfConsumemateriallotData setAreaid(String Areaid) {
		this.repository().set(SfConsumemateriallotData.Areaid, Areaid);
		return this;
	}

	public String getMaterialdefid() {
		return this.repository().getString(SfConsumemateriallotData.Materialdefid);
	}

	public SfConsumemateriallotData setMaterialdefid(String Materialdefid) {
		this.repository().set(SfConsumemateriallotData.Materialdefid, Materialdefid);
		return this;
	}

	public Double getConsumedqty() {
		return this.repository().getDouble(SfConsumemateriallotData.Consumedqty);
	}

	public SfConsumemateriallotData setConsumedqty(Double Consumedqty) {
		this.repository().set(SfConsumemateriallotData.Consumedqty, Consumedqty);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(SfConsumemateriallotData.Equipmentid);
	}

	public SfConsumemateriallotData setEquipmentid(String Equipmentid) {
		this.repository().set(SfConsumemateriallotData.Equipmentid, Equipmentid);
		return this;
	}

	public String getLocationid() {
		return this.repository().getString(SfConsumemateriallotData.Locationid);
	}

	public SfConsumemateriallotData setLocationid(String Locationid) {
		this.repository().set(SfConsumemateriallotData.Locationid, Locationid);
		return this;
	}

	public String getProductdefid() {
		return this.repository().getString(SfConsumemateriallotData.Productdefid);
	}

	public SfConsumemateriallotData setProductdefid(String Productdefid) {
		this.repository().set(SfConsumemateriallotData.Productdefid, Productdefid);
		return this;
	}

	public String getProcessdefid() {
		return this.repository().getString(SfConsumemateriallotData.Processdefid);
	}

	public SfConsumemateriallotData setProcessdefid(String Processdefid) {
		this.repository().set(SfConsumemateriallotData.Processdefid, Processdefid);
		return this;
	}

	public String getProductdefversion() {
		return this.repository().getString(SfConsumemateriallotData.Productdefversion);
	}

	public SfConsumemateriallotData setProductdefversion(String Productdefversion) {
		this.repository().set(SfConsumemateriallotData.Productdefversion, Productdefversion);
		return this;
	}

	public String getProcessdefversion() {
		return this.repository().getString(SfConsumemateriallotData.Processdefversion);
	}

	public SfConsumemateriallotData setProcessdefversion(String Processdefversion) {
		this.repository().set(SfConsumemateriallotData.Processdefversion, Processdefversion);
		return this;
	}

	public String getProcesspathid() {
		return this.repository().getString(SfConsumemateriallotData.Processpathid);
	}

	public SfConsumemateriallotData setProcesspathid(String Processpathid) {
		this.repository().set(SfConsumemateriallotData.Processpathid, Processpathid);
		return this;
	}

	public String getUsersequence() {
		return this.repository().getString(SfConsumemateriallotData.Usersequence);
	}

	public SfConsumemateriallotData setUsersequence(String Usersequence) {
		this.repository().set(SfConsumemateriallotData.Usersequence, Usersequence);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(SfConsumemateriallotData.Processsegmentid);
	}

	public SfConsumemateriallotData setProcesssegmentid(String Processsegmentid) {
		this.repository().set(SfConsumemateriallotData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getProcesssegmentversion() {
		return this.repository().getString(SfConsumemateriallotData.Processsegmentversion);
	}

	public SfConsumemateriallotData setProcesssegmentversion(String Processsegmentversion) {
		this.repository().set(SfConsumemateriallotData.Processsegmentversion, Processsegmentversion);
		return this;
	}

	public String getSerialno() {
		return this.repository().getString(SfConsumemateriallotData.Serialno);
	}

	public SfConsumemateriallotData setSerialno(String Serialno) {
		this.repository().set(SfConsumemateriallotData.Serialno, Serialno);
		return this;
	}

	public Double getGoodqty() {
		return this.repository().getDouble(SfConsumemateriallotData.Goodqty);
	}

	public SfConsumemateriallotData setGoodqty(Double Goodqty) {
		this.repository().set(SfConsumemateriallotData.Goodqty, Goodqty);
		return this;
	}

	public Double getBadqty() {
		return this.repository().getDouble(SfConsumemateriallotData.Badqty);
	}

	public SfConsumemateriallotData setBadqty(Double Badqty) {
		this.repository().set(SfConsumemateriallotData.Badqty, Badqty);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfConsumemateriallotData.Description);
	}

	public SfConsumemateriallotData setDescription(String Description) {
		this.repository().set(SfConsumemateriallotData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfConsumemateriallotData.Creator);
	}

	public SfConsumemateriallotData setCreator(String Creator) {
		this.repository().set(SfConsumemateriallotData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfConsumemateriallotData.Createdtime);
	}

	public SfConsumemateriallotData setCreatedtime(Date Createdtime) {
		this.repository().set(SfConsumemateriallotData.Createdtime, Createdtime);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfConsumemateriallotData.Txnuser);
	}

	public SfConsumemateriallotData setTxnuser(String Txnuser) {
		this.repository().set(SfConsumemateriallotData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfConsumemateriallotData.Txntime);
	}

	public SfConsumemateriallotData setTxntime(Date Txntime) {
		this.repository().set(SfConsumemateriallotData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfConsumemateriallotData.Txngrouphistkey);
	}

	public SfConsumemateriallotData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfConsumemateriallotData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfConsumemateriallotData.Txnreasoncodeclass);
	}

	public SfConsumemateriallotData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfConsumemateriallotData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfConsumemateriallotData.Txnreasoncode);
	}

	public SfConsumemateriallotData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfConsumemateriallotData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfConsumemateriallotData.Txncomment);
	}

	public SfConsumemateriallotData setTxncomment(String Txncomment) {
		this.repository().set(SfConsumemateriallotData.Txncomment, Txncomment);
		return this;
	}


}