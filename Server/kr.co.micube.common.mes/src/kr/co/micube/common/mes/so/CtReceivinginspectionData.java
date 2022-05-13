package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtReceivinginspectionData extends SQLData {

	public static final String Consumabledefid = "CONSUMABLEDEFID";

	public static final String Deliveryno = "DELIVERYNO";

	public static final String Deliverysequence = "DELIVERYSEQUENCE";

	public static final String Vendorname = "VENDORNAME";

	public static final String Deliveryconfirmdept = "DELIVERYCONFIRMDEPT";

	public static final String Deliveryconfirmuser = "DELIVERYCONFIRMUSER";

	public static final String Deliverydate = "DELIVERYDATE";

	public static final String Deliveryqty = "DELIVERYQTY";

	public static final String Deliverywarehouseid = "DELIVERYWAREHOUSEID";

	public static final String Purchaseno = "PURCHASENO";

	public static final String Goodqty = "GOODQTY";

	public static final String Defectqty = "DEFECTQTY";

	public static final String Resultcode = "RESULTCODE";

	public static final String Inspector = "INSPECTOR";

	public static final String Inspectiondate = "INSPECTIONDATE";

	public static final String Deliverycode = "DELIVERYCODE";

	public static final String Iserpsendyn = "ISERPSENDYN";

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

	public static final String Interfacetxnhistkey = "INTERFACETXNHISTKEY";

	public CtReceivinginspectionData() {
		this(new CtReceivinginspectionKey()); 
	}

	public CtReceivinginspectionData(CtReceivinginspectionKey key) {
		super(key, "CtReceivinginspection");
	}


	public String getVendorname() {
		return this.repository().getString(CtReceivinginspectionData.Vendorname);
	}

	public CtReceivinginspectionData setVendorname(String Vendorname) {
		this.repository().set(CtReceivinginspectionData.Vendorname, Vendorname);
		return this;
	}

	public String getDeliveryconfirmdept() {
		return this.repository().getString(CtReceivinginspectionData.Deliveryconfirmdept);
	}

	public CtReceivinginspectionData setDeliveryconfirmdept(String Deliveryconfirmdept) {
		this.repository().set(CtReceivinginspectionData.Deliveryconfirmdept, Deliveryconfirmdept);
		return this;
	}

	public String getDeliveryconfirmuser() {
		return this.repository().getString(CtReceivinginspectionData.Deliveryconfirmuser);
	}

	public CtReceivinginspectionData setDeliveryconfirmuser(String Deliveryconfirmuser) {
		this.repository().set(CtReceivinginspectionData.Deliveryconfirmuser, Deliveryconfirmuser);
		return this;
	}

	public Date getDeliverydate() {
		return this.repository().getDate(CtReceivinginspectionData.Deliverydate);
	}

	public CtReceivinginspectionData setDeliverydate(Date Deliverydate) {
		this.repository().set(CtReceivinginspectionData.Deliverydate, Deliverydate);
		return this;
	}

	public Double getDeliveryqty() {
		return this.repository().getDouble(CtReceivinginspectionData.Deliveryqty);
	}

	public CtReceivinginspectionData setDeliveryqty(Double Deliveryqty) {
		this.repository().set(CtReceivinginspectionData.Deliveryqty, Deliveryqty);
		return this;
	}

	public String getDeliverywarehouseid() {
		return this.repository().getString(CtReceivinginspectionData.Deliverywarehouseid);
	}

	public CtReceivinginspectionData setDeliverywarehouseid(String Deliverywarehouseid) {
		this.repository().set(CtReceivinginspectionData.Deliverywarehouseid, Deliverywarehouseid);
		return this;
	}

	public String getPurchaseno() {
		return this.repository().getString(CtReceivinginspectionData.Purchaseno);
	}

	public CtReceivinginspectionData setPurchaseno(String Purchaseno) {
		this.repository().set(CtReceivinginspectionData.Purchaseno, Purchaseno);
		return this;
	}

	public Double getGoodqty() {
		return this.repository().getDouble(CtReceivinginspectionData.Goodqty);
	}

	public CtReceivinginspectionData setGoodqty(Double Goodqty) {
		this.repository().set(CtReceivinginspectionData.Goodqty, Goodqty);
		return this;
	}

	public Double getDefectqty() {
		return this.repository().getDouble(CtReceivinginspectionData.Defectqty);
	}

	public CtReceivinginspectionData setDefectqty(Double Defectqty) {
		this.repository().set(CtReceivinginspectionData.Defectqty, Defectqty);
		return this;
	}

	public String getResultcode() {
		return this.repository().getString(CtReceivinginspectionData.Resultcode);
	}

	public CtReceivinginspectionData setResultcode(String Resultcode) {
		this.repository().set(CtReceivinginspectionData.Resultcode, Resultcode);
		return this;
	}

	public String getInspector() {
		return this.repository().getString(CtReceivinginspectionData.Inspector);
	}

	public CtReceivinginspectionData setInspector(String Inspector) {
		this.repository().set(CtReceivinginspectionData.Inspector, Inspector);
		return this;
	}

	public Date getInspectiondate() {
		return this.repository().getDate(CtReceivinginspectionData.Inspectiondate);
	}

	public CtReceivinginspectionData setInspectiondate(Date Inspectiondate) {
		this.repository().set(CtReceivinginspectionData.Inspectiondate, Inspectiondate);
		return this;
	}

	public String getDeliverycode() {
		return this.repository().getString(CtReceivinginspectionData.Deliverycode);
	}

	public CtReceivinginspectionData setDeliverycode(String Deliverycode) {
		this.repository().set(CtReceivinginspectionData.Deliverycode, Deliverycode);
		return this;
	}

	public String getIserpsendyn() {
		return this.repository().getString(CtReceivinginspectionData.Iserpsendyn);
	}

	public CtReceivinginspectionData setIserpsendyn(String Iserpsendyn) {
		this.repository().set(CtReceivinginspectionData.Iserpsendyn, Iserpsendyn);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtReceivinginspectionData.Description);
	}

	public CtReceivinginspectionData setDescription(String Description) {
		this.repository().set(CtReceivinginspectionData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtReceivinginspectionData.Creator);
	}

	public CtReceivinginspectionData setCreator(String Creator) {
		this.repository().set(CtReceivinginspectionData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtReceivinginspectionData.Createdtime);
	}

	public CtReceivinginspectionData setCreatedtime(Date Createdtime) {
		this.repository().set(CtReceivinginspectionData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtReceivinginspectionData.Modifier);
	}

	public CtReceivinginspectionData setModifier(String Modifier) {
		this.repository().set(CtReceivinginspectionData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtReceivinginspectionData.Modifiedtime);
	}

	public CtReceivinginspectionData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtReceivinginspectionData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtReceivinginspectionData.Lasttxnhistkey);
	}

	public CtReceivinginspectionData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtReceivinginspectionData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtReceivinginspectionData.Lasttxnid);
	}

	public CtReceivinginspectionData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtReceivinginspectionData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtReceivinginspectionData.Lasttxnuser);
	}

	public CtReceivinginspectionData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtReceivinginspectionData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtReceivinginspectionData.Lasttxntime);
	}

	public CtReceivinginspectionData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtReceivinginspectionData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtReceivinginspectionData.Lasttxncomment);
	}

	public CtReceivinginspectionData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtReceivinginspectionData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtReceivinginspectionData.Validstate);
	}

	public CtReceivinginspectionData setValidstate(String Validstate) {
		this.repository().set(CtReceivinginspectionData.Validstate, Validstate);
		return this;
	}

	public String getInterfacetxnhistkey() {
		return this.repository().getString(CtReceivinginspectionData.Interfacetxnhistkey);
	}

	public CtReceivinginspectionData setInterfacetxnhistkey(String Interfacetxnhistkey) {
		this.repository().set(CtReceivinginspectionData.Interfacetxnhistkey, Interfacetxnhistkey);
		return this;
	}


}