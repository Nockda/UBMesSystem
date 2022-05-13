package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlEquipmentchecklistData extends SQLData {

	public static final String Equipcheckid = "EQUIPCHECKID";

	public static final String Equipcheckname = "EQUIPCHECKNAME";

	public static final String Checktype = "CHECKTYPE";

	public static final String Checkway = "CHECKWAY";

	public static final String Checkcycle = "CHECKCYCLE";

	public static final String Checkcount = "CHECKCOUNT";

	public static final String Resultway = "RESULTWAY";

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

	public UlEquipmentchecklistData() {
		this(new UlEquipmentchecklistKey()); 
	}

	public UlEquipmentchecklistData(UlEquipmentchecklistKey key) {
		super(key, "UlEquipmentchecklist");
	}


	public String getEquipcheckname() {
		return this.repository().getString(UlEquipmentchecklistData.Equipcheckname);
	}

	public UlEquipmentchecklistData setEquipcheckname(String Equipcheckname) {
		this.repository().set(UlEquipmentchecklistData.Equipcheckname, Equipcheckname);
		return this;
	}

	public String getChecktype() {
		return this.repository().getString(UlEquipmentchecklistData.Checktype);
	}

	public UlEquipmentchecklistData setChecktype(String Checktype) {
		this.repository().set(UlEquipmentchecklistData.Checktype, Checktype);
		return this;
	}

	public String getCheckway() {
		return this.repository().getString(UlEquipmentchecklistData.Checkway);
	}

	public UlEquipmentchecklistData setCheckway(String Checkway) {
		this.repository().set(UlEquipmentchecklistData.Checkway, Checkway);
		return this;
	}

	public String getCheckcycle() {
		return this.repository().getString(UlEquipmentchecklistData.Checkcycle);
	}

	public UlEquipmentchecklistData setCheckcycle(String Checkcycle) {
		this.repository().set(UlEquipmentchecklistData.Checkcycle, Checkcycle);
		return this;
	}

	public Double getCheckcount() {
		return this.repository().getDouble(UlEquipmentchecklistData.Checkcount);
	}

	public UlEquipmentchecklistData setCheckcount(Double Checkcount) {
		this.repository().set(UlEquipmentchecklistData.Checkcount, Checkcount);
		return this;
	}

	public String getResultway() {
		return this.repository().getString(UlEquipmentchecklistData.Resultway);
	}

	public UlEquipmentchecklistData setResultway(String Resultway) {
		this.repository().set(UlEquipmentchecklistData.Resultway, Resultway);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(UlEquipmentchecklistData.Dictionaryid);
	}

	public UlEquipmentchecklistData setDictionaryid(String Dictionaryid) {
		this.repository().set(UlEquipmentchecklistData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlEquipmentchecklistData.Description);
	}

	public UlEquipmentchecklistData setDescription(String Description) {
		this.repository().set(UlEquipmentchecklistData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlEquipmentchecklistData.Creator);
	}

	public UlEquipmentchecklistData setCreator(String Creator) {
		this.repository().set(UlEquipmentchecklistData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlEquipmentchecklistData.Createdtime);
	}

	public UlEquipmentchecklistData setCreatedtime(Date Createdtime) {
		this.repository().set(UlEquipmentchecklistData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlEquipmentchecklistData.Modifier);
	}

	public UlEquipmentchecklistData setModifier(String Modifier) {
		this.repository().set(UlEquipmentchecklistData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlEquipmentchecklistData.Modifiedtime);
	}

	public UlEquipmentchecklistData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlEquipmentchecklistData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(UlEquipmentchecklistData.Lasttxnhistkey);
	}

	public UlEquipmentchecklistData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(UlEquipmentchecklistData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(UlEquipmentchecklistData.Lasttxnid);
	}

	public UlEquipmentchecklistData setLasttxnid(String Lasttxnid) {
		this.repository().set(UlEquipmentchecklistData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(UlEquipmentchecklistData.Lasttxnuser);
	}

	public UlEquipmentchecklistData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(UlEquipmentchecklistData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(UlEquipmentchecklistData.Lasttxntime);
	}

	public UlEquipmentchecklistData setLasttxntime(Date Lasttxntime) {
		this.repository().set(UlEquipmentchecklistData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(UlEquipmentchecklistData.Lasttxncomment);
	}

	public UlEquipmentchecklistData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(UlEquipmentchecklistData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlEquipmentchecklistData.Validstate);
	}

	public UlEquipmentchecklistData setValidstate(String Validstate) {
		this.repository().set(UlEquipmentchecklistData.Validstate, Validstate);
		return this;
	}


}