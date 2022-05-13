package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlCellData extends SQLData {

	public static final String Cellid = "CELLID";

	public static final String Cellname = "CELLNAME";

	public static final String Cellgroupid = "CELLGROUPID";

	public static final String Consumabledefid = "CONSUMABLEDEFID";

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

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Lasttxnid = "LASTTXNID";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public static final String Displaysequence = "DISPLAYSEQUENCE";

	public static final String Location = "LOCATION";

	public UlCellData() {
		this(new UlCellKey()); 
	}

	public UlCellData(UlCellKey key) {
		super(key, "UlCell");
	}


	public String getCellname() {
		return this.repository().getString(UlCellData.Cellname);
	}

	public UlCellData setCellname(String Cellname) {
		this.repository().set(UlCellData.Cellname, Cellname);
		return this;
	}

	public String getCellgroupid() {
		return this.repository().getString(UlCellData.Cellgroupid);
	}

	public UlCellData setCellgroupid(String Cellgroupid) {
		this.repository().set(UlCellData.Cellgroupid, Cellgroupid);
		return this;
	}

	public String getConsumabledefid() {
		return this.repository().getString(UlCellData.Consumabledefid);
	}

	public UlCellData setConsumabledefid(String Consumabledefid) {
		this.repository().set(UlCellData.Consumabledefid, Consumabledefid);
		return this;
	}

	public Double getQty() {
		return this.repository().getDouble(UlCellData.Qty);
	}

	public UlCellData setQty(Double Qty) {
		this.repository().set(UlCellData.Qty, Qty);
		return this;
	}

	public Date getIntime() {
		return this.repository().getDate(UlCellData.Intime);
	}

	public UlCellData setIntime(Date Intime) {
		this.repository().set(UlCellData.Intime, Intime);
		return this;
	}

	public Double getInqty() {
		return this.repository().getDouble(UlCellData.Inqty);
	}

	public UlCellData setInqty(Double Inqty) {
		this.repository().set(UlCellData.Inqty, Inqty);
		return this;
	}

	public Date getOuttime() {
		return this.repository().getDate(UlCellData.Outtime);
	}

	public UlCellData setOuttime(Date Outtime) {
		this.repository().set(UlCellData.Outtime, Outtime);
		return this;
	}

	public Double getOutqty() {
		return this.repository().getDouble(UlCellData.Outqty);
	}

	public UlCellData setOutqty(Double Outqty) {
		this.repository().set(UlCellData.Outqty, Outqty);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlCellData.Description);
	}

	public UlCellData setDescription(String Description) {
		this.repository().set(UlCellData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlCellData.Creator);
	}

	public UlCellData setCreator(String Creator) {
		this.repository().set(UlCellData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlCellData.Createdtime);
	}

	public UlCellData setCreatedtime(Date Createdtime) {
		this.repository().set(UlCellData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlCellData.Modifier);
	}

	public UlCellData setModifier(String Modifier) {
		this.repository().set(UlCellData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlCellData.Modifiedtime);
	}

	public UlCellData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlCellData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(UlCellData.Lasttxnhistkey);
	}

	public UlCellData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(UlCellData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(UlCellData.Lasttxnid);
	}

	public UlCellData setLasttxnid(String Lasttxnid) {
		this.repository().set(UlCellData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(UlCellData.Lasttxnuser);
	}

	public UlCellData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(UlCellData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(UlCellData.Lasttxntime);
	}

	public UlCellData setLasttxntime(Date Lasttxntime) {
		this.repository().set(UlCellData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(UlCellData.Lasttxncomment);
	}

	public UlCellData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(UlCellData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlCellData.Validstate);
	}

	public UlCellData setValidstate(String Validstate) {
		this.repository().set(UlCellData.Validstate, Validstate);
		return this;
	}

	public Double getDisplaysequence() {
		return this.repository().getDouble(UlCellData.Displaysequence);
	}

	public UlCellData setDisplaysequence(Double Displaysequence) {
		this.repository().set(UlCellData.Displaysequence, Displaysequence);
		return this;
	}

	public String getLocation() {
		return this.repository().getString(UlCellData.Location);
	}

	public UlCellData setLocation(String Location) {
		this.repository().set(UlCellData.Location, Location);
		return this;
	}


}