package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtConsumabletransactionData extends SQLData {

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Areaid = "AREAID";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Warehouseid = "WAREHOUSEID";

	public static final String Locationid = "LOCATIONID";

	public static final String Consumabledefid = "CONSUMABLEDEFID";

	public static final String Consumabledefversion = "CONSUMABLEDEFVERSION";

	public static final String Consumablelotid = "CONSUMABLELOTID";

	public static final String Transactiontype = "TRANSACTIONTYPE";

	public static final String Transactioncode = "TRANSACTIONCODE";

	public static final String Qty = "QTY";

	public static final String Towarehouseid = "TOWAREHOUSEID";

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

	public static final String Transactiondetailcode = "TRANSACTIONDETAILCODE";

	public static final String Teamid = "TEAMID";

	public static final String Customerid = "CUSTOMERID";

	public static final String Referencekey = "REFERENCEKEY";
	
	public static final String Cellid = "CELLID";

	public CtConsumabletransactionData() {
		this(new CtConsumabletransactionKey()); 
	}

	public CtConsumabletransactionData(CtConsumabletransactionKey key) {
		super(key, "CtConsumabletransaction");
	}


	public String getEnterpriseid() {
		return this.repository().getString(CtConsumabletransactionData.Enterpriseid);
	}

	public CtConsumabletransactionData setEnterpriseid(String Enterpriseid) {
		this.repository().set(CtConsumabletransactionData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(CtConsumabletransactionData.Plantid);
	}

	public CtConsumabletransactionData setPlantid(String Plantid) {
		this.repository().set(CtConsumabletransactionData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(CtConsumabletransactionData.Areaid);
	}

	public CtConsumabletransactionData setAreaid(String Areaid) {
		this.repository().set(CtConsumabletransactionData.Areaid, Areaid);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(CtConsumabletransactionData.Equipmentid);
	}

	public CtConsumabletransactionData setEquipmentid(String Equipmentid) {
		this.repository().set(CtConsumabletransactionData.Equipmentid, Equipmentid);
		return this;
	}

	public String getWarehouseid() {
		return this.repository().getString(CtConsumabletransactionData.Warehouseid);
	}

	public CtConsumabletransactionData setWarehouseid(String Warehouseid) {
		this.repository().set(CtConsumabletransactionData.Warehouseid, Warehouseid);
		return this;
	}

	public String getLocationid() {
		return this.repository().getString(CtConsumabletransactionData.Locationid);
	}

	public CtConsumabletransactionData setLocationid(String Locationid) {
		this.repository().set(CtConsumabletransactionData.Locationid, Locationid);
		return this;
	}

	public String getConsumabledefid() {
		return this.repository().getString(CtConsumabletransactionData.Consumabledefid);
	}

	public CtConsumabletransactionData setConsumabledefid(String Consumabledefid) {
		this.repository().set(CtConsumabletransactionData.Consumabledefid, Consumabledefid);
		return this;
	}

	public String getConsumabledefversion() {
		return this.repository().getString(CtConsumabletransactionData.Consumabledefversion);
	}

	public CtConsumabletransactionData setConsumabledefversion(String Consumabledefversion) {
		this.repository().set(CtConsumabletransactionData.Consumabledefversion, Consumabledefversion);
		return this;
	}

	public String getConsumablelotid() {
		return this.repository().getString(CtConsumabletransactionData.Consumablelotid);
	}

	public CtConsumabletransactionData setConsumablelotid(String Consumablelotid) {
		this.repository().set(CtConsumabletransactionData.Consumablelotid, Consumablelotid);
		return this;
	}

	public String getTransactiontype() {
		return this.repository().getString(CtConsumabletransactionData.Transactiontype);
	}

	public CtConsumabletransactionData setTransactiontype(String Transactiontype) {
		this.repository().set(CtConsumabletransactionData.Transactiontype, Transactiontype);
		return this;
	}

	public String getTransactioncode() {
		return this.repository().getString(CtConsumabletransactionData.Transactioncode);
	}

	public CtConsumabletransactionData setTransactioncode(String Transactioncode) {
		this.repository().set(CtConsumabletransactionData.Transactioncode, Transactioncode);
		return this;
	}

	public Double getQty() {
		return this.repository().getDouble(CtConsumabletransactionData.Qty);
	}

	public CtConsumabletransactionData setQty(Double Qty) {
		this.repository().set(CtConsumabletransactionData.Qty, Qty);
		return this;
	}

	public String getTowarehouseid() {
		return this.repository().getString(CtConsumabletransactionData.Towarehouseid);
	}

	public CtConsumabletransactionData setTowarehouseid(String Towarehouseid) {
		this.repository().set(CtConsumabletransactionData.Towarehouseid, Towarehouseid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtConsumabletransactionData.Description);
	}

	public CtConsumabletransactionData setDescription(String Description) {
		this.repository().set(CtConsumabletransactionData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtConsumabletransactionData.Creator);
	}

	public CtConsumabletransactionData setCreator(String Creator) {
		this.repository().set(CtConsumabletransactionData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtConsumabletransactionData.Createdtime);
	}

	public CtConsumabletransactionData setCreatedtime(Date Createdtime) {
		this.repository().set(CtConsumabletransactionData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtConsumabletransactionData.Modifier);
	}

	public CtConsumabletransactionData setModifier(String Modifier) {
		this.repository().set(CtConsumabletransactionData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtConsumabletransactionData.Modifiedtime);
	}

	public CtConsumabletransactionData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtConsumabletransactionData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtConsumabletransactionData.Txnid);
	}

	public CtConsumabletransactionData setTxnid(String Txnid) {
		this.repository().set(CtConsumabletransactionData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtConsumabletransactionData.Txnuser);
	}

	public CtConsumabletransactionData setTxnuser(String Txnuser) {
		this.repository().set(CtConsumabletransactionData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtConsumabletransactionData.Txntime);
	}

	public CtConsumabletransactionData setTxntime(Date Txntime) {
		this.repository().set(CtConsumabletransactionData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtConsumabletransactionData.Txngrouphistkey);
	}

	public CtConsumabletransactionData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtConsumabletransactionData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtConsumabletransactionData.Txnreasoncodeclass);
	}

	public CtConsumabletransactionData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtConsumabletransactionData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtConsumabletransactionData.Txnreasoncode);
	}

	public CtConsumabletransactionData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtConsumabletransactionData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtConsumabletransactionData.Txncomment);
	}

	public CtConsumabletransactionData setTxncomment(String Txncomment) {
		this.repository().set(CtConsumabletransactionData.Txncomment, Txncomment);
		return this;
	}

	public String getTransactiondetailcode() {
		return this.repository().getString(CtConsumabletransactionData.Transactiondetailcode);
	}

	public CtConsumabletransactionData setTransactiondetailcode(String Transactiondetailcode) {
		this.repository().set(CtConsumabletransactionData.Transactiondetailcode, Transactiondetailcode);
		return this;
	}

	public String getTeamid() {
		return this.repository().getString(CtConsumabletransactionData.Teamid);
	}

	public CtConsumabletransactionData setTeamid(String Teamid) {
		this.repository().set(CtConsumabletransactionData.Teamid, Teamid);
		return this;
	}

	public String getCustomerid() {
		return this.repository().getString(CtConsumabletransactionData.Customerid);
	}

	public CtConsumabletransactionData setCustomerid(String Customerid) {
		this.repository().set(CtConsumabletransactionData.Customerid, Customerid);
		return this;
	}

	public String getReferencekey() {
		return this.repository().getString(CtConsumabletransactionData.Referencekey);
	}

	public CtConsumabletransactionData setReferencekey(String Referencekey) {
		this.repository().set(CtConsumabletransactionData.Referencekey, Referencekey);
		return this;
	}
	
	public String getCellid() {
		return this.repository().getString(CtConsumabletransactionData.Cellid);
	}

	public CtConsumabletransactionData setCellid(String Cellid) {
		this.repository().set(CtConsumabletransactionData.Cellid, Cellid);
		return this;
	}


}