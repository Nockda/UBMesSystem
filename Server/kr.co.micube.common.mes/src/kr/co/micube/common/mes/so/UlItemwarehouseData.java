package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class UlItemwarehouseData extends SQLData {

	public static final String Updatedt = "UPDATEDT";

	public static final String Createdt = "CREATEDT";

	public static final String Itemid = "ITEMID";

	public static final String Codeid = "CODEID";

	public static final String Typecnt = "TYPECNT";

	public UlItemwarehouseData() {
		this(new UlItemwarehouseKey()); 
	}

	public UlItemwarehouseData(UlItemwarehouseKey key) {
		super(key, "UlItemwarehouse");
	}


	public Date getUpdatedt() {
		return this.repository().getDate(UlItemwarehouseData.Updatedt);
	}

	public UlItemwarehouseData setUpdatedt(Date Updatedt) {
		this.repository().set(UlItemwarehouseData.Updatedt, Updatedt);
		return this;
	}

	public Date getCreatedt() {
		return this.repository().getDate(UlItemwarehouseData.Createdt);
	}

	public UlItemwarehouseData setCreatedt(Date Createdt) {
		this.repository().set(UlItemwarehouseData.Createdt, Createdt);
		return this;
	}

	public Integer getTypecnt() {
		return this.repository().getInteger(UlItemwarehouseData.Typecnt);
	}

	public UlItemwarehouseData setTypecnt(Integer Typecnt) {
		this.repository().set(UlItemwarehouseData.Typecnt, Typecnt);
		return this;
	}


}