package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfLotHistoryData extends SQLData {

	public static final String Lotid = "LOTID";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Lotname = "LOTNAME";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Prevplantid = "PREVPLANTID";

	public static final String Areaid = "AREAID";

	public static final String Prevareaid = "PREVAREAID";

	public static final String Equipmentid = "EQUIPMENTID";

	public static final String Prevequipmentid = "PREVEQUIPMENTID";

	public static final String Locationid = "LOCATIONID";

	public static final String Recipedefid = "RECIPEDEFID";

	public static final String Recipedefversion = "RECIPEDEFVERSION";

	public static final String Originalplantid = "ORIGINALPLANTID";

	public static final String Rawmaterialid = "RAWMATERIALID";

	public static final String Rootlotid = "ROOTLOTID";

	public static final String Parentlotid = "PARENTLOTID";

	public static final String Childlotid = "CHILDLOTID";

	public static final String Carrierid = "CARRIERID";

	public static final String Lotgroupid = "LOTGROUPID";

	public static final String Lottype = "LOTTYPE";

	public static final String Prevlottype = "PREVLOTTYPE";

	public static final String Hassublot = "HASSUBLOT";

	public static final String Productdefid = "PRODUCTDEFID";

	public static final String Productdefversion = "PRODUCTDEFVERSION";

	public static final String Prevproductdefid = "PREVPRODUCTDEFID";

	public static final String Prevproductdefversion = "PREVPRODUCTDEFVERSION";

	public static final String Processdefid = "PROCESSDEFID";

	public static final String Processdefversion = "PROCESSDEFVERSION";

	public static final String Prevprocessdefid = "PREVPROCESSDEFID";

	public static final String Prevprocessdefversion = "PREVPROCESSDEFVERSION";

	public static final String Processpathstack = "PROCESSPATHSTACK";

	public static final String Usersequence = "USERSEQUENCE";

	public static final String Prevusersequence = "PREVUSERSEQUENCE";

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Processsegmentversion = "PROCESSSEGMENTVERSION";

	public static final String Prevprocesssegmentid = "PREVPROCESSSEGMENTID";

	public static final String Prevprocesssegmentversion = "PREVPROCESSSEGMENTVERSION";

	public static final String Productionorderid = "PRODUCTIONORDERID";

	public static final String Workorderid = "WORKORDERID";

	public static final String Priority = "PRIORITY";

	public static final String Duedate = "DUEDATE";

	public static final String Trackinuser = "TRACKINUSER";

	public static final String Trackintime = "TRACKINTIME";

	public static final String Trackoutuser = "TRACKOUTUSER";

	public static final String Trackouttime = "TRACKOUTTIME";

	public static final String Lotstate = "LOTSTATE";

	public static final String Prevlotstate = "PREVLOTSTATE";

	public static final String Processstate = "PROCESSSTATE";

	public static final String Prevprocessstate = "PREVPROCESSSTATE";

	public static final String Ishold = "ISHOLD";

	public static final String Isrework = "ISREWORK";

	public static final String Createdqty = "CREATEDQTY";

	public static final String Qty = "QTY";

	public static final String Prevqty = "PREVQTY";

	public static final String Defectqty = "DEFECTQTY";

	public static final String Prevdefectqty = "PREVDEFECTQTY";

	public static final String Reworkcount = "REWORKCOUNT";

	public static final String Totalreworkcount = "TOTALREWORKCOUNT";

	public static final String Subprocessdefid = "SUBPROCESSDEFID";

	public static final String Subprocessdefversion = "SUBPROCESSDEFVERSION";

	public static final String Starteduser = "STARTEDUSER";

	public static final String Starteddate = "STARTEDDATE";

	public static final String Iscancel = "ISCANCEL";

	public static final String Cancelhistkey = "CANCELHISTKEY";

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

	public static final String Printcount = "PRINTCOUNT";

	public static final String Subpartnumber = "SUBPARTNUMBER";

	public SfLotHistoryData() {
		this(new SfLotHistoryKey()); 
	}

	public SfLotHistoryData(SfLotHistoryKey key) {
		super(key, "SfLotHistory");
	}


	public String getLotname() {
		return this.repository().getString(SfLotHistoryData.Lotname);
	}

	public SfLotHistoryData setLotname(String Lotname) {
		this.repository().set(SfLotHistoryData.Lotname, Lotname);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfLotHistoryData.Enterpriseid);
	}

	public SfLotHistoryData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfLotHistoryData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfLotHistoryData.Plantid);
	}

	public SfLotHistoryData setPlantid(String Plantid) {
		this.repository().set(SfLotHistoryData.Plantid, Plantid);
		return this;
	}

	public String getPrevplantid() {
		return this.repository().getString(SfLotHistoryData.Prevplantid);
	}

	public SfLotHistoryData setPrevplantid(String Prevplantid) {
		this.repository().set(SfLotHistoryData.Prevplantid, Prevplantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfLotHistoryData.Areaid);
	}

	public SfLotHistoryData setAreaid(String Areaid) {
		this.repository().set(SfLotHistoryData.Areaid, Areaid);
		return this;
	}

	public String getPrevareaid() {
		return this.repository().getString(SfLotHistoryData.Prevareaid);
	}

	public SfLotHistoryData setPrevareaid(String Prevareaid) {
		this.repository().set(SfLotHistoryData.Prevareaid, Prevareaid);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(SfLotHistoryData.Equipmentid);
	}

	public SfLotHistoryData setEquipmentid(String Equipmentid) {
		this.repository().set(SfLotHistoryData.Equipmentid, Equipmentid);
		return this;
	}

	public String getPrevequipmentid() {
		return this.repository().getString(SfLotHistoryData.Prevequipmentid);
	}

	public SfLotHistoryData setPrevequipmentid(String Prevequipmentid) {
		this.repository().set(SfLotHistoryData.Prevequipmentid, Prevequipmentid);
		return this;
	}

	public String getLocationid() {
		return this.repository().getString(SfLotHistoryData.Locationid);
	}

	public SfLotHistoryData setLocationid(String Locationid) {
		this.repository().set(SfLotHistoryData.Locationid, Locationid);
		return this;
	}

	public String getRecipedefid() {
		return this.repository().getString(SfLotHistoryData.Recipedefid);
	}

	public SfLotHistoryData setRecipedefid(String Recipedefid) {
		this.repository().set(SfLotHistoryData.Recipedefid, Recipedefid);
		return this;
	}

	public String getRecipedefversion() {
		return this.repository().getString(SfLotHistoryData.Recipedefversion);
	}

	public SfLotHistoryData setRecipedefversion(String Recipedefversion) {
		this.repository().set(SfLotHistoryData.Recipedefversion, Recipedefversion);
		return this;
	}

	public String getOriginalplantid() {
		return this.repository().getString(SfLotHistoryData.Originalplantid);
	}

	public SfLotHistoryData setOriginalplantid(String Originalplantid) {
		this.repository().set(SfLotHistoryData.Originalplantid, Originalplantid);
		return this;
	}

	public String getRawmaterialid() {
		return this.repository().getString(SfLotHistoryData.Rawmaterialid);
	}

	public SfLotHistoryData setRawmaterialid(String Rawmaterialid) {
		this.repository().set(SfLotHistoryData.Rawmaterialid, Rawmaterialid);
		return this;
	}

	public String getRootlotid() {
		return this.repository().getString(SfLotHistoryData.Rootlotid);
	}

	public SfLotHistoryData setRootlotid(String Rootlotid) {
		this.repository().set(SfLotHistoryData.Rootlotid, Rootlotid);
		return this;
	}

	public String getParentlotid() {
		return this.repository().getString(SfLotHistoryData.Parentlotid);
	}

	public SfLotHistoryData setParentlotid(String Parentlotid) {
		this.repository().set(SfLotHistoryData.Parentlotid, Parentlotid);
		return this;
	}

	public String getChildlotid() {
		return this.repository().getString(SfLotHistoryData.Childlotid);
	}

	public SfLotHistoryData setChildlotid(String Childlotid) {
		this.repository().set(SfLotHistoryData.Childlotid, Childlotid);
		return this;
	}

	public String getCarrierid() {
		return this.repository().getString(SfLotHistoryData.Carrierid);
	}

	public SfLotHistoryData setCarrierid(String Carrierid) {
		this.repository().set(SfLotHistoryData.Carrierid, Carrierid);
		return this;
	}

	public String getLotgroupid() {
		return this.repository().getString(SfLotHistoryData.Lotgroupid);
	}

	public SfLotHistoryData setLotgroupid(String Lotgroupid) {
		this.repository().set(SfLotHistoryData.Lotgroupid, Lotgroupid);
		return this;
	}

	public String getLottype() {
		return this.repository().getString(SfLotHistoryData.Lottype);
	}

	public SfLotHistoryData setLottype(String Lottype) {
		this.repository().set(SfLotHistoryData.Lottype, Lottype);
		return this;
	}

	public String getPrevlottype() {
		return this.repository().getString(SfLotHistoryData.Prevlottype);
	}

	public SfLotHistoryData setPrevlottype(String Prevlottype) {
		this.repository().set(SfLotHistoryData.Prevlottype, Prevlottype);
		return this;
	}

	public String getHassublot() {
		return this.repository().getString(SfLotHistoryData.Hassublot);
	}

	public SfLotHistoryData setHassublot(String Hassublot) {
		this.repository().set(SfLotHistoryData.Hassublot, Hassublot);
		return this;
	}

	public String getProductdefid() {
		return this.repository().getString(SfLotHistoryData.Productdefid);
	}

	public SfLotHistoryData setProductdefid(String Productdefid) {
		this.repository().set(SfLotHistoryData.Productdefid, Productdefid);
		return this;
	}

	public String getProductdefversion() {
		return this.repository().getString(SfLotHistoryData.Productdefversion);
	}

	public SfLotHistoryData setProductdefversion(String Productdefversion) {
		this.repository().set(SfLotHistoryData.Productdefversion, Productdefversion);
		return this;
	}

	public String getPrevproductdefid() {
		return this.repository().getString(SfLotHistoryData.Prevproductdefid);
	}

	public SfLotHistoryData setPrevproductdefid(String Prevproductdefid) {
		this.repository().set(SfLotHistoryData.Prevproductdefid, Prevproductdefid);
		return this;
	}

	public String getPrevproductdefversion() {
		return this.repository().getString(SfLotHistoryData.Prevproductdefversion);
	}

	public SfLotHistoryData setPrevproductdefversion(String Prevproductdefversion) {
		this.repository().set(SfLotHistoryData.Prevproductdefversion, Prevproductdefversion);
		return this;
	}

	public String getProcessdefid() {
		return this.repository().getString(SfLotHistoryData.Processdefid);
	}

	public SfLotHistoryData setProcessdefid(String Processdefid) {
		this.repository().set(SfLotHistoryData.Processdefid, Processdefid);
		return this;
	}

	public String getProcessdefversion() {
		return this.repository().getString(SfLotHistoryData.Processdefversion);
	}

	public SfLotHistoryData setProcessdefversion(String Processdefversion) {
		this.repository().set(SfLotHistoryData.Processdefversion, Processdefversion);
		return this;
	}

	public String getPrevprocessdefid() {
		return this.repository().getString(SfLotHistoryData.Prevprocessdefid);
	}

	public SfLotHistoryData setPrevprocessdefid(String Prevprocessdefid) {
		this.repository().set(SfLotHistoryData.Prevprocessdefid, Prevprocessdefid);
		return this;
	}

	public String getPrevprocessdefversion() {
		return this.repository().getString(SfLotHistoryData.Prevprocessdefversion);
	}

	public SfLotHistoryData setPrevprocessdefversion(String Prevprocessdefversion) {
		this.repository().set(SfLotHistoryData.Prevprocessdefversion, Prevprocessdefversion);
		return this;
	}

	public String getProcesspathstack() {
		return this.repository().getString(SfLotHistoryData.Processpathstack);
	}

	public SfLotHistoryData setProcesspathstack(String Processpathstack) {
		this.repository().set(SfLotHistoryData.Processpathstack, Processpathstack);
		return this;
	}

	public String getUsersequence() {
		return this.repository().getString(SfLotHistoryData.Usersequence);
	}

	public SfLotHistoryData setUsersequence(String Usersequence) {
		this.repository().set(SfLotHistoryData.Usersequence, Usersequence);
		return this;
	}

	public String getPrevusersequence() {
		return this.repository().getString(SfLotHistoryData.Prevusersequence);
	}

	public SfLotHistoryData setPrevusersequence(String Prevusersequence) {
		this.repository().set(SfLotHistoryData.Prevusersequence, Prevusersequence);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(SfLotHistoryData.Processsegmentid);
	}

	public SfLotHistoryData setProcesssegmentid(String Processsegmentid) {
		this.repository().set(SfLotHistoryData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getProcesssegmentversion() {
		return this.repository().getString(SfLotHistoryData.Processsegmentversion);
	}

	public SfLotHistoryData setProcesssegmentversion(String Processsegmentversion) {
		this.repository().set(SfLotHistoryData.Processsegmentversion, Processsegmentversion);
		return this;
	}

	public String getPrevprocesssegmentid() {
		return this.repository().getString(SfLotHistoryData.Prevprocesssegmentid);
	}

	public SfLotHistoryData setPrevprocesssegmentid(String Prevprocesssegmentid) {
		this.repository().set(SfLotHistoryData.Prevprocesssegmentid, Prevprocesssegmentid);
		return this;
	}

	public String getPrevprocesssegmentversion() {
		return this.repository().getString(SfLotHistoryData.Prevprocesssegmentversion);
	}

	public SfLotHistoryData setPrevprocesssegmentversion(String Prevprocesssegmentversion) {
		this.repository().set(SfLotHistoryData.Prevprocesssegmentversion, Prevprocesssegmentversion);
		return this;
	}

	public String getProductionorderid() {
		return this.repository().getString(SfLotHistoryData.Productionorderid);
	}

	public SfLotHistoryData setProductionorderid(String Productionorderid) {
		this.repository().set(SfLotHistoryData.Productionorderid, Productionorderid);
		return this;
	}

	public String getWorkorderid() {
		return this.repository().getString(SfLotHistoryData.Workorderid);
	}

	public SfLotHistoryData setWorkorderid(String Workorderid) {
		this.repository().set(SfLotHistoryData.Workorderid, Workorderid);
		return this;
	}

	public Double getPriority() {
		return this.repository().getDouble(SfLotHistoryData.Priority);
	}

	public SfLotHistoryData setPriority(Double Priority) {
		this.repository().set(SfLotHistoryData.Priority, Priority);
		return this;
	}

	public Date getDuedate() {
		return this.repository().getDate(SfLotHistoryData.Duedate);
	}

	public SfLotHistoryData setDuedate(Date Duedate) {
		this.repository().set(SfLotHistoryData.Duedate, Duedate);
		return this;
	}

	public String getTrackinuser() {
		return this.repository().getString(SfLotHistoryData.Trackinuser);
	}

	public SfLotHistoryData setTrackinuser(String Trackinuser) {
		this.repository().set(SfLotHistoryData.Trackinuser, Trackinuser);
		return this;
	}

	public Date getTrackintime() {
		return this.repository().getDate(SfLotHistoryData.Trackintime);
	}

	public SfLotHistoryData setTrackintime(Date Trackintime) {
		this.repository().set(SfLotHistoryData.Trackintime, Trackintime);
		return this;
	}

	public String getTrackoutuser() {
		return this.repository().getString(SfLotHistoryData.Trackoutuser);
	}

	public SfLotHistoryData setTrackoutuser(String Trackoutuser) {
		this.repository().set(SfLotHistoryData.Trackoutuser, Trackoutuser);
		return this;
	}

	public Date getTrackouttime() {
		return this.repository().getDate(SfLotHistoryData.Trackouttime);
	}

	public SfLotHistoryData setTrackouttime(Date Trackouttime) {
		this.repository().set(SfLotHistoryData.Trackouttime, Trackouttime);
		return this;
	}

	public String getLotstate() {
		return this.repository().getString(SfLotHistoryData.Lotstate);
	}

	public SfLotHistoryData setLotstate(String Lotstate) {
		this.repository().set(SfLotHistoryData.Lotstate, Lotstate);
		return this;
	}

	public String getPrevlotstate() {
		return this.repository().getString(SfLotHistoryData.Prevlotstate);
	}

	public SfLotHistoryData setPrevlotstate(String Prevlotstate) {
		this.repository().set(SfLotHistoryData.Prevlotstate, Prevlotstate);
		return this;
	}

	public String getProcessstate() {
		return this.repository().getString(SfLotHistoryData.Processstate);
	}

	public SfLotHistoryData setProcessstate(String Processstate) {
		this.repository().set(SfLotHistoryData.Processstate, Processstate);
		return this;
	}

	public String getPrevprocessstate() {
		return this.repository().getString(SfLotHistoryData.Prevprocessstate);
	}

	public SfLotHistoryData setPrevprocessstate(String Prevprocessstate) {
		this.repository().set(SfLotHistoryData.Prevprocessstate, Prevprocessstate);
		return this;
	}

	public String getIshold() {
		return this.repository().getString(SfLotHistoryData.Ishold);
	}

	public SfLotHistoryData setIshold(String Ishold) {
		this.repository().set(SfLotHistoryData.Ishold, Ishold);
		return this;
	}

	public String getIsrework() {
		return this.repository().getString(SfLotHistoryData.Isrework);
	}

	public SfLotHistoryData setIsrework(String Isrework) {
		this.repository().set(SfLotHistoryData.Isrework, Isrework);
		return this;
	}

	public Double getCreatedqty() {
		return this.repository().getDouble(SfLotHistoryData.Createdqty);
	}

	public SfLotHistoryData setCreatedqty(Double Createdqty) {
		this.repository().set(SfLotHistoryData.Createdqty, Createdqty);
		return this;
	}

	public Double getQty() {
		return this.repository().getDouble(SfLotHistoryData.Qty);
	}

	public SfLotHistoryData setQty(Double Qty) {
		this.repository().set(SfLotHistoryData.Qty, Qty);
		return this;
	}

	public String getPrevqty() {
		return this.repository().getString(SfLotHistoryData.Prevqty);
	}

	public SfLotHistoryData setPrevqty(String Prevqty) {
		this.repository().set(SfLotHistoryData.Prevqty, Prevqty);
		return this;
	}

	public Double getDefectqty() {
		return this.repository().getDouble(SfLotHistoryData.Defectqty);
	}

	public SfLotHistoryData setDefectqty(Double Defectqty) {
		this.repository().set(SfLotHistoryData.Defectqty, Defectqty);
		return this;
	}

	public String getPrevdefectqty() {
		return this.repository().getString(SfLotHistoryData.Prevdefectqty);
	}

	public SfLotHistoryData setPrevdefectqty(String Prevdefectqty) {
		this.repository().set(SfLotHistoryData.Prevdefectqty, Prevdefectqty);
		return this;
	}

	public Double getReworkcount() {
		return this.repository().getDouble(SfLotHistoryData.Reworkcount);
	}

	public SfLotHistoryData setReworkcount(Double Reworkcount) {
		this.repository().set(SfLotHistoryData.Reworkcount, Reworkcount);
		return this;
	}

	public Double getTotalreworkcount() {
		return this.repository().getDouble(SfLotHistoryData.Totalreworkcount);
	}

	public SfLotHistoryData setTotalreworkcount(Double Totalreworkcount) {
		this.repository().set(SfLotHistoryData.Totalreworkcount, Totalreworkcount);
		return this;
	}

	public String getSubprocessdefid() {
		return this.repository().getString(SfLotHistoryData.Subprocessdefid);
	}

	public SfLotHistoryData setSubprocessdefid(String Subprocessdefid) {
		this.repository().set(SfLotHistoryData.Subprocessdefid, Subprocessdefid);
		return this;
	}

	public String getSubprocessdefversion() {
		return this.repository().getString(SfLotHistoryData.Subprocessdefversion);
	}

	public SfLotHistoryData setSubprocessdefversion(String Subprocessdefversion) {
		this.repository().set(SfLotHistoryData.Subprocessdefversion, Subprocessdefversion);
		return this;
	}

	public String getStarteduser() {
		return this.repository().getString(SfLotHistoryData.Starteduser);
	}

	public SfLotHistoryData setStarteduser(String Starteduser) {
		this.repository().set(SfLotHistoryData.Starteduser, Starteduser);
		return this;
	}

	public Date getStarteddate() {
		return this.repository().getDate(SfLotHistoryData.Starteddate);
	}

	public SfLotHistoryData setStarteddate(Date Starteddate) {
		this.repository().set(SfLotHistoryData.Starteddate, Starteddate);
		return this;
	}

	public String getIscancel() {
		return this.repository().getString(SfLotHistoryData.Iscancel);
	}

	public SfLotHistoryData setIscancel(String Iscancel) {
		this.repository().set(SfLotHistoryData.Iscancel, Iscancel);
		return this;
	}

	public String getCancelhistkey() {
		return this.repository().getString(SfLotHistoryData.Cancelhistkey);
	}

	public SfLotHistoryData setCancelhistkey(String Cancelhistkey) {
		this.repository().set(SfLotHistoryData.Cancelhistkey, Cancelhistkey);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfLotHistoryData.Description);
	}

	public SfLotHistoryData setDescription(String Description) {
		this.repository().set(SfLotHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfLotHistoryData.Creator);
	}

	public SfLotHistoryData setCreator(String Creator) {
		this.repository().set(SfLotHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfLotHistoryData.Createdtime);
	}

	public SfLotHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(SfLotHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfLotHistoryData.Modifier);
	}

	public SfLotHistoryData setModifier(String Modifier) {
		this.repository().set(SfLotHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfLotHistoryData.Modifiedtime);
	}

	public SfLotHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfLotHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(SfLotHistoryData.Txnid);
	}

	public SfLotHistoryData setTxnid(String Txnid) {
		this.repository().set(SfLotHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(SfLotHistoryData.Txnuser);
	}

	public SfLotHistoryData setTxnuser(String Txnuser) {
		this.repository().set(SfLotHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(SfLotHistoryData.Txntime);
	}

	public SfLotHistoryData setTxntime(Date Txntime) {
		this.repository().set(SfLotHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(SfLotHistoryData.Txngrouphistkey);
	}

	public SfLotHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(SfLotHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(SfLotHistoryData.Txnreasoncodeclass);
	}

	public SfLotHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(SfLotHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(SfLotHistoryData.Txnreasoncode);
	}

	public SfLotHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(SfLotHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(SfLotHistoryData.Txncomment);
	}

	public SfLotHistoryData setTxncomment(String Txncomment) {
		this.repository().set(SfLotHistoryData.Txncomment, Txncomment);
		return this;
	}

	public Integer getPrintcount() {
		return this.repository().getInteger(SfLotHistoryData.Printcount);
	}

	public SfLotHistoryData setPrintcount(Integer Printcount) {
		this.repository().set(SfLotHistoryData.Printcount, Printcount);
		return this;
	}

	public String getSubpartnumber() {
		return this.repository().getString(SfLotHistoryData.Subpartnumber);
	}

	public SfLotHistoryData setSubpartnumber(String Subpartnumber) {
		this.repository().set(SfLotHistoryData.Subpartnumber, Subpartnumber);
		return this;
	}


}