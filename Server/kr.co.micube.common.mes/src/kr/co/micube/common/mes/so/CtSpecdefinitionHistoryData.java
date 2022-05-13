package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtSpecdefinitionHistoryData extends SQLData {

	public static final String Txnhistkey = "TXNHISTKEY";

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

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public static final String Isdivide = "ISDIVIDE";

	public CtSpecdefinitionHistoryData() {
		this(new CtSpecdefinitionHistoryKey()); 
	}

	public CtSpecdefinitionHistoryData(CtSpecdefinitionHistoryKey key) {
		super(key, "CtSpecdefinitionHistory");
	}


	public String getSpecdefname() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Specdefname);
	}

	public CtSpecdefinitionHistoryData setSpecdefname(String Specdefname) {
		this.repository().set(CtSpecdefinitionHistoryData.Specdefname, Specdefname);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Enterpriseid);
	}

	public CtSpecdefinitionHistoryData setEnterpriseid(String Enterpriseid) {
		this.repository().set(CtSpecdefinitionHistoryData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Plantid);
	}

	public CtSpecdefinitionHistoryData setPlantid(String Plantid) {
		this.repository().set(CtSpecdefinitionHistoryData.Plantid, Plantid);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Processsegmentid);
	}

	public CtSpecdefinitionHistoryData setProcesssegmentid(String Processsegmentid) {
		this.repository().set(CtSpecdefinitionHistoryData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Dictionaryid);
	}

	public CtSpecdefinitionHistoryData setDictionaryid(String Dictionaryid) {
		this.repository().set(CtSpecdefinitionHistoryData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Description);
	}

	public CtSpecdefinitionHistoryData setDescription(String Description) {
		this.repository().set(CtSpecdefinitionHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Creator);
	}

	public CtSpecdefinitionHistoryData setCreator(String Creator) {
		this.repository().set(CtSpecdefinitionHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtSpecdefinitionHistoryData.Createdtime);
	}

	public CtSpecdefinitionHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtSpecdefinitionHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Modifier);
	}

	public CtSpecdefinitionHistoryData setModifier(String Modifier) {
		this.repository().set(CtSpecdefinitionHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtSpecdefinitionHistoryData.Modifiedtime);
	}

	public CtSpecdefinitionHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtSpecdefinitionHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Txnid);
	}

	public CtSpecdefinitionHistoryData setTxnid(String Txnid) {
		this.repository().set(CtSpecdefinitionHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Txnuser);
	}

	public CtSpecdefinitionHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtSpecdefinitionHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtSpecdefinitionHistoryData.Txntime);
	}

	public CtSpecdefinitionHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtSpecdefinitionHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Txngrouphistkey);
	}

	public CtSpecdefinitionHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtSpecdefinitionHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Txnreasoncodeclass);
	}

	public CtSpecdefinitionHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtSpecdefinitionHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Txnreasoncode);
	}

	public CtSpecdefinitionHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtSpecdefinitionHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Txncomment);
	}

	public CtSpecdefinitionHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtSpecdefinitionHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Validstate);
	}

	public CtSpecdefinitionHistoryData setValidstate(String Validstate) {
		this.repository().set(CtSpecdefinitionHistoryData.Validstate, Validstate);
		return this;
	}

	public String getIsdivide() {
		return this.repository().getString(CtSpecdefinitionHistoryData.Isdivide);
	}

	public CtSpecdefinitionHistoryData setIsdivide(String Isdivide) {
		this.repository().set(CtSpecdefinitionHistoryData.Isdivide, Isdivide);
		return this;
	}


}