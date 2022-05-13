package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtRefrigeratorreportHistoryData extends SQLData {

	public static final String Lotid = "LOTID";

	public static final String Inspectiondegree = "INSPECTIONDEGREE";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Inspector = "INSPECTOR";

	public static final String Inspectdate = "INSPECTDATE";

	public static final String Cylinderlotid = "CYLINDERLOTID";

	public static final String Firstdisplacer_lotid = "FIRSTDISPLACER_LOTID";

	public static final String Seconddisplacer_lotid = "SECONDDISPLACER_LOTID";

	public static final String Xhead_lotid = "XHEAD_LOTID";

	public static final String Refrigeratorpower = "REFRIGERATORPOWER";

	public static final String Compressorpower = "COMPRESSORPOWER";

	public static final String Compressor = "COMPRESSOR";

	public static final String Modelcode = "MODELCODE";

	public static final String Modelreferencevalue = "MODELREFERENCEVALUE";

	public static final String Equipmentcode = "EQUIPMENTCODE";

	public static final String Testno = "TESTNO";

	public static final String Jigno = "JIGNO";

	public static final String Coolingtime = "COOLINGTIME";

	public static final String Coolingtimespec = "COOLINGTIMESPEC";

	public static final String Motorstall_power = "MOTORSTALL_POWER";

	public static final String Motorstall_referencevalue = "MOTORSTALL_REFERENCEVALUE";

	public static final String Motorstall_comments = "MOTORSTALL_COMMENTS";

	public static final String Noise = "NOISE";

	public static final String Comments = "COMMENTS";

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

	public CtRefrigeratorreportHistoryData() {
		this(new CtRefrigeratorreportHistoryKey()); 
	}

	public CtRefrigeratorreportHistoryData(CtRefrigeratorreportHistoryKey key) {
		super(key, "CtRefrigeratorreportHistory");
	}


	public String getInspector() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Inspector);
	}

	public CtRefrigeratorreportHistoryData setInspector(String Inspector) {
		this.repository().set(CtRefrigeratorreportHistoryData.Inspector, Inspector);
		return this;
	}

	public String getInspectdate() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Inspectdate);
	}

	public CtRefrigeratorreportHistoryData setInspectdate(String Inspectdate) {
		this.repository().set(CtRefrigeratorreportHistoryData.Inspectdate, Inspectdate);
		return this;
	}

	public String getCylinderlotid() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Cylinderlotid);
	}

	public CtRefrigeratorreportHistoryData setCylinderlotid(String Cylinderlotid) {
		this.repository().set(CtRefrigeratorreportHistoryData.Cylinderlotid, Cylinderlotid);
		return this;
	}

	public String getFirstdisplacer_lotid() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Firstdisplacer_lotid);
	}

	public CtRefrigeratorreportHistoryData setFirstdisplacer_lotid(String Firstdisplacer_lotid) {
		this.repository().set(CtRefrigeratorreportHistoryData.Firstdisplacer_lotid, Firstdisplacer_lotid);
		return this;
	}

	public String getSeconddisplacer_lotid() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Seconddisplacer_lotid);
	}

	public CtRefrigeratorreportHistoryData setSeconddisplacer_lotid(String Seconddisplacer_lotid) {
		this.repository().set(CtRefrigeratorreportHistoryData.Seconddisplacer_lotid, Seconddisplacer_lotid);
		return this;
	}

	public String getXhead_lotid() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Xhead_lotid);
	}

	public CtRefrigeratorreportHistoryData setXhead_lotid(String Xhead_lotid) {
		this.repository().set(CtRefrigeratorreportHistoryData.Xhead_lotid, Xhead_lotid);
		return this;
	}

	public String getRefrigeratorpower() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Refrigeratorpower);
	}

	public CtRefrigeratorreportHistoryData setRefrigeratorpower(String Refrigeratorpower) {
		this.repository().set(CtRefrigeratorreportHistoryData.Refrigeratorpower, Refrigeratorpower);
		return this;
	}

	public String getCompressorpower() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Compressorpower);
	}

	public CtRefrigeratorreportHistoryData setCompressorpower(String Compressorpower) {
		this.repository().set(CtRefrigeratorreportHistoryData.Compressorpower, Compressorpower);
		return this;
	}

	public String getCompressor() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Compressor);
	}

	public CtRefrigeratorreportHistoryData setCompressor(String Compressor) {
		this.repository().set(CtRefrigeratorreportHistoryData.Compressor, Compressor);
		return this;
	}

	public String getModelcode() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Modelcode);
	}

	public CtRefrigeratorreportHistoryData setModelcode(String Modelcode) {
		this.repository().set(CtRefrigeratorreportHistoryData.Modelcode, Modelcode);
		return this;
	}

	public String getModelreferencevalue() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Modelreferencevalue);
	}

	public CtRefrigeratorreportHistoryData setModelreferencevalue(String Modelreferencevalue) {
		this.repository().set(CtRefrigeratorreportHistoryData.Modelreferencevalue, Modelreferencevalue);
		return this;
	}

	public String getEquipmentcode() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Equipmentcode);
	}

	public CtRefrigeratorreportHistoryData setEquipmentcode(String Equipmentcode) {
		this.repository().set(CtRefrigeratorreportHistoryData.Equipmentcode, Equipmentcode);
		return this;
	}

	public String getTestno() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Testno);
	}

	public CtRefrigeratorreportHistoryData setTestno(String Testno) {
		this.repository().set(CtRefrigeratorreportHistoryData.Testno, Testno);
		return this;
	}

	public String getJigno() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Jigno);
	}

	public CtRefrigeratorreportHistoryData setJigno(String Jigno) {
		this.repository().set(CtRefrigeratorreportHistoryData.Jigno, Jigno);
		return this;
	}

	public String getCoolingtime() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Coolingtime);
	}

	public CtRefrigeratorreportHistoryData setCoolingtime(String Coolingtime) {
		this.repository().set(CtRefrigeratorreportHistoryData.Coolingtime, Coolingtime);
		return this;
	}

	public String getCoolingtimespec() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Coolingtimespec);
	}

	public CtRefrigeratorreportHistoryData setCoolingtimespec(String Coolingtimespec) {
		this.repository().set(CtRefrigeratorreportHistoryData.Coolingtimespec, Coolingtimespec);
		return this;
	}

	public String getMotorstall_power() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Motorstall_power);
	}

	public CtRefrigeratorreportHistoryData setMotorstall_power(String Motorstall_power) {
		this.repository().set(CtRefrigeratorreportHistoryData.Motorstall_power, Motorstall_power);
		return this;
	}

	public String getMotorstall_referencevalue() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Motorstall_referencevalue);
	}

	public CtRefrigeratorreportHistoryData setMotorstall_referencevalue(String Motorstall_referencevalue) {
		this.repository().set(CtRefrigeratorreportHistoryData.Motorstall_referencevalue, Motorstall_referencevalue);
		return this;
	}

	public String getMotorstall_comments() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Motorstall_comments);
	}

	public CtRefrigeratorreportHistoryData setMotorstall_comments(String Motorstall_comments) {
		this.repository().set(CtRefrigeratorreportHistoryData.Motorstall_comments, Motorstall_comments);
		return this;
	}

	public String getNoise() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Noise);
	}

	public CtRefrigeratorreportHistoryData setNoise(String Noise) {
		this.repository().set(CtRefrigeratorreportHistoryData.Noise, Noise);
		return this;
	}

	public String getComments() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Comments);
	}

	public CtRefrigeratorreportHistoryData setComments(String Comments) {
		this.repository().set(CtRefrigeratorreportHistoryData.Comments, Comments);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Description);
	}

	public CtRefrigeratorreportHistoryData setDescription(String Description) {
		this.repository().set(CtRefrigeratorreportHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Creator);
	}

	public CtRefrigeratorreportHistoryData setCreator(String Creator) {
		this.repository().set(CtRefrigeratorreportHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtRefrigeratorreportHistoryData.Createdtime);
	}

	public CtRefrigeratorreportHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtRefrigeratorreportHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Modifier);
	}

	public CtRefrigeratorreportHistoryData setModifier(String Modifier) {
		this.repository().set(CtRefrigeratorreportHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtRefrigeratorreportHistoryData.Modifiedtime);
	}

	public CtRefrigeratorreportHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtRefrigeratorreportHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Txnid);
	}

	public CtRefrigeratorreportHistoryData setTxnid(String Txnid) {
		this.repository().set(CtRefrigeratorreportHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Txnuser);
	}

	public CtRefrigeratorreportHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtRefrigeratorreportHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtRefrigeratorreportHistoryData.Txntime);
	}

	public CtRefrigeratorreportHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtRefrigeratorreportHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Txngrouphistkey);
	}

	public CtRefrigeratorreportHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtRefrigeratorreportHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Txnreasoncodeclass);
	}

	public CtRefrigeratorreportHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtRefrigeratorreportHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Txnreasoncode);
	}

	public CtRefrigeratorreportHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtRefrigeratorreportHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Txncomment);
	}

	public CtRefrigeratorreportHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtRefrigeratorreportHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtRefrigeratorreportHistoryData.Validstate);
	}

	public CtRefrigeratorreportHistoryData setValidstate(String Validstate) {
		this.repository().set(CtRefrigeratorreportHistoryData.Validstate, Validstate);
		return this;
	}


}