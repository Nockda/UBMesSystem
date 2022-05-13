package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlMaterialetcinoutData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Consumabledefid = "CONSUMABLEDEFID";

	public static final String Consumablelotid = "CONSUMABLELOTID";

	public static final String Processdate = "PROCESSDATE";

	public static final String Inoutgubun = "INOUTGUBUN";

	public static final String Inouttype = "INOUTTYPE";

	public static final String Warehouseid = "WAREHOUSEID";

	public static final String Locationid = "LOCATIONID";

	public static final String Processqty = "PROCESSQTY";

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

	public UlMaterialetcinoutData() {
		this(new UlMaterialetcinoutKey()); 
	}

	public UlMaterialetcinoutData(UlMaterialetcinoutKey key) {
		super(key, "UlMaterialetcinout");
		this.txnInfo().setHistoryTable(true);
	}


	public String getConsumabledefid() {
		return this.repository().getString(UlMaterialetcinoutData.Consumabledefid);
	}

	public UlMaterialetcinoutData setConsumabledefid(String Consumabledefid) {
		this.repository().set(UlMaterialetcinoutData.Consumabledefid, Consumabledefid);
		return this;
	}

	public String getConsumablelotid() {
		return this.repository().getString(UlMaterialetcinoutData.Consumablelotid);
	}

	public UlMaterialetcinoutData setConsumablelotid(String Consumablelotid) {
		this.repository().set(UlMaterialetcinoutData.Consumablelotid, Consumablelotid);
		return this;
	}

	public Date getProcessdate() {
		return this.repository().getDate(UlMaterialetcinoutData.Processdate);
	}

	public UlMaterialetcinoutData setProcessdate(Date Processdate) {
		this.repository().set(UlMaterialetcinoutData.Processdate, Processdate);
		return this;
	}

	public String getInoutgubun() {
		return this.repository().getString(UlMaterialetcinoutData.Inoutgubun);
	}

	public UlMaterialetcinoutData setInoutgubun(String Inoutgubun) {
		this.repository().set(UlMaterialetcinoutData.Inoutgubun, Inoutgubun);
		return this;
	}

	public String getInouttype() {
		return this.repository().getString(UlMaterialetcinoutData.Inouttype);
	}

	public UlMaterialetcinoutData setInouttype(String Inouttype) {
		this.repository().set(UlMaterialetcinoutData.Inouttype, Inouttype);
		return this;
	}

	public String getWarehouseid() {
		return this.repository().getString(UlMaterialetcinoutData.Warehouseid);
	}

	public UlMaterialetcinoutData setWarehouseid(String Warehouseid) {
		this.repository().set(UlMaterialetcinoutData.Warehouseid, Warehouseid);
		return this;
	}

	public String getLocationid() {
		return this.repository().getString(UlMaterialetcinoutData.Locationid);
	}

	public UlMaterialetcinoutData setLocationid(String Locationid) {
		this.repository().set(UlMaterialetcinoutData.Locationid, Locationid);
		return this;
	}

	public Double getProcessqty() {
		return this.repository().getDouble(UlMaterialetcinoutData.Processqty);
	}

	public UlMaterialetcinoutData setProcessqty(Double Processqty) {
		this.repository().set(UlMaterialetcinoutData.Processqty, Processqty);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlMaterialetcinoutData.Description);
	}

	public UlMaterialetcinoutData setDescription(String Description) {
		this.repository().set(UlMaterialetcinoutData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlMaterialetcinoutData.Creator);
	}

	public UlMaterialetcinoutData setCreator(String Creator) {
		this.repository().set(UlMaterialetcinoutData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlMaterialetcinoutData.Createdtime);
	}

	public UlMaterialetcinoutData setCreatedtime(Date Createdtime) {
		this.repository().set(UlMaterialetcinoutData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlMaterialetcinoutData.Modifier);
	}

	public UlMaterialetcinoutData setModifier(String Modifier) {
		this.repository().set(UlMaterialetcinoutData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlMaterialetcinoutData.Modifiedtime);
	}

	public UlMaterialetcinoutData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlMaterialetcinoutData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlMaterialetcinoutData.Txnid);
	}

	public UlMaterialetcinoutData setTxnid(String Txnid) {
		this.repository().set(UlMaterialetcinoutData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlMaterialetcinoutData.Txnuser);
	}

	public UlMaterialetcinoutData setTxnuser(String Txnuser) {
		this.repository().set(UlMaterialetcinoutData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlMaterialetcinoutData.Txntime);
	}

	public UlMaterialetcinoutData setTxntime(Date Txntime) {
		this.repository().set(UlMaterialetcinoutData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlMaterialetcinoutData.Txngrouphistkey);
	}

	public UlMaterialetcinoutData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlMaterialetcinoutData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlMaterialetcinoutData.Txnreasoncodeclass);
	}

	public UlMaterialetcinoutData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlMaterialetcinoutData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlMaterialetcinoutData.Txnreasoncode);
	}

	public UlMaterialetcinoutData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlMaterialetcinoutData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlMaterialetcinoutData.Txncomment);
	}

	public UlMaterialetcinoutData setTxncomment(String Txncomment) {
		this.repository().set(UlMaterialetcinoutData.Txncomment, Txncomment);
		return this;
	}


}