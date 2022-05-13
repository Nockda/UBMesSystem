package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfWorkorderbomData extends SQLData {

	public static final String Workorderid = "WORKORDERID";

	public static final String Consumabledefid = "CONSUMABLEDEFID";

	public static final String Consumabledefversion = "CONSUMABLEDEFVERSION";

	public static final String Qty = "QTY";

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

	public SfWorkorderbomData() {
		this(new SfWorkorderbomKey()); 
	}

	public SfWorkorderbomData(SfWorkorderbomKey key) {
		super(key, "SfWorkorderbom");
	}


	public Double getQty() {
		return this.repository().getDouble(SfWorkorderbomData.Qty);
	}

	public SfWorkorderbomData setQty(Double Qty) {
		this.repository().set(SfWorkorderbomData.Qty, Qty);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfWorkorderbomData.Description);
	}

	public SfWorkorderbomData setDescription(String Description) {
		this.repository().set(SfWorkorderbomData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfWorkorderbomData.Creator);
	}

	public SfWorkorderbomData setCreator(String Creator) {
		this.repository().set(SfWorkorderbomData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfWorkorderbomData.Createdtime);
	}

	public SfWorkorderbomData setCreatedtime(Date Createdtime) {
		this.repository().set(SfWorkorderbomData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfWorkorderbomData.Modifier);
	}

	public SfWorkorderbomData setModifier(String Modifier) {
		this.repository().set(SfWorkorderbomData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfWorkorderbomData.Modifiedtime);
	}

	public SfWorkorderbomData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfWorkorderbomData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfWorkorderbomData.Lasttxnhistkey);
	}

	public SfWorkorderbomData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfWorkorderbomData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfWorkorderbomData.Lasttxnid);
	}

	public SfWorkorderbomData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfWorkorderbomData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfWorkorderbomData.Lasttxnuser);
	}

	public SfWorkorderbomData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfWorkorderbomData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfWorkorderbomData.Lasttxntime);
	}

	public SfWorkorderbomData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfWorkorderbomData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfWorkorderbomData.Lasttxncomment);
	}

	public SfWorkorderbomData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfWorkorderbomData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfWorkorderbomData.Validstate);
	}

	public SfWorkorderbomData setValidstate(String Validstate) {
		this.repository().set(SfWorkorderbomData.Validstate, Validstate);
		return this;
	}


}