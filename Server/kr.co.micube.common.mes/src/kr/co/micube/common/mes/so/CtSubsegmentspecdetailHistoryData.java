package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtSubsegmentspecdetailHistoryData extends SQLData {

	public static final String Specsequence = "SPECSEQUENCE";

	public static final String Parameterid = "PARAMETERID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Specdefid = "SPECDEFID";

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

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public static final String Ismeasure = "ISMEASURE";

	public static final String Displaysequence = "DISPLAYSEQUENCE";

	public static final String Isspecforce = "ISSPECFORCE";

	public CtSubsegmentspecdetailHistoryData() {
		this(new CtSubsegmentspecdetailHistoryKey()); 
	}

	public CtSubsegmentspecdetailHistoryData(CtSubsegmentspecdetailHistoryKey key) {
		super(key, "CtSubsegmentspecdetailHistory");
	}


	public String getSpectype() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Spectype);
	}

	public CtSubsegmentspecdetailHistoryData setSpectype(String Spectype) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Spectype, Spectype);
		return this;
	}

	public Double getLsl() {
		return this.repository().getDouble(CtSubsegmentspecdetailHistoryData.Lsl);
	}

	public CtSubsegmentspecdetailHistoryData setLsl(Double Lsl) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Lsl, Lsl);
		return this;
	}

	public Double getCsl() {
		return this.repository().getDouble(CtSubsegmentspecdetailHistoryData.Csl);
	}

	public CtSubsegmentspecdetailHistoryData setCsl(Double Csl) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Csl, Csl);
		return this;
	}

	public Double getUsl() {
		return this.repository().getDouble(CtSubsegmentspecdetailHistoryData.Usl);
	}

	public CtSubsegmentspecdetailHistoryData setUsl(Double Usl) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Usl, Usl);
		return this;
	}

	public String getTarget() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Target);
	}

	public CtSubsegmentspecdetailHistoryData setTarget(String Target) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Target, Target);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Description);
	}

	public CtSubsegmentspecdetailHistoryData setDescription(String Description) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Creator);
	}

	public CtSubsegmentspecdetailHistoryData setCreator(String Creator) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtSubsegmentspecdetailHistoryData.Createdtime);
	}

	public CtSubsegmentspecdetailHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Modifier);
	}

	public CtSubsegmentspecdetailHistoryData setModifier(String Modifier) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtSubsegmentspecdetailHistoryData.Modifiedtime);
	}

	public CtSubsegmentspecdetailHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Txnid);
	}

	public CtSubsegmentspecdetailHistoryData setTxnid(String Txnid) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Txnuser);
	}

	public CtSubsegmentspecdetailHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtSubsegmentspecdetailHistoryData.Txntime);
	}

	public CtSubsegmentspecdetailHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Txngrouphistkey);
	}

	public CtSubsegmentspecdetailHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Txnreasoncodeclass);
	}

	public CtSubsegmentspecdetailHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Txnreasoncode);
	}

	public CtSubsegmentspecdetailHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Txncomment);
	}

	public CtSubsegmentspecdetailHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Validstate);
	}

	public CtSubsegmentspecdetailHistoryData setValidstate(String Validstate) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Validstate, Validstate);
		return this;
	}

	public String getIsmeasure() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Ismeasure);
	}

	public CtSubsegmentspecdetailHistoryData setIsmeasure(String Ismeasure) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Ismeasure, Ismeasure);
		return this;
	}

	public Double getDisplaysequence() {
		return this.repository().getDouble(CtSubsegmentspecdetailHistoryData.Displaysequence);
	}

	public CtSubsegmentspecdetailHistoryData setDisplaysequence(Double Displaysequence) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Displaysequence, Displaysequence);
		return this;
	}

	public String getIsspecforce() {
		return this.repository().getString(CtSubsegmentspecdetailHistoryData.Isspecforce);
	}

	public CtSubsegmentspecdetailHistoryData setIsspecforce(String Isspecforce) {
		this.repository().set(CtSubsegmentspecdetailHistoryData.Isspecforce, Isspecforce);
		return this;
	}


}