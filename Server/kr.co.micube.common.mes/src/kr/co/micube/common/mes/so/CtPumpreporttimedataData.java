package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtPumpreporttimedataData extends SQLData {

	public static final String Lotid = "LOTID";

	public static final String Inspectiondegree = "INSPECTIONDEGREE";

	public static final String Measuretime = "MEASURETIME";

	public static final String Supplyvalue = "SUPPLYVALUE";

	public static final String Returnvalue = "RETURNVALUE";

	public static final String Twotempvalue = "TWOTEMPVALUE";

	public static final String Tcvalue = "TCVALUE";

	public static final String Vacvalue = "VACVALUE";

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

	public CtPumpreporttimedataData() {
		this(new CtPumpreporttimedataKey()); 
	}

	public CtPumpreporttimedataData(CtPumpreporttimedataKey key) {
		super(key, "CtPumpreporttimedata");
	}


	public String getSupplyvalue() {
		return this.repository().getString(CtPumpreporttimedataData.Supplyvalue);
	}

	public CtPumpreporttimedataData setSupplyvalue(String Supplyvalue) {
		this.repository().set(CtPumpreporttimedataData.Supplyvalue, Supplyvalue);
		return this;
	}

	public String getReturnvalue() {
		return this.repository().getString(CtPumpreporttimedataData.Returnvalue);
	}

	public CtPumpreporttimedataData setReturnvalue(String Returnvalue) {
		this.repository().set(CtPumpreporttimedataData.Returnvalue, Returnvalue);
		return this;
	}

	public String getTwotempvalue() {
		return this.repository().getString(CtPumpreporttimedataData.Twotempvalue);
	}

	public CtPumpreporttimedataData setTwotempvalue(String Twotempvalue) {
		this.repository().set(CtPumpreporttimedataData.Twotempvalue, Twotempvalue);
		return this;
	}

	public String getTcvalue() {
		return this.repository().getString(CtPumpreporttimedataData.Tcvalue);
	}

	public CtPumpreporttimedataData setTcvalue(String Tcvalue) {
		this.repository().set(CtPumpreporttimedataData.Tcvalue, Tcvalue);
		return this;
	}

	public String getVacvalue() {
		return this.repository().getString(CtPumpreporttimedataData.Vacvalue);
	}

	public CtPumpreporttimedataData setVacvalue(String Vacvalue) {
		this.repository().set(CtPumpreporttimedataData.Vacvalue, Vacvalue);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtPumpreporttimedataData.Description);
	}

	public CtPumpreporttimedataData setDescription(String Description) {
		this.repository().set(CtPumpreporttimedataData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtPumpreporttimedataData.Creator);
	}

	public CtPumpreporttimedataData setCreator(String Creator) {
		this.repository().set(CtPumpreporttimedataData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtPumpreporttimedataData.Createdtime);
	}

	public CtPumpreporttimedataData setCreatedtime(Date Createdtime) {
		this.repository().set(CtPumpreporttimedataData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtPumpreporttimedataData.Modifier);
	}

	public CtPumpreporttimedataData setModifier(String Modifier) {
		this.repository().set(CtPumpreporttimedataData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtPumpreporttimedataData.Modifiedtime);
	}

	public CtPumpreporttimedataData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtPumpreporttimedataData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtPumpreporttimedataData.Lasttxnhistkey);
	}

	public CtPumpreporttimedataData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtPumpreporttimedataData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtPumpreporttimedataData.Lasttxnid);
	}

	public CtPumpreporttimedataData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtPumpreporttimedataData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtPumpreporttimedataData.Lasttxnuser);
	}

	public CtPumpreporttimedataData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtPumpreporttimedataData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtPumpreporttimedataData.Lasttxntime);
	}

	public CtPumpreporttimedataData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtPumpreporttimedataData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtPumpreporttimedataData.Lasttxncomment);
	}

	public CtPumpreporttimedataData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtPumpreporttimedataData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtPumpreporttimedataData.Validstate);
	}

	public CtPumpreporttimedataData setValidstate(String Validstate) {
		this.repository().set(CtPumpreporttimedataData.Validstate, Validstate);
		return this;
	}


}