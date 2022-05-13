package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class EnterpriseData extends SQLData {

	public static final String Phone = "PHONE";

	public static final String Validstate = "VALIDSTATE";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Faxno = "FAXNO";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Lasttxnid = "LASTTXNID";

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Modifier = "MODIFIER";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Description = "DESCRIPTION";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Address = "ADDRESS";

	public static final String Enterprisename = "ENTERPRISENAME";

	public EnterpriseData() {
		this(new EnterpriseKey()); 
	}

	public EnterpriseData(EnterpriseKey key) {
		super(key, "Enterprise");
	}


	public String getPhone() {
		return this.repository().getString(EnterpriseData.Phone);
	}

	public EnterpriseData setPhone(String Phone) {
		this.repository().set(EnterpriseData.Phone, Phone);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(EnterpriseData.Validstate);
	}

	public EnterpriseData setValidstate(String Validstate) {
		this.repository().set(EnterpriseData.Validstate, Validstate);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(EnterpriseData.Lasttxncomment);
	}

	public EnterpriseData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(EnterpriseData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getFaxno() {
		return this.repository().getString(EnterpriseData.Faxno);
	}

	public EnterpriseData setFaxno(String Faxno) {
		this.repository().set(EnterpriseData.Faxno, Faxno);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(EnterpriseData.Lasttxnuser);
	}

	public EnterpriseData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(EnterpriseData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(EnterpriseData.Lasttxntime);
	}

	public EnterpriseData setLasttxntime(Date Lasttxntime) {
		this.repository().set(EnterpriseData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(EnterpriseData.Lasttxnid);
	}

	public EnterpriseData setLasttxnid(String Lasttxnid) {
		this.repository().set(EnterpriseData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(EnterpriseData.Lasttxnhistkey);
	}

	public EnterpriseData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(EnterpriseData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(EnterpriseData.Modifiedtime);
	}

	public EnterpriseData setModifiedtime(Date Modifiedtime) {
		this.repository().set(EnterpriseData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(EnterpriseData.Modifier);
	}

	public EnterpriseData setModifier(String Modifier) {
		this.repository().set(EnterpriseData.Modifier, Modifier);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(EnterpriseData.Description);
	}

	public EnterpriseData setDescription(String Description) {
		this.repository().set(EnterpriseData.Description, Description);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(EnterpriseData.Createdtime);
	}

	public EnterpriseData setCreatedtime(Date Createdtime) {
		this.repository().set(EnterpriseData.Createdtime, Createdtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(EnterpriseData.Creator);
	}

	public EnterpriseData setCreator(String Creator) {
		this.repository().set(EnterpriseData.Creator, Creator);
		return this;
	}

	public String getAddress() {
		return this.repository().getString(EnterpriseData.Address);
	}

	public EnterpriseData setAddress(String Address) {
		this.repository().set(EnterpriseData.Address, Address);
		return this;
	}

	public String getEnterprisename() {
		return this.repository().getString(EnterpriseData.Enterprisename);
	}

	public EnterpriseData setEnterprisename(String Enterprisename) {
		this.repository().set(EnterpriseData.Enterprisename, Enterprisename);
		return this;
	}


}