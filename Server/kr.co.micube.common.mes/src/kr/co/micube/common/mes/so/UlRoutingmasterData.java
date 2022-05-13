package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlRoutingmasterData extends SQLData {

	public static final String Routingid = "ROUTINGID";

	public static final String Routingnameeng = "ROUTINGNAMEENG";

	public static final String Routingnamejpn = "ROUTINGNAMEJPN";

	public static final String Routingnamekor = "ROUTINGNAMEKOR";

	public static final String Lotunit = "LOTUNIT";

	public static final String Description = "DESCRIPTION";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Workgroupid = "WORKGROUPID";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Validstate = "VALIDSTATE";

	public static final String Modelid = "MODELID";

	public static final String Itemassetcategory = "ITEMASSETCATEGORY";

	public static final String Modifier = "MODIFIER";

	public static final String Processid = "PROCESSID";
	
	public static final String Ordertype = "ORDERTYPE";

	public UlRoutingmasterData() {
		this(new UlRoutingmasterKey()); 
	}

	public UlRoutingmasterData(UlRoutingmasterKey key) {
		super(key, "UlRoutingmaster");
	}


	public String getRoutingnameeng() {
		return this.repository().getString(UlRoutingmasterData.Routingnameeng);
	}

	public UlRoutingmasterData setRoutingnameeng(String Routingnameeng) {
		this.repository().set(UlRoutingmasterData.Routingnameeng, Routingnameeng);
		return this;
	}

	public String getRoutingnamejpn() {
		return this.repository().getString(UlRoutingmasterData.Routingnamejpn);
	}

	public UlRoutingmasterData setRoutingnamejpn(String Routingnamejpn) {
		this.repository().set(UlRoutingmasterData.Routingnamejpn, Routingnamejpn);
		return this;
	}

	public String getRoutingnamekor() {
		return this.repository().getString(UlRoutingmasterData.Routingnamekor);
	}

	public UlRoutingmasterData setRoutingnamekor(String Routingnamekor) {
		this.repository().set(UlRoutingmasterData.Routingnamekor, Routingnamekor);
		return this;
	}

	public String getLotunit() {
		return this.repository().getString(UlRoutingmasterData.Lotunit);
	}

	public UlRoutingmasterData setLotunit(String Lotunit) {
		this.repository().set(UlRoutingmasterData.Lotunit, Lotunit);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlRoutingmasterData.Description);
	}

	public UlRoutingmasterData setDescription(String Description) {
		this.repository().set(UlRoutingmasterData.Description, Description);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlRoutingmasterData.Modifiedtime);
	}

	public UlRoutingmasterData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlRoutingmasterData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlRoutingmasterData.Creator);
	}

	public UlRoutingmasterData setCreator(String Creator) {
		this.repository().set(UlRoutingmasterData.Creator, Creator);
		return this;
	}

	public String getWorkgroupid() {
		return this.repository().getString(UlRoutingmasterData.Workgroupid);
	}

	public UlRoutingmasterData setWorkgroupid(String Workgroupid) {
		this.repository().set(UlRoutingmasterData.Workgroupid, Workgroupid);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlRoutingmasterData.Createdtime);
	}

	public UlRoutingmasterData setCreatedtime(Date Createdtime) {
		this.repository().set(UlRoutingmasterData.Createdtime, Createdtime);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlRoutingmasterData.Validstate);
	}

	public UlRoutingmasterData setValidstate(String Validstate) {
		this.repository().set(UlRoutingmasterData.Validstate, Validstate);
		return this;
	}

	public String getModelid() {
		return this.repository().getString(UlRoutingmasterData.Modelid);
	}

	public UlRoutingmasterData setModelid(String Modelid) {
		this.repository().set(UlRoutingmasterData.Modelid, Modelid);
		return this;
	}

	public String getItemassetcategory() {
		return this.repository().getString(UlRoutingmasterData.Itemassetcategory);
	}

	public UlRoutingmasterData setItemassetcategory(String Itemassetcategory) {
		this.repository().set(UlRoutingmasterData.Itemassetcategory, Itemassetcategory);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlRoutingmasterData.Modifier);
	}

	public UlRoutingmasterData setModifier(String Modifier) {
		this.repository().set(UlRoutingmasterData.Modifier, Modifier);
		return this;
	}

	public String getProcessid() {
		return this.repository().getString(UlRoutingmasterData.Processid);
	}

	public UlRoutingmasterData setProcessid(String Processid) {
		this.repository().set(UlRoutingmasterData.Processid, Processid);
		return this;
	}

	public String getOrdertype() {
		return this.repository().getString(UlRoutingmasterData.Ordertype);
	}

	public UlRoutingmasterData setOrdertype(String Ordertype) {
		this.repository().set(UlRoutingmasterData.Ordertype, Ordertype);
		return this;
	}

}