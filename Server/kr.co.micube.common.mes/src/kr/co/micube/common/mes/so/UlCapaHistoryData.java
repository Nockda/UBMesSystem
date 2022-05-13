package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlCapaHistoryData extends SQLData {

	public static final String Docid = "DOCID";

	public static final String Txnhistkey = "TXNHISTKEY";

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

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public UlCapaHistoryData() {
		this(new UlCapaHistoryKey()); 
	}

	public UlCapaHistoryData(UlCapaHistoryKey key) {
		super(key, "UlCapaHistory");
	}


	public String getClaimnumber() {
		return this.repository().getString(UlCapaHistoryData.Claimnumber);
	}

	public UlCapaHistoryData setClaimnumber(String Claimnumber) {
		this.repository().set(UlCapaHistoryData.Claimnumber, Claimnumber);
		return this;
	}

	public Date getPublishdate() {
		return this.repository().getDate(UlCapaHistoryData.Publishdate);
	}

	public UlCapaHistoryData setPublishdate(Date Publishdate) {
		this.repository().set(UlCapaHistoryData.Publishdate, Publishdate);
		return this;
	}

	public String getDefectdocid() {
		return this.repository().getString(UlCapaHistoryData.Defectdocid);
	}

	public UlCapaHistoryData setDefectdocid(String Defectdocid) {
		this.repository().set(UlCapaHistoryData.Defectdocid, Defectdocid);
		return this;
	}

	public String getReqdepartmentid() {
		return this.repository().getString(UlCapaHistoryData.Reqdepartmentid);
	}

	public UlCapaHistoryData setReqdepartmentid(String Reqdepartmentid) {
		this.repository().set(UlCapaHistoryData.Reqdepartmentid, Reqdepartmentid);
		return this;
	}

	public String getRequser() {
		return this.repository().getString(UlCapaHistoryData.Requser);
	}

	public UlCapaHistoryData setRequser(String Requser) {
		this.repository().set(UlCapaHistoryData.Requser, Requser);
		return this;
	}

	public String getPublishtype() {
		return this.repository().getString(UlCapaHistoryData.Publishtype);
	}

	public UlCapaHistoryData setPublishtype(String Publishtype) {
		this.repository().set(UlCapaHistoryData.Publishtype, Publishtype);
		return this;
	}

	public Date getReqconfdate() {
		return this.repository().getDate(UlCapaHistoryData.Reqconfdate);
	}

	public UlCapaHistoryData setReqconfdate(Date Reqconfdate) {
		this.repository().set(UlCapaHistoryData.Reqconfdate, Reqconfdate);
		return this;
	}

	public String getClaimtype() {
		return this.repository().getString(UlCapaHistoryData.Claimtype);
	}

	public UlCapaHistoryData setClaimtype(String Claimtype) {
		this.repository().set(UlCapaHistoryData.Claimtype, Claimtype);
		return this;
	}

	public Double getFixedcost() {
		return this.repository().getDouble(UlCapaHistoryData.Fixedcost);
	}

	public UlCapaHistoryData setFixedcost(Double Fixedcost) {
		this.repository().set(UlCapaHistoryData.Fixedcost, Fixedcost);
		return this;
	}

	public Double getVariablecost() {
		return this.repository().getDouble(UlCapaHistoryData.Variablecost);
	}

	public UlCapaHistoryData setVariablecost(Double Variablecost) {
		this.repository().set(UlCapaHistoryData.Variablecost, Variablecost);
		return this;
	}

	public String getProgressstate() {
		return this.repository().getString(UlCapaHistoryData.Progressstate);
	}

	public UlCapaHistoryData setProgressstate(String Progressstate) {
		this.repository().set(UlCapaHistoryData.Progressstate, Progressstate);
		return this;
	}

	public String getCustomerid() {
		return this.repository().getString(UlCapaHistoryData.Customerid);
	}

	public UlCapaHistoryData setCustomerid(String Customerid) {
		this.repository().set(UlCapaHistoryData.Customerid, Customerid);
		return this;
	}

	public Date getClaimdate() {
		return this.repository().getDate(UlCapaHistoryData.Claimdate);
	}

	public UlCapaHistoryData setClaimdate(Date Claimdate) {
		this.repository().set(UlCapaHistoryData.Claimdate, Claimdate);
		return this;
	}

	public String getXnumber() {
		return this.repository().getString(UlCapaHistoryData.Xnumber);
	}

	public UlCapaHistoryData setXnumber(String Xnumber) {
		this.repository().set(UlCapaHistoryData.Xnumber, Xnumber);
		return this;
	}

	public String getClaimdesc() {
		return this.repository().getString(UlCapaHistoryData.Claimdesc);
	}

	public UlCapaHistoryData setClaimdesc(String Claimdesc) {
		this.repository().set(UlCapaHistoryData.Claimdesc, Claimdesc);
		return this;
	}

	public String getProgressdesc() {
		return this.repository().getString(UlCapaHistoryData.Progressdesc);
	}

	public UlCapaHistoryData setProgressdesc(String Progressdesc) {
		this.repository().set(UlCapaHistoryData.Progressdesc, Progressdesc);
		return this;
	}

	public Date getRecieptdate() {
		return this.repository().getDate(UlCapaHistoryData.Recieptdate);
	}

	public UlCapaHistoryData setRecieptdate(Date Recieptdate) {
		this.repository().set(UlCapaHistoryData.Recieptdate, Recieptdate);
		return this;
	}

	public Date getCompletedate() {
		return this.repository().getDate(UlCapaHistoryData.Completedate);
	}

	public UlCapaHistoryData setCompletedate(Date Completedate) {
		this.repository().set(UlCapaHistoryData.Completedate, Completedate);
		return this;
	}

	public Integer getCompleteday() {
		return this.repository().getInteger(UlCapaHistoryData.Completeday);
	}

	public UlCapaHistoryData setCompleteday(Integer Completeday) {
		this.repository().set(UlCapaHistoryData.Completeday, Completeday);
		return this;
	}

	public Date getActiondate() {
		return this.repository().getDate(UlCapaHistoryData.Actiondate);
	}

	public UlCapaHistoryData setActiondate(Date Actiondate) {
		this.repository().set(UlCapaHistoryData.Actiondate, Actiondate);
		return this;
	}

	public Integer getActionday() {
		return this.repository().getInteger(UlCapaHistoryData.Actionday);
	}

	public UlCapaHistoryData setActionday(Integer Actionday) {
		this.repository().set(UlCapaHistoryData.Actionday, Actionday);
		return this;
	}

	public Date getIndate() {
		return this.repository().getDate(UlCapaHistoryData.Indate);
	}

	public UlCapaHistoryData setIndate(Date Indate) {
		this.repository().set(UlCapaHistoryData.Indate, Indate);
		return this;
	}

	public String getConfirmuser() {
		return this.repository().getString(UlCapaHistoryData.Confirmuser);
	}

	public UlCapaHistoryData setConfirmuser(String Confirmuser) {
		this.repository().set(UlCapaHistoryData.Confirmuser, Confirmuser);
		return this;
	}

	public Integer getResponsedate() {
		return this.repository().getInteger(UlCapaHistoryData.Responsedate);
	}

	public UlCapaHistoryData setResponsedate(Integer Responsedate) {
		this.repository().set(UlCapaHistoryData.Responsedate, Responsedate);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlCapaHistoryData.Description);
	}

	public UlCapaHistoryData setDescription(String Description) {
		this.repository().set(UlCapaHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlCapaHistoryData.Creator);
	}

	public UlCapaHistoryData setCreator(String Creator) {
		this.repository().set(UlCapaHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlCapaHistoryData.Createdtime);
	}

	public UlCapaHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(UlCapaHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlCapaHistoryData.Modifier);
	}

	public UlCapaHistoryData setModifier(String Modifier) {
		this.repository().set(UlCapaHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlCapaHistoryData.Modifiedtime);
	}

	public UlCapaHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlCapaHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlCapaHistoryData.Txnid);
	}

	public UlCapaHistoryData setTxnid(String Txnid) {
		this.repository().set(UlCapaHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlCapaHistoryData.Txnuser);
	}

	public UlCapaHistoryData setTxnuser(String Txnuser) {
		this.repository().set(UlCapaHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlCapaHistoryData.Txntime);
	}

	public UlCapaHistoryData setTxntime(Date Txntime) {
		this.repository().set(UlCapaHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlCapaHistoryData.Txngrouphistkey);
	}

	public UlCapaHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlCapaHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlCapaHistoryData.Txnreasoncodeclass);
	}

	public UlCapaHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlCapaHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlCapaHistoryData.Txnreasoncode);
	}

	public UlCapaHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlCapaHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlCapaHistoryData.Txncomment);
	}

	public UlCapaHistoryData setTxncomment(String Txncomment) {
		this.repository().set(UlCapaHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlCapaHistoryData.Validstate);
	}

	public UlCapaHistoryData setValidstate(String Validstate) {
		this.repository().set(UlCapaHistoryData.Validstate, Validstate);
		return this;
	}


}