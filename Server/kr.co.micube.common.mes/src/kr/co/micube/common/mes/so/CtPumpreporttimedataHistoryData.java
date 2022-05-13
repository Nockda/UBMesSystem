package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtPumpreporttimedataHistoryData extends SQLData {

	public static final String Lotid = "LOTID";

	public static final String Inspectiondegree = "INSPECTIONDEGREE";

	public static final String Measuretime = "MEASURETIME";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Supplyvalue = "SUPPLYVALUE";

	public static final String Returnvalue = "RETURNVALUE";

	public static final String Twotempvalue = "TWOTEMPVALUE";

	public static final String Tcvalue = "TCVALUE";

	public static final String Vacvalue = "VACVALUE";

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

	public CtPumpreporttimedataHistoryData() {
		this(new CtPumpreporttimedataHistoryKey()); 
	}

	public CtPumpreporttimedataHistoryData(CtPumpreporttimedataHistoryKey key) {
		super(key, "CtPumpreporttimedataHistory");
	}


	public String getSupplyvalue() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Supplyvalue);
	}

	public CtPumpreporttimedataHistoryData setSupplyvalue(String Supplyvalue) {
		this.repository().set(CtPumpreporttimedataHistoryData.Supplyvalue, Supplyvalue);
		return this;
	}

	public String getReturnvalue() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Returnvalue);
	}

	public CtPumpreporttimedataHistoryData setReturnvalue(String Returnvalue) {
		this.repository().set(CtPumpreporttimedataHistoryData.Returnvalue, Returnvalue);
		return this;
	}

	public String getTwotempvalue() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Twotempvalue);
	}

	public CtPumpreporttimedataHistoryData setTwotempvalue(String Twotempvalue) {
		this.repository().set(CtPumpreporttimedataHistoryData.Twotempvalue, Twotempvalue);
		return this;
	}

	public String getTcvalue() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Tcvalue);
	}

	public CtPumpreporttimedataHistoryData setTcvalue(String Tcvalue) {
		this.repository().set(CtPumpreporttimedataHistoryData.Tcvalue, Tcvalue);
		return this;
	}

	public String getVacvalue() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Vacvalue);
	}

	public CtPumpreporttimedataHistoryData setVacvalue(String Vacvalue) {
		this.repository().set(CtPumpreporttimedataHistoryData.Vacvalue, Vacvalue);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Description);
	}

	public CtPumpreporttimedataHistoryData setDescription(String Description) {
		this.repository().set(CtPumpreporttimedataHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Creator);
	}

	public CtPumpreporttimedataHistoryData setCreator(String Creator) {
		this.repository().set(CtPumpreporttimedataHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtPumpreporttimedataHistoryData.Createdtime);
	}

	public CtPumpreporttimedataHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtPumpreporttimedataHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Modifier);
	}

	public CtPumpreporttimedataHistoryData setModifier(String Modifier) {
		this.repository().set(CtPumpreporttimedataHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtPumpreporttimedataHistoryData.Modifiedtime);
	}

	public CtPumpreporttimedataHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtPumpreporttimedataHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Txnid);
	}

	public CtPumpreporttimedataHistoryData setTxnid(String Txnid) {
		this.repository().set(CtPumpreporttimedataHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Txnuser);
	}

	public CtPumpreporttimedataHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtPumpreporttimedataHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtPumpreporttimedataHistoryData.Txntime);
	}

	public CtPumpreporttimedataHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtPumpreporttimedataHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Txngrouphistkey);
	}

	public CtPumpreporttimedataHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtPumpreporttimedataHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Txnreasoncodeclass);
	}

	public CtPumpreporttimedataHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtPumpreporttimedataHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Txnreasoncode);
	}

	public CtPumpreporttimedataHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtPumpreporttimedataHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Txncomment);
	}

	public CtPumpreporttimedataHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtPumpreporttimedataHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtPumpreporttimedataHistoryData.Validstate);
	}

	public CtPumpreporttimedataHistoryData setValidstate(String Validstate) {
		this.repository().set(CtPumpreporttimedataHistoryData.Validstate, Validstate);
		return this;
	}


}