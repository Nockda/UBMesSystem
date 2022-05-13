package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlErptmesspudelvData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Crtdatetime = "CRTDATETIME";

	public static final String Recvyn = "RECVYN";

	public static final String Recvdatetime = "RECVDATETIME";

	public static final String Delvseq = "DELVSEQ";

	public static final String Delvserl = "DELVSERL";

	public static final String Delvno = "DELVNO";

	public static final String Indate = "INDATE";

	public static final String Itemseq = "ITEMSEQ";

	public static final String Itemno = "ITEMNO";

	public static final String Delvqty = "DELVQTY";

	public static final String Okqty = "OKQTY";

	public static final String Badqty = "BADQTY";

	public static final String Whseq = "WHSEQ";

	public static final String Remark = "REMARK";

	public static final String Empseq = "EMPSEQ";

	public static final String Lotno = "LOTNO";

	public static final String Delvinseq = "DELVINSEQ";

	public static final String Delvinserl = "DELVINSERL";

	public static final String Progstatus = "PROGSTATUS";

	public static final String Progresult = "PROGRESULT";

	public static final String Tossyn = "TOSSYN";

	public static final String Interfacetxnhistkey = "INTERFACETXNHISTKEY";

	public UlErptmesspudelvData() {
		this(new UlErptmesspudelvKey()); 
	}

	public UlErptmesspudelvData(UlErptmesspudelvKey key) {
		super(key, "UlErptmesspudelv");
	}


	public Date getCrtdatetime() {
		return this.repository().getDate(UlErptmesspudelvData.Crtdatetime);
	}

	public UlErptmesspudelvData setCrtdatetime(Date Crtdatetime) {
		this.repository().set(UlErptmesspudelvData.Crtdatetime, Crtdatetime);
		return this;
	}

	public String getRecvyn() {
		return this.repository().getString(UlErptmesspudelvData.Recvyn);
	}

	public UlErptmesspudelvData setRecvyn(String Recvyn) {
		this.repository().set(UlErptmesspudelvData.Recvyn, Recvyn);
		return this;
	}

	public Date getRecvdatetime() {
		return this.repository().getDate(UlErptmesspudelvData.Recvdatetime);
	}

	public UlErptmesspudelvData setRecvdatetime(Date Recvdatetime) {
		this.repository().set(UlErptmesspudelvData.Recvdatetime, Recvdatetime);
		return this;
	}

	public Integer getDelvseq() {
		return this.repository().getInteger(UlErptmesspudelvData.Delvseq);
	}

	public UlErptmesspudelvData setDelvseq(Integer Delvseq) {
		this.repository().set(UlErptmesspudelvData.Delvseq, Delvseq);
		return this;
	}

	public Integer getDelvserl() {
		return this.repository().getInteger(UlErptmesspudelvData.Delvserl);
	}

	public UlErptmesspudelvData setDelvserl(Integer Delvserl) {
		this.repository().set(UlErptmesspudelvData.Delvserl, Delvserl);
		return this;
	}

	public String getDelvno() {
		return this.repository().getString(UlErptmesspudelvData.Delvno);
	}

	public UlErptmesspudelvData setDelvno(String Delvno) {
		this.repository().set(UlErptmesspudelvData.Delvno, Delvno);
		return this;
	}

	public String getIndate() {
		return this.repository().getString(UlErptmesspudelvData.Indate);
	}

	public UlErptmesspudelvData setIndate(String Indate) {
		this.repository().set(UlErptmesspudelvData.Indate, Indate);
		return this;
	}

	public Integer getItemseq() {
		return this.repository().getInteger(UlErptmesspudelvData.Itemseq);
	}

	public UlErptmesspudelvData setItemseq(Integer Itemseq) {
		this.repository().set(UlErptmesspudelvData.Itemseq, Itemseq);
		return this;
	}

	public String getItemno() {
		return this.repository().getString(UlErptmesspudelvData.Itemno);
	}

	public UlErptmesspudelvData setItemno(String Itemno) {
		this.repository().set(UlErptmesspudelvData.Itemno, Itemno);
		return this;
	}

	public Double getDelvqty() {
		return this.repository().getDouble(UlErptmesspudelvData.Delvqty);
	}

	public UlErptmesspudelvData setDelvqty(Double Delvqty) {
		this.repository().set(UlErptmesspudelvData.Delvqty, Delvqty);
		return this;
	}

	public Double getOkqty() {
		return this.repository().getDouble(UlErptmesspudelvData.Okqty);
	}

	public UlErptmesspudelvData setOkqty(Double Okqty) {
		this.repository().set(UlErptmesspudelvData.Okqty, Okqty);
		return this;
	}

	public Double getBadqty() {
		return this.repository().getDouble(UlErptmesspudelvData.Badqty);
	}

	public UlErptmesspudelvData setBadqty(Double Badqty) {
		this.repository().set(UlErptmesspudelvData.Badqty, Badqty);
		return this;
	}

	public Integer getWhseq() {
		return this.repository().getInteger(UlErptmesspudelvData.Whseq);
	}

	public UlErptmesspudelvData setWhseq(Integer Whseq) {
		this.repository().set(UlErptmesspudelvData.Whseq, Whseq);
		return this;
	}

	public String getRemark() {
		return this.repository().getString(UlErptmesspudelvData.Remark);
	}

	public UlErptmesspudelvData setRemark(String Remark) {
		this.repository().set(UlErptmesspudelvData.Remark, Remark);
		return this;
	}

	public Integer getEmpseq() {
		return this.repository().getInteger(UlErptmesspudelvData.Empseq);
	}

	public UlErptmesspudelvData setEmpseq(Integer Empseq) {
		this.repository().set(UlErptmesspudelvData.Empseq, Empseq);
		return this;
	}

	public String getLotno() {
		return this.repository().getString(UlErptmesspudelvData.Lotno);
	}

	public UlErptmesspudelvData setLotno(String Lotno) {
		this.repository().set(UlErptmesspudelvData.Lotno, Lotno);
		return this;
	}

	public Integer getDelvinseq() {
		return this.repository().getInteger(UlErptmesspudelvData.Delvinseq);
	}

	public UlErptmesspudelvData setDelvinseq(Integer Delvinseq) {
		this.repository().set(UlErptmesspudelvData.Delvinseq, Delvinseq);
		return this;
	}

	public Integer getDelvinserl() {
		return this.repository().getInteger(UlErptmesspudelvData.Delvinserl);
	}

	public UlErptmesspudelvData setDelvinserl(Integer Delvinserl) {
		this.repository().set(UlErptmesspudelvData.Delvinserl, Delvinserl);
		return this;
	}

	public String getProgstatus() {
		return this.repository().getString(UlErptmesspudelvData.Progstatus);
	}

	public UlErptmesspudelvData setProgstatus(String Progstatus) {
		this.repository().set(UlErptmesspudelvData.Progstatus, Progstatus);
		return this;
	}

	public String getProgresult() {
		return this.repository().getString(UlErptmesspudelvData.Progresult);
	}

	public UlErptmesspudelvData setProgresult(String Progresult) {
		this.repository().set(UlErptmesspudelvData.Progresult, Progresult);
		return this;
	}

	public String getTossyn() {
		return this.repository().getString(UlErptmesspudelvData.Tossyn);
	}

	public UlErptmesspudelvData setTossyn(String Tossyn) {
		this.repository().set(UlErptmesspudelvData.Tossyn, Tossyn);
		return this;
	}

	public String getInterfacetxnhistkey() {
		return this.repository().getString(UlErptmesspudelvData.Interfacetxnhistkey);
	}

	public UlErptmesspudelvData setInterfacetxnhistkey(String Interfacetxnhistkey) {
		this.repository().set(UlErptmesspudelvData.Interfacetxnhistkey, Interfacetxnhistkey);
		return this;
	}


}