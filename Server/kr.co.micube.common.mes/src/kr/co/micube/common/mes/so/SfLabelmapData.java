package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfLabelmapData extends SQLData {

	public static final String Labelid = "LABELID";

	public static final String Productdefid = "PRODUCTDEFID";

	public static final String Productdefversion = "PRODUCTDEFVERSION";

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

	public SfLabelmapData() {
		this(new SfLabelmapKey()); 
	}

	public SfLabelmapData(SfLabelmapKey key) {
		super(key, "SfLabelmap");
	}


	public String getDescription() {
		return this.repository().getString(SfLabelmapData.Description);
	}

	public SfLabelmapData setDescription(String Description) {
		this.repository().set(SfLabelmapData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfLabelmapData.Creator);
	}

	public SfLabelmapData setCreator(String Creator) {
		this.repository().set(SfLabelmapData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfLabelmapData.Createdtime);
	}

	public SfLabelmapData setCreatedtime(Date Createdtime) {
		this.repository().set(SfLabelmapData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfLabelmapData.Modifier);
	}

	public SfLabelmapData setModifier(String Modifier) {
		this.repository().set(SfLabelmapData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfLabelmapData.Modifiedtime);
	}

	public SfLabelmapData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfLabelmapData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfLabelmapData.Lasttxnhistkey);
	}

	public SfLabelmapData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfLabelmapData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfLabelmapData.Lasttxnid);
	}

	public SfLabelmapData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfLabelmapData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfLabelmapData.Lasttxnuser);
	}

	public SfLabelmapData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfLabelmapData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfLabelmapData.Lasttxntime);
	}

	public SfLabelmapData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfLabelmapData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfLabelmapData.Lasttxncomment);
	}

	public SfLabelmapData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfLabelmapData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfLabelmapData.Validstate);
	}

	public SfLabelmapData setValidstate(String Validstate) {
		this.repository().set(SfLabelmapData.Validstate, Validstate);
		return this;
	}


}