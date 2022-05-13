package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlMaterialdeliveryreqData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Reqseq = "REQSEQ";

	public static final String Reqserl = "REQSERL";

	public static final String Reqno = "REQNO";

	public static final String Itemno = "ITEMNO";

	public static final String Itemseq = "ITEMSEQ";

	public static final String Completeyn = "COMPLETEYN";

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

	public static final String Requestqty = "REQUESTQTY";

	public UlMaterialdeliveryreqData() {
		this(new UlMaterialdeliveryreqKey()); 
	}

	public UlMaterialdeliveryreqData(UlMaterialdeliveryreqKey key) {
		super(key, "UlMaterialdeliveryreq");
	}


	public Integer getReqseq() {
		return this.repository().getInteger(UlMaterialdeliveryreqData.Reqseq);
	}

	public UlMaterialdeliveryreqData setReqseq(Integer Reqseq) {
		this.repository().set(UlMaterialdeliveryreqData.Reqseq, Reqseq);
		return this;
	}

	public Integer getReqserl() {
		return this.repository().getInteger(UlMaterialdeliveryreqData.Reqserl);
	}

	public UlMaterialdeliveryreqData setReqserl(Integer Reqserl) {
		this.repository().set(UlMaterialdeliveryreqData.Reqserl, Reqserl);
		return this;
	}

	public String getReqno() {
		return this.repository().getString(UlMaterialdeliveryreqData.Reqno);
	}

	public UlMaterialdeliveryreqData setReqno(String Reqno) {
		this.repository().set(UlMaterialdeliveryreqData.Reqno, Reqno);
		return this;
	}

	public String getItemno() {
		return this.repository().getString(UlMaterialdeliveryreqData.Itemno);
	}

	public UlMaterialdeliveryreqData setItemno(String Itemno) {
		this.repository().set(UlMaterialdeliveryreqData.Itemno, Itemno);
		return this;
	}

	public Integer getItemseq() {
		return this.repository().getInteger(UlMaterialdeliveryreqData.Itemseq);
	}

	public UlMaterialdeliveryreqData setItemseq(Integer Itemseq) {
		this.repository().set(UlMaterialdeliveryreqData.Itemseq, Itemseq);
		return this;
	}

	public String getCompleteyn() {
		return this.repository().getString(UlMaterialdeliveryreqData.Completeyn);
	}

	public UlMaterialdeliveryreqData setCompleteyn(String Completeyn) {
		this.repository().set(UlMaterialdeliveryreqData.Completeyn, Completeyn);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlMaterialdeliveryreqData.Description);
	}

	public UlMaterialdeliveryreqData setDescription(String Description) {
		this.repository().set(UlMaterialdeliveryreqData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlMaterialdeliveryreqData.Creator);
	}

	public UlMaterialdeliveryreqData setCreator(String Creator) {
		this.repository().set(UlMaterialdeliveryreqData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlMaterialdeliveryreqData.Createdtime);
	}

	public UlMaterialdeliveryreqData setCreatedtime(Date Createdtime) {
		this.repository().set(UlMaterialdeliveryreqData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlMaterialdeliveryreqData.Modifier);
	}

	public UlMaterialdeliveryreqData setModifier(String Modifier) {
		this.repository().set(UlMaterialdeliveryreqData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlMaterialdeliveryreqData.Modifiedtime);
	}

	public UlMaterialdeliveryreqData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlMaterialdeliveryreqData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlMaterialdeliveryreqData.Txnid);
	}

	public UlMaterialdeliveryreqData setTxnid(String Txnid) {
		this.repository().set(UlMaterialdeliveryreqData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlMaterialdeliveryreqData.Txnuser);
	}

	public UlMaterialdeliveryreqData setTxnuser(String Txnuser) {
		this.repository().set(UlMaterialdeliveryreqData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlMaterialdeliveryreqData.Txntime);
	}

	public UlMaterialdeliveryreqData setTxntime(Date Txntime) {
		this.repository().set(UlMaterialdeliveryreqData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlMaterialdeliveryreqData.Txngrouphistkey);
	}

	public UlMaterialdeliveryreqData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlMaterialdeliveryreqData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlMaterialdeliveryreqData.Txnreasoncodeclass);
	}

	public UlMaterialdeliveryreqData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlMaterialdeliveryreqData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlMaterialdeliveryreqData.Txnreasoncode);
	}

	public UlMaterialdeliveryreqData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlMaterialdeliveryreqData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlMaterialdeliveryreqData.Txncomment);
	}

	public UlMaterialdeliveryreqData setTxncomment(String Txncomment) {
		this.repository().set(UlMaterialdeliveryreqData.Txncomment, Txncomment);
		return this;
	}

	public Double getRequestqty() {
		return this.repository().getDouble(UlMaterialdeliveryreqData.Requestqty);
	}

	public UlMaterialdeliveryreqData setRequestqty(Double Requestqty) {
		this.repository().set(UlMaterialdeliveryreqData.Requestqty, Requestqty);
		return this;
	}


}