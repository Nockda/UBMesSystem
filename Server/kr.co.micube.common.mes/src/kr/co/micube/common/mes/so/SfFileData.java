package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfFileData extends SQLData {

	public static final String Manualno = "MANUALNO";

	public static final String Manualversion = "MANUALVERSION";

	public static final String Filename = "FILENAME";

	public static final String Filepath = "FILEPATH";

	public static final String Filesize = "FILESIZE";

	public static final String Fileext = "FILEEXT";

	public static final String Filetype = "FILETYPE";

	public static final String Filedata = "FILEDATA";

	public static final String Description = "DESCRIPTION";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Modifier = "MODIFIER";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Validstate = "VALIDSTATE";

	public SfFileData() {
		this(new SfFileKey()); 
	}

	public SfFileData(SfFileKey key) {
		super(key, "SfFile");
	}


	public String getFilename() {
		return this.repository().getString(SfFileData.Filename);
	}

	public SfFileData setFilename(String Filename) {
		this.repository().set(SfFileData.Filename, Filename);
		return this;
	}

	public String getFilepath() {
		return this.repository().getString(SfFileData.Filepath);
	}

	public SfFileData setFilepath(String Filepath) {
		this.repository().set(SfFileData.Filepath, Filepath);
		return this;
	}

	public Double getFilesize() {
		return this.repository().getDouble(SfFileData.Filesize);
	}

	public SfFileData setFilesize(Double Filesize) {
		this.repository().set(SfFileData.Filesize, Filesize);
		return this;
	}

	public String getFileext() {
		return this.repository().getString(SfFileData.Fileext);
	}

	public SfFileData setFileext(String Fileext) {
		this.repository().set(SfFileData.Fileext, Fileext);
		return this;
	}

	public String getFiletype() {
		return this.repository().getString(SfFileData.Filetype);
	}

	public SfFileData setFiletype(String Filetype) {
		this.repository().set(SfFileData.Filetype, Filetype);
		return this;
	}

	public byte[] getFiledata() throws DatabaseException {
		return this.repository().getBlob(SfFileData.Filedata);
	}

	public SfFileData setFiledata(byte[] Filedata) {
		this.repository().set(SfFileData.Filedata, Filedata);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfFileData.Description);
	}

	public SfFileData setDescription(String Description) {
		this.repository().set(SfFileData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfFileData.Creator);
	}

	public SfFileData setCreator(String Creator) {
		this.repository().set(SfFileData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfFileData.Createdtime);
	}

	public SfFileData setCreatedtime(Date Createdtime) {
		this.repository().set(SfFileData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfFileData.Modifier);
	}

	public SfFileData setModifier(String Modifier) {
		this.repository().set(SfFileData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfFileData.Modifiedtime);
	}

	public SfFileData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfFileData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfFileData.Validstate);
	}

	public SfFileData setValidstate(String Validstate) {
		this.repository().set(SfFileData.Validstate, Validstate);
		return this;
	}


}