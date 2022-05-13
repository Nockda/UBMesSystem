package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfLabeldefinitionHistoryData extends SQLData {

	public static final String Labelid = "LABELID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Labelname = "LABELNAME";

	public static final String Labeltype = "LABELTYPE";

	public static final String Pageheight = "PAGEHEIGHT";

	public static final String Pagewidth = "PAGEWIDTH";

	public static final String Filename = "FILENAME";

	public static final String Fileext = "FILEEXT";

	public static final String Labeldata = "LABELDATA";

	public static final String Queryid = "QUERYID";

	public static final String Queryversion = "QUERYVERSION";

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

	public SfLabeldefinitionHistoryData() {
		this(new SfLabeldefinitionHistoryKey()); 
	}

	public SfLabeldefinitionHistoryData(SfLabeldefinitionHistoryKey key) {
		super(key, "SfLabeldefinitionHistory");
	}


	public String getLabelname() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Labelname);
	}

	public SfLabeldefinitionHistoryData setLabelname(String Labelname) {
		this.repository().set(SfLabeldefinitionHistoryData.Labelname, Labelname);
		return this;
	}

	public String getLabeltype() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Labeltype);
	}

	public SfLabeldefinitionHistoryData setLabeltype(String Labeltype) {
		this.repository().set(SfLabeldefinitionHistoryData.Labeltype, Labeltype);
		return this;
	}

	public Double getPageheight() {
		return this.repository().getDouble(SfLabeldefinitionHistoryData.Pageheight);
	}

	public SfLabeldefinitionHistoryData setPageheight(Double Pageheight) {
		this.repository().set(SfLabeldefinitionHistoryData.Pageheight, Pageheight);
		return this;
	}

	public Double getPagewidth() {
		return this.repository().getDouble(SfLabeldefinitionHistoryData.Pagewidth);
	}

	public SfLabeldefinitionHistoryData setPagewidth(Double Pagewidth) {
		this.repository().set(SfLabeldefinitionHistoryData.Pagewidth, Pagewidth);
		return this;
	}

	public String getFilename() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Filename);
	}

	public SfLabeldefinitionHistoryData setFilename(String Filename) {
		this.repository().set(SfLabeldefinitionHistoryData.Filename, Filename);
		return this;
	}

	public String getFileext() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Fileext);
	}

	public SfLabeldefinitionHistoryData setFileext(String Fileext) {
		this.repository().set(SfLabeldefinitionHistoryData.Fileext, Fileext);
		return this;
	}

	public byte[] getLabeldata() throws DatabaseException {
		return this.repository().getBlob(SfLabeldefinitionHistoryData.Labeldata);
	}

	public SfLabeldefinitionHistoryData setLabeldata(byte[] Labeldata) {
		this.repository().set(SfLabeldefinitionHistoryData.Labeldata, Labeldata);
		return this;
	}

	public String getQueryid() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Queryid);
	}

	public SfLabeldefinitionHistoryData setQueryid(String Queryid) {
		this.repository().set(SfLabeldefinitionHistoryData.Queryid, Queryid);
		return this;
	}

	public String getQueryversion() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Queryversion);
	}

	public SfLabeldefinitionHistoryData setQueryversion(String Queryversion) {
		this.repository().set(SfLabeldefinitionHistoryData.Queryversion, Queryversion);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Description);
	}

	public SfLabeldefinitionHistoryData setDescription(String Description) {
		this.repository().set(SfLabeldefinitionHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Creator);
	}

	public SfLabeldefinitionHistoryData setCreator(String Creator) {
		this.repository().set(SfLabeldefinitionHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfLabeldefinitionHistoryData.Createdtime);
	}

	public SfLabeldefinitionHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(SfLabeldefinitionHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Modifier);
	}

	public SfLabeldefinitionHistoryData setModifier(String Modifier) {
		this.repository().set(SfLabeldefinitionHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfLabeldefinitionHistoryData.Modifiedtime);
	}

	public SfLabeldefinitionHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfLabeldefinitionHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Txnid);
	}

	public SfLabeldefinitionHistoryData setTxnid(String Txnid) {
		this.repository().set(SfLabeldefinitionHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Txnuser);
	}

	public SfLabeldefinitionHistoryData setTxnuser(String Txnuser) {
		this.repository().set(SfLabeldefinitionHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfLabeldefinitionHistoryData.Txntime);
	}

	public SfLabeldefinitionHistoryData setTxntime(Date Txntime) {
		this.repository().set(SfLabeldefinitionHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Txngrouphistkey);
	}

	public SfLabeldefinitionHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfLabeldefinitionHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Txnreasoncodeclass);
	}

	public SfLabeldefinitionHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfLabeldefinitionHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Txnreasoncode);
	}

	public SfLabeldefinitionHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfLabeldefinitionHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Txncomment);
	}

	public SfLabeldefinitionHistoryData setTxncomment(String Txncomment) {
		this.repository().set(SfLabeldefinitionHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfLabeldefinitionHistoryData.Validstate);
	}

	public SfLabeldefinitionHistoryData setValidstate(String Validstate) {
		this.repository().set(SfLabeldefinitionHistoryData.Validstate, Validstate);
		return this;
	}


}