package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlErptmesmateetcinData extends SQLData {

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

	public UlErptmesmateetcinData() {
		this(new UlErptmesmateetcinKey()); 
	}

	public UlErptmesmateetcinData(UlErptmesmateetcinKey key) {
		super(key, "UlErptmesmateetcin");
	}


	public String getMeskey() {
		return this.repository().getString(UlErptmesmateetcinData.Meskey);
	}

	public UlErptmesmateetcinData setMeskey(String Meskey) {
		this.repository().set(UlErptmesmateetcinData.Meskey, Meskey);
		return this;
	}

	public Integer getMesseq() {
		return this.repository().getInteger(UlErptmesmateetcinData.Messeq);
	}

	public UlErptmesmateetcinData setMesseq(Integer Messeq) {
		this.repository().set(UlErptmesmateetcinData.Messeq, Messeq);
		return this;
	}

	public String getAudtype() {
		return this.repository().getString(UlErptmesmateetcinData.Audtype);
	}

	public UlErptmesmateetcinData setAudtype(String Audtype) {
		this.repository().set(UlErptmesmateetcinData.Audtype, Audtype);
		return this;
	}

	public Date getCrtdatetime() {
		return this.repository().getDate(UlErptmesmateetcinData.Crtdatetime);
	}

	public UlErptmesmateetcinData setCrtdatetime(Date Crtdatetime) {
		this.repository().set(UlErptmesmateetcinData.Crtdatetime, Crtdatetime);
		return this;
	}

	public String getRecvyn() {
		return this.repository().getString(UlErptmesmateetcinData.Recvyn);
	}

	public UlErptmesmateetcinData setRecvyn(String Recvyn) {
		this.repository().set(UlErptmesmateetcinData.Recvyn, Recvyn);
		return this;
	}

	public Date getRecvdatetime() {
		return this.repository().getDate(UlErptmesmateetcinData.Recvdatetime);
	}

	public UlErptmesmateetcinData setRecvdatetime(Date Recvdatetime) {
		this.repository().set(UlErptmesmateetcinData.Recvdatetime, Recvdatetime);
		return this;
	}

	public String getIndate() {
		return this.repository().getString(UlErptmesmateetcinData.Indate);
	}

	public UlErptmesmateetcinData setIndate(String Indate) {
		this.repository().set(UlErptmesmateetcinData.Indate, Indate);
		return this;
	}

	public Integer getEtcintype() {
		return this.repository().getInteger(UlErptmesmateetcinData.Etcintype);
	}

	public UlErptmesmateetcinData setEtcintype(Integer Etcintype) {
		this.repository().set(UlErptmesmateetcinData.Etcintype, Etcintype);
		return this;
	}

	public Integer getItemseq() {
		return this.repository().getInteger(UlErptmesmateetcinData.Itemseq);
	}

	public UlErptmesmateetcinData setItemseq(Integer Itemseq) {
		this.repository().set(UlErptmesmateetcinData.Itemseq, Itemseq);
		return this;
	}

	public String getItemno() {
		return this.repository().getString(UlErptmesmateetcinData.Itemno);
	}

	public UlErptmesmateetcinData setItemno(String Itemno) {
		this.repository().set(UlErptmesmateetcinData.Itemno, Itemno);
		return this;
	}

	public Double getInqty() {
		return this.repository().getDouble(UlErptmesmateetcinData.Inqty);
	}

	public UlErptmesmateetcinData setInqty(Double Inqty) {
		this.repository().set(UlErptmesmateetcinData.Inqty, Inqty);
		return this;
	}

	public Integer getWhseq() {
		return this.repository().getInteger(UlErptmesmateetcinData.Whseq);
	}

	public UlErptmesmateetcinData setWhseq(Integer Whseq) {
		this.repository().set(UlErptmesmateetcinData.Whseq, Whseq);
		return this;
	}

	public Integer getEmpseq() {
		return this.repository().getInteger(UlErptmesmateetcinData.Empseq);
	}

	public UlErptmesmateetcinData setEmpseq(Integer Empseq) {
		this.repository().set(UlErptmesmateetcinData.Empseq, Empseq);
		return this;
	}

	public Integer getEtcinseq() {
		return this.repository().getInteger(UlErptmesmateetcinData.Etcinseq);
	}

	public UlErptmesmateetcinData setEtcinseq(Integer Etcinseq) {
		this.repository().set(UlErptmesmateetcinData.Etcinseq, Etcinseq);
		return this;
	}

	public Integer getEtcinserl() {
		return this.repository().getInteger(UlErptmesmateetcinData.Etcinserl);
	}

	public UlErptmesmateetcinData setEtcinserl(Integer Etcinserl) {
		this.repository().set(UlErptmesmateetcinData.Etcinserl, Etcinserl);
		return this;
	}

	public String getProgstatus() {
		return this.repository().getString(UlErptmesmateetcinData.Progstatus);
	}

	public UlErptmesmateetcinData setProgstatus(String Progstatus) {
		this.repository().set(UlErptmesmateetcinData.Progstatus, Progstatus);
		return this;
	}

	public String getProgresult() {
		return this.repository().getString(UlErptmesmateetcinData.Progresult);
	}

	public UlErptmesmateetcinData setProgresult(String Progresult) {
		this.repository().set(UlErptmesmateetcinData.Progresult, Progresult);
		return this;
	}

	public String getTossyn() {
		return this.repository().getString(UlErptmesmateetcinData.Tossyn);
	}

	public UlErptmesmateetcinData setTossyn(String Tossyn) {
		this.repository().set(UlErptmesmateetcinData.Tossyn, Tossyn);
		return this;
	}

	public String getInterfacetxnhistkey() {
		return this.repository().getString(UlErptmesmateetcinData.Interfacetxnhistkey);
	}

	public UlErptmesmateetcinData setInterfacetxnhistkey(String Interfacetxnhistkey) {
		this.repository().set(UlErptmesmateetcinData.Interfacetxnhistkey, Interfacetxnhistkey);
		return this;
	}

	public String getRemark() {
		return this.repository().getString(UlErptmesmateetcinData.Remark);
	}

	public UlErptmesmateetcinData setRemark(String Remark) {
		this.repository().set(UlErptmesmateetcinData.Remark, Remark);
		return this;
	}


}