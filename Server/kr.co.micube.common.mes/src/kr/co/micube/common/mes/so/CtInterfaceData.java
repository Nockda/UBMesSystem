package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtInterfaceData extends SQLData {

	public static final String Interfaceid = "INTERFACEID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Description = "DESCRIPTION";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Modifier = "MODIFIER";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public CtInterfaceData() {
		this(new CtInterfaceKey()); 
	}

	public CtInterfaceData(CtInterfaceKey key) {
		super(key, "CtInterface");
	}


	public String getDescription() {
		return this.repository().getString(CtInterfaceData.Description);
	}

	public CtInterfaceData setDescription(String Description) {
		this.repository().set(CtInterfaceData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtInterfaceData.Creator);
	}

	public CtInterfaceData setCreator(String Creator) {
		this.repository().set(CtInterfaceData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtInterfaceData.Createdtime);
	}

	public CtInterfaceData setCreatedtime(Date Createdtime) {
		this.repository().set(CtInterfaceData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtInterfaceData.Modifier);
	}

	public CtInterfaceData setModifier(String Modifier) {
		this.repository().set(CtInterfaceData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtInterfaceData.Modifiedtime);
	}

	public CtInterfaceData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtInterfaceData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtInterfaceData.Txnid);
	}

	public CtInterfaceData setTxnid(String Txnid) {
		this.repository().set(CtInterfaceData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtInterfaceData.Txnuser);
	}

	public CtInterfaceData setTxnuser(String Txnuser) {
		this.repository().set(CtInterfaceData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtInterfaceData.Txntime);
	}

	public CtInterfaceData setTxntime(Date Txntime) {
		this.repository().set(CtInterfaceData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtInterfaceData.Txngrouphistkey);
	}

	public CtInterfaceData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtInterfaceData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtInterfaceData.Txnreasoncodeclass);
	}

	public CtInterfaceData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtInterfaceData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtInterfaceData.Txnreasoncode);
	}

	public CtInterfaceData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtInterfaceData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtInterfaceData.Txncomment);
	}

	public CtInterfaceData setTxncomment(String Txncomment) {
		this.repository().set(CtInterfaceData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtInterfaceData.Validstate);
	}

	public CtInterfaceData setValidstate(String Validstate) {
		this.repository().set(CtInterfaceData.Validstate, Validstate);
		return this;
	}


}