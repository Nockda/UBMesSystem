package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfConsumablelotHistoryData extends SQLData {

	public static final String Consumablelotid = "CONSUMABLELOTID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Consumablelotname = "CONSUMABLELOTNAME";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Areaid = "AREAID";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Warehouseid = "WAREHOUSEID";

	public static final String Locationid = "LOCATIONID";

	public static final String Consumabledefid = "CONSUMABLEDEFID";

	public static final String Consumabledefversion = "CONSUMABLEDEFVERSION";

	public static final String Consumablelotgroupid = "CONSUMABLELOTGROUPID";

	public static final String Consumablestate = "CONSUMABLESTATE";

	public static final String Createdqty = "CREATEDQTY";

	public static final String Consumablelotqty = "CONSUMABLELOTQTY";

	public static final String Expireddate = "EXPIREDDATE";

	public static final String Ishold = "ISHOLD";

	public static final String Orderseq = "ORDERSEQ";

	public static final String Parentconsumablelotid = "PARENTCONSUMABLELOTID";

	public static final String State = "STATE";

	public static final String Isnotorderresult = "ISNOTORDERRESULT";

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

	public static final String Printcount = "PRINTCOUNT";

	public static final String Subpartnumber = "SUBPARTNUMBER";

	public SfConsumablelotHistoryData() {
		this(new SfConsumablelotHistoryKey()); 
	}

	public SfConsumablelotHistoryData(SfConsumablelotHistoryKey key) {
		super(key, "SfConsumablelotHistory");
	}


	public String getConsumablelotname() {
		return this.repository().getString(SfConsumablelotHistoryData.Consumablelotname);
	}

	public SfConsumablelotHistoryData setConsumablelotname(String Consumablelotname) {
		this.repository().set(SfConsumablelotHistoryData.Consumablelotname, Consumablelotname);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfConsumablelotHistoryData.Enterpriseid);
	}

	public SfConsumablelotHistoryData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfConsumablelotHistoryData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfConsumablelotHistoryData.Plantid);
	}

	public SfConsumablelotHistoryData setPlantid(String Plantid) {
		this.repository().set(SfConsumablelotHistoryData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfConsumablelotHistoryData.Areaid);
	}

	public SfConsumablelotHistoryData setAreaid(String Areaid) {
		this.repository().set(SfConsumablelotHistoryData.Areaid, Areaid);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(SfConsumablelotHistoryData.Equipmentid);
	}

	public SfConsumablelotHistoryData setEquipmentid(String Equipmentid) {
		this.repository().set(SfConsumablelotHistoryData.Equipmentid, Equipmentid);
		return this;
	}

	public String getWarehouseid() {
		return this.repository().getString(SfConsumablelotHistoryData.Warehouseid);
	}

	public SfConsumablelotHistoryData setWarehouseid(String Warehouseid) {
		this.repository().set(SfConsumablelotHistoryData.Warehouseid, Warehouseid);
		return this;
	}

	public String getLocationid() {
		return this.repository().getString(SfConsumablelotHistoryData.Locationid);
	}

	public SfConsumablelotHistoryData setLocationid(String Locationid) {
		this.repository().set(SfConsumablelotHistoryData.Locationid, Locationid);
		return this;
	}

	public String getConsumabledefid() {
		return this.repository().getString(SfConsumablelotHistoryData.Consumabledefid);
	}

	public SfConsumablelotHistoryData setConsumabledefid(String Consumabledefid) {
		this.repository().set(SfConsumablelotHistoryData.Consumabledefid, Consumabledefid);
		return this;
	}

	public String getConsumabledefversion() {
		return this.repository().getString(SfConsumablelotHistoryData.Consumabledefversion);
	}

	public SfConsumablelotHistoryData setConsumabledefversion(String Consumabledefversion) {
		this.repository().set(SfConsumablelotHistoryData.Consumabledefversion, Consumabledefversion);
		return this;
	}

	public String getConsumablelotgroupid() {
		return this.repository().getString(SfConsumablelotHistoryData.Consumablelotgroupid);
	}

	public SfConsumablelotHistoryData setConsumablelotgroupid(String Consumablelotgroupid) {
		this.repository().set(SfConsumablelotHistoryData.Consumablelotgroupid, Consumablelotgroupid);
		return this;
	}

	public String getConsumablestate() {
		return this.repository().getString(SfConsumablelotHistoryData.Consumablestate);
	}

	public SfConsumablelotHistoryData setConsumablestate(String Consumablestate) {
		this.repository().set(SfConsumablelotHistoryData.Consumablestate, Consumablestate);
		return this;
	}

	public Double getCreatedqty() {
		return this.repository().getDouble(SfConsumablelotHistoryData.Createdqty);
	}

	public SfConsumablelotHistoryData setCreatedqty(Double Createdqty) {
		this.repository().set(SfConsumablelotHistoryData.Createdqty, Createdqty);
		return this;
	}

	public Double getConsumablelotqty() {
		return this.repository().getDouble(SfConsumablelotHistoryData.Consumablelotqty);
	}

	public SfConsumablelotHistoryData setConsumablelotqty(Double Consumablelotqty) {
		this.repository().set(SfConsumablelotHistoryData.Consumablelotqty, Consumablelotqty);
		return this;
	}

	public Date getExpireddate() {
		return this.repository().getDate(SfConsumablelotHistoryData.Expireddate);
	}

	public SfConsumablelotHistoryData setExpireddate(Date Expireddate) {
		this.repository().set(SfConsumablelotHistoryData.Expireddate, Expireddate);
		return this;
	}

	public String getIshold() {
		return this.repository().getString(SfConsumablelotHistoryData.Ishold);
	}

	public SfConsumablelotHistoryData setIshold(String Ishold) {
		this.repository().set(SfConsumablelotHistoryData.Ishold, Ishold);
		return this;
	}

	public Integer getOrderseq() {
		return this.repository().getInteger(SfConsumablelotHistoryData.Orderseq);
	}

	public SfConsumablelotHistoryData setOrderseq(Integer Orderseq) {
		this.repository().set(SfConsumablelotHistoryData.Orderseq, Orderseq);
		return this;
	}

	public String getParentconsumablelotid() {
		return this.repository().getString(SfConsumablelotHistoryData.Parentconsumablelotid);
	}

	public SfConsumablelotHistoryData setParentconsumablelotid(String Parentconsumablelotid) {
		this.repository().set(SfConsumablelotHistoryData.Parentconsumablelotid, Parentconsumablelotid);
		return this;
	}

	public String getState() {
		return this.repository().getString(SfConsumablelotHistoryData.State);
	}

	public SfConsumablelotHistoryData setState(String State) {
		this.repository().set(SfConsumablelotHistoryData.State, State);
		return this;
	}

	public String getIsnotorderresult() {
		return this.repository().getString(SfConsumablelotHistoryData.Isnotorderresult);
	}

	public SfConsumablelotHistoryData setIsnotorderresult(String Isnotorderresult) {
		this.repository().set(SfConsumablelotHistoryData.Isnotorderresult, Isnotorderresult);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfConsumablelotHistoryData.Description);
	}

	public SfConsumablelotHistoryData setDescription(String Description) {
		this.repository().set(SfConsumablelotHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfConsumablelotHistoryData.Creator);
	}

	public SfConsumablelotHistoryData setCreator(String Creator) {
		this.repository().set(SfConsumablelotHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfConsumablelotHistoryData.Createdtime);
	}

	public SfConsumablelotHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(SfConsumablelotHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfConsumablelotHistoryData.Modifier);
	}

	public SfConsumablelotHistoryData setModifier(String Modifier) {
		this.repository().set(SfConsumablelotHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfConsumablelotHistoryData.Modifiedtime);
	}

	public SfConsumablelotHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfConsumablelotHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(SfConsumablelotHistoryData.Txnid);
	}

	public SfConsumablelotHistoryData setTxnid(String Txnid) {
		this.repository().set(SfConsumablelotHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfConsumablelotHistoryData.Txnuser);
	}

	public SfConsumablelotHistoryData setTxnuser(String Txnuser) {
		this.repository().set(SfConsumablelotHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfConsumablelotHistoryData.Txntime);
	}

	public SfConsumablelotHistoryData setTxntime(Date Txntime) {
		this.repository().set(SfConsumablelotHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfConsumablelotHistoryData.Txngrouphistkey);
	}

	public SfConsumablelotHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfConsumablelotHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfConsumablelotHistoryData.Txnreasoncodeclass);
	}

	public SfConsumablelotHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfConsumablelotHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfConsumablelotHistoryData.Txnreasoncode);
	}

	public SfConsumablelotHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfConsumablelotHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfConsumablelotHistoryData.Txncomment);
	}

	public SfConsumablelotHistoryData setTxncomment(String Txncomment) {
		this.repository().set(SfConsumablelotHistoryData.Txncomment, Txncomment);
		return this;
	}

	public Integer getPrintcount() {
		return this.repository().getInteger(SfConsumablelotHistoryData.Printcount);
	}

	public SfConsumablelotHistoryData setPrintcount(Integer Printcount) {
		this.repository().set(SfConsumablelotHistoryData.Printcount, Printcount);
		return this;
	}

	public String getSubpartnumber() {
		return this.repository().getString(SfConsumablelotHistoryData.Subpartnumber);
	}

	public SfConsumablelotHistoryData setSubpartnumber(String Subpartnumber) {
		this.repository().set(SfConsumablelotHistoryData.Subpartnumber, Subpartnumber);
		return this;
	}


}