package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlProcessworkresultData extends SQLData {

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Lotid = "LOTID";

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Workstarttime = "WORKSTARTTIME";

	public static final String Workendtime = "WORKENDTIME";

	public static final String Workstartuser = "WORKSTARTUSER";

	public static final String Workenduser = "WORKENDUSER";

	public static final String Workstartqty = "WORKSTARTQTY";

	public static final String Workendqty = "WORKENDQTY";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Chargeuserid = "CHARGEUSERID";

	public static final String Worktime = "WORKTIME";

	public static final String Comments = "COMMENTS";

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

	public static final String Standardtime = "STANDARDTIME";

	public UlProcessworkresultData() {
		this(new UlProcessworkresultKey()); 
	}

	public UlProcessworkresultData(UlProcessworkresultKey key) {
		super(key, "UlProcessworkresult");
		this.txnInfo().setHistoryTable(true);
	}


	public String getLotid() {
		return this.repository().getString(UlProcessworkresultData.Lotid);
	}

	public UlProcessworkresultData setLotid(String Lotid) {
		this.repository().set(UlProcessworkresultData.Lotid, Lotid);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(UlProcessworkresultData.Processsegmentid);
	}

	public UlProcessworkresultData setProcesssegmentid(String Processsegmentid) {
		this.repository().set(UlProcessworkresultData.Processsegmentid, Processsegmentid);
		return this;
	}

	public Date getWorkstarttime() {
		return this.repository().getDate(UlProcessworkresultData.Workstarttime);
	}

	public UlProcessworkresultData setWorkstarttime(Date Workstarttime) {
		this.repository().set(UlProcessworkresultData.Workstarttime, Workstarttime);
		return this;
	}

	public Date getWorkendtime() {
		return this.repository().getDate(UlProcessworkresultData.Workendtime);
	}

	public UlProcessworkresultData setWorkendtime(Date Workendtime) {
		this.repository().set(UlProcessworkresultData.Workendtime, Workendtime);
		return this;
	}

	public String getWorkstartuser() {
		return this.repository().getString(UlProcessworkresultData.Workstartuser);
	}

	public UlProcessworkresultData setWorkstartuser(String Workstartuser) {
		this.repository().set(UlProcessworkresultData.Workstartuser, Workstartuser);
		return this;
	}

	public String getWorkenduser() {
		return this.repository().getString(UlProcessworkresultData.Workenduser);
	}

	public UlProcessworkresultData setWorkenduser(String Workenduser) {
		this.repository().set(UlProcessworkresultData.Workenduser, Workenduser);
		return this;
	}

	public Double getWorkstartqty() {
		return this.repository().getDouble(UlProcessworkresultData.Workstartqty);
	}

	public UlProcessworkresultData setWorkstartqty(Double Workstartqty) {
		this.repository().set(UlProcessworkresultData.Workstartqty, Workstartqty);
		return this;
	}

	public Double getWorkendqty() {
		return this.repository().getDouble(UlProcessworkresultData.Workendqty);
	}

	public UlProcessworkresultData setWorkendqty(Double Workendqty) {
		this.repository().set(UlProcessworkresultData.Workendqty, Workendqty);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(UlProcessworkresultData.Equipmentid);
	}

	public UlProcessworkresultData setEquipmentid(String Equipmentid) {
		this.repository().set(UlProcessworkresultData.Equipmentid, Equipmentid);
		return this;
	}

	public String getChargeuserid() {
		return this.repository().getString(UlProcessworkresultData.Chargeuserid);
	}

	public UlProcessworkresultData setChargeuserid(String Chargeuserid) {
		this.repository().set(UlProcessworkresultData.Chargeuserid, Chargeuserid);
		return this;
	}

	public Double getWorktime() {
		return this.repository().getDouble(UlProcessworkresultData.Worktime);
	}

	public UlProcessworkresultData setWorktime(Double Worktime) {
		this.repository().set(UlProcessworkresultData.Worktime, Worktime);
		return this;
	}

	public String getComments() {
		return this.repository().getString(UlProcessworkresultData.Comments);
	}

	public UlProcessworkresultData setComments(String Comments) {
		this.repository().set(UlProcessworkresultData.Comments, Comments);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlProcessworkresultData.Creator);
	}

	public UlProcessworkresultData setCreator(String Creator) {
		this.repository().set(UlProcessworkresultData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlProcessworkresultData.Createdtime);
	}

	public UlProcessworkresultData setCreatedtime(Date Createdtime) {
		this.repository().set(UlProcessworkresultData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlProcessworkresultData.Modifier);
	}

	public UlProcessworkresultData setModifier(String Modifier) {
		this.repository().set(UlProcessworkresultData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlProcessworkresultData.Modifiedtime);
	}

	public UlProcessworkresultData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlProcessworkresultData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlProcessworkresultData.Txnid);
	}

	public UlProcessworkresultData setTxnid(String Txnid) {
		this.repository().set(UlProcessworkresultData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlProcessworkresultData.Txnuser);
	}

	public UlProcessworkresultData setTxnuser(String Txnuser) {
		this.repository().set(UlProcessworkresultData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlProcessworkresultData.Txntime);
	}

	public UlProcessworkresultData setTxntime(Date Txntime) {
		this.repository().set(UlProcessworkresultData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlProcessworkresultData.Txngrouphistkey);
	}

	public UlProcessworkresultData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlProcessworkresultData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlProcessworkresultData.Txnreasoncodeclass);
	}

	public UlProcessworkresultData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlProcessworkresultData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlProcessworkresultData.Txnreasoncode);
	}

	public UlProcessworkresultData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlProcessworkresultData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlProcessworkresultData.Txncomment);
	}

	public UlProcessworkresultData setTxncomment(String Txncomment) {
		this.repository().set(UlProcessworkresultData.Txncomment, Txncomment);
		return this;
	}

	public Double getStandardtime() {
		return this.repository().getDouble(UlProcessworkresultData.Standardtime);
	}

	public UlProcessworkresultData setStandardtime(Double Standardtime) {
		this.repository().set(UlProcessworkresultData.Standardtime, Standardtime);
		return this;
	}


}