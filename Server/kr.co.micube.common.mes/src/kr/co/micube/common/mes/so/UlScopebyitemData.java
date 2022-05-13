package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlScopebyitemData extends SQLData {

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Drawingnumber = "DRAWINGNUMBER";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Itemname = "ITEMNAME";

	public static final String Validstate = "VALIDSTATE";

	public static final String Modifier = "MODIFIER";

	public static final String Itemid = "ITEMID";

	public static final String Team = "TEAM";

	public static final String Processid = "PROCESSID";

	public static final String Scope = "SCOPE";

	public static final String Modelname = "MODELNAME";

	public UlScopebyitemData() {
		this(new UlScopebyitemKey()); 
	}

	public UlScopebyitemData(UlScopebyitemKey key) {
		super(key, "UlScopebyitem");
	}


	public Date getModifiedtime() {
		return this.repository().getDate(UlScopebyitemData.Modifiedtime);
	}

	public UlScopebyitemData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlScopebyitemData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlScopebyitemData.Creator);
	}

	public UlScopebyitemData setCreator(String Creator) {
		this.repository().set(UlScopebyitemData.Creator, Creator);
		return this;
	}

	public String getDrawingnumber() {
		return this.repository().getString(UlScopebyitemData.Drawingnumber);
	}

	public UlScopebyitemData setDrawingnumber(String Drawingnumber) {
		this.repository().set(UlScopebyitemData.Drawingnumber, Drawingnumber);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlScopebyitemData.Createdtime);
	}

	public UlScopebyitemData setCreatedtime(Date Createdtime) {
		this.repository().set(UlScopebyitemData.Createdtime, Createdtime);
		return this;
	}

	public String getItemname() {
		return this.repository().getString(UlScopebyitemData.Itemname);
	}

	public UlScopebyitemData setItemname(String Itemname) {
		this.repository().set(UlScopebyitemData.Itemname, Itemname);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlScopebyitemData.Validstate);
	}

	public UlScopebyitemData setValidstate(String Validstate) {
		this.repository().set(UlScopebyitemData.Validstate, Validstate);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlScopebyitemData.Modifier);
	}

	public UlScopebyitemData setModifier(String Modifier) {
		this.repository().set(UlScopebyitemData.Modifier, Modifier);
		return this;
	}

	public String getTeam() {
		return this.repository().getString(UlScopebyitemData.Team);
	}

	public UlScopebyitemData setTeam(String Team) {
		this.repository().set(UlScopebyitemData.Team, Team);
		return this;
	}

	public String getProcessid() {
		return this.repository().getString(UlScopebyitemData.Processid);
	}

	public UlScopebyitemData setProcessid(String Processid) {
		this.repository().set(UlScopebyitemData.Processid, Processid);
		return this;
	}

	public Double getScope() {
		return this.repository().getDouble(UlScopebyitemData.Scope);
	}

	public UlScopebyitemData setScope(Double Scope) {
		this.repository().set(UlScopebyitemData.Scope, Scope);
		return this;
	}

	public String getModelname() {
		return this.repository().getString(UlScopebyitemData.Modelname);
	}

	public UlScopebyitemData setModelname(String Modelname) {
		this.repository().set(UlScopebyitemData.Modelname, Modelname);
		return this;
	}


}