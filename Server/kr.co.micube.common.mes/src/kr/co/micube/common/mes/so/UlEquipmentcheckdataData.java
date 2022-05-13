package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlEquipmentcheckdataData extends SQLData {

	public static final String Checkdate = "CHECKDATE";

	public static final String Equipcheckid = "EQUIPCHECKID";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Resulttype01 = "RESULTTYPE01";

	public static final String Resulttype02 = "RESULTTYPE02";

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

	public UlEquipmentcheckdataData() {
		this(new UlEquipmentcheckdataKey()); 
	}

	public UlEquipmentcheckdataData(UlEquipmentcheckdataKey key) {
		super(key, "UlEquipmentcheckdata");
	}


	public String getResulttype01() {
		return this.repository().getString(UlEquipmentcheckdataData.Resulttype01);
	}

	public UlEquipmentcheckdataData setResulttype01(String Resulttype01) {
		this.repository().set(UlEquipmentcheckdataData.Resulttype01, Resulttype01);
		return this;
	}

	public Double getResulttype02() {
		return this.repository().getDouble(UlEquipmentcheckdataData.Resulttype02);
	}

	public UlEquipmentcheckdataData setResulttype02(Double Resulttype02) {
		this.repository().set(UlEquipmentcheckdataData.Resulttype02, Resulttype02);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlEquipmentcheckdataData.Description);
	}

	public UlEquipmentcheckdataData setDescription(String Description) {
		this.repository().set(UlEquipmentcheckdataData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlEquipmentcheckdataData.Creator);
	}

	public UlEquipmentcheckdataData setCreator(String Creator) {
		this.repository().set(UlEquipmentcheckdataData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlEquipmentcheckdataData.Createdtime);
	}

	public UlEquipmentcheckdataData setCreatedtime(Date Createdtime) {
		this.repository().set(UlEquipmentcheckdataData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlEquipmentcheckdataData.Modifier);
	}

	public UlEquipmentcheckdataData setModifier(String Modifier) {
		this.repository().set(UlEquipmentcheckdataData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlEquipmentcheckdataData.Modifiedtime);
	}

	public UlEquipmentcheckdataData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlEquipmentcheckdataData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(UlEquipmentcheckdataData.Lasttxnhistkey);
	}

	public UlEquipmentcheckdataData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(UlEquipmentcheckdataData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(UlEquipmentcheckdataData.Lasttxnid);
	}

	public UlEquipmentcheckdataData setLasttxnid(String Lasttxnid) {
		this.repository().set(UlEquipmentcheckdataData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(UlEquipmentcheckdataData.Lasttxnuser);
	}

	public UlEquipmentcheckdataData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(UlEquipmentcheckdataData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(UlEquipmentcheckdataData.Lasttxntime);
	}

	public UlEquipmentcheckdataData setLasttxntime(Date Lasttxntime) {
		this.repository().set(UlEquipmentcheckdataData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(UlEquipmentcheckdataData.Lasttxncomment);
	}

	public UlEquipmentcheckdataData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(UlEquipmentcheckdataData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlEquipmentcheckdataData.Validstate);
	}

	public UlEquipmentcheckdataData setValidstate(String Validstate) {
		this.repository().set(UlEquipmentcheckdataData.Validstate, Validstate);
		return this;
	}


}