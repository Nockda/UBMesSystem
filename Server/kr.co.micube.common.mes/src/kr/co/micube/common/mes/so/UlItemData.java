package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlItemData extends SQLData {

	public static final String Domesticforeign = "DOMESTICFOREIGN";

	public static final String Mediumcategory = "MEDIUMCATEGORY";

	public static final String Largecategory = "LARGECATEGORY";

	public static final String Additional = "ADDITIONAL";

	public static final String Itemname = "ITEMNAME";

	public static final String Itemstandard = "ITEMSTANDARD";

	public static final String Itemstatus = "ITEMSTATUS";

	public static final String Itemid = "ITEMID";

	public static final String Itemassetcategory = "ITEMASSETCATEGORY";

	public static final String Department = "DEPARTMENT";

	public static final String Createdt = "CREATEDT";

	public static final String Smallcategory = "SMALLCATEGORY";

	public static final String Unit = "UNIT";

	public static final String Updatedt = "UPDATEDT";

	public static final String Userid = "USERID";

	public UlItemData() {
		this(new UlItemKey()); 
	}

	public UlItemData(UlItemKey key) {
		super(key, "UlItem");
	}


	public String getDomesticforeign() {
		return this.repository().getString(UlItemData.Domesticforeign);
	}

	public UlItemData setDomesticforeign(String Domesticforeign) {
		this.repository().set(UlItemData.Domesticforeign, Domesticforeign);
		return this;
	}

	public String getMediumcategory() {
		return this.repository().getString(UlItemData.Mediumcategory);
	}

	public UlItemData setMediumcategory(String Mediumcategory) {
		this.repository().set(UlItemData.Mediumcategory, Mediumcategory);
		return this;
	}

	public String getLargecategory() {
		return this.repository().getString(UlItemData.Largecategory);
	}

	public UlItemData setLargecategory(String Largecategory) {
		this.repository().set(UlItemData.Largecategory, Largecategory);
		return this;
	}

	public String getAdditional() {
		return this.repository().getString(UlItemData.Additional);
	}

	public UlItemData setAdditional(String Additional) {
		this.repository().set(UlItemData.Additional, Additional);
		return this;
	}

	public String getItemname() {
		return this.repository().getString(UlItemData.Itemname);
	}

	public UlItemData setItemname(String Itemname) {
		this.repository().set(UlItemData.Itemname, Itemname);
		return this;
	}

	public String getItemstandard() {
		return this.repository().getString(UlItemData.Itemstandard);
	}

	public UlItemData setItemstandard(String Itemstandard) {
		this.repository().set(UlItemData.Itemstandard, Itemstandard);
		return this;
	}

	public String getItemstatus() {
		return this.repository().getString(UlItemData.Itemstatus);
	}

	public UlItemData setItemstatus(String Itemstatus) {
		this.repository().set(UlItemData.Itemstatus, Itemstatus);
		return this;
	}

	public String getItemassetcategory() {
		return this.repository().getString(UlItemData.Itemassetcategory);
	}

	public UlItemData setItemassetcategory(String Itemassetcategory) {
		this.repository().set(UlItemData.Itemassetcategory, Itemassetcategory);
		return this;
	}

	public String getDepartment() {
		return this.repository().getString(UlItemData.Department);
	}

	public UlItemData setDepartment(String Department) {
		this.repository().set(UlItemData.Department, Department);
		return this;
	}

	public Date getCreatedt() {
		return this.repository().getDate(UlItemData.Createdt);
	}

	public UlItemData setCreatedt(Date Createdt) {
		this.repository().set(UlItemData.Createdt, Createdt);
		return this;
	}

	public String getSmallcategory() {
		return this.repository().getString(UlItemData.Smallcategory);
	}

	public UlItemData setSmallcategory(String Smallcategory) {
		this.repository().set(UlItemData.Smallcategory, Smallcategory);
		return this;
	}

	public String getUnit() {
		return this.repository().getString(UlItemData.Unit);
	}

	public UlItemData setUnit(String Unit) {
		this.repository().set(UlItemData.Unit, Unit);
		return this;
	}

	public Date getUpdatedt() {
		return this.repository().getDate(UlItemData.Updatedt);
	}

	public UlItemData setUpdatedt(Date Updatedt) {
		this.repository().set(UlItemData.Updatedt, Updatedt);
		return this;
	}


}