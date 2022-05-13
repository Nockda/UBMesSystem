package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlDefectHistoryData extends SQLData {

	public static final String Docid = "DOCID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Publishdate = "PUBLISHDATE";

	public static final String Progressstate = "PROGRESSSTATE";

	public static final String Claimnumber = "CLAIMNUMBER";

	public static final String Departmentid = "DEPARTMENTID";

	public static final String Detectid = "DETECTID";

	public static final String Itemid = "ITEMID";

	public static final String Companyid = "COMPANYID";

	public static final String Drawingnumber = "DRAWINGNUMBER";

	public static final String Defectdesc = "DEFECTDESC";

	public static final String Largecategory = "LARGECATEGORY";

	public static final String Smallcategroy = "SMALLCATEGROY";

	public static final String Actiontype = "ACTIONTYPE";

	public static final String Completestate = "COMPLETESTATE";

	public static final String Paymentdate = "PAYMENTDATE";

	public static final String Paymentqty = "PAYMENTQTY";

	public static final String Unitprice = "UNITPRICE";

	public static final String Defectdate = "DEFECTDATE";

	public static final String Defectqty = "DEFECTQTY";

	public static final String Defectprice = "DEFECTPRICE";

	public static final String Recurrcnt = "RECURRCNT";

	public static final String Receiptdate = "RECEIPTDATE";

	public static final String Deliverydate = "DELIVERYDATE";

	public static final String Completedate = "COMPLETEDATE";

	public static final String Completeday = "COMPLETEDAY";

	public static final String Exportdate = "EXPORTDATE";

	public static final String Actiondate = "ACTIONDATE";

	public static final String Actionday = "ACTIONDAY";

	public static final String Reasondesc = "REASONDESC";

	public static final String Actiondesc = "ACTIONDESC";

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

	public static final String Findid = "FINDID";

	public UlDefectHistoryData() {
		this(new UlDefectHistoryKey()); 
	}

	public UlDefectHistoryData(UlDefectHistoryKey key) {
		super(key, "UlDefectHistory");
	}


	public Date getPublishdate() {
		return this.repository().getDate(UlDefectHistoryData.Publishdate);
	}

	public UlDefectHistoryData setPublishdate(Date Publishdate) {
		this.repository().set(UlDefectHistoryData.Publishdate, Publishdate);
		return this;
	}

	public String getProgressstate() {
		return this.repository().getString(UlDefectHistoryData.Progressstate);
	}

	public UlDefectHistoryData setProgressstate(String Progressstate) {
		this.repository().set(UlDefectHistoryData.Progressstate, Progressstate);
		return this;
	}

	public String getClaimnumber() {
		return this.repository().getString(UlDefectHistoryData.Claimnumber);
	}

	public UlDefectHistoryData setClaimnumber(String Claimnumber) {
		this.repository().set(UlDefectHistoryData.Claimnumber, Claimnumber);
		return this;
	}

	public String getDepartmentid() {
		return this.repository().getString(UlDefectHistoryData.Departmentid);
	}

	public UlDefectHistoryData setDepartmentid(String Departmentid) {
		this.repository().set(UlDefectHistoryData.Departmentid, Departmentid);
		return this;
	}

	public String getDetectid() {
		return this.repository().getString(UlDefectHistoryData.Detectid);
	}

	public UlDefectHistoryData setDetectid(String Detectid) {
		this.repository().set(UlDefectHistoryData.Detectid, Detectid);
		return this;
	}

	public String getItemid() {
		return this.repository().getString(UlDefectHistoryData.Itemid);
	}

	public UlDefectHistoryData setItemid(String Itemid) {
		this.repository().set(UlDefectHistoryData.Itemid, Itemid);
		return this;
	}

	public String getCompanyid() {
		return this.repository().getString(UlDefectHistoryData.Companyid);
	}

	public UlDefectHistoryData setCompanyid(String Companyid) {
		this.repository().set(UlDefectHistoryData.Companyid, Companyid);
		return this;
	}

	public String getDrawingnumber() {
		return this.repository().getString(UlDefectHistoryData.Drawingnumber);
	}

	public UlDefectHistoryData setDrawingnumber(String Drawingnumber) {
		this.repository().set(UlDefectHistoryData.Drawingnumber, Drawingnumber);
		return this;
	}

	public String getDefectdesc() {
		return this.repository().getString(UlDefectHistoryData.Defectdesc);
	}

	public UlDefectHistoryData setDefectdesc(String Defectdesc) {
		this.repository().set(UlDefectHistoryData.Defectdesc, Defectdesc);
		return this;
	}

	public String getLargecategory() {
		return this.repository().getString(UlDefectHistoryData.Largecategory);
	}

	public UlDefectHistoryData setLargecategory(String Largecategory) {
		this.repository().set(UlDefectHistoryData.Largecategory, Largecategory);
		return this;
	}

	public String getSmallcategroy() {
		return this.repository().getString(UlDefectHistoryData.Smallcategroy);
	}

	public UlDefectHistoryData setSmallcategroy(String Smallcategroy) {
		this.repository().set(UlDefectHistoryData.Smallcategroy, Smallcategroy);
		return this;
	}

	public String getActiontype() {
		return this.repository().getString(UlDefectHistoryData.Actiontype);
	}

	public UlDefectHistoryData setActiontype(String Actiontype) {
		this.repository().set(UlDefectHistoryData.Actiontype, Actiontype);
		return this;
	}

	public String getCompletestate() {
		return this.repository().getString(UlDefectHistoryData.Completestate);
	}

	public UlDefectHistoryData setCompletestate(String Completestate) {
		this.repository().set(UlDefectHistoryData.Completestate, Completestate);
		return this;
	}

	public Date getPaymentdate() {
		return this.repository().getDate(UlDefectHistoryData.Paymentdate);
	}

	public UlDefectHistoryData setPaymentdate(Date Paymentdate) {
		this.repository().set(UlDefectHistoryData.Paymentdate, Paymentdate);
		return this;
	}

	public Double getPaymentqty() {
		return this.repository().getDouble(UlDefectHistoryData.Paymentqty);
	}

	public UlDefectHistoryData setPaymentqty(Double Paymentqty) {
		this.repository().set(UlDefectHistoryData.Paymentqty, Paymentqty);
		return this;
	}

	public Double getUnitprice() {
		return this.repository().getDouble(UlDefectHistoryData.Unitprice);
	}

	public UlDefectHistoryData setUnitprice(Double Unitprice) {
		this.repository().set(UlDefectHistoryData.Unitprice, Unitprice);
		return this;
	}

	public Date getDefectdate() {
		return this.repository().getDate(UlDefectHistoryData.Defectdate);
	}

	public UlDefectHistoryData setDefectdate(Date Defectdate) {
		this.repository().set(UlDefectHistoryData.Defectdate, Defectdate);
		return this;
	}

	public Double getDefectqty() {
		return this.repository().getDouble(UlDefectHistoryData.Defectqty);
	}

	public UlDefectHistoryData setDefectqty(Double Defectqty) {
		this.repository().set(UlDefectHistoryData.Defectqty, Defectqty);
		return this;
	}

	public Double getDefectprice() {
		return this.repository().getDouble(UlDefectHistoryData.Defectprice);
	}

	public UlDefectHistoryData setDefectprice(Double Defectprice) {
		this.repository().set(UlDefectHistoryData.Defectprice, Defectprice);
		return this;
	}

	public Integer getRecurrcnt() {
		return this.repository().getInteger(UlDefectHistoryData.Recurrcnt);
	}

	public UlDefectHistoryData setRecurrcnt(Integer Recurrcnt) {
		this.repository().set(UlDefectHistoryData.Recurrcnt, Recurrcnt);
		return this;
	}

	public Date getReceiptdate() {
		return this.repository().getDate(UlDefectHistoryData.Receiptdate);
	}

	public UlDefectHistoryData setReceiptdate(Date Receiptdate) {
		this.repository().set(UlDefectHistoryData.Receiptdate, Receiptdate);
		return this;
	}

	public Date getDeliverydate() {
		return this.repository().getDate(UlDefectHistoryData.Deliverydate);
	}

	public UlDefectHistoryData setDeliverydate(Date Deliverydate) {
		this.repository().set(UlDefectHistoryData.Deliverydate, Deliverydate);
		return this;
	}

	public Date getCompletedate() {
		return this.repository().getDate(UlDefectHistoryData.Completedate);
	}

	public UlDefectHistoryData setCompletedate(Date Completedate) {
		this.repository().set(UlDefectHistoryData.Completedate, Completedate);
		return this;
	}

	public Integer getCompleteday() {
		return this.repository().getInteger(UlDefectHistoryData.Completeday);
	}

	public UlDefectHistoryData setCompleteday(Integer Completeday) {
		this.repository().set(UlDefectHistoryData.Completeday, Completeday);
		return this;
	}

	public Date getExportdate() {
		return this.repository().getDate(UlDefectHistoryData.Exportdate);
	}

	public UlDefectHistoryData setExportdate(Date Exportdate) {
		this.repository().set(UlDefectHistoryData.Exportdate, Exportdate);
		return this;
	}

	public Date getActiondate() {
		return this.repository().getDate(UlDefectHistoryData.Actiondate);
	}

	public UlDefectHistoryData setActiondate(Date Actiondate) {
		this.repository().set(UlDefectHistoryData.Actiondate, Actiondate);
		return this;
	}

	public Integer getActionday() {
		return this.repository().getInteger(UlDefectHistoryData.Actionday);
	}

	public UlDefectHistoryData setActionday(Integer Actionday) {
		this.repository().set(UlDefectHistoryData.Actionday, Actionday);
		return this;
	}

	public String getReasondesc() {
		return this.repository().getString(UlDefectHistoryData.Reasondesc);
	}

	public UlDefectHistoryData setReasondesc(String Reasondesc) {
		this.repository().set(UlDefectHistoryData.Reasondesc, Reasondesc);
		return this;
	}

	public String getActiondesc() {
		return this.repository().getString(UlDefectHistoryData.Actiondesc);
	}

	public UlDefectHistoryData setActiondesc(String Actiondesc) {
		this.repository().set(UlDefectHistoryData.Actiondesc, Actiondesc);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlDefectHistoryData.Description);
	}

	public UlDefectHistoryData setDescription(String Description) {
		this.repository().set(UlDefectHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlDefectHistoryData.Creator);
	}

	public UlDefectHistoryData setCreator(String Creator) {
		this.repository().set(UlDefectHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlDefectHistoryData.Createdtime);
	}

	public UlDefectHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(UlDefectHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlDefectHistoryData.Modifier);
	}

	public UlDefectHistoryData setModifier(String Modifier) {
		this.repository().set(UlDefectHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlDefectHistoryData.Modifiedtime);
	}

	public UlDefectHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlDefectHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlDefectHistoryData.Txnid);
	}

	public UlDefectHistoryData setTxnid(String Txnid) {
		this.repository().set(UlDefectHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlDefectHistoryData.Txnuser);
	}

	public UlDefectHistoryData setTxnuser(String Txnuser) {
		this.repository().set(UlDefectHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlDefectHistoryData.Txntime);
	}

	public UlDefectHistoryData setTxntime(Date Txntime) {
		this.repository().set(UlDefectHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlDefectHistoryData.Txngrouphistkey);
	}

	public UlDefectHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlDefectHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlDefectHistoryData.Txnreasoncodeclass);
	}

	public UlDefectHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlDefectHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlDefectHistoryData.Txnreasoncode);
	}

	public UlDefectHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlDefectHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlDefectHistoryData.Txncomment);
	}

	public UlDefectHistoryData setTxncomment(String Txncomment) {
		this.repository().set(UlDefectHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlDefectHistoryData.Validstate);
	}

	public UlDefectHistoryData setValidstate(String Validstate) {
		this.repository().set(UlDefectHistoryData.Validstate, Validstate);
		return this;
	}

	public String getFindid() {
		return this.repository().getString(UlDefectHistoryData.Findid);
	}

	public UlDefectHistoryData setFindid(String Findid) {
		this.repository().set(UlDefectHistoryData.Findid, Findid);
		return this;
	}


}