package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlShipinspstandardData extends SQLData {

	public static final String Revno = "REVNO";

	public static final String Inspectionid = "INSPECTIONID";

	public static final String Inspectionname = "INSPECTIONNAME";

	public static final String Reasondescription = "REASONDESCRIPTION";

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

	public UlShipinspstandardData() {
		this(new UlShipinspstandardKey()); 
	}

	public UlShipinspstandardData(UlShipinspstandardKey key) {
		super(key, "UlShipinspstandard");
	}


	public String getInspectionname() {
		return this.repository().getString(UlShipinspstandardData.Inspectionname);
	}

	public UlShipinspstandardData setInspectionname(String Inspectionname) {
		this.repository().set(UlShipinspstandardData.Inspectionname, Inspectionname);
		return this;
	}

	public String getReasondescription() {
		return this.repository().getString(UlShipinspstandardData.Reasondescription);
	}

	public UlShipinspstandardData setReasondescription(String Reasondescription) {
		this.repository().set(UlShipinspstandardData.Reasondescription, Reasondescription);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlShipinspstandardData.Creator);
	}

	public UlShipinspstandardData setCreator(String Creator) {
		this.repository().set(UlShipinspstandardData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlShipinspstandardData.Createdtime);
	}

	public UlShipinspstandardData setCreatedtime(Date Createdtime) {
		this.repository().set(UlShipinspstandardData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlShipinspstandardData.Modifier);
	}

	public UlShipinspstandardData setModifier(String Modifier) {
		this.repository().set(UlShipinspstandardData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlShipinspstandardData.Modifiedtime);
	}

	public UlShipinspstandardData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlShipinspstandardData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(UlShipinspstandardData.Lasttxnhistkey);
	}

	public UlShipinspstandardData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(UlShipinspstandardData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(UlShipinspstandardData.Lasttxnid);
	}

	public UlShipinspstandardData setLasttxnid(String Lasttxnid) {
		this.repository().set(UlShipinspstandardData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(UlShipinspstandardData.Lasttxnuser);
	}

	public UlShipinspstandardData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(UlShipinspstandardData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(UlShipinspstandardData.Lasttxntime);
	}

	public UlShipinspstandardData setLasttxntime(Date Lasttxntime) {
		this.repository().set(UlShipinspstandardData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(UlShipinspstandardData.Lasttxncomment);
	}

	public UlShipinspstandardData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(UlShipinspstandardData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlShipinspstandardData.Validstate);
	}

	public UlShipinspstandardData setValidstate(String Validstate) {
		this.repository().set(UlShipinspstandardData.Validstate, Validstate);
		return this;
	}


}