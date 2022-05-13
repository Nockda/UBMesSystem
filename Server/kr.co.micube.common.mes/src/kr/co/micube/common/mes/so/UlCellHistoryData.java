package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlCellHistoryData extends SQLData {

	public static final String Cellid = "CELLID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Cellname = "CELLNAME";

	public static final String Cellgroupid = "CELLGROUPID";

	public static final String Itemid = "ITEMID";

	public static final String Itemname = "ITEMNAME";

	public static final String Qty = "QTY";

	public static final String Intime = "INTIME";

	public static final String Inqty = "INQTY";

	public static final String Outtime = "OUTTIME";

	public static final String Outqty = "OUTQTY";

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

	public static final String Displaysequence = "DISPLAYSEQUENCE";

	public static final String Location = "LOCATION";

	public UlCellHistoryData() {
		this(new UlCellHistoryKey()); 
	}

	public UlCellHistoryData(UlCellHistoryKey key) {
		super(key, "UlCellHistory");
	}


	public String getCellname() {
		return this.repository().getString(UlCellHistoryData.Cellname);
	}

	public UlCellHistoryData setCellname(String Cellname) {
		this.repository().set(UlCellHistoryData.Cellname, Cellname);
		return this;
	}

	public String getCellgroupid() {
		return this.repository().getString(UlCellHistoryData.Cellgroupid);
	}

	public UlCellHistoryData setCellgroupid(String Cellgroupid) {
		this.repository().set(UlCellHistoryData.Cellgroupid, Cellgroupid);
		return this;
	}

	public String getItemid() {
		return this.repository().getString(UlCellHistoryData.Itemid);
	}

	public UlCellHistoryData setItemid(String Itemid) {
		this.repository().set(UlCellHistoryData.Itemid, Itemid);
		return this;
	}

	public String getItemname() {
		return this.repository().getString(UlCellHistoryData.Itemname);
	}

	public UlCellHistoryData setItemname(String Itemname) {
		this.repository().set(UlCellHistoryData.Itemname, Itemname);
		return this;
	}

	public Double getQty() {
		return this.repository().getDouble(UlCellHistoryData.Qty);
	}

	public UlCellHistoryData setQty(Double Qty) {
		this.repository().set(UlCellHistoryData.Qty, Qty);
		return this;
	}

	public Date getIntime() {
		return this.repository().getDate(UlCellHistoryData.Intime);
	}

	public UlCellHistoryData setIntime(Date Intime) {
		this.repository().set(UlCellHistoryData.Intime, Intime);
		return this;
	}

	public Double getInqty() {
		return this.repository().getDouble(UlCellHistoryData.Inqty);
	}

	public UlCellHistoryData setInqty(Double Inqty) {
		this.repository().set(UlCellHistoryData.Inqty, Inqty);
		return this;
	}

	public Date getOuttime() {
		return this.repository().getDate(UlCellHistoryData.Outtime);
	}

	public UlCellHistoryData setOuttime(Date Outtime) {
		this.repository().set(UlCellHistoryData.Outtime, Outtime);
		return this;
	}

	public Double getOutqty() {
		return this.repository().getDouble(UlCellHistoryData.Outqty);
	}

	public UlCellHistoryData setOutqty(Double Outqty) {
		this.repository().set(UlCellHistoryData.Outqty, Outqty);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlCellHistoryData.Description);
	}

	public UlCellHistoryData setDescription(String Description) {
		this.repository().set(UlCellHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlCellHistoryData.Creator);
	}

	public UlCellHistoryData setCreator(String Creator) {
		this.repository().set(UlCellHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlCellHistoryData.Createdtime);
	}

	public UlCellHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(UlCellHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlCellHistoryData.Modifier);
	}

	public UlCellHistoryData setModifier(String Modifier) {
		this.repository().set(UlCellHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlCellHistoryData.Modifiedtime);
	}

	public UlCellHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlCellHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlCellHistoryData.Txnid);
	}

	public UlCellHistoryData setTxnid(String Txnid) {
		this.repository().set(UlCellHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlCellHistoryData.Txnuser);
	}

	public UlCellHistoryData setTxnuser(String Txnuser) {
		this.repository().set(UlCellHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlCellHistoryData.Txntime);
	}

	public UlCellHistoryData setTxntime(Date Txntime) {
		this.repository().set(UlCellHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlCellHistoryData.Txngrouphistkey);
	}

	public UlCellHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlCellHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlCellHistoryData.Txnreasoncodeclass);
	}

	public UlCellHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlCellHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlCellHistoryData.Txnreasoncode);
	}

	public UlCellHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlCellHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlCellHistoryData.Txncomment);
	}

	public UlCellHistoryData setTxncomment(String Txncomment) {
		this.repository().set(UlCellHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlCellHistoryData.Validstate);
	}

	public UlCellHistoryData setValidstate(String Validstate) {
		this.repository().set(UlCellHistoryData.Validstate, Validstate);
		return this;
	}

	public Double getDisplaysequence() {
		return this.repository().getDouble(UlCellHistoryData.Displaysequence);
	}

	public UlCellHistoryData setDisplaysequence(Double Displaysequence) {
		this.repository().set(UlCellHistoryData.Displaysequence, Displaysequence);
		return this;
	}

	public String getLocation() {
		return this.repository().getString(UlCellHistoryData.Location);
	}

	public UlCellHistoryData setLocation(String Location) {
		this.repository().set(UlCellHistoryData.Location, Location);
		return this;
	}


}