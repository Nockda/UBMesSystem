package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class InspitemHistotryData extends SQLData {

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Itemid = "ITEMID";

	public static final String Itemname = "ITEMNAME";

	public static final String Inputtype = "INPUTTYPE";

	public static final String Unit = "UNIT";

	public static final String Decimalplace = "DECIMALPLACE";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Modifier = "MODIFIER";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public InspitemHistotryData() {
		this(new InspitemHistotryKey()); 
	}

	public InspitemHistotryData(InspitemHistotryKey key) {
		super(key, "UlInspitemHistotry");
	}


	public String getItemname() {
		return this.repository().getString(InspitemHistotryData.Itemname);
	}

	public InspitemHistotryData setItemname(String Itemname) {
		this.repository().set(InspitemHistotryData.Itemname, Itemname);
		return this;
	}

	public String getInputtype() {
		return this.repository().getString(InspitemHistotryData.Inputtype);
	}

	public InspitemHistotryData setInputtype(String Inputtype) {
		this.repository().set(InspitemHistotryData.Inputtype, Inputtype);
		return this;
	}

	public String getUnit() {
		return this.repository().getString(InspitemHistotryData.Unit);
	}

	public InspitemHistotryData setUnit(String Unit) {
		this.repository().set(InspitemHistotryData.Unit, Unit);
		return this;
	}

	public Double getDecimalplace() {
		return this.repository().getDouble(InspitemHistotryData.Decimalplace);
	}

	public InspitemHistotryData setDecimalplace(Double Decimalplace) {
		this.repository().set(InspitemHistotryData.Decimalplace, Decimalplace);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(InspitemHistotryData.Creator);
	}

	public InspitemHistotryData setCreator(String Creator) {
		this.repository().set(InspitemHistotryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(InspitemHistotryData.Createdtime);
	}

	public InspitemHistotryData setCreatedtime(Date Createdtime) {
		this.repository().set(InspitemHistotryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(InspitemHistotryData.Modifier);
	}

	public InspitemHistotryData setModifier(String Modifier) {
		this.repository().set(InspitemHistotryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(InspitemHistotryData.Modifiedtime);
	}

	public InspitemHistotryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(InspitemHistotryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(InspitemHistotryData.Txnuser);
	}

	public InspitemHistotryData setTxnuser(String Txnuser) {
		this.repository().set(InspitemHistotryData.Txnuser, Txnuser);
		return this;
	}

	public String getTxntime() {
		return this.repository().getString(InspitemHistotryData.Txntime);
	}

	public InspitemHistotryData setTxntime(String Txntime) {
		this.repository().set(InspitemHistotryData.Txntime, Txntime);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(InspitemHistotryData.Txnreasoncodeclass);
	}

	public InspitemHistotryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(InspitemHistotryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public Date getTxnreasoncode() {
		return this.repository().getDate(InspitemHistotryData.Txnreasoncode);
	}

	public InspitemHistotryData setTxnreasoncode(Date Txnreasoncode) {
		this.repository().set(InspitemHistotryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(InspitemHistotryData.Txncomment);
	}

	public InspitemHistotryData setTxncomment(String Txncomment) {
		this.repository().set(InspitemHistotryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(InspitemHistotryData.Validstate);
	}

	public InspitemHistotryData setValidstate(String Validstate) {
		this.repository().set(InspitemHistotryData.Validstate, Validstate);
		return this;
	}


}