package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfConsumabledefinitionHistoryData extends SQLData {

	public static final String Consumabledefid = "CONSUMABLEDEFID";

	public static final String Consumabledefversion = "CONSUMABLEDEFVERSION";

	public static final String Txnhistkey = "TXNHISTKEY";

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

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public static final String Notordersegmentid = "NOTORDERSEGMENTID";

	public static final String Isnotorderresult = "ISNOTORDERRESULT";

	public static final String Receivinginspstdfileid = "RECEIVINGINSPSTDFILEID";

	public static final String Shippinginspstdfileid = "SHIPPINGINSPSTDFILEID";

	public static final String Productdefshortname = "PRODUCTDEFSHORTNAME";

	public static final String Partnumber = "PARTNUMBER";

	public SfConsumabledefinitionHistoryData() {
		this(new SfConsumabledefinitionHistoryKey()); 
	}

	public SfConsumabledefinitionHistoryData(SfConsumabledefinitionHistoryKey key) {
		super(key, "SfConsumabledefinitionHistory");
	}


	public String getConsumabledefname() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Consumabledefname);
	}

	public SfConsumabledefinitionHistoryData setConsumabledefname(String Consumabledefname) {
		this.repository().set(SfConsumabledefinitionHistoryData.Consumabledefname, Consumabledefname);
		return this;
	}

	public String getConsumableclassid() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Consumableclassid);
	}

	public SfConsumabledefinitionHistoryData setConsumableclassid(String Consumableclassid) {
		this.repository().set(SfConsumabledefinitionHistoryData.Consumableclassid, Consumableclassid);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Enterpriseid);
	}

	public SfConsumabledefinitionHistoryData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfConsumabledefinitionHistoryData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Plantid);
	}

	public SfConsumabledefinitionHistoryData setPlantid(String Plantid) {
		this.repository().set(SfConsumabledefinitionHistoryData.Plantid, Plantid);
		return this;
	}

	public String getConsumabletype() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Consumabletype);
	}

	public SfConsumabledefinitionHistoryData setConsumabletype(String Consumabletype) {
		this.repository().set(SfConsumabledefinitionHistoryData.Consumabletype, Consumabletype);
		return this;
	}

	public String getUnit() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Unit);
	}

	public SfConsumabledefinitionHistoryData setUnit(String Unit) {
		this.repository().set(SfConsumabledefinitionHistoryData.Unit, Unit);
		return this;
	}

	public Double getLotsize() {
		return this.repository().getDouble(SfConsumabledefinitionHistoryData.Lotsize);
	}

	public SfConsumabledefinitionHistoryData setLotsize(Double Lotsize) {
		this.repository().set(SfConsumabledefinitionHistoryData.Lotsize, Lotsize);
		return this;
	}

	public String getImportinsp() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Importinsp);
	}

	public SfConsumabledefinitionHistoryData setImportinsp(String Importinsp) {
		this.repository().set(SfConsumabledefinitionHistoryData.Importinsp, Importinsp);
		return this;
	}

	public String getIsserial() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Isserial);
	}

	public SfConsumabledefinitionHistoryData setIsserial(String Isserial) {
		this.repository().set(SfConsumabledefinitionHistoryData.Isserial, Isserial);
		return this;
	}

	public String getIstracking() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Istracking);
	}

	public SfConsumabledefinitionHistoryData setIstracking(String Istracking) {
		this.repository().set(SfConsumabledefinitionHistoryData.Istracking, Istracking);
		return this;
	}

	public String getStandard() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Standard);
	}

	public SfConsumabledefinitionHistoryData setStandard(String Standard) {
		this.repository().set(SfConsumabledefinitionHistoryData.Standard, Standard);
		return this;
	}

	public String getItemclasslseq() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Itemclasslseq);
	}

	public SfConsumabledefinitionHistoryData setItemclasslseq(String Itemclasslseq) {
		this.repository().set(SfConsumabledefinitionHistoryData.Itemclasslseq, Itemclasslseq);
		return this;
	}

	public String getItemclassmseq() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Itemclassmseq);
	}

	public SfConsumabledefinitionHistoryData setItemclassmseq(String Itemclassmseq) {
		this.repository().set(SfConsumabledefinitionHistoryData.Itemclassmseq, Itemclassmseq);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Dictionaryid);
	}

	public SfConsumabledefinitionHistoryData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfConsumabledefinitionHistoryData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getIsfinalinsp() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Isfinalinsp);
	}

	public SfConsumabledefinitionHistoryData setIsfinalinsp(String Isfinalinsp) {
		this.repository().set(SfConsumabledefinitionHistoryData.Isfinalinsp, Isfinalinsp);
		return this;
	}

	public Integer getErp_unitid() {
		return this.repository().getInteger(SfConsumabledefinitionHistoryData.Erp_unitid);
	}

	public SfConsumabledefinitionHistoryData setErp_unitid(Integer Erp_unitid) {
		this.repository().set(SfConsumabledefinitionHistoryData.Erp_unitid, Erp_unitid);
		return this;
	}

	public Integer getErp_consumabledefid() {
		return this.repository().getInteger(SfConsumabledefinitionHistoryData.Erp_consumabledefid);
	}

	public SfConsumabledefinitionHistoryData setErp_consumabledefid(Integer Erp_consumabledefid) {
		this.repository().set(SfConsumabledefinitionHistoryData.Erp_consumabledefid, Erp_consumabledefid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Description);
	}

	public SfConsumabledefinitionHistoryData setDescription(String Description) {
		this.repository().set(SfConsumabledefinitionHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Creator);
	}

	public SfConsumabledefinitionHistoryData setCreator(String Creator) {
		this.repository().set(SfConsumabledefinitionHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfConsumabledefinitionHistoryData.Createdtime);
	}

	public SfConsumabledefinitionHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(SfConsumabledefinitionHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Modifier);
	}

	public SfConsumabledefinitionHistoryData setModifier(String Modifier) {
		this.repository().set(SfConsumabledefinitionHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfConsumabledefinitionHistoryData.Modifiedtime);
	}

	public SfConsumabledefinitionHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfConsumabledefinitionHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Txnid);
	}

	public SfConsumabledefinitionHistoryData setTxnid(String Txnid) {
		this.repository().set(SfConsumabledefinitionHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Txnuser);
	}

	public SfConsumabledefinitionHistoryData setTxnuser(String Txnuser) {
		this.repository().set(SfConsumabledefinitionHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfConsumabledefinitionHistoryData.Txntime);
	}

	public SfConsumabledefinitionHistoryData setTxntime(Date Txntime) {
		this.repository().set(SfConsumabledefinitionHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Txngrouphistkey);
	}

	public SfConsumabledefinitionHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfConsumabledefinitionHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Txnreasoncodeclass);
	}

	public SfConsumabledefinitionHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfConsumabledefinitionHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Txnreasoncode);
	}

	public SfConsumabledefinitionHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfConsumabledefinitionHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Txncomment);
	}

	public SfConsumabledefinitionHistoryData setTxncomment(String Txncomment) {
		this.repository().set(SfConsumabledefinitionHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Validstate);
	}

	public SfConsumabledefinitionHistoryData setValidstate(String Validstate) {
		this.repository().set(SfConsumabledefinitionHistoryData.Validstate, Validstate);
		return this;
	}

	public String getNotordersegmentid() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Notordersegmentid);
	}

	public SfConsumabledefinitionHistoryData setNotordersegmentid(String Notordersegmentid) {
		this.repository().set(SfConsumabledefinitionHistoryData.Notordersegmentid, Notordersegmentid);
		return this;
	}

	public String getIsnotorderresult() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Isnotorderresult);
	}

	public SfConsumabledefinitionHistoryData setIsnotorderresult(String Isnotorderresult) {
		this.repository().set(SfConsumabledefinitionHistoryData.Isnotorderresult, Isnotorderresult);
		return this;
	}

	public String getReceivinginspstdfileid() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Receivinginspstdfileid);
	}

	public SfConsumabledefinitionHistoryData setReceivinginspstdfileid(String Receivinginspstdfileid) {
		this.repository().set(SfConsumabledefinitionHistoryData.Receivinginspstdfileid, Receivinginspstdfileid);
		return this;
	}

	public String getShippinginspstdfileid() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Shippinginspstdfileid);
	}

	public SfConsumabledefinitionHistoryData setShippinginspstdfileid(String Shippinginspstdfileid) {
		this.repository().set(SfConsumabledefinitionHistoryData.Shippinginspstdfileid, Shippinginspstdfileid);
		return this;
	}

	public String getProductdefshortname() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Productdefshortname);
	}

	public SfConsumabledefinitionHistoryData setProductdefshortname(String Productdefshortname) {
		this.repository().set(SfConsumabledefinitionHistoryData.Productdefshortname, Productdefshortname);
		return this;
	}

	public String getPartnumber() {
		return this.repository().getString(SfConsumabledefinitionHistoryData.Partnumber);
	}

	public SfConsumabledefinitionHistoryData setPartnumber(String Partnumber) {
		this.repository().set(SfConsumabledefinitionHistoryData.Partnumber, Partnumber);
		return this;
	}


}