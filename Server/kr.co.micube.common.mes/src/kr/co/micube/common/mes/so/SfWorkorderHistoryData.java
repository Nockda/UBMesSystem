package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfWorkorderHistoryData extends SQLData {

	public static final String Workorderid = "WORKORDERID";

	public static final String Txnhistkey = "TXNHISTKEY";

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

	public static final String Txnid = "TXNID";

	public static final String Txnuser = "TXNUSER";

	public static final String Txntime = "TXNTIME";

	public static final String Txngrouphistkey = "TXNGROUPHISTKEY";

	public static final String Txnreasoncodeclass = "TXNREASONCODECLASS";

	public static final String Txnreasoncode = "TXNREASONCODE";

	public static final String Txncomment = "TXNCOMMENT";

	public static final String Validstate = "VALIDSTATE";

	public SfWorkorderHistoryData() {
		this(new SfWorkorderHistoryKey()); 
	}

	public SfWorkorderHistoryData(SfWorkorderHistoryKey key) {
		super(key, "SfWorkorderHistory");
	}


	public String getWorkordername() {
		return this.repository().getString(SfWorkorderHistoryData.Workordername);
	}

	public SfWorkorderHistoryData setWorkordername(String Workordername) {
		this.repository().set(SfWorkorderHistoryData.Workordername, Workordername);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfWorkorderHistoryData.Enterpriseid);
	}

	public SfWorkorderHistoryData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfWorkorderHistoryData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfWorkorderHistoryData.Plantid);
	}

	public SfWorkorderHistoryData setPlantid(String Plantid) {
		this.repository().set(SfWorkorderHistoryData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfWorkorderHistoryData.Areaid);
	}

	public SfWorkorderHistoryData setAreaid(String Areaid) {
		this.repository().set(SfWorkorderHistoryData.Areaid, Areaid);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(SfWorkorderHistoryData.Equipmentid);
	}

	public SfWorkorderHistoryData setEquipmentid(String Equipmentid) {
		this.repository().set(SfWorkorderHistoryData.Equipmentid, Equipmentid);
		return this;
	}

	public String getProductdefid() {
		return this.repository().getString(SfWorkorderHistoryData.Productdefid);
	}

	public SfWorkorderHistoryData setProductdefid(String Productdefid) {
		this.repository().set(SfWorkorderHistoryData.Productdefid, Productdefid);
		return this;
	}

	public String getProductdefversion() {
		return this.repository().getString(SfWorkorderHistoryData.Productdefversion);
	}

	public SfWorkorderHistoryData setProductdefversion(String Productdefversion) {
		this.repository().set(SfWorkorderHistoryData.Productdefversion, Productdefversion);
		return this;
	}

	public Date getPlanstarttime() {
		return this.repository().getDate(SfWorkorderHistoryData.Planstarttime);
	}

	public SfWorkorderHistoryData setPlanstarttime(Date Planstarttime) {
		this.repository().set(SfWorkorderHistoryData.Planstarttime, Planstarttime);
		return this;
	}

	public Date getPlanendtime() {
		return this.repository().getDate(SfWorkorderHistoryData.Planendtime);
	}

	public SfWorkorderHistoryData setPlanendtime(Date Planendtime) {
		this.repository().set(SfWorkorderHistoryData.Planendtime, Planendtime);
		return this;
	}

	public Double getPlanqty() {
		return this.repository().getDouble(SfWorkorderHistoryData.Planqty);
	}

	public SfWorkorderHistoryData setPlanqty(Double Planqty) {
		this.repository().set(SfWorkorderHistoryData.Planqty, Planqty);
		return this;
	}

	public Date getWorkorderdate() {
		return this.repository().getDate(SfWorkorderHistoryData.Workorderdate);
	}

	public SfWorkorderHistoryData setWorkorderdate(Date Workorderdate) {
		this.repository().set(SfWorkorderHistoryData.Workorderdate, Workorderdate);
		return this;
	}

	public String getOwner() {
		return this.repository().getString(SfWorkorderHistoryData.Owner);
	}

	public SfWorkorderHistoryData setOwner(String Owner) {
		this.repository().set(SfWorkorderHistoryData.Owner, Owner);
		return this;
	}

	public String getState() {
		return this.repository().getString(SfWorkorderHistoryData.State);
	}

	public SfWorkorderHistoryData setState(String State) {
		this.repository().set(SfWorkorderHistoryData.State, State);
		return this;
	}

	public Double getStartqty() {
		return this.repository().getDouble(SfWorkorderHistoryData.Startqty);
	}

	public SfWorkorderHistoryData setStartqty(Double Startqty) {
		this.repository().set(SfWorkorderHistoryData.Startqty, Startqty);
		return this;
	}

	public Double getCompleteqty() {
		return this.repository().getDouble(SfWorkorderHistoryData.Completeqty);
	}

	public SfWorkorderHistoryData setCompleteqty(Double Completeqty) {
		this.repository().set(SfWorkorderHistoryData.Completeqty, Completeqty);
		return this;
	}

	public Double getScrapqty() {
		return this.repository().getDouble(SfWorkorderHistoryData.Scrapqty);
	}

	public SfWorkorderHistoryData setScrapqty(Double Scrapqty) {
		this.repository().set(SfWorkorderHistoryData.Scrapqty, Scrapqty);
		return this;
	}

	public String getStartuser() {
		return this.repository().getString(SfWorkorderHistoryData.Startuser);
	}

	public SfWorkorderHistoryData setStartuser(String Startuser) {
		this.repository().set(SfWorkorderHistoryData.Startuser, Startuser);
		return this;
	}

	public Date getStarttime() {
		return this.repository().getDate(SfWorkorderHistoryData.Starttime);
	}

	public SfWorkorderHistoryData setStarttime(Date Starttime) {
		this.repository().set(SfWorkorderHistoryData.Starttime, Starttime);
		return this;
	}

	public String getCompleteuser() {
		return this.repository().getString(SfWorkorderHistoryData.Completeuser);
	}

	public SfWorkorderHistoryData setCompleteuser(String Completeuser) {
		this.repository().set(SfWorkorderHistoryData.Completeuser, Completeuser);
		return this;
	}

	public Date getCompletetime() {
		return this.repository().getDate(SfWorkorderHistoryData.Completetime);
	}

	public SfWorkorderHistoryData setCompletetime(Date Completetime) {
		this.repository().set(SfWorkorderHistoryData.Completetime, Completetime);
		return this;
	}

	public Integer getDeptseq() {
		return this.repository().getInteger(SfWorkorderHistoryData.Deptseq);
	}

	public SfWorkorderHistoryData setDeptseq(Integer Deptseq) {
		this.repository().set(SfWorkorderHistoryData.Deptseq, Deptseq);
		return this;
	}

	public Integer getWorkcenterseq() {
		return this.repository().getInteger(SfWorkorderHistoryData.Workcenterseq);
	}

	public SfWorkorderHistoryData setWorkcenterseq(Integer Workcenterseq) {
		this.repository().set(SfWorkorderHistoryData.Workcenterseq, Workcenterseq);
		return this;
	}

	public Double getOrderqty() {
		return this.repository().getDouble(SfWorkorderHistoryData.Orderqty);
	}

	public SfWorkorderHistoryData setOrderqty(Double Orderqty) {
		this.repository().set(SfWorkorderHistoryData.Orderqty, Orderqty);
		return this;
	}

	public Integer getWorkorderseq() {
		return this.repository().getInteger(SfWorkorderHistoryData.Workorderseq);
	}

	public SfWorkorderHistoryData setWorkorderseq(Integer Workorderseq) {
		this.repository().set(SfWorkorderHistoryData.Workorderseq, Workorderseq);
		return this;
	}

	public Integer getWorkorderserl() {
		return this.repository().getInteger(SfWorkorderHistoryData.Workorderserl);
	}

	public SfWorkorderHistoryData setWorkorderserl(Integer Workorderserl) {
		this.repository().set(SfWorkorderHistoryData.Workorderserl, Workorderserl);
		return this;
	}

	public Integer getItemseq() {
		return this.repository().getInteger(SfWorkorderHistoryData.Itemseq);
	}

	public SfWorkorderHistoryData setItemseq(Integer Itemseq) {
		this.repository().set(SfWorkorderHistoryData.Itemseq, Itemseq);
		return this;
	}

	public Integer getUnitseq() {
		return this.repository().getInteger(SfWorkorderHistoryData.Unitseq);
	}

	public SfWorkorderHistoryData setUnitseq(Integer Unitseq) {
		this.repository().set(SfWorkorderHistoryData.Unitseq, Unitseq);
		return this;
	}

	public Integer getProcseq() {
		return this.repository().getInteger(SfWorkorderHistoryData.Procseq);
	}

	public SfWorkorderHistoryData setProcseq(Integer Procseq) {
		this.repository().set(SfWorkorderHistoryData.Procseq, Procseq);
		return this;
	}

	public String getUserlotserial() {
		return this.repository().getString(SfWorkorderHistoryData.Userlotserial);
	}

	public SfWorkorderHistoryData setUserlotserial(String Userlotserial) {
		this.repository().set(SfWorkorderHistoryData.Userlotserial, Userlotserial);
		return this;
	}

	public String getIshold() {
		return this.repository().getString(SfWorkorderHistoryData.Ishold);
	}

	public SfWorkorderHistoryData setIshold(String Ishold) {
		this.repository().set(SfWorkorderHistoryData.Ishold, Ishold);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfWorkorderHistoryData.Description);
	}

	public SfWorkorderHistoryData setDescription(String Description) {
		this.repository().set(SfWorkorderHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfWorkorderHistoryData.Creator);
	}

	public SfWorkorderHistoryData setCreator(String Creator) {
		this.repository().set(SfWorkorderHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfWorkorderHistoryData.Createdtime);
	}

	public SfWorkorderHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(SfWorkorderHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfWorkorderHistoryData.Modifier);
	}

	public SfWorkorderHistoryData setModifier(String Modifier) {
		this.repository().set(SfWorkorderHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfWorkorderHistoryData.Modifiedtime);
	}

	public SfWorkorderHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfWorkorderHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(SfWorkorderHistoryData.Txnid);
	}

	public SfWorkorderHistoryData setTxnid(String Txnid) {
		this.repository().set(SfWorkorderHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfWorkorderHistoryData.Txnuser);
	}

	public SfWorkorderHistoryData setTxnuser(String Txnuser) {
		this.repository().set(SfWorkorderHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfWorkorderHistoryData.Txntime);
	}

	public SfWorkorderHistoryData setTxntime(Date Txntime) {
		this.repository().set(SfWorkorderHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfWorkorderHistoryData.Txngrouphistkey);
	}

	public SfWorkorderHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfWorkorderHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfWorkorderHistoryData.Txnreasoncodeclass);
	}

	public SfWorkorderHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfWorkorderHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfWorkorderHistoryData.Txnreasoncode);
	}

	public SfWorkorderHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfWorkorderHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfWorkorderHistoryData.Txncomment);
	}

	public SfWorkorderHistoryData setTxncomment(String Txncomment) {
		this.repository().set(SfWorkorderHistoryData.Txncomment, Txncomment);
		return this;
	}

	public String getValidstate() {
		return this.repository().getString(SfWorkorderHistoryData.Validstate);
	}

	public SfWorkorderHistoryData setValidstate(String Validstate) {
		this.repository().set(SfWorkorderHistoryData.Validstate, Validstate);
		return this;
	}


}