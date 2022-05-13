package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class WorkorderHistotryData extends SQLData {

	public static final String Workorderid = "WORKORDERID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnid = "TXNID";

	public static final String Productionorderid = "PRODUCTIONORDERID";

	public static final String Workordername = "WORKORDERNAME";

	public static final String Description = "DESCRIPTION";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Areaid = "AREAID";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Productdefid = "PRODUCTDEFID";

	public static final String Productdefversion = "PRODUCTDEFVERSION";

	public static final String Planstarttime = "PLANSTARTTIME";

	public static final String Planendtime = "PLANENDTIME";

	public static final String Planqty = "PLANQTY";

	public static final String Owner = "OWNER";

	public static final String State = "STATE";

	public static final String Startqty = "STARTQTY";

	public static final String Completeqty = "COMPLETEQTY";

	public static final String Scrapqty = "SCRAPQTY";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Startuser = "STARTUSER";

	public static final String Starttime = "STARTTIME";

	public static final String Completeuser = "COMPLETEUSER";

	public static final String Completetime = "COMPLETETIME";

	public static final String Modifier = "MODIFIER";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public static final String Workorderseq = "WORKORDERSEQ";

	public static final String Deptseq = "DEPTSEQ";

	public static final String Workcenterseq = "WORKCENTERSEQ";

	public static final String Orderqty = "ORDERQTY";

	public static final String Workorderdate = "WORKORDERDATE";

	public WorkorderHistotryData() {
		this(new WorkorderHistotryKey()); 
	}

	public WorkorderHistotryData(WorkorderHistotryKey key) {
		super(key, "SfWorkorderHistotry");
	}


	public String getTxngrouphistkey() {
		return this.repository().getString(WorkorderHistotryData.Txngrouphistkey);
	}

	public WorkorderHistotryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(WorkorderHistotryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(WorkorderHistotryData.Txnid);
	}

	public WorkorderHistotryData setTxnid(String Txnid) {
		this.repository().set(WorkorderHistotryData.Txnid, Txnid);
		return this;
	}

	public String getProductionorderid() {
		return this.repository().getString(WorkorderHistotryData.Productionorderid);
	}

	public WorkorderHistotryData setProductionorderid(String Productionorderid) {
		this.repository().set(WorkorderHistotryData.Productionorderid, Productionorderid);
		return this;
	}

	public String getWorkordername() {
		return this.repository().getString(WorkorderHistotryData.Workordername);
	}

	public WorkorderHistotryData setWorkordername(String Workordername) {
		this.repository().set(WorkorderHistotryData.Workordername, Workordername);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(WorkorderHistotryData.Description);
	}

	public WorkorderHistotryData setDescription(String Description) {
		this.repository().set(WorkorderHistotryData.Description, Description);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(WorkorderHistotryData.Enterpriseid);
	}

	public WorkorderHistotryData setEnterpriseid(String Enterpriseid) {
		this.repository().set(WorkorderHistotryData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(WorkorderHistotryData.Plantid);
	}

	public WorkorderHistotryData setPlantid(String Plantid) {
		this.repository().set(WorkorderHistotryData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(WorkorderHistotryData.Areaid);
	}

	public WorkorderHistotryData setAreaid(String Areaid) {
		this.repository().set(WorkorderHistotryData.Areaid, Areaid);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(WorkorderHistotryData.Equipmentid);
	}

	public WorkorderHistotryData setEquipmentid(String Equipmentid) {
		this.repository().set(WorkorderHistotryData.Equipmentid, Equipmentid);
		return this;
	}

	public String getProductdefid() {
		return this.repository().getString(WorkorderHistotryData.Productdefid);
	}

	public WorkorderHistotryData setProductdefid(String Productdefid) {
		this.repository().set(WorkorderHistotryData.Productdefid, Productdefid);
		return this;
	}

	public String getProductdefversion() {
		return this.repository().getString(WorkorderHistotryData.Productdefversion);
	}

	public WorkorderHistotryData setProductdefversion(String Productdefversion) {
		this.repository().set(WorkorderHistotryData.Productdefversion, Productdefversion);
		return this;
	}

	public Date getPlanstarttime() {
		return this.repository().getDate(WorkorderHistotryData.Planstarttime);
	}

	public WorkorderHistotryData setPlanstarttime(Date Planstarttime) {
		this.repository().set(WorkorderHistotryData.Planstarttime, Planstarttime);
		return this;
	}

	public Date getPlanendtime() {
		return this.repository().getDate(WorkorderHistotryData.Planendtime);
	}

	public WorkorderHistotryData setPlanendtime(Date Planendtime) {
		this.repository().set(WorkorderHistotryData.Planendtime, Planendtime);
		return this;
	}

	public Double getPlanqty() {
		return this.repository().getDouble(WorkorderHistotryData.Planqty);
	}

	public WorkorderHistotryData setPlanqty(Double Planqty) {
		this.repository().set(WorkorderHistotryData.Planqty, Planqty);
		return this;
	}

	public String getOwner() {
		return this.repository().getString(WorkorderHistotryData.Owner);
	}

	public WorkorderHistotryData setOwner(String Owner) {
		this.repository().set(WorkorderHistotryData.Owner, Owner);
		return this;
	}

	public String getState() {
		return this.repository().getString(WorkorderHistotryData.State);
	}

	public WorkorderHistotryData setState(String State) {
		this.repository().set(WorkorderHistotryData.State, State);
		return this;
	}

	public Double getStartqty() {
		return this.repository().getDouble(WorkorderHistotryData.Startqty);
	}

	public WorkorderHistotryData setStartqty(Double Startqty) {
		this.repository().set(WorkorderHistotryData.Startqty, Startqty);
		return this;
	}

	public Double getCompleteqty() {
		return this.repository().getDouble(WorkorderHistotryData.Completeqty);
	}

	public WorkorderHistotryData setCompleteqty(Double Completeqty) {
		this.repository().set(WorkorderHistotryData.Completeqty, Completeqty);
		return this;
	}

	public Double getScrapqty() {
		return this.repository().getDouble(WorkorderHistotryData.Scrapqty);
	}

	public WorkorderHistotryData setScrapqty(Double Scrapqty) {
		this.repository().set(WorkorderHistotryData.Scrapqty, Scrapqty);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(WorkorderHistotryData.Creator);
	}

	public WorkorderHistotryData setCreator(String Creator) {
		this.repository().set(WorkorderHistotryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(WorkorderHistotryData.Createdtime);
	}

	public WorkorderHistotryData setCreatedtime(Date Createdtime) {
		this.repository().set(WorkorderHistotryData.Createdtime, Createdtime);
		return this;
	}

	public String getStartuser() {
		return this.repository().getString(WorkorderHistotryData.Startuser);
	}

	public WorkorderHistotryData setStartuser(String Startuser) {
		this.repository().set(WorkorderHistotryData.Startuser, Startuser);
		return this;
	}

	public Date getStarttime() {
		return this.repository().getDate(WorkorderHistotryData.Starttime);
	}

	public WorkorderHistotryData setStarttime(Date Starttime) {
		this.repository().set(WorkorderHistotryData.Starttime, Starttime);
		return this;
	}

	public String getCompleteuser() {
		return this.repository().getString(WorkorderHistotryData.Completeuser);
	}

	public WorkorderHistotryData setCompleteuser(String Completeuser) {
		this.repository().set(WorkorderHistotryData.Completeuser, Completeuser);
		return this;
	}

	public Date getCompletetime() {
		return this.repository().getDate(WorkorderHistotryData.Completetime);
	}

	public WorkorderHistotryData setCompletetime(Date Completetime) {
		this.repository().set(WorkorderHistotryData.Completetime, Completetime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(WorkorderHistotryData.Modifier);
	}

	public WorkorderHistotryData setModifier(String Modifier) {
		this.repository().set(WorkorderHistotryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(WorkorderHistotryData.Modifiedtime);
	}

	public WorkorderHistotryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(WorkorderHistotryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(WorkorderHistotryData.Txnuser);
	}

	public WorkorderHistotryData setTxnuser(String Txnuser) {
		this.repository().set(WorkorderHistotryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(WorkorderHistotryData.Txntime);
	}

	public WorkorderHistotryData setTxntime(Date Txntime) {
		this.repository().set(WorkorderHistotryData.Txntime, Txntime);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(WorkorderHistotryData.Txnreasoncodeclass);
	}

	public WorkorderHistotryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(WorkorderHistotryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(WorkorderHistotryData.Txnreasoncode);
	}

	public WorkorderHistotryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(WorkorderHistotryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(WorkorderHistotryData.Txncomment);
	}

	public WorkorderHistotryData setTxncomment(String Txncomment) {
		this.repository().set(WorkorderHistotryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(WorkorderHistotryData.Validstate);
	}

	public WorkorderHistotryData setValidstate(String Validstate) {
		this.repository().set(WorkorderHistotryData.Validstate, Validstate);
		return this;
	}

	public Integer getWorkorderseq() {
		return this.repository().getInteger(WorkorderHistotryData.Workorderseq);
	}

	public WorkorderHistotryData setWorkorderseq(Integer Workorderseq) {
		this.repository().set(WorkorderHistotryData.Workorderseq, Workorderseq);
		return this;
	}

	public Integer getDeptseq() {
		return this.repository().getInteger(WorkorderHistotryData.Deptseq);
	}

	public WorkorderHistotryData setDeptseq(Integer Deptseq) {
		this.repository().set(WorkorderHistotryData.Deptseq, Deptseq);
		return this;
	}

	public Integer getWorkcenterseq() {
		return this.repository().getInteger(WorkorderHistotryData.Workcenterseq);
	}

	public WorkorderHistotryData setWorkcenterseq(Integer Workcenterseq) {
		this.repository().set(WorkorderHistotryData.Workcenterseq, Workcenterseq);
		return this;
	}

	public Double getOrderqty() {
		return this.repository().getDouble(WorkorderHistotryData.Orderqty);
	}

	public WorkorderHistotryData setOrderqty(Double Orderqty) {
		this.repository().set(WorkorderHistotryData.Orderqty, Orderqty);
		return this;
	}

	public Date getWorkorderdate() {
		return this.repository().getDate(WorkorderHistotryData.Workorderdate);
	}

	public WorkorderHistotryData setWorkorderdate(Date Workorderdate) {
		this.repository().set(WorkorderHistotryData.Workorderdate, Workorderdate);
		return this;
	}


}