package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfAreaData extends SQLData {

	public static final String Areaid = "AREAID";

	public static final String Areaname = "AREANAME";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Areatype = "AREATYPE";

	public static final String Parentareaid = "PARENTAREAID";

	public static final String Warehouseid = "WAREHOUSEID";

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

	public SfAreaData() {
		this(new SfAreaKey()); 
	}

	public SfAreaData(SfAreaKey key) {
		super(key, "SfArea");
	}


	public String getAreaname() {
		return this.repository().getString(SfAreaData.Areaname);
	}

	public SfAreaData setAreaname(String Areaname) {
		this.repository().set(SfAreaData.Areaname, Areaname);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfAreaData.Enterpriseid);
	}

	public SfAreaData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfAreaData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfAreaData.Plantid);
	}

	public SfAreaData setPlantid(String Plantid) {
		this.repository().set(SfAreaData.Plantid, Plantid);
		return this;
	}

	public String getAreatype() {
		return this.repository().getString(SfAreaData.Areatype);
	}

	public SfAreaData setAreatype(String Areatype) {
		this.repository().set(SfAreaData.Areatype, Areatype);
		return this;
	}

	public String getParentareaid() {
		return this.repository().getString(SfAreaData.Parentareaid);
	}

	public SfAreaData setParentareaid(String Parentareaid) {
		this.repository().set(SfAreaData.Parentareaid, Parentareaid);
		return this;
	}

	public String getWarehouseid() {
		return this.repository().getString(SfAreaData.Warehouseid);
	}

	public SfAreaData setWarehouseid(String Warehouseid) {
		this.repository().set(SfAreaData.Warehouseid, Warehouseid);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfAreaData.Dictionaryid);
	}

	public SfAreaData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfAreaData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfAreaData.Description);
	}

	public SfAreaData setDescription(String Description) {
		this.repository().set(SfAreaData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfAreaData.Creator);
	}

	public SfAreaData setCreator(String Creator) {
		this.repository().set(SfAreaData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfAreaData.Createdtime);
	}

	public SfAreaData setCreatedtime(Date Createdtime) {
		this.repository().set(SfAreaData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfAreaData.Modifier);
	}

	public SfAreaData setModifier(String Modifier) {
		this.repository().set(SfAreaData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfAreaData.Modifiedtime);
	}

	public SfAreaData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfAreaData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfAreaData.Lasttxnhistkey);
	}

	public SfAreaData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfAreaData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfAreaData.Lasttxnid);
	}

	public SfAreaData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfAreaData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfAreaData.Lasttxnuser);
	}

	public SfAreaData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfAreaData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfAreaData.Lasttxntime);
	}

	public SfAreaData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfAreaData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfAreaData.Lasttxncomment);
	}

	public SfAreaData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfAreaData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfAreaData.Validstate);
	}

	public SfAreaData setValidstate(String Validstate) {
		this.repository().set(SfAreaData.Validstate, Validstate);
		return this;
	}


}