package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfEquipmentData extends SQLData {

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Equipmentclassid = "EQUIPMENTCLASSID";

	public static final String Equipmentname = "EQUIPMENTNAME";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Areaid = "AREAID";

	public static final String Locationid = "LOCATIONID";

	public static final String Equipmenttype = "EQUIPMENTTYPE";

	public static final String Detailequipmenttype = "DETAILEQUIPMENTTYPE";

	public static final String Parentequipmentid = "PARENTEQUIPMENTID";

	public static final String Recipeclassid = "RECIPECLASSID";

	public static final String Statemodelid = "STATEMODELID";

	public static final String Vendor = "VENDOR";

	public static final String Model = "MODEL";

	public static final String Serialno = "SERIALNO";

	public static final String Processunit = "PROCESSUNIT";

	public static final String Mincapacity = "MINCAPACITY";

	public static final String Maxcapacity = "MAXCAPACITY";

	public static final String State = "STATE";

	public static final String E10state = "E10STATE";

	public static final String Controlmode = "CONTROLMODE";

	public static final String Operationmode = "OPERATIONMODE";

	public static final String Currentrecipedefid = "CURRENTRECIPEDEFID";

	public static final String Currentrecipedefversion = "CURRENTRECIPEDEFVERSION";

	public static final String Processedlotcount = "PROCESSEDLOTCOUNT";

	public static final String Lastlotid = "LASTLOTID";

	public static final String Lastproductdefid = "LASTPRODUCTDEFID";

	public static final String Lastproductdefversion = "LASTPRODUCTDEFVERSION";

	public static final String Lastprocesssegmentid = "LASTPROCESSSEGMENTID";

	public static final String Lastprocesssegmentversion = "LASTPROCESSSEGMENTVERSION";

	public static final String Dictionaryid = "DICTIONARYID";

	public static final String Processdefid = "PROCESSDEFID";

	public static final String Assetno = "ASSETNO";

	public static final String Department = "DEPARTMENT";

	public static final String Ifstate = "IFSTATE";
	
	public static final String Isdailycheck = "ISDAILYCHECK";

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

	public SfEquipmentData() {
		this(new SfEquipmentKey()); 
	}

	public SfEquipmentData(SfEquipmentKey key) {
		super(key, "SfEquipment");
	}


	public String getEquipmentclassid() {
		return this.repository().getString(SfEquipmentData.Equipmentclassid);
	}

	public SfEquipmentData setEquipmentclassid(String Equipmentclassid) {
		this.repository().set(SfEquipmentData.Equipmentclassid, Equipmentclassid);
		return this;
	}

	public String getEquipmentname() {
		return this.repository().getString(SfEquipmentData.Equipmentname);
	}

	public SfEquipmentData setEquipmentname(String Equipmentname) {
		this.repository().set(SfEquipmentData.Equipmentname, Equipmentname);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfEquipmentData.Enterpriseid);
	}

	public SfEquipmentData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfEquipmentData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfEquipmentData.Plantid);
	}

	public SfEquipmentData setPlantid(String Plantid) {
		this.repository().set(SfEquipmentData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfEquipmentData.Areaid);
	}

	public SfEquipmentData setAreaid(String Areaid) {
		this.repository().set(SfEquipmentData.Areaid, Areaid);
		return this;
	}

	public String getLocationid() {
		return this.repository().getString(SfEquipmentData.Locationid);
	}

	public SfEquipmentData setLocationid(String Locationid) {
		this.repository().set(SfEquipmentData.Locationid, Locationid);
		return this;
	}

	public String getEquipmenttype() {
		return this.repository().getString(SfEquipmentData.Equipmenttype);
	}

	public SfEquipmentData setEquipmenttype(String Equipmenttype) {
		this.repository().set(SfEquipmentData.Equipmenttype, Equipmenttype);
		return this;
	}

	public String getDetailequipmenttype() {
		return this.repository().getString(SfEquipmentData.Detailequipmenttype);
	}

	public SfEquipmentData setDetailequipmenttype(String Detailequipmenttype) {
		this.repository().set(SfEquipmentData.Detailequipmenttype, Detailequipmenttype);
		return this;
	}

	public String getParentequipmentid() {
		return this.repository().getString(SfEquipmentData.Parentequipmentid);
	}

	public SfEquipmentData setParentequipmentid(String Parentequipmentid) {
		this.repository().set(SfEquipmentData.Parentequipmentid, Parentequipmentid);
		return this;
	}

	public String getRecipeclassid() {
		return this.repository().getString(SfEquipmentData.Recipeclassid);
	}

	public SfEquipmentData setRecipeclassid(String Recipeclassid) {
		this.repository().set(SfEquipmentData.Recipeclassid, Recipeclassid);
		return this;
	}

	public String getStatemodelid() {
		return this.repository().getString(SfEquipmentData.Statemodelid);
	}

	public SfEquipmentData setStatemodelid(String Statemodelid) {
		this.repository().set(SfEquipmentData.Statemodelid, Statemodelid);
		return this;
	}

	public String getVendor() {
		return this.repository().getString(SfEquipmentData.Vendor);
	}

	public SfEquipmentData setVendor(String Vendor) {
		this.repository().set(SfEquipmentData.Vendor, Vendor);
		return this;
	}

	public String getModel() {
		return this.repository().getString(SfEquipmentData.Model);
	}

	public SfEquipmentData setModel(String Model) {
		this.repository().set(SfEquipmentData.Model, Model);
		return this;
	}

	public String getSerialno() {
		return this.repository().getString(SfEquipmentData.Serialno);
	}

	public SfEquipmentData setSerialno(String Serialno) {
		this.repository().set(SfEquipmentData.Serialno, Serialno);
		return this;
	}

	public String getProcessunit() {
		return this.repository().getString(SfEquipmentData.Processunit);
	}

	public SfEquipmentData setProcessunit(String Processunit) {
		this.repository().set(SfEquipmentData.Processunit, Processunit);
		return this;
	}

	public Double getMincapacity() {
		return this.repository().getDouble(SfEquipmentData.Mincapacity);
	}

	public SfEquipmentData setMincapacity(Double Mincapacity) {
		this.repository().set(SfEquipmentData.Mincapacity, Mincapacity);
		return this;
	}

	public Double getMaxcapacity() {
		return this.repository().getDouble(SfEquipmentData.Maxcapacity);
	}

	public SfEquipmentData setMaxcapacity(Double Maxcapacity) {
		this.repository().set(SfEquipmentData.Maxcapacity, Maxcapacity);
		return this;
	}

	public String getState() {
		return this.repository().getString(SfEquipmentData.State);
	}

	public SfEquipmentData setState(String State) {
		this.repository().set(SfEquipmentData.State, State);
		return this;
	}

	public String getE10state() {
		return this.repository().getString(SfEquipmentData.E10state);
	}

	public SfEquipmentData setE10state(String E10state) {
		this.repository().set(SfEquipmentData.E10state, E10state);
		return this;
	}

	public String getControlmode() {
		return this.repository().getString(SfEquipmentData.Controlmode);
	}

	public SfEquipmentData setControlmode(String Controlmode) {
		this.repository().set(SfEquipmentData.Controlmode, Controlmode);
		return this;
	}

	public String getOperationmode() {
		return this.repository().getString(SfEquipmentData.Operationmode);
	}

	public SfEquipmentData setOperationmode(String Operationmode) {
		this.repository().set(SfEquipmentData.Operationmode, Operationmode);
		return this;
	}

	public String getCurrentrecipedefid() {
		return this.repository().getString(SfEquipmentData.Currentrecipedefid);
	}

	public SfEquipmentData setCurrentrecipedefid(String Currentrecipedefid) {
		this.repository().set(SfEquipmentData.Currentrecipedefid, Currentrecipedefid);
		return this;
	}

	public String getCurrentrecipedefversion() {
		return this.repository().getString(SfEquipmentData.Currentrecipedefversion);
	}

	public SfEquipmentData setCurrentrecipedefversion(String Currentrecipedefversion) {
		this.repository().set(SfEquipmentData.Currentrecipedefversion, Currentrecipedefversion);
		return this;
	}

	public Double getProcessedlotcount() {
		return this.repository().getDouble(SfEquipmentData.Processedlotcount);
	}

	public SfEquipmentData setProcessedlotcount(Double Processedlotcount) {
		this.repository().set(SfEquipmentData.Processedlotcount, Processedlotcount);
		return this;
	}

	public String getLastlotid() {
		return this.repository().getString(SfEquipmentData.Lastlotid);
	}

	public SfEquipmentData setLastlotid(String Lastlotid) {
		this.repository().set(SfEquipmentData.Lastlotid, Lastlotid);
		return this;
	}

	public String getLastproductdefid() {
		return this.repository().getString(SfEquipmentData.Lastproductdefid);
	}

	public SfEquipmentData setLastproductdefid(String Lastproductdefid) {
		this.repository().set(SfEquipmentData.Lastproductdefid, Lastproductdefid);
		return this;
	}

	public String getLastproductdefversion() {
		return this.repository().getString(SfEquipmentData.Lastproductdefversion);
	}

	public SfEquipmentData setLastproductdefversion(String Lastproductdefversion) {
		this.repository().set(SfEquipmentData.Lastproductdefversion, Lastproductdefversion);
		return this;
	}

	public String getLastprocesssegmentid() {
		return this.repository().getString(SfEquipmentData.Lastprocesssegmentid);
	}

	public SfEquipmentData setLastprocesssegmentid(String Lastprocesssegmentid) {
		this.repository().set(SfEquipmentData.Lastprocesssegmentid, Lastprocesssegmentid);
		return this;
	}

	public String getLastprocesssegmentversion() {
		return this.repository().getString(SfEquipmentData.Lastprocesssegmentversion);
	}

	public SfEquipmentData setLastprocesssegmentversion(String Lastprocesssegmentversion) {
		this.repository().set(SfEquipmentData.Lastprocesssegmentversion, Lastprocesssegmentversion);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfEquipmentData.Dictionaryid);
	}

	public SfEquipmentData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfEquipmentData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getProcessdefid() {
		return this.repository().getString(SfEquipmentData.Processdefid);
	}

	public SfEquipmentData setProcessdefid(String Processdefid) {
		this.repository().set(SfEquipmentData.Processdefid, Processdefid);
		return this;
	}

	public String getAssetno() {
		return this.repository().getString(SfEquipmentData.Assetno);
	}

	public SfEquipmentData setAssetno(String Assetno) {
		this.repository().set(SfEquipmentData.Assetno, Assetno);
		return this;
	}

	public String getDepartment() {
		return this.repository().getString(SfEquipmentData.Department);
	}

	public SfEquipmentData setDepartment(String Department) {
		this.repository().set(SfEquipmentData.Department, Department);
		return this;
	}

	public String getIfstate() {
		return this.repository().getString(SfEquipmentData.Ifstate);
	}

	public SfEquipmentData setIfstate(String Ifstate) {
		this.repository().set(SfEquipmentData.Ifstate, Ifstate);
		return this;
	}

	public String getIsdailycheck() {
		return this.repository().getString(SfEquipmentData.Isdailycheck);
	}

	public SfEquipmentData setIsdailycheck(String Isdailycheck) {
		this.repository().set(SfEquipmentData.Isdailycheck, Isdailycheck);
		return this;
	}
	
	public String getDescription() {
		return this.repository().getString(SfEquipmentData.Description);
	}

	public SfEquipmentData setDescription(String Description) {
		this.repository().set(SfEquipmentData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfEquipmentData.Creator);
	}

	public SfEquipmentData setCreator(String Creator) {
		this.repository().set(SfEquipmentData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfEquipmentData.Createdtime);
	}

	public SfEquipmentData setCreatedtime(Date Createdtime) {
		this.repository().set(SfEquipmentData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfEquipmentData.Modifier);
	}

	public SfEquipmentData setModifier(String Modifier) {
		this.repository().set(SfEquipmentData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfEquipmentData.Modifiedtime);
	}

	public SfEquipmentData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfEquipmentData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfEquipmentData.Lasttxnhistkey);
	}

	public SfEquipmentData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfEquipmentData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfEquipmentData.Lasttxnid);
	}

	public SfEquipmentData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfEquipmentData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfEquipmentData.Lasttxnuser);
	}

	public SfEquipmentData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfEquipmentData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfEquipmentData.Lasttxntime);
	}

	public SfEquipmentData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfEquipmentData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfEquipmentData.Lasttxncomment);
	}

	public SfEquipmentData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfEquipmentData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfEquipmentData.Validstate);
	}

	public SfEquipmentData setValidstate(String Validstate) {
		this.repository().set(SfEquipmentData.Validstate, Validstate);
		return this;
	}


}