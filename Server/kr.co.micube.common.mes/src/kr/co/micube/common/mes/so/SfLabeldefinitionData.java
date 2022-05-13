package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfLabeldefinitionData extends SQLData {

	public static final String Labelid = "LABELID";

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

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Lasttxnid = "LASTTXNID";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public SfLabeldefinitionData() {
		this(new SfLabeldefinitionKey()); 
	}

	public SfLabeldefinitionData(SfLabeldefinitionKey key) {
		super(key, "SfLabeldefinition");
	}


	public String getLabelname() {
		return this.repository().getString(SfLabeldefinitionData.Labelname);
	}

	public SfLabeldefinitionData setLabelname(String Labelname) {
		this.repository().set(SfLabeldefinitionData.Labelname, Labelname);
		return this;
	}

	public String getLabeltype() {
		return this.repository().getString(SfLabeldefinitionData.Labeltype);
	}

	public SfLabeldefinitionData setLabeltype(String Labeltype) {
		this.repository().set(SfLabeldefinitionData.Labeltype, Labeltype);
		return this;
	}

	public Double getPageheight() {
		return this.repository().getDouble(SfLabeldefinitionData.Pageheight);
	}

	public SfLabeldefinitionData setPageheight(Double Pageheight) {
		this.repository().set(SfLabeldefinitionData.Pageheight, Pageheight);
		return this;
	}

	public Double getPagewidth() {
		return this.repository().getDouble(SfLabeldefinitionData.Pagewidth);
	}

	public SfLabeldefinitionData setPagewidth(Double Pagewidth) {
		this.repository().set(SfLabeldefinitionData.Pagewidth, Pagewidth);
		return this;
	}

	public String getFilename() {
		return this.repository().getString(SfLabeldefinitionData.Filename);
	}

	public SfLabeldefinitionData setFilename(String Filename) {
		this.repository().set(SfLabeldefinitionData.Filename, Filename);
		return this;
	}

	public String getFileext() {
		return this.repository().getString(SfLabeldefinitionData.Fileext);
	}

	public SfLabeldefinitionData setFileext(String Fileext) {
		this.repository().set(SfLabeldefinitionData.Fileext, Fileext);
		return this;
	}

	public byte[] getLabeldata() throws DatabaseException {
		return this.repository().getBlob(SfLabeldefinitionData.Labeldata);
	}

	public SfLabeldefinitionData setLabeldata(byte[] Labeldata) {
		this.repository().set(SfLabeldefinitionData.Labeldata, Labeldata);
		return this;
	}

	public String getQueryid() {
		return this.repository().getString(SfLabeldefinitionData.Queryid);
	}

	public SfLabeldefinitionData setQueryid(String Queryid) {
		this.repository().set(SfLabeldefinitionData.Queryid, Queryid);
		return this;
	}

	public String getQueryversion() {
		return this.repository().getString(SfLabeldefinitionData.Queryversion);
	}

	public SfLabeldefinitionData setQueryversion(String Queryversion) {
		this.repository().set(SfLabeldefinitionData.Queryversion, Queryversion);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfLabeldefinitionData.Description);
	}

	public SfLabeldefinitionData setDescription(String Description) {
		this.repository().set(SfLabeldefinitionData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfLabeldefinitionData.Creator);
	}

	public SfLabeldefinitionData setCreator(String Creator) {
		this.repository().set(SfLabeldefinitionData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfLabeldefinitionData.Createdtime);
	}

	public SfLabeldefinitionData setCreatedtime(Date Createdtime) {
		this.repository().set(SfLabeldefinitionData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfLabeldefinitionData.Modifier);
	}

	public SfLabeldefinitionData setModifier(String Modifier) {
		this.repository().set(SfLabeldefinitionData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfLabeldefinitionData.Modifiedtime);
	}

	public SfLabeldefinitionData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfLabeldefinitionData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfLabeldefinitionData.Lasttxnhistkey);
	}

	public SfLabeldefinitionData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfLabeldefinitionData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfLabeldefinitionData.Lasttxnid);
	}

	public SfLabeldefinitionData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfLabeldefinitionData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfLabeldefinitionData.Lasttxnuser);
	}

	public SfLabeldefinitionData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfLabeldefinitionData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfLabeldefinitionData.Lasttxntime);
	}

	public SfLabeldefinitionData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfLabeldefinitionData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfLabeldefinitionData.Lasttxncomment);
	}

	public SfLabeldefinitionData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfLabeldefinitionData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfLabeldefinitionData.Validstate);
	}

	public SfLabeldefinitionData setValidstate(String Validstate) {
		this.repository().set(SfLabeldefinitionData.Validstate, Validstate);
		return this;
	}


}