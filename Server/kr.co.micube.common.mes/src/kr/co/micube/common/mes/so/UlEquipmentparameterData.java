package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlEquipmentparameterData extends SQLData {

	public static final String Modifier = "MODIFIER";

	public static final String Parameterid = "PARAMETERID";

	public static final String Parameterlevel = "PARAMETERLEVEL";

	public static final String Parameternameeng = "PARAMETERNAMEENG";

	public static final String Parameternamejpn = "PARAMETERNAMEJPN";

	public static final String Parameternamekor = "PARAMETERNAMEKOR";

	public static final String Managestate = "MANAGESTATE";

	public static final String Lowerspeclimit = "LOWERSPECLIMIT";

	public static final String Svparameterid = "SVPARAMETERID";

	public static final String Svrate = "SVRATE";

	public static final String Target = "TARGET";

	public static final String Validstate = "VALIDSTATE";

	public static final String Unit = "UNIT";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Averagevalue = "AVERAGEVALUE";

	public static final String Uppercontrollimit = "UPPERCONTROLLIMIT";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Description = "DESCRIPTION";

	public static final String Limittime = "LIMITTIME";

	public static final String Upperspeclimit = "UPPERSPECLIMIT";

	public static final String Lowercontrollimit = "LOWERCONTROLLIMIT";

	public static final String Dataformat = "DATAFORMAT";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Gathercycle = "GATHERCYCLE";

	public static final String Interlockstate = "INTERLOCKSTATE";

	public UlEquipmentparameterData() {
		this(new UlEquipmentparameterKey()); 
	}

	public UlEquipmentparameterData(UlEquipmentparameterKey key) {
		super(key, "UlEquipmentparameter");
	}


	public String getModifier() {
		return this.repository().getString(UlEquipmentparameterData.Modifier);
	}

	public UlEquipmentparameterData setModifier(String Modifier) {
		this.repository().set(UlEquipmentparameterData.Modifier, Modifier);
		return this;
	}

	public String getParameterlevel() {
		return this.repository().getString(UlEquipmentparameterData.Parameterlevel);
	}

	public UlEquipmentparameterData setParameterlevel(String Parameterlevel) {
		this.repository().set(UlEquipmentparameterData.Parameterlevel, Parameterlevel);
		return this;
	}

	public String getParameternameeng() {
		return this.repository().getString(UlEquipmentparameterData.Parameternameeng);
	}

	public UlEquipmentparameterData setParameternameeng(String Parameternameeng) {
		this.repository().set(UlEquipmentparameterData.Parameternameeng, Parameternameeng);
		return this;
	}

	public String getParameternamejpn() {
		return this.repository().getString(UlEquipmentparameterData.Parameternamejpn);
	}

	public UlEquipmentparameterData setParameternamejpn(String Parameternamejpn) {
		this.repository().set(UlEquipmentparameterData.Parameternamejpn, Parameternamejpn);
		return this;
	}

	public String getParameternamekor() {
		return this.repository().getString(UlEquipmentparameterData.Parameternamekor);
	}

	public UlEquipmentparameterData setParameternamekor(String Parameternamekor) {
		this.repository().set(UlEquipmentparameterData.Parameternamekor, Parameternamekor);
		return this;
	}

	public String getManagestate() {
		return this.repository().getString(UlEquipmentparameterData.Managestate);
	}

	public UlEquipmentparameterData setManagestate(String Managestate) {
		this.repository().set(UlEquipmentparameterData.Managestate, Managestate);
		return this;
	}

	public Double getLowerspeclimit() {
		return this.repository().getDouble(UlEquipmentparameterData.Lowerspeclimit);
	}

	public UlEquipmentparameterData setLowerspeclimit(Double Lowerspeclimit) {
		this.repository().set(UlEquipmentparameterData.Lowerspeclimit, Lowerspeclimit);
		return this;
	}

	public String getSvparameterid() {
		return this.repository().getString(UlEquipmentparameterData.Svparameterid);
	}

	public UlEquipmentparameterData setSvparameterid(String Svparameterid) {
		this.repository().set(UlEquipmentparameterData.Svparameterid, Svparameterid);
		return this;
	}

	public Double getSvrate() {
		return this.repository().getDouble(UlEquipmentparameterData.Svrate);
	}

	public UlEquipmentparameterData setSvrate(Double Svrate) {
		this.repository().set(UlEquipmentparameterData.Svrate, Svrate);
		return this;
	}

	public Double getTarget() {
		return this.repository().getDouble(UlEquipmentparameterData.Target);
	}

	public UlEquipmentparameterData setTarget(Double Target) {
		this.repository().set(UlEquipmentparameterData.Target, Target);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlEquipmentparameterData.Validstate);
	}

	public UlEquipmentparameterData setValidstate(String Validstate) {
		this.repository().set(UlEquipmentparameterData.Validstate, Validstate);
		return this;
	}

	public String getUnit() {
		return this.repository().getString(UlEquipmentparameterData.Unit);
	}

	public UlEquipmentparameterData setUnit(String Unit) {
		this.repository().set(UlEquipmentparameterData.Unit, Unit);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlEquipmentparameterData.Creator);
	}

	public UlEquipmentparameterData setCreator(String Creator) {
		this.repository().set(UlEquipmentparameterData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlEquipmentparameterData.Createdtime);
	}

	public UlEquipmentparameterData setCreatedtime(Date Createdtime) {
		this.repository().set(UlEquipmentparameterData.Createdtime, Createdtime);
		return this;
	}

	public Double getAveragevalue() {
		return this.repository().getDouble(UlEquipmentparameterData.Averagevalue);
	}

	public UlEquipmentparameterData setAveragevalue(Double Averagevalue) {
		this.repository().set(UlEquipmentparameterData.Averagevalue, Averagevalue);
		return this;
	}

	public Double getUppercontrollimit() {
		return this.repository().getDouble(UlEquipmentparameterData.Uppercontrollimit);
	}

	public UlEquipmentparameterData setUppercontrollimit(Double Uppercontrollimit) {
		this.repository().set(UlEquipmentparameterData.Uppercontrollimit, Uppercontrollimit);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlEquipmentparameterData.Modifiedtime);
	}

	public UlEquipmentparameterData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlEquipmentparameterData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlEquipmentparameterData.Description);
	}

	public UlEquipmentparameterData setDescription(String Description) {
		this.repository().set(UlEquipmentparameterData.Description, Description);
		return this;
	}

	public Integer getLimittime() {
		return this.repository().getInteger(UlEquipmentparameterData.Limittime);
	}

	public UlEquipmentparameterData setLimittime(Integer Limittime) {
		this.repository().set(UlEquipmentparameterData.Limittime, Limittime);
		return this;
	}

	public Double getUpperspeclimit() {
		return this.repository().getDouble(UlEquipmentparameterData.Upperspeclimit);
	}

	public UlEquipmentparameterData setUpperspeclimit(Double Upperspeclimit) {
		this.repository().set(UlEquipmentparameterData.Upperspeclimit, Upperspeclimit);
		return this;
	}

	public Double getLowercontrollimit() {
		return this.repository().getDouble(UlEquipmentparameterData.Lowercontrollimit);
	}

	public UlEquipmentparameterData setLowercontrollimit(Double Lowercontrollimit) {
		this.repository().set(UlEquipmentparameterData.Lowercontrollimit, Lowercontrollimit);
		return this;
	}

	public String getDataformat() {
		return this.repository().getString(UlEquipmentparameterData.Dataformat);
	}

	public UlEquipmentparameterData setDataformat(String Dataformat) {
		this.repository().set(UlEquipmentparameterData.Dataformat, Dataformat);
		return this;
	}

	public Integer getGathercycle() {
		return this.repository().getInteger(UlEquipmentparameterData.Gathercycle);
	}

	public UlEquipmentparameterData setGathercycle(Integer Gathercycle) {
		this.repository().set(UlEquipmentparameterData.Gathercycle, Gathercycle);
		return this;
	}

	public String getInterlockstate() {
		return this.repository().getString(UlEquipmentparameterData.Interlockstate);
	}

	public UlEquipmentparameterData setInterlockstate(String Interlockstate) {
		this.repository().set(UlEquipmentparameterData.Interlockstate, Interlockstate);
		return this;
	}


}