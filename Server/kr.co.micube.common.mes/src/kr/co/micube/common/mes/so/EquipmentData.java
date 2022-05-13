package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class EquipmentData extends SQLData {

	public static final String Serialno = "SERIALNO";

	public static final String Statemodelid = "STATEMODELID";

	public static final String State = "STATE";

	public static final String Parentequipmentid = "PARENTEQUIPMENTID";

	public static final String Plantid = "PLANTID";

	public static final String Recipeclassid = "RECIPECLASSID";

	public static final String Processedlotcount = "PROCESSEDLOTCOUNT";

	public static final String Processunit = "PROCESSUNIT";

	public static final String Validstate = "VALIDSTATE";

	public static final String Areaid = "AREAID";

	public static final String Mincapacity = "MINCAPACITY";

	public static final String Model = "MODEL";

	public static final String Vendor = "VENDOR";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Equipmentname = "EQUIPMENTNAME";

	public static final String Equipmenttype = "EQUIPMENTTYPE";

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Lasttxnid = "LASTTXNID";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Modifier = "MODIFIER";

	public static final String Operationmode = "OPERATIONMODE";

	public static final String Lastlotid = "LASTLOTID";

	public static final String Lastprocesssegmentid = "LASTPROCESSSEGMENTID";

	public static final String Lastprocesssegmentversion = "LASTPROCESSSEGMENTVERSION";

	public static final String Lastproductdefid = "LASTPRODUCTDEFID";

	public static final String Lastproductdefversion = "LASTPRODUCTDEFVERSION";

	public static final String Locationid = "LOCATIONID";

	public static final String Maxcapacity = "MAXCAPACITY";

	public static final String Equipmentclassid = "EQUIPMENTCLASSID";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Currentrecipedefid = "CURRENTRECIPEDEFID";

	public static final String Description = "DESCRIPTION";

	public static final String Detailequipmenttype = "DETAILEQUIPMENTTYPE";

	public static final String E10state = "E10STATE";

	public static final String Creator = "CREATOR";

	public static final String Currentrecipedefversion = "CURRENTRECIPEDEFVERSION";

	public static final String Controlmode = "CONTROLMODE";
	
	public static final String Equipmentnamekor = "EQUIPMENTNAMEKOR";
	
	public static final String Equipmentnameeng = "EQUIPMENTNAMEENG";
	
	public static final String Equipmentnamejpn = "EQUIPMENTNAMEJPN";
	
	public static final String Processdefid = "PROCESSDEFID";
	
	public static final String Assetno = "ASSETNO";
	
	public static final String Departmentid = "DEPARTMENTID";
	
	public static final String Ifstate = "IFSTATE";

	public EquipmentData() {
		this(new EquipmentKey()); 
	}

	public EquipmentData(EquipmentKey key) {
		super(key, "Equipment");
	}


	public String getSerialno() {
		return this.repository().getString(EquipmentData.Serialno);
	}

	public EquipmentData setSerialno(String Serialno) {
		this.repository().set(EquipmentData.Serialno, Serialno);
		return this;
	}

	public String getStatemodelid() {
		return this.repository().getString(EquipmentData.Statemodelid);
	}

	public EquipmentData setStatemodelid(String Statemodelid) {
		this.repository().set(EquipmentData.Statemodelid, Statemodelid);
		return this;
	}

	public String getState() {
		return this.repository().getString(EquipmentData.State);
	}

	public EquipmentData setState(String State) {
		this.repository().set(EquipmentData.State, State);
		return this;
	}

	public String getParentequipmentid() {
		return this.repository().getString(EquipmentData.Parentequipmentid);
	}

	public EquipmentData setParentequipmentid(String Parentequipmentid) {
		this.repository().set(EquipmentData.Parentequipmentid, Parentequipmentid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(EquipmentData.Plantid);
	}

	public EquipmentData setPlantid(String Plantid) {
		this.repository().set(EquipmentData.Plantid, Plantid);
		return this;
	}

	public String getRecipeclassid() {
		return this.repository().getString(EquipmentData.Recipeclassid);
	}

	public EquipmentData setRecipeclassid(String Recipeclassid) {
		this.repository().set(EquipmentData.Recipeclassid, Recipeclassid);
		return this;
	}

	public Double getProcessedlotcount() {
		return this.repository().getDouble(EquipmentData.Processedlotcount);
	}

	public EquipmentData setProcessedlotcount(Double Processedlotcount) {
		this.repository().set(EquipmentData.Processedlotcount, Processedlotcount);
		return this;
	}

	public String getProcessunit() {
		return this.repository().getString(EquipmentData.Processunit);
	}

	public EquipmentData setProcessunit(String Processunit) {
		this.repository().set(EquipmentData.Processunit, Processunit);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(EquipmentData.Validstate);
	}

	public EquipmentData setValidstate(String Validstate) {
		this.repository().set(EquipmentData.Validstate, Validstate);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(EquipmentData.Areaid);
	}

	public EquipmentData setAreaid(String Areaid) {
		this.repository().set(EquipmentData.Areaid, Areaid);
		return this;
	}

	public Double getMincapacity() {
		return this.repository().getDouble(EquipmentData.Mincapacity);
	}

	public EquipmentData setMincapacity(Double Mincapacity) {
		this.repository().set(EquipmentData.Mincapacity, Mincapacity);
		return this;
	}

	public String getModel() {
		return this.repository().getString(EquipmentData.Model);
	}

	public EquipmentData setModel(String Model) {
		this.repository().set(EquipmentData.Model, Model);
		return this;
	}

	public String getVendor() {
		return this.repository().getString(EquipmentData.Vendor);
	}

	public EquipmentData setVendor(String Vendor) {
		this.repository().set(EquipmentData.Vendor, Vendor);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(EquipmentData.Enterpriseid);
	}

	public EquipmentData setEnterpriseid(String Enterpriseid) {
		this.repository().set(EquipmentData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getEquipmentname() {
		return this.repository().getString(EquipmentData.Equipmentname);
	}

	public EquipmentData setEquipmentname(String Equipmentname) {
		this.repository().set(EquipmentData.Equipmentname, Equipmentname);
		return this;
	}

	public String getEquipmenttype() {
		return this.repository().getString(EquipmentData.Equipmenttype);
	}

	public EquipmentData setEquipmenttype(String Equipmenttype) {
		this.repository().set(EquipmentData.Equipmenttype, Equipmenttype);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(EquipmentData.Lasttxnhistkey);
	}

	public EquipmentData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(EquipmentData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(EquipmentData.Lasttxnid);
	}

	public EquipmentData setLasttxnid(String Lasttxnid) {
		this.repository().set(EquipmentData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(EquipmentData.Lasttxncomment);
	}

	public EquipmentData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(EquipmentData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(EquipmentData.Modifiedtime);
	}

	public EquipmentData setModifiedtime(Date Modifiedtime) {
		this.repository().set(EquipmentData.Modifiedtime, Modifiedtime);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(EquipmentData.Lasttxntime);
	}

	public EquipmentData setLasttxntime(Date Lasttxntime) {
		this.repository().set(EquipmentData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(EquipmentData.Lasttxnuser);
	}

	public EquipmentData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(EquipmentData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(EquipmentData.Modifier);
	}

	public EquipmentData setModifier(String Modifier) {
		this.repository().set(EquipmentData.Modifier, Modifier);
		return this;
	}

	public String getOperationmode() {
		return this.repository().getString(EquipmentData.Operationmode);
	}

	public EquipmentData setOperationmode(String Operationmode) {
		this.repository().set(EquipmentData.Operationmode, Operationmode);
		return this;
	}

	public String getLastlotid() {
		return this.repository().getString(EquipmentData.Lastlotid);
	}

	public EquipmentData setLastlotid(String Lastlotid) {
		this.repository().set(EquipmentData.Lastlotid, Lastlotid);
		return this;
	}

	public String getLastprocesssegmentid() {
		return this.repository().getString(EquipmentData.Lastprocesssegmentid);
	}

	public EquipmentData setLastprocesssegmentid(String Lastprocesssegmentid) {
		this.repository().set(EquipmentData.Lastprocesssegmentid, Lastprocesssegmentid);
		return this;
	}

	public String getLastprocesssegmentversion() {
		return this.repository().getString(EquipmentData.Lastprocesssegmentversion);
	}

	public EquipmentData setLastprocesssegmentversion(String Lastprocesssegmentversion) {
		this.repository().set(EquipmentData.Lastprocesssegmentversion, Lastprocesssegmentversion);
		return this;
	}

	public String getLastproductdefid() {
		return this.repository().getString(EquipmentData.Lastproductdefid);
	}

	public EquipmentData setLastproductdefid(String Lastproductdefid) {
		this.repository().set(EquipmentData.Lastproductdefid, Lastproductdefid);
		return this;
	}

	public String getLastproductdefversion() {
		return this.repository().getString(EquipmentData.Lastproductdefversion);
	}

	public EquipmentData setLastproductdefversion(String Lastproductdefversion) {
		this.repository().set(EquipmentData.Lastproductdefversion, Lastproductdefversion);
		return this;
	}

	public String getLocationid() {
		return this.repository().getString(EquipmentData.Locationid);
	}

	public EquipmentData setLocationid(String Locationid) {
		this.repository().set(EquipmentData.Locationid, Locationid);
		return this;
	}

	public Double getMaxcapacity() {
		return this.repository().getDouble(EquipmentData.Maxcapacity);
	}

	public EquipmentData setMaxcapacity(Double Maxcapacity) {
		this.repository().set(EquipmentData.Maxcapacity, Maxcapacity);
		return this;
	}

	public String getEquipmentclassid() {
		return this.repository().getString(EquipmentData.Equipmentclassid);
	}

	public EquipmentData setEquipmentclassid(String Equipmentclassid) {
		this.repository().set(EquipmentData.Equipmentclassid, Equipmentclassid);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(EquipmentData.Createdtime);
	}

	public EquipmentData setCreatedtime(Date Createdtime) {
		this.repository().set(EquipmentData.Createdtime, Createdtime);
		return this;
	}

	public String getCurrentrecipedefid() {
		return this.repository().getString(EquipmentData.Currentrecipedefid);
	}

	public EquipmentData setCurrentrecipedefid(String Currentrecipedefid) {
		this.repository().set(EquipmentData.Currentrecipedefid, Currentrecipedefid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(EquipmentData.Description);
	}

	public EquipmentData setDescription(String Description) {
		this.repository().set(EquipmentData.Description, Description);
		return this;
	}

	public String getDetailequipmenttype() {
		return this.repository().getString(EquipmentData.Detailequipmenttype);
	}

	public EquipmentData setDetailequipmenttype(String Detailequipmenttype) {
		this.repository().set(EquipmentData.Detailequipmenttype, Detailequipmenttype);
		return this;
	}

	public String getE10state() {
		return this.repository().getString(EquipmentData.E10state);
	}

	public EquipmentData setE10state(String E10state) {
		this.repository().set(EquipmentData.E10state, E10state);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(EquipmentData.Creator);
	}

	public EquipmentData setCreator(String Creator) {
		this.repository().set(EquipmentData.Creator, Creator);
		return this;
	}

	public String getCurrentrecipedefversion() {
		return this.repository().getString(EquipmentData.Currentrecipedefversion);
	}

	public EquipmentData setCurrentrecipedefversion(String Currentrecipedefversion) {
		this.repository().set(EquipmentData.Currentrecipedefversion, Currentrecipedefversion);
		return this;
	}

	public String getControlmode() {
		return this.repository().getString(EquipmentData.Controlmode);
	}

	public EquipmentData setControlmode(String Controlmode) {
		this.repository().set(EquipmentData.Controlmode, Controlmode);
		return this;
	}
	
	public String getEquipmentnamekor() {
		return this.repository().getString(EquipmentData.Equipmentnamekor);
	}

	public EquipmentData setEquipmentnamekor(String Equipmentnamekor) {
		this.repository().set(EquipmentData.Equipmentnamekor, Equipmentnamekor);
		return this;
	}
	
	public String getEquipmentnameeng() {
		return this.repository().getString(EquipmentData.Equipmentnameeng);
	}

	public EquipmentData setEquipmentnameeng(String Equipmentnameeng) {
		this.repository().set(EquipmentData.Equipmentnameeng, Equipmentnameeng);
		return this;
	}
	
	public String getEquipmentnamejpn() {
		return this.repository().getString(EquipmentData.Equipmentnamejpn);
	}

	public EquipmentData setEquipmentnamejpn(String Equipmentnamejpn) {
		this.repository().set(EquipmentData.Equipmentnamejpn, Equipmentnamejpn);
		return this;
	}
	
	public String getProcessdefid() {
		return this.repository().getString(EquipmentData.Processdefid);
	}

	public EquipmentData setProcessdefid(String Processdefid) {
		this.repository().set(EquipmentData.Processdefid, Processdefid);
		return this;
	}

	public String getAssetno() {
		return this.repository().getString(EquipmentData.Assetno);
	}

	public EquipmentData setAssetno(String Assetno) {
		this.repository().set(EquipmentData.Assetno, Assetno);
		return this;
	}
	
	public String getDepartmentid() {
		return this.repository().getString(EquipmentData.Departmentid);
	}

	public EquipmentData setDepartmentid(String Departmentid) {
		this.repository().set(EquipmentData.Departmentid, Departmentid);
		return this;
	}
	
	public String getIfstate() {
		return this.repository().getString(EquipmentData.Ifstate);
	}

	public EquipmentData setIfstate(String Ifstate) {
		this.repository().set(EquipmentData.Ifstate, Ifstate);
		return this;
	}
	
}