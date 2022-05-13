package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfEquipmentmaintitemData extends SQLData {

	public static final String Equipmentclassid = "EQUIPMENTCLASSID";

	public static final String Maintitemid = "MAINTITEMID";

	public static final String Mainttype = "MAINTTYPE";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Expectedmainttime = "EXPECTEDMAINTTIME";

	public static final String Resulttype = "RESULTTYPE";

	public static final String Maintsequence = "MAINTSEQUENCE";

	public static final String Maintduration = "MAINTDURATION";

	public static final String Maintdurationunit = "MAINTDURATIONUNIT";

	public static final String Maintplantype = "MAINTPLANTYPE";

	public static final String Maintplanday = "MAINTPLANDAY";

	public static final String Validationtype = "VALIDATIONTYPE";

	public static final String Target = "TARGET";

	public static final String Lowerlimit = "LOWERLIMIT";

	public static final String Upperlimit = "UPPERLIMIT";

	public static final String Limitunit = "LIMITUNIT";

	public static final String Maintposition = "MAINTPOSITION";

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

	public SfEquipmentmaintitemData() {
		this(new SfEquipmentmaintitemKey()); 
	}

	public SfEquipmentmaintitemData(SfEquipmentmaintitemKey key) {
		super(key, "SfEquipmentmaintitem");
	}


	public String getEnterpriseid() {
		return this.repository().getString(SfEquipmentmaintitemData.Enterpriseid);
	}

	public SfEquipmentmaintitemData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfEquipmentmaintitemData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfEquipmentmaintitemData.Plantid);
	}

	public SfEquipmentmaintitemData setPlantid(String Plantid) {
		this.repository().set(SfEquipmentmaintitemData.Plantid, Plantid);
		return this;
	}

	public String getExpectedmainttime() {
		return this.repository().getString(SfEquipmentmaintitemData.Expectedmainttime);
	}

	public SfEquipmentmaintitemData setExpectedmainttime(String Expectedmainttime) {
		this.repository().set(SfEquipmentmaintitemData.Expectedmainttime, Expectedmainttime);
		return this;
	}

	public String getResulttype() {
		return this.repository().getString(SfEquipmentmaintitemData.Resulttype);
	}

	public SfEquipmentmaintitemData setResulttype(String Resulttype) {
		this.repository().set(SfEquipmentmaintitemData.Resulttype, Resulttype);
		return this;
	}

	public String getMaintsequence() {
		return this.repository().getString(SfEquipmentmaintitemData.Maintsequence);
	}

	public SfEquipmentmaintitemData setMaintsequence(String Maintsequence) {
		this.repository().set(SfEquipmentmaintitemData.Maintsequence, Maintsequence);
		return this;
	}

	public Double getMaintduration() {
		return this.repository().getDouble(SfEquipmentmaintitemData.Maintduration);
	}

	public SfEquipmentmaintitemData setMaintduration(Double Maintduration) {
		this.repository().set(SfEquipmentmaintitemData.Maintduration, Maintduration);
		return this;
	}

	public String getMaintdurationunit() {
		return this.repository().getString(SfEquipmentmaintitemData.Maintdurationunit);
	}

	public SfEquipmentmaintitemData setMaintdurationunit(String Maintdurationunit) {
		this.repository().set(SfEquipmentmaintitemData.Maintdurationunit, Maintdurationunit);
		return this;
	}

	public String getMaintplantype() {
		return this.repository().getString(SfEquipmentmaintitemData.Maintplantype);
	}

	public SfEquipmentmaintitemData setMaintplantype(String Maintplantype) {
		this.repository().set(SfEquipmentmaintitemData.Maintplantype, Maintplantype);
		return this;
	}

	public String getMaintplanday() {
		return this.repository().getString(SfEquipmentmaintitemData.Maintplanday);
	}

	public SfEquipmentmaintitemData setMaintplanday(String Maintplanday) {
		this.repository().set(SfEquipmentmaintitemData.Maintplanday, Maintplanday);
		return this;
	}

	public String getValidationtype() {
		return this.repository().getString(SfEquipmentmaintitemData.Validationtype);
	}

	public SfEquipmentmaintitemData setValidationtype(String Validationtype) {
		this.repository().set(SfEquipmentmaintitemData.Validationtype, Validationtype);
		return this;
	}

	public Double getTarget() {
		return this.repository().getDouble(SfEquipmentmaintitemData.Target);
	}

	public SfEquipmentmaintitemData setTarget(Double Target) {
		this.repository().set(SfEquipmentmaintitemData.Target, Target);
		return this;
	}

	public Double getLowerlimit() {
		return this.repository().getDouble(SfEquipmentmaintitemData.Lowerlimit);
	}

	public SfEquipmentmaintitemData setLowerlimit(Double Lowerlimit) {
		this.repository().set(SfEquipmentmaintitemData.Lowerlimit, Lowerlimit);
		return this;
	}

	public Double getUpperlimit() {
		return this.repository().getDouble(SfEquipmentmaintitemData.Upperlimit);
	}

	public SfEquipmentmaintitemData setUpperlimit(Double Upperlimit) {
		this.repository().set(SfEquipmentmaintitemData.Upperlimit, Upperlimit);
		return this;
	}

	public String getLimitunit() {
		return this.repository().getString(SfEquipmentmaintitemData.Limitunit);
	}

	public SfEquipmentmaintitemData setLimitunit(String Limitunit) {
		this.repository().set(SfEquipmentmaintitemData.Limitunit, Limitunit);
		return this;
	}

	public String getMaintposition() {
		return this.repository().getString(SfEquipmentmaintitemData.Maintposition);
	}

	public SfEquipmentmaintitemData setMaintposition(String Maintposition) {
		this.repository().set(SfEquipmentmaintitemData.Maintposition, Maintposition);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfEquipmentmaintitemData.Description);
	}

	public SfEquipmentmaintitemData setDescription(String Description) {
		this.repository().set(SfEquipmentmaintitemData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfEquipmentmaintitemData.Creator);
	}

	public SfEquipmentmaintitemData setCreator(String Creator) {
		this.repository().set(SfEquipmentmaintitemData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfEquipmentmaintitemData.Createdtime);
	}

	public SfEquipmentmaintitemData setCreatedtime(Date Createdtime) {
		this.repository().set(SfEquipmentmaintitemData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfEquipmentmaintitemData.Modifier);
	}

	public SfEquipmentmaintitemData setModifier(String Modifier) {
		this.repository().set(SfEquipmentmaintitemData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfEquipmentmaintitemData.Modifiedtime);
	}

	public SfEquipmentmaintitemData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfEquipmentmaintitemData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfEquipmentmaintitemData.Lasttxnhistkey);
	}

	public SfEquipmentmaintitemData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfEquipmentmaintitemData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfEquipmentmaintitemData.Lasttxnid);
	}

	public SfEquipmentmaintitemData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfEquipmentmaintitemData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfEquipmentmaintitemData.Lasttxnuser);
	}

	public SfEquipmentmaintitemData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfEquipmentmaintitemData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfEquipmentmaintitemData.Lasttxntime);
	}

	public SfEquipmentmaintitemData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfEquipmentmaintitemData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfEquipmentmaintitemData.Lasttxncomment);
	}

	public SfEquipmentmaintitemData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfEquipmentmaintitemData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfEquipmentmaintitemData.Validstate);
	}

	public SfEquipmentmaintitemData setValidstate(String Validstate) {
		this.repository().set(SfEquipmentmaintitemData.Validstate, Validstate);
		return this;
	}


}