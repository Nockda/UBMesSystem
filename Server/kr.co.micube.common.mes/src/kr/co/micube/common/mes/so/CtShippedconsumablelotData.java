package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtShippedconsumablelotData extends SQLData {

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Creator = "CREATOR";

	public static final String Txntime = "TXNTIME";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Description = "DESCRIPTION";

	public static final String Modifier = "MODIFIER";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Qty = "QTY";

	public static final String Shippedqty = "SHIPPEDQTY";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnuser = "TXNUSER";

	public static final String Warehouseid = "WAREHOUSEID";

	public static final String Txnid = "TXNID";

	public static final String Areaid = "AREAID";

	public static final String Consumablelotid = "CONSUMABLELOTID";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Locationid = "LOCATIONID";

	public CtShippedconsumablelotData() {
		this(new CtShippedconsumablelotKey()); 
	}

	public CtShippedconsumablelotData(CtShippedconsumablelotKey key) {
		super(key, "CtShippedconsumablelot");
	}


	public String getTxncomment() {
		return this.repository().getString(CtShippedconsumablelotData.Txncomment);
	}

	public CtShippedconsumablelotData setTxncomment(String Txncomment) {
		this.repository().set(CtShippedconsumablelotData.Txncomment, Txncomment);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtShippedconsumablelotData.Creator);
	}

	public CtShippedconsumablelotData setCreator(String Creator) {
		this.repository().set(CtShippedconsumablelotData.Creator, Creator);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtShippedconsumablelotData.Txntime);
	}

	public CtShippedconsumablelotData setTxntime(Date Txntime) {
		this.repository().set(CtShippedconsumablelotData.Txntime, Txntime);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtShippedconsumablelotData.Createdtime);
	}

	public CtShippedconsumablelotData setCreatedtime(Date Createdtime) {
		this.repository().set(CtShippedconsumablelotData.Createdtime, Createdtime);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtShippedconsumablelotData.Description);
	}

	public CtShippedconsumablelotData setDescription(String Description) {
		this.repository().set(CtShippedconsumablelotData.Description, Description);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtShippedconsumablelotData.Modifier);
	}

	public CtShippedconsumablelotData setModifier(String Modifier) {
		this.repository().set(CtShippedconsumablelotData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtShippedconsumablelotData.Modifiedtime);
	}

	public CtShippedconsumablelotData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtShippedconsumablelotData.Modifiedtime, Modifiedtime);
		return this;
	}

	public Double getQty() {
		return this.repository().getDouble(CtShippedconsumablelotData.Qty);
	}

	public CtShippedconsumablelotData setQty(Double Qty) {
		this.repository().set(CtShippedconsumablelotData.Qty, Qty);
		return this;
	}

	public Double getShippedqty() {
		return this.repository().getDouble(CtShippedconsumablelotData.Shippedqty);
	}

	public CtShippedconsumablelotData setShippedqty(Double Shippedqty) {
		this.repository().set(CtShippedconsumablelotData.Shippedqty, Shippedqty);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtShippedconsumablelotData.Txnreasoncode);
	}

	public CtShippedconsumablelotData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtShippedconsumablelotData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtShippedconsumablelotData.Txngrouphistkey);
	}

	public CtShippedconsumablelotData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtShippedconsumablelotData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtShippedconsumablelotData.Txnuser);
	}

	public CtShippedconsumablelotData setTxnuser(String Txnuser) {
		this.repository().set(CtShippedconsumablelotData.Txnuser, Txnuser);
		return this;
	}

	public String getWarehouseid() {
		return this.repository().getString(CtShippedconsumablelotData.Warehouseid);
	}

	public CtShippedconsumablelotData setWarehouseid(String Warehouseid) {
		this.repository().set(CtShippedconsumablelotData.Warehouseid, Warehouseid);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtShippedconsumablelotData.Txnid);
	}

	public CtShippedconsumablelotData setTxnid(String Txnid) {
		this.repository().set(CtShippedconsumablelotData.Txnid, Txnid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(CtShippedconsumablelotData.Areaid);
	}

	public CtShippedconsumablelotData setAreaid(String Areaid) {
		this.repository().set(CtShippedconsumablelotData.Areaid, Areaid);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtShippedconsumablelotData.Txnreasoncodeclass);
	}

	public CtShippedconsumablelotData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtShippedconsumablelotData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(CtShippedconsumablelotData.Enterpriseid);
	}

	public CtShippedconsumablelotData setEnterpriseid(String Enterpriseid) {
		this.repository().set(CtShippedconsumablelotData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(CtShippedconsumablelotData.Plantid);
	}

	public CtShippedconsumablelotData setPlantid(String Plantid) {
		this.repository().set(CtShippedconsumablelotData.Plantid, Plantid);
		return this;
	}

	public String getLocationid() {
		return this.repository().getString(CtShippedconsumablelotData.Locationid);
	}

	public CtShippedconsumablelotData setLocationid(String Locationid) {
		this.repository().set(CtShippedconsumablelotData.Locationid, Locationid);
		return this;
	}


}