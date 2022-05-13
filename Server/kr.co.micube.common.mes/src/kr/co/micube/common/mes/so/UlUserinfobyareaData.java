package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlUserinfobyareaData extends SQLData {

	public static final String Team = "TEAM";

	public static final String Position = "POSITION";

	public static final String Processid = "PROCESSID";

	public static final String Username = "USERNAME";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Validstate = "VALIDSTATE";

	public static final String Modifier = "MODIFIER";

	public static final String Areaid = "AREAID";

	public static final String Userid = "USERID";

	public UlUserinfobyareaData() {
		this(new UlUserinfobyareaKey()); 
	}

	public UlUserinfobyareaData(UlUserinfobyareaKey key) {
		super(key, "UlUserinfobyarea");
	}


	public String getTeam() {
		return this.repository().getString(UlUserinfobyareaData.Team);
	}

	public UlUserinfobyareaData setTeam(String Team) {
		this.repository().set(UlUserinfobyareaData.Team, Team);
		return this;
	}

	public String getPosition() {
		return this.repository().getString(UlUserinfobyareaData.Position);
	}

	public UlUserinfobyareaData setPosition(String Position) {
		this.repository().set(UlUserinfobyareaData.Position, Position);
		return this;
	}

	public String getUsername() {
		return this.repository().getString(UlUserinfobyareaData.Username);
	}

	public UlUserinfobyareaData setUsername(String Username) {
		this.repository().set(UlUserinfobyareaData.Username, Username);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlUserinfobyareaData.Modifiedtime);
	}

	public UlUserinfobyareaData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlUserinfobyareaData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlUserinfobyareaData.Creator);
	}

	public UlUserinfobyareaData setCreator(String Creator) {
		this.repository().set(UlUserinfobyareaData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlUserinfobyareaData.Createdtime);
	}

	public UlUserinfobyareaData setCreatedtime(Date Createdtime) {
		this.repository().set(UlUserinfobyareaData.Createdtime, Createdtime);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlUserinfobyareaData.Validstate);
	}

	public UlUserinfobyareaData setValidstate(String Validstate) {
		this.repository().set(UlUserinfobyareaData.Validstate, Validstate);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlUserinfobyareaData.Modifier);
	}

	public UlUserinfobyareaData setModifier(String Modifier) {
		this.repository().set(UlUserinfobyareaData.Modifier, Modifier);
		return this;
	}

	public String getUserid() {
		return this.repository().getString(UlUserinfobyareaData.Userid);
	}

	public UlUserinfobyareaData setUserid(String Userid) {
		this.repository().set(UlUserinfobyareaData.Userid, Userid);
		return this;
	}


}