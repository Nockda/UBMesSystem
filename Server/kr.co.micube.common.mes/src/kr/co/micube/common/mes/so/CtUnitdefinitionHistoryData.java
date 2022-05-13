package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtUnitdefinitionHistoryData extends SQLData {

	public static final String Unitid = "UNITID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Unitname = "UNITNAME";

	public static final String Unit = "UNIT";

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

	public static final String Erp_unitid = "ERP_UNITID";

	public CtUnitdefinitionHistoryData() {
		this(new CtUnitdefinitionHistoryKey()); 
	}

	public CtUnitdefinitionHistoryData(CtUnitdefinitionHistoryKey key) {
		super(key, "CtUnitdefinitionHistory");
	}


	public String getUnitname() {
		return this.repository().getString(CtUnitdefinitionHistoryData.Unitname);
	}

	public CtUnitdefinitionHistoryData setUnitname(String Unitname) {
		this.repository().set(CtUnitdefinitionHistoryData.Unitname, Unitname);
		return this;
	}

	public String getUnit() {
		return this.repository().getString(CtUnitdefinitionHistoryData.Unit);
	}

	public CtUnitdefinitionHistoryData setUnit(String Unit) {
		this.repository().set(CtUnitdefinitionHistoryData.Unit, Unit);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtUnitdefinitionHistoryData.Description);
	}

	public CtUnitdefinitionHistoryData setDescription(String Description) {
		this.repository().set(CtUnitdefinitionHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtUnitdefinitionHistoryData.Creator);
	}

	public CtUnitdefinitionHistoryData setCreator(String Creator) {
		this.repository().set(CtUnitdefinitionHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtUnitdefinitionHistoryData.Createdtime);
	}

	public CtUnitdefinitionHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtUnitdefinitionHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtUnitdefinitionHistoryData.Modifier);
	}

	public CtUnitdefinitionHistoryData setModifier(String Modifier) {
		this.repository().set(CtUnitdefinitionHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtUnitdefinitionHistoryData.Modifiedtime);
	}

	public CtUnitdefinitionHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtUnitdefinitionHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtUnitdefinitionHistoryData.Txnid);
	}

	public CtUnitdefinitionHistoryData setTxnid(String Txnid) {
		this.repository().set(CtUnitdefinitionHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtUnitdefinitionHistoryData.Txnuser);
	}

	public CtUnitdefinitionHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtUnitdefinitionHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtUnitdefinitionHistoryData.Txntime);
	}

	public CtUnitdefinitionHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtUnitdefinitionHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtUnitdefinitionHistoryData.Txngrouphistkey);
	}

	public CtUnitdefinitionHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtUnitdefinitionHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtUnitdefinitionHistoryData.Txnreasoncodeclass);
	}

	public CtUnitdefinitionHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtUnitdefinitionHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtUnitdefinitionHistoryData.Txnreasoncode);
	}

	public CtUnitdefinitionHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtUnitdefinitionHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtUnitdefinitionHistoryData.Txncomment);
	}

	public CtUnitdefinitionHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtUnitdefinitionHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtUnitdefinitionHistoryData.Validstate);
	}

	public CtUnitdefinitionHistoryData setValidstate(String Validstate) {
		this.repository().set(CtUnitdefinitionHistoryData.Validstate, Validstate);
		return this;
	}

	public String getErp_unitid() {
		return this.repository().getString(CtUnitdefinitionHistoryData.Erp_unitid);
	}

	public CtUnitdefinitionHistoryData setErp_unitid(String Erp_unitid) {
		this.repository().set(CtUnitdefinitionHistoryData.Erp_unitid, Erp_unitid);
		return this;
	}


}