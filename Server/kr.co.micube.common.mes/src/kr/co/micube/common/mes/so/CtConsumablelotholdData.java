package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtConsumablelotholdData extends SQLData {

	public static final String Consumablelotid = "CONSUMABLELOTID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Warehouseid = "WAREHOUSEID";

	public static final String Consumablelotqty = "CONSUMABLELOTQTY";

	public static final String State = "STATE";

	public static final String Reasoncodeid = "REASONCODEID";

	public static final String Holduser = "HOLDUSER";

	public static final String Holdcomments = "HOLDCOMMENTS";

	public static final String Holddate = "HOLDDATE";

	public static final String Releasereasoncodeid = "RELEASEREASONCODEID";

	public static final String Releaseuser = "RELEASEUSER";

	public static final String Releasedate = "RELEASEDATE";

	public static final String Releasecomments = "RELEASECOMMENTS";

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

	public CtConsumablelotholdData() {
		this(new CtConsumablelotholdKey()); 
	}

	public CtConsumablelotholdData(CtConsumablelotholdKey key) {
		super(key, "CtConsumablelothold");
		this.txnInfo().setHistoryTable(true);
	}


	public String getWarehouseid() {
		return this.repository().getString(CtConsumablelotholdData.Warehouseid);
	}

	public CtConsumablelotholdData setWarehouseid(String Warehouseid) {
		this.repository().set(CtConsumablelotholdData.Warehouseid, Warehouseid);
		return this;
	}

	public Double getConsumablelotqty() {
		return this.repository().getDouble(CtConsumablelotholdData.Consumablelotqty);
	}

	public CtConsumablelotholdData setConsumablelotqty(Double Consumablelotqty) {
		this.repository().set(CtConsumablelotholdData.Consumablelotqty, Consumablelotqty);
		return this;
	}

	public String getState() {
		return this.repository().getString(CtConsumablelotholdData.State);
	}

	public CtConsumablelotholdData setState(String State) {
		this.repository().set(CtConsumablelotholdData.State, State);
		return this;
	}

	public String getReasoncodeid() {
		return this.repository().getString(CtConsumablelotholdData.Reasoncodeid);
	}

	public CtConsumablelotholdData setReasoncodeid(String Reasoncodeid) {
		this.repository().set(CtConsumablelotholdData.Reasoncodeid, Reasoncodeid);
		return this;
	}

	public String getHolduser() {
		return this.repository().getString(CtConsumablelotholdData.Holduser);
	}

	public CtConsumablelotholdData setHolduser(String Holduser) {
		this.repository().set(CtConsumablelotholdData.Holduser, Holduser);
		return this;
	}

	public String getHoldcomments() {
		return this.repository().getString(CtConsumablelotholdData.Holdcomments);
	}

	public CtConsumablelotholdData setHoldcomments(String Holdcomments) {
		this.repository().set(CtConsumablelotholdData.Holdcomments, Holdcomments);
		return this;
	}

	public Date getHolddate() {
		return this.repository().getDate(CtConsumablelotholdData.Holddate);
	}

	public CtConsumablelotholdData setHolddate(Date Holddate) {
		this.repository().set(CtConsumablelotholdData.Holddate, Holddate);
		return this;
	}

	public String getReleasereasoncodeid() {
		return this.repository().getString(CtConsumablelotholdData.Releasereasoncodeid);
	}

	public CtConsumablelotholdData setReleasereasoncodeid(String Releasereasoncodeid) {
		this.repository().set(CtConsumablelotholdData.Releasereasoncodeid, Releasereasoncodeid);
		return this;
	}

	public String getReleaseuser() {
		return this.repository().getString(CtConsumablelotholdData.Releaseuser);
	}

	public CtConsumablelotholdData setReleaseuser(String Releaseuser) {
		this.repository().set(CtConsumablelotholdData.Releaseuser, Releaseuser);
		return this;
	}

	public Date getReleasedate() {
		return this.repository().getDate(CtConsumablelotholdData.Releasedate);
	}

	public CtConsumablelotholdData setReleasedate(Date Releasedate) {
		this.repository().set(CtConsumablelotholdData.Releasedate, Releasedate);
		return this;
	}

	public String getReleasecomments() {
		return this.repository().getString(CtConsumablelotholdData.Releasecomments);
	}

	public CtConsumablelotholdData setReleasecomments(String Releasecomments) {
		this.repository().set(CtConsumablelotholdData.Releasecomments, Releasecomments);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtConsumablelotholdData.Description);
	}

	public CtConsumablelotholdData setDescription(String Description) {
		this.repository().set(CtConsumablelotholdData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtConsumablelotholdData.Creator);
	}

	public CtConsumablelotholdData setCreator(String Creator) {
		this.repository().set(CtConsumablelotholdData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtConsumablelotholdData.Createdtime);
	}

	public CtConsumablelotholdData setCreatedtime(Date Createdtime) {
		this.repository().set(CtConsumablelotholdData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtConsumablelotholdData.Modifier);
	}

	public CtConsumablelotholdData setModifier(String Modifier) {
		this.repository().set(CtConsumablelotholdData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtConsumablelotholdData.Modifiedtime);
	}

	public CtConsumablelotholdData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtConsumablelotholdData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtConsumablelotholdData.Txnid);
	}

	public CtConsumablelotholdData setTxnid(String Txnid) {
		this.repository().set(CtConsumablelotholdData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtConsumablelotholdData.Txnuser);
	}

	public CtConsumablelotholdData setTxnuser(String Txnuser) {
		this.repository().set(CtConsumablelotholdData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtConsumablelotholdData.Txntime);
	}

	public CtConsumablelotholdData setTxntime(Date Txntime) {
		this.repository().set(CtConsumablelotholdData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtConsumablelotholdData.Txngrouphistkey);
	}

	public CtConsumablelotholdData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtConsumablelotholdData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtConsumablelotholdData.Txnreasoncodeclass);
	}

	public CtConsumablelotholdData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtConsumablelotholdData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtConsumablelotholdData.Txnreasoncode);
	}

	public CtConsumablelotholdData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtConsumablelotholdData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtConsumablelotholdData.Txncomment);
	}

	public CtConsumablelotholdData setTxncomment(String Txncomment) {
		this.repository().set(CtConsumablelotholdData.Txncomment, Txncomment);
		return this;
	}


}