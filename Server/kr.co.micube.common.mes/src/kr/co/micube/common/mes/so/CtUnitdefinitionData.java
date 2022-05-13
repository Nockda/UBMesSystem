package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtUnitdefinitionData extends SQLData {

	public static final String Unitid = "UNITID";

	public static final String Unitname = "UNITNAME";

	public static final String Unit = "UNIT";

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

	public static final String Erp_unitid = "ERP_UNITID";

	public CtUnitdefinitionData() {
		this(new CtUnitdefinitionKey()); 
	}

	public CtUnitdefinitionData(CtUnitdefinitionKey key) {
		super(key, "CtUnitdefinition");
	}


	public String getUnitname() {
		return this.repository().getString(CtUnitdefinitionData.Unitname);
	}

	public CtUnitdefinitionData setUnitname(String Unitname) {
		this.repository().set(CtUnitdefinitionData.Unitname, Unitname);
		return this;
	}

	public String getUnit() {
		return this.repository().getString(CtUnitdefinitionData.Unit);
	}

	public CtUnitdefinitionData setUnit(String Unit) {
		this.repository().set(CtUnitdefinitionData.Unit, Unit);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtUnitdefinitionData.Description);
	}

	public CtUnitdefinitionData setDescription(String Description) {
		this.repository().set(CtUnitdefinitionData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtUnitdefinitionData.Creator);
	}

	public CtUnitdefinitionData setCreator(String Creator) {
		this.repository().set(CtUnitdefinitionData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtUnitdefinitionData.Createdtime);
	}

	public CtUnitdefinitionData setCreatedtime(Date Createdtime) {
		this.repository().set(CtUnitdefinitionData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtUnitdefinitionData.Modifier);
	}

	public CtUnitdefinitionData setModifier(String Modifier) {
		this.repository().set(CtUnitdefinitionData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtUnitdefinitionData.Modifiedtime);
	}

	public CtUnitdefinitionData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtUnitdefinitionData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtUnitdefinitionData.Lasttxnhistkey);
	}

	public CtUnitdefinitionData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtUnitdefinitionData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtUnitdefinitionData.Lasttxnid);
	}

	public CtUnitdefinitionData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtUnitdefinitionData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtUnitdefinitionData.Lasttxnuser);
	}

	public CtUnitdefinitionData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtUnitdefinitionData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtUnitdefinitionData.Lasttxntime);
	}

	public CtUnitdefinitionData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtUnitdefinitionData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtUnitdefinitionData.Lasttxncomment);
	}

	public CtUnitdefinitionData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtUnitdefinitionData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtUnitdefinitionData.Validstate);
	}

	public CtUnitdefinitionData setValidstate(String Validstate) {
		this.repository().set(CtUnitdefinitionData.Validstate, Validstate);
		return this;
	}

	public String getErp_unitid() {
		return this.repository().getString(CtUnitdefinitionData.Erp_unitid);
	}

	public CtUnitdefinitionData setErp_unitid(String Erp_unitid) {
		this.repository().set(CtUnitdefinitionData.Erp_unitid, Erp_unitid);
		return this;
	}


}