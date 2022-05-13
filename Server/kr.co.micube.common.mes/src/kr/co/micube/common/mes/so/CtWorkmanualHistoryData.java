package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtWorkmanualHistoryData extends SQLData {

	public static final String Drawingno = "DRAWINGNO";

	public static final String Manualno = "MANUALNO";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Manualid = "MANUALID";

	public static final String Manualversion = "MANUALVERSION";

	public static final String Manualname = "MANUALNAME";

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Manualtype = "MANUALTYPE";

	public static final String State = "STATE";

	public static final String Scrapuser = "SCRAPUSER";

	public static final String Scrapdate = "SCRAPDATE";

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

	public CtWorkmanualHistoryData() {
		this(new CtWorkmanualHistoryKey()); 
	}

	public CtWorkmanualHistoryData(CtWorkmanualHistoryKey key) {
		super(key, "CtWorkmanualHistory");
	}


	public String getDrawingno() {
		return this.repository().getString(CtWorkmanualHistoryData.Drawingno);
	}

	public CtWorkmanualHistoryData setDrawingno(String Drawingno) {
		this.repository().set(CtWorkmanualHistoryData.Drawingno, Drawingno);
		return this;
	}

	public String getManualid() {
		return this.repository().getString(CtWorkmanualHistoryData.Manualid);
	}

	public CtWorkmanualHistoryData setManualid(String Manualid) {
		this.repository().set(CtWorkmanualHistoryData.Manualid, Manualid);
		return this;
	}

	public String getManualversion() {
		return this.repository().getString(CtWorkmanualHistoryData.Manualversion);
	}

	public CtWorkmanualHistoryData setManualversion(String Manualversion) {
		this.repository().set(CtWorkmanualHistoryData.Manualversion, Manualversion);
		return this;
	}

	public String getManualname() {
		return this.repository().getString(CtWorkmanualHistoryData.Manualname);
	}

	public CtWorkmanualHistoryData setManualname(String Manualname) {
		this.repository().set(CtWorkmanualHistoryData.Manualname, Manualname);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(CtWorkmanualHistoryData.Processsegmentid);
	}

	public CtWorkmanualHistoryData setProcesssegmentid(String Processsegmentid) {
		this.repository().set(CtWorkmanualHistoryData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getManualtype() {
		return this.repository().getString(CtWorkmanualHistoryData.Manualtype);
	}

	public CtWorkmanualHistoryData setManualtype(String Manualtype) {
		this.repository().set(CtWorkmanualHistoryData.Manualtype, Manualtype);
		return this;
	}

	public String getState() {
		return this.repository().getString(CtWorkmanualHistoryData.State);
	}

	public CtWorkmanualHistoryData setState(String State) {
		this.repository().set(CtWorkmanualHistoryData.State, State);
		return this;
	}

	public String getScrapuser() {
		return this.repository().getString(CtWorkmanualHistoryData.Scrapuser);
	}

	public CtWorkmanualHistoryData setScrapuser(String Scrapuser) {
		this.repository().set(CtWorkmanualHistoryData.Scrapuser, Scrapuser);
		return this;
	}

	public Date getScrapdate() {
		return this.repository().getDate(CtWorkmanualHistoryData.Scrapdate);
	}

	public CtWorkmanualHistoryData setScrapdate(Date Scrapdate) {
		this.repository().set(CtWorkmanualHistoryData.Scrapdate, Scrapdate);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtWorkmanualHistoryData.Description);
	}

	public CtWorkmanualHistoryData setDescription(String Description) {
		this.repository().set(CtWorkmanualHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtWorkmanualHistoryData.Creator);
	}

	public CtWorkmanualHistoryData setCreator(String Creator) {
		this.repository().set(CtWorkmanualHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtWorkmanualHistoryData.Createdtime);
	}

	public CtWorkmanualHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtWorkmanualHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtWorkmanualHistoryData.Modifier);
	}

	public CtWorkmanualHistoryData setModifier(String Modifier) {
		this.repository().set(CtWorkmanualHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtWorkmanualHistoryData.Modifiedtime);
	}

	public CtWorkmanualHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtWorkmanualHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtWorkmanualHistoryData.Txnid);
	}

	public CtWorkmanualHistoryData setTxnid(String Txnid) {
		this.repository().set(CtWorkmanualHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtWorkmanualHistoryData.Txnuser);
	}

	public CtWorkmanualHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtWorkmanualHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtWorkmanualHistoryData.Txntime);
	}

	public CtWorkmanualHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtWorkmanualHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtWorkmanualHistoryData.Txngrouphistkey);
	}

	public CtWorkmanualHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtWorkmanualHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtWorkmanualHistoryData.Txnreasoncodeclass);
	}

	public CtWorkmanualHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtWorkmanualHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtWorkmanualHistoryData.Txnreasoncode);
	}

	public CtWorkmanualHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtWorkmanualHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtWorkmanualHistoryData.Txncomment);
	}

	public CtWorkmanualHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtWorkmanualHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtWorkmanualHistoryData.Validstate);
	}

	public CtWorkmanualHistoryData setValidstate(String Validstate) {
		this.repository().set(CtWorkmanualHistoryData.Validstate, Validstate);
		return this;
	}


}