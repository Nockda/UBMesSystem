package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfUserData extends SQLData {

	public static final String Userid = "USERID";

	public static final String Username = "USERNAME";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Areaid = "AREAID";

	public static final String Password = "PASSWORD";

	public static final String Nickname = "NICKNAME";

	public static final String Department = "DEPARTMENT";

	public static final String Position = "POSITION";

	public static final String Duty = "DUTY";

	public static final String Shiftid = "SHIFTID";

	public static final String Emailaddress = "EMAILADDRESS";

	public static final String Homeaddress = "HOMEADDRESS";

	public static final String Cellphonenumber = "CELLPHONENUMBER";

	public static final String Languagetype = "LANGUAGETYPE";

	public static final String Seed = "SEED";

	public static final String Mainskin = "MAINSKIN";

	public static final String Userstate = "USERSTATE";

	public static final String Ipaddress = "IPADDRESS";

	public static final String Failcount = "FAILCOUNT";

	public static final String Erp_empno = "ERP_EMPNO";

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

	public SfUserData() {
		this(new SfUserKey()); 
	}

	public SfUserData(SfUserKey key) {
		super(key, "User");
	}


	public String getUsername() {
		return this.repository().getString(SfUserData.Username);
	}

	public SfUserData setUsername(String Username) {
		this.repository().set(SfUserData.Username, Username);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfUserData.Enterpriseid);
	}

	public SfUserData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfUserData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfUserData.Plantid);
	}

	public SfUserData setPlantid(String Plantid) {
		this.repository().set(SfUserData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfUserData.Areaid);
	}

	public SfUserData setAreaid(String Areaid) {
		this.repository().set(SfUserData.Areaid, Areaid);
		return this;
	}

	public String getPassword() {
		return this.repository().getString(SfUserData.Password);
	}

	public SfUserData setPassword(String Password) {
		this.repository().set(SfUserData.Password, Password);
		return this;
	}

	public String getNickname() {
		return this.repository().getString(SfUserData.Nickname);
	}

	public SfUserData setNickname(String Nickname) {
		this.repository().set(SfUserData.Nickname, Nickname);
		return this;
	}

	public String getDepartment() {
		return this.repository().getString(SfUserData.Department);
	}

	public SfUserData setDepartment(String Department) {
		this.repository().set(SfUserData.Department, Department);
		return this;
	}

	public String getPosition() {
		return this.repository().getString(SfUserData.Position);
	}

	public SfUserData setPosition(String Position) {
		this.repository().set(SfUserData.Position, Position);
		return this;
	}

	public String getDuty() {
		return this.repository().getString(SfUserData.Duty);
	}

	public SfUserData setDuty(String Duty) {
		this.repository().set(SfUserData.Duty, Duty);
		return this;
	}

	public String getShiftid() {
		return this.repository().getString(SfUserData.Shiftid);
	}

	public SfUserData setShiftid(String Shiftid) {
		this.repository().set(SfUserData.Shiftid, Shiftid);
		return this;
	}

	public String getEmailaddress() {
		return this.repository().getString(SfUserData.Emailaddress);
	}

	public SfUserData setEmailaddress(String Emailaddress) {
		this.repository().set(SfUserData.Emailaddress, Emailaddress);
		return this;
	}

	public String getHomeaddress() {
		return this.repository().getString(SfUserData.Homeaddress);
	}

	public SfUserData setHomeaddress(String Homeaddress) {
		this.repository().set(SfUserData.Homeaddress, Homeaddress);
		return this;
	}

	public String getCellphonenumber() {
		return this.repository().getString(SfUserData.Cellphonenumber);
	}

	public SfUserData setCellphonenumber(String Cellphonenumber) {
		this.repository().set(SfUserData.Cellphonenumber, Cellphonenumber);
		return this;
	}

	public String getLanguagetype() {
		return this.repository().getString(SfUserData.Languagetype);
	}

	public SfUserData setLanguagetype(String Languagetype) {
		this.repository().set(SfUserData.Languagetype, Languagetype);
		return this;
	}

	public String getSeed() {
		return this.repository().getString(SfUserData.Seed);
	}

	public SfUserData setSeed(String Seed) {
		this.repository().set(SfUserData.Seed, Seed);
		return this;
	}

	public String getMainskin() {
		return this.repository().getString(SfUserData.Mainskin);
	}

	public SfUserData setMainskin(String Mainskin) {
		this.repository().set(SfUserData.Mainskin, Mainskin);
		return this;
	}

	public String getUserstate() {
		return this.repository().getString(SfUserData.Userstate);
	}

	public SfUserData setUserstate(String Userstate) {
		this.repository().set(SfUserData.Userstate, Userstate);
		return this;
	}

	public String getIpaddress() {
		return this.repository().getString(SfUserData.Ipaddress);
	}

	public SfUserData setIpaddress(String Ipaddress) {
		this.repository().set(SfUserData.Ipaddress, Ipaddress);
		return this;
	}

	public Integer getFailcount() {
		return this.repository().getInteger(SfUserData.Failcount);
	}

	public SfUserData setFailcount(Integer Failcount) {
		this.repository().set(SfUserData.Failcount, Failcount);
		return this;
	}

	public String getErp_empno() {
		return this.repository().getString(SfUserData.Erp_empno);
	}

	public SfUserData setErp_empno(String Erp_empno) {
		this.repository().set(SfUserData.Erp_empno, Erp_empno);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfUserData.Description);
	}

	public SfUserData setDescription(String Description) {
		this.repository().set(SfUserData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfUserData.Creator);
	}

	public SfUserData setCreator(String Creator) {
		this.repository().set(SfUserData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfUserData.Createdtime);
	}

	public SfUserData setCreatedtime(Date Createdtime) {
		this.repository().set(SfUserData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfUserData.Modifier);
	}

	public SfUserData setModifier(String Modifier) {
		this.repository().set(SfUserData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfUserData.Modifiedtime);
	}

	public SfUserData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfUserData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfUserData.Lasttxnhistkey);
	}

	public SfUserData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfUserData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfUserData.Lasttxnid);
	}

	public SfUserData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfUserData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfUserData.Lasttxnuser);
	}

	public SfUserData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfUserData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfUserData.Lasttxntime);
	}

	public SfUserData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfUserData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfUserData.Lasttxncomment);
	}

	public SfUserData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfUserData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfUserData.Validstate);
	}

	public SfUserData setValidstate(String Validstate) {
		this.repository().set(SfUserData.Validstate, Validstate);
		return this;
	}


}