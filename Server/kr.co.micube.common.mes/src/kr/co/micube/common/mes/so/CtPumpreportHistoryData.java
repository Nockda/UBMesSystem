package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtPumpreportHistoryData extends SQLData {

	public static final String Lotid = "LOTID";

	public static final String Inspectiondegree = "INSPECTIONDEGREE";

	public static final String Txnhistkey = "TXNHISTKEY";

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

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public CtPumpreportHistoryData() {
		this(new CtPumpreportHistoryKey()); 
	}

	public CtPumpreportHistoryData(CtPumpreportHistoryKey key) {
		super(key, "CtPumpreportHistory");
	}


	public String getCustomerorderno() {
		return this.repository().getString(CtPumpreportHistoryData.Customerorderno);
	}

	public CtPumpreportHistoryData setCustomerorderno(String Customerorderno) {
		this.repository().set(CtPumpreportHistoryData.Customerorderno, Customerorderno);
		return this;
	}

	public String getRequnestno() {
		return this.repository().getString(CtPumpreportHistoryData.Requnestno);
	}

	public CtPumpreportHistoryData setRequnestno(String Requnestno) {
		this.repository().set(CtPumpreportHistoryData.Requnestno, Requnestno);
		return this;
	}

	public String getProductdefid() {
		return this.repository().getString(CtPumpreportHistoryData.Productdefid);
	}

	public CtPumpreportHistoryData setProductdefid(String Productdefid) {
		this.repository().set(CtPumpreportHistoryData.Productdefid, Productdefid);
		return this;
	}

	public String getProductdefversion() {
		return this.repository().getString(CtPumpreportHistoryData.Productdefversion);
	}

	public CtPumpreportHistoryData setProductdefversion(String Productdefversion) {
		this.repository().set(CtPumpreportHistoryData.Productdefversion, Productdefversion);
		return this;
	}

	public String getProducttype() {
		return this.repository().getString(CtPumpreportHistoryData.Producttype);
	}

	public CtPumpreportHistoryData setProducttype(String Producttype) {
		this.repository().set(CtPumpreportHistoryData.Producttype, Producttype);
		return this;
	}

	public Date getInspectiondate() {
		return this.repository().getDate(CtPumpreportHistoryData.Inspectiondate);
	}

	public CtPumpreportHistoryData setInspectiondate(Date Inspectiondate) {
		this.repository().set(CtPumpreportHistoryData.Inspectiondate, Inspectiondate);
		return this;
	}

	public String getInspector() {
		return this.repository().getString(CtPumpreportHistoryData.Inspector);
	}

	public CtPumpreportHistoryData setInspector(String Inspector) {
		this.repository().set(CtPumpreportHistoryData.Inspector, Inspector);
		return this;
	}

	public String getDepartment() {
		return this.repository().getString(CtPumpreportHistoryData.Department);
	}

	public CtPumpreportHistoryData setDepartment(String Department) {
		this.repository().set(CtPumpreportHistoryData.Department, Department);
		return this;
	}

	public String getCryopumpmodel() {
		return this.repository().getString(CtPumpreportHistoryData.Cryopumpmodel);
	}

	public CtPumpreportHistoryData setCryopumpmodel(String Cryopumpmodel) {
		this.repository().set(CtPumpreportHistoryData.Cryopumpmodel, Cryopumpmodel);
		return this;
	}

	public String getCryopumserialno() {
		return this.repository().getString(CtPumpreportHistoryData.Cryopumserialno);
	}

	public CtPumpreportHistoryData setCryopumserialno(String Cryopumserialno) {
		this.repository().set(CtPumpreportHistoryData.Cryopumserialno, Cryopumserialno);
		return this;
	}

	public String getRefrigeratormodel() {
		return this.repository().getString(CtPumpreportHistoryData.Refrigeratormodel);
	}

	public CtPumpreportHistoryData setRefrigeratormodel(String Refrigeratormodel) {
		this.repository().set(CtPumpreportHistoryData.Refrigeratormodel, Refrigeratormodel);
		return this;
	}

	public String getRefrigeratorserialno() {
		return this.repository().getString(CtPumpreportHistoryData.Refrigeratorserialno);
	}

	public CtPumpreportHistoryData setRefrigeratorserialno(String Refrigeratorserialno) {
		this.repository().set(CtPumpreportHistoryData.Refrigeratorserialno, Refrigeratorserialno);
		return this;
	}

	public String getCompressormodel() {
		return this.repository().getString(CtPumpreportHistoryData.Compressormodel);
	}

	public CtPumpreportHistoryData setCompressormodel(String Compressormodel) {
		this.repository().set(CtPumpreportHistoryData.Compressormodel, Compressormodel);
		return this;
	}

	public String getCompressorserialno() {
		return this.repository().getString(CtPumpreportHistoryData.Compressorserialno);
	}

	public CtPumpreportHistoryData setCompressorserialno(String Compressorserialno) {
		this.repository().set(CtPumpreportHistoryData.Compressorserialno, Compressorserialno);
		return this;
	}

	public String getVisualinspresult() {
		return this.repository().getString(CtPumpreportHistoryData.Visualinspresult);
	}

	public CtPumpreportHistoryData setVisualinspresult(String Visualinspresult) {
		this.repository().set(CtPumpreportHistoryData.Visualinspresult, Visualinspresult);
		return this;
	}

	public String getMeasureinspresult() {
		return this.repository().getString(CtPumpreportHistoryData.Measureinspresult);
	}

	public CtPumpreportHistoryData setMeasureinspresult(String Measureinspresult) {
		this.repository().set(CtPumpreportHistoryData.Measureinspresult, Measureinspresult);
		return this;
	}

	public String getLeakinspresult() {
		return this.repository().getString(CtPumpreportHistoryData.Leakinspresult);
	}

	public CtPumpreportHistoryData setLeakinspresult(String Leakinspresult) {
		this.repository().set(CtPumpreportHistoryData.Leakinspresult, Leakinspresult);
		return this;
	}

	public String getOperation_reachtime() {
		return this.repository().getString(CtPumpreportHistoryData.Operation_reachtime);
	}

	public CtPumpreportHistoryData setOperation_reachtime(String Operation_reachtime) {
		this.repository().set(CtPumpreportHistoryData.Operation_reachtime, Operation_reachtime);
		return this;
	}

	public String getOperation_coolingdroptime() {
		return this.repository().getString(CtPumpreportHistoryData.Operation_coolingdroptime);
	}

	public CtPumpreportHistoryData setOperation_coolingdroptime(String Operation_coolingdroptime) {
		this.repository().set(CtPumpreportHistoryData.Operation_coolingdroptime, Operation_coolingdroptime);
		return this;
	}

	public String getOperation_rt80k() {
		return this.repository().getString(CtPumpreportHistoryData.Operation_rt80k);
	}

	public CtPumpreportHistoryData setOperation_rt80k(String Operation_rt80k) {
		this.repository().set(CtPumpreportHistoryData.Operation_rt80k, Operation_rt80k);
		return this;
	}

	public String getOperation_rt15k() {
		return this.repository().getString(CtPumpreportHistoryData.Operation_rt15k);
	}

	public CtPumpreportHistoryData setOperation_rt15k(String Operation_rt15k) {
		this.repository().set(CtPumpreportHistoryData.Operation_rt15k, Operation_rt15k);
		return this;
	}

	public String getOperation_component() {
		return this.repository().getString(CtPumpreportHistoryData.Operation_component);
	}

	public CtPumpreportHistoryData setOperation_component(String Operation_component) {
		this.repository().set(CtPumpreportHistoryData.Operation_component, Operation_component);
		return this;
	}

	public String getInputvoltage_volt() {
		return this.repository().getString(CtPumpreportHistoryData.Inputvoltage_volt);
	}

	public CtPumpreportHistoryData setInputvoltage_volt(String Inputvoltage_volt) {
		this.repository().set(CtPumpreportHistoryData.Inputvoltage_volt, Inputvoltage_volt);
		return this;
	}

	public String getInputvoltage_pai() {
		return this.repository().getString(CtPumpreportHistoryData.Inputvoltage_pai);
	}

	public CtPumpreportHistoryData setInputvoltage_pai(String Inputvoltage_pai) {
		this.repository().set(CtPumpreportHistoryData.Inputvoltage_pai, Inputvoltage_pai);
		return this;
	}

	public String getInputvoltage_hz() {
		return this.repository().getString(CtPumpreportHistoryData.Inputvoltage_hz);
	}

	public CtPumpreportHistoryData setInputvoltage_hz(String Inputvoltage_hz) {
		this.repository().set(CtPumpreportHistoryData.Inputvoltage_hz, Inputvoltage_hz);
		return this;
	}

	public String getTemperature() {
		return this.repository().getString(CtPumpreportHistoryData.Temperature);
	}

	public CtPumpreportHistoryData setTemperature(String Temperature) {
		this.repository().set(CtPumpreportHistoryData.Temperature, Temperature);
		return this;
	}

	public String getHumidity() {
		return this.repository().getString(CtPumpreportHistoryData.Humidity);
	}

	public CtPumpreportHistoryData setHumidity(String Humidity) {
		this.repository().set(CtPumpreportHistoryData.Humidity, Humidity);
		return this;
	}

	public String getExterior_temperature() {
		return this.repository().getString(CtPumpreportHistoryData.Exterior_temperature);
	}

	public CtPumpreportHistoryData setExterior_temperature(String Exterior_temperature) {
		this.repository().set(CtPumpreportHistoryData.Exterior_temperature, Exterior_temperature);
		return this;
	}

	public String getNoise() {
		return this.repository().getString(CtPumpreportHistoryData.Noise);
	}

	public CtPumpreportHistoryData setNoise(String Noise) {
		this.repository().set(CtPumpreportHistoryData.Noise, Noise);
		return this;
	}

	public String getTwotemp1() {
		return this.repository().getString(CtPumpreportHistoryData.Twotemp1);
	}

	public CtPumpreportHistoryData setTwotemp1(String Twotemp1) {
		this.repository().set(CtPumpreportHistoryData.Twotemp1, Twotemp1);
		return this;
	}

	public String getTwotemp2() {
		return this.repository().getString(CtPumpreportHistoryData.Twotemp2);
	}

	public CtPumpreportHistoryData setTwotemp2(String Twotemp2) {
		this.repository().set(CtPumpreportHistoryData.Twotemp2, Twotemp2);
		return this;
	}

	public String getTwotemp3() {
		return this.repository().getString(CtPumpreportHistoryData.Twotemp3);
	}

	public CtPumpreportHistoryData setTwotemp3(String Twotemp3) {
		this.repository().set(CtPumpreportHistoryData.Twotemp3, Twotemp3);
		return this;
	}

	public String getReachingpressureh() {
		return this.repository().getString(CtPumpreportHistoryData.Reachingpressureh);
	}

	public CtPumpreportHistoryData setReachingpressureh(String Reachingpressureh) {
		this.repository().set(CtPumpreportHistoryData.Reachingpressureh, Reachingpressureh);
		return this;
	}

	public String getReachingpressurepa() {
		return this.repository().getString(CtPumpreportHistoryData.Reachingpressurepa);
	}

	public CtPumpreportHistoryData setReachingpressurepa(String Reachingpressurepa) {
		this.repository().set(CtPumpreportHistoryData.Reachingpressurepa, Reachingpressurepa);
		return this;
	}

	public String getVibration() {
		return this.repository().getString(CtPumpreportHistoryData.Vibration);
	}

	public CtPumpreportHistoryData setVibration(String Vibration) {
		this.repository().set(CtPumpreportHistoryData.Vibration, Vibration);
		return this;
	}

	public String getSound() {
		return this.repository().getString(CtPumpreportHistoryData.Sound);
	}

	public CtPumpreportHistoryData setSound(String Sound) {
		this.repository().set(CtPumpreportHistoryData.Sound, Sound);
		return this;
	}

	public String getTime_23k() {
		return this.repository().getString(CtPumpreportHistoryData.Time_23k);
	}

	public CtPumpreportHistoryData setTime_23k(String Time_23k) {
		this.repository().set(CtPumpreportHistoryData.Time_23k, Time_23k);
		return this;
	}

	public String getTime_20k() {
		return this.repository().getString(CtPumpreportHistoryData.Time_20k);
	}

	public CtPumpreportHistoryData setTime_20k(String Time_20k) {
		this.repository().set(CtPumpreportHistoryData.Time_20k, Time_20k);
		return this;
	}

	public String getTime_18k() {
		return this.repository().getString(CtPumpreportHistoryData.Time_18k);
	}

	public CtPumpreportHistoryData setTime_18k(String Time_18k) {
		this.repository().set(CtPumpreportHistoryData.Time_18k, Time_18k);
		return this;
	}

	public String getTime_15k() {
		return this.repository().getString(CtPumpreportHistoryData.Time_15k);
	}

	public CtPumpreportHistoryData setTime_15k(String Time_15k) {
		this.repository().set(CtPumpreportHistoryData.Time_15k, Time_15k);
		return this;
	}

	public String getComments() {
		return this.repository().getString(CtPumpreportHistoryData.Comments);
	}

	public CtPumpreportHistoryData setComments(String Comments) {
		this.repository().set(CtPumpreportHistoryData.Comments, Comments);
		return this;
	}

	public String getInspresult() {
		return this.repository().getString(CtPumpreportHistoryData.Inspresult);
	}

	public CtPumpreportHistoryData setInspresult(String Inspresult) {
		this.repository().set(CtPumpreportHistoryData.Inspresult, Inspresult);
		return this;
	}

	public String getPublishdate() {
		return this.repository().getString(CtPumpreportHistoryData.Publishdate);
	}

	public CtPumpreportHistoryData setPublishdate(String Publishdate) {
		this.repository().set(CtPumpreportHistoryData.Publishdate, Publishdate);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtPumpreportHistoryData.Description);
	}

	public CtPumpreportHistoryData setDescription(String Description) {
		this.repository().set(CtPumpreportHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtPumpreportHistoryData.Creator);
	}

	public CtPumpreportHistoryData setCreator(String Creator) {
		this.repository().set(CtPumpreportHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtPumpreportHistoryData.Createdtime);
	}

	public CtPumpreportHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtPumpreportHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtPumpreportHistoryData.Modifier);
	}

	public CtPumpreportHistoryData setModifier(String Modifier) {
		this.repository().set(CtPumpreportHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtPumpreportHistoryData.Modifiedtime);
	}

	public CtPumpreportHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtPumpreportHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtPumpreportHistoryData.Txnid);
	}

	public CtPumpreportHistoryData setTxnid(String Txnid) {
		this.repository().set(CtPumpreportHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtPumpreportHistoryData.Txnuser);
	}

	public CtPumpreportHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtPumpreportHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtPumpreportHistoryData.Txntime);
	}

	public CtPumpreportHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtPumpreportHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtPumpreportHistoryData.Txngrouphistkey);
	}

	public CtPumpreportHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtPumpreportHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtPumpreportHistoryData.Txnreasoncodeclass);
	}

	public CtPumpreportHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtPumpreportHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtPumpreportHistoryData.Txnreasoncode);
	}

	public CtPumpreportHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtPumpreportHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtPumpreportHistoryData.Txncomment);
	}

	public CtPumpreportHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtPumpreportHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtPumpreportHistoryData.Validstate);
	}

	public CtPumpreportHistoryData setValidstate(String Validstate) {
		this.repository().set(CtPumpreportHistoryData.Validstate, Validstate);
		return this;
	}


}