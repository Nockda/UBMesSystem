package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfAreaHistoryData extends SQLData {

	public static final String Areaid = "AREAID";

	public static final String Txnhistkey = "TXNHISTKEY";

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

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public SfAreaHistoryData() {
		this(new SfAreaHistoryKey()); 
	}

	public SfAreaHistoryData(SfAreaHistoryKey key) {
		super(key, "SfAreaHistory");
	}


	public String getAreaname() {
		return this.repository().getString(SfAreaHistoryData.Areaname);
	}

	public SfAreaHistoryData setAreaname(String Areaname) {
		this.repository().set(SfAreaHistoryData.Areaname, Areaname);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfAreaHistoryData.Enterpriseid);
	}

	public SfAreaHistoryData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfAreaHistoryData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfAreaHistoryData.Plantid);
	}

	public SfAreaHistoryData setPlantid(String Plantid) {
		this.repository().set(SfAreaHistoryData.Plantid, Plantid);
		return this;
	}

	public String getAreatype() {
		return this.repository().getString(SfAreaHistoryData.Areatype);
	}

	public SfAreaHistoryData setAreatype(String Areatype) {
		this.repository().set(SfAreaHistoryData.Areatype, Areatype);
		return this;
	}

	public String getParentareaid() {
		return this.repository().getString(SfAreaHistoryData.Parentareaid);
	}

	public SfAreaHistoryData setParentareaid(String Parentareaid) {
		this.repository().set(SfAreaHistoryData.Parentareaid, Parentareaid);
		return this;
	}

	public String getWarehouseid() {
		return this.repository().getString(SfAreaHistoryData.Warehouseid);
	}

	public SfAreaHistoryData setWarehouseid(String Warehouseid) {
		this.repository().set(SfAreaHistoryData.Warehouseid, Warehouseid);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(SfAreaHistoryData.Dictionaryid);
	}

	public SfAreaHistoryData setDictionaryid(String Dictionaryid) {
		this.repository().set(SfAreaHistoryData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfAreaHistoryData.Description);
	}

	public SfAreaHistoryData setDescription(String Description) {
		this.repository().set(SfAreaHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfAreaHistoryData.Creator);
	}

	public SfAreaHistoryData setCreator(String Creator) {
		this.repository().set(SfAreaHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfAreaHistoryData.Createdtime);
	}

	public SfAreaHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(SfAreaHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfAreaHistoryData.Modifier);
	}

	public SfAreaHistoryData setModifier(String Modifier) {
		this.repository().set(SfAreaHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfAreaHistoryData.Modifiedtime);
	}

	public SfAreaHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfAreaHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(SfAreaHistoryData.Txnid);
	}

	public SfAreaHistoryData setTxnid(String Txnid) {
		this.repository().set(SfAreaHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfAreaHistoryData.Txnuser);
	}

	public SfAreaHistoryData setTxnuser(String Txnuser) {
		this.repository().set(SfAreaHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfAreaHistoryData.Txntime);
	}

	public SfAreaHistoryData setTxntime(Date Txntime) {
		this.repository().set(SfAreaHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfAreaHistoryData.Txngrouphistkey);
	}

	public SfAreaHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfAreaHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfAreaHistoryData.Txnreasoncodeclass);
	}

	public SfAreaHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfAreaHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfAreaHistoryData.Txnreasoncode);
	}

	public SfAreaHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfAreaHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfAreaHistoryData.Txncomment);
	}

	public SfAreaHistoryData setTxncomment(String Txncomment) {
		this.repository().set(SfAreaHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfAreaHistoryData.Validstate);
	}

	public SfAreaHistoryData setValidstate(String Validstate) {
		this.repository().set(SfAreaHistoryData.Validstate, Validstate);
		return this;
	}


}