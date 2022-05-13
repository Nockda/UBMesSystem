package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlErptmesmateetcoutData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Meskey = "MESKEY";

	public static final String Messeq = "MESSEQ";

	public static final String Audtype = "AUDType";

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

	public UlErptmesmateetcoutData() {
		this(new UlErptmesmateetcoutKey()); 
	}

	public UlErptmesmateetcoutData(UlErptmesmateetcoutKey key) {
		super(key, "UlErptmesmateetcout");
	}


	public String getMeskey() {
		return this.repository().getString(UlErptmesmateetcoutData.Meskey);
	}

	public UlErptmesmateetcoutData setMeskey(String Meskey) {
		this.repository().set(UlErptmesmateetcoutData.Meskey, Meskey);
		return this;
	}

	public Integer getMesseq() {
		return this.repository().getInteger(UlErptmesmateetcoutData.Messeq);
	}

	public UlErptmesmateetcoutData setMesseq(Integer Messeq) {
		this.repository().set(UlErptmesmateetcoutData.Messeq, Messeq);
		return this;
	}

	public String getAudtype() {
		return this.repository().getString(UlErptmesmateetcoutData.Audtype);
	}

	public UlErptmesmateetcoutData setAudtype(String Audtype) {
		this.repository().set(UlErptmesmateetcoutData.Audtype, Audtype);
		return this;
	}

	public Date getCrtdatetime() {
		return this.repository().getDate(UlErptmesmateetcoutData.Crtdatetime);
	}

	public UlErptmesmateetcoutData setCrtdatetime(Date Crtdatetime) {
		this.repository().set(UlErptmesmateetcoutData.Crtdatetime, Crtdatetime);
		return this;
	}

	public String getRecvyn() {
		return this.repository().getString(UlErptmesmateetcoutData.Recvyn);
	}

	public UlErptmesmateetcoutData setRecvyn(String Recvyn) {
		this.repository().set(UlErptmesmateetcoutData.Recvyn, Recvyn);
		return this;
	}

	public Date getRecvdatetime() {
		return this.repository().getDate(UlErptmesmateetcoutData.Recvdatetime);
	}

	public UlErptmesmateetcoutData setRecvdatetime(Date Recvdatetime) {
		this.repository().set(UlErptmesmateetcoutData.Recvdatetime, Recvdatetime);
		return this;
	}

	public String getOutdate() {
		return this.repository().getString(UlErptmesmateetcoutData.Outdate);
	}

	public UlErptmesmateetcoutData setOutdate(String Outdate) {
		this.repository().set(UlErptmesmateetcoutData.Outdate, Outdate);
		return this;
	}

	public Integer getEtcouttype() {
		return this.repository().getInteger(UlErptmesmateetcoutData.Etcouttype);
	}

	public UlErptmesmateetcoutData setEtcouttype(Integer Etcouttype) {
		this.repository().set(UlErptmesmateetcoutData.Etcouttype, Etcouttype);
		return this;
	}

	public Integer getItemseq() {
		return this.repository().getInteger(UlErptmesmateetcoutData.Itemseq);
	}

	public UlErptmesmateetcoutData setItemseq(Integer Itemseq) {
		this.repository().set(UlErptmesmateetcoutData.Itemseq, Itemseq);
		return this;
	}

	public String getItemno() {
		return this.repository().getString(UlErptmesmateetcoutData.Itemno);
	}

	public UlErptmesmateetcoutData setItemno(String Itemno) {
		this.repository().set(UlErptmesmateetcoutData.Itemno, Itemno);
		return this;
	}

	public Double getOutqty() {
		return this.repository().getDouble(UlErptmesmateetcoutData.Outqty);
	}

	public UlErptmesmateetcoutData setOutqty(Double Outqty) {
		this.repository().set(UlErptmesmateetcoutData.Outqty, Outqty);
		return this;
	}

	public Integer getWhseq() {
		return this.repository().getInteger(UlErptmesmateetcoutData.Whseq);
	}

	public UlErptmesmateetcoutData setWhseq(Integer Whseq) {
		this.repository().set(UlErptmesmateetcoutData.Whseq, Whseq);
		return this;
	}

	public Integer getEmpseq() {
		return this.repository().getInteger(UlErptmesmateetcoutData.Empseq);
	}

	public UlErptmesmateetcoutData setEmpseq(Integer Empseq) {
		this.repository().set(UlErptmesmateetcoutData.Empseq, Empseq);
		return this;
	}

	public Integer getEtcoutseq() {
		return this.repository().getInteger(UlErptmesmateetcoutData.Etcoutseq);
	}

	public UlErptmesmateetcoutData setEtcoutseq(Integer Etcoutseq) {
		this.repository().set(UlErptmesmateetcoutData.Etcoutseq, Etcoutseq);
		return this;
	}

	public Integer getEtcoutserl() {
		return this.repository().getInteger(UlErptmesmateetcoutData.Etcoutserl);
	}

	public UlErptmesmateetcoutData setEtcoutserl(Integer Etcoutserl) {
		this.repository().set(UlErptmesmateetcoutData.Etcoutserl, Etcoutserl);
		return this;
	}

	public String getProgstatus() {
		return this.repository().getString(UlErptmesmateetcoutData.Progstatus);
	}

	public UlErptmesmateetcoutData setProgstatus(String Progstatus) {
		this.repository().set(UlErptmesmateetcoutData.Progstatus, Progstatus);
		return this;
	}

	public String getProgresult() {
		return this.repository().getString(UlErptmesmateetcoutData.Progresult);
	}

	public UlErptmesmateetcoutData setProgresult(String Progresult) {
		this.repository().set(UlErptmesmateetcoutData.Progresult, Progresult);
		return this;
	}

	public String getTossyn() {
		return this.repository().getString(UlErptmesmateetcoutData.Tossyn);
	}

	public UlErptmesmateetcoutData setTossyn(String Tossyn) {
		this.repository().set(UlErptmesmateetcoutData.Tossyn, Tossyn);
		return this;
	}

	public String getInterfacetxnhistkey() {
		return this.repository().getString(UlErptmesmateetcoutData.Interfacetxnhistkey);
	}

	public UlErptmesmateetcoutData setInterfacetxnhistkey(String Interfacetxnhistkey) {
		this.repository().set(UlErptmesmateetcoutData.Interfacetxnhistkey, Interfacetxnhistkey);
		return this;
	}

	public String getRemark() {
		return this.repository().getString(UlErptmesmateetcoutData.Remark);
	}

	public UlErptmesmateetcoutData setRemark(String Remark) {
		this.repository().set(UlErptmesmateetcoutData.Remark, Remark);
		return this;
	}


}