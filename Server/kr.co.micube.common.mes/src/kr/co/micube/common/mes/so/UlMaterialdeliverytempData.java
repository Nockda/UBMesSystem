package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlMaterialdeliverytempData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Reqseq = "REQSEQ";

	public static final String Reqserl = "REQSERL";

	public static final String Reqno = "REQNO";

	public static final String Consumablelotid = "CONSUMABLELOTID";

	public static final String Consumabledefid = "CONSUMABLEDEFID";

	public static final String Itemseq = "ITEMSEQ";

	public static final String Deliveryqty = "DELIVERYQTY";

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

	public UlMaterialdeliverytempData() {
		this(new UlMaterialdeliverytempKey()); 
	}

	public UlMaterialdeliverytempData(UlMaterialdeliverytempKey key) {
		super(key, "UlMaterialdeliverytemp");
		this.txnInfo().setHistoryTable(true);
	}


	public Integer getReqseq() {
		return this.repository().getInteger(UlMaterialdeliverytempData.Reqseq);
	}

	public UlMaterialdeliverytempData setReqseq(Integer Reqseq) {
		this.repository().set(UlMaterialdeliverytempData.Reqseq, Reqseq);
		return this;
	}

	public Integer getReqserl() {
		return this.repository().getInteger(UlMaterialdeliverytempData.Reqserl);
	}

	public UlMaterialdeliverytempData setReqserl(Integer Reqserl) {
		this.repository().set(UlMaterialdeliverytempData.Reqserl, Reqserl);
		return this;
	}

	public String getReqno() {
		return this.repository().getString(UlMaterialdeliverytempData.Reqno);
	}

	public UlMaterialdeliverytempData setReqno(String Reqno) {
		this.repository().set(UlMaterialdeliverytempData.Reqno, Reqno);
		return this;
	}

	public String getConsumablelotid() {
		return this.repository().getString(UlMaterialdeliverytempData.Consumablelotid);
	}

	public UlMaterialdeliverytempData setConsumablelotid(String Consumablelotid) {
		this.repository().set(UlMaterialdeliverytempData.Consumablelotid, Consumablelotid);
		return this;
	}

	public String getConsumabledefid() {
		return this.repository().getString(UlMaterialdeliverytempData.Consumabledefid);
	}

	public UlMaterialdeliverytempData setConsumabledefid(String Consumabledefid) {
		this.repository().set(UlMaterialdeliverytempData.Consumabledefid, Consumabledefid);
		return this;
	}

	public Integer getItemseq() {
		return this.repository().getInteger(UlMaterialdeliverytempData.Itemseq);
	}

	public UlMaterialdeliverytempData setItemseq(Integer Itemseq) {
		this.repository().set(UlMaterialdeliverytempData.Itemseq, Itemseq);
		return this;
	}

	public Double getDeliveryqty() {
		return this.repository().getDouble(UlMaterialdeliverytempData.Deliveryqty);
	}

	public UlMaterialdeliverytempData setDeliveryqty(Double Deliveryqty) {
		this.repository().set(UlMaterialdeliverytempData.Deliveryqty, Deliveryqty);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlMaterialdeliverytempData.Description);
	}

	public UlMaterialdeliverytempData setDescription(String Description) {
		this.repository().set(UlMaterialdeliverytempData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlMaterialdeliverytempData.Creator);
	}

	public UlMaterialdeliverytempData setCreator(String Creator) {
		this.repository().set(UlMaterialdeliverytempData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlMaterialdeliverytempData.Createdtime);
	}

	public UlMaterialdeliverytempData setCreatedtime(Date Createdtime) {
		this.repository().set(UlMaterialdeliverytempData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlMaterialdeliverytempData.Modifier);
	}

	public UlMaterialdeliverytempData setModifier(String Modifier) {
		this.repository().set(UlMaterialdeliverytempData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlMaterialdeliverytempData.Modifiedtime);
	}

	public UlMaterialdeliverytempData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlMaterialdeliverytempData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlMaterialdeliverytempData.Txnid);
	}

	public UlMaterialdeliverytempData setTxnid(String Txnid) {
		this.repository().set(UlMaterialdeliverytempData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlMaterialdeliverytempData.Txnuser);
	}

	public UlMaterialdeliverytempData setTxnuser(String Txnuser) {
		this.repository().set(UlMaterialdeliverytempData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlMaterialdeliverytempData.Txntime);
	}

	public UlMaterialdeliverytempData setTxntime(Date Txntime) {
		this.repository().set(UlMaterialdeliverytempData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlMaterialdeliverytempData.Txngrouphistkey);
	}

	public UlMaterialdeliverytempData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlMaterialdeliverytempData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlMaterialdeliverytempData.Txnreasoncodeclass);
	}

	public UlMaterialdeliverytempData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlMaterialdeliverytempData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlMaterialdeliverytempData.Txnreasoncode);
	}

	public UlMaterialdeliverytempData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlMaterialdeliverytempData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlMaterialdeliverytempData.Txncomment);
	}

	public UlMaterialdeliverytempData setTxncomment(String Txncomment) {
		this.repository().set(UlMaterialdeliverytempData.Txncomment, Txncomment);
		return this;
	}


}