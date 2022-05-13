package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfConnectionHistoryData extends SQLData {

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Userid = "USERID";

	public static final String Connectiontype = "CONNECTIONTYPE";

	public static final String Uiid = "UIID";

	public static final String Menuid = "MENUID";

	public static final String Ipaddress = "IPADDRESS";

	public static final String Connectiontime = "CONNECTIONTIME";

	public static final String Disconnectiontime = "DISCONNECTIONTIME";

	public SfConnectionHistoryData() {
		this(new SfConnectionHistoryKey()); 
	}

	public SfConnectionHistoryData(SfConnectionHistoryKey key) {
		super(key, "SfConnectionHistory");
	}


	public String getUserid() {
		return this.repository().getString(SfConnectionHistoryData.Userid);
	}

	public SfConnectionHistoryData setUserid(String Userid) {
		this.repository().set(SfConnectionHistoryData.Userid, Userid);
		return this;
	}

	public String getConnectiontype() {
		return this.repository().getString(SfConnectionHistoryData.Connectiontype);
	}

	public SfConnectionHistoryData setConnectiontype(String Connectiontype) {
		this.repository().set(SfConnectionHistoryData.Connectiontype, Connectiontype);
		return this;
	}

	public String getUiid() {
		return this.repository().getString(SfConnectionHistoryData.Uiid);
	}

	public SfConnectionHistoryData setUiid(String Uiid) {
		this.repository().set(SfConnectionHistoryData.Uiid, Uiid);
		return this;
	}

	public String getMenuid() {
		return this.repository().getString(SfConnectionHistoryData.Menuid);
	}

	public SfConnectionHistoryData setMenuid(String Menuid) {
		this.repository().set(SfConnectionHistoryData.Menuid, Menuid);
		return this;
	}

	public String getIpaddress() {
		return this.repository().getString(SfConnectionHistoryData.Ipaddress);
	}

	public SfConnectionHistoryData setIpaddress(String Ipaddress) {
		this.repository().set(SfConnectionHistoryData.Ipaddress, Ipaddress);
		return this;
	}

	public Date getConnectiontime() {
		return this.repository().getDate(SfConnectionHistoryData.Connectiontime);
	}

	public SfConnectionHistoryData setConnectiontime(Date Connectiontime) {
		this.repository().set(SfConnectionHistoryData.Connectiontime, Connectiontime);
		return this;
	}

	public Date getDisconnectiontime() {
		return this.repository().getDate(SfConnectionHistoryData.Disconnectiontime);
	}

	public SfConnectionHistoryData setDisconnectiontime(Date Disconnectiontime) {
		this.repository().set(SfConnectionHistoryData.Disconnectiontime, Disconnectiontime);
		return this;
	}


}