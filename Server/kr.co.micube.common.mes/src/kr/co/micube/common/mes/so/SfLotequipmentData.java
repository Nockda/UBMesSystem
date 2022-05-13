package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfLotequipmentData extends SQLData {

	public static final String Lotid = "LOTID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Processsegmentversion = "PROCESSSEGMENTVERSION";

	public static final String Subprocesssegmentid = "SUBPROCESSSEGMENTID";

	public static final String Trackintime = "TRACKINTIME";

	public static final String Trackouttime = "TRACKOUTTIME";

	public static final String Qty = "QTY";

	public static final String Description = "DESCRIPTION";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Modifier = "MODIFIER";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public SfLotequipmentData() {
		this(new SfLotequipmentKey()); 
	}

	public SfLotequipmentData(SfLotequipmentKey key) {
		super(key, "SfLotequipment");
		this.txnInfo().setHistoryTable(true);
	}


	public String getEquipmentid() {
		return this.repository().getString(SfLotequipmentData.Equipmentid);
	}

	public SfLotequipmentData setEquipmentid(String Equipmentid) {
		this.repository().set(SfLotequipmentData.Equipmentid, Equipmentid);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(SfLotequipmentData.Processsegmentid);
	}

	public SfLotequipmentData setProcesssegmentid(String Processsegmentid) {
		this.repository().set(SfLotequipmentData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getProcesssegmentversion() {
		return this.repository().getString(SfLotequipmentData.Processsegmentversion);
	}

	public SfLotequipmentData setProcesssegmentversion(String Processsegmentversion) {
		this.repository().set(SfLotequipmentData.Processsegmentversion, Processsegmentversion);
		return this;
	}

	public String getSubprocesssegmentid() {
		return this.repository().getString(SfLotequipmentData.Subprocesssegmentid);
	}

	public SfLotequipmentData setSubprocesssegmentid(String Subprocesssegmentid) {
		this.repository().set(SfLotequipmentData.Subprocesssegmentid, Subprocesssegmentid);
		return this;
	}

	public Date getTrackintime() {
		return this.repository().getDate(SfLotequipmentData.Trackintime);
	}

	public SfLotequipmentData setTrackintime(Date Trackintime) {
		this.repository().set(SfLotequipmentData.Trackintime, Trackintime);
		return this;
	}

	public Date getTrackouttime() {
		return this.repository().getDate(SfLotequipmentData.Trackouttime);
	}

	public SfLotequipmentData setTrackouttime(Date Trackouttime) {
		this.repository().set(SfLotequipmentData.Trackouttime, Trackouttime);
		return this;
	}

	public Double getQty() {
		return this.repository().getDouble(SfLotequipmentData.Qty);
	}

	public SfLotequipmentData setQty(Double Qty) {
		this.repository().set(SfLotequipmentData.Qty, Qty);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfLotequipmentData.Description);
	}

	public SfLotequipmentData setDescription(String Description) {
		this.repository().set(SfLotequipmentData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfLotequipmentData.Creator);
	}

	public SfLotequipmentData setCreator(String Creator) {
		this.repository().set(SfLotequipmentData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfLotequipmentData.Createdtime);
	}

	public SfLotequipmentData setCreatedtime(Date Createdtime) {
		this.repository().set(SfLotequipmentData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfLotequipmentData.Modifier);
	}

	public SfLotequipmentData setModifier(String Modifier) {
		this.repository().set(SfLotequipmentData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfLotequipmentData.Modifiedtime);
	}

	public SfLotequipmentData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfLotequipmentData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfLotequipmentData.Txngrouphistkey);
	}

	public SfLotequipmentData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfLotequipmentData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(SfLotequipmentData.Txnid);
	}

	public SfLotequipmentData setTxnid(String Txnid) {
		this.repository().set(SfLotequipmentData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfLotequipmentData.Txnuser);
	}

	public SfLotequipmentData setTxnuser(String Txnuser) {
		this.repository().set(SfLotequipmentData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfLotequipmentData.Txntime);
	}

	public SfLotequipmentData setTxntime(Date Txntime) {
		this.repository().set(SfLotequipmentData.Txntime, Txntime);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfLotequipmentData.Txnreasoncodeclass);
	}

	public SfLotequipmentData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfLotequipmentData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfLotequipmentData.Txnreasoncode);
	}

	public SfLotequipmentData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfLotequipmentData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfLotequipmentData.Txncomment);
	}

	public SfLotequipmentData setTxncomment(String Txncomment) {
		this.repository().set(SfLotequipmentData.Txncomment, Txncomment);
		return this;
	}


}