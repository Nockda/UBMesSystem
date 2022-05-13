package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlCellgroupHistoryData extends SQLData {

	public static final String Cellgroupid = "CELLGROUPID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Cellgroupname = "CELLGROUPNAME";

	public static final String Teamid = "TEAMID";

	public static final String Warehouseid = "WAREHOUSEID";

	public static final String Areaid = "AREAID";

	public static final String Type = "TYPE";

	public static final String Mainuserid = "MAINUSERID";

	public static final String Subuserid = "SUBUSERID";

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

	public UlCellgroupHistoryData() {
		this(new UlCellgroupHistoryKey()); 
	}

	public UlCellgroupHistoryData(UlCellgroupHistoryKey key) {
		super(key, "UlCellgroupHistory");
	}


	public String getCellgroupname() {
		return this.repository().getString(UlCellgroupHistoryData.Cellgroupname);
	}

	public UlCellgroupHistoryData setCellgroupname(String Cellgroupname) {
		this.repository().set(UlCellgroupHistoryData.Cellgroupname, Cellgroupname);
		return this;
	}

	public String getTeamid() {
		return this.repository().getString(UlCellgroupHistoryData.Teamid);
	}

	public UlCellgroupHistoryData setTeamid(String Teamid) {
		this.repository().set(UlCellgroupHistoryData.Teamid, Teamid);
		return this;
	}

	public String getWarehouseid() {
		return this.repository().getString(UlCellgroupHistoryData.Warehouseid);
	}

	public UlCellgroupHistoryData setWarehouseid(String Warehouseid) {
		this.repository().set(UlCellgroupHistoryData.Warehouseid, Warehouseid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(UlCellgroupHistoryData.Areaid);
	}

	public UlCellgroupHistoryData setAreaid(String Areaid) {
		this.repository().set(UlCellgroupHistoryData.Areaid, Areaid);
		return this;
	}

	public String getType() {
		return this.repository().getString(UlCellgroupHistoryData.Type);
	}

	public UlCellgroupHistoryData setType(String Type) {
		this.repository().set(UlCellgroupHistoryData.Type, Type);
		return this;
	}

	public String getMainuserid() {
		return this.repository().getString(UlCellgroupHistoryData.Mainuserid);
	}

	public UlCellgroupHistoryData setMainuserid(String Mainuserid) {
		this.repository().set(UlCellgroupHistoryData.Mainuserid, Mainuserid);
		return this;
	}

	public String getSubuserid() {
		return this.repository().getString(UlCellgroupHistoryData.Subuserid);
	}

	public UlCellgroupHistoryData setSubuserid(String Subuserid) {
		this.repository().set(UlCellgroupHistoryData.Subuserid, Subuserid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlCellgroupHistoryData.Description);
	}

	public UlCellgroupHistoryData setDescription(String Description) {
		this.repository().set(UlCellgroupHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlCellgroupHistoryData.Creator);
	}

	public UlCellgroupHistoryData setCreator(String Creator) {
		this.repository().set(UlCellgroupHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlCellgroupHistoryData.Createdtime);
	}

	public UlCellgroupHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(UlCellgroupHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlCellgroupHistoryData.Modifier);
	}

	public UlCellgroupHistoryData setModifier(String Modifier) {
		this.repository().set(UlCellgroupHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlCellgroupHistoryData.Modifiedtime);
	}

	public UlCellgroupHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlCellgroupHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlCellgroupHistoryData.Txnid);
	}

	public UlCellgroupHistoryData setTxnid(String Txnid) {
		this.repository().set(UlCellgroupHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlCellgroupHistoryData.Txnuser);
	}

	public UlCellgroupHistoryData setTxnuser(String Txnuser) {
		this.repository().set(UlCellgroupHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlCellgroupHistoryData.Txntime);
	}

	public UlCellgroupHistoryData setTxntime(Date Txntime) {
		this.repository().set(UlCellgroupHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlCellgroupHistoryData.Txngrouphistkey);
	}

	public UlCellgroupHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlCellgroupHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlCellgroupHistoryData.Txnreasoncodeclass);
	}

	public UlCellgroupHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlCellgroupHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlCellgroupHistoryData.Txnreasoncode);
	}

	public UlCellgroupHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlCellgroupHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlCellgroupHistoryData.Txncomment);
	}

	public UlCellgroupHistoryData setTxncomment(String Txncomment) {
		this.repository().set(UlCellgroupHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlCellgroupHistoryData.Validstate);
	}

	public UlCellgroupHistoryData setValidstate(String Validstate) {
		this.repository().set(UlCellgroupHistoryData.Validstate, Validstate);
		return this;
	}


}