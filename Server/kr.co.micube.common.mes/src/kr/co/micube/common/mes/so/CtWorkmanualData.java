package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtWorkmanualData extends SQLData {

	public static final String Drawingno = "DRAWINGNO";

	public static final String Manualno = "MANUALNO";

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

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Lasttxnid = "LASTTXNID";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public CtWorkmanualData() {
		this(new CtWorkmanualKey()); 
	}

	public CtWorkmanualData(CtWorkmanualKey key) {
		super(key, "CtWorkmanual");
	}


	public String getDrawingno() {
		return this.repository().getString(CtWorkmanualData.Drawingno);
	}

	public CtWorkmanualData setDrawingno(String Drawingno) {
		this.repository().set(CtWorkmanualData.Drawingno, Drawingno);
		return this;
	}

	public String getManualid() {
		return this.repository().getString(CtWorkmanualData.Manualid);
	}

	public CtWorkmanualData setManualid(String Manualid) {
		this.repository().set(CtWorkmanualData.Manualid, Manualid);
		return this;
	}

	public String getManualversion() {
		return this.repository().getString(CtWorkmanualData.Manualversion);
	}

	public CtWorkmanualData setManualversion(String Manualversion) {
		this.repository().set(CtWorkmanualData.Manualversion, Manualversion);
		return this;
	}

	public String getManualname() {
		return this.repository().getString(CtWorkmanualData.Manualname);
	}

	public CtWorkmanualData setManualname(String Manualname) {
		this.repository().set(CtWorkmanualData.Manualname, Manualname);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(CtWorkmanualData.Processsegmentid);
	}

	public CtWorkmanualData setProcesssegmentid(String Processsegmentid) {
		this.repository().set(CtWorkmanualData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getManualtype() {
		return this.repository().getString(CtWorkmanualData.Manualtype);
	}

	public CtWorkmanualData setManualtype(String Manualtype) {
		this.repository().set(CtWorkmanualData.Manualtype, Manualtype);
		return this;
	}

	public String getState() {
		return this.repository().getString(CtWorkmanualData.State);
	}

	public CtWorkmanualData setState(String State) {
		this.repository().set(CtWorkmanualData.State, State);
		return this;
	}

	public String getScrapuser() {
		return this.repository().getString(CtWorkmanualData.Scrapuser);
	}

	public CtWorkmanualData setScrapuser(String Scrapuser) {
		this.repository().set(CtWorkmanualData.Scrapuser, Scrapuser);
		return this;
	}

	public Date getScrapdate() {
		return this.repository().getDate(CtWorkmanualData.Scrapdate);
	}

	public CtWorkmanualData setScrapdate(Date Scrapdate) {
		this.repository().set(CtWorkmanualData.Scrapdate, Scrapdate);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtWorkmanualData.Description);
	}

	public CtWorkmanualData setDescription(String Description) {
		this.repository().set(CtWorkmanualData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtWorkmanualData.Creator);
	}

	public CtWorkmanualData setCreator(String Creator) {
		this.repository().set(CtWorkmanualData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtWorkmanualData.Createdtime);
	}

	public CtWorkmanualData setCreatedtime(Date Createdtime) {
		this.repository().set(CtWorkmanualData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtWorkmanualData.Modifier);
	}

	public CtWorkmanualData setModifier(String Modifier) {
		this.repository().set(CtWorkmanualData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtWorkmanualData.Modifiedtime);
	}

	public CtWorkmanualData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtWorkmanualData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtWorkmanualData.Lasttxnhistkey);
	}

	public CtWorkmanualData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtWorkmanualData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtWorkmanualData.Lasttxnid);
	}

	public CtWorkmanualData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtWorkmanualData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtWorkmanualData.Lasttxnuser);
	}

	public CtWorkmanualData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtWorkmanualData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtWorkmanualData.Lasttxntime);
	}

	public CtWorkmanualData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtWorkmanualData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtWorkmanualData.Lasttxncomment);
	}

	public CtWorkmanualData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtWorkmanualData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtWorkmanualData.Validstate);
	}

	public CtWorkmanualData setValidstate(String Validstate) {
		this.repository().set(CtWorkmanualData.Validstate, Validstate);
		return this;
	}


}