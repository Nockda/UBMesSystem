package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlWorkmanualmasterData extends SQLData {

	public static final String Modifier = "MODIFIER";

	public static final String Processid = "PROCESSID";

	public static final String Workmanualid = "WORKMANUALID";

	public static final String Workmanualname = "WORKMANUALNAME";

	public static final String Workgroupid = "WORKGROUPID";

	public static final String Description = "DESCRIPTION";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Areaid = "AREAID";

	public UlWorkmanualmasterData() {
		this(new UlWorkmanualmasterKey()); 
	}

	public UlWorkmanualmasterData(UlWorkmanualmasterKey key) {
		super(key, "UlWorkmanualmaster");
	}


	public String getModifier() {
		return this.repository().getString(UlWorkmanualmasterData.Modifier);
	}

	public UlWorkmanualmasterData setModifier(String Modifier) {
		this.repository().set(UlWorkmanualmasterData.Modifier, Modifier);
		return this;
	}

	public String getProcessid() {
		return this.repository().getString(UlWorkmanualmasterData.Processid);
	}

	public UlWorkmanualmasterData setProcessid(String Processid) {
		this.repository().set(UlWorkmanualmasterData.Processid, Processid);
		return this;
	}

	public String getWorkmanualname() {
		return this.repository().getString(UlWorkmanualmasterData.Workmanualname);
	}

	public UlWorkmanualmasterData setWorkmanualname(String Workmanualname) {
		this.repository().set(UlWorkmanualmasterData.Workmanualname, Workmanualname);
		return this;
	}

	public String getWorkgroupid() {
		return this.repository().getString(UlWorkmanualmasterData.Workgroupid);
	}

	public UlWorkmanualmasterData setWorkgroupid(String Workgroupid) {
		this.repository().set(UlWorkmanualmasterData.Workgroupid, Workgroupid);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlWorkmanualmasterData.Description);
	}

	public UlWorkmanualmasterData setDescription(String Description) {
		this.repository().set(UlWorkmanualmasterData.Description, Description);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlWorkmanualmasterData.Modifiedtime);
	}

	public UlWorkmanualmasterData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlWorkmanualmasterData.Modifiedtime, Modifiedtime);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlWorkmanualmasterData.Createdtime);
	}

	public UlWorkmanualmasterData setCreatedtime(Date Createdtime) {
		this.repository().set(UlWorkmanualmasterData.Createdtime, Createdtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlWorkmanualmasterData.Creator);
	}

	public UlWorkmanualmasterData setCreator(String Creator) {
		this.repository().set(UlWorkmanualmasterData.Creator, Creator);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(UlWorkmanualmasterData.Areaid);
	}

	public UlWorkmanualmasterData setAreaid(String Areaid) {
		this.repository().set(UlWorkmanualmasterData.Areaid, Areaid);
		return this;
	}


}