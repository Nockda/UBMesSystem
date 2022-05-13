package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlSpecdetailData extends SQLData {

	public static final String Specdefid = "SPECDEFID";

	public static final String Subprocesssegmentid = "SUBPROCESSSEGMENTID";

	public static final String Itemid = "ITEMID";

	public static final String Spectype = "SPECTYPE";

	public static final String Lsl = "LSL";

	public static final String Csl = "CSL";

	public static final String Usl = "USL";

	public static final String Target = "TARGET";

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

	public UlSpecdetailData() {
		this(new UlSpecdetailKey()); 
	}

	public UlSpecdetailData(UlSpecdetailKey key) {
		super(key, "UlSpecdetail");
	}


	public String getSpectype() {
		return this.repository().getString(UlSpecdetailData.Spectype);
	}

	public UlSpecdetailData setSpectype(String Spectype) {
		this.repository().set(UlSpecdetailData.Spectype, Spectype);
		return this;
	}

	public Double getLsl() {
		return this.repository().getDouble(UlSpecdetailData.Lsl);
	}

	public UlSpecdetailData setLsl(Double Lsl) {
		this.repository().set(UlSpecdetailData.Lsl, Lsl);
		return this;
	}

	public Double getCsl() {
		return this.repository().getDouble(UlSpecdetailData.Csl);
	}

	public UlSpecdetailData setCsl(Double Csl) {
		this.repository().set(UlSpecdetailData.Csl, Csl);
		return this;
	}

	public Double getUsl() {
		return this.repository().getDouble(UlSpecdetailData.Usl);
	}

	public UlSpecdetailData setUsl(Double Usl) {
		this.repository().set(UlSpecdetailData.Usl, Usl);
		return this;
	}

	public String getTarget() {
		return this.repository().getString(UlSpecdetailData.Target);
	}

	public UlSpecdetailData setTarget(String Target) {
		this.repository().set(UlSpecdetailData.Target, Target);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlSpecdetailData.Creator);
	}

	public UlSpecdetailData setCreator(String Creator) {
		this.repository().set(UlSpecdetailData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlSpecdetailData.Createdtime);
	}

	public UlSpecdetailData setCreatedtime(Date Createdtime) {
		this.repository().set(UlSpecdetailData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlSpecdetailData.Modifier);
	}

	public UlSpecdetailData setModifier(String Modifier) {
		this.repository().set(UlSpecdetailData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlSpecdetailData.Modifiedtime);
	}

	public UlSpecdetailData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlSpecdetailData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(UlSpecdetailData.Lasttxnhistkey);
	}

	public UlSpecdetailData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(UlSpecdetailData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(UlSpecdetailData.Lasttxnid);
	}

	public UlSpecdetailData setLasttxnid(String Lasttxnid) {
		this.repository().set(UlSpecdetailData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(UlSpecdetailData.Lasttxnuser);
	}

	public UlSpecdetailData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(UlSpecdetailData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(UlSpecdetailData.Lasttxntime);
	}

	public UlSpecdetailData setLasttxntime(Date Lasttxntime) {
		this.repository().set(UlSpecdetailData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(UlSpecdetailData.Lasttxncomment);
	}

	public UlSpecdetailData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(UlSpecdetailData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlSpecdetailData.Validstate);
	}

	public UlSpecdetailData setValidstate(String Validstate) {
		this.repository().set(UlSpecdetailData.Validstate, Validstate);
		return this;
	}


}