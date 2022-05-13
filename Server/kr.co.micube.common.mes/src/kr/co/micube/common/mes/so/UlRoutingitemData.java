package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlRoutingitemData extends SQLData {

	public static final String Modifier = "MODIFIER";

	public static final String Itemid = "ITEMID";

	public static final String Validstate = "VALIDSTATE";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Routingid = "ROUTINGID";
	
	public static final String Resultstate= "RESULTSTATE";
	
	public static final String Outsourcestate= "OUTSOURCESTATE";
	
	public static final String Processdstate= "PROCESSDSTATE";
	
	public static final String Standworktime= "STANDWORKTIME";

	public UlRoutingitemData() {
		this(new UlRoutingitemKey()); 
	}

	public UlRoutingitemData(UlRoutingitemKey key) {
		super(key, "UlRoutingitem");
	}


	public String getModifier() {
		return this.repository().getString(UlRoutingitemData.Modifier);
	}

	public UlRoutingitemData setModifier(String Modifier) {
		this.repository().set(UlRoutingitemData.Modifier, Modifier);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlRoutingitemData.Validstate);
	}

	public UlRoutingitemData setValidstate(String Validstate) {
		this.repository().set(UlRoutingitemData.Validstate, Validstate);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlRoutingitemData.Createdtime);
	}

	public UlRoutingitemData setCreatedtime(Date Createdtime) {
		this.repository().set(UlRoutingitemData.Createdtime, Createdtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlRoutingitemData.Creator);
	}

	public UlRoutingitemData setCreator(String Creator) {
		this.repository().set(UlRoutingitemData.Creator, Creator);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlRoutingitemData.Modifiedtime);
	}

	public UlRoutingitemData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlRoutingitemData.Modifiedtime, Modifiedtime);
		return this;
	}
	
	public String getResultstate() {
		return this.repository().getString(UlRoutingitemData.Resultstate);
	}

	public UlRoutingitemData setResultstate(String Resultstate) {
		this.repository().set(UlRoutingitemData.Resultstate, Resultstate);
		return this;
	}
	
	public String getOutsourcestate() {
		return this.repository().getString(UlRoutingitemData.Outsourcestate);
	}

	public UlRoutingitemData setOutsourcestate(String Outsourcestate) {
		this.repository().set(UlRoutingitemData.Outsourcestate, Outsourcestate);
		return this;
	}
	
	public String getProcessdstate() {
		return this.repository().getString(UlRoutingitemData.Processdstate);
	}

	public UlRoutingitemData setProcessdstate(String Processdstate) {
		this.repository().set(UlRoutingitemData.Processdstate, Processdstate);
		return this;
	}
	
	public Double getStandworktime() {
		return this.repository().getDouble(UlRoutingitemData.Standworktime);
	}

	public UlRoutingitemData setStandworktime(Double Standworktime) {
		this.repository().set(UlRoutingitemData.Standworktime, Standworktime);
		return this;
	}


}