package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlSubprocessworkresultdetailData extends SQLData {

	public static final String Workresulthistkey = "WORKRESULTHISTKEY";

	public static final String Parameterid = "PARAMETERID";

	public static final String Pointid = "POINTID";

	public static final String Seq = "SEQ";

	public static final String Measurevalue = "MEASUREVALUE";

	public static final String Specdefid = "SPECDEFID";

	public static final String Usl = "USL";

	public static final String Csl = "CSL";

	public static final String Lsl = "LSL";

	public static final String Target = "TARGET";

	public static final String Description = "DESCRIPTION";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Modifier = "MODIFIER";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Isdefect = "ISDEFECT";

	public UlSubprocessworkresultdetailData() {
		this(new UlSubprocessworkresultdetailKey()); 
	}

	public UlSubprocessworkresultdetailData(UlSubprocessworkresultdetailKey key) {
		super(key, "UlSubprocessworkresultdetail");
		this.txnInfo().setHistoryTable(true);
	}


	public String getMeasurevalue() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Measurevalue);
	}

	public UlSubprocessworkresultdetailData setMeasurevalue(String Measurevalue) {
		this.repository().set(UlSubprocessworkresultdetailData.Measurevalue, Measurevalue);
		return this;
	}

	public String getSpecdefid() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Specdefid);
	}

	public UlSubprocessworkresultdetailData setSpecdefid(String Specdefid) {
		this.repository().set(UlSubprocessworkresultdetailData.Specdefid, Specdefid);
		return this;
	}

	public Double getUsl() {
		return this.repository().getDouble(UlSubprocessworkresultdetailData.Usl);
	}

	public UlSubprocessworkresultdetailData setUsl(Double Usl) {
		this.repository().set(UlSubprocessworkresultdetailData.Usl, Usl);
		return this;
	}

	public Double getCsl() {
		return this.repository().getDouble(UlSubprocessworkresultdetailData.Csl);
	}

	public UlSubprocessworkresultdetailData setCsl(Double Csl) {
		this.repository().set(UlSubprocessworkresultdetailData.Csl, Csl);
		return this;
	}

	public Double getLsl() {
		return this.repository().getDouble(UlSubprocessworkresultdetailData.Lsl);
	}

	public UlSubprocessworkresultdetailData setLsl(Double Lsl) {
		this.repository().set(UlSubprocessworkresultdetailData.Lsl, Lsl);
		return this;
	}

	public String getTarget() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Target);
	}

	public UlSubprocessworkresultdetailData setTarget(String Target) {
		this.repository().set(UlSubprocessworkresultdetailData.Target, Target);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Description);
	}

	public UlSubprocessworkresultdetailData setDescription(String Description) {
		this.repository().set(UlSubprocessworkresultdetailData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Creator);
	}

	public UlSubprocessworkresultdetailData setCreator(String Creator) {
		this.repository().set(UlSubprocessworkresultdetailData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlSubprocessworkresultdetailData.Createdtime);
	}

	public UlSubprocessworkresultdetailData setCreatedtime(Date Createdtime) {
		this.repository().set(UlSubprocessworkresultdetailData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Modifier);
	}

	public UlSubprocessworkresultdetailData setModifier(String Modifier) {
		this.repository().set(UlSubprocessworkresultdetailData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlSubprocessworkresultdetailData.Modifiedtime);
	}

	public UlSubprocessworkresultdetailData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlSubprocessworkresultdetailData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Lasttxncomment);
	}

	public UlSubprocessworkresultdetailData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(UlSubprocessworkresultdetailData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Txnuser);
	}

	public UlSubprocessworkresultdetailData setTxnuser(String Txnuser) {
		this.repository().set(UlSubprocessworkresultdetailData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(UlSubprocessworkresultdetailData.Txntime);
	}

	public UlSubprocessworkresultdetailData setTxntime(Date Txntime) {
		this.repository().set(UlSubprocessworkresultdetailData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Txngrouphistkey);
	}

	public UlSubprocessworkresultdetailData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(UlSubprocessworkresultdetailData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Txnreasoncodeclass);
	}

	public UlSubprocessworkresultdetailData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(UlSubprocessworkresultdetailData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Txnreasoncode);
	}

	public UlSubprocessworkresultdetailData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(UlSubprocessworkresultdetailData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Txncomment);
	}

	public UlSubprocessworkresultdetailData setTxncomment(String Txncomment) {
		this.repository().set(UlSubprocessworkresultdetailData.Txncomment, Txncomment);
		return this;
	}

	public String getIsdefect() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Isdefect);
	}

	public UlSubprocessworkresultdetailData setIsdefect(String Isdefect) {
		this.repository().set(UlSubprocessworkresultdetailData.Isdefect, Isdefect);
		return this;
	}


}