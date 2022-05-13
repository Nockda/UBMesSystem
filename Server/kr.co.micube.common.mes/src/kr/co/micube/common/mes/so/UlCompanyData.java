package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlCompanyData extends SQLData {

	public static final String Phone = "PHONE";

	public static final String Item = "ITEM";

	public static final String Lawregno = "LAWREGNO";

	public static final String Modifier = "MODIFIER";

	public static final String Homepage = "HOMEPAGE";

	public static final String Creator = "CREATOR";

	public static final String Address = "ADDRESS";

	public static final String Businessno = "BUSINESSNO";

	public static final String Ceoname = "CEONAME";

	public static final String Category = "CATEGORY";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Description = "DESCRIPTION";

	public static final String Companyid = "COMPANYID";

	public static final String Companynameeng = "COMPANYNAMEENG";

	public static final String Companynamejpn = "COMPANYNAMEJPN";

	public static final String Companynamekor = "COMPANYNAMEKOR";

	public static final String Companytype = "COMPANYTYPE";

	public static final String Faxno = "FAXNO";
	
	public static final String Validstate = "VALIDSTATE";

	public UlCompanyData() {
		this(new UlCompanyKey()); 
	}

	public UlCompanyData(UlCompanyKey key) {
		super(key, "UlCompany");
	}


	public String getPhone() {
		return this.repository().getString(UlCompanyData.Phone);
	}

	public UlCompanyData setPhone(String Phone) {
		this.repository().set(UlCompanyData.Phone, Phone);
		return this;
	}

	public String getItem() {
		return this.repository().getString(UlCompanyData.Item);
	}

	public UlCompanyData setItem(String Item) {
		this.repository().set(UlCompanyData.Item, Item);
		return this;
	}

	public String getLawregno() {
		return this.repository().getString(UlCompanyData.Lawregno);
	}

	public UlCompanyData setLawregno(String Lawregno) {
		this.repository().set(UlCompanyData.Lawregno, Lawregno);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlCompanyData.Modifier);
	}

	public UlCompanyData setModifier(String Modifier) {
		this.repository().set(UlCompanyData.Modifier, Modifier);
		return this;
	}

	public String getHomepage() {
		return this.repository().getString(UlCompanyData.Homepage);
	}

	public UlCompanyData setHomepage(String Homepage) {
		this.repository().set(UlCompanyData.Homepage, Homepage);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlCompanyData.Creator);
	}

	public UlCompanyData setCreator(String Creator) {
		this.repository().set(UlCompanyData.Creator, Creator);
		return this;
	}

	public String getAddress() {
		return this.repository().getString(UlCompanyData.Address);
	}

	public UlCompanyData setAddress(String Address) {
		this.repository().set(UlCompanyData.Address, Address);
		return this;
	}

	public String getBusinessno() {
		return this.repository().getString(UlCompanyData.Businessno);
	}

	public UlCompanyData setBusinessno(String Businessno) {
		this.repository().set(UlCompanyData.Businessno, Businessno);
		return this;
	}

	public String getCeoname() {
		return this.repository().getString(UlCompanyData.Ceoname);
	}

	public UlCompanyData setCeoname(String Ceoname) {
		this.repository().set(UlCompanyData.Ceoname, Ceoname);
		return this;
	}

	public String getCategory() {
		return this.repository().getString(UlCompanyData.Category);
	}

	public UlCompanyData setCategory(String Category) {
		this.repository().set(UlCompanyData.Category, Category);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlCompanyData.Createdtime);
	}

	public UlCompanyData setCreatedtime(Date Createdtime) {
		this.repository().set(UlCompanyData.Createdtime, Createdtime);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlCompanyData.Modifiedtime);
	}

	public UlCompanyData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlCompanyData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlCompanyData.Description);
	}

	public UlCompanyData setDescription(String Description) {
		this.repository().set(UlCompanyData.Description, Description);
		return this;
	}

	public String getCompanynameeng() {
		return this.repository().getString(UlCompanyData.Companynameeng);
	}

	public UlCompanyData setCompanynameeng(String Companynameeng) {
		this.repository().set(UlCompanyData.Companynameeng, Companynameeng);
		return this;
	}

	public String getCompanynamejpn() {
		return this.repository().getString(UlCompanyData.Companynamejpn);
	}

	public UlCompanyData setCompanynamejpn(String Companynamejpn) {
		this.repository().set(UlCompanyData.Companynamejpn, Companynamejpn);
		return this;
	}

	public String getCompanynamekor() {
		return this.repository().getString(UlCompanyData.Companynamekor);
	}

	public UlCompanyData setCompanynamekor(String Companynamekor) {
		this.repository().set(UlCompanyData.Companynamekor, Companynamekor);
		return this;
	}

	public String getCompanytype() {
		return this.repository().getString(UlCompanyData.Companytype);
	}

	public UlCompanyData setCompanytype(String Companytype) {
		this.repository().set(UlCompanyData.Companytype, Companytype);
		return this;
	}

	public String getFaxno() {
		return this.repository().getString(UlCompanyData.Faxno);
	}

	public UlCompanyData setFaxno(String Faxno) {
		this.repository().set(UlCompanyData.Faxno, Faxno);
		return this;
	}
	
	public String getValidstate() {
		return this.repository().getString(EnterpriseData.Validstate);
	}

	public UlCompanyData setValidstate(String Validstate) {
		this.repository().set(UlCompanyData.Validstate, Validstate);
		return this;
	}


}