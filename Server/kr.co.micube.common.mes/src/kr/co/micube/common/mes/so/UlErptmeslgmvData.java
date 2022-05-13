package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlErptmeslgmvData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Crtdatetime = "CRTDATETIME";

	public static final String Recvyn = "RECVYN";

	public static final String Recvdatetime = "RECVDATETIME";

	public static final String Mvdate = "MVDATE";

	public static final String Itemseq = "ITEMSEQ";

	public static final String Itemno = "ITEMNO";

	public static final String Mvqty = "MVQTY";

	public static final String Outwhseq = "OUTWHSEQ";

	public static final String Inwhseq = "INWHSEQ";

	public static final String Mvtype = "MVTYPE";

	public static final String Empseq = "EMPSEQ";

	public static final String Ismatyn = "ISMATYN";

	public static final String Mvseq = "MVSEQ";

	public static final String Mvserl = "MVSERL";

	public static final String Progstatus = "PROGSTATUS";

	public static final String Progresult = "PROGRESULT";

	public static final String Tossyn = "TOSSYN";

	public static final String Interfacetxnhistkey = "INTERFACETXNHISTKEY";

	public static final String Remark = "REMARK";
	
	public static final String Lotno = "LOTNO";

	public UlErptmeslgmvData() {
		this(new UlErptmeslgmvKey()); 
	}

	public UlErptmeslgmvData(UlErptmeslgmvKey key) {
		super(key, "UlErptmeslgmv");
	}


	public Date getCrtdatetime() {
		return this.repository().getDate(UlErptmeslgmvData.Crtdatetime);
	}

	public UlErptmeslgmvData setCrtdatetime(Date Crtdatetime) {
		this.repository().set(UlErptmeslgmvData.Crtdatetime, Crtdatetime);
		return this;
	}

	public String getRecvyn() {
		return this.repository().getString(UlErptmeslgmvData.Recvyn);
	}

	public UlErptmeslgmvData setRecvyn(String Recvyn) {
		this.repository().set(UlErptmeslgmvData.Recvyn, Recvyn);
		return this;
	}

	public Date getRecvdatetime() {
		return this.repository().getDate(UlErptmeslgmvData.Recvdatetime);
	}

	public UlErptmeslgmvData setRecvdatetime(Date Recvdatetime) {
		this.repository().set(UlErptmeslgmvData.Recvdatetime, Recvdatetime);
		return this;
	}

	public String getMvdate() {
		return this.repository().getString(UlErptmeslgmvData.Mvdate);
	}

	public UlErptmeslgmvData setMvdate(String Mvdate) {
		this.repository().set(UlErptmeslgmvData.Mvdate, Mvdate);
		return this;
	}

	public Integer getItemseq() {
		return this.repository().getInteger(UlErptmeslgmvData.Itemseq);
	}

	public UlErptmeslgmvData setItemseq(Integer Itemseq) {
		this.repository().set(UlErptmeslgmvData.Itemseq, Itemseq);
		return this;
	}

	public String getItemno() {
		return this.repository().getString(UlErptmeslgmvData.Itemno);
	}

	public UlErptmeslgmvData setItemno(String Itemno) {
		this.repository().set(UlErptmeslgmvData.Itemno, Itemno);
		return this;
	}

	public Double getMvqty() {
		return this.repository().getDouble(UlErptmeslgmvData.Mvqty);
	}

	public UlErptmeslgmvData setMvqty(Double Mvqty) {
		this.repository().set(UlErptmeslgmvData.Mvqty, Mvqty);
		return this;
	}

	public Integer getOutwhseq() {
		return this.repository().getInteger(UlErptmeslgmvData.Outwhseq);
	}

	public UlErptmeslgmvData setOutwhseq(Integer Outwhseq) {
		this.repository().set(UlErptmeslgmvData.Outwhseq, Outwhseq);
		return this;
	}

	public Integer getInwhseq() {
		return this.repository().getInteger(UlErptmeslgmvData.Inwhseq);
	}

	public UlErptmeslgmvData setInwhseq(Integer Inwhseq) {
		this.repository().set(UlErptmeslgmvData.Inwhseq, Inwhseq);
		return this;
	}

	public Integer getMvtype() {
		return this.repository().getInteger(UlErptmeslgmvData.Mvtype);
	}

	public UlErptmeslgmvData setMvtype(Integer Mvtype) {
		this.repository().set(UlErptmeslgmvData.Mvtype, Mvtype);
		return this;
	}

	public Integer getEmpseq() {
		return this.repository().getInteger(UlErptmeslgmvData.Empseq);
	}

	public UlErptmeslgmvData setEmpseq(Integer Empseq) {
		this.repository().set(UlErptmeslgmvData.Empseq, Empseq);
		return this;
	}

	public String getIsmatyn() {
		return this.repository().getString(UlErptmeslgmvData.Ismatyn);
	}

	public UlErptmeslgmvData setIsmatyn(String Ismatyn) {
		this.repository().set(UlErptmeslgmvData.Ismatyn, Ismatyn);
		return this;
	}

	public Integer getMvseq() {
		return this.repository().getInteger(UlErptmeslgmvData.Mvseq);
	}

	public UlErptmeslgmvData setMvseq(Integer Mvseq) {
		this.repository().set(UlErptmeslgmvData.Mvseq, Mvseq);
		return this;
	}

	public Integer getMvserl() {
		return this.repository().getInteger(UlErptmeslgmvData.Mvserl);
	}

	public UlErptmeslgmvData setMvserl(Integer Mvserl) {
		this.repository().set(UlErptmeslgmvData.Mvserl, Mvserl);
		return this;
	}

	public String getProgstatus() {
		return this.repository().getString(UlErptmeslgmvData.Progstatus);
	}

	public UlErptmeslgmvData setProgstatus(String Progstatus) {
		this.repository().set(UlErptmeslgmvData.Progstatus, Progstatus);
		return this;
	}

	public String getProgresult() {
		return this.repository().getString(UlErptmeslgmvData.Progresult);
	}

	public UlErptmeslgmvData setProgresult(String Progresult) {
		this.repository().set(UlErptmeslgmvData.Progresult, Progresult);
		return this;
	}

	public String getTossyn() {
		return this.repository().getString(UlErptmeslgmvData.Tossyn);
	}

	public UlErptmeslgmvData setTossyn(String Tossyn) {
		this.repository().set(UlErptmeslgmvData.Tossyn, Tossyn);
		return this;
	}

	public String getInterfacetxnhistkey() {
		return this.repository().getString(UlErptmeslgmvData.Interfacetxnhistkey);
	}

	public UlErptmeslgmvData setInterfacetxnhistkey(String Interfacetxnhistkey) {
		this.repository().set(UlErptmeslgmvData.Interfacetxnhistkey, Interfacetxnhistkey);
		return this;
	}

	public String getRemark() {
		return this.repository().getString(UlErptmeslgmvData.Remark);
	}

	public UlErptmeslgmvData setRemark(String Remark) {
		this.repository().set(UlErptmeslgmvData.Remark, Remark);
		return this;
	}

	public String getLotno() {
		return this.repository().getString(UlErptmeslgmvData.Lotno);
	}

	public UlErptmeslgmvData setLotno(String Lotno) {
		this.repository().set(UlErptmeslgmvData.Lotno, Lotno);
		return this;
	}

}