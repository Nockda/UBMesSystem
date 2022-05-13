package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlXmanageData extends SQLData {

	public static final String Xnumber = "XNUMBER";

	public static final String Claimnumber = "CLAIMNUMBER";

	public static final String Isreport = "ISREPORT";

	public static final String Publishdate = "PUBLISHDATE";

	public static final String Publisher = "PUBLISHER";

	public static final String Progressstate = "PROGRESSSTATE";

	public static final String Elapsedday = "ELAPSEDDAY";

	public static final String Chargetype = "CHARGETYPE";

	public static final String Xtype = "XTYPE";

	public static final String Troubletype = "TROUBLETYPE";

	public static final String Itemfamily = "ITEMFAMILY";

	public static final String Manufacturerid = "MANUFACTURERID";

	public static final String Modelid = "MODELID";

	public static final String Manufacturenumber = "MANUFACTURENUMBER";

	public static final String Etmhour = "ETMHOUR";

	public static final String Customerregionid = "CUSTOMERREGIONID";

	public static final String Customerbase = "CUSTOMERBASE";

	public static final String Devicecustomerid = "DEVICECUSTOMERID";

	public static final String Customerid = "CUSTOMERID";

	public static final String Lineid = "LINEID";

	public static final String Customerlocation = "CUSTOMERLOCATION";

	public static final String Customermanager = "CUSTOMERMANAGER";

	public static final String Tellnumber = "TELLNUMBER";

	public static final String Fixedcost = "FIXEDCOST";

	public static final String Variablecost = "VARIABLECOST";

	public static final String Processmonth = "PROCESSMONTH";

	public static final String Ordermonth = "ORDERMONTH";

	public static final String Salesmonth = "SALESMONTH";

	public static final String Responsefrom = "RESPONSEFROM";

	public static final String Isexam = "ISEXAM";

	public static final String Occurdate = "OCCURDATE";

	public static final String Statedesc = "STATEDESC";

	public static final String Responsedesc = "RESPONSEDESC";

	public static final String Ordernumber = "ORDERNUMBER";

	public static final String Requestdate = "REQUESTDATE";

	public static final String Progressdesc = "PROGRESSDESC";

	public static final String Completedate = "COMPLETEDATE";

	public static final String Shipmentdate = "SHIPMENTDATE";

	public static final String Orderprice = "ORDERPRICE";

	public static final String Salesprice = "SALESPRICE";

	public static final String Freeprice = "FREEPRICE";

	public static final String Processdate = "PROCESSDATE";

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

	public static final String Qty = "QTY";

	public static final String Hopedeleverydate = "HOPEDELEVERYDATE";

	public static final String Indate = "INDATE";

	public static final String Confirmuser = "CONFIRMUSER";

	public static final String Claimcontent = "CLAIMCONTENT";

	public UlXmanageData() {
		this(new UlXmanageKey()); 
	}

	public UlXmanageData(UlXmanageKey key) {
		super(key, "UlXmanage");
	}


	public String getClaimnumber() {
		return this.repository().getString(UlXmanageData.Claimnumber);
	}

	public UlXmanageData setClaimnumber(String Claimnumber) {
		this.repository().set(UlXmanageData.Claimnumber, Claimnumber);
		return this;
	}

	public String getIsreport() {
		return this.repository().getString(UlXmanageData.Isreport);
	}

	public UlXmanageData setIsreport(String Isreport) {
		this.repository().set(UlXmanageData.Isreport, Isreport);
		return this;
	}

	public Date getPublishdate() {
		return this.repository().getDate(UlXmanageData.Publishdate);
	}

	public UlXmanageData setPublishdate(Date Publishdate) {
		this.repository().set(UlXmanageData.Publishdate, Publishdate);
		return this;
	}

	public String getPublisher() {
		return this.repository().getString(UlXmanageData.Publisher);
	}

	public UlXmanageData setPublisher(String Publisher) {
		this.repository().set(UlXmanageData.Publisher, Publisher);
		return this;
	}

	public String getProgressstate() {
		return this.repository().getString(UlXmanageData.Progressstate);
	}

	public UlXmanageData setProgressstate(String Progressstate) {
		this.repository().set(UlXmanageData.Progressstate, Progressstate);
		return this;
	}

	public Integer getElapsedday() {
		return this.repository().getInteger(UlXmanageData.Elapsedday);
	}

	public UlXmanageData setElapsedday(Integer Elapsedday) {
		this.repository().set(UlXmanageData.Elapsedday, Elapsedday);
		return this;
	}

	public String getChargetype() {
		return this.repository().getString(UlXmanageData.Chargetype);
	}

	public UlXmanageData setChargetype(String Chargetype) {
		this.repository().set(UlXmanageData.Chargetype, Chargetype);
		return this;
	}

	public String getXtype() {
		return this.repository().getString(UlXmanageData.Xtype);
	}

	public UlXmanageData setXtype(String Xtype) {
		this.repository().set(UlXmanageData.Xtype, Xtype);
		return this;
	}

	public String getTroubletype() {
		return this.repository().getString(UlXmanageData.Troubletype);
	}

	public UlXmanageData setTroubletype(String Troubletype) {
		this.repository().set(UlXmanageData.Troubletype, Troubletype);
		return this;
	}

	public String getItemfamily() {
		return this.repository().getString(UlXmanageData.Itemfamily);
	}

	public UlXmanageData setItemfamily(String Itemfamily) {
		this.repository().set(UlXmanageData.Itemfamily, Itemfamily);
		return this;
	}

	public String getManufacturerid() {
		return this.repository().getString(UlXmanageData.Manufacturerid);
	}

	public UlXmanageData setManufacturerid(String Manufacturerid) {
		this.repository().set(UlXmanageData.Manufacturerid, Manufacturerid);
		return this;
	}

	public String getModelid() {
		return this.repository().getString(UlXmanageData.Modelid);
	}

	public UlXmanageData setModelid(String Modelid) {
		this.repository().set(UlXmanageData.Modelid, Modelid);
		return this;
	}

	public String getManufacturenumber() {
		return this.repository().getString(UlXmanageData.Manufacturenumber);
	}

	public UlXmanageData setManufacturenumber(String Manufacturenumber) {
		this.repository().set(UlXmanageData.Manufacturenumber, Manufacturenumber);
		return this;
	}

	public Integer getEtmhour() {
		return this.repository().getInteger(UlXmanageData.Etmhour);
	}

	public UlXmanageData setEtmhour(Integer Etmhour) {
		this.repository().set(UlXmanageData.Etmhour, Etmhour);
		return this;
	}

	public String getCustomerregionid() {
		return this.repository().getString(UlXmanageData.Customerregionid);
	}

	public UlXmanageData setCustomerregionid(String Customerregionid) {
		this.repository().set(UlXmanageData.Customerregionid, Customerregionid);
		return this;
	}

	public String getCustomerbase() {
		return this.repository().getString(UlXmanageData.Customerbase);
	}

	public UlXmanageData setCustomerbase(String Customerbase) {
		this.repository().set(UlXmanageData.Customerbase, Customerbase);
		return this;
	}

	public String getDevicecustomerid() {
		return this.repository().getString(UlXmanageData.Devicecustomerid);
	}

	public UlXmanageData setDevicecustomerid(String Devicecustomerid) {
		this.repository().set(UlXmanageData.Devicecustomerid, Devicecustomerid);
		return this;
	}

	public String getCustomerid() {
		return this.repository().getString(UlXmanageData.Customerid);
	}

	public UlXmanageData setCustomerid(String Customerid) {
		this.repository().set(UlXmanageData.Customerid, Customerid);
		return this;
	}

	public String getLineid() {
		return this.repository().getString(UlXmanageData.Lineid);
	}

	public UlXmanageData setLineid(String Lineid) {
		this.repository().set(UlXmanageData.Lineid, Lineid);
		return this;
	}

	public String getCustomerlocation() {
		return this.repository().getString(UlXmanageData.Customerlocation);
	}

	public UlXmanageData setCustomerlocation(String Customerlocation) {
		this.repository().set(UlXmanageData.Customerlocation, Customerlocation);
		return this;
	}

	public String getCustomermanager() {
		return this.repository().getString(UlXmanageData.Customermanager);
	}

	public UlXmanageData setCustomermanager(String Customermanager) {
		this.repository().set(UlXmanageData.Customermanager, Customermanager);
		return this;
	}

	public String getTellnumber() {
		return this.repository().getString(UlXmanageData.Tellnumber);
	}

	public UlXmanageData setTellnumber(String Tellnumber) {
		this.repository().set(UlXmanageData.Tellnumber, Tellnumber);
		return this;
	}

	public Double getFixedcost() {
		return this.repository().getDouble(UlXmanageData.Fixedcost);
	}

	public UlXmanageData setFixedcost(Double Fixedcost) {
		this.repository().set(UlXmanageData.Fixedcost, Fixedcost);
		return this;
	}

	public Double getVariablecost() {
		return this.repository().getDouble(UlXmanageData.Variablecost);
	}

	public UlXmanageData setVariablecost(Double Variablecost) {
		this.repository().set(UlXmanageData.Variablecost, Variablecost);
		return this;
	}

	public String getProcessmonth() {
		return this.repository().getString(UlXmanageData.Processmonth);
	}

	public UlXmanageData setProcessmonth(String Processmonth) {
		this.repository().set(UlXmanageData.Processmonth, Processmonth);
		return this;
	}

	public Integer getOrdermonth() {
		return this.repository().getInteger(UlXmanageData.Ordermonth);
	}

	public UlXmanageData setOrdermonth(Integer Ordermonth) {
		this.repository().set(UlXmanageData.Ordermonth, Ordermonth);
		return this;
	}

	public Integer getSalesmonth() {
		return this.repository().getInteger(UlXmanageData.Salesmonth);
	}

	public UlXmanageData setSalesmonth(Integer Salesmonth) {
		this.repository().set(UlXmanageData.Salesmonth, Salesmonth);
		return this;
	}

	public String getResponsefrom() {
		return this.repository().getString(UlXmanageData.Responsefrom);
	}

	public UlXmanageData setResponsefrom(String Responsefrom) {
		this.repository().set(UlXmanageData.Responsefrom, Responsefrom);
		return this;
	}

	public String getIsexam() {
		return this.repository().getString(UlXmanageData.Isexam);
	}

	public UlXmanageData setIsexam(String Isexam) {
		this.repository().set(UlXmanageData.Isexam, Isexam);
		return this;
	}

	public Date getOccurdate() {
		return this.repository().getDate(UlXmanageData.Occurdate);
	}

	public UlXmanageData setOccurdate(Date Occurdate) {
		this.repository().set(UlXmanageData.Occurdate, Occurdate);
		return this;
	}

	public String getStatedesc() {
		return this.repository().getString(UlXmanageData.Statedesc);
	}

	public UlXmanageData setStatedesc(String Statedesc) {
		this.repository().set(UlXmanageData.Statedesc, Statedesc);
		return this;
	}

	public String getResponsedesc() {
		return this.repository().getString(UlXmanageData.Responsedesc);
	}

	public UlXmanageData setResponsedesc(String Responsedesc) {
		this.repository().set(UlXmanageData.Responsedesc, Responsedesc);
		return this;
	}

	public String getOrdernumber() {
		return this.repository().getString(UlXmanageData.Ordernumber);
	}

	public UlXmanageData setOrdernumber(String Ordernumber) {
		this.repository().set(UlXmanageData.Ordernumber, Ordernumber);
		return this;
	}

	public Date getRequestdate() {
		return this.repository().getDate(UlXmanageData.Requestdate);
	}

	public UlXmanageData setRequestdate(Date Requestdate) {
		this.repository().set(UlXmanageData.Requestdate, Requestdate);
		return this;
	}

	public String getProgressdesc() {
		return this.repository().getString(UlXmanageData.Progressdesc);
	}

	public UlXmanageData setProgressdesc(String Progressdesc) {
		this.repository().set(UlXmanageData.Progressdesc, Progressdesc);
		return this;
	}

	public Date getCompletedate() {
		return this.repository().getDate(UlXmanageData.Completedate);
	}

	public UlXmanageData setCompletedate(Date Completedate) {
		this.repository().set(UlXmanageData.Completedate, Completedate);
		return this;
	}

	public Date getShipmentdate() {
		return this.repository().getDate(UlXmanageData.Shipmentdate);
	}

	public UlXmanageData setShipmentdate(Date Shipmentdate) {
		this.repository().set(UlXmanageData.Shipmentdate, Shipmentdate);
		return this;
	}

	public Double getOrderprice() {
		return this.repository().getDouble(UlXmanageData.Orderprice);
	}

	public UlXmanageData setOrderprice(Double Orderprice) {
		this.repository().set(UlXmanageData.Orderprice, Orderprice);
		return this;
	}

	public Double getSalesprice() {
		return this.repository().getDouble(UlXmanageData.Salesprice);
	}

	public UlXmanageData setSalesprice(Double Salesprice) {
		this.repository().set(UlXmanageData.Salesprice, Salesprice);
		return this;
	}

	public Double getFreeprice() {
		return this.repository().getDouble(UlXmanageData.Freeprice);
	}

	public UlXmanageData setFreeprice(Double Freeprice) {
		this.repository().set(UlXmanageData.Freeprice, Freeprice);
		return this;
	}

	public Date getProcessdate() {
		return this.repository().getDate(UlXmanageData.Processdate);
	}

	public UlXmanageData setProcessdate(Date Processdate) {
		this.repository().set(UlXmanageData.Processdate, Processdate);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlXmanageData.Description);
	}

	public UlXmanageData setDescription(String Description) {
		this.repository().set(UlXmanageData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlXmanageData.Creator);
	}

	public UlXmanageData setCreator(String Creator) {
		this.repository().set(UlXmanageData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlXmanageData.Createdtime);
	}

	public UlXmanageData setCreatedtime(Date Createdtime) {
		this.repository().set(UlXmanageData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlXmanageData.Modifier);
	}

	public UlXmanageData setModifier(String Modifier) {
		this.repository().set(UlXmanageData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlXmanageData.Modifiedtime);
	}

	public UlXmanageData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlXmanageData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(UlXmanageData.Lasttxnhistkey);
	}

	public UlXmanageData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(UlXmanageData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(UlXmanageData.Lasttxnid);
	}

	public UlXmanageData setLasttxnid(String Lasttxnid) {
		this.repository().set(UlXmanageData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(UlXmanageData.Lasttxnuser);
	}

	public UlXmanageData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(UlXmanageData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(UlXmanageData.Lasttxntime);
	}

	public UlXmanageData setLasttxntime(Date Lasttxntime) {
		this.repository().set(UlXmanageData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(UlXmanageData.Lasttxncomment);
	}

	public UlXmanageData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(UlXmanageData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlXmanageData.Validstate);
	}

	public UlXmanageData setValidstate(String Validstate) {
		this.repository().set(UlXmanageData.Validstate, Validstate);
		return this;
	}

	public Double getQty() {
		return this.repository().getDouble(UlXmanageData.Qty);
	}

	public UlXmanageData setQty(Double Qty) {
		this.repository().set(UlXmanageData.Qty, Qty);
		return this;
	}

	public Date getHopedeleverydate() {
		return this.repository().getDate(UlXmanageData.Hopedeleverydate);
	}

	public UlXmanageData setHopedeleverydate(Date Hopedeleverydate) {
		this.repository().set(UlXmanageData.Hopedeleverydate, Hopedeleverydate);
		return this;
	}

	public Date getIndate() {
		return this.repository().getDate(UlXmanageData.Indate);
	}

	public UlXmanageData setIndate(Date Indate) {
		this.repository().set(UlXmanageData.Indate, Indate);
		return this;
	}

	public String getConfirmuser() {
		return this.repository().getString(UlXmanageData.Confirmuser);
	}

	public UlXmanageData setConfirmuser(String Confirmuser) {
		this.repository().set(UlXmanageData.Confirmuser, Confirmuser);
		return this;
	}

	public String getClaimcontent() {
		return this.repository().getString(UlXmanageData.Claimcontent);
	}

	public UlXmanageData setClaimcontent(String Claimcontent) {
		this.repository().set(UlXmanageData.Claimcontent, Claimcontent);
		return this;
	}


}