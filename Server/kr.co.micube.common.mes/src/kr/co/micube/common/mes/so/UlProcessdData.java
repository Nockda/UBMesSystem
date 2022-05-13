package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlProcessdData extends SQLData {

	public static final String Processdid = "PROCESSDID";

	public static final String Processdnameeng = "PROCESSDNAMEENG";

	public static final String Processdnamejpn = "PROCESSDNAMEJPN";

	public static final String Processdnamekor = "PROCESSDNAMEKOR";

	public static final String Modifier = "MODIFIER";

	public static final String Validstate = "VALIDSTATE";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Description = "DESCRIPTION";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public UlProcessdData() {
		this(new UlProcessdKey()); 
	}

	public UlProcessdData(UlProcessdKey key) {
		super(key, "UlProcessd");
	}


	public String getProcessdnameeng() {
		return this.repository().getString(UlProcessdData.Processdnameeng);
	}

	public UlProcessdData setProcessdnameeng(String Processdnameeng) {
		this.repository().set(UlProcessdData.Processdnameeng, Processdnameeng);
		return this;
	}

	public String getProcessdnamejpn() {
		return this.repository().getString(UlProcessdData.Processdnamejpn);
	}

	public UlProcessdData setProcessdnamejpn(String Processdnamejpn) {
		this.repository().set(UlProcessdData.Processdnamejpn, Processdnamejpn);
		return this;
	}

	public String getProcessdnamekor() {
		return this.repository().getString(UlProcessdData.Processdnamekor);
	}

	public UlProcessdData setProcessdnamekor(String Processdnamekor) {
		this.repository().set(UlProcessdData.Processdnamekor, Processdnamekor);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlProcessdData.Modifier);
	}

	public UlProcessdData setModifier(String Modifier) {
		this.repository().set(UlProcessdData.Modifier, Modifier);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(UlProcessdData.Validstate);
	}

	public UlProcessdData setValidstate(String Validstate) {
		this.repository().set(UlProcessdData.Validstate, Validstate);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlProcessdData.Createdtime);
	}

	public UlProcessdData setCreatedtime(Date Createdtime) {
		this.repository().set(UlProcessdData.Createdtime, Createdtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlProcessdData.Creator);
	}

	public UlProcessdData setCreator(String Creator) {
		this.repository().set(UlProcessdData.Creator, Creator);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlProcessdData.Description);
	}

	public UlProcessdData setDescription(String Description) {
		this.repository().set(UlProcessdData.Description, Description);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlProcessdData.Modifiedtime);
	}

	public UlProcessdData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlProcessdData.Modifiedtime, Modifiedtime);
		return this;
	}


}