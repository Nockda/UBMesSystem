package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfProductdefinitionData extends SQLData {

	public static final String Productdefid = "PRODUCTDEFID";

	public static final String Productdefversion = "PRODUCTDEFVERSION";

	public static final String Productdefname = "PRODUCTDEFNAME";

	public static final String Productclassid = "PRODUCTCLASSID";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Areaid = "AREAID";

	public static final String Productdeftype = "PRODUCTDEFTYPE";

	public static final String Unit = "UNIT";

	public static final String Defaultqty = "DEFAULTQTY";

	public static final String Hassublot = "HASSUBLOT";

	public static final String Owner = "OWNER";

	public static final String Leadtime = "LEADTIME";

	public static final String Lotsize = "LOTSIZE";

	public static final String Teamid = "TEAMID";

	public static final String Modelid = "MODELID";

	public static final String Processdefid = "PROCESSDEFID";

	public static final String Processdefversion = "PROCESSDEFVERSION";

	public static final String Standard = "STANDARD";

	public static final String Standardtime = "STANDARDTIME";

	public static final String Itemclasslseq = "ITEMCLASSLSEQ";

	public static final String Itemclassmseq = "ITEMCLASSMSEQ";

	public static final String Specdefid = "SPECDEFID";

	public static final String Importinspfileid = "IMPORTINSPFILEID";

	public static final String Exportinspfileid = "EXPORTINSPFILEID";

	public static final String Dictionaryid = "DICTIONARYID";

	public static final String Erp_unitid = "ERP_UNITID";

	public static final String Erp_productdefid = "ERP_PRODUCTDEFID";

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

	public static final String Versionstate = "VERSIONSTATE";

	public static final String Validstate = "VALIDSTATE";

	public static final String Shippinginspstdfileid = "SHIPPINGINSPSTDFILEID";

	public static final String Productdefshortname = "PRODUCTDEFSHORTNAME";

	public static final String Partnumber = "PARTNUMBER";

	public SfProductdefinitionData() {
		this(new SfProductdefinitionKey()); 
	}

	public SfProductdefinitionData(SfProductdefinitionKey key) {
		super(key, "SfProductdefinition");
	}


	public String getProductdefname() {
		return this.repository().getString(SfProductdefinitionData.Productdefname);
	}

	public SfProductdefinitionData setProductdefname(String Productdefname) {
		this.repository().set(SfProductdefinitionData.Productdefname, Productdefname);
		return this;
	}

	public String getProductclassid() {
		return this.repository().getString(SfProductdefinitionData.Productclassid);
	}

	public SfProductdefinitionData setProductclassid(String Productclassid) {
		this.repository().set(SfProductdefinitionData.Productclassid, Productclassid);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfProductdefinitionData.Enterpriseid);
	}

	public SfProductdefinitionData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfProductdefinitionData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfProductdefinitionData.Plantid);
	}

	public SfProductdefinitionData setPlantid(String Plantid) {
		this.repository().set(SfProductdefinitionData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfProductdefinitionData.Areaid);
	}

	public SfProductdefinitionData setAreaid(String Areaid) {
		this.repository().set(SfProductdefinitionData.Areaid, Areaid);
		return this;
	}

	public String getProductdeftype() {
		return this.repository().getString(SfProductdefinitionData.Productdeftype);
	}

	public SfProductdefinitionData setProductdeftype(String Productdeftype) {
		this.repository().set(SfProductdefinitionData.Productdeftype, Productdeftype);
		return this;
	}

	public String getUnit() {
		return this.repository().getString(SfProductdefinitionData.Unit);
	}

	public SfProductdefinitionData setUnit(String Unit) {
		this.repository().set(SfProductdefinitionData.Unit, Unit);
		return this;
	}

	public Double getDefaultqty() {
		return this.repository().getDouble(SfProductdefinitionData.Defaultqty);
	}

	public SfProductdefinitionData setDefaultqty(Double Defaultqty) {
		this.repository().set(SfProductdefinitionData.Defaultqty, Defaultqty);
		return this;
	}

	public String getHassublot() {
		return this.repository().getString(SfProductdefinitionData.Hassublot);
	}

	public SfProductdefinitionData setHassublot(String Hassublot) {
		this.repository().set(SfProductdefinitionData.Hassublot, Hassublot);
		return this;
	}

	public String getOwner() {
		return this.repository().getString(SfProductdefinitionData.Owner);
	}

	public SfProductdefinitionData setOwner(String Owner) {
		this.repository().set(SfProductdefinitionData.Owner, Owner);
		return this;
	}

	public Double getLeadtime() {
		return this.repository().getDouble(SfProductdefinitionData.Leadtime);
	}

	public SfProductdefinitionData setLeadtime(Double Leadtime) {
		this.repository().set(SfProductdefinitionData.Leadtime, Leadtime);
		return this;
	}

	public Double getLotsize() {
		return this.repository().getDouble(SfProductdefinitionData.Lotsize);
	}

	public SfProductdefinitionData setLotsize(Double Lotsize) {
		this.repository().set(SfProductdefinitionData.Lotsize, Lotsize);
		return this;
	}

	public String getTeamid() {
		return this.repository().getString(SfProductdefinitionData.Teamid);
	}

	public SfProductdefinitionData setTeamid(String Teamid) {
		this.repository().set(SfProductdefinitionData.Teamid, Teamid);
		return this;
	}

	public String getModelid() {
		return this.repository().getString(SfProductdefinitionData.Modelid);
	}

	public SfProductdefinitionData setModelid(String Modelid) {
		this.repository().set(SfProductdefinitionData.Modelid, Modelid);
		return this;
	}

	public String getProcessdefid() {
		return this.repository().getString(SfProductdefinitionData.Processdefid);
	}

	public SfProductdefinitionData setProcessdefid(String Processdefid) {
		this.repository().set(SfProductdefinitionData.Processdefid, Processdefid);
		return this;
	}

	public String getProcessdefversion() {
		return this.repository().getString(SfProductdefinitionData.Processdefversion);
	}

	public SfProductdefinitionData setProcessdefversion(String Processdefversion) {
		this.repository().set(SfProductdefinitionData.Processdefversion, Processdefversion);
		return this;
	}

	public String getStandard() {
		return this.repository().getString(SfProductdefinitionData.Standard);
	}

	public SfProductdefinitionData setStandard(String Standard) {
		this.repository().set(SfProductdefinitionData.Standard, Standard);
		return this;
	}

	public Double getStandardtime() {
		return this.repository().getDouble(SfProductdefinitionData.Standardtime);
	}

	public SfProductdefinitionData setStandardtime(Double Standardtime) {
		this.repository().set(SfProductdefinitionData.Standardtime, Standardtime);
		return this;
	}

	public String getItemclasslseq() {
		return this.repository().getString(SfProductdefinitionData.Itemclasslseq);
	}

	public SfProductdefinitionData setItemclasslseq(String Itemclasslseq) {
		this.repository().set(SfProductdefinitionData.Itemclasslseq, Itemclasslseq);
		return this;
	}

	public String getItemclassmseq() {
		return this.repository().getString(SfProductdefinitionData.Itemclassmseq);
	}

	public SfProductdefinitionData setItemclassmseq(String Itemclassmseq) {
		this.repository().set(SfProductdefinitionData.Itemclassmseq, Itemclassmseq);
		return this;
	}

	public String getSpecdefid() {
		return this.repository().getString(SfProductdefinitionData.Specdefid);
	}

	public SfProductdefinitionData setSpecdefid(String Specdefid) {
		this.repository().set(SfProductdefinitionData.Specdefid, Specdefid);
		return this;
	}

	public String getImportinspfileid() {
		return this.repository().getString(SfProductdefinitionData.Importinspfileid);
	}

	public SfProductdefinitionData setImportinspfileid(String Importinspfileid) {
		this.repository().set(SfProductdefinitionData.Importinspfileid, Importinspfileid);
		return this;
	}

	public String getExportinspfileid() {
		return this.repository().getString(SfProductdefinitionData.Exportinspfileid);
	}

	public SfProductdefinitionData setExportinspfileid(String Exportinspfileid) {
		this.repository().set(SfProductdefinitionData.Exportinspfileid, Exportinspfileid);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfProductdefinitionData.Dictionaryid);
	}

	public SfProductdefinitionData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfProductdefinitionData.Dictionaryid, Dictionaryid);
		return this;
	}

	public Integer getErp_unitid() {
		return this.repository().getInteger(SfProductdefinitionData.Erp_unitid);
	}

	public SfProductdefinitionData setErp_unitid(Integer Erp_unitid) {
		this.repository().set(SfProductdefinitionData.Erp_unitid, Erp_unitid);
		return this;
	}

	public Integer getErp_productdefid() {
		return this.repository().getInteger(SfProductdefinitionData.Erp_productdefid);
	}

	public SfProductdefinitionData setErp_productdefid(Integer Erp_productdefid) {
		this.repository().set(SfProductdefinitionData.Erp_productdefid, Erp_productdefid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfProductdefinitionData.Description);
	}

	public SfProductdefinitionData setDescription(String Description) {
		this.repository().set(SfProductdefinitionData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfProductdefinitionData.Creator);
	}

	public SfProductdefinitionData setCreator(String Creator) {
		this.repository().set(SfProductdefinitionData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfProductdefinitionData.Createdtime);
	}

	public SfProductdefinitionData setCreatedtime(Date Createdtime) {
		this.repository().set(SfProductdefinitionData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfProductdefinitionData.Modifier);
	}

	public SfProductdefinitionData setModifier(String Modifier) {
		this.repository().set(SfProductdefinitionData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfProductdefinitionData.Modifiedtime);
	}

	public SfProductdefinitionData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfProductdefinitionData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfProductdefinitionData.Lasttxnhistkey);
	}

	public SfProductdefinitionData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfProductdefinitionData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfProductdefinitionData.Lasttxnid);
	}

	public SfProductdefinitionData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfProductdefinitionData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfProductdefinitionData.Lasttxnuser);
	}

	public SfProductdefinitionData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfProductdefinitionData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfProductdefinitionData.Lasttxntime);
	}

	public SfProductdefinitionData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfProductdefinitionData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfProductdefinitionData.Lasttxncomment);
	}

	public SfProductdefinitionData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfProductdefinitionData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getVersionstate() {
		return this.repository().getString(SfProductdefinitionData.Versionstate);
	}

	public SfProductdefinitionData setVersionstate(String Versionstate) {
		this.repository().set(SfProductdefinitionData.Versionstate, Versionstate);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfProductdefinitionData.Validstate);
	}

	public SfProductdefinitionData setValidstate(String Validstate) {
		this.repository().set(SfProductdefinitionData.Validstate, Validstate);
		return this;
	}

	public String getShippinginspstdfileid() {
		return this.repository().getString(SfProductdefinitionData.Shippinginspstdfileid);
	}

	public SfProductdefinitionData setShippinginspstdfileid(String Shippinginspstdfileid) {
		this.repository().set(SfProductdefinitionData.Shippinginspstdfileid, Shippinginspstdfileid);
		return this;
	}

	public String getProductdefshortname() {
		return this.repository().getString(SfProductdefinitionData.Productdefshortname);
	}

	public SfProductdefinitionData setProductdefshortname(String Productdefshortname) {
		this.repository().set(SfProductdefinitionData.Productdefshortname, Productdefshortname);
		return this;
	}

	public String getPartnumber() {
		return this.repository().getString(SfProductdefinitionData.Partnumber);
	}

	public SfProductdefinitionData setPartnumber(String Partnumber) {
		this.repository().set(SfProductdefinitionData.Partnumber, Partnumber);
		return this;
	}


}