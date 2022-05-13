package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlMaterialinitData extends SQLData {

	public static final String Consumablelotid = "CONSUMABLELOTID";

	public static final String Consumabledefid = "CONSUMABLEDEFID";

	public static final String Warehouseid = "WAREHOUSEID";

	public static final String Locationid = "LOCATIONID";

	public static final String Createdqty = "CREATEDQTY";

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

	public UlMaterialinitData() {
		this(new UlMaterialinitKey()); 
	}

	public UlMaterialinitData(UlMaterialinitKey key) {
		super(key, "UlMaterialinit");
		this.txnInfo().setHistoryTable(true);
	}


	public String getConsumabledefid() {
		return this.repository().getString(UlMaterialinitData.Consumabledefid);
	}

	public UlMaterialinitData setConsumabledefid(String Consumabledefid) {
		this.repository().set(UlMaterialinitData.Consumabledefid, Consumabledefid);
		return this;
	}

	public String getWarehouseid() {
		return this.repository().getString(UlMaterialinitData.Warehouseid);
	}

	public UlMaterialinitData setWarehouseid(String Warehouseid) {
		this.repository().set(UlMaterialinitData.Warehouseid, Warehouseid);
		return this;
	}

	public String getLocationid() {
		return this.repository().getString(UlMaterialinitData.Locationid);
	}

	public UlMaterialinitData setLocationid(String Locationid) {
		this.repository().set(UlMaterialinitData.Locationid, Locationid);
		return this;
	}

	public Double getCreatedqty() {
		return this.repository().getDouble(UlMaterialinitData.Createdqty);
	}

	public UlMaterialinitData setCreatedqty(Double Createdqty) {
		this.repository().set(UlMaterialinitData.Createdqty, Createdqty);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlMaterialinitData.Description);
	}

	public UlMaterialinitData setDescription(String Description) {
		this.repository().set(UlMaterialinitData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlMaterialinitData.Creator);
	}

	public UlMaterialinitData setCreator(String Creator) {
		this.repository().set(UlMaterialinitData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlMaterialinitData.Createdtime);
	}

	public UlMaterialinitData setCreatedtime(Date Createdtime) {
		this.repository().set(UlMaterialinitData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlMaterialinitData.Modifier);
	}

	public UlMaterialinitData setModifier(String Modifier) {
		this.repository().set(UlMaterialinitData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlMaterialinitData.Modifiedtime);
	}

	public UlMaterialinitData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlMaterialinitData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlMaterialinitData.Txnid);
	}

	public UlMaterialinitData setTxnid(String Txnid) {
		this.repository().set(UlMaterialinitData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlMaterialinitData.Txnuser);
	}

	public UlMaterialinitData setTxnuser(String Txnuser) {
		this.repository().set(UlMaterialinitData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlMaterialinitData.Txntime);
	}

	public UlMaterialinitData setTxntime(Date Txntime) {
		this.repository().set(UlMaterialinitData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlMaterialinitData.Txngrouphistkey);
	}

	public UlMaterialinitData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlMaterialinitData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlMaterialinitData.Txnreasoncodeclass);
	}

	public UlMaterialinitData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlMaterialinitData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlMaterialinitData.Txnreasoncode);
	}

	public UlMaterialinitData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlMaterialinitData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlMaterialinitData.Txncomment);
	}

	public UlMaterialinitData setTxncomment(String Txncomment) {
		this.repository().set(UlMaterialinitData.Txncomment, Txncomment);
		return this;
	}


}