package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfConsumabledefinitionData extends SQLData {

	public static final String Consumabledefid = "CONSUMABLEDEFID";

	public static final String Consumabledefversion = "CONSUMABLEDEFVERSION";

	public static final String Consumabledefname = "CONSUMABLEDEFNAME";

	public static final String Consumableclassid = "CONSUMABLECLASSID";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Consumabletype = "CONSUMABLETYPE";

	public static final String Unit = "UNIT";

	public static final String Lotsize = "LOTSIZE";

	public static final String Importinsp = "IMPORTINSP";

	public static final String Isserial = "ISSERIAL";

	public static final String Istracking = "ISTRACKING";

	public static final String Standard = "STANDARD";

	public static final String Itemclasslseq = "ITEMCLASSLSEQ";

	public static final String Itemclassmseq = "ITEMCLASSMSEQ";

	public static final String Dictionaryid = "DICTIONARYID";

	public static final String Isfinalinsp = "ISFINALINSP";

	public static final String Erp_unitid = "ERP_UNITID";

	public static final String Erp_consumabledefid = "ERP_CONSUMABLEDEFID";

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

	public static final String Notordersegmentid = "NOTORDERSEGMENTID";

	public static final String Isnotorderresult = "ISNOTORDERRESULT";

	public static final String Receivinginspstdfileid = "RECEIVINGINSPSTDFILEID";

	public static final String Shippinginspstdfileid = "SHIPPINGINSPSTDFILEID";

	public static final String Consumabledefshortname = "CONSUMABLEDEFSHORTNAME";

	public static final String Partnumber = "PARTNUMBER";

	public SfConsumabledefinitionData() {
		this(new SfConsumabledefinitionKey()); 
	}

	public SfConsumabledefinitionData(SfConsumabledefinitionKey key) {
		super(key, "SfConsumabledefinition");
	}


	public String getConsumabledefname() {
		return this.repository().getString(SfConsumabledefinitionData.Consumabledefname);
	}

	public SfConsumabledefinitionData setConsumabledefname(String Consumabledefname) {
		this.repository().set(SfConsumabledefinitionData.Consumabledefname, Consumabledefname);
		return this;
	}

	public String getConsumableclassid() {
		return this.repository().getString(SfConsumabledefinitionData.Consumableclassid);
	}

	public SfConsumabledefinitionData setConsumableclassid(String Consumableclassid) {
		this.repository().set(SfConsumabledefinitionData.Consumableclassid, Consumableclassid);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfConsumabledefinitionData.Enterpriseid);
	}

	public SfConsumabledefinitionData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfConsumabledefinitionData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfConsumabledefinitionData.Plantid);
	}

	public SfConsumabledefinitionData setPlantid(String Plantid) {
		this.repository().set(SfConsumabledefinitionData.Plantid, Plantid);
		return this;
	}

	public String getConsumabletype() {
		return this.repository().getString(SfConsumabledefinitionData.Consumabletype);
	}

	public SfConsumabledefinitionData setConsumabletype(String Consumabletype) {
		this.repository().set(SfConsumabledefinitionData.Consumabletype, Consumabletype);
		return this;
	}

	public String getUnit() {
		return this.repository().getString(SfConsumabledefinitionData.Unit);
	}

	public SfConsumabledefinitionData setUnit(String Unit) {
		this.repository().set(SfConsumabledefinitionData.Unit, Unit);
		return this;
	}

	public Double getLotsize() {
		return this.repository().getDouble(SfConsumabledefinitionData.Lotsize);
	}

	public SfConsumabledefinitionData setLotsize(Double Lotsize) {
		this.repository().set(SfConsumabledefinitionData.Lotsize, Lotsize);
		return this;
	}

	public String getImportinsp() {
		return this.repository().getString(SfConsumabledefinitionData.Importinsp);
	}

	public SfConsumabledefinitionData setImportinsp(String Importinsp) {
		this.repository().set(SfConsumabledefinitionData.Importinsp, Importinsp);
		return this;
	}

	public String getIsserial() {
		return this.repository().getString(SfConsumabledefinitionData.Isserial);
	}

	public SfConsumabledefinitionData setIsserial(String Isserial) {
		this.repository().set(SfConsumabledefinitionData.Isserial, Isserial);
		return this;
	}

	public String getIstracking() {
		return this.repository().getString(SfConsumabledefinitionData.Istracking);
	}

	public SfConsumabledefinitionData setIstracking(String Istracking) {
		this.repository().set(SfConsumabledefinitionData.Istracking, Istracking);
		return this;
	}

	public String getStandard() {
		return this.repository().getString(SfConsumabledefinitionData.Standard);
	}

	public SfConsumabledefinitionData setStandard(String Standard) {
		this.repository().set(SfConsumabledefinitionData.Standard, Standard);
		return this;
	}

	public String getItemclasslseq() {
		return this.repository().getString(SfConsumabledefinitionData.Itemclasslseq);
	}

	public SfConsumabledefinitionData setItemclasslseq(String Itemclasslseq) {
		this.repository().set(SfConsumabledefinitionData.Itemclasslseq, Itemclasslseq);
		return this;
	}

	public String getItemclassmseq() {
		return this.repository().getString(SfConsumabledefinitionData.Itemclassmseq);
	}

	public SfConsumabledefinitionData setItemclassmseq(String Itemclassmseq) {
		this.repository().set(SfConsumabledefinitionData.Itemclassmseq, Itemclassmseq);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfConsumabledefinitionData.Dictionaryid);
	}

	public SfConsumabledefinitionData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfConsumabledefinitionData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getIsfinalinsp() {
		return this.repository().getString(SfConsumabledefinitionData.Isfinalinsp);
	}

	public SfConsumabledefinitionData setIsfinalinsp(String Isfinalinsp) {
		this.repository().set(SfConsumabledefinitionData.Isfinalinsp, Isfinalinsp);
		return this;
	}

	public Integer getErp_unitid() {
		return this.repository().getInteger(SfConsumabledefinitionData.Erp_unitid);
	}

	public SfConsumabledefinitionData setErp_unitid(Integer Erp_unitid) {
		this.repository().set(SfConsumabledefinitionData.Erp_unitid, Erp_unitid);
		return this;
	}

	public Integer getErp_consumabledefid() {
		return this.repository().getInteger(SfConsumabledefinitionData.Erp_consumabledefid);
	}

	public SfConsumabledefinitionData setErp_consumabledefid(Integer Erp_consumabledefid) {
		this.repository().set(SfConsumabledefinitionData.Erp_consumabledefid, Erp_consumabledefid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfConsumabledefinitionData.Description);
	}

	public SfConsumabledefinitionData setDescription(String Description) {
		this.repository().set(SfConsumabledefinitionData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfConsumabledefinitionData.Creator);
	}

	public SfConsumabledefinitionData setCreator(String Creator) {
		this.repository().set(SfConsumabledefinitionData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfConsumabledefinitionData.Createdtime);
	}

	public SfConsumabledefinitionData setCreatedtime(Date Createdtime) {
		this.repository().set(SfConsumabledefinitionData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfConsumabledefinitionData.Modifier);
	}

	public SfConsumabledefinitionData setModifier(String Modifier) {
		this.repository().set(SfConsumabledefinitionData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfConsumabledefinitionData.Modifiedtime);
	}

	public SfConsumabledefinitionData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfConsumabledefinitionData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfConsumabledefinitionData.Lasttxnhistkey);
	}

	public SfConsumabledefinitionData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfConsumabledefinitionData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfConsumabledefinitionData.Lasttxnid);
	}

	public SfConsumabledefinitionData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfConsumabledefinitionData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfConsumabledefinitionData.Lasttxnuser);
	}

	public SfConsumabledefinitionData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfConsumabledefinitionData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfConsumabledefinitionData.Lasttxntime);
	}

	public SfConsumabledefinitionData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfConsumabledefinitionData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfConsumabledefinitionData.Lasttxncomment);
	}

	public SfConsumabledefinitionData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfConsumabledefinitionData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getVersionstate() {
		return this.repository().getString(SfConsumabledefinitionData.Versionstate);
	}

	public SfConsumabledefinitionData setVersionstate(String Versionstate) {
		this.repository().set(SfConsumabledefinitionData.Versionstate, Versionstate);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfConsumabledefinitionData.Validstate);
	}

	public SfConsumabledefinitionData setValidstate(String Validstate) {
		this.repository().set(SfConsumabledefinitionData.Validstate, Validstate);
		return this;
	}

	public String getNotordersegmentid() {
		return this.repository().getString(SfConsumabledefinitionData.Notordersegmentid);
	}

	public SfConsumabledefinitionData setNotordersegmentid(String Notordersegmentid) {
		this.repository().set(SfConsumabledefinitionData.Notordersegmentid, Notordersegmentid);
		return this;
	}

	public String getIsnotorderresult() {
		return this.repository().getString(SfConsumabledefinitionData.Isnotorderresult);
	}

	public SfConsumabledefinitionData setIsnotorderresult(String Isnotorderresult) {
		this.repository().set(SfConsumabledefinitionData.Isnotorderresult, Isnotorderresult);
		return this;
	}

	public String getReceivinginspstdfileid() {
		return this.repository().getString(SfConsumabledefinitionData.Receivinginspstdfileid);
	}

	public SfConsumabledefinitionData setReceivinginspstdfileid(String Receivinginspstdfileid) {
		this.repository().set(SfConsumabledefinitionData.Receivinginspstdfileid, Receivinginspstdfileid);
		return this;
	}

	public String getShippinginspstdfileid() {
		return this.repository().getString(SfConsumabledefinitionData.Shippinginspstdfileid);
	}

	public SfConsumabledefinitionData setShippinginspstdfileid(String Shippinginspstdfileid) {
		this.repository().set(SfConsumabledefinitionData.Shippinginspstdfileid, Shippinginspstdfileid);
		return this;
	}

	public String getConsumabledefshortname() {
		return this.repository().getString(SfConsumabledefinitionData.Consumabledefshortname);
	}

	public SfConsumabledefinitionData setConsumabledefshortname(String Consumabledefshortname) {
		this.repository().set(SfConsumabledefinitionData.Consumabledefshortname, Consumabledefshortname);
		return this;
	}

	public String getPartnumber() {
		return this.repository().getString(SfConsumabledefinitionData.Partnumber);
	}

	public SfConsumabledefinitionData setPartnumber(String Partnumber) {
		this.repository().set(SfConsumabledefinitionData.Partnumber, Partnumber);
		return this;
	}


}