package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtConsumablelotgenealData extends SQLData {

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Consumablelotid = "CONSUMABLELOTID";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Areaid = "AREAID";

	public static final String Warehouseid = "WAREHOUSEID";

	public static final String Consumabledefid = "CONSUMABLEDEFID";

	public static final String Consumabledefversion = "CONSUMABLEDEFVERSION";

	public static final String Destinationlotid = "DESTINATIONLOTID";

	public static final String Txntype = "TXNTYPE";

	public static final String Originalqty = "ORIGINALQTY";

	public static final String Qty = "QTY";

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

	public CtConsumablelotgenealData() {
		this(new CtConsumablelotgenealKey()); 
	}

	public CtConsumablelotgenealData(CtConsumablelotgenealKey key) {
		super(key, "CtConsumablelotgeneal");
		this.txnInfo().setHistoryTable(true);
	}


	public String getEnterpriseid() {
		return this.repository().getString(CtConsumablelotgenealData.Enterpriseid);
	}

	public CtConsumablelotgenealData setEnterpriseid(String Enterpriseid) {
		this.repository().set(CtConsumablelotgenealData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(CtConsumablelotgenealData.Plantid);
	}

	public CtConsumablelotgenealData setPlantid(String Plantid) {
		this.repository().set(CtConsumablelotgenealData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(CtConsumablelotgenealData.Areaid);
	}

	public CtConsumablelotgenealData setAreaid(String Areaid) {
		this.repository().set(CtConsumablelotgenealData.Areaid, Areaid);
		return this;
	}

	public String getWarehouseid() {
		return this.repository().getString(CtConsumablelotgenealData.Warehouseid);
	}

	public CtConsumablelotgenealData setWarehouseid(String Warehouseid) {
		this.repository().set(CtConsumablelotgenealData.Warehouseid, Warehouseid);
		return this;
	}

	public String getConsumabledefid() {
		return this.repository().getString(CtConsumablelotgenealData.Consumabledefid);
	}

	public CtConsumablelotgenealData setConsumabledefid(String Consumabledefid) {
		this.repository().set(CtConsumablelotgenealData.Consumabledefid, Consumabledefid);
		return this;
	}

	public String getConsumabledefversion() {
		return this.repository().getString(CtConsumablelotgenealData.Consumabledefversion);
	}

	public CtConsumablelotgenealData setConsumabledefversion(String Consumabledefversion) {
		this.repository().set(CtConsumablelotgenealData.Consumabledefversion, Consumabledefversion);
		return this;
	}

	public String getDestinationlotid() {
		return this.repository().getString(CtConsumablelotgenealData.Destinationlotid);
	}

	public CtConsumablelotgenealData setDestinationlotid(String Destinationlotid) {
		this.repository().set(CtConsumablelotgenealData.Destinationlotid, Destinationlotid);
		return this;
	}

	public String getTxntype() {
		return this.repository().getString(CtConsumablelotgenealData.Txntype);
	}

	public CtConsumablelotgenealData setTxntype(String Txntype) {
		this.repository().set(CtConsumablelotgenealData.Txntype, Txntype);
		return this;
	}

	public Double getOriginalqty() {
		return this.repository().getDouble(CtConsumablelotgenealData.Originalqty);
	}

	public CtConsumablelotgenealData setOriginalqty(Double Originalqty) {
		this.repository().set(CtConsumablelotgenealData.Originalqty, Originalqty);
		return this;
	}

	public Double getQty() {
		return this.repository().getDouble(CtConsumablelotgenealData.Qty);
	}

	public CtConsumablelotgenealData setQty(Double Qty) {
		this.repository().set(CtConsumablelotgenealData.Qty, Qty);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtConsumablelotgenealData.Description);
	}

	public CtConsumablelotgenealData setDescription(String Description) {
		this.repository().set(CtConsumablelotgenealData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtConsumablelotgenealData.Creator);
	}

	public CtConsumablelotgenealData setCreator(String Creator) {
		this.repository().set(CtConsumablelotgenealData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtConsumablelotgenealData.Createdtime);
	}

	public CtConsumablelotgenealData setCreatedtime(Date Createdtime) {
		this.repository().set(CtConsumablelotgenealData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtConsumablelotgenealData.Modifier);
	}

	public CtConsumablelotgenealData setModifier(String Modifier) {
		this.repository().set(CtConsumablelotgenealData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtConsumablelotgenealData.Modifiedtime);
	}

	public CtConsumablelotgenealData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtConsumablelotgenealData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtConsumablelotgenealData.Txnid);
	}

	public CtConsumablelotgenealData setTxnid(String Txnid) {
		this.repository().set(CtConsumablelotgenealData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtConsumablelotgenealData.Txnuser);
	}

	public CtConsumablelotgenealData setTxnuser(String Txnuser) {
		this.repository().set(CtConsumablelotgenealData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtConsumablelotgenealData.Txntime);
	}

	public CtConsumablelotgenealData setTxntime(Date Txntime) {
		this.repository().set(CtConsumablelotgenealData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtConsumablelotgenealData.Txngrouphistkey);
	}

	public CtConsumablelotgenealData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtConsumablelotgenealData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtConsumablelotgenealData.Txnreasoncodeclass);
	}

	public CtConsumablelotgenealData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtConsumablelotgenealData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtConsumablelotgenealData.Txnreasoncode);
	}

	public CtConsumablelotgenealData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtConsumablelotgenealData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtConsumablelotgenealData.Txncomment);
	}

	public CtConsumablelotgenealData setTxncomment(String Txncomment) {
		this.repository().set(CtConsumablelotgenealData.Txncomment, Txncomment);
		return this;
	}


}