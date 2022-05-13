package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlErptmesetcinData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Meskey = "MESKEY";

	public static final String Messeq = "MESSEQ";

	public static final String Audtype = "AUDType";

	public static final String Crtdatetime = "CRTDATETIME";

	public static final String Recvyn = "RECVYN";

	public static final String Recvdatetime = "RECVDATETIME";

	public static final String Indate = "INDATE";

	public static final String Etcintype = "ETCINTYPE";

	public static final String Itemseq = "ITEMSEQ";

	public static final String Itemno = "ITEMNO";

	public static final String Inqty = "INQTY";

	public static final String Whseq = "WHSEQ";

	public static final String Empseq = "EMPSEQ";

	public static final String Etcinseq = "ETCINSEQ";

	public static final String Etcinserl = "ETCINSERL";

	public static final String Progstatus = "PROGSTATUS";

	public static final String Progresult = "PROGRESULT";

	public static final String Tossyn = "TOSSYN";

	public static final String Interfacetxnhistkey = "INTERFACETXNHISTKEY";

	public static final String Remark = "REMARK";

	public UlErptmesetcinData() {
		this(new UlErptmesetcinKey()); 
	}

	public UlErptmesetcinData(UlErptmesetcinKey key) {
		super(key, "UlErptmesetcin");
	}


	public String getMeskey() {
		return this.repository().getString(UlErptmesetcinData.Meskey);
	}

	public UlErptmesetcinData setMeskey(String Meskey) {
		this.repository().set(UlErptmesetcinData.Meskey, Meskey);
		return this;
	}

	public Integer getMesseq() {
		return this.repository().getInteger(UlErptmesetcinData.Messeq);
	}

	public UlErptmesetcinData setMesseq(Integer Messeq) {
		this.repository().set(UlErptmesetcinData.Messeq, Messeq);
		return this;
	}

	public String getAudtype() {
		return this.repository().getString(UlErptmesetcinData.Audtype);
	}

	public UlErptmesetcinData setAudtype(String Audtype) {
		this.repository().set(UlErptmesetcinData.Audtype, Audtype);
		return this;
	}

	public Date getCrtdatetime() {
		return this.repository().getDate(UlErptmesetcinData.Crtdatetime);
	}

	public UlErptmesetcinData setCrtdatetime(Date Crtdatetime) {
		this.repository().set(UlErptmesetcinData.Crtdatetime, Crtdatetime);
		return this;
	}

	public String getRecvyn() {
		return this.repository().getString(UlErptmesetcinData.Recvyn);
	}

	public UlErptmesetcinData setRecvyn(String Recvyn) {
		this.repository().set(UlErptmesetcinData.Recvyn, Recvyn);
		return this;
	}

	public Date getRecvdatetime() {
		return this.repository().getDate(UlErptmesetcinData.Recvdatetime);
	}

	public UlErptmesetcinData setRecvdatetime(Date Recvdatetime) {
		this.repository().set(UlErptmesetcinData.Recvdatetime, Recvdatetime);
		return this;
	}

	public String getIndate() {
		return this.repository().getString(UlErptmesetcinData.Indate);
	}

	public UlErptmesetcinData setIndate(String Indate) {
		this.repository().set(UlErptmesetcinData.Indate, Indate);
		return this;
	}

	public Integer getEtcintype() {
		return this.repository().getInteger(UlErptmesetcinData.Etcintype);
	}

	public UlErptmesetcinData setEtcintype(Integer Etcintype) {
		this.repository().set(UlErptmesetcinData.Etcintype, Etcintype);
		return this;
	}

	public Integer getItemseq() {
		return this.repository().getInteger(UlErptmesetcinData.Itemseq);
	}

	public UlErptmesetcinData setItemseq(Integer Itemseq) {
		this.repository().set(UlErptmesetcinData.Itemseq, Itemseq);
		return this;
	}

	public String getItemno() {
		return this.repository().getString(UlErptmesetcinData.Itemno);
	}

	public UlErptmesetcinData setItemno(String Itemno) {
		this.repository().set(UlErptmesetcinData.Itemno, Itemno);
		return this;
	}

	public Double getInqty() {
		return this.repository().getDouble(UlErptmesetcinData.Inqty);
	}

	public UlErptmesetcinData setInqty(Double Inqty) {
		this.repository().set(UlErptmesetcinData.Inqty, Inqty);
		return this;
	}

	public Integer getWhseq() {
		return this.repository().getInteger(UlErptmesetcinData.Whseq);
	}

	public UlErptmesetcinData setWhseq(Integer Whseq) {
		this.repository().set(UlErptmesetcinData.Whseq, Whseq);
		return this;
	}

	public Integer getEmpseq() {
		return this.repository().getInteger(UlErptmesetcinData.Empseq);
	}

	public UlErptmesetcinData setEmpseq(Integer Empseq) {
		this.repository().set(UlErptmesetcinData.Empseq, Empseq);
		return this;
	}

	public Integer getEtcinseq() {
		return this.repository().getInteger(UlErptmesetcinData.Etcinseq);
	}

	public UlErptmesetcinData setEtcinseq(Integer Etcinseq) {
		this.repository().set(UlErptmesetcinData.Etcinseq, Etcinseq);
		return this;
	}

	public Integer getEtcinserl() {
		return this.repository().getInteger(UlErptmesetcinData.Etcinserl);
	}

	public UlErptmesetcinData setEtcinserl(Integer Etcinserl) {
		this.repository().set(UlErptmesetcinData.Etcinserl, Etcinserl);
		return this;
	}

	public String getProgstatus() {
		return this.repository().getString(UlErptmesetcinData.Progstatus);
	}

	public UlErptmesetcinData setProgstatus(String Progstatus) {
		this.repository().set(UlErptmesetcinData.Progstatus, Progstatus);
		return this;
	}

	public String getProgresult() {
		return this.repository().getString(UlErptmesetcinData.Progresult);
	}

	public UlErptmesetcinData setProgresult(String Progresult) {
		this.repository().set(UlErptmesetcinData.Progresult, Progresult);
		return this;
	}

	public String getTossyn() {
		return this.repository().getString(UlErptmesetcinData.Tossyn);
	}

	public UlErptmesetcinData setTossyn(String Tossyn) {
		this.repository().set(UlErptmesetcinData.Tossyn, Tossyn);
		return this;
	}

	public String getInterfacetxnhistkey() {
		return this.repository().getString(UlErptmesetcinData.Interfacetxnhistkey);
	}

	public UlErptmesetcinData setInterfacetxnhistkey(String Interfacetxnhistkey) {
		this.repository().set(UlErptmesetcinData.Interfacetxnhistkey, Interfacetxnhistkey);
		return this;
	}

	public String getRemark() {
		return this.repository().getString(UlErptmesetcinData.Remark);
	}

	public UlErptmesetcinData setRemark(String Remark) {
		this.repository().set(UlErptmesetcinData.Remark, Remark);
		return this;
	}


}