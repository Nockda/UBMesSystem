package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class InspitemData extends SQLData {

	public static final String Itemid = "ITEMID";

	public static final String Itemname = "ITEMNAME";

	public static final String Inputtype = "INPUTTYPE";

	public static final String Unit = "UNIT";

	public static final String Decimalplace = "DECIMALPLACE";

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

	public InspitemData() {
		this(new InspitemKey()); 
	}

	public InspitemData(InspitemKey key) {
		super(key, "UlInspitem");
	}


	public String getItemname() {
		return this.repository().getString(InspitemData.Itemname);
	}

	public InspitemData setItemname(String Itemname) {
		this.repository().set(InspitemData.Itemname, Itemname);
		return this;
	}

	public String getInputtype() {
		return this.repository().getString(InspitemData.Inputtype);
	}

	public InspitemData setInputtype(String Inputtype) {
		this.repository().set(InspitemData.Inputtype, Inputtype);
		return this;
	}

	public String getUnit() {
		return this.repository().getString(InspitemData.Unit);
	}

	public InspitemData setUnit(String Unit) {
		this.repository().set(InspitemData.Unit, Unit);
		return this;
	}

	public Double getDecimalplace() {
		return this.repository().getDouble(InspitemData.Decimalplace);
	}

	public InspitemData setDecimalplace(Double Decimalplace) {
		this.repository().set(InspitemData.Decimalplace, Decimalplace);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(InspitemData.Creator);
	}

	public InspitemData setCreator(String Creator) {
		this.repository().set(InspitemData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(InspitemData.Createdtime);
	}

	public InspitemData setCreatedtime(Date Createdtime) {
		this.repository().set(InspitemData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(InspitemData.Modifier);
	}

	public InspitemData setModifier(String Modifier) {
		this.repository().set(InspitemData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(InspitemData.Modifiedtime);
	}

	public InspitemData setModifiedtime(Date Modifiedtime) {
		this.repository().set(InspitemData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(InspitemData.Lasttxnhistkey);
	}

	public InspitemData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(InspitemData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(InspitemData.Lasttxnid);
	}

	public InspitemData setLasttxnid(String Lasttxnid) {
		this.repository().set(InspitemData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(InspitemData.Lasttxnuser);
	}

	public InspitemData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(InspitemData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(InspitemData.Lasttxntime);
	}

	public InspitemData setLasttxntime(Date Lasttxntime) {
		this.repository().set(InspitemData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(InspitemData.Lasttxncomment);
	}

	public InspitemData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(InspitemData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(InspitemData.Validstate);
	}

	public InspitemData setValidstate(String Validstate) {
		this.repository().set(InspitemData.Validstate, Validstate);
		return this;
	}


}