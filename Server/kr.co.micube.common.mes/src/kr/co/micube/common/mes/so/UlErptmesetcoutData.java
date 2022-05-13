package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlErptmesetcoutData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Crtdatetime = "CRTDATETIME";

	public static final String Recvyn = "RECVYN";

	public static final String Recvdatetime = "RECVDATETIME";

	public static final String Outdate = "OUTDATE";

	public static final String Etcouttype = "ETCOUTTYPE";

	public static final String Itemseq = "ITEMSEQ";

	public static final String Itemno = "ITEMNO";

	public static final String Outqty = "OUTQTY";

	public static final String Whseq = "WHSEQ";

	public static final String Empseq = "EMPSEQ";

	public static final String Etcoutseq = "ETCOUTSEQ";

	public static final String Etcoutserl = "ETCOUTSERL";

	public static final String Progstatus = "PROGSTATUS";

	public static final String Progresult = "PROGRESULT";

	public static final String Tossyn = "TOSSYN";

	public static final String Interfacetxnhistkey = "INTERFACETXNHISTKEY";

	public static final String Remark = "REMARK";

	public UlErptmesetcoutData() {
		this(new UlErptmesetcoutKey()); 
	}

	public UlErptmesetcoutData(UlErptmesetcoutKey key) {
		super(key, "UlErptmesetcout");
	}


	public Date getCrtdatetime() {
		return this.repository().getDate(UlErptmesetcoutData.Crtdatetime);
	}

	public UlErptmesetcoutData setCrtdatetime(Date Crtdatetime) {
		this.repository().set(UlErptmesetcoutData.Crtdatetime, Crtdatetime);
		return this;
	}

	public String getRecvyn() {
		return this.repository().getString(UlErptmesetcoutData.Recvyn);
	}

	public UlErptmesetcoutData setRecvyn(String Recvyn) {
		this.repository().set(UlErptmesetcoutData.Recvyn, Recvyn);
		return this;
	}

	public Date getRecvdatetime() {
		return this.repository().getDate(UlErptmesetcoutData.Recvdatetime);
	}

	public UlErptmesetcoutData setRecvdatetime(Date Recvdatetime) {
		this.repository().set(UlErptmesetcoutData.Recvdatetime, Recvdatetime);
		return this;
	}

	public String getOutdate() {
		return this.repository().getString(UlErptmesetcoutData.Outdate);
	}

	public UlErptmesetcoutData setOutdate(String Outdate) {
		this.repository().set(UlErptmesetcoutData.Outdate, Outdate);
		return this;
	}

	public Integer getEtcouttype() {
		return this.repository().getInteger(UlErptmesetcoutData.Etcouttype);
	}

	public UlErptmesetcoutData setEtcouttype(Integer Etcouttype) {
		this.repository().set(UlErptmesetcoutData.Etcouttype, Etcouttype);
		return this;
	}

	public Integer getItemseq() {
		return this.repository().getInteger(UlErptmesetcoutData.Itemseq);
	}

	public UlErptmesetcoutData setItemseq(Integer Itemseq) {
		this.repository().set(UlErptmesetcoutData.Itemseq, Itemseq);
		return this;
	}

	public String getItemno() {
		return this.repository().getString(UlErptmesetcoutData.Itemno);
	}

	public UlErptmesetcoutData setItemno(String Itemno) {
		this.repository().set(UlErptmesetcoutData.Itemno, Itemno);
		return this;
	}

	public Double getOutqty() {
		return this.repository().getDouble(UlErptmesetcoutData.Outqty);
	}

	public UlErptmesetcoutData setOutqty(Double Outqty) {
		this.repository().set(UlErptmesetcoutData.Outqty, Outqty);
		return this;
	}

	public Integer getWhseq() {
		return this.repository().getInteger(UlErptmesetcoutData.Whseq);
	}

	public UlErptmesetcoutData setWhseq(Integer Whseq) {
		this.repository().set(UlErptmesetcoutData.Whseq, Whseq);
		return this;
	}

	public Integer getEmpseq() {
		return this.repository().getInteger(UlErptmesetcoutData.Empseq);
	}

	public UlErptmesetcoutData setEmpseq(Integer Empseq) {
		this.repository().set(UlErptmesetcoutData.Empseq, Empseq);
		return this;
	}

	public Integer getEtcoutseq() {
		return this.repository().getInteger(UlErptmesetcoutData.Etcoutseq);
	}

	public UlErptmesetcoutData setEtcoutseq(Integer Etcoutseq) {
		this.repository().set(UlErptmesetcoutData.Etcoutseq, Etcoutseq);
		return this;
	}

	public Integer getEtcoutserl() {
		return this.repository().getInteger(UlErptmesetcoutData.Etcoutserl);
	}

	public UlErptmesetcoutData setEtcoutserl(Integer Etcoutserl) {
		this.repository().set(UlErptmesetcoutData.Etcoutserl, Etcoutserl);
		return this;
	}

	public String getProgstatus() {
		return this.repository().getString(UlErptmesetcoutData.Progstatus);
	}

	public UlErptmesetcoutData setProgstatus(String Progstatus) {
		this.repository().set(UlErptmesetcoutData.Progstatus, Progstatus);
		return this;
	}

	public String getProgresult() {
		return this.repository().getString(UlErptmesetcoutData.Progresult);
	}

	public UlErptmesetcoutData setProgresult(String Progresult) {
		this.repository().set(UlErptmesetcoutData.Progresult, Progresult);
		return this;
	}

	public String getTossyn() {
		return this.repository().getString(UlErptmesetcoutData.Tossyn);
	}

	public UlErptmesetcoutData setTossyn(String Tossyn) {
		this.repository().set(UlErptmesetcoutData.Tossyn, Tossyn);
		return this;
	}

	public String getInterfacetxnhistkey() {
		return this.repository().getString(UlErptmesetcoutData.Interfacetxnhistkey);
	}

	public UlErptmesetcoutData setInterfacetxnhistkey(String Interfacetxnhistkey) {
		this.repository().set(UlErptmesetcoutData.Interfacetxnhistkey, Interfacetxnhistkey);
		return this;
	}

	public String getRemark() {
		return this.repository().getString(UlErptmesetcoutData.Remark);
	}

	public UlErptmesetcoutData setRemark(String Remark) {
		this.repository().set(UlErptmesetcoutData.Remark, Remark);
		return this;
	}


}