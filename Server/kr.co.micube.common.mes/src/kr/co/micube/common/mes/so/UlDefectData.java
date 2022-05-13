package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlDefectData extends SQLData {

	public static final String Docid = "DOCID";

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

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Lasttxnid = "LASTTXNID";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public static final String Findid = "FINDID";

	public UlDefectData() {
		this(new UlDefectKey()); 
	}

	public UlDefectData(UlDefectKey key) {
		super(key, "UlDefect");
	}


	public Date getPublishdate() {
		return this.repository().getDate(UlDefectData.Publishdate);
	}

	public UlDefectData setPublishdate(Date Publishdate) {
		this.repository().set(UlDefectData.Publishdate, Publishdate);
		return this;
	}

	public String getProgressstate() {
		return this.repository().getString(UlDefectData.Progressstate);
	}

	public UlDefectData setProgressstate(String Progressstate) {
		this.repository().set(UlDefectData.Progressstate, Progressstate);
		return this;
	}

	public String getClaimnumber() {
		return this.repository().getString(UlDefectData.Claimnumber);
	}

	public UlDefectData setClaimnumber(String Claimnumber) {
		this.repository().set(UlDefectData.Claimnumber, Claimnumber);
		return this;
	}

	public String getDepartmentid() {
		return this.repository().getString(UlDefectData.Departmentid);
	}

	public UlDefectData setDepartmentid(String Departmentid) {
		this.repository().set(UlDefectData.Departmentid, Departmentid);
		return this;
	}

	public String getDetectid() {
		return this.repository().getString(UlDefectData.Detectid);
	}

	public UlDefectData setDetectid(String Detectid) {
		this.repository().set(UlDefectData.Detectid, Detectid);
		return this;
	}

	public String getItemid() {
		return this.repository().getString(UlDefectData.Itemid);
	}

	public UlDefectData setItemid(String Itemid) {
		this.repository().set(UlDefectData.Itemid, Itemid);
		return this;
	}

	public String getCompanyid() {
		return this.repository().getString(UlDefectData.Companyid);
	}

	public UlDefectData setCompanyid(String Companyid) {
		this.repository().set(UlDefectData.Companyid, Companyid);
		return this;
	}

	public String getDrawingnumber() {
		return this.repository().getString(UlDefectData.Drawingnumber);
	}

	public UlDefectData setDrawingnumber(String Drawingnumber) {
		this.repository().set(UlDefectData.Drawingnumber, Drawingnumber);
		return this;
	}

	public String getDefectdesc() {
		return this.repository().getString(UlDefectData.Defectdesc);
	}

	public UlDefectData setDefectdesc(String Defectdesc) {
		this.repository().set(UlDefectData.Defectdesc, Defectdesc);
		return this;
	}

	public String getLargecategory() {
		return this.repository().getString(UlDefectData.Largecategory);
	}

	public UlDefectData setLargecategory(String Largecategory) {
		this.repository().set(UlDefectData.Largecategory, Largecategory);
		return this;
	}

	public String getSmallcategroy() {
		return this.repository().getString(UlDefectData.Smallcategroy);
	}

	public UlDefectData setSmallcategroy(String Smallcategroy) {
		this.repository().set(UlDefectData.Smallcategroy, Smallcategroy);
		return this;
	}

	public String getActiontype() {
		return this.repository().getString(UlDefectData.Actiontype);
	}

	public UlDefectData setActiontype(String Actiontype) {
		this.repository().set(UlDefectData.Actiontype, Actiontype);
		return this;
	}

	public String getCompletestate() {
		return this.repository().getString(UlDefectData.Completestate);
	}

	public UlDefectData setCompletestate(String Completestate) {
		this.repository().set(UlDefectData.Completestate, Completestate);
		return this;
	}

	public Date getPaymentdate() {
		return this.repository().getDate(UlDefectData.Paymentdate);
	}

	public UlDefectData setPaymentdate(Date Paymentdate) {
		this.repository().set(UlDefectData.Paymentdate, Paymentdate);
		return this;
	}

	public Double getPaymentqty() {
		return this.repository().getDouble(UlDefectData.Paymentqty);
	}

	public UlDefectData setPaymentqty(Double Paymentqty) {
		this.repository().set(UlDefectData.Paymentqty, Paymentqty);
		return this;
	}

	public Double getUnitprice() {
		return this.repository().getDouble(UlDefectData.Unitprice);
	}

	public UlDefectData setUnitprice(Double Unitprice) {
		this.repository().set(UlDefectData.Unitprice, Unitprice);
		return this;
	}

	public Date getDefectdate() {
		return this.repository().getDate(UlDefectData.Defectdate);
	}

	public UlDefectData setDefectdate(Date Defectdate) {
		this.repository().set(UlDefectData.Defectdate, Defectdate);
		return this;
	}

	public Double getDefectqty() {
		return this.repository().getDouble(UlDefectData.Defectqty);
	}

	public UlDefectData setDefectqty(Double Defectqty) {
		this.repository().set(UlDefectData.Defectqty, Defectqty);
		return this;
	}

	public Double getDefectprice() {
		return this.repository().getDouble(UlDefectData.Defectprice);
	}

	public UlDefectData setDefectprice(Double Defectprice) {
		this.repository().set(UlDefectData.Defectprice, Defectprice);
		return this;
	}

	public Integer getRecurrcnt() {
		return this.repository().getInteger(UlDefectData.Recurrcnt);
	}

	public UlDefectData setRecurrcnt(Integer Recurrcnt) {
		this.repository().set(UlDefectData.Recurrcnt, Recurrcnt);
		return this;
	}

	public Date getReceiptdate() {
		return this.repository().getDate(UlDefectData.Receiptdate);
	}

	public UlDefectData setReceiptdate(Date Receiptdate) {
		this.repository().set(UlDefectData.Receiptdate, Receiptdate);
		return this;
	}

	public Date getDeliverydate() {
		return this.repository().getDate(UlDefectData.Deliverydate);
	}

	public UlDefectData setDeliverydate(Date Deliverydate) {
		this.repository().set(UlDefectData.Deliverydate, Deliverydate);
		return this;
	}

	public Date getCompletedate() {
		return this.repository().getDate(UlDefectData.Completedate);
	}

	public UlDefectData setCompletedate(Date Completedate) {
		this.repository().set(UlDefectData.Completedate, Completedate);
		return this;
	}

	public Integer getCompleteday() {
		return this.repository().getInteger(UlDefectData.Completeday);
	}

	public UlDefectData setCompleteday(Integer Completeday) {
		this.repository().set(UlDefectData.Completeday, Completeday);
		return this;
	}

	public Date getExportdate() {
		return this.repository().getDate(UlDefectData.Exportdate);
	}

	public UlDefectData setExportdate(Date Exportdate) {
		this.repository().set(UlDefectData.Exportdate, Exportdate);
		return this;
	}

	public Date getActiondate() {
		return this.repository().getDate(UlDefectData.Actiondate);
	}

	public UlDefectData setActiondate(Date Actiondate) {
		this.repository().set(UlDefectData.Actiondate, Actiondate);
		return this;
	}

	public Integer getActionday() {
		return this.repository().getInteger(UlDefectData.Actionday);
	}

	public UlDefectData setActionday(Integer Actionday) {
		this.repository().set(UlDefectData.Actionday, Actionday);
		return this;
	}

	public String getReasondesc() {
		return this.repository().getString(UlDefectData.Reasondesc);
	}

	public UlDefectData setReasondesc(String Reasondesc) {
		this.repository().set(UlDefectData.Reasondesc, Reasondesc);
		return this;
	}

	public String getActiondesc() {
		return this.repository().getString(UlDefectData.Actiondesc);
	}

	public UlDefectData setActiondesc(String Actiondesc) {
		this.repository().set(UlDefectData.Actiondesc, Actiondesc);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlDefectData.Description);
	}

	public UlDefectData setDescription(String Description) {
		this.repository().set(UlDefectData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlDefectData.Creator);
	}

	public UlDefectData setCreator(String Creator) {
		this.repository().set(UlDefectData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlDefectData.Createdtime);
	}

	public UlDefectData setCreatedtime(Date Createdtime) {
		this.repository().set(UlDefectData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlDefectData.Modifier);
	}

	public UlDefectData setModifier(String Modifier) {
		this.repository().set(UlDefectData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlDefectData.Modifiedtime);
	}

	public UlDefectData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlDefectData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(UlDefectData.Lasttxnhistkey);
	}

	public UlDefectData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(UlDefectData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(UlDefectData.Lasttxnid);
	}

	public UlDefectData setLasttxnid(String Lasttxnid) {
		this.repository().set(UlDefectData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(UlDefectData.Lasttxnuser);
	}

	public UlDefectData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(UlDefectData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(UlDefectData.Lasttxntime);
	}

	public UlDefectData setLasttxntime(Date Lasttxntime) {
		this.repository().set(UlDefectData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(UlDefectData.Lasttxncomment);
	}

	public UlDefectData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(UlDefectData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlDefectData.Validstate);
	}

	public UlDefectData setValidstate(String Validstate) {
		this.repository().set(UlDefectData.Validstate, Validstate);
		return this;
	}

	public String getFindid() {
		return this.repository().getString(UlDefectData.Findid);
	}

	public UlDefectData setFindid(String Findid) {
		this.repository().set(UlDefectData.Findid, Findid);
		return this;
	}


}