package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtSubsegmentspecdetailData extends SQLData {

	public static final String Specdefid = "SPECDEFID";

	public static final String Specsequence = "SPECSEQUENCE";

	public static final String Parameterid = "PARAMETERID";

	public static final String Spectype = "SPECTYPE";

	public static final String Lsl = "LSL";

	public static final String Csl = "CSL";

	public static final String Usl = "USL";

	public static final String Target = "TARGET";

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

	public static final String Ismeasure = "ISMEASURE";

	public static final String Displaysequence = "DISPLAYSEQUENCE";

	public static final String Isspecforce = "ISSPECFORCE";

	public static final String Specdefidversion = "SPECDEFIDVERSION";

	public CtSubsegmentspecdetailData() {
		this(new CtSubsegmentspecdetailKey()); 
	}

	public CtSubsegmentspecdetailData(CtSubsegmentspecdetailKey key) {
		super(key, "CtSubsegmentspecdetail");
	}


	public String getSpectype() {
		return this.repository().getString(CtSubsegmentspecdetailData.Spectype);
	}

	public CtSubsegmentspecdetailData setSpectype(String Spectype) {
		this.repository().set(CtSubsegmentspecdetailData.Spectype, Spectype);
		return this;
	}

	public Double getLsl() {
		return this.repository().getDouble(CtSubsegmentspecdetailData.Lsl);
	}

	public CtSubsegmentspecdetailData setLsl(Double Lsl) {
		this.repository().set(CtSubsegmentspecdetailData.Lsl, Lsl);
		return this;
	}

	public Double getCsl() {
		return this.repository().getDouble(CtSubsegmentspecdetailData.Csl);
	}

	public CtSubsegmentspecdetailData setCsl(Double Csl) {
		this.repository().set(CtSubsegmentspecdetailData.Csl, Csl);
		return this;
	}

	public Double getUsl() {
		return this.repository().getDouble(CtSubsegmentspecdetailData.Usl);
	}

	public CtSubsegmentspecdetailData setUsl(Double Usl) {
		this.repository().set(CtSubsegmentspecdetailData.Usl, Usl);
		return this;
	}

	public String getTarget() {
		return this.repository().getString(CtSubsegmentspecdetailData.Target);
	}

	public CtSubsegmentspecdetailData setTarget(String Target) {
		this.repository().set(CtSubsegmentspecdetailData.Target, Target);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtSubsegmentspecdetailData.Description);
	}

	public CtSubsegmentspecdetailData setDescription(String Description) {
		this.repository().set(CtSubsegmentspecdetailData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtSubsegmentspecdetailData.Creator);
	}

	public CtSubsegmentspecdetailData setCreator(String Creator) {
		this.repository().set(CtSubsegmentspecdetailData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtSubsegmentspecdetailData.Createdtime);
	}

	public CtSubsegmentspecdetailData setCreatedtime(Date Createdtime) {
		this.repository().set(CtSubsegmentspecdetailData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtSubsegmentspecdetailData.Modifier);
	}

	public CtSubsegmentspecdetailData setModifier(String Modifier) {
		this.repository().set(CtSubsegmentspecdetailData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtSubsegmentspecdetailData.Modifiedtime);
	}

	public CtSubsegmentspecdetailData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtSubsegmentspecdetailData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtSubsegmentspecdetailData.Lasttxnhistkey);
	}

	public CtSubsegmentspecdetailData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtSubsegmentspecdetailData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtSubsegmentspecdetailData.Lasttxnid);
	}

	public CtSubsegmentspecdetailData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtSubsegmentspecdetailData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtSubsegmentspecdetailData.Lasttxnuser);
	}

	public CtSubsegmentspecdetailData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtSubsegmentspecdetailData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtSubsegmentspecdetailData.Lasttxntime);
	}

	public CtSubsegmentspecdetailData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtSubsegmentspecdetailData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtSubsegmentspecdetailData.Lasttxncomment);
	}

	public CtSubsegmentspecdetailData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtSubsegmentspecdetailData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtSubsegmentspecdetailData.Validstate);
	}

	public CtSubsegmentspecdetailData setValidstate(String Validstate) {
		this.repository().set(CtSubsegmentspecdetailData.Validstate, Validstate);
		return this;
	}

	public String getIsmeasure() {
		return this.repository().getString(CtSubsegmentspecdetailData.Ismeasure);
	}

	public CtSubsegmentspecdetailData setIsmeasure(String Ismeasure) {
		this.repository().set(CtSubsegmentspecdetailData.Ismeasure, Ismeasure);
		return this;
	}

	public Double getDisplaysequence() {
		return this.repository().getDouble(CtSubsegmentspecdetailData.Displaysequence);
	}

	public CtSubsegmentspecdetailData setDisplaysequence(Double Displaysequence) {
		this.repository().set(CtSubsegmentspecdetailData.Displaysequence, Displaysequence);
		return this;
	}

	public String getIsspecforce() {
		return this.repository().getString(CtSubsegmentspecdetailData.Isspecforce);
	}

	public CtSubsegmentspecdetailData setIsspecforce(String Isspecforce) {
		this.repository().set(CtSubsegmentspecdetailData.Isspecforce, Isspecforce);
		return this;
	}


}