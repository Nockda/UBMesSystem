package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlKanbanData extends SQLData {

	public static final String Reqcode = "REQCODE";

	public static final String Reqdate = "REQDATE";

	public static final String State = "STATE";

	public static final String Resdate = "RESDATE";

	public static final String Cellid = "CELLID";

	public static final String Locationid = "LOCATIONID";

	public static final String Consumabledefid = "CONSUMABLEDEFID";

	public static final String Unit = "UNIT";

	public static final String Qty = "QTY";

	public static final String Fromwarehouseid = "FROMWAREHOUSEID";

	public static final String Towarehouseid = "TOWAREHOUSEID";

	public static final String Department = "DEPARTMENT";

	public static final String Userid = "USERID";

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

	public static final String Lotqty = "LOTQTY";

	public UlKanbanData() {
		this(new UlKanbanKey()); 
	}

	public UlKanbanData(UlKanbanKey key) {
		super(key, "UlKanban");
		this.txnInfo().setHistoryTable(true);
	}


	public Date getReqdate() {
		return this.repository().getDate(UlKanbanData.Reqdate);
	}

	public UlKanbanData setReqdate(Date Reqdate) {
		this.repository().set(UlKanbanData.Reqdate, Reqdate);
		return this;
	}

	public String getState() {
		return this.repository().getString(UlKanbanData.State);
	}

	public UlKanbanData setState(String State) {
		this.repository().set(UlKanbanData.State, State);
		return this;
	}

	public Date getResdate() {
		return this.repository().getDate(UlKanbanData.Resdate);
	}

	public UlKanbanData setResdate(Date Resdate) {
		this.repository().set(UlKanbanData.Resdate, Resdate);
		return this;
	}

	public String getCellid() {
		return this.repository().getString(UlKanbanData.Cellid);
	}

	public UlKanbanData setCellid(String Cellid) {
		this.repository().set(UlKanbanData.Cellid, Cellid);
		return this;
	}

	public String getLocationid() {
		return this.repository().getString(UlKanbanData.Locationid);
	}

	public UlKanbanData setLocationid(String Locationid) {
		this.repository().set(UlKanbanData.Locationid, Locationid);
		return this;
	}

	public String getConsumabledefid() {
		return this.repository().getString(UlKanbanData.Consumabledefid);
	}

	public UlKanbanData setConsumabledefid(String Consumabledefid) {
		this.repository().set(UlKanbanData.Consumabledefid, Consumabledefid);
		return this;
	}

	public String getUnit() {
		return this.repository().getString(UlKanbanData.Unit);
	}

	public UlKanbanData setUnit(String Unit) {
		this.repository().set(UlKanbanData.Unit, Unit);
		return this;
	}

	public Double getQty() {
		return this.repository().getDouble(UlKanbanData.Qty);
	}

	public UlKanbanData setQty(Double Qty) {
		this.repository().set(UlKanbanData.Qty, Qty);
		return this;
	}

	public String getFromwarehouseid() {
		return this.repository().getString(UlKanbanData.Fromwarehouseid);
	}

	public UlKanbanData setFromwarehouseid(String Fromwarehouseid) {
		this.repository().set(UlKanbanData.Fromwarehouseid, Fromwarehouseid);
		return this;
	}

	public String getTowarehouseid() {
		return this.repository().getString(UlKanbanData.Towarehouseid);
	}

	public UlKanbanData setTowarehouseid(String Towarehouseid) {
		this.repository().set(UlKanbanData.Towarehouseid, Towarehouseid);
		return this;
	}

	public String getDepartment() {
		return this.repository().getString(UlKanbanData.Department);
	}

	public UlKanbanData setDepartment(String Department) {
		this.repository().set(UlKanbanData.Department, Department);
		return this;
	}

	public String getUserid() {
		return this.repository().getString(UlKanbanData.Userid);
	}

	public UlKanbanData setUserid(String Userid) {
		this.repository().set(UlKanbanData.Userid, Userid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlKanbanData.Description);
	}

	public UlKanbanData setDescription(String Description) {
		this.repository().set(UlKanbanData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlKanbanData.Creator);
	}

	public UlKanbanData setCreator(String Creator) {
		this.repository().set(UlKanbanData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlKanbanData.Createdtime);
	}

	public UlKanbanData setCreatedtime(Date Createdtime) {
		this.repository().set(UlKanbanData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlKanbanData.Modifier);
	}

	public UlKanbanData setModifier(String Modifier) {
		this.repository().set(UlKanbanData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlKanbanData.Modifiedtime);
	}

	public UlKanbanData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlKanbanData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlKanbanData.Txnid);
	}

	public UlKanbanData setTxnid(String Txnid) {
		this.repository().set(UlKanbanData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlKanbanData.Txnuser);
	}

	public UlKanbanData setTxnuser(String Txnuser) {
		this.repository().set(UlKanbanData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlKanbanData.Txntime);
	}

	public UlKanbanData setTxntime(Date Txntime) {
		this.repository().set(UlKanbanData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlKanbanData.Txngrouphistkey);
	}

	public UlKanbanData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlKanbanData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlKanbanData.Txnreasoncodeclass);
	}

	public UlKanbanData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlKanbanData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlKanbanData.Txnreasoncode);
	}

	public UlKanbanData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlKanbanData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlKanbanData.Txncomment);
	}

	public UlKanbanData setTxncomment(String Txncomment) {
		this.repository().set(UlKanbanData.Txncomment, Txncomment);
		return this;
	}

	public Double getLotqty() {
		return this.repository().getDouble(UlKanbanData.Lotqty);
	}

	public UlKanbanData setLotqty(Double Lotqty) {
		this.repository().set(UlKanbanData.Lotqty, Lotqty);
		return this;
	}


}