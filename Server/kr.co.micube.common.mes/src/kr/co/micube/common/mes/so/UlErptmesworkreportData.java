package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlErptmesworkreportData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Meskey = "MESKEY";

	public static final String Messeq = "MESSEQ";

	public static final String Audtype = "AUDType";

	public static final String Crtdatetime = "CRTDATETIME";

	public static final String Recvyn = "RECVYN";

	public static final String Recvdatetime = "RECVDATETIME";

	public static final String Workdate = "WORKDATE";

	public static final String Workorderseq = "WORKORDERSEQ";

	public static final String Workorderserl = "WORKORDERSERL";

	public static final String Workorderno = "WORKORDERNO";

	public static final String Whseq = "WHSEQ";

	public static final String Deptseq = "DEPTSEQ";

	public static final String Empseq = "EMPSEQ";

	public static final String Itemseq = "ITEMSEQ";

	public static final String Itemno = "ITEMNO";

	public static final String Unitseq = "UNITSEQ";

	public static final String Prodokqty = "PRODOKQTY";

	public static final String Prodbadqty = "PRODBADQTY";

	public static final String Fieldwhseq = "FIELDWHSEQ";

	public static final String Remark = "REMARK";

	public static final String Workstarttime = "WORKSTARTTIME";

	public static final String Workendtime = "WORKENDTIME";

	public static final String Workhour = "WORKHOUR";

	public static final String Workerqty = "WORKERQTY";

	public static final String Workreportseq = "WORKREPORTSEQ";

	public static final String Progstatus = "PROGSTATUS";

	public static final String Progresult = "PROGRESULT";

	public static final String Tossyn = "TOSSYN";

	public static final String Interfacetxnhistkey = "INTERFACETXNHISTKEY";

	public UlErptmesworkreportData() {
		this(new UlErptmesworkreportKey()); 
	}

	public UlErptmesworkreportData(UlErptmesworkreportKey key) {
		super(key, "UlErptmesworkreport");
	}


	public String getMeskey() {
		return this.repository().getString(UlErptmesworkreportData.Meskey);
	}

	public UlErptmesworkreportData setMeskey(String Meskey) {
		this.repository().set(UlErptmesworkreportData.Meskey, Meskey);
		return this;
	}

	public Integer getMesseq() {
		return this.repository().getInteger(UlErptmesworkreportData.Messeq);
	}

	public UlErptmesworkreportData setMesseq(Integer Messeq) {
		this.repository().set(UlErptmesworkreportData.Messeq, Messeq);
		return this;
	}

	public String getAudtype() {
		return this.repository().getString(UlErptmesworkreportData.Audtype);
	}

	public UlErptmesworkreportData setAudtype(String Audtype) {
		this.repository().set(UlErptmesworkreportData.Audtype, Audtype);
		return this;
	}

	public Date getCrtdatetime() {
		return this.repository().getDate(UlErptmesworkreportData.Crtdatetime);
	}

	public UlErptmesworkreportData setCrtdatetime(Date Crtdatetime) {
		this.repository().set(UlErptmesworkreportData.Crtdatetime, Crtdatetime);
		return this;
	}

	public String getRecvyn() {
		return this.repository().getString(UlErptmesworkreportData.Recvyn);
	}

	public UlErptmesworkreportData setRecvyn(String Recvyn) {
		this.repository().set(UlErptmesworkreportData.Recvyn, Recvyn);
		return this;
	}

	public Date getRecvdatetime() {
		return this.repository().getDate(UlErptmesworkreportData.Recvdatetime);
	}

	public UlErptmesworkreportData setRecvdatetime(Date Recvdatetime) {
		this.repository().set(UlErptmesworkreportData.Recvdatetime, Recvdatetime);
		return this;
	}

	public String getWorkdate() {
		return this.repository().getString(UlErptmesworkreportData.Workdate);
	}

	public UlErptmesworkreportData setWorkdate(String Workdate) {
		this.repository().set(UlErptmesworkreportData.Workdate, Workdate);
		return this;
	}

	public Integer getWorkorderseq() {
		return this.repository().getInteger(UlErptmesworkreportData.Workorderseq);
	}

	public UlErptmesworkreportData setWorkorderseq(Integer Workorderseq) {
		this.repository().set(UlErptmesworkreportData.Workorderseq, Workorderseq);
		return this;
	}

	public Integer getWorkorderserl() {
		return this.repository().getInteger(UlErptmesworkreportData.Workorderserl);
	}

	public UlErptmesworkreportData setWorkorderserl(Integer Workorderserl) {
		this.repository().set(UlErptmesworkreportData.Workorderserl, Workorderserl);
		return this;
	}

	public String getWorkorderno() {
		return this.repository().getString(UlErptmesworkreportData.Workorderno);
	}

	public UlErptmesworkreportData setWorkorderno(String Workorderno) {
		this.repository().set(UlErptmesworkreportData.Workorderno, Workorderno);
		return this;
	}

	public Integer getWhseq() {
		return this.repository().getInteger(UlErptmesworkreportData.Whseq);
	}

	public UlErptmesworkreportData setWhseq(Integer Whseq) {
		this.repository().set(UlErptmesworkreportData.Whseq, Whseq);
		return this;
	}

	public Integer getDeptseq() {
		return this.repository().getInteger(UlErptmesworkreportData.Deptseq);
	}

	public UlErptmesworkreportData setDeptseq(Integer Deptseq) {
		this.repository().set(UlErptmesworkreportData.Deptseq, Deptseq);
		return this;
	}

	public Integer getEmpseq() {
		return this.repository().getInteger(UlErptmesworkreportData.Empseq);
	}

	public UlErptmesworkreportData setEmpseq(Integer Empseq) {
		this.repository().set(UlErptmesworkreportData.Empseq, Empseq);
		return this;
	}

	public Integer getItemseq() {
		return this.repository().getInteger(UlErptmesworkreportData.Itemseq);
	}

	public UlErptmesworkreportData setItemseq(Integer Itemseq) {
		this.repository().set(UlErptmesworkreportData.Itemseq, Itemseq);
		return this;
	}

	public String getItemno() {
		return this.repository().getString(UlErptmesworkreportData.Itemno);
	}

	public UlErptmesworkreportData setItemno(String Itemno) {
		this.repository().set(UlErptmesworkreportData.Itemno, Itemno);
		return this;
	}

	public Integer getUnitseq() {
		return this.repository().getInteger(UlErptmesworkreportData.Unitseq);
	}

	public UlErptmesworkreportData setUnitseq(Integer Unitseq) {
		this.repository().set(UlErptmesworkreportData.Unitseq, Unitseq);
		return this;
	}

	public Double getProdokqty() {
		return this.repository().getDouble(UlErptmesworkreportData.Prodokqty);
	}

	public UlErptmesworkreportData setProdokqty(Double Prodokqty) {
		this.repository().set(UlErptmesworkreportData.Prodokqty, Prodokqty);
		return this;
	}

	public Double getProdbadqty() {
		return this.repository().getDouble(UlErptmesworkreportData.Prodbadqty);
	}

	public UlErptmesworkreportData setProdbadqty(Double Prodbadqty) {
		this.repository().set(UlErptmesworkreportData.Prodbadqty, Prodbadqty);
		return this;
	}

	public Integer getFieldwhseq() {
		return this.repository().getInteger(UlErptmesworkreportData.Fieldwhseq);
	}

	public UlErptmesworkreportData setFieldwhseq(Integer Fieldwhseq) {
		this.repository().set(UlErptmesworkreportData.Fieldwhseq, Fieldwhseq);
		return this;
	}

	public String getRemark() {
		return this.repository().getString(UlErptmesworkreportData.Remark);
	}

	public UlErptmesworkreportData setRemark(String Remark) {
		this.repository().set(UlErptmesworkreportData.Remark, Remark);
		return this;
	}

	public String getWorkstarttime() {
		return this.repository().getString(UlErptmesworkreportData.Workstarttime);
	}

	public UlErptmesworkreportData setWorkstarttime(String Workstarttime) {
		this.repository().set(UlErptmesworkreportData.Workstarttime, Workstarttime);
		return this;
	}

	public String getWorkendtime() {
		return this.repository().getString(UlErptmesworkreportData.Workendtime);
	}

	public UlErptmesworkreportData setWorkendtime(String Workendtime) {
		this.repository().set(UlErptmesworkreportData.Workendtime, Workendtime);
		return this;
	}

	public Double getWorkhour() {
		return this.repository().getDouble(UlErptmesworkreportData.Workhour);
	}

	public UlErptmesworkreportData setWorkhour(Double Workhour) {
		this.repository().set(UlErptmesworkreportData.Workhour, Workhour);
		return this;
	}

	public Double getWorkerqty() {
		return this.repository().getDouble(UlErptmesworkreportData.Workerqty);
	}

	public UlErptmesworkreportData setWorkerqty(Double Workerqty) {
		this.repository().set(UlErptmesworkreportData.Workerqty, Workerqty);
		return this;
	}

	public Integer getWorkreportseq() {
		return this.repository().getInteger(UlErptmesworkreportData.Workreportseq);
	}

	public UlErptmesworkreportData setWorkreportseq(Integer Workreportseq) {
		this.repository().set(UlErptmesworkreportData.Workreportseq, Workreportseq);
		return this;
	}

	public String getProgstatus() {
		return this.repository().getString(UlErptmesworkreportData.Progstatus);
	}

	public UlErptmesworkreportData setProgstatus(String Progstatus) {
		this.repository().set(UlErptmesworkreportData.Progstatus, Progstatus);
		return this;
	}

	public String getProgresult() {
		return this.repository().getString(UlErptmesworkreportData.Progresult);
	}

	public UlErptmesworkreportData setProgresult(String Progresult) {
		this.repository().set(UlErptmesworkreportData.Progresult, Progresult);
		return this;
	}

	public String getTossyn() {
		return this.repository().getString(UlErptmesworkreportData.Tossyn);
	}

	public UlErptmesworkreportData setTossyn(String Tossyn) {
		this.repository().set(UlErptmesworkreportData.Tossyn, Tossyn);
		return this;
	}

	public String getInterfacetxnhistkey() {
		return this.repository().getString(UlErptmesworkreportData.Interfacetxnhistkey);
	}

	public UlErptmesworkreportData setInterfacetxnhistkey(String Interfacetxnhistkey) {
		this.repository().set(UlErptmesworkreportData.Interfacetxnhistkey, Interfacetxnhistkey);
		return this;
	}


}