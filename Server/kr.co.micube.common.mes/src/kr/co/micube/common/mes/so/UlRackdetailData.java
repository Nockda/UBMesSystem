package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlRackdetailData extends SQLData {

	public static final String Qty = "QTY";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Cellid = "CELLID";

	public static final String Cellname = "CELLNAME";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Intime = "INTIME";

	public static final String Validstate = "VALIDSTATE";

	public static final String Outtime = "OUTTIME";

	public static final String Outqty = "OUTQTY";

	public static final String Inqty = "INQTY";

	public static final String Rackid = "RACKID";

	public static final String Rackname = "RACKNAME";

	public static final String Itemname = "ITEMNAME";

	public static final String Itemid = "ITEMID";

	public static final String Modifier = "MODIFIER";

	public UlRackdetailData() {
		this(new UlRackdetailKey()); 
	}

	public UlRackdetailData(UlRackdetailKey key) {
		super(key, "UlRackdetail");
	}


	public Double getQty() {
		return this.repository().getDouble(UlRackdetailData.Qty);
	}

	public UlRackdetailData setQty(Double Qty) {
		this.repository().set(UlRackdetailData.Qty, Qty);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlRackdetailData.Modifiedtime);
	}

	public UlRackdetailData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlRackdetailData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlRackdetailData.Creator);
	}

	public UlRackdetailData setCreator(String Creator) {
		this.repository().set(UlRackdetailData.Creator, Creator);
		return this;
	}

	public String getCellname() {
		return this.repository().getString(UlRackdetailData.Cellname);
	}

	public UlRackdetailData setCellname(String Cellname) {
		this.repository().set(UlRackdetailData.Cellname, Cellname);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlRackdetailData.Createdtime);
	}

	public UlRackdetailData setCreatedtime(Date Createdtime) {
		this.repository().set(UlRackdetailData.Createdtime, Createdtime);
		return this;
	}

	public Date getIntime() {
		return this.repository().getDate(UlRackdetailData.Intime);
	}

	public UlRackdetailData setIntime(Date Intime) {
		this.repository().set(UlRackdetailData.Intime, Intime);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlRackdetailData.Validstate);
	}

	public UlRackdetailData setValidstate(String Validstate) {
		this.repository().set(UlRackdetailData.Validstate, Validstate);
		return this;
	}

	public Date getOuttime() {
		return this.repository().getDate(UlRackdetailData.Outtime);
	}

	public UlRackdetailData setOuttime(Date Outtime) {
		this.repository().set(UlRackdetailData.Outtime, Outtime);
		return this;
	}

	public Double getOutqty() {
		return this.repository().getDouble(UlRackdetailData.Outqty);
	}

	public UlRackdetailData setOutqty(Double Outqty) {
		this.repository().set(UlRackdetailData.Outqty, Outqty);
		return this;
	}

	public Double getInqty() {
		return this.repository().getDouble(UlRackdetailData.Inqty);
	}

	public UlRackdetailData setInqty(Double Inqty) {
		this.repository().set(UlRackdetailData.Inqty, Inqty);
		return this;
	}

	public String getRackid() {
		return this.repository().getString(UlRackdetailData.Rackid);
	}

	public UlRackdetailData setRackid(String Rackid) {
		this.repository().set(UlRackdetailData.Rackid, Rackid);
		return this;
	}

	public String getRackname() {
		return this.repository().getString(UlRackdetailData.Rackname);
	}

	public UlRackdetailData setRackname(String Rackname) {
		this.repository().set(UlRackdetailData.Rackname, Rackname);
		return this;
	}

	public String getItemname() {
		return this.repository().getString(UlRackdetailData.Itemname);
	}

	public UlRackdetailData setItemname(String Itemname) {
		this.repository().set(UlRackdetailData.Itemname, Itemname);
		return this;
	}

	public String getItemid() {
		return this.repository().getString(UlRackdetailData.Itemid);
	}

	public UlRackdetailData setItemid(String Itemid) {
		this.repository().set(UlRackdetailData.Itemid, Itemid);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlRackdetailData.Modifier);
	}

	public UlRackdetailData setModifier(String Modifier) {
		this.repository().set(UlRackdetailData.Modifier, Modifier);
		return this;
	}


}