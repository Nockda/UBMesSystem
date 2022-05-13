package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlMaterialmoveData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Consumabledefid = "CONSUMABLEDEFID";

	public static final String Consumablelotid = "CONSUMABLELOTID";

	public static final String Moveqty = "MOVEQTY";

	public static final String Fromwarehouseid = "FROMWAREHOUSEID";

	public static final String Fromcellid = "FROMCELLID";

	public static final String Towarehouseid = "TOWAREHOUSEID";

	public static final String Tocellid = "TOCELLID";

	public static final String Movetype = "MOVETYPE";

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

	public UlMaterialmoveData() {
		this(new UlMaterialmoveKey()); 
	}

	public UlMaterialmoveData(UlMaterialmoveKey key) {
		super(key, "UlMaterialmove");
		this.txnInfo().setHistoryTable(true);
	}


	public String getConsumabledefid() {
		return this.repository().getString(UlMaterialmoveData.Consumabledefid);
	}

	public UlMaterialmoveData setConsumabledefid(String Consumabledefid) {
		this.repository().set(UlMaterialmoveData.Consumabledefid, Consumabledefid);
		return this;
	}

	public String getConsumablelotid() {
		return this.repository().getString(UlMaterialmoveData.Consumablelotid);
	}

	public UlMaterialmoveData setConsumablelotid(String Consumablelotid) {
		this.repository().set(UlMaterialmoveData.Consumablelotid, Consumablelotid);
		return this;
	}

	public Double getMoveqty() {
		return this.repository().getDouble(UlMaterialmoveData.Moveqty);
	}

	public UlMaterialmoveData setMoveqty(Double Moveqty) {
		this.repository().set(UlMaterialmoveData.Moveqty, Moveqty);
		return this;
	}

	public String getFromwarehouseid() {
		return this.repository().getString(UlMaterialmoveData.Fromwarehouseid);
	}

	public UlMaterialmoveData setFromwarehouseid(String Fromwarehouseid) {
		this.repository().set(UlMaterialmoveData.Fromwarehouseid, Fromwarehouseid);
		return this;
	}

	public String getFromcellid() {
		return this.repository().getString(UlMaterialmoveData.Fromcellid);
	}

	public UlMaterialmoveData setFromcellid(String Fromcellid) {
		this.repository().set(UlMaterialmoveData.Fromcellid, Fromcellid);
		return this;
	}

	public String getTowarehouseid() {
		return this.repository().getString(UlMaterialmoveData.Towarehouseid);
	}

	public UlMaterialmoveData setTowarehouseid(String Towarehouseid) {
		this.repository().set(UlMaterialmoveData.Towarehouseid, Towarehouseid);
		return this;
	}

	public String getTocellid() {
		return this.repository().getString(UlMaterialmoveData.Tocellid);
	}

	public UlMaterialmoveData setTocellid(String Tocellid) {
		this.repository().set(UlMaterialmoveData.Tocellid, Tocellid);
		return this;
	}

	public String getMovetype() {
		return this.repository().getString(UlMaterialmoveData.Movetype);
	}

	public UlMaterialmoveData setMovetype(String Movetype) {
		this.repository().set(UlMaterialmoveData.Movetype, Movetype);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlMaterialmoveData.Description);
	}

	public UlMaterialmoveData setDescription(String Description) {
		this.repository().set(UlMaterialmoveData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlMaterialmoveData.Creator);
	}

	public UlMaterialmoveData setCreator(String Creator) {
		this.repository().set(UlMaterialmoveData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlMaterialmoveData.Createdtime);
	}

	public UlMaterialmoveData setCreatedtime(Date Createdtime) {
		this.repository().set(UlMaterialmoveData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlMaterialmoveData.Modifier);
	}

	public UlMaterialmoveData setModifier(String Modifier) {
		this.repository().set(UlMaterialmoveData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlMaterialmoveData.Modifiedtime);
	}

	public UlMaterialmoveData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlMaterialmoveData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlMaterialmoveData.Txnid);
	}

	public UlMaterialmoveData setTxnid(String Txnid) {
		this.repository().set(UlMaterialmoveData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlMaterialmoveData.Txnuser);
	}

	public UlMaterialmoveData setTxnuser(String Txnuser) {
		this.repository().set(UlMaterialmoveData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlMaterialmoveData.Txntime);
	}

	public UlMaterialmoveData setTxntime(Date Txntime) {
		this.repository().set(UlMaterialmoveData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlMaterialmoveData.Txngrouphistkey);
	}

	public UlMaterialmoveData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlMaterialmoveData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlMaterialmoveData.Txnreasoncodeclass);
	}

	public UlMaterialmoveData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlMaterialmoveData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlMaterialmoveData.Txnreasoncode);
	}

	public UlMaterialmoveData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlMaterialmoveData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlMaterialmoveData.Txncomment);
	}

	public UlMaterialmoveData setTxncomment(String Txncomment) {
		this.repository().set(UlMaterialmoveData.Txncomment, Txncomment);
		return this;
	}


}