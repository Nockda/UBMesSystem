package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtNonorderconsumableworkresultData extends SQLData {

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Consumablelotid = "CONSUMABLELOTID";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Areaid = "AREAID";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Warehouseid = "WAREHOUSEID";

	public static final String Parentconsumablelotid = "PARENTCONSUMABLELOTID";

	public static final String Inputqty = "INPUTQTY";

	public static final String Workqty = "WORKQTY";

	public static final String Worker = "WORKER";

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

	public static final String Workstarttime = "WORKSTARTTIME";

	public static final String Workendtime = "WORKENDTIME";

	public static final String Switchdate = "SWITCHDATE";

	public CtNonorderconsumableworkresultData() {
		this(new CtNonorderconsumableworkresultKey()); 
	}

	public CtNonorderconsumableworkresultData(CtNonorderconsumableworkresultKey key) {
		super(key, "CtNonorderconsumableworkresult");
		this.txnInfo().setHistoryTable(true);
	}


	public String getEnterpriseid() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Enterpriseid);
	}

	public CtNonorderconsumableworkresultData setEnterpriseid(String Enterpriseid) {
		this.repository().set(CtNonorderconsumableworkresultData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Plantid);
	}

	public CtNonorderconsumableworkresultData setPlantid(String Plantid) {
		this.repository().set(CtNonorderconsumableworkresultData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Areaid);
	}

	public CtNonorderconsumableworkresultData setAreaid(String Areaid) {
		this.repository().set(CtNonorderconsumableworkresultData.Areaid, Areaid);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Equipmentid);
	}

	public CtNonorderconsumableworkresultData setEquipmentid(String Equipmentid) {
		this.repository().set(CtNonorderconsumableworkresultData.Equipmentid, Equipmentid);
		return this;
	}

	public String getWarehouseid() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Warehouseid);
	}

	public CtNonorderconsumableworkresultData setWarehouseid(String Warehouseid) {
		this.repository().set(CtNonorderconsumableworkresultData.Warehouseid, Warehouseid);
		return this;
	}

	public String getParentconsumablelotid() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Parentconsumablelotid);
	}

	public CtNonorderconsumableworkresultData setParentconsumablelotid(String Parentconsumablelotid) {
		this.repository().set(CtNonorderconsumableworkresultData.Parentconsumablelotid, Parentconsumablelotid);
		return this;
	}

	public Double getInputqty() {
		return this.repository().getDouble(CtNonorderconsumableworkresultData.Inputqty);
	}

	public CtNonorderconsumableworkresultData setInputqty(Double Inputqty) {
		this.repository().set(CtNonorderconsumableworkresultData.Inputqty, Inputqty);
		return this;
	}

	public Double getWorkqty() {
		return this.repository().getDouble(CtNonorderconsumableworkresultData.Workqty);
	}

	public CtNonorderconsumableworkresultData setWorkqty(Double Workqty) {
		this.repository().set(CtNonorderconsumableworkresultData.Workqty, Workqty);
		return this;
	}

	public String getWorker() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Worker);
	}

	public CtNonorderconsumableworkresultData setWorker(String Worker) {
		this.repository().set(CtNonorderconsumableworkresultData.Worker, Worker);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Description);
	}

	public CtNonorderconsumableworkresultData setDescription(String Description) {
		this.repository().set(CtNonorderconsumableworkresultData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Creator);
	}

	public CtNonorderconsumableworkresultData setCreator(String Creator) {
		this.repository().set(CtNonorderconsumableworkresultData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtNonorderconsumableworkresultData.Createdtime);
	}

	public CtNonorderconsumableworkresultData setCreatedtime(Date Createdtime) {
		this.repository().set(CtNonorderconsumableworkresultData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Modifier);
	}

	public CtNonorderconsumableworkresultData setModifier(String Modifier) {
		this.repository().set(CtNonorderconsumableworkresultData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtNonorderconsumableworkresultData.Modifiedtime);
	}

	public CtNonorderconsumableworkresultData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtNonorderconsumableworkresultData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Txnid);
	}

	public CtNonorderconsumableworkresultData setTxnid(String Txnid) {
		this.repository().set(CtNonorderconsumableworkresultData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Txnuser);
	}

	public CtNonorderconsumableworkresultData setTxnuser(String Txnuser) {
		this.repository().set(CtNonorderconsumableworkresultData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtNonorderconsumableworkresultData.Txntime);
	}

	public CtNonorderconsumableworkresultData setTxntime(Date Txntime) {
		this.repository().set(CtNonorderconsumableworkresultData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Txngrouphistkey);
	}

	public CtNonorderconsumableworkresultData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtNonorderconsumableworkresultData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Txnreasoncodeclass);
	}

	public CtNonorderconsumableworkresultData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtNonorderconsumableworkresultData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Txnreasoncode);
	}

	public CtNonorderconsumableworkresultData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtNonorderconsumableworkresultData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Txncomment);
	}

	public CtNonorderconsumableworkresultData setTxncomment(String Txncomment) {
		this.repository().set(CtNonorderconsumableworkresultData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(CtNonorderconsumableworkresultData.Validstate);
	}

	public CtNonorderconsumableworkresultData setValidstate(String Validstate) {
		this.repository().set(CtNonorderconsumableworkresultData.Validstate, Validstate);
		return this;
	}

	public Date getWorkstarttime() {
		return this.repository().getDate(CtNonorderconsumableworkresultData.Workstarttime);
	}

	public CtNonorderconsumableworkresultData setWorkstarttime(Date Workstarttime) {
		this.repository().set(CtNonorderconsumableworkresultData.Workstarttime, Workstarttime);
		return this;
	}

	public Date getWorkendtime() {
		return this.repository().getDate(CtNonorderconsumableworkresultData.Workendtime);
	}

	public CtNonorderconsumableworkresultData setWorkendtime(Date Workendtime) {
		this.repository().set(CtNonorderconsumableworkresultData.Workendtime, Workendtime);
		return this;
	}

	public Date getSwitchdate() {
		return this.repository().getDate(CtNonorderconsumableworkresultData.Switchdate);
	}

	public CtNonorderconsumableworkresultData setSwitchdate(Date Switchdate) {
		this.repository().set(CtNonorderconsumableworkresultData.Switchdate, Switchdate);
		return this;
	}


}