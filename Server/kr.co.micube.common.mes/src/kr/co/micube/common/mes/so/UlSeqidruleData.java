package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlSeqidruleData extends SQLData {

	public static final String Modifier = "MODIFIER";

	public static final String Description = "DESCRIPTION";

	public static final String Lastseqid = "LASTSEQID";

	public static final String Seqcount = "SEQCOUNT";

	public static final String Seqid = "SEQID";

	public static final String Seqnameeng = "SEQNAMEENG";

	public static final String Seqnamejpn = "SEQNAMEJPN";

	public static final String Seqnamekor = "SEQNAMEKOR";

	public static final String Seqrule = "SEQRULE";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Creator = "CREATOR";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public UlSeqidruleData() {
		this(new UlSeqidruleKey()); 
	}

	public UlSeqidruleData(UlSeqidruleKey key) {
		super(key, "UlSeqidrule");
	}


	public String getModifier() {
		return this.repository().getString(UlSeqidruleData.Modifier);
	}

	public UlSeqidruleData setModifier(String Modifier) {
		this.repository().set(UlSeqidruleData.Modifier, Modifier);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(UlSeqidruleData.Description);
	}

	public UlSeqidruleData setDescription(String Description) {
		this.repository().set(UlSeqidruleData.Description, Description);
		return this;
	}

	public String getLastseqid() {
		return this.repository().getString(UlSeqidruleData.Lastseqid);
	}

	public UlSeqidruleData setLastseqid(String Lastseqid) {
		this.repository().set(UlSeqidruleData.Lastseqid, Lastseqid);
		return this;
	}

	public Integer getSeqcount() {
		return this.repository().getInteger(UlSeqidruleData.Seqcount);
	}

	public UlSeqidruleData setSeqcount(Integer Seqcount) {
		this.repository().set(UlSeqidruleData.Seqcount, Seqcount);
		return this;
	}

	public String getSeqnameeng() {
		return this.repository().getString(UlSeqidruleData.Seqnameeng);
	}

	public UlSeqidruleData setSeqnameeng(String Seqnameeng) {
		this.repository().set(UlSeqidruleData.Seqnameeng, Seqnameeng);
		return this;
	}

	public String getSeqnamejpn() {
		return this.repository().getString(UlSeqidruleData.Seqnamejpn);
	}

	public UlSeqidruleData setSeqnamejpn(String Seqnamejpn) {
		this.repository().set(UlSeqidruleData.Seqnamejpn, Seqnamejpn);
		return this;
	}

	public String getSeqnamekor() {
		return this.repository().getString(UlSeqidruleData.Seqnamekor);
	}

	public UlSeqidruleData setSeqnamekor(String Seqnamekor) {
		this.repository().set(UlSeqidruleData.Seqnamekor, Seqnamekor);
		return this;
	}

	public String getSeqrule() {
		return this.repository().getString(UlSeqidruleData.Seqrule);
	}

	public UlSeqidruleData setSeqrule(String Seqrule) {
		this.repository().set(UlSeqidruleData.Seqrule, Seqrule);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(UlSeqidruleData.Createdtime);
	}

	public UlSeqidruleData setCreatedtime(Date Createdtime) {
		this.repository().set(UlSeqidruleData.Createdtime, Createdtime);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(UlSeqidruleData.Creator);
	}

	public UlSeqidruleData setCreator(String Creator) {
		this.repository().set(UlSeqidruleData.Creator, Creator);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(UlSeqidruleData.Modifiedtime);
	}

	public UlSeqidruleData setModifiedtime(Date Modifiedtime) {
		this.repository().set(UlSeqidruleData.Modifiedtime, Modifiedtime);
		return this;
	}


}