package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtModelstandardinfoHistoryData extends SQLData {

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Modelid = "MODELID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Standard1 = "STANDARD1";

	public static final String Standard2 = "STANDARD2";

	public static final String Standard3 = "STANDARD3";

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

	public CtModelstandardinfoHistoryData() {
		this(new CtModelstandardinfoHistoryKey()); 
	}

	public CtModelstandardinfoHistoryData(CtModelstandardinfoHistoryKey key) {
		super(key, "CtModelstandardinfoHistory");
	}


	public String getStandard1() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Standard1);
	}

	public CtModelstandardinfoHistoryData setStandard1(String Standard1) {
		this.repository().set(CtModelstandardinfoHistoryData.Standard1, Standard1);
		return this;
	}

	public String getStandard2() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Standard2);
	}

	public CtModelstandardinfoHistoryData setStandard2(String Standard2) {
		this.repository().set(CtModelstandardinfoHistoryData.Standard2, Standard2);
		return this;
	}

	public String getStandard3() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Standard3);
	}

	public CtModelstandardinfoHistoryData setStandard3(String Standard3) {
		this.repository().set(CtModelstandardinfoHistoryData.Standard3, Standard3);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Description);
	}

	public CtModelstandardinfoHistoryData setDescription(String Description) {
		this.repository().set(CtModelstandardinfoHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Creator);
	}

	public CtModelstandardinfoHistoryData setCreator(String Creator) {
		this.repository().set(CtModelstandardinfoHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtModelstandardinfoHistoryData.Createdtime);
	}

	public CtModelstandardinfoHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtModelstandardinfoHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Modifier);
	}

	public CtModelstandardinfoHistoryData setModifier(String Modifier) {
		this.repository().set(CtModelstandardinfoHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtModelstandardinfoHistoryData.Modifiedtime);
	}

	public CtModelstandardinfoHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtModelstandardinfoHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Txnid);
	}

	public CtModelstandardinfoHistoryData setTxnid(String Txnid) {
		this.repository().set(CtModelstandardinfoHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Txnuser);
	}

	public CtModelstandardinfoHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtModelstandardinfoHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtModelstandardinfoHistoryData.Txntime);
	}

	public CtModelstandardinfoHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtModelstandardinfoHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Txngrouphistkey);
	}

	public CtModelstandardinfoHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtModelstandardinfoHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Txnreasoncodeclass);
	}

	public CtModelstandardinfoHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtModelstandardinfoHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Txnreasoncode);
	}

	public CtModelstandardinfoHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtModelstandardinfoHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Txncomment);
	}

	public CtModelstandardinfoHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtModelstandardinfoHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtModelstandardinfoHistoryData.Validstate);
	}

	public CtModelstandardinfoHistoryData setValidstate(String Validstate) {
		this.repository().set(CtModelstandardinfoHistoryData.Validstate, Validstate);
		return this;
	}


}