package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfWorkorderData extends SQLData {

	public static final String Workorderid = "WORKORDERID";

	public static final String Productionorderid = "PRODUCTIONORDERID";

	public static final String Workordername = "WORKORDERNAME";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Areaid = "AREAID";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Productdefid = "PRODUCTDEFID";

	public static final String Productdefversion = "PRODUCTDEFVERSION";

	public static final String Planstarttime = "PLANSTARTTIME";

	public static final String Planendtime = "PLANENDTIME";

	public static final String Planqty = "PLANQTY";

	public static final String Workorderdate = "WORKORDERDATE";

	public static final String Owner = "OWNER";

	public static final String State = "STATE";

	public static final String Startqty = "STARTQTY";

	public static final String Completeqty = "COMPLETEQTY";

	public static final String Scrapqty = "SCRAPQTY";

	public static final String Startuser = "STARTUSER";

	public static final String Starttime = "STARTTIME";

	public static final String Completeuser = "COMPLETEUSER";

	public static final String Completetime = "COMPLETETIME";

	public static final String Deptseq = "DEPTSEQ";

	public static final String Workcenterseq = "WORKCENTERSEQ";

	public static final String Orderqty = "ORDERQTY";

	public static final String Workorderseq = "WORKORDERSEQ";

	public static final String Workorderserl = "WORKORDERSERL";

	public static final String Itemseq = "ITEMSEQ";

	public static final String Unitseq = "UNITSEQ";

	public static final String Procseq = "PROCSEQ";

	public static final String Userlotserial = "USERLOTSERIAL";

	public static final String Ishold = "ISHOLD";

	public static final String Description = "DESCRIPTION";

	public static final String Creator = "CREATOR";

	public static final String Createdtime = "CREATEDTIME";

	public static final String Modifier = "MODIFIER";

	public static final String Modifiedtime = "MODIFIEDTIME";

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Lasttxnid = "LASTTXNID";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public SfWorkorderData() {
		this(new SfWorkorderKey()); 
	}

	public SfWorkorderData(SfWorkorderKey key) {
		super(key, "SfWorkorder");
	}


	public String getProductionorderid() {
		return this.repository().getString(SfWorkorderData.Productionorderid);
	}

	public SfWorkorderData setProductionorderid(String Productionorderid) {
		this.repository().set(SfWorkorderData.Productionorderid, Productionorderid);
		return this;
	}

	public String getWorkordername() {
		return this.repository().getString(SfWorkorderData.Workordername);
	}

	public SfWorkorderData setWorkordername(String Workordername) {
		this.repository().set(SfWorkorderData.Workordername, Workordername);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfWorkorderData.Enterpriseid);
	}

	public SfWorkorderData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfWorkorderData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfWorkorderData.Plantid);
	}

	public SfWorkorderData setPlantid(String Plantid) {
		this.repository().set(SfWorkorderData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfWorkorderData.Areaid);
	}

	public SfWorkorderData setAreaid(String Areaid) {
		this.repository().set(SfWorkorderData.Areaid, Areaid);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(SfWorkorderData.Equipmentid);
	}

	public SfWorkorderData setEquipmentid(String Equipmentid) {
		this.repository().set(SfWorkorderData.Equipmentid, Equipmentid);
		return this;
	}

	public String getProductdefid() {
		return this.repository().getString(SfWorkorderData.Productdefid);
	}

	public SfWorkorderData setProductdefid(String Productdefid) {
		this.repository().set(SfWorkorderData.Productdefid, Productdefid);
		return this;
	}

	public String getProductdefversion() {
		return this.repository().getString(SfWorkorderData.Productdefversion);
	}

	public SfWorkorderData setProductdefversion(String Productdefversion) {
		this.repository().set(SfWorkorderData.Productdefversion, Productdefversion);
		return this;
	}

	public Date getPlanstarttime() {
		return this.repository().getDate(SfWorkorderData.Planstarttime);
	}

	public SfWorkorderData setPlanstarttime(Date Planstarttime) {
		this.repository().set(SfWorkorderData.Planstarttime, Planstarttime);
		return this;
	}

	public Date getPlanendtime() {
		return this.repository().getDate(SfWorkorderData.Planendtime);
	}

	public SfWorkorderData setPlanendtime(Date Planendtime) {
		this.repository().set(SfWorkorderData.Planendtime, Planendtime);
		return this;
	}

	public Double getPlanqty() {
		return this.repository().getDouble(SfWorkorderData.Planqty);
	}

	public SfWorkorderData setPlanqty(Double Planqty) {
		this.repository().set(SfWorkorderData.Planqty, Planqty);
		return this;
	}

	public Date getWorkorderdate() {
		return this.repository().getDate(SfWorkorderData.Workorderdate);
	}

	public SfWorkorderData setWorkorderdate(Date Workorderdate) {
		this.repository().set(SfWorkorderData.Workorderdate, Workorderdate);
		return this;
	}

	public String getOwner() {
		return this.repository().getString(SfWorkorderData.Owner);
	}

	public SfWorkorderData setOwner(String Owner) {
		this.repository().set(SfWorkorderData.Owner, Owner);
		return this;
	}

	public String getState() {
		return this.repository().getString(SfWorkorderData.State);
	}

	public SfWorkorderData setState(String State) {
		this.repository().set(SfWorkorderData.State, State);
		return this;
	}

	public Double getStartqty() {
		return this.repository().getDouble(SfWorkorderData.Startqty);
	}

	public SfWorkorderData setStartqty(Double Startqty) {
		this.repository().set(SfWorkorderData.Startqty, Startqty);
		return this;
	}

	public Double getCompleteqty() {
		return this.repository().getDouble(SfWorkorderData.Completeqty);
	}

	public SfWorkorderData setCompleteqty(Double Completeqty) {
		this.repository().set(SfWorkorderData.Completeqty, Completeqty);
		return this;
	}

	public Double getScrapqty() {
		return this.repository().getDouble(SfWorkorderData.Scrapqty);
	}

	public SfWorkorderData setScrapqty(Double Scrapqty) {
		this.repository().set(SfWorkorderData.Scrapqty, Scrapqty);
		return this;
	}

	public String getStartuser() {
		return this.repository().getString(SfWorkorderData.Startuser);
	}

	public SfWorkorderData setStartuser(String Startuser) {
		this.repository().set(SfWorkorderData.Startuser, Startuser);
		return this;
	}

	public Date getStarttime() {
		return this.repository().getDate(SfWorkorderData.Starttime);
	}

	public SfWorkorderData setStarttime(Date Starttime) {
		this.repository().set(SfWorkorderData.Starttime, Starttime);
		return this;
	}

	public String getCompleteuser() {
		return this.repository().getString(SfWorkorderData.Completeuser);
	}

	public SfWorkorderData setCompleteuser(String Completeuser) {
		this.repository().set(SfWorkorderData.Completeuser, Completeuser);
		return this;
	}

	public Date getCompletetime() {
		return this.repository().getDate(SfWorkorderData.Completetime);
	}

	public SfWorkorderData setCompletetime(Date Completetime) {
		this.repository().set(SfWorkorderData.Completetime, Completetime);
		return this;
	}

	public Integer getDeptseq() {
		return this.repository().getInteger(SfWorkorderData.Deptseq);
	}

	public SfWorkorderData setDeptseq(Integer Deptseq) {
		this.repository().set(SfWorkorderData.Deptseq, Deptseq);
		return this;
	}

	public Integer getWorkcenterseq() {
		return this.repository().getInteger(SfWorkorderData.Workcenterseq);
	}

	public SfWorkorderData setWorkcenterseq(Integer Workcenterseq) {
		this.repository().set(SfWorkorderData.Workcenterseq, Workcenterseq);
		return this;
	}

	public Double getOrderqty() {
		return this.repository().getDouble(SfWorkorderData.Orderqty);
	}

	public SfWorkorderData setOrderqty(Double Orderqty) {
		this.repository().set(SfWorkorderData.Orderqty, Orderqty);
		return this;
	}

	public Integer getWorkorderseq() {
		return this.repository().getInteger(SfWorkorderData.Workorderseq);
	}

	public SfWorkorderData setWorkorderseq(Integer Workorderseq) {
		this.repository().set(SfWorkorderData.Workorderseq, Workorderseq);
		return this;
	}

	public Integer getWorkorderserl() {
		return this.repository().getInteger(SfWorkorderData.Workorderserl);
	}

	public SfWorkorderData setWorkorderserl(Integer Workorderserl) {
		this.repository().set(SfWorkorderData.Workorderserl, Workorderserl);
		return this;
	}

	public Integer getItemseq() {
		return this.repository().getInteger(SfWorkorderData.Itemseq);
	}

	public SfWorkorderData setItemseq(Integer Itemseq) {
		this.repository().set(SfWorkorderData.Itemseq, Itemseq);
		return this;
	}

	public Integer getUnitseq() {
		return this.repository().getInteger(SfWorkorderData.Unitseq);
	}

	public SfWorkorderData setUnitseq(Integer Unitseq) {
		this.repository().set(SfWorkorderData.Unitseq, Unitseq);
		return this;
	}

	public Integer getProcseq() {
		return this.repository().getInteger(SfWorkorderData.Procseq);
	}

	public SfWorkorderData setProcseq(Integer Procseq) {
		this.repository().set(SfWorkorderData.Procseq, Procseq);
		return this;
	}

	public String getUserlotserial() {
		return this.repository().getString(SfWorkorderData.Userlotserial);
	}

	public SfWorkorderData setUserlotserial(String Userlotserial) {
		this.repository().set(SfWorkorderData.Userlotserial, Userlotserial);
		return this;
	}

	public String getIshold() {
		return this.repository().getString(SfWorkorderData.Ishold);
	}

	public SfWorkorderData setIshold(String Ishold) {
		this.repository().set(SfWorkorderData.Ishold, Ishold);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfWorkorderData.Description);
	}

	public SfWorkorderData setDescription(String Description) {
		this.repository().set(SfWorkorderData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfWorkorderData.Creator);
	}

	public SfWorkorderData setCreator(String Creator) {
		this.repository().set(SfWorkorderData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfWorkorderData.Createdtime);
	}

	public SfWorkorderData setCreatedtime(Date Createdtime) {
		this.repository().set(SfWorkorderData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfWorkorderData.Modifier);
	}

	public SfWorkorderData setModifier(String Modifier) {
		this.repository().set(SfWorkorderData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfWorkorderData.Modifiedtime);
	}

	public SfWorkorderData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfWorkorderData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfWorkorderData.Lasttxnhistkey);
	}

	public SfWorkorderData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfWorkorderData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfWorkorderData.Lasttxnid);
	}

	public SfWorkorderData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfWorkorderData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfWorkorderData.Lasttxnuser);
	}

	public SfWorkorderData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfWorkorderData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfWorkorderData.Lasttxntime);
	}

	public SfWorkorderData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfWorkorderData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfWorkorderData.Lasttxncomment);
	}

	public SfWorkorderData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfWorkorderData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfWorkorderData.Validstate);
	}

	public SfWorkorderData setValidstate(String Validstate) {
		this.repository().set(SfWorkorderData.Validstate, Validstate);
		return this;
	}


}