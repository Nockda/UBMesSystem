package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfEquipmentclassData extends SQLData {

	public static final String Equipmentclassid = "EQUIPMENTCLASSID";

	public static final String Equipmentclassname = "EQUIPMENTCLASSNAME";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Equipmentclasstype = "EQUIPMENTCLASSTYPE";

	public static final String Parentequipmentclassid = "PARENTEQUIPMENTCLASSID";

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

	public SfEquipmentclassData() {
		this(new SfEquipmentclassKey()); 
	}

	public SfEquipmentclassData(SfEquipmentclassKey key) {
		super(key, "SfEquipmentclass");
	}


	public String getEquipmentclassname() {
		return this.repository().getString(SfEquipmentclassData.Equipmentclassname);
	}

	public SfEquipmentclassData setEquipmentclassname(String Equipmentclassname) {
		this.repository().set(SfEquipmentclassData.Equipmentclassname, Equipmentclassname);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfEquipmentclassData.Enterpriseid);
	}

	public SfEquipmentclassData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfEquipmentclassData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfEquipmentclassData.Plantid);
	}

	public SfEquipmentclassData setPlantid(String Plantid) {
		this.repository().set(SfEquipmentclassData.Plantid, Plantid);
		return this;
	}

	public String getEquipmentclasstype() {
		return this.repository().getString(SfEquipmentclassData.Equipmentclasstype);
	}

	public SfEquipmentclassData setEquipmentclasstype(String Equipmentclasstype) {
		this.repository().set(SfEquipmentclassData.Equipmentclasstype, Equipmentclasstype);
		return this;
	}

	public String getParentequipmentclassid() {
		return this.repository().getString(SfEquipmentclassData.Parentequipmentclassid);
	}

	public SfEquipmentclassData setParentequipmentclassid(String Parentequipmentclassid) {
		this.repository().set(SfEquipmentclassData.Parentequipmentclassid, Parentequipmentclassid);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfEquipmentclassData.Dictionaryid);
	}

	public SfEquipmentclassData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfEquipmentclassData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfEquipmentclassData.Description);
	}

	public SfEquipmentclassData setDescription(String Description) {
		this.repository().set(SfEquipmentclassData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfEquipmentclassData.Creator);
	}

	public SfEquipmentclassData setCreator(String Creator) {
		this.repository().set(SfEquipmentclassData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfEquipmentclassData.Createdtime);
	}

	public SfEquipmentclassData setCreatedtime(Date Createdtime) {
		this.repository().set(SfEquipmentclassData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfEquipmentclassData.Modifier);
	}

	public SfEquipmentclassData setModifier(String Modifier) {
		this.repository().set(SfEquipmentclassData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfEquipmentclassData.Modifiedtime);
	}

	public SfEquipmentclassData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfEquipmentclassData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfEquipmentclassData.Lasttxnhistkey);
	}

	public SfEquipmentclassData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfEquipmentclassData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfEquipmentclassData.Lasttxnid);
	}

	public SfEquipmentclassData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfEquipmentclassData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfEquipmentclassData.Lasttxnuser);
	}

	public SfEquipmentclassData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfEquipmentclassData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfEquipmentclassData.Lasttxntime);
	}

	public SfEquipmentclassData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfEquipmentclassData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfEquipmentclassData.Lasttxncomment);
	}

	public SfEquipmentclassData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfEquipmentclassData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfEquipmentclassData.Validstate);
	}

	public SfEquipmentclassData setValidstate(String Validstate) {
		this.repository().set(SfEquipmentclassData.Validstate, Validstate);
		return this;
	}


}