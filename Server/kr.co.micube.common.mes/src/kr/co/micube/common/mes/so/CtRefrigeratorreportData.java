package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtRefrigeratorreportData extends SQLData {

	public static final String Lotid = "LOTID";

	public static final String Inspectiondegree = "INSPECTIONDEGREE";

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

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Lasttxnid = "LASTTXNID";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public CtRefrigeratorreportData() {
		this(new CtRefrigeratorreportKey()); 
	}

	public CtRefrigeratorreportData(CtRefrigeratorreportKey key) {
		super(key, "CtRefrigeratorreport");
	}


	public String getInspector() {
		return this.repository().getString(CtRefrigeratorreportData.Inspector);
	}

	public CtRefrigeratorreportData setInspector(String Inspector) {
		this.repository().set(CtRefrigeratorreportData.Inspector, Inspector);
		return this;
	}

	public String getInspectdate() {
		return this.repository().getString(CtRefrigeratorreportData.Inspectdate);
	}

	public CtRefrigeratorreportData setInspectdate(String Inspectdate) {
		this.repository().set(CtRefrigeratorreportData.Inspectdate, Inspectdate);
		return this;
	}

	public String getCylinderlotid() {
		return this.repository().getString(CtRefrigeratorreportData.Cylinderlotid);
	}

	public CtRefrigeratorreportData setCylinderlotid(String Cylinderlotid) {
		this.repository().set(CtRefrigeratorreportData.Cylinderlotid, Cylinderlotid);
		return this;
	}

	public String getFirstdisplacer_lotid() {
		return this.repository().getString(CtRefrigeratorreportData.Firstdisplacer_lotid);
	}

	public CtRefrigeratorreportData setFirstdisplacer_lotid(String Firstdisplacer_lotid) {
		this.repository().set(CtRefrigeratorreportData.Firstdisplacer_lotid, Firstdisplacer_lotid);
		return this;
	}

	public String getSeconddisplacer_lotid() {
		return this.repository().getString(CtRefrigeratorreportData.Seconddisplacer_lotid);
	}

	public CtRefrigeratorreportData setSeconddisplacer_lotid(String Seconddisplacer_lotid) {
		this.repository().set(CtRefrigeratorreportData.Seconddisplacer_lotid, Seconddisplacer_lotid);
		return this;
	}

	public String getXhead_lotid() {
		return this.repository().getString(CtRefrigeratorreportData.Xhead_lotid);
	}

	public CtRefrigeratorreportData setXhead_lotid(String Xhead_lotid) {
		this.repository().set(CtRefrigeratorreportData.Xhead_lotid, Xhead_lotid);
		return this;
	}

	public String getRefrigeratorpower() {
		return this.repository().getString(CtRefrigeratorreportData.Refrigeratorpower);
	}

	public CtRefrigeratorreportData setRefrigeratorpower(String Refrigeratorpower) {
		this.repository().set(CtRefrigeratorreportData.Refrigeratorpower, Refrigeratorpower);
		return this;
	}

	public String getCompressorpower() {
		return this.repository().getString(CtRefrigeratorreportData.Compressorpower);
	}

	public CtRefrigeratorreportData setCompressorpower(String Compressorpower) {
		this.repository().set(CtRefrigeratorreportData.Compressorpower, Compressorpower);
		return this;
	}

	public String getCompressor() {
		return this.repository().getString(CtRefrigeratorreportData.Compressor);
	}

	public CtRefrigeratorreportData setCompressor(String Compressor) {
		this.repository().set(CtRefrigeratorreportData.Compressor, Compressor);
		return this;
	}

	public String getModelcode() {
		return this.repository().getString(CtRefrigeratorreportData.Modelcode);
	}

	public CtRefrigeratorreportData setModelcode(String Modelcode) {
		this.repository().set(CtRefrigeratorreportData.Modelcode, Modelcode);
		return this;
	}

	public String getModelreferencevalue() {
		return this.repository().getString(CtRefrigeratorreportData.Modelreferencevalue);
	}

	public CtRefrigeratorreportData setModelreferencevalue(String Modelreferencevalue) {
		this.repository().set(CtRefrigeratorreportData.Modelreferencevalue, Modelreferencevalue);
		return this;
	}

	public String getEquipmentcode() {
		return this.repository().getString(CtRefrigeratorreportData.Equipmentcode);
	}

	public CtRefrigeratorreportData setEquipmentcode(String Equipmentcode) {
		this.repository().set(CtRefrigeratorreportData.Equipmentcode, Equipmentcode);
		return this;
	}

	public String getTestno() {
		return this.repository().getString(CtRefrigeratorreportData.Testno);
	}

	public CtRefrigeratorreportData setTestno(String Testno) {
		this.repository().set(CtRefrigeratorreportData.Testno, Testno);
		return this;
	}

	public String getJigno() {
		return this.repository().getString(CtRefrigeratorreportData.Jigno);
	}

	public CtRefrigeratorreportData setJigno(String Jigno) {
		this.repository().set(CtRefrigeratorreportData.Jigno, Jigno);
		return this;
	}

	public String getCoolingtime() {
		return this.repository().getString(CtRefrigeratorreportData.Coolingtime);
	}

	public CtRefrigeratorreportData setCoolingtime(String Coolingtime) {
		this.repository().set(CtRefrigeratorreportData.Coolingtime, Coolingtime);
		return this;
	}

	public String getCoolingtimespec() {
		return this.repository().getString(CtRefrigeratorreportData.Coolingtimespec);
	}

	public CtRefrigeratorreportData setCoolingtimespec(String Coolingtimespec) {
		this.repository().set(CtRefrigeratorreportData.Coolingtimespec, Coolingtimespec);
		return this;
	}

	public String getMotorstall_power() {
		return this.repository().getString(CtRefrigeratorreportData.Motorstall_power);
	}

	public CtRefrigeratorreportData setMotorstall_power(String Motorstall_power) {
		this.repository().set(CtRefrigeratorreportData.Motorstall_power, Motorstall_power);
		return this;
	}

	public String getMotorstall_referencevalue() {
		return this.repository().getString(CtRefrigeratorreportData.Motorstall_referencevalue);
	}

	public CtRefrigeratorreportData setMotorstall_referencevalue(String Motorstall_referencevalue) {
		this.repository().set(CtRefrigeratorreportData.Motorstall_referencevalue, Motorstall_referencevalue);
		return this;
	}

	public String getMotorstall_comments() {
		return this.repository().getString(CtRefrigeratorreportData.Motorstall_comments);
	}

	public CtRefrigeratorreportData setMotorstall_comments(String Motorstall_comments) {
		this.repository().set(CtRefrigeratorreportData.Motorstall_comments, Motorstall_comments);
		return this;
	}

	public String getNoise() {
		return this.repository().getString(CtRefrigeratorreportData.Noise);
	}

	public CtRefrigeratorreportData setNoise(String Noise) {
		this.repository().set(CtRefrigeratorreportData.Noise, Noise);
		return this;
	}

	public String getComments() {
		return this.repository().getString(CtRefrigeratorreportData.Comments);
	}

	public CtRefrigeratorreportData setComments(String Comments) {
		this.repository().set(CtRefrigeratorreportData.Comments, Comments);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtRefrigeratorreportData.Description);
	}

	public CtRefrigeratorreportData setDescription(String Description) {
		this.repository().set(CtRefrigeratorreportData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtRefrigeratorreportData.Creator);
	}

	public CtRefrigeratorreportData setCreator(String Creator) {
		this.repository().set(CtRefrigeratorreportData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtRefrigeratorreportData.Createdtime);
	}

	public CtRefrigeratorreportData setCreatedtime(Date Createdtime) {
		this.repository().set(CtRefrigeratorreportData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtRefrigeratorreportData.Modifier);
	}

	public CtRefrigeratorreportData setModifier(String Modifier) {
		this.repository().set(CtRefrigeratorreportData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtRefrigeratorreportData.Modifiedtime);
	}

	public CtRefrigeratorreportData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtRefrigeratorreportData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtRefrigeratorreportData.Lasttxnhistkey);
	}

	public CtRefrigeratorreportData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtRefrigeratorreportData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtRefrigeratorreportData.Lasttxnid);
	}

	public CtRefrigeratorreportData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtRefrigeratorreportData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtRefrigeratorreportData.Lasttxnuser);
	}

	public CtRefrigeratorreportData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtRefrigeratorreportData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtRefrigeratorreportData.Lasttxntime);
	}

	public CtRefrigeratorreportData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtRefrigeratorreportData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtRefrigeratorreportData.Lasttxncomment);
	}

	public CtRefrigeratorreportData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtRefrigeratorreportData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtRefrigeratorreportData.Validstate);
	}

	public CtRefrigeratorreportData setValidstate(String Validstate) {
		this.repository().set(CtRefrigeratorreportData.Validstate, Validstate);
		return this;
	}


}