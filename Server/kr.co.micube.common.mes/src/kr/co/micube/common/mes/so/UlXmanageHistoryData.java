package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlXmanageHistoryData extends SQLData {

	public static final String Xnumber = "XNUMBER";

	public static final String Txnhistkey = "TXNHISTKEY";

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

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public static final String Qty = "QTY";

	public static final String Hopedeleverydate = "HOPEDELEVERYDATE";

	public static final String Claimcontent = "CLAIMCONTENT";

	public UlXmanageHistoryData() {
		this(new UlXmanageHistoryKey()); 
	}

	public UlXmanageHistoryData(UlXmanageHistoryKey key) {
		super(key, "UlXmanageHistory");
	}


	public String getClaimnumber() {
		return this.repository().getString(UlXmanageHistoryData.Claimnumber);
	}

	public UlXmanageHistoryData setClaimnumber(String Claimnumber) {
		this.repository().set(UlXmanageHistoryData.Claimnumber, Claimnumber);
		return this;
	}

	public String getIsreport() {
		return this.repository().getString(UlXmanageHistoryData.Isreport);
	}

	public UlXmanageHistoryData setIsreport(String Isreport) {
		this.repository().set(UlXmanageHistoryData.Isreport, Isreport);
		return this;
	}

	public Date getPublishdate() {
		return this.repository().getDate(UlXmanageHistoryData.Publishdate);
	}

	public UlXmanageHistoryData setPublishdate(Date Publishdate) {
		this.repository().set(UlXmanageHistoryData.Publishdate, Publishdate);
		return this;
	}

	public String getPublisher() {
		return this.repository().getString(UlXmanageHistoryData.Publisher);
	}

	public UlXmanageHistoryData setPublisher(String Publisher) {
		this.repository().set(UlXmanageHistoryData.Publisher, Publisher);
		return this;
	}

	public String getProgressstate() {
		return this.repository().getString(UlXmanageHistoryData.Progressstate);
	}

	public UlXmanageHistoryData setProgressstate(String Progressstate) {
		this.repository().set(UlXmanageHistoryData.Progressstate, Progressstate);
		return this;
	}

	public Integer getElapsedday() {
		return this.repository().getInteger(UlXmanageHistoryData.Elapsedday);
	}

	public UlXmanageHistoryData setElapsedday(Integer Elapsedday) {
		this.repository().set(UlXmanageHistoryData.Elapsedday, Elapsedday);
		return this;
	}

	public String getChargetype() {
		return this.repository().getString(UlXmanageHistoryData.Chargetype);
	}

	public UlXmanageHistoryData setChargetype(String Chargetype) {
		this.repository().set(UlXmanageHistoryData.Chargetype, Chargetype);
		return this;
	}

	public String getXtype() {
		return this.repository().getString(UlXmanageHistoryData.Xtype);
	}

	public UlXmanageHistoryData setXtype(String Xtype) {
		this.repository().set(UlXmanageHistoryData.Xtype, Xtype);
		return this;
	}

	public String getTroubletype() {
		return this.repository().getString(UlXmanageHistoryData.Troubletype);
	}

	public UlXmanageHistoryData setTroubletype(String Troubletype) {
		this.repository().set(UlXmanageHistoryData.Troubletype, Troubletype);
		return this;
	}

	public String getItemfamily() {
		return this.repository().getString(UlXmanageHistoryData.Itemfamily);
	}

	public UlXmanageHistoryData setItemfamily(String Itemfamily) {
		this.repository().set(UlXmanageHistoryData.Itemfamily, Itemfamily);
		return this;
	}

	public String getManufacturerid() {
		return this.repository().getString(UlXmanageHistoryData.Manufacturerid);
	}

	public UlXmanageHistoryData setManufacturerid(String Manufacturerid) {
		this.repository().set(UlXmanageHistoryData.Manufacturerid, Manufacturerid);
		return this;
	}

	public String getModelid() {
		return this.repository().getString(UlXmanageHistoryData.Modelid);
	}

	public UlXmanageHistoryData setModelid(String Modelid) {
		this.repository().set(UlXmanageHistoryData.Modelid, Modelid);
		return this;
	}

	public String getManufacturenumber() {
		return this.repository().getString(UlXmanageHistoryData.Manufacturenumber);
	}

	public UlXmanageHistoryData setManufacturenumber(String Manufacturenumber) {
		this.repository().set(UlXmanageHistoryData.Manufacturenumber, Manufacturenumber);
		return this;
	}

	public Integer getEtmhour() {
		return this.repository().getInteger(UlXmanageHistoryData.Etmhour);
	}

	public UlXmanageHistoryData setEtmhour(Integer Etmhour) {
		this.repository().set(UlXmanageHistoryData.Etmhour, Etmhour);
		return this;
	}

	public String getCustomerregionid() {
		return this.repository().getString(UlXmanageHistoryData.Customerregionid);
	}

	public UlXmanageHistoryData setCustomerregionid(String Customerregionid) {
		this.repository().set(UlXmanageHistoryData.Customerregionid, Customerregionid);
		return this;
	}

	public String getCustomerbase() {
		return this.repository().getString(UlXmanageHistoryData.Customerbase);
	}

	public UlXmanageHistoryData setCustomerbase(String Customerbase) {
		this.repository().set(UlXmanageHistoryData.Customerbase, Customerbase);
		return this;
	}

	public String getDevicecustomerid() {
		return this.repository().getString(UlXmanageHistoryData.Devicecustomerid);
	}

	public UlXmanageHistoryData setDevicecustomerid(String Devicecustomerid) {
		this.repository().set(UlXmanageHistoryData.Devicecustomerid, Devicecustomerid);
		return this;
	}

	public String getCustomerid() {
		return this.repository().getString(UlXmanageHistoryData.Customerid);
	}

	public UlXmanageHistoryData setCustomerid(String Customerid) {
		this.repository().set(UlXmanageHistoryData.Customerid, Customerid);
		return this;
	}

	public String getLineid() {
		return this.repository().getString(UlXmanageHistoryData.Lineid);
	}

	public UlXmanageHistoryData setLineid(String Lineid) {
		this.repository().set(UlXmanageHistoryData.Lineid, Lineid);
		return this;
	}

	public String getCustomerlocation() {
		return this.repository().getString(UlXmanageHistoryData.Customerlocation);
	}

	public UlXmanageHistoryData setCustomerlocation(String Customerlocation) {
		this.repository().set(UlXmanageHistoryData.Customerlocation, Customerlocation);
		return this;
	}

	public String getCustomermanager() {
		return this.repository().getString(UlXmanageHistoryData.Customermanager);
	}

	public UlXmanageHistoryData setCustomermanager(String Customermanager) {
		this.repository().set(UlXmanageHistoryData.Customermanager, Customermanager);
		return this;
	}

	public String getTellnumber() {
		return this.repository().getString(UlXmanageHistoryData.Tellnumber);
	}

	public UlXmanageHistoryData setTellnumber(String Tellnumber) {
		this.repository().set(UlXmanageHistoryData.Tellnumber, Tellnumber);
		return this;
	}

	public Double getFixedcost() {
		return this.repository().getDouble(UlXmanageHistoryData.Fixedcost);
	}

	public UlXmanageHistoryData setFixedcost(Double Fixedcost) {
		this.repository().set(UlXmanageHistoryData.Fixedcost, Fixedcost);
		return this;
	}

	public Double getVariablecost() {
		return this.repository().getDouble(UlXmanageHistoryData.Variablecost);
	}

	public UlXmanageHistoryData setVariablecost(Double Variablecost) {
		this.repository().set(UlXmanageHistoryData.Variablecost, Variablecost);
		return this;
	}

	public String getProcessmonth() {
		return this.repository().getString(UlXmanageHistoryData.Processmonth);
	}

	public UlXmanageHistoryData setProcessmonth(String Processmonth) {
		this.repository().set(UlXmanageHistoryData.Processmonth, Processmonth);
		return this;
	}

	public Integer getOrdermonth() {
		return this.repository().getInteger(UlXmanageHistoryData.Ordermonth);
	}

	public UlXmanageHistoryData setOrdermonth(Integer Ordermonth) {
		this.repository().set(UlXmanageHistoryData.Ordermonth, Ordermonth);
		return this;
	}

	public Integer getSalesmonth() {
		return this.repository().getInteger(UlXmanageHistoryData.Salesmonth);
	}

	public UlXmanageHistoryData setSalesmonth(Integer Salesmonth) {
		this.repository().set(UlXmanageHistoryData.Salesmonth, Salesmonth);
		return this;
	}

	public String getResponsefrom() {
		return this.repository().getString(UlXmanageHistoryData.Responsefrom);
	}

	public UlXmanageHistoryData setResponsefrom(String Responsefrom) {
		this.repository().set(UlXmanageHistoryData.Responsefrom, Responsefrom);
		return this;
	}

	public String getIsexam() {
		return this.repository().getString(UlXmanageHistoryData.Isexam);
	}

	public UlXmanageHistoryData setIsexam(String Isexam) {
		this.repository().set(UlXmanageHistoryData.Isexam, Isexam);
		return this;
	}

	public Date getOccurdate() {
		return this.repository().getDate(UlXmanageHistoryData.Occurdate);
	}

	public UlXmanageHistoryData setOccurdate(Date Occurdate) {
		this.repository().set(UlXmanageHistoryData.Occurdate, Occurdate);
		return this;
	}

	public String getStatedesc() {
		return this.repository().getString(UlXmanageHistoryData.Statedesc);
	}

	public UlXmanageHistoryData setStatedesc(String Statedesc) {
		this.repository().set(UlXmanageHistoryData.Statedesc, Statedesc);
		return this;
	}

	public String getResponsedesc() {
		return this.repository().getString(UlXmanageHistoryData.Responsedesc);
	}

	public UlXmanageHistoryData setResponsedesc(String Responsedesc) {
		this.repository().set(UlXmanageHistoryData.Responsedesc, Responsedesc);
		return this;
	}

	public String getOrdernumber() {
		return this.repository().getString(UlXmanageHistoryData.Ordernumber);
	}

	public UlXmanageHistoryData setOrdernumber(String Ordernumber) {
		this.repository().set(UlXmanageHistoryData.Ordernumber, Ordernumber);
		return this;
	}

	public Date getRequestdate() {
		return this.repository().getDate(UlXmanageHistoryData.Requestdate);
	}

	public UlXmanageHistoryData setRequestdate(Date Requestdate) {
		this.repository().set(UlXmanageHistoryData.Requestdate, Requestdate);
		return this;
	}

	public String getProgressdesc() {
		return this.repository().getString(UlXmanageHistoryData.Progressdesc);
	}

	public UlXmanageHistoryData setProgressdesc(String Progressdesc) {
		this.repository().set(UlXmanageHistoryData.Progressdesc, Progressdesc);
		return this;
	}

	public Date getCompletedate() {
		return this.repository().getDate(UlXmanageHistoryData.Completedate);
	}

	public UlXmanageHistoryData setCompletedate(Date Completedate) {
		this.repository().set(UlXmanageHistoryData.Completedate, Completedate);
		return this;
	}

	public Date getShipmentdate() {
		return this.repository().getDate(UlXmanageHistoryData.Shipmentdate);
	}

	public UlXmanageHistoryData setShipmentdate(Date Shipmentdate) {
		this.repository().set(UlXmanageHistoryData.Shipmentdate, Shipmentdate);
		return this;
	}

	public Double getOrderprice() {
		return this.repository().getDouble(UlXmanageHistoryData.Orderprice);
	}

	public UlXmanageHistoryData setOrderprice(Double Orderprice) {
		this.repository().set(UlXmanageHistoryData.Orderprice, Orderprice);
		return this;
	}

	public Double getSalesprice() {
		return this.repository().getDouble(UlXmanageHistoryData.Salesprice);
	}

	public UlXmanageHistoryData setSalesprice(Double Salesprice) {
		this.repository().set(UlXmanageHistoryData.Salesprice, Salesprice);
		return this;
	}

	public Double getFreeprice() {
		return this.repository().getDouble(UlXmanageHistoryData.Freeprice);
	}

	public UlXmanageHistoryData setFreeprice(Double Freeprice) {
		this.repository().set(UlXmanageHistoryData.Freeprice, Freeprice);
		return this;
	}

	public Date getProcessdate() {
		return this.repository().getDate(UlXmanageHistoryData.Processdate);
	}

	public UlXmanageHistoryData setProcessdate(Date Processdate) {
		this.repository().set(UlXmanageHistoryData.Processdate, Processdate);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlXmanageHistoryData.Description);
	}

	public UlXmanageHistoryData setDescription(String Description) {
		this.repository().set(UlXmanageHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlXmanageHistoryData.Creator);
	}

	public UlXmanageHistoryData setCreator(String Creator) {
		this.repository().set(UlXmanageHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlXmanageHistoryData.Createdtime);
	}

	public UlXmanageHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(UlXmanageHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlXmanageHistoryData.Modifier);
	}

	public UlXmanageHistoryData setModifier(String Modifier) {
		this.repository().set(UlXmanageHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlXmanageHistoryData.Modifiedtime);
	}

	public UlXmanageHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlXmanageHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlXmanageHistoryData.Txnid);
	}

	public UlXmanageHistoryData setTxnid(String Txnid) {
		this.repository().set(UlXmanageHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlXmanageHistoryData.Txnuser);
	}

	public UlXmanageHistoryData setTxnuser(String Txnuser) {
		this.repository().set(UlXmanageHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlXmanageHistoryData.Txntime);
	}

	public UlXmanageHistoryData setTxntime(Date Txntime) {
		this.repository().set(UlXmanageHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlXmanageHistoryData.Txngrouphistkey);
	}

	public UlXmanageHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlXmanageHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlXmanageHistoryData.Txnreasoncodeclass);
	}

	public UlXmanageHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlXmanageHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlXmanageHistoryData.Txnreasoncode);
	}

	public UlXmanageHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlXmanageHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlXmanageHistoryData.Txncomment);
	}

	public UlXmanageHistoryData setTxncomment(String Txncomment) {
		this.repository().set(UlXmanageHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlXmanageHistoryData.Validstate);
	}

	public UlXmanageHistoryData setValidstate(String Validstate) {
		this.repository().set(UlXmanageHistoryData.Validstate, Validstate);
		return this;
	}

	public Double getQty() {
		return this.repository().getDouble(UlXmanageHistoryData.Qty);
	}

	public UlXmanageHistoryData setQty(Double Qty) {
		this.repository().set(UlXmanageHistoryData.Qty, Qty);
		return this;
	}

	public Date getHopedeleverydate() {
		return this.repository().getDate(UlXmanageHistoryData.Hopedeleverydate);
	}

	public UlXmanageHistoryData setHopedeleverydate(Date Hopedeleverydate) {
		this.repository().set(UlXmanageHistoryData.Hopedeleverydate, Hopedeleverydate);
		return this;
	}

	public String getClaimcontent() {
		return this.repository().getString(UlXmanageHistoryData.Claimcontent);
	}

	public UlXmanageHistoryData setClaimcontent(String Claimcontent) {
		this.repository().set(UlXmanageHistoryData.Claimcontent, Claimcontent);
		return this;
	}


}