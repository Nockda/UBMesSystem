package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtTeamData extends SQLData {

	public static final String Teamid = "TEAMID";

	public static final String Teamname = "TEAMNAME";

	public static final String Dictionaryid = "DICTIONARYID";

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

	public CtTeamData() {
		this(new CtTeamKey()); 
	}

	public CtTeamData(CtTeamKey key) {
		super(key, "CtTeam");
	}


	public String getTeamname() {
		return this.repository().getString(CtTeamData.Teamname);
	}

	public CtTeamData setTeamname(String Teamname) {
		this.repository().set(CtTeamData.Teamname, Teamname);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(CtTeamData.Dictionaryid);
	}

	public CtTeamData setDictionaryid(String Dictionaryid) {
		this.repository().set(CtTeamData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtTeamData.Description);
	}

	public CtTeamData setDescription(String Description) {
		this.repository().set(CtTeamData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtTeamData.Creator);
	}

	public CtTeamData setCreator(String Creator) {
		this.repository().set(CtTeamData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtTeamData.Createdtime);
	}

	public CtTeamData setCreatedtime(Date Createdtime) {
		this.repository().set(CtTeamData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtTeamData.Modifier);
	}

	public CtTeamData setModifier(String Modifier) {
		this.repository().set(CtTeamData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtTeamData.Modifiedtime);
	}

	public CtTeamData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtTeamData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtTeamData.Lasttxnhistkey);
	}

	public CtTeamData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtTeamData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtTeamData.Lasttxnid);
	}

	public CtTeamData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtTeamData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtTeamData.Lasttxnuser);
	}

	public CtTeamData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtTeamData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtTeamData.Lasttxntime);
	}

	public CtTeamData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtTeamData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtTeamData.Lasttxncomment);
	}

	public CtTeamData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtTeamData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtTeamData.Validstate);
	}

	public CtTeamData setValidstate(String Validstate) {
		this.repository().set(CtTeamData.Validstate, Validstate);
		return this;
	}


}