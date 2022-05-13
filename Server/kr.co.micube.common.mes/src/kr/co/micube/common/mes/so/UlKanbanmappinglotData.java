package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlKanbanmappinglotData extends SQLData {

	public static final String Reqcode = "REQCODE";

	public static final String Lotid = "LOTID";

	public static final String Cellid = "CELLID";

	public static final String Unit = "UNIT";

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

	public UlKanbanmappinglotData() {
		this(new UlKanbanmappinglotKey()); 
	}

	public UlKanbanmappinglotData(UlKanbanmappinglotKey key) {
		super(key, "UlKanbanmappinglot");
		this.txnInfo().setHistoryTable(true);
	}


	public String getCellid() {
		return this.repository().getString(UlKanbanmappinglotData.Cellid);
	}

	public UlKanbanmappinglotData setCellid(String Cellid) {
		this.repository().set(UlKanbanmappinglotData.Cellid, Cellid);
		return this;
	}

	public String getUnit() {
		return this.repository().getString(UlKanbanmappinglotData.Unit);
	}

	public UlKanbanmappinglotData setUnit(String Unit) {
		this.repository().set(UlKanbanmappinglotData.Unit, Unit);
		return this;
	}

	public Double getQty() {
		return this.repository().getDouble(UlKanbanmappinglotData.Qty);
	}

	public UlKanbanmappinglotData setQty(Double Qty) {
		this.repository().set(UlKanbanmappinglotData.Qty, Qty);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlKanbanmappinglotData.Description);
	}

	public UlKanbanmappinglotData setDescription(String Description) {
		this.repository().set(UlKanbanmappinglotData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlKanbanmappinglotData.Creator);
	}

	public UlKanbanmappinglotData setCreator(String Creator) {
		this.repository().set(UlKanbanmappinglotData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlKanbanmappinglotData.Createdtime);
	}

	public UlKanbanmappinglotData setCreatedtime(Date Createdtime) {
		this.repository().set(UlKanbanmappinglotData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlKanbanmappinglotData.Modifier);
	}

	public UlKanbanmappinglotData setModifier(String Modifier) {
		this.repository().set(UlKanbanmappinglotData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlKanbanmappinglotData.Modifiedtime);
	}

	public UlKanbanmappinglotData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlKanbanmappinglotData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlKanbanmappinglotData.Txnid);
	}

	public UlKanbanmappinglotData setTxnid(String Txnid) {
		this.repository().set(UlKanbanmappinglotData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlKanbanmappinglotData.Txnuser);
	}

	public UlKanbanmappinglotData setTxnuser(String Txnuser) {
		this.repository().set(UlKanbanmappinglotData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlKanbanmappinglotData.Txntime);
	}

	public UlKanbanmappinglotData setTxntime(Date Txntime) {
		this.repository().set(UlKanbanmappinglotData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlKanbanmappinglotData.Txngrouphistkey);
	}

	public UlKanbanmappinglotData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlKanbanmappinglotData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlKanbanmappinglotData.Txnreasoncodeclass);
	}

	public UlKanbanmappinglotData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlKanbanmappinglotData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlKanbanmappinglotData.Txnreasoncode);
	}

	public UlKanbanmappinglotData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlKanbanmappinglotData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlKanbanmappinglotData.Txncomment);
	}

	public UlKanbanmappinglotData setTxncomment(String Txncomment) {
		this.repository().set(UlKanbanmappinglotData.Txncomment, Txncomment);
		return this;
	}


}