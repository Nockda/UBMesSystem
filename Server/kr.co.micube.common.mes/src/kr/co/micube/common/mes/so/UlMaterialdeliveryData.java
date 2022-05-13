package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlMaterialdeliveryData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Reqseq = "REQSEQ";

	public static final String Reqserl = "REQSERL";

	public static final String Reqno = "REQNO";

	public static final String Itemno = "ITEMNO";

	public static final String Itemseq = "ITEMSEQ";

	public static final String Unitseq = "UNITSEQ";

	public static final String Outwhseq = "OUTWHSEQ";

	public static final String Inwhseq = "INWHSEQ";

	public static final String Consumablelotid = "CONSUMABLELOTID";

	public static final String Outqty = "OUTQTY";

	public static final String Completeyn = "COMPLETEYN";

	public static final String Tossyn = "TOSSYN";

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

	public static final String Departmentid = "DEPARTMENTID";

	public UlMaterialdeliveryData() {
		this(new UlMaterialdeliveryKey()); 
	}

	public UlMaterialdeliveryData(UlMaterialdeliveryKey key) {
		super(key, "UlMaterialdelivery");
		this.txnInfo().setHistoryTable(true);
	}


	public Integer getReqseq() {
		return this.repository().getInteger(UlMaterialdeliveryData.Reqseq);
	}

	public UlMaterialdeliveryData setReqseq(Integer Reqseq) {
		this.repository().set(UlMaterialdeliveryData.Reqseq, Reqseq);
		return this;
	}

	public Integer getReqserl() {
		return this.repository().getInteger(UlMaterialdeliveryData.Reqserl);
	}

	public UlMaterialdeliveryData setReqserl(Integer Reqserl) {
		this.repository().set(UlMaterialdeliveryData.Reqserl, Reqserl);
		return this;
	}

	public String getReqno() {
		return this.repository().getString(UlMaterialdeliveryData.Reqno);
	}

	public UlMaterialdeliveryData setReqno(String Reqno) {
		this.repository().set(UlMaterialdeliveryData.Reqno, Reqno);
		return this;
	}

	public String getItemno() {
		return this.repository().getString(UlMaterialdeliveryData.Itemno);
	}

	public UlMaterialdeliveryData setItemno(String Itemno) {
		this.repository().set(UlMaterialdeliveryData.Itemno, Itemno);
		return this;
	}

	public Integer getItemseq() {
		return this.repository().getInteger(UlMaterialdeliveryData.Itemseq);
	}

	public UlMaterialdeliveryData setItemseq(Integer Itemseq) {
		this.repository().set(UlMaterialdeliveryData.Itemseq, Itemseq);
		return this;
	}

	public Integer getUnitseq() {
		return this.repository().getInteger(UlMaterialdeliveryData.Unitseq);
	}

	public UlMaterialdeliveryData setUnitseq(Integer Unitseq) {
		this.repository().set(UlMaterialdeliveryData.Unitseq, Unitseq);
		return this;
	}

	public Integer getOutwhseq() {
		return this.repository().getInteger(UlMaterialdeliveryData.Outwhseq);
	}

	public UlMaterialdeliveryData setOutwhseq(Integer Outwhseq) {
		this.repository().set(UlMaterialdeliveryData.Outwhseq, Outwhseq);
		return this;
	}

	public Integer getInwhseq() {
		return this.repository().getInteger(UlMaterialdeliveryData.Inwhseq);
	}

	public UlMaterialdeliveryData setInwhseq(Integer Inwhseq) {
		this.repository().set(UlMaterialdeliveryData.Inwhseq, Inwhseq);
		return this;
	}

	public String getConsumablelotid() {
		return this.repository().getString(UlMaterialdeliveryData.Consumablelotid);
	}

	public UlMaterialdeliveryData setConsumablelotid(String Consumablelotid) {
		this.repository().set(UlMaterialdeliveryData.Consumablelotid, Consumablelotid);
		return this;
	}

	public Double getOutqty() {
		return this.repository().getDouble(UlMaterialdeliveryData.Outqty);
	}

	public UlMaterialdeliveryData setOutqty(Double Outqty) {
		this.repository().set(UlMaterialdeliveryData.Outqty, Outqty);
		return this;
	}

	public String getCompleteyn() {
		return this.repository().getString(UlMaterialdeliveryData.Completeyn);
	}

	public UlMaterialdeliveryData setCompleteyn(String Completeyn) {
		this.repository().set(UlMaterialdeliveryData.Completeyn, Completeyn);
		return this;
	}

	public String getTossyn() {
		return this.repository().getString(UlMaterialdeliveryData.Tossyn);
	}

	public UlMaterialdeliveryData setTossyn(String Tossyn) {
		this.repository().set(UlMaterialdeliveryData.Tossyn, Tossyn);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlMaterialdeliveryData.Description);
	}

	public UlMaterialdeliveryData setDescription(String Description) {
		this.repository().set(UlMaterialdeliveryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlMaterialdeliveryData.Creator);
	}

	public UlMaterialdeliveryData setCreator(String Creator) {
		this.repository().set(UlMaterialdeliveryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlMaterialdeliveryData.Createdtime);
	}

	public UlMaterialdeliveryData setCreatedtime(Date Createdtime) {
		this.repository().set(UlMaterialdeliveryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlMaterialdeliveryData.Modifier);
	}

	public UlMaterialdeliveryData setModifier(String Modifier) {
		this.repository().set(UlMaterialdeliveryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlMaterialdeliveryData.Modifiedtime);
	}

	public UlMaterialdeliveryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlMaterialdeliveryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlMaterialdeliveryData.Txnid);
	}

	public UlMaterialdeliveryData setTxnid(String Txnid) {
		this.repository().set(UlMaterialdeliveryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlMaterialdeliveryData.Txnuser);
	}

	public UlMaterialdeliveryData setTxnuser(String Txnuser) {
		this.repository().set(UlMaterialdeliveryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlMaterialdeliveryData.Txntime);
	}

	public UlMaterialdeliveryData setTxntime(Date Txntime) {
		this.repository().set(UlMaterialdeliveryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlMaterialdeliveryData.Txngrouphistkey);
	}

	public UlMaterialdeliveryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlMaterialdeliveryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlMaterialdeliveryData.Txnreasoncodeclass);
	}

	public UlMaterialdeliveryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlMaterialdeliveryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlMaterialdeliveryData.Txnreasoncode);
	}

	public UlMaterialdeliveryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlMaterialdeliveryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlMaterialdeliveryData.Txncomment);
	}

	public UlMaterialdeliveryData setTxncomment(String Txncomment) {
		this.repository().set(UlMaterialdeliveryData.Txncomment, Txncomment);
		return this;
	}

	public String getDepartmentid() {
		return this.repository().getString(UlMaterialdeliveryData.Departmentid);
	}

	public UlMaterialdeliveryData setDepartmentid(String Departmentid) {
		this.repository().set(UlMaterialdeliveryData.Departmentid, Departmentid);
		return this;
	}


}