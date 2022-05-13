package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlIqcinsplistData extends SQLData {

	public static final String Modifier = "MODIFIER";

	public static final String Itemname = "ITEMNAME";

	public static final String Itemid = "ITEMID";

	public static final String Filename = "FILENAME";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Filedata = "FILEDATA";

	public static final String Description = "DESCRIPTION";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public UlIqcinsplistData() {
		this(new UlIqcinsplistKey()); 
	}

	public UlIqcinsplistData(UlIqcinsplistKey key) {
		super(key, "UlIqcinsplist");
	}


	public String getModifier() {
		return this.repository().getString(UlIqcinsplistData.Modifier);
	}

	public UlIqcinsplistData setModifier(String Modifier) {
		this.repository().set(UlIqcinsplistData.Modifier, Modifier);
		return this;
	}

	public String getItemname() {
		return this.repository().getString(UlIqcinsplistData.Itemname);
	}

	public UlIqcinsplistData setItemname(String Itemname) {
		this.repository().set(UlIqcinsplistData.Itemname, Itemname);
		return this;
	}

	public String getFilename() {
		return this.repository().getString(UlIqcinsplistData.Filename);
	}

	public UlIqcinsplistData setFilename(String Filename) {
		this.repository().set(UlIqcinsplistData.Filename, Filename);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlIqcinsplistData.Createdtime);
	}

	public UlIqcinsplistData setCreatedtime(Date Createdtime) {
		this.repository().set(UlIqcinsplistData.Createdtime, Createdtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlIqcinsplistData.Creator);
	}

	public UlIqcinsplistData setCreator(String Creator) {
		this.repository().set(UlIqcinsplistData.Creator, Creator);
		return this;
	}

	public byte[] getFiledata() throws DatabaseException {
		return this.repository().getBlob(UlIqcinsplistData.Filedata);
	}

	public UlIqcinsplistData setFiledata(byte[] Filedata) {
		this.repository().set(UlIqcinsplistData.Filedata, Filedata);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlIqcinsplistData.Description);
	}

	public UlIqcinsplistData setDescription(String Description) {
		this.repository().set(UlIqcinsplistData.Description, Description);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlIqcinsplistData.Modifiedtime);
	}

	public UlIqcinsplistData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlIqcinsplistData.Modifiedtime, Modifiedtime);
		return this;
	}


}