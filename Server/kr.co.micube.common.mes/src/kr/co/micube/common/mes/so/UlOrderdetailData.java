package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlOrderdetailData extends SQLData {

	public static final String Seq = "SEQ";

	public static final String Poseq = "POSEQ";

	public static final String Poserl = "POSERL";

	public static final String Pono = "PONO";

	public static final String Delvdate = "DELVDATE";

	public static final String Delvseq = "DELVSEQ";

	public static final String Delvserl = "DELVSERL";

	public static final String Delvno = "DELVNO";

	public static final String Itemno = "ITEMNO";

	public static final String Itemseq = "ITEMSEQ";

	public static final String Whseq = "WHSEQ";

	public static final String Inqty = "INQTY";

	public static final String Lotsize = "LOTSIZE";

	public static final String Completeyn = "COMPLETEYN";

	public static final String Tossyn = "TOSSYN";

	public static final String Custseq = "CUSTSEQ";

	public static final String Custname = "CUSTNAME";

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

	public UlOrderdetailData() {
		this(new UlOrderdetailKey()); 
	}

	public UlOrderdetailData(UlOrderdetailKey key) {
		super(key, "UlOrderdetail");
	}


	public Integer getPoseq() {
		return this.repository().getInteger(UlOrderdetailData.Poseq);
	}

	public UlOrderdetailData setPoseq(Integer Poseq) {
		this.repository().set(UlOrderdetailData.Poseq, Poseq);
		return this;
	}

	public Integer getPoserl() {
		return this.repository().getInteger(UlOrderdetailData.Poserl);
	}

	public UlOrderdetailData setPoserl(Integer Poserl) {
		this.repository().set(UlOrderdetailData.Poserl, Poserl);
		return this;
	}

	public String getPono() {
		return this.repository().getString(UlOrderdetailData.Pono);
	}

	public UlOrderdetailData setPono(String Pono) {
		this.repository().set(UlOrderdetailData.Pono, Pono);
		return this;
	}

	public Date getDelvdate() {
		return this.repository().getDate(UlOrderdetailData.Delvdate);
	}

	public UlOrderdetailData setDelvdate(Date Delvdate) {
		this.repository().set(UlOrderdetailData.Delvdate, Delvdate);
		return this;
	}

	public Integer getDelvseq() {
		return this.repository().getInteger(UlOrderdetailData.Delvseq);
	}

	public UlOrderdetailData setDelvseq(Integer Delvseq) {
		this.repository().set(UlOrderdetailData.Delvseq, Delvseq);
		return this;
	}

	public Integer getDelvserl() {
		return this.repository().getInteger(UlOrderdetailData.Delvserl);
	}

	public UlOrderdetailData setDelvserl(Integer Delvserl) {
		this.repository().set(UlOrderdetailData.Delvserl, Delvserl);
		return this;
	}

	public String getDelvno() {
		return this.repository().getString(UlOrderdetailData.Delvno);
	}

	public UlOrderdetailData setDelvno(String Delvno) {
		this.repository().set(UlOrderdetailData.Delvno, Delvno);
		return this;
	}

	public String getItemno() {
		return this.repository().getString(UlOrderdetailData.Itemno);
	}

	public UlOrderdetailData setItemno(String Itemno) {
		this.repository().set(UlOrderdetailData.Itemno, Itemno);
		return this;
	}

	public Integer getItemseq() {
		return this.repository().getInteger(UlOrderdetailData.Itemseq);
	}

	public UlOrderdetailData setItemseq(Integer Itemseq) {
		this.repository().set(UlOrderdetailData.Itemseq, Itemseq);
		return this;
	}

	public Integer getWhseq() {
		return this.repository().getInteger(UlOrderdetailData.Whseq);
	}

	public UlOrderdetailData setWhseq(Integer Whseq) {
		this.repository().set(UlOrderdetailData.Whseq, Whseq);
		return this;
	}

	public Double getInqty() {
		return this.repository().getDouble(UlOrderdetailData.Inqty);
	}

	public UlOrderdetailData setInqty(Double Inqty) {
		this.repository().set(UlOrderdetailData.Inqty, Inqty);
		return this;
	}

	public Integer getLotsize() {
		return this.repository().getInteger(UlOrderdetailData.Lotsize);
	}

	public UlOrderdetailData setLotsize(Integer Lotsize) {
		this.repository().set(UlOrderdetailData.Lotsize, Lotsize);
		return this;
	}

	public String getCompleteyn() {
		return this.repository().getString(UlOrderdetailData.Completeyn);
	}

	public UlOrderdetailData setCompleteyn(String Completeyn) {
		this.repository().set(UlOrderdetailData.Completeyn, Completeyn);
		return this;
	}

	public String getTossyn() {
		return this.repository().getString(UlOrderdetailData.Tossyn);
	}

	public UlOrderdetailData setTossyn(String Tossyn) {
		this.repository().set(UlOrderdetailData.Tossyn, Tossyn);
		return this;
	}

	public String getCustseq() {
		return this.repository().getString(UlOrderdetailData.Custseq);
	}

	public UlOrderdetailData setCustseq(String Custseq) {
		this.repository().set(UlOrderdetailData.Custseq, Custseq);
		return this;
	}

	public String getCustname() {
		return this.repository().getString(UlOrderdetailData.Custname);
	}

	public UlOrderdetailData setCustname(String Custname) {
		this.repository().set(UlOrderdetailData.Custname, Custname);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlOrderdetailData.Description);
	}

	public UlOrderdetailData setDescription(String Description) {
		this.repository().set(UlOrderdetailData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlOrderdetailData.Creator);
	}

	public UlOrderdetailData setCreator(String Creator) {
		this.repository().set(UlOrderdetailData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlOrderdetailData.Createdtime);
	}

	public UlOrderdetailData setCreatedtime(Date Createdtime) {
		this.repository().set(UlOrderdetailData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlOrderdetailData.Modifier);
	}

	public UlOrderdetailData setModifier(String Modifier) {
		this.repository().set(UlOrderdetailData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlOrderdetailData.Modifiedtime);
	}

	public UlOrderdetailData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlOrderdetailData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(UlOrderdetailData.Txnid);
	}

	public UlOrderdetailData setTxnid(String Txnid) {
		this.repository().set(UlOrderdetailData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlOrderdetailData.Txnuser);
	}

	public UlOrderdetailData setTxnuser(String Txnuser) {
		this.repository().set(UlOrderdetailData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlOrderdetailData.Txntime);
	}

	public UlOrderdetailData setTxntime(Date Txntime) {
		this.repository().set(UlOrderdetailData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlOrderdetailData.Txngrouphistkey);
	}

	public UlOrderdetailData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlOrderdetailData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlOrderdetailData.Txnreasoncodeclass);
	}

	public UlOrderdetailData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlOrderdetailData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlOrderdetailData.Txnreasoncode);
	}

	public UlOrderdetailData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlOrderdetailData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlOrderdetailData.Txncomment);
	}

	public UlOrderdetailData setTxncomment(String Txncomment) {
		this.repository().set(UlOrderdetailData.Txncomment, Txncomment);
		return this;
	}


}