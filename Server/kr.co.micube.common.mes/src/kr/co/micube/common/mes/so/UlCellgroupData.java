package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlCellgroupData extends SQLData {

	public static final String Cellgroupid = "CELLGROUPID";

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

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Lasttxnid = "LASTTXNID";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public UlCellgroupData() {
		this(new UlCellgroupKey()); 
	}

	public UlCellgroupData(UlCellgroupKey key) {
		super(key, "UlCellgroup");
	}


	public String getCellgroupname() {
		return this.repository().getString(UlCellgroupData.Cellgroupname);
	}

	public UlCellgroupData setCellgroupname(String Cellgroupname) {
		this.repository().set(UlCellgroupData.Cellgroupname, Cellgroupname);
		return this;
	}

	public String getTeamid() {
		return this.repository().getString(UlCellgroupData.Teamid);
	}

	public UlCellgroupData setTeamid(String Teamid) {
		this.repository().set(UlCellgroupData.Teamid, Teamid);
		return this;
	}

	public String getWarehouseid() {
		return this.repository().getString(UlCellgroupData.Warehouseid);
	}

	public UlCellgroupData setWarehouseid(String Warehouseid) {
		this.repository().set(UlCellgroupData.Warehouseid, Warehouseid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(UlCellgroupData.Areaid);
	}

	public UlCellgroupData setAreaid(String Areaid) {
		this.repository().set(UlCellgroupData.Areaid, Areaid);
		return this;
	}

	public String getType() {
		return this.repository().getString(UlCellgroupData.Type);
	}

	public UlCellgroupData setType(String Type) {
		this.repository().set(UlCellgroupData.Type, Type);
		return this;
	}

	public String getMainuserid() {
		return this.repository().getString(UlCellgroupData.Mainuserid);
	}

	public UlCellgroupData setMainuserid(String Mainuserid) {
		this.repository().set(UlCellgroupData.Mainuserid, Mainuserid);
		return this;
	}

	public String getSubuserid() {
		return this.repository().getString(UlCellgroupData.Subuserid);
	}

	public UlCellgroupData setSubuserid(String Subuserid) {
		this.repository().set(UlCellgroupData.Subuserid, Subuserid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlCellgroupData.Description);
	}

	public UlCellgroupData setDescription(String Description) {
		this.repository().set(UlCellgroupData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlCellgroupData.Creator);
	}

	public UlCellgroupData setCreator(String Creator) {
		this.repository().set(UlCellgroupData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlCellgroupData.Createdtime);
	}

	public UlCellgroupData setCreatedtime(Date Createdtime) {
		this.repository().set(UlCellgroupData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlCellgroupData.Modifier);
	}

	public UlCellgroupData setModifier(String Modifier) {
		this.repository().set(UlCellgroupData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlCellgroupData.Modifiedtime);
	}

	public UlCellgroupData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlCellgroupData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(UlCellgroupData.Lasttxnhistkey);
	}

	public UlCellgroupData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(UlCellgroupData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(UlCellgroupData.Lasttxnid);
	}

	public UlCellgroupData setLasttxnid(String Lasttxnid) {
		this.repository().set(UlCellgroupData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(UlCellgroupData.Lasttxnuser);
	}

	public UlCellgroupData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(UlCellgroupData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(UlCellgroupData.Lasttxntime);
	}

	public UlCellgroupData setLasttxntime(Date Lasttxntime) {
		this.repository().set(UlCellgroupData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(UlCellgroupData.Lasttxncomment);
	}

	public UlCellgroupData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(UlCellgroupData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlCellgroupData.Validstate);
	}

	public UlCellgroupData setValidstate(String Validstate) {
		this.repository().set(UlCellgroupData.Validstate, Validstate);
		return this;
	}


}