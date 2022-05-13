package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlModelmappingData extends SQLData {

	public static final String Description = "DESCRIPTION";

	public static final String Specid = "SPECID";

	public static final String Specname = "SPECNAME";

	public static final String Modelid = "MODELID";

	public static final String Modelname = "MODELNAME";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Modifier = "MODIFIER";

	public static final String Creator = "CREATOR";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Validstate = "VALIDSTATE";

	public UlModelmappingData() {
		this(new UlModelmappingKey()); 
	}

	public UlModelmappingData(UlModelmappingKey key) {
		super(key, "UlModelmapping");
	}


	public String getDescription() {
		return this.repository().getString(UlModelmappingData.Description);
	}

	public UlModelmappingData setDescription(String Description) {
		this.repository().set(UlModelmappingData.Description, Description);
		return this;
	}

	public String getSpecname() {
		return this.repository().getString(UlModelmappingData.Specname);
	}

	public UlModelmappingData setSpecname(String Specname) {
		this.repository().set(UlModelmappingData.Specname, Specname);
		return this;
	}

	public String getModelname() {
		return this.repository().getString(UlModelmappingData.Modelname);
	}

	public UlModelmappingData setModelname(String Modelname) {
		this.repository().set(UlModelmappingData.Modelname, Modelname);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlModelmappingData.Createdtime);
	}

	public UlModelmappingData setCreatedtime(Date Createdtime) {
		this.repository().set(UlModelmappingData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlModelmappingData.Modifier);
	}

	public UlModelmappingData setModifier(String Modifier) {
		this.repository().set(UlModelmappingData.Modifier, Modifier);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlModelmappingData.Creator);
	}

	public UlModelmappingData setCreator(String Creator) {
		this.repository().set(UlModelmappingData.Creator, Creator);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlModelmappingData.Modifiedtime);
	}

	public UlModelmappingData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlModelmappingData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlModelmappingData.Validstate);
	}

	public UlModelmappingData setValidstate(String Validstate) {
		this.repository().set(UlModelmappingData.Validstate, Validstate);
		return this;
	}


}