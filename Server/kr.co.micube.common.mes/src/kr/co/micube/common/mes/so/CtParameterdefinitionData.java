package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtParameterdefinitionData extends SQLData {

	public static final String Parameterid = "PARAMETERID";

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

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Lasttxnid = "LASTTXNID";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public static final String Isnotrequired = "ISNOTREQUIRED";

	public static final String Eqpsignaltype = "EQPSIGNALTYPE";

	public CtParameterdefinitionData() {
		this(new CtParameterdefinitionKey()); 
	}

	public CtParameterdefinitionData(CtParameterdefinitionKey key) {
		super(key, "CtParameterdefinition");
	}


	public String getParametername() {
		return this.repository().getString(CtParameterdefinitionData.Parametername);
	}

	public CtParameterdefinitionData setParametername(String Parametername) {
		this.repository().set(CtParameterdefinitionData.Parametername, Parametername);
		return this;
	}

	public String getInputtype() {
		return this.repository().getString(CtParameterdefinitionData.Inputtype);
	}

	public CtParameterdefinitionData setInputtype(String Inputtype) {
		this.repository().set(CtParameterdefinitionData.Inputtype, Inputtype);
		return this;
	}

	public String getUnit() {
		return this.repository().getString(CtParameterdefinitionData.Unit);
	}

	public CtParameterdefinitionData setUnit(String Unit) {
		this.repository().set(CtParameterdefinitionData.Unit, Unit);
		return this;
	}

	public Double getDecimalplace() {
		return this.repository().getDouble(CtParameterdefinitionData.Decimalplace);
	}

	public CtParameterdefinitionData setDecimalplace(Double Decimalplace) {
		this.repository().set(CtParameterdefinitionData.Decimalplace, Decimalplace);
		return this;
	}

	public String getParametertype() {
		return this.repository().getString(CtParameterdefinitionData.Parametertype);
	}

	public CtParameterdefinitionData setParametertype(String Parametertype) {
		this.repository().set(CtParameterdefinitionData.Parametertype, Parametertype);
		return this;
	}

	public String getCodeclassid() {
		return this.repository().getString(CtParameterdefinitionData.Codeclassid);
	}

	public CtParameterdefinitionData setCodeclassid(String Codeclassid) {
		this.repository().set(CtParameterdefinitionData.Codeclassid, Codeclassid);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(CtParameterdefinitionData.Dictionaryid);
	}

	public CtParameterdefinitionData setDictionaryid(String Dictionaryid) {
		this.repository().set(CtParameterdefinitionData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtParameterdefinitionData.Description);
	}

	public CtParameterdefinitionData setDescription(String Description) {
		this.repository().set(CtParameterdefinitionData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtParameterdefinitionData.Creator);
	}

	public CtParameterdefinitionData setCreator(String Creator) {
		this.repository().set(CtParameterdefinitionData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtParameterdefinitionData.Createdtime);
	}

	public CtParameterdefinitionData setCreatedtime(Date Createdtime) {
		this.repository().set(CtParameterdefinitionData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtParameterdefinitionData.Modifier);
	}

	public CtParameterdefinitionData setModifier(String Modifier) {
		this.repository().set(CtParameterdefinitionData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtParameterdefinitionData.Modifiedtime);
	}

	public CtParameterdefinitionData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtParameterdefinitionData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtParameterdefinitionData.Lasttxnhistkey);
	}

	public CtParameterdefinitionData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtParameterdefinitionData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtParameterdefinitionData.Lasttxnid);
	}

	public CtParameterdefinitionData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtParameterdefinitionData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtParameterdefinitionData.Lasttxnuser);
	}

	public CtParameterdefinitionData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtParameterdefinitionData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtParameterdefinitionData.Lasttxntime);
	}

	public CtParameterdefinitionData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtParameterdefinitionData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtParameterdefinitionData.Lasttxncomment);
	}

	public CtParameterdefinitionData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtParameterdefinitionData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtParameterdefinitionData.Validstate);
	}

	public CtParameterdefinitionData setValidstate(String Validstate) {
		this.repository().set(CtParameterdefinitionData.Validstate, Validstate);
		return this;
	}

	public String getIsnotrequired() {
		return this.repository().getString(CtParameterdefinitionData.Isnotrequired);
	}

	public CtParameterdefinitionData setIsnotrequired(String Isnotrequired) {
		this.repository().set(CtParameterdefinitionData.Isnotrequired, Isnotrequired);
		return this;
	}

	public String getEqpsignaltype() {
		return this.repository().getString(CtParameterdefinitionData.Eqpsignaltype);
	}

	public CtParameterdefinitionData setEqpsignaltype(String Eqpsignaltype) {
		this.repository().set(CtParameterdefinitionData.Eqpsignaltype, Eqpsignaltype);
		return this;
	}


}