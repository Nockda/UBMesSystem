package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtPumpreportData extends SQLData {

	public static final String Lotid = "LOTID";

	public static final String Inspectiondegree = "INSPECTIONDEGREE";

	public static final String Customerorderno = "CUSTOMERORDERNO";

	public static final String Requnestno = "REQUNESTNO";

	public static final String Productdefid = "PRODUCTDEFID";

	public static final String Productdefversion = "PRODUCTDEFVERSION";

	public static final String Producttype = "PRODUCTTYPE";

	public static final String Inspectiondate = "INSPECTIONDATE";

	public static final String Inspector = "INSPECTOR";

	public static final String Department = "DEPARTMENT";

	public static final String Cryopumpmodel = "CRYOPUMPMODEL";

	public static final String Cryopumserialno = "CRYOPUMSERIALNO";

	public static final String Refrigeratormodel = "REFRIGERATORMODEL";

	public static final String Refrigeratorserialno = "REFRIGERATORSERIALNO";

	public static final String Compressormodel = "COMPRESSORMODEL";

	public static final String Compressorserialno = "COMPRESSORSERIALNO";

	public static final String Visualinspresult = "VISUALINSPRESULT";

	public static final String Measureinspresult = "MEASUREINSPRESULT";

	public static final String Leakinspresult = "LEAKINSPRESULT";

	public static final String Operation_reachtime = "OPERATION_REACHTIME";

	public static final String Operation_coolingdroptime = "OPERATION_COOLINGDROPTIME";

	public static final String Operation_rt80k = "OPERATION_RT80K";

	public static final String Operation_rt15k = "OPERATION_RT15K";

	public static final String Operation_component = "OPERATION_COMPONENT";

	public static final String Inputvoltage_volt = "INPUTVOLTAGE_VOLT";

	public static final String Inputvoltage_pai = "INPUTVOLTAGE_PAI";

	public static final String Inputvoltage_hz = "INPUTVOLTAGE_HZ";

	public static final String Temperature = "TEMPERATURE";

	public static final String Humidity = "HUMIDITY";

	public static final String Exterior_temperature = "EXTERIOR_TEMPERATURE";

	public static final String Noise = "NOISE";

	public static final String Twotemp1 = "TWOTEMP1";

	public static final String Twotemp2 = "TWOTEMP2";

	public static final String Twotemp3 = "TWOTEMP3";

	public static final String Reachingpressureh = "REACHINGPRESSUREH";

	public static final String Reachingpressurepa = "REACHINGPRESSUREPA";

	public static final String Vibration = "VIBRATION";

	public static final String Sound = "SOUND";

	public static final String Time_23k = "TIME_23K";

	public static final String Time_20k = "TIME_20K";

	public static final String Time_18k = "TIME_18K";

	public static final String Time_15k = "TIME_15K";

	public static final String Comments = "COMMENTS";

	public static final String Inspresult = "INSPRESULT";

	public static final String Publishdate = "PUBLISHDATE";

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

	public CtPumpreportData() {
		this(new CtPumpreportKey()); 
	}

	public CtPumpreportData(CtPumpreportKey key) {
		super(key, "CtPumpreport");
	}


	public String getCustomerorderno() {
		return this.repository().getString(CtPumpreportData.Customerorderno);
	}

	public CtPumpreportData setCustomerorderno(String Customerorderno) {
		this.repository().set(CtPumpreportData.Customerorderno, Customerorderno);
		return this;
	}

	public String getRequnestno() {
		return this.repository().getString(CtPumpreportData.Requnestno);
	}

	public CtPumpreportData setRequnestno(String Requnestno) {
		this.repository().set(CtPumpreportData.Requnestno, Requnestno);
		return this;
	}

	public String getProductdefid() {
		return this.repository().getString(CtPumpreportData.Productdefid);
	}

	public CtPumpreportData setProductdefid(String Productdefid) {
		this.repository().set(CtPumpreportData.Productdefid, Productdefid);
		return this;
	}

	public String getProductdefversion() {
		return this.repository().getString(CtPumpreportData.Productdefversion);
	}

	public CtPumpreportData setProductdefversion(String Productdefversion) {
		this.repository().set(CtPumpreportData.Productdefversion, Productdefversion);
		return this;
	}

	public String getProducttype() {
		return this.repository().getString(CtPumpreportData.Producttype);
	}

	public CtPumpreportData setProducttype(String Producttype) {
		this.repository().set(CtPumpreportData.Producttype, Producttype);
		return this;
	}

	public Date getInspectiondate() {
		return this.repository().getDate(CtPumpreportData.Inspectiondate);
	}

	public CtPumpreportData setInspectiondate(Date Inspectiondate) {
		this.repository().set(CtPumpreportData.Inspectiondate, Inspectiondate);
		return this;
	}

	public String getInspector() {
		return this.repository().getString(CtPumpreportData.Inspector);
	}

	public CtPumpreportData setInspector(String Inspector) {
		this.repository().set(CtPumpreportData.Inspector, Inspector);
		return this;
	}

	public String getDepartment() {
		return this.repository().getString(CtPumpreportData.Department);
	}

	public CtPumpreportData setDepartment(String Department) {
		this.repository().set(CtPumpreportData.Department, Department);
		return this;
	}

	public String getCryopumpmodel() {
		return this.repository().getString(CtPumpreportData.Cryopumpmodel);
	}

	public CtPumpreportData setCryopumpmodel(String Cryopumpmodel) {
		this.repository().set(CtPumpreportData.Cryopumpmodel, Cryopumpmodel);
		return this;
	}

	public String getCryopumserialno() {
		return this.repository().getString(CtPumpreportData.Cryopumserialno);
	}

	public CtPumpreportData setCryopumserialno(String Cryopumserialno) {
		this.repository().set(CtPumpreportData.Cryopumserialno, Cryopumserialno);
		return this;
	}

	public String getRefrigeratormodel() {
		return this.repository().getString(CtPumpreportData.Refrigeratormodel);
	}

	public CtPumpreportData setRefrigeratormodel(String Refrigeratormodel) {
		this.repository().set(CtPumpreportData.Refrigeratormodel, Refrigeratormodel);
		return this;
	}

	public String getRefrigeratorserialno() {
		return this.repository().getString(CtPumpreportData.Refrigeratorserialno);
	}

	public CtPumpreportData setRefrigeratorserialno(String Refrigeratorserialno) {
		this.repository().set(CtPumpreportData.Refrigeratorserialno, Refrigeratorserialno);
		return this;
	}

	public String getCompressormodel() {
		return this.repository().getString(CtPumpreportData.Compressormodel);
	}

	public CtPumpreportData setCompressormodel(String Compressormodel) {
		this.repository().set(CtPumpreportData.Compressormodel, Compressormodel);
		return this;
	}

	public String getCompressorserialno() {
		return this.repository().getString(CtPumpreportData.Compressorserialno);
	}

	public CtPumpreportData setCompressorserialno(String Compressorserialno) {
		this.repository().set(CtPumpreportData.Compressorserialno, Compressorserialno);
		return this;
	}

	public String getVisualinspresult() {
		return this.repository().getString(CtPumpreportData.Visualinspresult);
	}

	public CtPumpreportData setVisualinspresult(String Visualinspresult) {
		this.repository().set(CtPumpreportData.Visualinspresult, Visualinspresult);
		return this;
	}

	public String getMeasureinspresult() {
		return this.repository().getString(CtPumpreportData.Measureinspresult);
	}

	public CtPumpreportData setMeasureinspresult(String Measureinspresult) {
		this.repository().set(CtPumpreportData.Measureinspresult, Measureinspresult);
		return this;
	}

	public String getLeakinspresult() {
		return this.repository().getString(CtPumpreportData.Leakinspresult);
	}

	public CtPumpreportData setLeakinspresult(String Leakinspresult) {
		this.repository().set(CtPumpreportData.Leakinspresult, Leakinspresult);
		return this;
	}

	public String getOperation_reachtime() {
		return this.repository().getString(CtPumpreportData.Operation_reachtime);
	}

	public CtPumpreportData setOperation_reachtime(String Operation_reachtime) {
		this.repository().set(CtPumpreportData.Operation_reachtime, Operation_reachtime);
		return this;
	}

	public String getOperation_coolingdroptime() {
		return this.repository().getString(CtPumpreportData.Operation_coolingdroptime);
	}

	public CtPumpreportData setOperation_coolingdroptime(String Operation_coolingdroptime) {
		this.repository().set(CtPumpreportData.Operation_coolingdroptime, Operation_coolingdroptime);
		return this;
	}

	public String getOperation_rt80k() {
		return this.repository().getString(CtPumpreportData.Operation_rt80k);
	}

	public CtPumpreportData setOperation_rt80k(String Operation_rt80k) {
		this.repository().set(CtPumpreportData.Operation_rt80k, Operation_rt80k);
		return this;
	}

	public String getOperation_rt15k() {
		return this.repository().getString(CtPumpreportData.Operation_rt15k);
	}

	public CtPumpreportData setOperation_rt15k(String Operation_rt15k) {
		this.repository().set(CtPumpreportData.Operation_rt15k, Operation_rt15k);
		return this;
	}

	public String getOperation_component() {
		return this.repository().getString(CtPumpreportData.Operation_component);
	}

	public CtPumpreportData setOperation_component(String Operation_component) {
		this.repository().set(CtPumpreportData.Operation_component, Operation_component);
		return this;
	}

	public String getInputvoltage_volt() {
		return this.repository().getString(CtPumpreportData.Inputvoltage_volt);
	}

	public CtPumpreportData setInputvoltage_volt(String Inputvoltage_volt) {
		this.repository().set(CtPumpreportData.Inputvoltage_volt, Inputvoltage_volt);
		return this;
	}

	public String getInputvoltage_pai() {
		return this.repository().getString(CtPumpreportData.Inputvoltage_pai);
	}

	public CtPumpreportData setInputvoltage_pai(String Inputvoltage_pai) {
		this.repository().set(CtPumpreportData.Inputvoltage_pai, Inputvoltage_pai);
		return this;
	}

	public String getInputvoltage_hz() {
		return this.repository().getString(CtPumpreportData.Inputvoltage_hz);
	}

	public CtPumpreportData setInputvoltage_hz(String Inputvoltage_hz) {
		this.repository().set(CtPumpreportData.Inputvoltage_hz, Inputvoltage_hz);
		return this;
	}

	public String getTemperature() {
		return this.repository().getString(CtPumpreportData.Temperature);
	}

	public CtPumpreportData setTemperature(String Temperature) {
		this.repository().set(CtPumpreportData.Temperature, Temperature);
		return this;
	}

	public String getHumidity() {
		return this.repository().getString(CtPumpreportData.Humidity);
	}

	public CtPumpreportData setHumidity(String Humidity) {
		this.repository().set(CtPumpreportData.Humidity, Humidity);
		return this;
	}

	public String getExterior_temperature() {
		return this.repository().getString(CtPumpreportData.Exterior_temperature);
	}

	public CtPumpreportData setExterior_temperature(String Exterior_temperature) {
		this.repository().set(CtPumpreportData.Exterior_temperature, Exterior_temperature);
		return this;
	}

	public String getNoise() {
		return this.repository().getString(CtPumpreportData.Noise);
	}

	public CtPumpreportData setNoise(String Noise) {
		this.repository().set(CtPumpreportData.Noise, Noise);
		return this;
	}

	public String getTwotemp1() {
		return this.repository().getString(CtPumpreportData.Twotemp1);
	}

	public CtPumpreportData setTwotemp1(String Twotemp1) {
		this.repository().set(CtPumpreportData.Twotemp1, Twotemp1);
		return this;
	}

	public String getTwotemp2() {
		return this.repository().getString(CtPumpreportData.Twotemp2);
	}

	public CtPumpreportData setTwotemp2(String Twotemp2) {
		this.repository().set(CtPumpreportData.Twotemp2, Twotemp2);
		return this;
	}

	public String getTwotemp3() {
		return this.repository().getString(CtPumpreportData.Twotemp3);
	}

	public CtPumpreportData setTwotemp3(String Twotemp3) {
		this.repository().set(CtPumpreportData.Twotemp3, Twotemp3);
		return this;
	}

	public String getReachingpressureh() {
		return this.repository().getString(CtPumpreportData.Reachingpressureh);
	}

	public CtPumpreportData setReachingpressureh(String Reachingpressureh) {
		this.repository().set(CtPumpreportData.Reachingpressureh, Reachingpressureh);
		return this;
	}

	public String getReachingpressurepa() {
		return this.repository().getString(CtPumpreportData.Reachingpressurepa);
	}

	public CtPumpreportData setReachingpressurepa(String Reachingpressurepa) {
		this.repository().set(CtPumpreportData.Reachingpressurepa, Reachingpressurepa);
		return this;
	}

	public String getVibration() {
		return this.repository().getString(CtPumpreportData.Vibration);
	}

	public CtPumpreportData setVibration(String Vibration) {
		this.repository().set(CtPumpreportData.Vibration, Vibration);
		return this;
	}

	public String getSound() {
		return this.repository().getString(CtPumpreportData.Sound);
	}

	public CtPumpreportData setSound(String Sound) {
		this.repository().set(CtPumpreportData.Sound, Sound);
		return this;
	}

	public String getTime_23k() {
		return this.repository().getString(CtPumpreportData.Time_23k);
	}

	public CtPumpreportData setTime_23k(String Time_23k) {
		this.repository().set(CtPumpreportData.Time_23k, Time_23k);
		return this;
	}

	public String getTime_20k() {
		return this.repository().getString(CtPumpreportData.Time_20k);
	}

	public CtPumpreportData setTime_20k(String Time_20k) {
		this.repository().set(CtPumpreportData.Time_20k, Time_20k);
		return this;
	}

	public String getTime_18k() {
		return this.repository().getString(CtPumpreportData.Time_18k);
	}

	public CtPumpreportData setTime_18k(String Time_18k) {
		this.repository().set(CtPumpreportData.Time_18k, Time_18k);
		return this;
	}

	public String getTime_15k() {
		return this.repository().getString(CtPumpreportData.Time_15k);
	}

	public CtPumpreportData setTime_15k(String Time_15k) {
		this.repository().set(CtPumpreportData.Time_15k, Time_15k);
		return this;
	}

	public String getComments() {
		return this.repository().getString(CtPumpreportData.Comments);
	}

	public CtPumpreportData setComments(String Comments) {
		this.repository().set(CtPumpreportData.Comments, Comments);
		return this;
	}

	public String getInspresult() {
		return this.repository().getString(CtPumpreportData.Inspresult);
	}

	public CtPumpreportData setInspresult(String Inspresult) {
		this.repository().set(CtPumpreportData.Inspresult, Inspresult);
		return this;
	}

	public String getPublishdate() {
		return this.repository().getString(CtPumpreportData.Publishdate);
	}

	public CtPumpreportData setPublishdate(String Publishdate) {
		this.repository().set(CtPumpreportData.Publishdate, Publishdate);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtPumpreportData.Description);
	}

	public CtPumpreportData setDescription(String Description) {
		this.repository().set(CtPumpreportData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtPumpreportData.Creator);
	}

	public CtPumpreportData setCreator(String Creator) {
		this.repository().set(CtPumpreportData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtPumpreportData.Createdtime);
	}

	public CtPumpreportData setCreatedtime(Date Createdtime) {
		this.repository().set(CtPumpreportData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtPumpreportData.Modifier);
	}

	public CtPumpreportData setModifier(String Modifier) {
		this.repository().set(CtPumpreportData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtPumpreportData.Modifiedtime);
	}

	public CtPumpreportData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtPumpreportData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtPumpreportData.Lasttxnhistkey);
	}

	public CtPumpreportData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtPumpreportData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtPumpreportData.Lasttxnid);
	}

	public CtPumpreportData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtPumpreportData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtPumpreportData.Lasttxnuser);
	}

	public CtPumpreportData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtPumpreportData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtPumpreportData.Lasttxntime);
	}

	public CtPumpreportData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtPumpreportData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtPumpreportData.Lasttxncomment);
	}

	public CtPumpreportData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtPumpreportData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtPumpreportData.Validstate);
	}

	public CtPumpreportData setValidstate(String Validstate) {
		this.repository().set(CtPumpreportData.Validstate, Validstate);
		return this;
	}


}