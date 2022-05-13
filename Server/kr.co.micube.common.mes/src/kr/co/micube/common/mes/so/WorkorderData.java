package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class WorkorderData extends SQLData {

	public static final String Workorderid = "WORKORDERID";

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

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Lasttxnid = "LASTTXNID";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public static final String Workorderseq = "WORKORDERSEQ";

	public static final String Deptseq = "DEPTSEQ";

	public static final String Workcenterseq = "WORKCENTERSEQ";

	public static final String Orderqty = "ORDERQTY";

	public static final String Workorderdate = "WORKORDERDATE";

	public WorkorderData() {
		this(new WorkorderKey()); 
	}

	public WorkorderData(WorkorderKey key) {
		super(key, "SfWorkorder");
	}


	public String getProductionorderid() {
		return this.repository().getString(WorkorderData.Productionorderid);
	}

	public WorkorderData setProductionorderid(String Productionorderid) {
		this.repository().set(WorkorderData.Productionorderid, Productionorderid);
		return this;
	}

	public String getWorkordername() {
		return this.repository().getString(WorkorderData.Workordername);
	}

	public WorkorderData setWorkordername(String Workordername) {
		this.repository().set(WorkorderData.Workordername, Workordername);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(WorkorderData.Description);
	}

	public WorkorderData setDescription(String Description) {
		this.repository().set(WorkorderData.Description, Description);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(WorkorderData.Enterpriseid);
	}

	public WorkorderData setEnterpriseid(String Enterpriseid) {
		this.repository().set(WorkorderData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(WorkorderData.Plantid);
	}

	public WorkorderData setPlantid(String Plantid) {
		this.repository().set(WorkorderData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(WorkorderData.Areaid);
	}

	public WorkorderData setAreaid(String Areaid) {
		this.repository().set(WorkorderData.Areaid, Areaid);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(WorkorderData.Equipmentid);
	}

	public WorkorderData setEquipmentid(String Equipmentid) {
		this.repository().set(WorkorderData.Equipmentid, Equipmentid);
		return this;
	}

	public String getProductdefid() {
		return this.repository().getString(WorkorderData.Productdefid);
	}

	public WorkorderData setProductdefid(String Productdefid) {
		this.repository().set(WorkorderData.Productdefid, Productdefid);
		return this;
	}

	public String getProductdefversion() {
		return this.repository().getString(WorkorderData.Productdefversion);
	}

	public WorkorderData setProductdefversion(String Productdefversion) {
		this.repository().set(WorkorderData.Productdefversion, Productdefversion);
		return this;
	}

	public Date getPlanstarttime() {
		return this.repository().getDate(WorkorderData.Planstarttime);
	}

	public WorkorderData setPlanstarttime(Date Planstarttime) {
		this.repository().set(WorkorderData.Planstarttime, Planstarttime);
		return this;
	}

	public Date getPlanendtime() {
		return this.repository().getDate(WorkorderData.Planendtime);
	}

	public WorkorderData setPlanendtime(Date Planendtime) {
		this.repository().set(WorkorderData.Planendtime, Planendtime);
		return this;
	}

	public Double getPlanqty() {
		return this.repository().getDouble(WorkorderData.Planqty);
	}

	public WorkorderData setPlanqty(Double Planqty) {
		this.repository().set(WorkorderData.Planqty, Planqty);
		return this;
	}

	public String getOwner() {
		return this.repository().getString(WorkorderData.Owner);
	}

	public WorkorderData setOwner(String Owner) {
		this.repository().set(WorkorderData.Owner, Owner);
		return this;
	}

	public String getState() {
		return this.repository().getString(WorkorderData.State);
	}

	public WorkorderData setState(String State) {
		this.repository().set(WorkorderData.State, State);
		return this;
	}

	public Double getStartqty() {
		return this.repository().getDouble(WorkorderData.Startqty);
	}

	public WorkorderData setStartqty(Double Startqty) {
		this.repository().set(WorkorderData.Startqty, Startqty);
		return this;
	}

	public Double getCompleteqty() {
		return this.repository().getDouble(WorkorderData.Completeqty);
	}

	public WorkorderData setCompleteqty(Double Completeqty) {
		this.repository().set(WorkorderData.Completeqty, Completeqty);
		return this;
	}

	public Double getScrapqty() {
		return this.repository().getDouble(WorkorderData.Scrapqty);
	}

	public WorkorderData setScrapqty(Double Scrapqty) {
		this.repository().set(WorkorderData.Scrapqty, Scrapqty);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(WorkorderData.Creator);
	}

	public WorkorderData setCreator(String Creator) {
		this.repository().set(WorkorderData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(WorkorderData.Createdtime);
	}

	public WorkorderData setCreatedtime(Date Createdtime) {
		this.repository().set(WorkorderData.Createdtime, Createdtime);
		return this;
	}

	public String getStartuser() {
		return this.repository().getString(WorkorderData.Startuser);
	}

	public WorkorderData setStartuser(String Startuser) {
		this.repository().set(WorkorderData.Startuser, Startuser);
		return this;
	}

	public Date getStarttime() {
		return this.repository().getDate(WorkorderData.Starttime);
	}

	public WorkorderData setStarttime(Date Starttime) {
		this.repository().set(WorkorderData.Starttime, Starttime);
		return this;
	}

	public String getCompleteuser() {
		return this.repository().getString(WorkorderData.Completeuser);
	}

	public WorkorderData setCompleteuser(String Completeuser) {
		this.repository().set(WorkorderData.Completeuser, Completeuser);
		return this;
	}

	public Date getCompletetime() {
		return this.repository().getDate(WorkorderData.Completetime);
	}

	public WorkorderData setCompletetime(Date Completetime) {
		this.repository().set(WorkorderData.Completetime, Completetime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(WorkorderData.Modifier);
	}

	public WorkorderData setModifier(String Modifier) {
		this.repository().set(WorkorderData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(WorkorderData.Modifiedtime);
	}

	public WorkorderData setModifiedtime(Date Modifiedtime) {
		this.repository().set(WorkorderData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(WorkorderData.Lasttxnhistkey);
	}

	public WorkorderData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(WorkorderData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(WorkorderData.Lasttxnid);
	}

	public WorkorderData setLasttxnid(String Lasttxnid) {
		this.repository().set(WorkorderData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(WorkorderData.Lasttxnuser);
	}

	public WorkorderData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(WorkorderData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(WorkorderData.Lasttxntime);
	}

	public WorkorderData setLasttxntime(Date Lasttxntime) {
		this.repository().set(WorkorderData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(WorkorderData.Lasttxncomment);
	}

	public WorkorderData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(WorkorderData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(WorkorderData.Validstate);
	}

	public WorkorderData setValidstate(String Validstate) {
		this.repository().set(WorkorderData.Validstate, Validstate);
		return this;
	}

	public Integer getWorkorderseq() {
		return this.repository().getInteger(WorkorderData.Workorderseq);
	}

	public WorkorderData setWorkorderseq(Integer Workorderseq) {
		this.repository().set(WorkorderData.Workorderseq, Workorderseq);
		return this;
	}

	public Integer getDeptseq() {
		return this.repository().getInteger(WorkorderData.Deptseq);
	}

	public WorkorderData setDeptseq(Integer Deptseq) {
		this.repository().set(WorkorderData.Deptseq, Deptseq);
		return this;
	}

	public Integer getWorkcenterseq() {
		return this.repository().getInteger(WorkorderData.Workcenterseq);
	}

	public WorkorderData setWorkcenterseq(Integer Workcenterseq) {
		this.repository().set(WorkorderData.Workcenterseq, Workcenterseq);
		return this;
	}

	public Double getOrderqty() {
		return this.repository().getDouble(WorkorderData.Orderqty);
	}

	public WorkorderData setOrderqty(Double Orderqty) {
		this.repository().set(WorkorderData.Orderqty, Orderqty);
		return this;
	}

	public Date getWorkorderdate() {
		return this.repository().getDate(WorkorderData.Workorderdate);
	}

	public WorkorderData setWorkorderdate(Date Workorderdate) {
		this.repository().set(WorkorderData.Workorderdate, Workorderdate);
		return this;
	}


}