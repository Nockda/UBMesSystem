package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlSubprocessworkresultData extends SQLData {

	public static final String Specdefidversion = "SPECDEFIDVERSION";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Lotid = "LOTID";

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Subprocesssegmentid = "SUBPROCESSSEGMENTID";

	public static final String Workstarttime = "WORKSTARTTIME";

	public static final String Workendtime = "WORKENDTIME";

	public static final String Workstartuser = "WORKSTARTUSER";

	public static final String Workenduser = "WORKENDUSER";

	public static final String Workstartqty = "WORKSTARTQTY";

	public static final String Workendqty = "WORKENDQTY";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Specdefid = "SPECDEFID";

	public static final String Chargeuserid = "CHARGEUSERID";

	public static final String Worktime = "WORKTIME";

	public static final String Comments = "COMMENTS";

	public static final String Isfinished = "ISFINISHED";

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

	public UlSubprocessworkresultData() {
		this(new UlSubprocessworkresultKey()); 
	}

	public UlSubprocessworkresultData(UlSubprocessworkresultKey key) {
		super(key, "UlSubprocessworkresult");
		this.txnInfo().setHistoryTable(true);
	}


	public String getSpecdefidversion() {
		return this.repository().getString(UlSubprocessworkresultData.Specdefidversion);
	}

	public UlSubprocessworkresultData setSpecdefidversion(String Specdefidversion) {
		this.repository().set(UlSubprocessworkresultData.Specdefidversion, Specdefidversion);
		return this;
	}

	public String getLotid() {
		return this.repository().getString(UlSubprocessworkresultData.Lotid);
	}

	public UlSubprocessworkresultData setLotid(String Lotid) {
		this.repository().set(UlSubprocessworkresultData.Lotid, Lotid);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(UlSubprocessworkresultData.Processsegmentid);
	}

	public UlSubprocessworkresultData setProcesssegmentid(String Processsegmentid) {
		this.repository().set(UlSubprocessworkresultData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getSubprocesssegmentid() {
		return this.repository().getString(UlSubprocessworkresultData.Subprocesssegmentid);
	}

	public UlSubprocessworkresultData setSubprocesssegmentid(String Subprocesssegmentid) {
		this.repository().set(UlSubprocessworkresultData.Subprocesssegmentid, Subprocesssegmentid);
		return this;
	}

	public Date getWorkstarttime() {
		return this.repository().getDate(UlSubprocessworkresultData.Workstarttime);
	}

	public UlSubprocessworkresultData setWorkstarttime(Date Workstarttime) {
		this.repository().set(UlSubprocessworkresultData.Workstarttime, Workstarttime);
		return this;
	}

	public Date getWorkendtime() {
		return this.repository().getDate(UlSubprocessworkresultData.Workendtime);
	}

	public UlSubprocessworkresultData setWorkendtime(Date Workendtime) {
		this.repository().set(UlSubprocessworkresultData.Workendtime, Workendtime);
		return this;
	}

	public String getWorkstartuser() {
		return this.repository().getString(UlSubprocessworkresultData.Workstartuser);
	}

	public UlSubprocessworkresultData setWorkstartuser(String Workstartuser) {
		this.repository().set(UlSubprocessworkresultData.Workstartuser, Workstartuser);
		return this;
	}

	public String getWorkenduser() {
		return this.repository().getString(UlSubprocessworkresultData.Workenduser);
	}

	public UlSubprocessworkresultData setWorkenduser(String Workenduser) {
		this.repository().set(UlSubprocessworkresultData.Workenduser, Workenduser);
		return this;
	}

	public Double getWorkstartqty() {
		return this.repository().getDouble(UlSubprocessworkresultData.Workstartqty);
	}

	public UlSubprocessworkresultData setWorkstartqty(Double Workstartqty) {
		this.repository().set(UlSubprocessworkresultData.Workstartqty, Workstartqty);
		return this;
	}

	public Double getWorkendqty() {
		return this.repository().getDouble(UlSubprocessworkresultData.Workendqty);
	}

	public UlSubprocessworkresultData setWorkendqty(Double Workendqty) {
		this.repository().set(UlSubprocessworkresultData.Workendqty, Workendqty);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(UlSubprocessworkresultData.Equipmentid);
	}

	public UlSubprocessworkresultData setEquipmentid(String Equipmentid) {
		this.repository().set(UlSubprocessworkresultData.Equipmentid, Equipmentid);
		return this;
	}

	public String getSpecdefid() {
		return this.repository().getString(UlSubprocessworkresultData.Specdefid);
	}

	public UlSubprocessworkresultData setSpecdefid(String Specdefid) {
		this.repository().set(UlSubprocessworkresultData.Specdefid, Specdefid);
		return this;
	}

	public String getChargeuserid() {
		return this.repository().getString(UlSubprocessworkresultData.Chargeuserid);
	}

	public UlSubprocessworkresultData setChargeuserid(String Chargeuserid) {
		this.repository().set(UlSubprocessworkresultData.Chargeuserid, Chargeuserid);
		return this;
	}

	public Double getWorktime() {
		return this.repository().getDouble(UlSubprocessworkresultData.Worktime);
	}

	public UlSubprocessworkresultData setWorktime(Double Worktime) {
		this.repository().set(UlSubprocessworkresultData.Worktime, Worktime);
		return this;
	}

	public String getComments() {
		return this.repository().getString(UlSubprocessworkresultData.Comments);
	}

	public UlSubprocessworkresultData setComments(String Comments) {
		this.repository().set(UlSubprocessworkresultData.Comments, Comments);
		return this;
	}

	public String getIsfinished() {
		return this.repository().getString(UlSubprocessworkresultData.Isfinished);
	}

	public UlSubprocessworkresultData setIsfinished(String Isfinished) {
		this.repository().set(UlSubprocessworkresultData.Isfinished, Isfinished);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlSubprocessworkresultData.Creator);
	}

	public UlSubprocessworkresultData setCreator(String Creator) {
		this.repository().set(UlSubprocessworkresultData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlSubprocessworkresultData.Createdtime);
	}

	public UlSubprocessworkresultData setCreatedtime(Date Createdtime) {
		this.repository().set(UlSubprocessworkresultData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlSubprocessworkresultData.Modifier);
	}

	public UlSubprocessworkresultData setModifier(String Modifier) {
		this.repository().set(UlSubprocessworkresultData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlSubprocessworkresultData.Modifiedtime);
	}

	public UlSubprocessworkresultData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlSubprocessworkresultData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlSubprocessworkresultData.Txnid);
	}

	public UlSubprocessworkresultData setTxnid(String Txnid) {
		this.repository().set(UlSubprocessworkresultData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlSubprocessworkresultData.Txnuser);
	}

	public UlSubprocessworkresultData setTxnuser(String Txnuser) {
		this.repository().set(UlSubprocessworkresultData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlSubprocessworkresultData.Txntime);
	}

	public UlSubprocessworkresultData setTxntime(Date Txntime) {
		this.repository().set(UlSubprocessworkresultData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlSubprocessworkresultData.Txngrouphistkey);
	}

	public UlSubprocessworkresultData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlSubprocessworkresultData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlSubprocessworkresultData.Txnreasoncodeclass);
	}

	public UlSubprocessworkresultData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlSubprocessworkresultData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlSubprocessworkresultData.Txnreasoncode);
	}

	public UlSubprocessworkresultData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlSubprocessworkresultData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlSubprocessworkresultData.Txncomment);
	}

	public UlSubprocessworkresultData setTxncomment(String Txncomment) {
		this.repository().set(UlSubprocessworkresultData.Txncomment, Txncomment);
		return this;
	}


}