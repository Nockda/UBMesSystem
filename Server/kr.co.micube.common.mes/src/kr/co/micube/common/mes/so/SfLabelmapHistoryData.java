package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfLabelmapHistoryData extends SQLData {

	public static final String Labelid = "LABELID";

	public static final String Productdefid = "PRODUCTDEFID";

	public static final String Productdefversion = "PRODUCTDEFVERSION";

	public static final String Txnhistkey = "TXNHISTKEY";

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

	public SfLabelmapHistoryData() {
		this(new SfLabelmapHistoryKey()); 
	}

	public SfLabelmapHistoryData(SfLabelmapHistoryKey key) {
		super(key, "SfLabelmapHistory");
	}


	public String getDescription() {
		return this.repository().getString(SfLabelmapHistoryData.Description);
	}

	public SfLabelmapHistoryData setDescription(String Description) {
		this.repository().set(SfLabelmapHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfLabelmapHistoryData.Creator);
	}

	public SfLabelmapHistoryData setCreator(String Creator) {
		this.repository().set(SfLabelmapHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfLabelmapHistoryData.Createdtime);
	}

	public SfLabelmapHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(SfLabelmapHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfLabelmapHistoryData.Modifier);
	}

	public SfLabelmapHistoryData setModifier(String Modifier) {
		this.repository().set(SfLabelmapHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfLabelmapHistoryData.Modifiedtime);
	}

	public SfLabelmapHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfLabelmapHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(SfLabelmapHistoryData.Txnid);
	}

	public SfLabelmapHistoryData setTxnid(String Txnid) {
		this.repository().set(SfLabelmapHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfLabelmapHistoryData.Txnuser);
	}

	public SfLabelmapHistoryData setTxnuser(String Txnuser) {
		this.repository().set(SfLabelmapHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfLabelmapHistoryData.Txntime);
	}

	public SfLabelmapHistoryData setTxntime(Date Txntime) {
		this.repository().set(SfLabelmapHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfLabelmapHistoryData.Txngrouphistkey);
	}

	public SfLabelmapHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfLabelmapHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfLabelmapHistoryData.Txnreasoncodeclass);
	}

	public SfLabelmapHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfLabelmapHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfLabelmapHistoryData.Txnreasoncode);
	}

	public SfLabelmapHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfLabelmapHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfLabelmapHistoryData.Txncomment);
	}

	public SfLabelmapHistoryData setTxncomment(String Txncomment) {
		this.repository().set(SfLabelmapHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfLabelmapHistoryData.Validstate);
	}

	public SfLabelmapHistoryData setValidstate(String Validstate) {
		this.repository().set(SfLabelmapHistoryData.Validstate, Validstate);
		return this;
	}


}