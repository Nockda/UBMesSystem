package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlEquipmentData extends SQLData {

	public static final String Equipnameeng = "EQUIPNAMEENG";

	public static final String Equipnamejpn = "EQUIPNAMEJPN";

	public static final String Equipnamekor = "EQUIPNAMEKOR";

	public static final String Equiptype = "EQUIPTYPE";

	public static final String Deptcode = "DEPTCODE";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Validstate = "VALIDSTATE";
	
	public static final String Ifstate = "IFSTATE";

	public static final String Bigo = "BIGO";

	public static final String Equipcode = "EQUIPCODE";

	public static final String Equipcodeparent = "EQUIPCODEPARENT";

	public static final String Equipgroup = "EQUIPGROUP";

	public static final String Assetno = "ASSETNO";

	public static final String Areacode = "AREACODE";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Modifier = "MODIFIER";

	public static final String Processcode = "PROCESSCODE";
	
	public UlEquipmentData() {
		this(new UlEquipmentKey()); 
	}

	public UlEquipmentData(UlEquipmentKey key) {
		super(key, "UlEquipment");
	}


	public String getEquipnameeng() {
		return this.repository().getString(UlEquipmentData.Equipnameeng);
	}

	public UlEquipmentData setEquipnameeng(String Equipnameeng) {
		this.repository().set(UlEquipmentData.Equipnameeng, Equipnameeng);
		return this;
	}

	public String getEquipnamejpn() {
		return this.repository().getString(UlEquipmentData.Equipnamejpn);
	}

	public UlEquipmentData setEquipnamejpn(String Equipnamejpn) {
		this.repository().set(UlEquipmentData.Equipnamejpn, Equipnamejpn);
		return this;
	}

	public String getEquipnamekor() {
		return this.repository().getString(UlEquipmentData.Equipnamekor);
	}

	public UlEquipmentData setEquipnamekor(String Equipnamekor) {
		this.repository().set(UlEquipmentData.Equipnamekor, Equipnamekor);
		return this;
	}

	public String getEquiptype() {
		return this.repository().getString(UlEquipmentData.Equiptype);
	}

	public UlEquipmentData setEquiptype(String Equiptype) {
		this.repository().set(UlEquipmentData.Equiptype, Equiptype);
		return this;
	}

	public String getDeptcode() {
		return this.repository().getString(UlEquipmentData.Deptcode);
	}

	public UlEquipmentData setDeptcode(String Deptcode) {
		this.repository().set(UlEquipmentData.Deptcode, Deptcode);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlEquipmentData.Modifiedtime);
	}

	public UlEquipmentData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlEquipmentData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getIfstate() {
		return this.repository().getString(UlEquipmentData.Ifstate);
	}

	public UlEquipmentData setIfstate(String Ifstate) {
		this.repository().set(UlEquipmentData.Ifstate, Ifstate);
		return this;
	}
	
	public String getValidstate() {
		return this.repository().getString(UlEquipmentData.Validstate);
	}

	public UlEquipmentData setValidstate(String Validstate) {
		this.repository().set(UlEquipmentData.Validstate, Validstate);
		return this;
	}

	public String getBigo() {
		return this.repository().getString(UlEquipmentData.Bigo);
	}

	public UlEquipmentData setBigo(String Bigo) {
		this.repository().set(UlEquipmentData.Bigo, Bigo);
		return this;
	}

	public String getEquipcodeparent() {
		return this.repository().getString(UlEquipmentData.Equipcodeparent);
	}

	public UlEquipmentData setEquipcodeparent(String Equipcodeparent) {
		this.repository().set(UlEquipmentData.Equipcodeparent, Equipcodeparent);
		return this;
	}

	public String getEquipgroup() {
		return this.repository().getString(UlEquipmentData.Equipgroup);
	}

	public UlEquipmentData setEquipgroup(String Equipgroup) {
		this.repository().set(UlEquipmentData.Equipgroup, Equipgroup);
		return this;
	}

	public String getAssetno() {
		return this.repository().getString(UlEquipmentData.Assetno);
	}

	public UlEquipmentData setAssetno(String Assetno) {
		this.repository().set(UlEquipmentData.Assetno, Assetno);
		return this;
	}

	public String getAreacode() {
		return this.repository().getString(UlEquipmentData.Areacode);
	}

	public UlEquipmentData setAreacode(String Areacode) {
		this.repository().set(UlEquipmentData.Areacode, Areacode);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlEquipmentData.Createdtime);
	}

	public UlEquipmentData setCreatedtime(Date Createdtime) {
		this.repository().set(UlEquipmentData.Createdtime, Createdtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlEquipmentData.Creator);
	}

	public UlEquipmentData setCreator(String Creator) {
		this.repository().set(UlEquipmentData.Creator, Creator);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlEquipmentData.Modifier);
	}

	public UlEquipmentData setModifier(String Modifier) {
		this.repository().set(UlEquipmentData.Modifier, Modifier);
		return this;
	}

	public String getProcesscode() {
		return this.repository().getString(UlEquipmentData.Processcode);
	}

	public UlEquipmentData setProcesscode(String Processcode) {
		this.repository().set(UlEquipmentData.Processcode, Processcode);
		return this;
	}


}