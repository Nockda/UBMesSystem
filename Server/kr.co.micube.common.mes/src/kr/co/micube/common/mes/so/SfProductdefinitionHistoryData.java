package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfProductdefinitionHistoryData extends SQLData {

	public static final String Productdefid = "PRODUCTDEFID";

	public static final String Productdefversion = "PRODUCTDEFVERSION";

	public static final String Txnhistkey = "TXNHISTKEY";

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

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public static final String Productdefshortname = "PRODUCTDEFSHORTNAME";

	public static final String Partnumber = "PARTNUMBER";

	public SfProductdefinitionHistoryData() {
		this(new SfProductdefinitionHistoryKey()); 
	}

	public SfProductdefinitionHistoryData(SfProductdefinitionHistoryKey key) {
		super(key, "SfProductdefinitionHistory");
	}


	public String getProductdefname() {
		return this.repository().getString(SfProductdefinitionHistoryData.Productdefname);
	}

	public SfProductdefinitionHistoryData setProductdefname(String Productdefname) {
		this.repository().set(SfProductdefinitionHistoryData.Productdefname, Productdefname);
		return this;
	}

	public String getProductclassid() {
		return this.repository().getString(SfProductdefinitionHistoryData.Productclassid);
	}

	public SfProductdefinitionHistoryData setProductclassid(String Productclassid) {
		this.repository().set(SfProductdefinitionHistoryData.Productclassid, Productclassid);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfProductdefinitionHistoryData.Enterpriseid);
	}

	public SfProductdefinitionHistoryData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfProductdefinitionHistoryData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfProductdefinitionHistoryData.Plantid);
	}

	public SfProductdefinitionHistoryData setPlantid(String Plantid) {
		this.repository().set(SfProductdefinitionHistoryData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfProductdefinitionHistoryData.Areaid);
	}

	public SfProductdefinitionHistoryData setAreaid(String Areaid) {
		this.repository().set(SfProductdefinitionHistoryData.Areaid, Areaid);
		return this;
	}

	public String getProductdeftype() {
		return this.repository().getString(SfProductdefinitionHistoryData.Productdeftype);
	}

	public SfProductdefinitionHistoryData setProductdeftype(String Productdeftype) {
		this.repository().set(SfProductdefinitionHistoryData.Productdeftype, Productdeftype);
		return this;
	}

	public String getUnit() {
		return this.repository().getString(SfProductdefinitionHistoryData.Unit);
	}

	public SfProductdefinitionHistoryData setUnit(String Unit) {
		this.repository().set(SfProductdefinitionHistoryData.Unit, Unit);
		return this;
	}

	public Double getDefaultqty() {
		return this.repository().getDouble(SfProductdefinitionHistoryData.Defaultqty);
	}

	public SfProductdefinitionHistoryData setDefaultqty(Double Defaultqty) {
		this.repository().set(SfProductdefinitionHistoryData.Defaultqty, Defaultqty);
		return this;
	}

	public String getHassublot() {
		return this.repository().getString(SfProductdefinitionHistoryData.Hassublot);
	}

	public SfProductdefinitionHistoryData setHassublot(String Hassublot) {
		this.repository().set(SfProductdefinitionHistoryData.Hassublot, Hassublot);
		return this;
	}

	public String getOwner() {
		return this.repository().getString(SfProductdefinitionHistoryData.Owner);
	}

	public SfProductdefinitionHistoryData setOwner(String Owner) {
		this.repository().set(SfProductdefinitionHistoryData.Owner, Owner);
		return this;
	}

	public Double getLeadtime() {
		return this.repository().getDouble(SfProductdefinitionHistoryData.Leadtime);
	}

	public SfProductdefinitionHistoryData setLeadtime(Double Leadtime) {
		this.repository().set(SfProductdefinitionHistoryData.Leadtime, Leadtime);
		return this;
	}

	public Double getLotsize() {
		return this.repository().getDouble(SfProductdefinitionHistoryData.Lotsize);
	}

	public SfProductdefinitionHistoryData setLotsize(Double Lotsize) {
		this.repository().set(SfProductdefinitionHistoryData.Lotsize, Lotsize);
		return this;
	}

	public String getTeamid() {
		return this.repository().getString(SfProductdefinitionHistoryData.Teamid);
	}

	public SfProductdefinitionHistoryData setTeamid(String Teamid) {
		this.repository().set(SfProductdefinitionHistoryData.Teamid, Teamid);
		return this;
	}

	public String getModelid() {
		return this.repository().getString(SfProductdefinitionHistoryData.Modelid);
	}

	public SfProductdefinitionHistoryData setModelid(String Modelid) {
		this.repository().set(SfProductdefinitionHistoryData.Modelid, Modelid);
		return this;
	}

	public String getProcessdefid() {
		return this.repository().getString(SfProductdefinitionHistoryData.Processdefid);
	}

	public SfProductdefinitionHistoryData setProcessdefid(String Processdefid) {
		this.repository().set(SfProductdefinitionHistoryData.Processdefid, Processdefid);
		return this;
	}

	public String getProcessdefversion() {
		return this.repository().getString(SfProductdefinitionHistoryData.Processdefversion);
	}

	public SfProductdefinitionHistoryData setProcessdefversion(String Processdefversion) {
		this.repository().set(SfProductdefinitionHistoryData.Processdefversion, Processdefversion);
		return this;
	}

	public String getStandard() {
		return this.repository().getString(SfProductdefinitionHistoryData.Standard);
	}

	public SfProductdefinitionHistoryData setStandard(String Standard) {
		this.repository().set(SfProductdefinitionHistoryData.Standard, Standard);
		return this;
	}

	public Double getStandardtime() {
		return this.repository().getDouble(SfProductdefinitionHistoryData.Standardtime);
	}

	public SfProductdefinitionHistoryData setStandardtime(Double Standardtime) {
		this.repository().set(SfProductdefinitionHistoryData.Standardtime, Standardtime);
		return this;
	}

	public String getItemclasslseq() {
		return this.repository().getString(SfProductdefinitionHistoryData.Itemclasslseq);
	}

	public SfProductdefinitionHistoryData setItemclasslseq(String Itemclasslseq) {
		this.repository().set(SfProductdefinitionHistoryData.Itemclasslseq, Itemclasslseq);
		return this;
	}

	public String getItemclassmseq() {
		return this.repository().getString(SfProductdefinitionHistoryData.Itemclassmseq);
	}

	public SfProductdefinitionHistoryData setItemclassmseq(String Itemclassmseq) {
		this.repository().set(SfProductdefinitionHistoryData.Itemclassmseq, Itemclassmseq);
		return this;
	}

	public String getSpecdefid() {
		return this.repository().getString(SfProductdefinitionHistoryData.Specdefid);
	}

	public SfProductdefinitionHistoryData setSpecdefid(String Specdefid) {
		this.repository().set(SfProductdefinitionHistoryData.Specdefid, Specdefid);
		return this;
	}

	public String getImportinspfileid() {
		return this.repository().getString(SfProductdefinitionHistoryData.Importinspfileid);
	}

	public SfProductdefinitionHistoryData setImportinspfileid(String Importinspfileid) {
		this.repository().set(SfProductdefinitionHistoryData.Importinspfileid, Importinspfileid);
		return this;
	}

	public String getExportinspfileid() {
		return this.repository().getString(SfProductdefinitionHistoryData.Exportinspfileid);
	}

	public SfProductdefinitionHistoryData setExportinspfileid(String Exportinspfileid) {
		this.repository().set(SfProductdefinitionHistoryData.Exportinspfileid, Exportinspfileid);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfProductdefinitionHistoryData.Dictionaryid);
	}

	public SfProductdefinitionHistoryData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfProductdefinitionHistoryData.Dictionaryid, Dictionaryid);
		return this;
	}

	public Integer getErp_unitid() {
		return this.repository().getInteger(SfProductdefinitionHistoryData.Erp_unitid);
	}

	public SfProductdefinitionHistoryData setErp_unitid(Integer Erp_unitid) {
		this.repository().set(SfProductdefinitionHistoryData.Erp_unitid, Erp_unitid);
		return this;
	}

	public Integer getErp_productdefid() {
		return this.repository().getInteger(SfProductdefinitionHistoryData.Erp_productdefid);
	}

	public SfProductdefinitionHistoryData setErp_productdefid(Integer Erp_productdefid) {
		this.repository().set(SfProductdefinitionHistoryData.Erp_productdefid, Erp_productdefid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfProductdefinitionHistoryData.Description);
	}

	public SfProductdefinitionHistoryData setDescription(String Description) {
		this.repository().set(SfProductdefinitionHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfProductdefinitionHistoryData.Creator);
	}

	public SfProductdefinitionHistoryData setCreator(String Creator) {
		this.repository().set(SfProductdefinitionHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfProductdefinitionHistoryData.Createdtime);
	}

	public SfProductdefinitionHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(SfProductdefinitionHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfProductdefinitionHistoryData.Modifier);
	}

	public SfProductdefinitionHistoryData setModifier(String Modifier) {
		this.repository().set(SfProductdefinitionHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfProductdefinitionHistoryData.Modifiedtime);
	}

	public SfProductdefinitionHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfProductdefinitionHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(SfProductdefinitionHistoryData.Txnid);
	}

	public SfProductdefinitionHistoryData setTxnid(String Txnid) {
		this.repository().set(SfProductdefinitionHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfProductdefinitionHistoryData.Txnuser);
	}

	public SfProductdefinitionHistoryData setTxnuser(String Txnuser) {
		this.repository().set(SfProductdefinitionHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfProductdefinitionHistoryData.Txntime);
	}

	public SfProductdefinitionHistoryData setTxntime(Date Txntime) {
		this.repository().set(SfProductdefinitionHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfProductdefinitionHistoryData.Txngrouphistkey);
	}

	public SfProductdefinitionHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfProductdefinitionHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfProductdefinitionHistoryData.Txnreasoncodeclass);
	}

	public SfProductdefinitionHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfProductdefinitionHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfProductdefinitionHistoryData.Txnreasoncode);
	}

	public SfProductdefinitionHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfProductdefinitionHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfProductdefinitionHistoryData.Txncomment);
	}

	public SfProductdefinitionHistoryData setTxncomment(String Txncomment) {
		this.repository().set(SfProductdefinitionHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfProductdefinitionHistoryData.Validstate);
	}

	public SfProductdefinitionHistoryData setValidstate(String Validstate) {
		this.repository().set(SfProductdefinitionHistoryData.Validstate, Validstate);
		return this;
	}

	public String getProductdefshortname() {
		return this.repository().getString(SfProductdefinitionHistoryData.Productdefshortname);
	}

	public SfProductdefinitionHistoryData setProductdefshortname(String Productdefshortname) {
		this.repository().set(SfProductdefinitionHistoryData.Productdefshortname, Productdefshortname);
		return this;
	}

	public String getPartnumber() {
		return this.repository().getString(SfProductdefinitionHistoryData.Partnumber);
	}

	public SfProductdefinitionHistoryData setPartnumber(String Partnumber) {
		this.repository().set(SfProductdefinitionHistoryData.Partnumber, Partnumber);
		return this;
	}


}