package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlRackData extends SQLData {

	public static final String Modifier = "MODIFIER";

	public static final String Mainuserid = "MAINUSERID";

	public static final String Mainusername = "MAINUSERNAME";

	public static final String Subuserid = "SUBUSERID";

	public static final String Subusername = "SUBUSERNAME";

	public static final String Rackid = "RACKID";

	public static final String Rackname = "RACKNAME";

	public static final String Warehousename = "WAREHOUSENAME";

	public static final String Warehouseid = "WAREHOUSEID";

	public static final String Validstate = "VALIDSTATE";

	public static final String Team = "TEAM";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public UlRackData() {
		this(new UlRackKey()); 
	}

	public UlRackData(UlRackKey key) {
		super(key, "UlRack");
	}


	public String getModifier() {
		return this.repository().getString(UlRackData.Modifier);
	}

	public UlRackData setModifier(String Modifier) {
		this.repository().set(UlRackData.Modifier, Modifier);
		return this;
	}

	public String getMainuserid() {
		return this.repository().getString(UlRackData.Mainuserid);
	}

	public UlRackData setMainuserid(String Mainuserid) {
		this.repository().set(UlRackData.Mainuserid, Mainuserid);
		return this;
	}

	public String getMainusername() {
		return this.repository().getString(UlRackData.Mainusername);
	}

	public UlRackData setMainusername(String Mainusername) {
		this.repository().set(UlRackData.Mainusername, Mainusername);
		return this;
	}

	public String getSubuserid() {
		return this.repository().getString(UlRackData.Subuserid);
	}

	public UlRackData setSubuserid(String Subuserid) {
		this.repository().set(UlRackData.Subuserid, Subuserid);
		return this;
	}

	public String getSubusername() {
		return this.repository().getString(UlRackData.Subusername);
	}

	public UlRackData setSubusername(String Subusername) {
		this.repository().set(UlRackData.Subusername, Subusername);
		return this;
	}

	public String getRackname() {
		return this.repository().getString(UlRackData.Rackname);
	}

	public UlRackData setRackname(String Rackname) {
		this.repository().set(UlRackData.Rackname, Rackname);
		return this;
	}

	public String getWarehousename() {
		return this.repository().getString(UlRackData.Warehousename);
	}

	public UlRackData setWarehousename(String Warehousename) {
		this.repository().set(UlRackData.Warehousename, Warehousename);
		return this;
	}

	public String getWarehouseid() {
		return this.repository().getString(UlRackData.Warehouseid);
	}

	public UlRackData setWarehouseid(String Warehouseid) {
		this.repository().set(UlRackData.Warehouseid, Warehouseid);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlRackData.Validstate);
	}

	public UlRackData setValidstate(String Validstate) {
		this.repository().set(UlRackData.Validstate, Validstate);
		return this;
	}

	public String getTeam() {
		return this.repository().getString(UlRackData.Team);
	}

	public UlRackData setTeam(String Team) {
		this.repository().set(UlRackData.Team, Team);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlRackData.Createdtime);
	}

	public UlRackData setCreatedtime(Date Createdtime) {
		this.repository().set(UlRackData.Createdtime, Createdtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlRackData.Creator);
	}

	public UlRackData setCreator(String Creator) {
		this.repository().set(UlRackData.Creator, Creator);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlRackData.Modifiedtime);
	}

	public UlRackData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlRackData.Modifiedtime, Modifiedtime);
		return this;
	}


}