package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtSubsegmentspecHistoryData extends SQLData {

	public static final String Specdefid = "SPECDEFID";

	public static final String Subprocesssegmentid = "SUBPROCESSSEGMENTID";

	public static final String Specsequence = "SPECSEQUENCE";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Usersequence = "USERSEQUENCE";

	public static final String Isresult = "ISRESULT";

	public static final String Isoutsourcing = "ISOUTSOURCING";

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

	public static final String Ismeasure = "ISMEASURE";

	public CtSubsegmentspecHistoryData() {
		this(new CtSubsegmentspecHistoryKey()); 
	}

	public CtSubsegmentspecHistoryData(CtSubsegmentspecHistoryKey key) {
		super(key, "CtSubsegmentspecHistory");
	}


	public String getUsersequence() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Usersequence);
	}

	public CtSubsegmentspecHistoryData setUsersequence(String Usersequence) {
		this.repository().set(CtSubsegmentspecHistoryData.Usersequence, Usersequence);
		return this;
	}

	public String getIsresult() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Isresult);
	}

	public CtSubsegmentspecHistoryData setIsresult(String Isresult) {
		this.repository().set(CtSubsegmentspecHistoryData.Isresult, Isresult);
		return this;
	}

	public String getIsoutsourcing() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Isoutsourcing);
	}

	public CtSubsegmentspecHistoryData setIsoutsourcing(String Isoutsourcing) {
		this.repository().set(CtSubsegmentspecHistoryData.Isoutsourcing, Isoutsourcing);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Description);
	}

	public CtSubsegmentspecHistoryData setDescription(String Description) {
		this.repository().set(CtSubsegmentspecHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Creator);
	}

	public CtSubsegmentspecHistoryData setCreator(String Creator) {
		this.repository().set(CtSubsegmentspecHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtSubsegmentspecHistoryData.Createdtime);
	}

	public CtSubsegmentspecHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtSubsegmentspecHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Modifier);
	}

	public CtSubsegmentspecHistoryData setModifier(String Modifier) {
		this.repository().set(CtSubsegmentspecHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtSubsegmentspecHistoryData.Modifiedtime);
	}

	public CtSubsegmentspecHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtSubsegmentspecHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Txnid);
	}

	public CtSubsegmentspecHistoryData setTxnid(String Txnid) {
		this.repository().set(CtSubsegmentspecHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Txnuser);
	}

	public CtSubsegmentspecHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtSubsegmentspecHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtSubsegmentspecHistoryData.Txntime);
	}

	public CtSubsegmentspecHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtSubsegmentspecHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Txngrouphistkey);
	}

	public CtSubsegmentspecHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtSubsegmentspecHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Txnreasoncodeclass);
	}

	public CtSubsegmentspecHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtSubsegmentspecHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Txnreasoncode);
	}

	public CtSubsegmentspecHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtSubsegmentspecHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Txncomment);
	}

	public CtSubsegmentspecHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtSubsegmentspecHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Validstate);
	}

	public CtSubsegmentspecHistoryData setValidstate(String Validstate) {
		this.repository().set(CtSubsegmentspecHistoryData.Validstate, Validstate);
		return this;
	}

	public String getIsmeasure() {
		return this.repository().getString(CtSubsegmentspecHistoryData.Ismeasure);
	}

	public CtSubsegmentspecHistoryData setIsmeasure(String Ismeasure) {
		this.repository().set(CtSubsegmentspecHistoryData.Ismeasure, Ismeasure);
		return this;
	}


}