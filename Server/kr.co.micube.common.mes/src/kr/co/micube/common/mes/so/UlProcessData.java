package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlProcessData extends SQLData {

	public static final String Workgroupid = "WORKGROUPID";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Lotunit = "LOTUNIT";

	public static final String Description = "DESCRIPTION";

	public static final String Validstate = "VALIDSTATE";

	public static final String Ordertype = "ORDERTYPE";

	public static final String Processnameeng = "PROCESSNAMEENG";

	public static final String Processnamejpn = "PROCESSNAMEJPN";

	public static final String Processnamekor = "PROCESSNAMEKOR";

	public static final String Processid = "PROCESSID";

	public static final String Modifier = "MODIFIER";

	public UlProcessData() {
		this(new UlProcessKey()); 
	}

	public UlProcessData(UlProcessKey key) {
		super(key, "UlProcess");
	}


	public String getWorkgroupid() {
		return this.repository().getString(UlProcessData.Workgroupid);
	}

	public UlProcessData setWorkgroupid(String Workgroupid) {
		this.repository().set(UlProcessData.Workgroupid, Workgroupid);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlProcessData.Modifiedtime);
	}

	public UlProcessData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlProcessData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlProcessData.Creator);
	}

	public UlProcessData setCreator(String Creator) {
		this.repository().set(UlProcessData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlProcessData.Createdtime);
	}

	public UlProcessData setCreatedtime(Date Createdtime) {
		this.repository().set(UlProcessData.Createdtime, Createdtime);
		return this;
	}

	public String getLotunit() {
		return this.repository().getString(UlProcessData.Lotunit);
	}

	public UlProcessData setLotunit(String Lotunit) {
		this.repository().set(UlProcessData.Lotunit, Lotunit);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlProcessData.Description);
	}

	public UlProcessData setDescription(String Description) {
		this.repository().set(UlProcessData.Description, Description);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlProcessData.Validstate);
	}

	public UlProcessData setValidstate(String Validstate) {
		this.repository().set(UlProcessData.Validstate, Validstate);
		return this;
	}

	public String getOrdertype() {
		return this.repository().getString(UlProcessData.Ordertype);
	}

	public UlProcessData setOrdertype(String Ordertype) {
		this.repository().set(UlProcessData.Ordertype, Ordertype);
		return this;
	}

	public String getProcessnameeng() {
		return this.repository().getString(UlProcessData.Processnameeng);
	}

	public UlProcessData setProcessnameeng(String Processnameeng) {
		this.repository().set(UlProcessData.Processnameeng, Processnameeng);
		return this;
	}

	public String getProcessnamejpn() {
		return this.repository().getString(UlProcessData.Processnamejpn);
	}

	public UlProcessData setProcessnamejpn(String Processnamejpn) {
		this.repository().set(UlProcessData.Processnamejpn, Processnamejpn);
		return this;
	}

	public String getProcessnamekor() {
		return this.repository().getString(UlProcessData.Processnamekor);
	}

	public UlProcessData setProcessnamekor(String Processnamekor) {
		this.repository().set(UlProcessData.Processnamekor, Processnamekor);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlProcessData.Modifier);
	}

	public UlProcessData setModifier(String Modifier) {
		this.repository().set(UlProcessData.Modifier, Modifier);
		return this;
	}


}