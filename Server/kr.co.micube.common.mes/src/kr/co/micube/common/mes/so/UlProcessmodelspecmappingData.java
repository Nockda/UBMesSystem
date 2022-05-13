package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlProcessmodelspecmappingData extends SQLData {

	public static final String Modelid = "MODELID";

	public static final String Modelname = "MODELNAME";

	public static final String Specid = "SPECID";

	public static final String Processname = "PROCESSNAME";

	public static final String Processid = "PROCESSID";

	public static final String Validstate = "VALIDSTATE";

	public static final String Modifier = "MODIFIER";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Specname = "SPECNAME";

	public UlProcessmodelspecmappingData() {
		this(new UlProcessmodelspecmappingKey()); 
	}

	public UlProcessmodelspecmappingData(UlProcessmodelspecmappingKey key) {
		super(key, "UlProcessmodelspecmapping");
	}


	public String getModelname() {
		return this.repository().getString(UlProcessmodelspecmappingData.Modelname);
	}

	public UlProcessmodelspecmappingData setModelname(String Modelname) {
		this.repository().set(UlProcessmodelspecmappingData.Modelname, Modelname);
		return this;
	}

	public String getProcessname() {
		return this.repository().getString(UlProcessmodelspecmappingData.Processname);
	}

	public UlProcessmodelspecmappingData setProcessname(String Processname) {
		this.repository().set(UlProcessmodelspecmappingData.Processname, Processname);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlProcessmodelspecmappingData.Validstate);
	}

	public UlProcessmodelspecmappingData setValidstate(String Validstate) {
		this.repository().set(UlProcessmodelspecmappingData.Validstate, Validstate);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlProcessmodelspecmappingData.Modifier);
	}

	public UlProcessmodelspecmappingData setModifier(String Modifier) {
		this.repository().set(UlProcessmodelspecmappingData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlProcessmodelspecmappingData.Modifiedtime);
	}

	public UlProcessmodelspecmappingData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlProcessmodelspecmappingData.Modifiedtime, Modifiedtime);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlProcessmodelspecmappingData.Createdtime);
	}

	public UlProcessmodelspecmappingData setCreatedtime(Date Createdtime) {
		this.repository().set(UlProcessmodelspecmappingData.Createdtime, Createdtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlProcessmodelspecmappingData.Creator);
	}

	public UlProcessmodelspecmappingData setCreator(String Creator) {
		this.repository().set(UlProcessmodelspecmappingData.Creator, Creator);
		return this;
	}

	public String getSpecname() {
		return this.repository().getString(UlProcessmodelspecmappingData.Specname);
	}

	public UlProcessmodelspecmappingData setSpecname(String Specname) {
		this.repository().set(UlProcessmodelspecmappingData.Specname, Specname);
		return this;
	}


}