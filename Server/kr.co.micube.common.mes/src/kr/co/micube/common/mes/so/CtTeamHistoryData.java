package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtTeamHistoryData extends SQLData {

	public static final String Teamid = "TEAMID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Teamname = "TEAMNAME";

	public static final String Dictionaryid = "DICTIONARYID";

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

	public CtTeamHistoryData() {
		this(new CtTeamHistoryKey()); 
	}

	public CtTeamHistoryData(CtTeamHistoryKey key) {
		super(key, "CtTeamHistory");
	}


	public String getTeamname() {
		return this.repository().getString(CtTeamHistoryData.Teamname);
	}

	public CtTeamHistoryData setTeamname(String Teamname) {
		this.repository().set(CtTeamHistoryData.Teamname, Teamname);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(CtTeamHistoryData.Dictionaryid);
	}

	public CtTeamHistoryData setDictionaryid(String Dictionaryid) {
		this.repository().set(CtTeamHistoryData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtTeamHistoryData.Description);
	}

	public CtTeamHistoryData setDescription(String Description) {
		this.repository().set(CtTeamHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtTeamHistoryData.Creator);
	}

	public CtTeamHistoryData setCreator(String Creator) {
		this.repository().set(CtTeamHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtTeamHistoryData.Createdtime);
	}

	public CtTeamHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtTeamHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtTeamHistoryData.Modifier);
	}

	public CtTeamHistoryData setModifier(String Modifier) {
		this.repository().set(CtTeamHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtTeamHistoryData.Modifiedtime);
	}

	public CtTeamHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtTeamHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtTeamHistoryData.Txnid);
	}

	public CtTeamHistoryData setTxnid(String Txnid) {
		this.repository().set(CtTeamHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtTeamHistoryData.Txnuser);
	}

	public CtTeamHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtTeamHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtTeamHistoryData.Txntime);
	}

	public CtTeamHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtTeamHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtTeamHistoryData.Txngrouphistkey);
	}

	public CtTeamHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtTeamHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtTeamHistoryData.Txnreasoncodeclass);
	}

	public CtTeamHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtTeamHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtTeamHistoryData.Txnreasoncode);
	}

	public CtTeamHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtTeamHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtTeamHistoryData.Txncomment);
	}

	public CtTeamHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtTeamHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtTeamHistoryData.Validstate);
	}

	public CtTeamHistoryData setValidstate(String Validstate) {
		this.repository().set(CtTeamHistoryData.Validstate, Validstate);
		return this;
	}


}