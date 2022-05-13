package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlSpecidHistoryData extends SQLData {

	public static final String Specdefid = "SPECDEFID";

	public static final String Seq = "SEQ";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Specdefname = "SPECDEFNAME";

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Subprocesssegmentid = "SUBPROCESSSEGMENTID";

	public static final String Specseq = "SPECSEQ";

	public static final String Isresult = "ISRESULT";

	public static final String Isoutsourcing = "ISOUTSOURCING";

	public static final String Isdivide = "ISDIVIDE";

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

	public UlSpecidHistoryData() {
		this(new UlSpecidHistoryKey()); 
	}

	public UlSpecidHistoryData(UlSpecidHistoryKey key) {
		super(key, "UlSpecidHistory");
	}


	public String getSpecdefname() {
		return this.repository().getString(UlSpecidHistoryData.Specdefname);
	}

	public UlSpecidHistoryData setSpecdefname(String Specdefname) {
		this.repository().set(UlSpecidHistoryData.Specdefname, Specdefname);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(UlSpecidHistoryData.Processsegmentid);
	}

	public UlSpecidHistoryData setProcesssegmentid(String Processsegmentid) {
		this.repository().set(UlSpecidHistoryData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getSubprocesssegmentid() {
		return this.repository().getString(UlSpecidHistoryData.Subprocesssegmentid);
	}

	public UlSpecidHistoryData setSubprocesssegmentid(String Subprocesssegmentid) {
		this.repository().set(UlSpecidHistoryData.Subprocesssegmentid, Subprocesssegmentid);
		return this;
	}

	public Integer getSpecseq() {
		return this.repository().getInteger(UlSpecidHistoryData.Specseq);
	}

	public UlSpecidHistoryData setSpecseq(Integer Specseq) {
		this.repository().set(UlSpecidHistoryData.Specseq, Specseq);
		return this;
	}

	public String getIsresult() {
		return this.repository().getString(UlSpecidHistoryData.Isresult);
	}

	public UlSpecidHistoryData setIsresult(String Isresult) {
		this.repository().set(UlSpecidHistoryData.Isresult, Isresult);
		return this;
	}

	public String getIsoutsourcing() {
		return this.repository().getString(UlSpecidHistoryData.Isoutsourcing);
	}

	public UlSpecidHistoryData setIsoutsourcing(String Isoutsourcing) {
		this.repository().set(UlSpecidHistoryData.Isoutsourcing, Isoutsourcing);
		return this;
	}

	public String getIsdivide() {
		return this.repository().getString(UlSpecidHistoryData.Isdivide);
	}

	public UlSpecidHistoryData setIsdivide(String Isdivide) {
		this.repository().set(UlSpecidHistoryData.Isdivide, Isdivide);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(UlSpecidHistoryData.Dictionaryid);
	}

	public UlSpecidHistoryData setDictionaryid(String Dictionaryid) {
		this.repository().set(UlSpecidHistoryData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlSpecidHistoryData.Description);
	}

	public UlSpecidHistoryData setDescription(String Description) {
		this.repository().set(UlSpecidHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlSpecidHistoryData.Creator);
	}

	public UlSpecidHistoryData setCreator(String Creator) {
		this.repository().set(UlSpecidHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlSpecidHistoryData.Createdtime);
	}

	public UlSpecidHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(UlSpecidHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlSpecidHistoryData.Modifier);
	}

	public UlSpecidHistoryData setModifier(String Modifier) {
		this.repository().set(UlSpecidHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlSpecidHistoryData.Modifiedtime);
	}

	public UlSpecidHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlSpecidHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlSpecidHistoryData.Txnid);
	}

	public UlSpecidHistoryData setTxnid(String Txnid) {
		this.repository().set(UlSpecidHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlSpecidHistoryData.Txnuser);
	}

	public UlSpecidHistoryData setTxnuser(String Txnuser) {
		this.repository().set(UlSpecidHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlSpecidHistoryData.Txntime);
	}

	public UlSpecidHistoryData setTxntime(Date Txntime) {
		this.repository().set(UlSpecidHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlSpecidHistoryData.Txngrouphistkey);
	}

	public UlSpecidHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlSpecidHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlSpecidHistoryData.Txnreasoncodeclass);
	}

	public UlSpecidHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlSpecidHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlSpecidHistoryData.Txnreasoncode);
	}

	public UlSpecidHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlSpecidHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlSpecidHistoryData.Txncomment);
	}

	public UlSpecidHistoryData setTxncomment(String Txncomment) {
		this.repository().set(UlSpecidHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlSpecidHistoryData.Validstate);
	}

	public UlSpecidHistoryData setValidstate(String Validstate) {
		this.repository().set(UlSpecidHistoryData.Validstate, Validstate);
		return this;
	}


}