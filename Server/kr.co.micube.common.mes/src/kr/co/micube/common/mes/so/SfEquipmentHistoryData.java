package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfEquipmentHistoryData extends SQLData {

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Txnhistkey = "TXNHISTKEY";

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

	public static final String Description = "DESCRIPTION";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Modifier = "MODIFIER";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public SfEquipmentHistoryData() {
		this(new SfEquipmentHistoryKey()); 
	}

	public SfEquipmentHistoryData(SfEquipmentHistoryKey key) {
		super(key, "SfEquipmentHistory");
	}


	public String getEquipmentclassid() {
		return this.repository().getString(SfEquipmentHistoryData.Equipmentclassid);
	}

	public SfEquipmentHistoryData setEquipmentclassid(String Equipmentclassid) {
		this.repository().set(SfEquipmentHistoryData.Equipmentclassid, Equipmentclassid);
		return this;
	}

	public String getEquipmentname() {
		return this.repository().getString(SfEquipmentHistoryData.Equipmentname);
	}

	public SfEquipmentHistoryData setEquipmentname(String Equipmentname) {
		this.repository().set(SfEquipmentHistoryData.Equipmentname, Equipmentname);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfEquipmentHistoryData.Enterpriseid);
	}

	public SfEquipmentHistoryData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfEquipmentHistoryData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfEquipmentHistoryData.Plantid);
	}

	public SfEquipmentHistoryData setPlantid(String Plantid) {
		this.repository().set(SfEquipmentHistoryData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfEquipmentHistoryData.Areaid);
	}

	public SfEquipmentHistoryData setAreaid(String Areaid) {
		this.repository().set(SfEquipmentHistoryData.Areaid, Areaid);
		return this;
	}

	public String getLocationid() {
		return this.repository().getString(SfEquipmentHistoryData.Locationid);
	}

	public SfEquipmentHistoryData setLocationid(String Locationid) {
		this.repository().set(SfEquipmentHistoryData.Locationid, Locationid);
		return this;
	}

	public String getEquipmenttype() {
		return this.repository().getString(SfEquipmentHistoryData.Equipmenttype);
	}

	public SfEquipmentHistoryData setEquipmenttype(String Equipmenttype) {
		this.repository().set(SfEquipmentHistoryData.Equipmenttype, Equipmenttype);
		return this;
	}

	public String getDetailequipmenttype() {
		return this.repository().getString(SfEquipmentHistoryData.Detailequipmenttype);
	}

	public SfEquipmentHistoryData setDetailequipmenttype(String Detailequipmenttype) {
		this.repository().set(SfEquipmentHistoryData.Detailequipmenttype, Detailequipmenttype);
		return this;
	}

	public String getParentequipmentid() {
		return this.repository().getString(SfEquipmentHistoryData.Parentequipmentid);
	}

	public SfEquipmentHistoryData setParentequipmentid(String Parentequipmentid) {
		this.repository().set(SfEquipmentHistoryData.Parentequipmentid, Parentequipmentid);
		return this;
	}

	public String getRecipeclassid() {
		return this.repository().getString(SfEquipmentHistoryData.Recipeclassid);
	}

	public SfEquipmentHistoryData setRecipeclassid(String Recipeclassid) {
		this.repository().set(SfEquipmentHistoryData.Recipeclassid, Recipeclassid);
		return this;
	}

	public String getStatemodelid() {
		return this.repository().getString(SfEquipmentHistoryData.Statemodelid);
	}

	public SfEquipmentHistoryData setStatemodelid(String Statemodelid) {
		this.repository().set(SfEquipmentHistoryData.Statemodelid, Statemodelid);
		return this;
	}

	public String getVendor() {
		return this.repository().getString(SfEquipmentHistoryData.Vendor);
	}

	public SfEquipmentHistoryData setVendor(String Vendor) {
		this.repository().set(SfEquipmentHistoryData.Vendor, Vendor);
		return this;
	}

	public String getModel() {
		return this.repository().getString(SfEquipmentHistoryData.Model);
	}

	public SfEquipmentHistoryData setModel(String Model) {
		this.repository().set(SfEquipmentHistoryData.Model, Model);
		return this;
	}

	public String getSerialno() {
		return this.repository().getString(SfEquipmentHistoryData.Serialno);
	}

	public SfEquipmentHistoryData setSerialno(String Serialno) {
		this.repository().set(SfEquipmentHistoryData.Serialno, Serialno);
		return this;
	}

	public String getProcessunit() {
		return this.repository().getString(SfEquipmentHistoryData.Processunit);
	}

	public SfEquipmentHistoryData setProcessunit(String Processunit) {
		this.repository().set(SfEquipmentHistoryData.Processunit, Processunit);
		return this;
	}

	public Double getMincapacity() {
		return this.repository().getDouble(SfEquipmentHistoryData.Mincapacity);
	}

	public SfEquipmentHistoryData setMincapacity(Double Mincapacity) {
		this.repository().set(SfEquipmentHistoryData.Mincapacity, Mincapacity);
		return this;
	}

	public Double getMaxcapacity() {
		return this.repository().getDouble(SfEquipmentHistoryData.Maxcapacity);
	}

	public SfEquipmentHistoryData setMaxcapacity(Double Maxcapacity) {
		this.repository().set(SfEquipmentHistoryData.Maxcapacity, Maxcapacity);
		return this;
	}

	public String getState() {
		return this.repository().getString(SfEquipmentHistoryData.State);
	}

	public SfEquipmentHistoryData setState(String State) {
		this.repository().set(SfEquipmentHistoryData.State, State);
		return this;
	}

	public String getE10state() {
		return this.repository().getString(SfEquipmentHistoryData.E10state);
	}

	public SfEquipmentHistoryData setE10state(String E10state) {
		this.repository().set(SfEquipmentHistoryData.E10state, E10state);
		return this;
	}

	public String getControlmode() {
		return this.repository().getString(SfEquipmentHistoryData.Controlmode);
	}

	public SfEquipmentHistoryData setControlmode(String Controlmode) {
		this.repository().set(SfEquipmentHistoryData.Controlmode, Controlmode);
		return this;
	}

	public String getOperationmode() {
		return this.repository().getString(SfEquipmentHistoryData.Operationmode);
	}

	public SfEquipmentHistoryData setOperationmode(String Operationmode) {
		this.repository().set(SfEquipmentHistoryData.Operationmode, Operationmode);
		return this;
	}

	public String getCurrentrecipedefid() {
		return this.repository().getString(SfEquipmentHistoryData.Currentrecipedefid);
	}

	public SfEquipmentHistoryData setCurrentrecipedefid(String Currentrecipedefid) {
		this.repository().set(SfEquipmentHistoryData.Currentrecipedefid, Currentrecipedefid);
		return this;
	}

	public String getCurrentrecipedefversion() {
		return this.repository().getString(SfEquipmentHistoryData.Currentrecipedefversion);
	}

	public SfEquipmentHistoryData setCurrentrecipedefversion(String Currentrecipedefversion) {
		this.repository().set(SfEquipmentHistoryData.Currentrecipedefversion, Currentrecipedefversion);
		return this;
	}

	public Double getProcessedlotcount() {
		return this.repository().getDouble(SfEquipmentHistoryData.Processedlotcount);
	}

	public SfEquipmentHistoryData setProcessedlotcount(Double Processedlotcount) {
		this.repository().set(SfEquipmentHistoryData.Processedlotcount, Processedlotcount);
		return this;
	}

	public String getLastlotid() {
		return this.repository().getString(SfEquipmentHistoryData.Lastlotid);
	}

	public SfEquipmentHistoryData setLastlotid(String Lastlotid) {
		this.repository().set(SfEquipmentHistoryData.Lastlotid, Lastlotid);
		return this;
	}

	public String getLastproductdefid() {
		return this.repository().getString(SfEquipmentHistoryData.Lastproductdefid);
	}

	public SfEquipmentHistoryData setLastproductdefid(String Lastproductdefid) {
		this.repository().set(SfEquipmentHistoryData.Lastproductdefid, Lastproductdefid);
		return this;
	}

	public String getLastproductdefversion() {
		return this.repository().getString(SfEquipmentHistoryData.Lastproductdefversion);
	}

	public SfEquipmentHistoryData setLastproductdefversion(String Lastproductdefversion) {
		this.repository().set(SfEquipmentHistoryData.Lastproductdefversion, Lastproductdefversion);
		return this;
	}

	public String getLastprocesssegmentid() {
		return this.repository().getString(SfEquipmentHistoryData.Lastprocesssegmentid);
	}

	public SfEquipmentHistoryData setLastprocesssegmentid(String Lastprocesssegmentid) {
		this.repository().set(SfEquipmentHistoryData.Lastprocesssegmentid, Lastprocesssegmentid);
		return this;
	}

	public String getLastprocesssegmentversion() {
		return this.repository().getString(SfEquipmentHistoryData.Lastprocesssegmentversion);
	}

	public SfEquipmentHistoryData setLastprocesssegmentversion(String Lastprocesssegmentversion) {
		this.repository().set(SfEquipmentHistoryData.Lastprocesssegmentversion, Lastprocesssegmentversion);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfEquipmentHistoryData.Dictionaryid);
	}

	public SfEquipmentHistoryData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfEquipmentHistoryData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getProcessdefid() {
		return this.repository().getString(SfEquipmentHistoryData.Processdefid);
	}

	public SfEquipmentHistoryData setProcessdefid(String Processdefid) {
		this.repository().set(SfEquipmentHistoryData.Processdefid, Processdefid);
		return this;
	}

	public String getAssetno() {
		return this.repository().getString(SfEquipmentHistoryData.Assetno);
	}

	public SfEquipmentHistoryData setAssetno(String Assetno) {
		this.repository().set(SfEquipmentHistoryData.Assetno, Assetno);
		return this;
	}

	public String getDepartment() {
		return this.repository().getString(SfEquipmentHistoryData.Department);
	}

	public SfEquipmentHistoryData setDepartment(String Department) {
		this.repository().set(SfEquipmentHistoryData.Department, Department);
		return this;
	}

	public String getIfstate() {
		return this.repository().getString(SfEquipmentHistoryData.Ifstate);
	}

	public SfEquipmentHistoryData setIfstate(String Ifstate) {
		this.repository().set(SfEquipmentHistoryData.Ifstate, Ifstate);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfEquipmentHistoryData.Description);
	}

	public SfEquipmentHistoryData setDescription(String Description) {
		this.repository().set(SfEquipmentHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfEquipmentHistoryData.Creator);
	}

	public SfEquipmentHistoryData setCreator(String Creator) {
		this.repository().set(SfEquipmentHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfEquipmentHistoryData.Createdtime);
	}

	public SfEquipmentHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(SfEquipmentHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfEquipmentHistoryData.Modifier);
	}

	public SfEquipmentHistoryData setModifier(String Modifier) {
		this.repository().set(SfEquipmentHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfEquipmentHistoryData.Modifiedtime);
	}

	public SfEquipmentHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfEquipmentHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(SfEquipmentHistoryData.Txnid);
	}

	public SfEquipmentHistoryData setTxnid(String Txnid) {
		this.repository().set(SfEquipmentHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfEquipmentHistoryData.Txnuser);
	}

	public SfEquipmentHistoryData setTxnuser(String Txnuser) {
		this.repository().set(SfEquipmentHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfEquipmentHistoryData.Txntime);
	}

	public SfEquipmentHistoryData setTxntime(Date Txntime) {
		this.repository().set(SfEquipmentHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfEquipmentHistoryData.Txngrouphistkey);
	}

	public SfEquipmentHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfEquipmentHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfEquipmentHistoryData.Txnreasoncodeclass);
	}

	public SfEquipmentHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfEquipmentHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfEquipmentHistoryData.Txnreasoncode);
	}

	public SfEquipmentHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfEquipmentHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfEquipmentHistoryData.Txncomment);
	}

	public SfEquipmentHistoryData setTxncomment(String Txncomment) {
		this.repository().set(SfEquipmentHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfEquipmentHistoryData.Validstate);
	}

	public SfEquipmentHistoryData setValidstate(String Validstate) {
		this.repository().set(SfEquipmentHistoryData.Validstate, Validstate);
		return this;
	}


}