package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfConsumablelotData extends SQLData {

	public static final String Consumablelotid = "CONSUMABLELOTID";

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

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Lasttxnid = "LASTTXNID";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Printcount = "PRINTCOUNT";

	public static final String Subpartnumber = "SUBPARTNUMBER";

	public SfConsumablelotData() {
		this(new SfConsumablelotKey()); 
	}

	public SfConsumablelotData(SfConsumablelotKey key) {
		super(key, "SfConsumablelot");
	}


	public String getConsumablelotname() {
		return this.repository().getString(SfConsumablelotData.Consumablelotname);
	}

	public SfConsumablelotData setConsumablelotname(String Consumablelotname) {
		this.repository().set(SfConsumablelotData.Consumablelotname, Consumablelotname);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfConsumablelotData.Enterpriseid);
	}

	public SfConsumablelotData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfConsumablelotData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfConsumablelotData.Plantid);
	}

	public SfConsumablelotData setPlantid(String Plantid) {
		this.repository().set(SfConsumablelotData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfConsumablelotData.Areaid);
	}

	public SfConsumablelotData setAreaid(String Areaid) {
		this.repository().set(SfConsumablelotData.Areaid, Areaid);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(SfConsumablelotData.Equipmentid);
	}

	public SfConsumablelotData setEquipmentid(String Equipmentid) {
		this.repository().set(SfConsumablelotData.Equipmentid, Equipmentid);
		return this;
	}

	public String getWarehouseid() {
		return this.repository().getString(SfConsumablelotData.Warehouseid);
	}

	public SfConsumablelotData setWarehouseid(String Warehouseid) {
		this.repository().set(SfConsumablelotData.Warehouseid, Warehouseid);
		return this;
	}

	public String getLocationid() {
		return this.repository().getString(SfConsumablelotData.Locationid);
	}

	public SfConsumablelotData setLocationid(String Locationid) {
		this.repository().set(SfConsumablelotData.Locationid, Locationid);
		return this;
	}

	public String getConsumabledefid() {
		return this.repository().getString(SfConsumablelotData.Consumabledefid);
	}

	public SfConsumablelotData setConsumabledefid(String Consumabledefid) {
		this.repository().set(SfConsumablelotData.Consumabledefid, Consumabledefid);
		return this;
	}

	public String getConsumabledefversion() {
		return this.repository().getString(SfConsumablelotData.Consumabledefversion);
	}

	public SfConsumablelotData setConsumabledefversion(String Consumabledefversion) {
		this.repository().set(SfConsumablelotData.Consumabledefversion, Consumabledefversion);
		return this;
	}

	public String getConsumablelotgroupid() {
		return this.repository().getString(SfConsumablelotData.Consumablelotgroupid);
	}

	public SfConsumablelotData setConsumablelotgroupid(String Consumablelotgroupid) {
		this.repository().set(SfConsumablelotData.Consumablelotgroupid, Consumablelotgroupid);
		return this;
	}

	public String getConsumablestate() {
		return this.repository().getString(SfConsumablelotData.Consumablestate);
	}

	public SfConsumablelotData setConsumablestate(String Consumablestate) {
		this.repository().set(SfConsumablelotData.Consumablestate, Consumablestate);
		return this;
	}

	public Double getCreatedqty() {
		return this.repository().getDouble(SfConsumablelotData.Createdqty);
	}

	public SfConsumablelotData setCreatedqty(Double Createdqty) {
		this.repository().set(SfConsumablelotData.Createdqty, Createdqty);
		return this;
	}

	public Double getConsumablelotqty() {
		return this.repository().getDouble(SfConsumablelotData.Consumablelotqty);
	}

	public SfConsumablelotData setConsumablelotqty(Double Consumablelotqty) {
		this.repository().set(SfConsumablelotData.Consumablelotqty, Consumablelotqty);
		return this;
	}

	public Date getExpireddate() {
		return this.repository().getDate(SfConsumablelotData.Expireddate);
	}

	public SfConsumablelotData setExpireddate(Date Expireddate) {
		this.repository().set(SfConsumablelotData.Expireddate, Expireddate);
		return this;
	}

	public String getIshold() {
		return this.repository().getString(SfConsumablelotData.Ishold);
	}

	public SfConsumablelotData setIshold(String Ishold) {
		this.repository().set(SfConsumablelotData.Ishold, Ishold);
		return this;
	}

	public Integer getOrderseq() {
		return this.repository().getInteger(SfConsumablelotData.Orderseq);
	}

	public SfConsumablelotData setOrderseq(Integer Orderseq) {
		this.repository().set(SfConsumablelotData.Orderseq, Orderseq);
		return this;
	}

	public String getParentconsumablelotid() {
		return this.repository().getString(SfConsumablelotData.Parentconsumablelotid);
	}

	public SfConsumablelotData setParentconsumablelotid(String Parentconsumablelotid) {
		this.repository().set(SfConsumablelotData.Parentconsumablelotid, Parentconsumablelotid);
		return this;
	}

	public String getState() {
		return this.repository().getString(SfConsumablelotData.State);
	}

	public SfConsumablelotData setState(String State) {
		this.repository().set(SfConsumablelotData.State, State);
		return this;
	}

	public String getIsnotorderresult() {
		return this.repository().getString(SfConsumablelotData.Isnotorderresult);
	}

	public SfConsumablelotData setIsnotorderresult(String Isnotorderresult) {
		this.repository().set(SfConsumablelotData.Isnotorderresult, Isnotorderresult);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfConsumablelotData.Description);
	}

	public SfConsumablelotData setDescription(String Description) {
		this.repository().set(SfConsumablelotData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfConsumablelotData.Creator);
	}

	public SfConsumablelotData setCreator(String Creator) {
		this.repository().set(SfConsumablelotData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfConsumablelotData.Createdtime);
	}

	public SfConsumablelotData setCreatedtime(Date Createdtime) {
		this.repository().set(SfConsumablelotData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfConsumablelotData.Modifier);
	}

	public SfConsumablelotData setModifier(String Modifier) {
		this.repository().set(SfConsumablelotData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfConsumablelotData.Modifiedtime);
	}

	public SfConsumablelotData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfConsumablelotData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfConsumablelotData.Lasttxnhistkey);
	}

	public SfConsumablelotData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfConsumablelotData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfConsumablelotData.Lasttxnid);
	}

	public SfConsumablelotData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfConsumablelotData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfConsumablelotData.Lasttxnuser);
	}

	public SfConsumablelotData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfConsumablelotData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfConsumablelotData.Lasttxntime);
	}

	public SfConsumablelotData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfConsumablelotData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfConsumablelotData.Lasttxncomment);
	}

	public SfConsumablelotData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfConsumablelotData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public Integer getPrintcount() {
		return this.repository().getInteger(SfConsumablelotData.Printcount);
	}

	public SfConsumablelotData setPrintcount(Integer Printcount) {
		this.repository().set(SfConsumablelotData.Printcount, Printcount);
		return this;
	}

	public String getSubpartnumber() {
		return this.repository().getString(SfConsumablelotData.Subpartnumber);
	}

	public SfConsumablelotData setSubpartnumber(String Subpartnumber) {
		this.repository().set(SfConsumablelotData.Subpartnumber, Subpartnumber);
		return this;
	}


}