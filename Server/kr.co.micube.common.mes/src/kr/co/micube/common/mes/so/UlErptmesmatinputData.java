package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlErptmesmatinputData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Meskey = "MESKEY";

	public static final String Messeq = "MESSEQ";

	public static final String Audtype = "AUDType";

	public static final String Crtdatetime = "CRTDATETIME";

	public static final String Recvyn = "RECVYN";

	public static final String Recvdatetime = "RECVDATETIME";

	public static final String Inputdate = "INPUTDATE";

	public static final String Itemseq = "ITEMSEQ";

	public static final String Itemno = "ITEMNO";

	public static final String Unitseq = "UNITSEQ";

	public static final String Inputqty = "INPUTQTY";

	public static final String Workreportseq = "WORKREPORTSEQ";

	public static final String Workreportserl = "WORKREPORTSERL";

	public static final String Progstatus = "PROGSTATUS";

	public static final String Progresult = "PROGRESULT";

	public static final String Tossyn = "TOSSYN";

	public static final String Interfacetxnhistkey = "INTERFACETXNHISTKEY";

	public UlErptmesmatinputData() {
		this(new UlErptmesmatinputKey()); 
	}

	public UlErptmesmatinputData(UlErptmesmatinputKey key) {
		super(key, "UlErptmesmatinput");
	}


	public String getMeskey() {
		return this.repository().getString(UlErptmesmatinputData.Meskey);
	}

	public UlErptmesmatinputData setMeskey(String Meskey) {
		this.repository().set(UlErptmesmatinputData.Meskey, Meskey);
		return this;
	}

	public Integer getMesseq() {
		return this.repository().getInteger(UlErptmesmatinputData.Messeq);
	}

	public UlErptmesmatinputData setMesseq(Integer Messeq) {
		this.repository().set(UlErptmesmatinputData.Messeq, Messeq);
		return this;
	}

	public String getAudtype() {
		return this.repository().getString(UlErptmesmatinputData.Audtype);
	}

	public UlErptmesmatinputData setAudtype(String Audtype) {
		this.repository().set(UlErptmesmatinputData.Audtype, Audtype);
		return this;
	}

	public Date getCrtdatetime() {
		return this.repository().getDate(UlErptmesmatinputData.Crtdatetime);
	}

	public UlErptmesmatinputData setCrtdatetime(Date Crtdatetime) {
		this.repository().set(UlErptmesmatinputData.Crtdatetime, Crtdatetime);
		return this;
	}

	public String getRecvyn() {
		return this.repository().getString(UlErptmesmatinputData.Recvyn);
	}

	public UlErptmesmatinputData setRecvyn(String Recvyn) {
		this.repository().set(UlErptmesmatinputData.Recvyn, Recvyn);
		return this;
	}

	public Date getRecvdatetime() {
		return this.repository().getDate(UlErptmesmatinputData.Recvdatetime);
	}

	public UlErptmesmatinputData setRecvdatetime(Date Recvdatetime) {
		this.repository().set(UlErptmesmatinputData.Recvdatetime, Recvdatetime);
		return this;
	}

	public String getInputdate() {
		return this.repository().getString(UlErptmesmatinputData.Inputdate);
	}

	public UlErptmesmatinputData setInputdate(String Inputdate) {
		this.repository().set(UlErptmesmatinputData.Inputdate, Inputdate);
		return this;
	}

	public Integer getItemseq() {
		return this.repository().getInteger(UlErptmesmatinputData.Itemseq);
	}

	public UlErptmesmatinputData setItemseq(Integer Itemseq) {
		this.repository().set(UlErptmesmatinputData.Itemseq, Itemseq);
		return this;
	}

	public String getItemno() {
		return this.repository().getString(UlErptmesmatinputData.Itemno);
	}

	public UlErptmesmatinputData setItemno(String Itemno) {
		this.repository().set(UlErptmesmatinputData.Itemno, Itemno);
		return this;
	}

	public Integer getUnitseq() {
		return this.repository().getInteger(UlErptmesmatinputData.Unitseq);
	}

	public UlErptmesmatinputData setUnitseq(Integer Unitseq) {
		this.repository().set(UlErptmesmatinputData.Unitseq, Unitseq);
		return this;
	}

	public Double getInputqty() {
		return this.repository().getDouble(UlErptmesmatinputData.Inputqty);
	}

	public UlErptmesmatinputData setInputqty(Double Inputqty) {
		this.repository().set(UlErptmesmatinputData.Inputqty, Inputqty);
		return this;
	}

	public Integer getWorkreportseq() {
		return this.repository().getInteger(UlErptmesmatinputData.Workreportseq);
	}

	public UlErptmesmatinputData setWorkreportseq(Integer Workreportseq) {
		this.repository().set(UlErptmesmatinputData.Workreportseq, Workreportseq);
		return this;
	}

	public Integer getWorkreportserl() {
		return this.repository().getInteger(UlErptmesmatinputData.Workreportserl);
	}

	public UlErptmesmatinputData setWorkreportserl(Integer Workreportserl) {
		this.repository().set(UlErptmesmatinputData.Workreportserl, Workreportserl);
		return this;
	}

	public String getProgstatus() {
		return this.repository().getString(UlErptmesmatinputData.Progstatus);
	}

	public UlErptmesmatinputData setProgstatus(String Progstatus) {
		this.repository().set(UlErptmesmatinputData.Progstatus, Progstatus);
		return this;
	}

	public String getProgresult() {
		return this.repository().getString(UlErptmesmatinputData.Progresult);
	}

	public UlErptmesmatinputData setProgresult(String Progresult) {
		this.repository().set(UlErptmesmatinputData.Progresult, Progresult);
		return this;
	}

	public String getTossyn() {
		return this.repository().getString(UlErptmesmatinputData.Tossyn);
	}

	public UlErptmesmatinputData setTossyn(String Tossyn) {
		this.repository().set(UlErptmesmatinputData.Tossyn, Tossyn);
		return this;
	}

	public String getInterfacetxnhistkey() {
		return this.repository().getString(UlErptmesmatinputData.Interfacetxnhistkey);
	}

	public UlErptmesmatinputData setInterfacetxnhistkey(String Interfacetxnhistkey) {
		this.repository().set(UlErptmesmatinputData.Interfacetxnhistkey, Interfacetxnhistkey);
		return this;
	}


}