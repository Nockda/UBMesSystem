package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtModelstandardinfoData extends SQLData {

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Modelid = "MODELID";

	public static final String Standard1 = "STANDARD1";

	public static final String Standard2 = "STANDARD2";

	public static final String Standard3 = "STANDARD3";

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

	public CtModelstandardinfoData() {
		this(new CtModelstandardinfoKey()); 
	}

	public CtModelstandardinfoData(CtModelstandardinfoKey key) {
		super(key, "CtModelstandardinfo");
	}


	public String getStandard1() {
		return this.repository().getString(CtModelstandardinfoData.Standard1);
	}

	public CtModelstandardinfoData setStandard1(String Standard1) {
		this.repository().set(CtModelstandardinfoData.Standard1, Standard1);
		return this;
	}

	public String getStandard2() {
		return this.repository().getString(CtModelstandardinfoData.Standard2);
	}

	public CtModelstandardinfoData setStandard2(String Standard2) {
		this.repository().set(CtModelstandardinfoData.Standard2, Standard2);
		return this;
	}

	public String getStandard3() {
		return this.repository().getString(CtModelstandardinfoData.Standard3);
	}

	public CtModelstandardinfoData setStandard3(String Standard3) {
		this.repository().set(CtModelstandardinfoData.Standard3, Standard3);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtModelstandardinfoData.Description);
	}

	public CtModelstandardinfoData setDescription(String Description) {
		this.repository().set(CtModelstandardinfoData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtModelstandardinfoData.Creator);
	}

	public CtModelstandardinfoData setCreator(String Creator) {
		this.repository().set(CtModelstandardinfoData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtModelstandardinfoData.Createdtime);
	}

	public CtModelstandardinfoData setCreatedtime(Date Createdtime) {
		this.repository().set(CtModelstandardinfoData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtModelstandardinfoData.Modifier);
	}

	public CtModelstandardinfoData setModifier(String Modifier) {
		this.repository().set(CtModelstandardinfoData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtModelstandardinfoData.Modifiedtime);
	}

	public CtModelstandardinfoData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtModelstandardinfoData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtModelstandardinfoData.Lasttxnhistkey);
	}

	public CtModelstandardinfoData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtModelstandardinfoData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtModelstandardinfoData.Lasttxnid);
	}

	public CtModelstandardinfoData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtModelstandardinfoData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtModelstandardinfoData.Lasttxnuser);
	}

	public CtModelstandardinfoData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtModelstandardinfoData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtModelstandardinfoData.Lasttxntime);
	}

	public CtModelstandardinfoData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtModelstandardinfoData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtModelstandardinfoData.Lasttxncomment);
	}

	public CtModelstandardinfoData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtModelstandardinfoData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtModelstandardinfoData.Validstate);
	}

	public CtModelstandardinfoData setValidstate(String Validstate) {
		this.repository().set(CtModelstandardinfoData.Validstate, Validstate);
		return this;
	}


}