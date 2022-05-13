package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlErptmesmatoutData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Crtdatetime = "CRTDATETIME";

	public static final String Recvyn = "RECVYN";

	public static final String Recvdatetime = "RECVDATETIME";

	public static final String Outreqseq = "OUTREQSEQ";

	public static final String Outreqitemserl = "OUTREQITEMSERL";

	public static final String Outdate = "OUTDATE";

	public static final String Outwhseq = "OUTWHSEQ";

	public static final String Inwhseq = "INWHSEQ";

	public static final String Deptseq = "DEPTSEQ";

	public static final String Empseq = "EMPSEQ";

	public static final String Itemseq = "ITEMSEQ";

	public static final String Itemno = "ITEMNO";

	public static final String Unitseq = "UNITSEQ";

	public static final String Outqty = "OUTQTY";

	public static final String Matoutseq = "MATOUTSEQ";

	public static final String Matoutserl = "MATOUTSERL";

	public static final String Progstatus = "PROGSTATUS";

	public static final String Progresult = "PROGRESULT";

	public static final String Tossyn = "TOSSYN";

	public static final String Interfacetxnhistkey = "INTERFACETXNHISTKEY";

	public UlErptmesmatoutData() {
		this(new UlErptmesmatoutKey()); 
	}

	public UlErptmesmatoutData(UlErptmesmatoutKey key) {
		super(key, "UlErptmesmatout");
	}


	public Date getCrtdatetime() {
		return this.repository().getDate(UlErptmesmatoutData.Crtdatetime);
	}

	public UlErptmesmatoutData setCrtdatetime(Date Crtdatetime) {
		this.repository().set(UlErptmesmatoutData.Crtdatetime, Crtdatetime);
		return this;
	}

	public String getRecvyn() {
		return this.repository().getString(UlErptmesmatoutData.Recvyn);
	}

	public UlErptmesmatoutData setRecvyn(String Recvyn) {
		this.repository().set(UlErptmesmatoutData.Recvyn, Recvyn);
		return this;
	}

	public Date getRecvdatetime() {
		return this.repository().getDate(UlErptmesmatoutData.Recvdatetime);
	}

	public UlErptmesmatoutData setRecvdatetime(Date Recvdatetime) {
		this.repository().set(UlErptmesmatoutData.Recvdatetime, Recvdatetime);
		return this;
	}

	public Integer getOutreqseq() {
		return this.repository().getInteger(UlErptmesmatoutData.Outreqseq);
	}

	public UlErptmesmatoutData setOutreqseq(Integer Outreqseq) {
		this.repository().set(UlErptmesmatoutData.Outreqseq, Outreqseq);
		return this;
	}

	public Integer getOutreqitemserl() {
		return this.repository().getInteger(UlErptmesmatoutData.Outreqitemserl);
	}

	public UlErptmesmatoutData setOutreqitemserl(Integer Outreqitemserl) {
		this.repository().set(UlErptmesmatoutData.Outreqitemserl, Outreqitemserl);
		return this;
	}

	public String getOutdate() {
		return this.repository().getString(UlErptmesmatoutData.Outdate);
	}

	public UlErptmesmatoutData setOutdate(String Outdate) {
		this.repository().set(UlErptmesmatoutData.Outdate, Outdate);
		return this;
	}

	public Integer getOutwhseq() {
		return this.repository().getInteger(UlErptmesmatoutData.Outwhseq);
	}

	public UlErptmesmatoutData setOutwhseq(Integer Outwhseq) {
		this.repository().set(UlErptmesmatoutData.Outwhseq, Outwhseq);
		return this;
	}

	public Integer getInwhseq() {
		return this.repository().getInteger(UlErptmesmatoutData.Inwhseq);
	}

	public UlErptmesmatoutData setInwhseq(Integer Inwhseq) {
		this.repository().set(UlErptmesmatoutData.Inwhseq, Inwhseq);
		return this;
	}

	public Integer getDeptseq() {
		return this.repository().getInteger(UlErptmesmatoutData.Deptseq);
	}

	public UlErptmesmatoutData setDeptseq(Integer Deptseq) {
		this.repository().set(UlErptmesmatoutData.Deptseq, Deptseq);
		return this;
	}

	public Integer getEmpseq() {
		return this.repository().getInteger(UlErptmesmatoutData.Empseq);
	}

	public UlErptmesmatoutData setEmpseq(Integer Empseq) {
		this.repository().set(UlErptmesmatoutData.Empseq, Empseq);
		return this;
	}

	public Integer getItemseq() {
		return this.repository().getInteger(UlErptmesmatoutData.Itemseq);
	}

	public UlErptmesmatoutData setItemseq(Integer Itemseq) {
		this.repository().set(UlErptmesmatoutData.Itemseq, Itemseq);
		return this;
	}

	public String getItemno() {
		return this.repository().getString(UlErptmesmatoutData.Itemno);
	}

	public UlErptmesmatoutData setItemno(String Itemno) {
		this.repository().set(UlErptmesmatoutData.Itemno, Itemno);
		return this;
	}

	public Integer getUnitseq() {
		return this.repository().getInteger(UlErptmesmatoutData.Unitseq);
	}

	public UlErptmesmatoutData setUnitseq(Integer Unitseq) {
		this.repository().set(UlErptmesmatoutData.Unitseq, Unitseq);
		return this;
	}

	public Double getOutqty() {
		return this.repository().getDouble(UlErptmesmatoutData.Outqty);
	}

	public UlErptmesmatoutData setOutqty(Double Outqty) {
		this.repository().set(UlErptmesmatoutData.Outqty, Outqty);
		return this;
	}

	public Integer getMatoutseq() {
		return this.repository().getInteger(UlErptmesmatoutData.Matoutseq);
	}

	public UlErptmesmatoutData setMatoutseq(Integer Matoutseq) {
		this.repository().set(UlErptmesmatoutData.Matoutseq, Matoutseq);
		return this;
	}

	public Integer getMatoutserl() {
		return this.repository().getInteger(UlErptmesmatoutData.Matoutserl);
	}

	public UlErptmesmatoutData setMatoutserl(Integer Matoutserl) {
		this.repository().set(UlErptmesmatoutData.Matoutserl, Matoutserl);
		return this;
	}

	public String getProgstatus() {
		return this.repository().getString(UlErptmesmatoutData.Progstatus);
	}

	public UlErptmesmatoutData setProgstatus(String Progstatus) {
		this.repository().set(UlErptmesmatoutData.Progstatus, Progstatus);
		return this;
	}

	public String getProgresult() {
		return this.repository().getString(UlErptmesmatoutData.Progresult);
	}

	public UlErptmesmatoutData setProgresult(String Progresult) {
		this.repository().set(UlErptmesmatoutData.Progresult, Progresult);
		return this;
	}

	public String getTossyn() {
		return this.repository().getString(UlErptmesmatoutData.Tossyn);
	}

	public UlErptmesmatoutData setTossyn(String Tossyn) {
		this.repository().set(UlErptmesmatoutData.Tossyn, Tossyn);
		return this;
	}

	public String getInterfacetxnhistkey() {
		return this.repository().getString(UlErptmesmatoutData.Interfacetxnhistkey);
	}

	public UlErptmesmatoutData setInterfacetxnhistkey(String Interfacetxnhistkey) {
		this.repository().set(UlErptmesmatoutData.Interfacetxnhistkey, Interfacetxnhistkey);
		return this;
	}


}