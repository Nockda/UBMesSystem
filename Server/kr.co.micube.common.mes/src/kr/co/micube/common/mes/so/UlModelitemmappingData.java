package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlModelitemmappingData extends SQLData {

	public static final String Modelname = "MODELNAME";

	public static final String Modelid = "MODELID";

	public static final String Domesticforeign = "DOMESTICFOREIGN";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Itemstandard = "ITEMSTANDARD";

	public static final String Modifier = "MODIFIER";

	public static final String Itemname = "ITEMNAME";

	public static final String Creator = "CREATOR";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Validstate = "VALIDSTATE";

	public static final String Itemassetcategory = "ITEMASSETCATEGORY";

	public static final String Itemid = "ITEMID";

	public UlModelitemmappingData() {
		this(new UlModelitemmappingKey()); 
	}

	public UlModelitemmappingData(UlModelitemmappingKey key) {
		super(key, "UlModelitemmapping");
	}


	public String getModelname() {
		return this.repository().getString(UlModelitemmappingData.Modelname);
	}

	public UlModelitemmappingData setModelname(String Modelname) {
		this.repository().set(UlModelitemmappingData.Modelname, Modelname);
		return this;
	}

	public String getDomesticforeign() {
		return this.repository().getString(UlModelitemmappingData.Domesticforeign);
	}

	public UlModelitemmappingData setDomesticforeign(String Domesticforeign) {
		this.repository().set(UlModelitemmappingData.Domesticforeign, Domesticforeign);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlModelitemmappingData.Createdtime);
	}

	public UlModelitemmappingData setCreatedtime(Date Createdtime) {
		this.repository().set(UlModelitemmappingData.Createdtime, Createdtime);
		return this;
	}

	public String getItemstandard() {
		return this.repository().getString(UlModelitemmappingData.Itemstandard);
	}

	public UlModelitemmappingData setItemstandard(String Itemstandard) {
		this.repository().set(UlModelitemmappingData.Itemstandard, Itemstandard);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlModelitemmappingData.Modifier);
	}

	public UlModelitemmappingData setModifier(String Modifier) {
		this.repository().set(UlModelitemmappingData.Modifier, Modifier);
		return this;
	}

	public String getItemname() {
		return this.repository().getString(UlModelitemmappingData.Itemname);
	}

	public UlModelitemmappingData setItemname(String Itemname) {
		this.repository().set(UlModelitemmappingData.Itemname, Itemname);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlModelitemmappingData.Creator);
	}

	public UlModelitemmappingData setCreator(String Creator) {
		this.repository().set(UlModelitemmappingData.Creator, Creator);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlModelitemmappingData.Modifiedtime);
	}

	public UlModelitemmappingData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlModelitemmappingData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlModelitemmappingData.Validstate);
	}

	public UlModelitemmappingData setValidstate(String Validstate) {
		this.repository().set(UlModelitemmappingData.Validstate, Validstate);
		return this;
	}

	public String getItemassetcategory() {
		return this.repository().getString(UlModelitemmappingData.Itemassetcategory);
	}

	public UlModelitemmappingData setItemassetcategory(String Itemassetcategory) {
		this.repository().set(UlModelitemmappingData.Itemassetcategory, Itemassetcategory);
		return this;
	}


}