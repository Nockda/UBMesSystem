package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlCapaData extends SQLData {

	public static final String Docid = "DOCID";

	public static final String Claimnumber = "CLAIMNUMBER";

	public static final String Publishdate = "PUBLISHDATE";

	public static final String Defectdocid = "DEFECTDOCID";

	public static final String Reqdepartmentid = "REQDEPARTMENTID";

	public static final String Requser = "REQUSER";

	public static final String Publishtype = "PUBLISHTYPE";

	public static final String Reqconfdate = "REQCONFDATE";

	public static final String Claimtype = "CLAIMTYPE";

	public static final String Fixedcost = "FIXEDCOST";

	public static final String Variablecost = "VARIABLECOST";

	public static final String Progressstate = "PROGRESSSTATE";

	public static final String Customerid = "CUSTOMERID";

	public static final String Claimdate = "CLAIMDATE";

	public static final String Xnumber = "XNUMBER";

	public static final String Claimdesc = "CLAIMDESC";

	public static final String Progressdesc = "PROGRESSDESC";

	public static final String Recieptdate = "RECIEPTDATE";

	public static final String Completedate = "COMPLETEDATE";

	public static final String Completeday = "COMPLETEDAY";

	public static final String Actiondate = "ACTIONDATE";

	public static final String Actionday = "ACTIONDAY";

	public static final String Indate = "INDATE";

	public static final String Confirmuser = "CONFIRMUSER";

	public static final String Responsedate = "RESPONSEDATE";

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

	public UlCapaData() {
		this(new UlCapaKey()); 
	}

	public UlCapaData(UlCapaKey key) {
		super(key, "UlCapa");
	}


	public String getClaimnumber() {
		return this.repository().getString(UlCapaData.Claimnumber);
	}

	public UlCapaData setClaimnumber(String Claimnumber) {
		this.repository().set(UlCapaData.Claimnumber, Claimnumber);
		return this;
	}

	public Date getPublishdate() {
		return this.repository().getDate(UlCapaData.Publishdate);
	}

	public UlCapaData setPublishdate(Date Publishdate) {
		this.repository().set(UlCapaData.Publishdate, Publishdate);
		return this;
	}

	public String getDefectdocid() {
		return this.repository().getString(UlCapaData.Defectdocid);
	}

	public UlCapaData setDefectdocid(String Defectdocid) {
		this.repository().set(UlCapaData.Defectdocid, Defectdocid);
		return this;
	}

	public String getReqdepartmentid() {
		return this.repository().getString(UlCapaData.Reqdepartmentid);
	}

	public UlCapaData setReqdepartmentid(String Reqdepartmentid) {
		this.repository().set(UlCapaData.Reqdepartmentid, Reqdepartmentid);
		return this;
	}

	public String getRequser() {
		return this.repository().getString(UlCapaData.Requser);
	}

	public UlCapaData setRequser(String Requser) {
		this.repository().set(UlCapaData.Requser, Requser);
		return this;
	}

	public String getPublishtype() {
		return this.repository().getString(UlCapaData.Publishtype);
	}

	public UlCapaData setPublishtype(String Publishtype) {
		this.repository().set(UlCapaData.Publishtype, Publishtype);
		return this;
	}

	public Date getReqconfdate() {
		return this.repository().getDate(UlCapaData.Reqconfdate);
	}

	public UlCapaData setReqconfdate(Date Reqconfdate) {
		this.repository().set(UlCapaData.Reqconfdate, Reqconfdate);
		return this;
	}

	public String getClaimtype() {
		return this.repository().getString(UlCapaData.Claimtype);
	}

	public UlCapaData setClaimtype(String Claimtype) {
		this.repository().set(UlCapaData.Claimtype, Claimtype);
		return this;
	}

	public Double getFixedcost() {
		return this.repository().getDouble(UlCapaData.Fixedcost);
	}

	public UlCapaData setFixedcost(Double Fixedcost) {
		this.repository().set(UlCapaData.Fixedcost, Fixedcost);
		return this;
	}

	public Double getVariablecost() {
		return this.repository().getDouble(UlCapaData.Variablecost);
	}

	public UlCapaData setVariablecost(Double Variablecost) {
		this.repository().set(UlCapaData.Variablecost, Variablecost);
		return this;
	}

	public String getProgressstate() {
		return this.repository().getString(UlCapaData.Progressstate);
	}

	public UlCapaData setProgressstate(String Progressstate) {
		this.repository().set(UlCapaData.Progressstate, Progressstate);
		return this;
	}

	public String getCustomerid() {
		return this.repository().getString(UlCapaData.Customerid);
	}

	public UlCapaData setCustomerid(String Customerid) {
		this.repository().set(UlCapaData.Customerid, Customerid);
		return this;
	}

	public Date getClaimdate() {
		return this.repository().getDate(UlCapaData.Claimdate);
	}

	public UlCapaData setClaimdate(Date Claimdate) {
		this.repository().set(UlCapaData.Claimdate, Claimdate);
		return this;
	}

	public String getXnumber() {
		return this.repository().getString(UlCapaData.Xnumber);
	}

	public UlCapaData setXnumber(String Xnumber) {
		this.repository().set(UlCapaData.Xnumber, Xnumber);
		return this;
	}

	public String getClaimdesc() {
		return this.repository().getString(UlCapaData.Claimdesc);
	}

	public UlCapaData setClaimdesc(String Claimdesc) {
		this.repository().set(UlCapaData.Claimdesc, Claimdesc);
		return this;
	}

	public String getProgressdesc() {
		return this.repository().getString(UlCapaData.Progressdesc);
	}

	public UlCapaData setProgressdesc(String Progressdesc) {
		this.repository().set(UlCapaData.Progressdesc, Progressdesc);
		return this;
	}

	public Date getRecieptdate() {
		return this.repository().getDate(UlCapaData.Recieptdate);
	}

	public UlCapaData setRecieptdate(Date Recieptdate) {
		this.repository().set(UlCapaData.Recieptdate, Recieptdate);
		return this;
	}

	public Date getCompletedate() {
		return this.repository().getDate(UlCapaData.Completedate);
	}

	public UlCapaData setCompletedate(Date Completedate) {
		this.repository().set(UlCapaData.Completedate, Completedate);
		return this;
	}

	public Integer getCompleteday() {
		return this.repository().getInteger(UlCapaData.Completeday);
	}

	public UlCapaData setCompleteday(Integer Completeday) {
		this.repository().set(UlCapaData.Completeday, Completeday);
		return this;
	}

	public Date getActiondate() {
		return this.repository().getDate(UlCapaData.Actiondate);
	}

	public UlCapaData setActiondate(Date Actiondate) {
		this.repository().set(UlCapaData.Actiondate, Actiondate);
		return this;
	}

	public Integer getActionday() {
		return this.repository().getInteger(UlCapaData.Actionday);
	}

	public UlCapaData setActionday(Integer Actionday) {
		this.repository().set(UlCapaData.Actionday, Actionday);
		return this;
	}

	public Date getIndate() {
		return this.repository().getDate(UlCapaData.Indate);
	}

	public UlCapaData setIndate(Date Indate) {
		this.repository().set(UlCapaData.Indate, Indate);
		return this;
	}

	public String getConfirmuser() {
		return this.repository().getString(UlCapaData.Confirmuser);
	}

	public UlCapaData setConfirmuser(String Confirmuser) {
		this.repository().set(UlCapaData.Confirmuser, Confirmuser);
		return this;
	}

	public Integer getResponsedate() {
		return this.repository().getInteger(UlCapaData.Responsedate);
	}

	public UlCapaData setResponsedate(Integer Responsedate) {
		this.repository().set(UlCapaData.Responsedate, Responsedate);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlCapaData.Description);
	}

	public UlCapaData setDescription(String Description) {
		this.repository().set(UlCapaData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlCapaData.Creator);
	}

	public UlCapaData setCreator(String Creator) {
		this.repository().set(UlCapaData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlCapaData.Createdtime);
	}

	public UlCapaData setCreatedtime(Date Createdtime) {
		this.repository().set(UlCapaData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlCapaData.Modifier);
	}

	public UlCapaData setModifier(String Modifier) {
		this.repository().set(UlCapaData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlCapaData.Modifiedtime);
	}

	public UlCapaData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlCapaData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(UlCapaData.Lasttxnhistkey);
	}

	public UlCapaData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(UlCapaData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(UlCapaData.Lasttxnid);
	}

	public UlCapaData setLasttxnid(String Lasttxnid) {
		this.repository().set(UlCapaData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(UlCapaData.Lasttxnuser);
	}

	public UlCapaData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(UlCapaData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(UlCapaData.Lasttxntime);
	}

	public UlCapaData setLasttxntime(Date Lasttxntime) {
		this.repository().set(UlCapaData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(UlCapaData.Lasttxncomment);
	}

	public UlCapaData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(UlCapaData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlCapaData.Validstate);
	}

	public UlCapaData setValidstate(String Validstate) {
		this.repository().set(UlCapaData.Validstate, Validstate);
		return this;
	}


}