package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlEquipmentcheckdatadetailData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Occurdate = "OCCURDATE";

	public static final String Occurdescription = "OCCURDESCRIPTION";

	public static final String Actiondate = "ACTIONDATE";

	public static final String Actiondescription = "ACTIONDESCRIPTION";

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

	public UlEquipmentcheckdatadetailData() {
		this(new UlEquipmentcheckdatadetailKey()); 
	}

	public UlEquipmentcheckdatadetailData(UlEquipmentcheckdatadetailKey key) {
		super(key, "UlEquipmentcheckdatadetail");
	}


	public String getEquipmentid() {
		return this.repository().getString(UlEquipmentcheckdatadetailData.Equipmentid);
	}

	public UlEquipmentcheckdatadetailData setEquipmentid(String Equipmentid) {
		this.repository().set(UlEquipmentcheckdatadetailData.Equipmentid, Equipmentid);
		return this;
	}

	public Date getOccurdate() {
		return this.repository().getDate(UlEquipmentcheckdatadetailData.Occurdate);
	}

	public UlEquipmentcheckdatadetailData setOccurdate(Date Occurdate) {
		this.repository().set(UlEquipmentcheckdatadetailData.Occurdate, Occurdate);
		return this;
	}

	public String getOccurdescription() {
		return this.repository().getString(UlEquipmentcheckdatadetailData.Occurdescription);
	}

	public UlEquipmentcheckdatadetailData setOccurdescription(String Occurdescription) {
		this.repository().set(UlEquipmentcheckdatadetailData.Occurdescription, Occurdescription);
		return this;
	}

	public Date getActiondate() {
		return this.repository().getDate(UlEquipmentcheckdatadetailData.Actiondate);
	}

	public UlEquipmentcheckdatadetailData setActiondate(Date Actiondate) {
		this.repository().set(UlEquipmentcheckdatadetailData.Actiondate, Actiondate);
		return this;
	}

	public String getActiondescription() {
		return this.repository().getString(UlEquipmentcheckdatadetailData.Actiondescription);
	}

	public UlEquipmentcheckdatadetailData setActiondescription(String Actiondescription) {
		this.repository().set(UlEquipmentcheckdatadetailData.Actiondescription, Actiondescription);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlEquipmentcheckdatadetailData.Description);
	}

	public UlEquipmentcheckdatadetailData setDescription(String Description) {
		this.repository().set(UlEquipmentcheckdatadetailData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlEquipmentcheckdatadetailData.Creator);
	}

	public UlEquipmentcheckdatadetailData setCreator(String Creator) {
		this.repository().set(UlEquipmentcheckdatadetailData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlEquipmentcheckdatadetailData.Createdtime);
	}

	public UlEquipmentcheckdatadetailData setCreatedtime(Date Createdtime) {
		this.repository().set(UlEquipmentcheckdatadetailData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlEquipmentcheckdatadetailData.Modifier);
	}

	public UlEquipmentcheckdatadetailData setModifier(String Modifier) {
		this.repository().set(UlEquipmentcheckdatadetailData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlEquipmentcheckdatadetailData.Modifiedtime);
	}

	public UlEquipmentcheckdatadetailData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlEquipmentcheckdatadetailData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(UlEquipmentcheckdatadetailData.Lasttxnhistkey);
	}

	public UlEquipmentcheckdatadetailData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(UlEquipmentcheckdatadetailData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(UlEquipmentcheckdatadetailData.Lasttxnid);
	}

	public UlEquipmentcheckdatadetailData setLasttxnid(String Lasttxnid) {
		this.repository().set(UlEquipmentcheckdatadetailData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(UlEquipmentcheckdatadetailData.Lasttxnuser);
	}

	public UlEquipmentcheckdatadetailData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(UlEquipmentcheckdatadetailData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(UlEquipmentcheckdatadetailData.Lasttxntime);
	}

	public UlEquipmentcheckdatadetailData setLasttxntime(Date Lasttxntime) {
		this.repository().set(UlEquipmentcheckdatadetailData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(UlEquipmentcheckdatadetailData.Lasttxncomment);
	}

	public UlEquipmentcheckdatadetailData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(UlEquipmentcheckdatadetailData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlEquipmentcheckdatadetailData.Validstate);
	}

	public UlEquipmentcheckdatadetailData setValidstate(String Validstate) {
		this.repository().set(UlEquipmentcheckdatadetailData.Validstate, Validstate);
		return this;
	}


}