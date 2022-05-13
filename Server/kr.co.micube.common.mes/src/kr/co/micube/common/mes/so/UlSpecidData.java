package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlSpecidData extends SQLData {

	public static final String Specdefid = "SPECDEFID";

	public static final String Seq = "SEQ";

	public static final String Specdefname = "SPECDEFNAME";

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Subprocesssegmentid = "SUBPROCESSSEGMENTID";

	public static final String Specseq = "SPECSEQ";

	public static final String Isresult = "ISRESULT";

	public static final String Isoutsourcing = "ISOUTSOURCING";

	public static final String Isdivide = "ISDIVIDE";

	public static final String Dictionaryid = "DICTIONARYID";

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

	public UlSpecidData() {
		this(new UlSpecidKey()); 
	}

	public UlSpecidData(UlSpecidKey key) {
		super(key, "UlSpecid");
	}


	public String getSpecdefname() {
		return this.repository().getString(UlSpecidData.Specdefname);
	}

	public UlSpecidData setSpecdefname(String Specdefname) {
		this.repository().set(UlSpecidData.Specdefname, Specdefname);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(UlSpecidData.Processsegmentid);
	}

	public UlSpecidData setProcesssegmentid(String Processsegmentid) {
		this.repository().set(UlSpecidData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getSubprocesssegmentid() {
		return this.repository().getString(UlSpecidData.Subprocesssegmentid);
	}

	public UlSpecidData setSubprocesssegmentid(String Subprocesssegmentid) {
		this.repository().set(UlSpecidData.Subprocesssegmentid, Subprocesssegmentid);
		return this;
	}

	public Integer getSpecseq() {
		return this.repository().getInteger(UlSpecidData.Specseq);
	}

	public UlSpecidData setSpecseq(Integer Specseq) {
		this.repository().set(UlSpecidData.Specseq, Specseq);
		return this;
	}

	public String getIsresult() {
		return this.repository().getString(UlSpecidData.Isresult);
	}

	public UlSpecidData setIsresult(String Isresult) {
		this.repository().set(UlSpecidData.Isresult, Isresult);
		return this;
	}

	public String getIsoutsourcing() {
		return this.repository().getString(UlSpecidData.Isoutsourcing);
	}

	public UlSpecidData setIsoutsourcing(String Isoutsourcing) {
		this.repository().set(UlSpecidData.Isoutsourcing, Isoutsourcing);
		return this;
	}

	public String getIsdivide() {
		return this.repository().getString(UlSpecidData.Isdivide);
	}

	public UlSpecidData setIsdivide(String Isdivide) {
		this.repository().set(UlSpecidData.Isdivide, Isdivide);
		return this;
	}

	public String getDictionaryid() {
		return this.repository().getString(UlSpecidData.Dictionaryid);
	}

	public UlSpecidData setDictionaryid(String Dictionaryid) {
		this.repository().set(UlSpecidData.Dictionaryid, Dictionaryid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlSpecidData.Description);
	}

	public UlSpecidData setDescription(String Description) {
		this.repository().set(UlSpecidData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlSpecidData.Creator);
	}

	public UlSpecidData setCreator(String Creator) {
		this.repository().set(UlSpecidData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlSpecidData.Createdtime);
	}

	public UlSpecidData setCreatedtime(Date Createdtime) {
		this.repository().set(UlSpecidData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlSpecidData.Modifier);
	}

	public UlSpecidData setModifier(String Modifier) {
		this.repository().set(UlSpecidData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlSpecidData.Modifiedtime);
	}

	public UlSpecidData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlSpecidData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(UlSpecidData.Lasttxnhistkey);
	}

	public UlSpecidData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(UlSpecidData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(UlSpecidData.Lasttxnid);
	}

	public UlSpecidData setLasttxnid(String Lasttxnid) {
		this.repository().set(UlSpecidData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(UlSpecidData.Lasttxnuser);
	}

	public UlSpecidData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(UlSpecidData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(UlSpecidData.Lasttxntime);
	}

	public UlSpecidData setLasttxntime(Date Lasttxntime) {
		this.repository().set(UlSpecidData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(UlSpecidData.Lasttxncomment);
	}

	public UlSpecidData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(UlSpecidData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlSpecidData.Validstate);
	}

	public UlSpecidData setValidstate(String Validstate) {
		this.repository().set(UlSpecidData.Validstate, Validstate);
		return this;
	}


}