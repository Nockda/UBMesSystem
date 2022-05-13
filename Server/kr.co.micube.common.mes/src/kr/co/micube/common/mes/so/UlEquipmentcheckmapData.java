package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlEquipmentcheckmapData extends SQLData {

	public static final String Equipmentclassid = "EQUIPMENTCLASSID";

	public static final String Equipcheckid = "EQUIPCHECKID";

	public static final String Checkpart = "CHECKPART";

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

	public UlEquipmentcheckmapData() {
		this(new UlEquipmentcheckmapKey()); 
	}

	public UlEquipmentcheckmapData(UlEquipmentcheckmapKey key) {
		super(key, "UlEquipmentcheckmap");
	}


	public String getCheckpart() {
		return this.repository().getString(UlEquipmentcheckmapData.Checkpart);
	}

	public UlEquipmentcheckmapData setCheckpart(String Checkpart) {
		this.repository().set(UlEquipmentcheckmapData.Checkpart, Checkpart);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlEquipmentcheckmapData.Description);
	}

	public UlEquipmentcheckmapData setDescription(String Description) {
		this.repository().set(UlEquipmentcheckmapData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlEquipmentcheckmapData.Creator);
	}

	public UlEquipmentcheckmapData setCreator(String Creator) {
		this.repository().set(UlEquipmentcheckmapData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlEquipmentcheckmapData.Createdtime);
	}

	public UlEquipmentcheckmapData setCreatedtime(Date Createdtime) {
		this.repository().set(UlEquipmentcheckmapData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlEquipmentcheckmapData.Modifier);
	}

	public UlEquipmentcheckmapData setModifier(String Modifier) {
		this.repository().set(UlEquipmentcheckmapData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlEquipmentcheckmapData.Modifiedtime);
	}

	public UlEquipmentcheckmapData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlEquipmentcheckmapData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(UlEquipmentcheckmapData.Lasttxnhistkey);
	}

	public UlEquipmentcheckmapData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(UlEquipmentcheckmapData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(UlEquipmentcheckmapData.Lasttxnid);
	}

	public UlEquipmentcheckmapData setLasttxnid(String Lasttxnid) {
		this.repository().set(UlEquipmentcheckmapData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(UlEquipmentcheckmapData.Lasttxnuser);
	}

	public UlEquipmentcheckmapData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(UlEquipmentcheckmapData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(UlEquipmentcheckmapData.Lasttxntime);
	}

	public UlEquipmentcheckmapData setLasttxntime(Date Lasttxntime) {
		this.repository().set(UlEquipmentcheckmapData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(UlEquipmentcheckmapData.Lasttxncomment);
	}

	public UlEquipmentcheckmapData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(UlEquipmentcheckmapData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlEquipmentcheckmapData.Validstate);
	}

	public UlEquipmentcheckmapData setValidstate(String Validstate) {
		this.repository().set(UlEquipmentcheckmapData.Validstate, Validstate);
		return this;
	}


}