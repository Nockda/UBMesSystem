package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlModelData extends SQLData {

	public static final String Validstate = "VALIDSTATE";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Modifier = "MODIFIER";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Modelnameeng = "MODELNAMEENG";

	public static final String Modelnamejpn = "MODELNAMEJPN";

	public static final String Modelnamekor = "MODELNAMEKOR";

	public static final String Modelid = "MODELID";

	public static final String Description = "DESCRIPTION";

	public UlModelData() {
		this(new UlModelKey()); 
	}

	public UlModelData(UlModelKey key) {
		super(key, "UlModel");
	}


	public String getValidstate() {
		return this.repository().getString(UlModelData.Validstate);
	}

	public UlModelData setValidstate(String Validstate) {
		this.repository().set(UlModelData.Validstate, Validstate);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlModelData.Modifiedtime);
	}

	public UlModelData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlModelData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlModelData.Creator);
	}

	public UlModelData setCreator(String Creator) {
		this.repository().set(UlModelData.Creator, Creator);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlModelData.Modifier);
	}

	public UlModelData setModifier(String Modifier) {
		this.repository().set(UlModelData.Modifier, Modifier);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlModelData.Createdtime);
	}

	public UlModelData setCreatedtime(Date Createdtime) {
		this.repository().set(UlModelData.Createdtime, Createdtime);
		return this;
	}

	public String getModelnameeng() {
		return this.repository().getString(UlModelData.Modelnameeng);
	}

	public UlModelData setModelnameeng(String Modelnameeng) {
		this.repository().set(UlModelData.Modelnameeng, Modelnameeng);
		return this;
	}

	public String getModelnamejpn() {
		return this.repository().getString(UlModelData.Modelnamejpn);
	}

	public UlModelData setModelnamejpn(String Modelnamejpn) {
		this.repository().set(UlModelData.Modelnamejpn, Modelnamejpn);
		return this;
	}

	public String getModelnamekor() {
		return this.repository().getString(UlModelData.Modelnamekor);
	}

	public UlModelData setModelnamekor(String Modelnamekor) {
		this.repository().set(UlModelData.Modelnamekor, Modelnamekor);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlModelData.Description);
	}

	public UlModelData setDescription(String Description) {
		this.repository().set(UlModelData.Description, Description);
		return this;
	}


}