package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlQmfileData extends SQLData {

	public static final String Modifier = "MODIFIER";

	public static final String Filename = "FILENAME";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Confnumber = "CONFNUMBER";

	public static final String Filedata = "FILEDATA";

	public static final String Description = "DESCRIPTION";

	public static final String Seqnumber = "SEQNUMBER";

	public static final String Docid = "DOCID";

	public UlQmfileData() {
		this(new UlQmfileKey()); 
	}

	public UlQmfileData(UlQmfileKey key) {
		super(key, "UlQmfile");
	}


	public String getModifier() {
		return this.repository().getString(UlQmfileData.Modifier);
	}

	public UlQmfileData setModifier(String Modifier) {
		this.repository().set(UlQmfileData.Modifier, Modifier);
		return this;
	}

	public String getFilename() {
		return this.repository().getString(UlQmfileData.Filename);
	}

	public UlQmfileData setFilename(String Filename) {
		this.repository().set(UlQmfileData.Filename, Filename);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlQmfileData.Modifiedtime);
	}

	public UlQmfileData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlQmfileData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlQmfileData.Creator);
	}

	public UlQmfileData setCreator(String Creator) {
		this.repository().set(UlQmfileData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlQmfileData.Createdtime);
	}

	public UlQmfileData setCreatedtime(Date Createdtime) {
		this.repository().set(UlQmfileData.Createdtime, Createdtime);
		return this;
	}

	public String getConfnumber() {
		return this.repository().getString(UlQmfileData.Confnumber);
	}

	public UlQmfileData setConfnumber(String Confnumber) {
		this.repository().set(UlQmfileData.Confnumber, Confnumber);
		return this;
	}

	public byte[] getFiledata() throws DatabaseException {
		return this.repository().getBlob(UlQmfileData.Filedata);
	}

	public UlQmfileData setFiledata(byte[] Filedata) {
		this.repository().set(UlQmfileData.Filedata, Filedata);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlQmfileData.Description);
	}

	public UlQmfileData setDescription(String Description) {
		this.repository().set(UlQmfileData.Description, Description);
		return this;
	}


}