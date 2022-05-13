package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlProdefficiencyData extends SQLData {

	public static final String Workdate = "WORKDATE";

	public static final String Teamid = "TEAMID";

	public static final String Workyear = "WORKYEAR";

	public static final String Workmonth = "WORKMONTH";

	public static final String Weeknumber = "WEEKNUMBER";

	public static final String Dayofweek = "DAYOFWEEK";

	public static final String Workdatetype = "WORKDATETYPE";

	public static final String Standworkhour = "STANDWORKHOUR";

	public static final String Standtranshour = "STANDTRANSHOUR";

	public static final String Standworkercnt = "STANDWORKERCNT";

	public static final String Workhour = "WORKHOUR";

	public static final String Transhour = "TRANSHOUR";

	public static final String Apphour = "APPHOUR";

	public static final String Supporthour = "SUPPORTHOUR";

	public static final String Extendhour = "EXTENDHOUR";

	public static final String Holidayhour = "HOLIDAYHOUR";

	public static final String Educationhour = "EDUCATIONHOUR";

	public static final String Traininghour = "TRAININGHOUR";

	public static final String Dispatchhour = "DISPATCHHOUR";

	public static final String Totalworkhour = "TOTALWORKHOUR";

	public static final String Totalavailablehour = "TOTALAVAILABLEHOUR";

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

	public UlProdefficiencyData() {
		this(new UlProdefficiencyKey()); 
	}

	public UlProdefficiencyData(UlProdefficiencyKey key) {
		super(key, "UlProdefficiency");
	}


	public Integer getWorkyear() {
		return this.repository().getInteger(UlProdefficiencyData.Workyear);
	}

	public UlProdefficiencyData setWorkyear(Integer Workyear) {
		this.repository().set(UlProdefficiencyData.Workyear, Workyear);
		return this;
	}

	public Integer getWorkmonth() {
		return this.repository().getInteger(UlProdefficiencyData.Workmonth);
	}

	public UlProdefficiencyData setWorkmonth(Integer Workmonth) {
		this.repository().set(UlProdefficiencyData.Workmonth, Workmonth);
		return this;
	}

	public Integer getWeeknumber() {
		return this.repository().getInteger(UlProdefficiencyData.Weeknumber);
	}

	public UlProdefficiencyData setWeeknumber(Integer Weeknumber) {
		this.repository().set(UlProdefficiencyData.Weeknumber, Weeknumber);
		return this;
	}

	public String getDayofweek() {
		return this.repository().getString(UlProdefficiencyData.Dayofweek);
	}

	public UlProdefficiencyData setDayofweek(String Dayofweek) {
		this.repository().set(UlProdefficiencyData.Dayofweek, Dayofweek);
		return this;
	}

	public String getWorkdatetype() {
		return this.repository().getString(UlProdefficiencyData.Workdatetype);
	}

	public UlProdefficiencyData setWorkdatetype(String Workdatetype) {
		this.repository().set(UlProdefficiencyData.Workdatetype, Workdatetype);
		return this;
	}

	public Double getStandworkhour() {
		return this.repository().getDouble(UlProdefficiencyData.Standworkhour);
	}

	public UlProdefficiencyData setStandworkhour(Double Standworkhour) {
		this.repository().set(UlProdefficiencyData.Standworkhour, Standworkhour);
		return this;
	}

	public Double getStandtranshour() {
		return this.repository().getDouble(UlProdefficiencyData.Standtranshour);
	}

	public UlProdefficiencyData setStandtranshour(Double Standtranshour) {
		this.repository().set(UlProdefficiencyData.Standtranshour, Standtranshour);
		return this;
	}

	public Double getStandworkercnt() {
		return this.repository().getDouble(UlProdefficiencyData.Standworkercnt);
	}

	public UlProdefficiencyData setStandworkercnt(Double Standworkercnt) {
		this.repository().set(UlProdefficiencyData.Standworkercnt, Standworkercnt);
		return this;
	}

	public Double getWorkhour() {
		return this.repository().getDouble(UlProdefficiencyData.Workhour);
	}

	public UlProdefficiencyData setWorkhour(Double Workhour) {
		this.repository().set(UlProdefficiencyData.Workhour, Workhour);
		return this;
	}

	public Double getTranshour() {
		return this.repository().getDouble(UlProdefficiencyData.Transhour);
	}

	public UlProdefficiencyData setTranshour(Double Transhour) {
		this.repository().set(UlProdefficiencyData.Transhour, Transhour);
		return this;
	}

	public Double getApphour() {
		return this.repository().getDouble(UlProdefficiencyData.Apphour);
	}

	public UlProdefficiencyData setApphour(Double Apphour) {
		this.repository().set(UlProdefficiencyData.Apphour, Apphour);
		return this;
	}

	public Double getSupporthour() {
		return this.repository().getDouble(UlProdefficiencyData.Supporthour);
	}

	public UlProdefficiencyData setSupporthour(Double Supporthour) {
		this.repository().set(UlProdefficiencyData.Supporthour, Supporthour);
		return this;
	}

	public Double getExtendhour() {
		return this.repository().getDouble(UlProdefficiencyData.Extendhour);
	}

	public UlProdefficiencyData setExtendhour(Double Extendhour) {
		this.repository().set(UlProdefficiencyData.Extendhour, Extendhour);
		return this;
	}

	public Double getHolidayhour() {
		return this.repository().getDouble(UlProdefficiencyData.Holidayhour);
	}

	public UlProdefficiencyData setHolidayhour(Double Holidayhour) {
		this.repository().set(UlProdefficiencyData.Holidayhour, Holidayhour);
		return this;
	}

	public Double getEducationhour() {
		return this.repository().getDouble(UlProdefficiencyData.Educationhour);
	}

	public UlProdefficiencyData setEducationhour(Double Educationhour) {
		this.repository().set(UlProdefficiencyData.Educationhour, Educationhour);
		return this;
	}

	public Double getTraininghour() {
		return this.repository().getDouble(UlProdefficiencyData.Traininghour);
	}

	public UlProdefficiencyData setTraininghour(Double Traininghour) {
		this.repository().set(UlProdefficiencyData.Traininghour, Traininghour);
		return this;
	}

	public Double getDispatchhour() {
		return this.repository().getDouble(UlProdefficiencyData.Dispatchhour);
	}

	public UlProdefficiencyData setDispatchhour(Double Dispatchhour) {
		this.repository().set(UlProdefficiencyData.Dispatchhour, Dispatchhour);
		return this;
	}

	public Double getTotalworkhour() {
		return this.repository().getDouble(UlProdefficiencyData.Totalworkhour);
	}

	public UlProdefficiencyData setTotalworkhour(Double Totalworkhour) {
		this.repository().set(UlProdefficiencyData.Totalworkhour, Totalworkhour);
		return this;
	}

	public Double getTotalavailablehour() {
		return this.repository().getDouble(UlProdefficiencyData.Totalavailablehour);
	}

	public UlProdefficiencyData setTotalavailablehour(Double Totalavailablehour) {
		this.repository().set(UlProdefficiencyData.Totalavailablehour, Totalavailablehour);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlProdefficiencyData.Description);
	}

	public UlProdefficiencyData setDescription(String Description) {
		this.repository().set(UlProdefficiencyData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlProdefficiencyData.Creator);
	}

	public UlProdefficiencyData setCreator(String Creator) {
		this.repository().set(UlProdefficiencyData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlProdefficiencyData.Createdtime);
	}

	public UlProdefficiencyData setCreatedtime(Date Createdtime) {
		this.repository().set(UlProdefficiencyData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlProdefficiencyData.Modifier);
	}

	public UlProdefficiencyData setModifier(String Modifier) {
		this.repository().set(UlProdefficiencyData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlProdefficiencyData.Modifiedtime);
	}

	public UlProdefficiencyData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlProdefficiencyData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(UlProdefficiencyData.Lasttxnhistkey);
	}

	public UlProdefficiencyData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(UlProdefficiencyData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(UlProdefficiencyData.Lasttxnid);
	}

	public UlProdefficiencyData setLasttxnid(String Lasttxnid) {
		this.repository().set(UlProdefficiencyData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(UlProdefficiencyData.Lasttxnuser);
	}

	public UlProdefficiencyData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(UlProdefficiencyData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(UlProdefficiencyData.Lasttxntime);
	}

	public UlProdefficiencyData setLasttxntime(Date Lasttxntime) {
		this.repository().set(UlProdefficiencyData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(UlProdefficiencyData.Lasttxncomment);
	}

	public UlProdefficiencyData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(UlProdefficiencyData.Lasttxncomment, Lasttxncomment);
		return this;
	}


}