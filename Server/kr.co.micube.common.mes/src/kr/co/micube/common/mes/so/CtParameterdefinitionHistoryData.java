package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtParameterdefinitionHistoryData extends SQLData {

	public static final String Parameterid = "PARAMETERID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Parametername = "PARAMETERNAME";

	public static final String Inputtype = "INPUTTYPE";

	public static final String Unit = "UNIT";

	public static final String Decimalplace = "DECIMALPLACE";

	public static final String Parametertype = "PARAMETERTYPE";

	public static final String Codeclassid = "CODECLASSID";

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

	public static final String Isnotrequired = "ISNOTREQUIRED";

	public static final String Eqpsignaltype = "EQPSIGNALTYPE";

	public CtParameterdefinitionHistoryData() {
		this(new CtParameterdefinitionHistoryKey()); 
	}

	public CtParameterdefinitionHistoryData(CtParameterdefinitionHistoryKey key) {
		super(key, "CtParameterdefinitionHistory");
	}


	public String getParametername() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Parametername);
	}

	public CtParameterdefinitionHistoryData setParametername(String Parametername) {
		this.repository().set(CtParameterdefinitionHistoryData.Parametername, Parametername);
		return this;
	}

	public String getInputtype() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Inputtype);
	}

	public CtParameterdefinitionHistoryData setInputtype(String Inputtype) {
		this.repository().set(CtParameterdefinitionHistoryData.Inputtype, Inputtype);
		return this;
	}

	public String getUnit() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Unit);
	}

	public CtParameterdefinitionHistoryData setUnit(String Unit) {
		this.repository().set(CtParameterdefinitionHistoryData.Unit, Unit);
		return this;
	}

	public Double getDecimalplace() {
		return this.repository().getDouble(CtParameterdefinitionHistoryData.Decimalplace);
	}

	public CtParameterdefinitionHistoryData setDecimalplace(Double Decimalplace) {
		this.repository().set(CtParameterdefinitionHistoryData.Decimalplace, Decimalplace);
		return this;
	}

	public String getParametertype() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Parametertype);
	}

	public CtParameterdefinitionHistoryData setParametertype(String Parametertype) {
		this.repository().set(CtParameterdefinitionHistoryData.Parametertype, Parametertype);
		return this;
	}

	public String getCodeclassid() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Codeclassid);
	}

	public CtParameterdefinitionHistoryData setCodeclassid(String Codeclassid) {
		this.repository().set(CtParameterdefinitionHistoryData.Codeclassid, Codeclassid);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Dictionaryid);
	}

	public CtParameterdefinitionHistoryData setDictionaryid(String Dictionaryid) {
		this.repository().set(CtParameterdefinitionHistoryData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Description);
	}

	public CtParameterdefinitionHistoryData setDescription(String Description) {
		this.repository().set(CtParameterdefinitionHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Creator);
	}

	public CtParameterdefinitionHistoryData setCreator(String Creator) {
		this.repository().set(CtParameterdefinitionHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtParameterdefinitionHistoryData.Createdtime);
	}

	public CtParameterdefinitionHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtParameterdefinitionHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Modifier);
	}

	public CtParameterdefinitionHistoryData setModifier(String Modifier) {
		this.repository().set(CtParameterdefinitionHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtParameterdefinitionHistoryData.Modifiedtime);
	}

	public CtParameterdefinitionHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtParameterdefinitionHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Txnid);
	}

	public CtParameterdefinitionHistoryData setTxnid(String Txnid) {
		this.repository().set(CtParameterdefinitionHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Txnuser);
	}

	public CtParameterdefinitionHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtParameterdefinitionHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtParameterdefinitionHistoryData.Txntime);
	}

	public CtParameterdefinitionHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtParameterdefinitionHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Txngrouphistkey);
	}

	public CtParameterdefinitionHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtParameterdefinitionHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Txnreasoncodeclass);
	}

	public CtParameterdefinitionHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtParameterdefinitionHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Txnreasoncode);
	}

	public CtParameterdefinitionHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtParameterdefinitionHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Txncomment);
	}

	public CtParameterdefinitionHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtParameterdefinitionHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Validstate);
	}

	public CtParameterdefinitionHistoryData setValidstate(String Validstate) {
		this.repository().set(CtParameterdefinitionHistoryData.Validstate, Validstate);
		return this;
	}

	public String getIsnotrequired() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Isnotrequired);
	}

	public CtParameterdefinitionHistoryData setIsnotrequired(String Isnotrequired) {
		this.repository().set(CtParameterdefinitionHistoryData.Isnotrequired, Isnotrequired);
		return this;
	}

	public String getEqpsignaltype() {
		return this.repository().getString(CtParameterdefinitionHistoryData.Eqpsignaltype);
	}

	public CtParameterdefinitionHistoryData setEqpsignaltype(String Eqpsignaltype) {
		this.repository().set(CtParameterdefinitionHistoryData.Eqpsignaltype, Eqpsignaltype);
		return this;
	}


}