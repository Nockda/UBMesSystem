package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlWorkmanualdetailData extends SQLData {

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Filedata = "FILEDATA";

	public static final String Description = "DESCRIPTION";

	public static final String Filename = "FILENAME";

	public static final String Workmanualid = "WORKMANUALID";

	public static final String Revisionid = "REVISIONID";

	public static final String Revisionname = "REVISIONNAME";

	public static final String Modifier = "MODIFIER";

	public UlWorkmanualdetailData() {
		this(new UlWorkmanualdetailKey()); 
	}

	public UlWorkmanualdetailData(UlWorkmanualdetailKey key) {
		super(key, "UlWorkmanualdetail");
	}


	public String getCreator() {
		return this.repository().getString(UlWorkmanualdetailData.Creator);
	}

	public UlWorkmanualdetailData setCreator(String Creator) {
		this.repository().set(UlWorkmanualdetailData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlWorkmanualdetailData.Createdtime);
	}

	public UlWorkmanualdetailData setCreatedtime(Date Createdtime) {
		this.repository().set(UlWorkmanualdetailData.Createdtime, Createdtime);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlWorkmanualdetailData.Modifiedtime);
	}

	public UlWorkmanualdetailData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlWorkmanualdetailData.Modifiedtime, Modifiedtime);
		return this;
	}

	public byte[] getFiledata() throws DatabaseException {
		return this.repository().getBlob(UlWorkmanualdetailData.Filedata);
	}

	public UlWorkmanualdetailData setFiledata(byte[] Filedata) {
		this.repository().set(UlWorkmanualdetailData.Filedata, Filedata);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlWorkmanualdetailData.Description);
	}

	public UlWorkmanualdetailData setDescription(String Description) {
		this.repository().set(UlWorkmanualdetailData.Description, Description);
		return this;
	}

	public String getFilename() {
		return this.repository().getString(UlWorkmanualdetailData.Filename);
	}

	public UlWorkmanualdetailData setFilename(String Filename) {
		this.repository().set(UlWorkmanualdetailData.Filename, Filename);
		return this;
	}

	public String getRevisionname() {
		return this.repository().getString(UlWorkmanualdetailData.Revisionname);
	}

	public UlWorkmanualdetailData setRevisionname(String Revisionname) {
		this.repository().set(UlWorkmanualdetailData.Revisionname, Revisionname);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(UlWorkmanualdetailData.Modifier);
	}

	public UlWorkmanualdetailData setModifier(String Modifier) {
		this.repository().set(UlWorkmanualdetailData.Modifier, Modifier);
		return this;
	}


}