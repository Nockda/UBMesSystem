package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtReceivinginspectionHistoryData extends SQLData {

	public static final String Consumabledefid = "CONSUMABLEDEFID";

	public static final String Deliveryno = "DELIVERYNO";

	public static final String Txnhistkey = "TXNHISTKEY";

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

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public static final String Interfacetxnhistkey = "INTERFACETXNHISTKEY";

	public CtReceivinginspectionHistoryData() {
		this(new CtReceivinginspectionHistoryKey()); 
	}

	public CtReceivinginspectionHistoryData(CtReceivinginspectionHistoryKey key) {
		super(key, "CtReceivinginspectionHistory");
	}


	public String getVendorname() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Vendorname);
	}

	public CtReceivinginspectionHistoryData setVendorname(String Vendorname) {
		this.repository().set(CtReceivinginspectionHistoryData.Vendorname, Vendorname);
		return this;
	}

	public String getDeliveryconfirmdept() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Deliveryconfirmdept);
	}

	public CtReceivinginspectionHistoryData setDeliveryconfirmdept(String Deliveryconfirmdept) {
		this.repository().set(CtReceivinginspectionHistoryData.Deliveryconfirmdept, Deliveryconfirmdept);
		return this;
	}

	public String getDeliveryconfirmuser() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Deliveryconfirmuser);
	}

	public CtReceivinginspectionHistoryData setDeliveryconfirmuser(String Deliveryconfirmuser) {
		this.repository().set(CtReceivinginspectionHistoryData.Deliveryconfirmuser, Deliveryconfirmuser);
		return this;
	}

	public Date getDeliverydate() {
		return this.repository().getDate(CtReceivinginspectionHistoryData.Deliverydate);
	}

	public CtReceivinginspectionHistoryData setDeliverydate(Date Deliverydate) {
		this.repository().set(CtReceivinginspectionHistoryData.Deliverydate, Deliverydate);
		return this;
	}

	public Double getDeliveryqty() {
		return this.repository().getDouble(CtReceivinginspectionHistoryData.Deliveryqty);
	}

	public CtReceivinginspectionHistoryData setDeliveryqty(Double Deliveryqty) {
		this.repository().set(CtReceivinginspectionHistoryData.Deliveryqty, Deliveryqty);
		return this;
	}

	public String getDeliverywarehouseid() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Deliverywarehouseid);
	}

	public CtReceivinginspectionHistoryData setDeliverywarehouseid(String Deliverywarehouseid) {
		this.repository().set(CtReceivinginspectionHistoryData.Deliverywarehouseid, Deliverywarehouseid);
		return this;
	}

	public String getPurchaseno() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Purchaseno);
	}

	public CtReceivinginspectionHistoryData setPurchaseno(String Purchaseno) {
		this.repository().set(CtReceivinginspectionHistoryData.Purchaseno, Purchaseno);
		return this;
	}

	public Double getGoodqty() {
		return this.repository().getDouble(CtReceivinginspectionHistoryData.Goodqty);
	}

	public CtReceivinginspectionHistoryData setGoodqty(Double Goodqty) {
		this.repository().set(CtReceivinginspectionHistoryData.Goodqty, Goodqty);
		return this;
	}

	public Double getDefectqty() {
		return this.repository().getDouble(CtReceivinginspectionHistoryData.Defectqty);
	}

	public CtReceivinginspectionHistoryData setDefectqty(Double Defectqty) {
		this.repository().set(CtReceivinginspectionHistoryData.Defectqty, Defectqty);
		return this;
	}

	public String getResultcode() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Resultcode);
	}

	public CtReceivinginspectionHistoryData setResultcode(String Resultcode) {
		this.repository().set(CtReceivinginspectionHistoryData.Resultcode, Resultcode);
		return this;
	}

	public String getInspector() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Inspector);
	}

	public CtReceivinginspectionHistoryData setInspector(String Inspector) {
		this.repository().set(CtReceivinginspectionHistoryData.Inspector, Inspector);
		return this;
	}

	public Date getInspectiondate() {
		return this.repository().getDate(CtReceivinginspectionHistoryData.Inspectiondate);
	}

	public CtReceivinginspectionHistoryData setInspectiondate(Date Inspectiondate) {
		this.repository().set(CtReceivinginspectionHistoryData.Inspectiondate, Inspectiondate);
		return this;
	}

	public String getDeliverycode() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Deliverycode);
	}

	public CtReceivinginspectionHistoryData setDeliverycode(String Deliverycode) {
		this.repository().set(CtReceivinginspectionHistoryData.Deliverycode, Deliverycode);
		return this;
	}

	public String getIserpsendyn() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Iserpsendyn);
	}

	public CtReceivinginspectionHistoryData setIserpsendyn(String Iserpsendyn) {
		this.repository().set(CtReceivinginspectionHistoryData.Iserpsendyn, Iserpsendyn);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Description);
	}

	public CtReceivinginspectionHistoryData setDescription(String Description) {
		this.repository().set(CtReceivinginspectionHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Creator);
	}

	public CtReceivinginspectionHistoryData setCreator(String Creator) {
		this.repository().set(CtReceivinginspectionHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtReceivinginspectionHistoryData.Createdtime);
	}

	public CtReceivinginspectionHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtReceivinginspectionHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Modifier);
	}

	public CtReceivinginspectionHistoryData setModifier(String Modifier) {
		this.repository().set(CtReceivinginspectionHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtReceivinginspectionHistoryData.Modifiedtime);
	}

	public CtReceivinginspectionHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtReceivinginspectionHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Txnid);
	}

	public CtReceivinginspectionHistoryData setTxnid(String Txnid) {
		this.repository().set(CtReceivinginspectionHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Txnuser);
	}

	public CtReceivinginspectionHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtReceivinginspectionHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtReceivinginspectionHistoryData.Txntime);
	}

	public CtReceivinginspectionHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtReceivinginspectionHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Txngrouphistkey);
	}

	public CtReceivinginspectionHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtReceivinginspectionHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Txnreasoncodeclass);
	}

	public CtReceivinginspectionHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtReceivinginspectionHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Txnreasoncode);
	}

	public CtReceivinginspectionHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtReceivinginspectionHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Txncomment);
	}

	public CtReceivinginspectionHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtReceivinginspectionHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Validstate);
	}

	public CtReceivinginspectionHistoryData setValidstate(String Validstate) {
		this.repository().set(CtReceivinginspectionHistoryData.Validstate, Validstate);
		return this;
	}

	public String getInterfacetxnhistkey() {
		return this.repository().getString(CtReceivinginspectionHistoryData.Interfacetxnhistkey);
	}

	public CtReceivinginspectionHistoryData setInterfacetxnhistkey(String Interfacetxnhistkey) {
		this.repository().set(CtReceivinginspectionHistoryData.Interfacetxnhistkey, Interfacetxnhistkey);
		return this;
	}


}