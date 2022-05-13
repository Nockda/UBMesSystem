package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class SfLotData extends SQLData {

	public static final String Lotid = "LOTID";

	public static final String Lotname = "LOTNAME";

	public static final String Enterpriseid = "ENTERPRISEID";

	public static final String Plantid = "PLANTID";

	public static final String Areaid = "AREAID";

	public static final String Equipmentid = "EQUIPMENTID";

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

	public static final String Hassublot = "HASSUBLOT";

	public static final String Productdefid = "PRODUCTDEFID";

	public static final String Productdefversion = "PRODUCTDEFVERSION";

	public static final String Processdefid = "PROCESSDEFID";

	public static final String Processdefversion = "PROCESSDEFVERSION";

	public static final String Processpathstack = "PROCESSPATHSTACK";

	public static final String Usersequence = "USERSEQUENCE";

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Processsegmentversion = "PROCESSSEGMENTVERSION";

	public static final String Productionorderid = "PRODUCTIONORDERID";

	public static final String Workorderid = "WORKORDERID";

	public static final String Priority = "PRIORITY";

	public static final String Duedate = "DUEDATE";

	public static final String Trackinuser = "TRACKINUSER";

	public static final String Trackintime = "TRACKINTIME";

	public static final String Trackoutuser = "TRACKOUTUSER";

	public static final String Trackouttime = "TRACKOUTTIME";

	public static final String Lotstate = "LOTSTATE";

	public static final String Processstate = "PROCESSSTATE";

	public static final String Ishold = "ISHOLD";

	public static final String Isrework = "ISREWORK";

	public static final String Createdqty = "CREATEDQTY";

	public static final String Qty = "QTY";

	public static final String Defectqty = "DEFECTQTY";

	public static final String Reworkcount = "REWORKCOUNT";

	public static final String Totalreworkcount = "TOTALREWORKCOUNT";

	public static final String Subprocessdefid = "SUBPROCESSDEFID";

	public static final String Subprocessdefversion = "SUBPROCESSDEFVERSION";

	public static final String Starteduser = "STARTEDUSER";

	public static final String Starteddate = "STARTEDDATE";

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

	public static final String Printcount = "PRINTCOUNT";

	public static final String Subpartnumber = "SUBPARTNUMBER";

	public SfLotData() {
		this(new SfLotKey()); 
	}

	public SfLotData(SfLotKey key) {
		super(key, "SfLot");
	}


	public String getLotname() {
		return this.repository().getString(SfLotData.Lotname);
	}

	public SfLotData setLotname(String Lotname) {
		this.repository().set(SfLotData.Lotname, Lotname);
		return this;
	}

	public String getEnterpriseid() {
		return this.repository().getString(SfLotData.Enterpriseid);
	}

	public SfLotData setEnterpriseid(String Enterpriseid) {
		this.repository().set(SfLotData.Enterpriseid, Enterpriseid);
		return this;
	}

	public String getPlantid() {
		return this.repository().getString(SfLotData.Plantid);
	}

	public SfLotData setPlantid(String Plantid) {
		this.repository().set(SfLotData.Plantid, Plantid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(SfLotData.Areaid);
	}

	public SfLotData setAreaid(String Areaid) {
		this.repository().set(SfLotData.Areaid, Areaid);
		return this;
	}

	public String getEquipmentid() {
		return this.repository().getString(SfLotData.Equipmentid);
	}

	public SfLotData setEquipmentid(String Equipmentid) {
		this.repository().set(SfLotData.Equipmentid, Equipmentid);
		return this;
	}

	public String getLocationid() {
		return this.repository().getString(SfLotData.Locationid);
	}

	public SfLotData setLocationid(String Locationid) {
		this.repository().set(SfLotData.Locationid, Locationid);
		return this;
	}

	public String getRecipedefid() {
		return this.repository().getString(SfLotData.Recipedefid);
	}

	public SfLotData setRecipedefid(String Recipedefid) {
		this.repository().set(SfLotData.Recipedefid, Recipedefid);
		return this;
	}

	public String getRecipedefversion() {
		return this.repository().getString(SfLotData.Recipedefversion);
	}

	public SfLotData setRecipedefversion(String Recipedefversion) {
		this.repository().set(SfLotData.Recipedefversion, Recipedefversion);
		return this;
	}

	public String getOriginalplantid() {
		return this.repository().getString(SfLotData.Originalplantid);
	}

	public SfLotData setOriginalplantid(String Originalplantid) {
		this.repository().set(SfLotData.Originalplantid, Originalplantid);
		return this;
	}

	public String getRawmaterialid() {
		return this.repository().getString(SfLotData.Rawmaterialid);
	}

	public SfLotData setRawmaterialid(String Rawmaterialid) {
		this.repository().set(SfLotData.Rawmaterialid, Rawmaterialid);
		return this;
	}

	public String getRootlotid() {
		return this.repository().getString(SfLotData.Rootlotid);
	}

	public SfLotData setRootlotid(String Rootlotid) {
		this.repository().set(SfLotData.Rootlotid, Rootlotid);
		return this;
	}

	public String getParentlotid() {
		return this.repository().getString(SfLotData.Parentlotid);
	}

	public SfLotData setParentlotid(String Parentlotid) {
		this.repository().set(SfLotData.Parentlotid, Parentlotid);
		return this;
	}

	public String getChildlotid() {
		return this.repository().getString(SfLotData.Childlotid);
	}

	public SfLotData setChildlotid(String Childlotid) {
		this.repository().set(SfLotData.Childlotid, Childlotid);
		return this;
	}

	public String getCarrierid() {
		return this.repository().getString(SfLotData.Carrierid);
	}

	public SfLotData setCarrierid(String Carrierid) {
		this.repository().set(SfLotData.Carrierid, Carrierid);
		return this;
	}

	public String getLotgroupid() {
		return this.repository().getString(SfLotData.Lotgroupid);
	}

	public SfLotData setLotgroupid(String Lotgroupid) {
		this.repository().set(SfLotData.Lotgroupid, Lotgroupid);
		return this;
	}

	public String getLottype() {
		return this.repository().getString(SfLotData.Lottype);
	}

	public SfLotData setLottype(String Lottype) {
		this.repository().set(SfLotData.Lottype, Lottype);
		return this;
	}

	public String getHassublot() {
		return this.repository().getString(SfLotData.Hassublot);
	}

	public SfLotData setHassublot(String Hassublot) {
		this.repository().set(SfLotData.Hassublot, Hassublot);
		return this;
	}

	public String getProductdefid() {
		return this.repository().getString(SfLotData.Productdefid);
	}

	public SfLotData setProductdefid(String Productdefid) {
		this.repository().set(SfLotData.Productdefid, Productdefid);
		return this;
	}

	public String getProductdefversion() {
		return this.repository().getString(SfLotData.Productdefversion);
	}

	public SfLotData setProductdefversion(String Productdefversion) {
		this.repository().set(SfLotData.Productdefversion, Productdefversion);
		return this;
	}

	public String getProcessdefid() {
		return this.repository().getString(SfLotData.Processdefid);
	}

	public SfLotData setProcessdefid(String Processdefid) {
		this.repository().set(SfLotData.Processdefid, Processdefid);
		return this;
	}

	public String getProcessdefversion() {
		return this.repository().getString(SfLotData.Processdefversion);
	}

	public SfLotData setProcessdefversion(String Processdefversion) {
		this.repository().set(SfLotData.Processdefversion, Processdefversion);
		return this;
	}

	public String getProcesspathstack() {
		return this.repository().getString(SfLotData.Processpathstack);
	}

	public SfLotData setProcesspathstack(String Processpathstack) {
		this.repository().set(SfLotData.Processpathstack, Processpathstack);
		return this;
	}

	public String getUsersequence() {
		return this.repository().getString(SfLotData.Usersequence);
	}

	public SfLotData setUsersequence(String Usersequence) {
		this.repository().set(SfLotData.Usersequence, Usersequence);
		return this;
	}

	public String getProcesssegmentid() {
		return this.repository().getString(SfLotData.Processsegmentid);
	}

	public SfLotData setProcesssegmentid(String Processsegmentid) {
		this.repository().set(SfLotData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getProcesssegmentversion() {
		return this.repository().getString(SfLotData.Processsegmentversion);
	}

	public SfLotData setProcesssegmentversion(String Processsegmentversion) {
		this.repository().set(SfLotData.Processsegmentversion, Processsegmentversion);
		return this;
	}

	public String getProductionorderid() {
		return this.repository().getString(SfLotData.Productionorderid);
	}

	public SfLotData setProductionorderid(String Productionorderid) {
		this.repository().set(SfLotData.Productionorderid, Productionorderid);
		return this;
	}

	public String getWorkorderid() {
		return this.repository().getString(SfLotData.Workorderid);
	}

	public SfLotData setWorkorderid(String Workorderid) {
		this.repository().set(SfLotData.Workorderid, Workorderid);
		return this;
	}

	public Double getPriority() {
		return this.repository().getDouble(SfLotData.Priority);
	}

	public SfLotData setPriority(Double Priority) {
		this.repository().set(SfLotData.Priority, Priority);
		return this;
	}

	public Date getDuedate() {
		return this.repository().getDate(SfLotData.Duedate);
	}

	public SfLotData setDuedate(Date Duedate) {
		this.repository().set(SfLotData.Duedate, Duedate);
		return this;
	}

	public String getTrackinuser() {
		return this.repository().getString(SfLotData.Trackinuser);
	}

	public SfLotData setTrackinuser(String Trackinuser) {
		this.repository().set(SfLotData.Trackinuser, Trackinuser);
		return this;
	}

	public Date getTrackintime() {
		return this.repository().getDate(SfLotData.Trackintime);
	}

	public SfLotData setTrackintime(Date Trackintime) {
		this.repository().set(SfLotData.Trackintime, Trackintime);
		return this;
	}

	public String getTrackoutuser() {
		return this.repository().getString(SfLotData.Trackoutuser);
	}

	public SfLotData setTrackoutuser(String Trackoutuser) {
		this.repository().set(SfLotData.Trackoutuser, Trackoutuser);
		return this;
	}

	public Date getTrackouttime() {
		return this.repository().getDate(SfLotData.Trackouttime);
	}

	public SfLotData setTrackouttime(Date Trackouttime) {
		this.repository().set(SfLotData.Trackouttime, Trackouttime);
		return this;
	}

	public String getLotstate() {
		return this.repository().getString(SfLotData.Lotstate);
	}

	public SfLotData setLotstate(String Lotstate) {
		this.repository().set(SfLotData.Lotstate, Lotstate);
		return this;
	}

	public String getProcessstate() {
		return this.repository().getString(SfLotData.Processstate);
	}

	public SfLotData setProcessstate(String Processstate) {
		this.repository().set(SfLotData.Processstate, Processstate);
		return this;
	}

	public String getIshold() {
		return this.repository().getString(SfLotData.Ishold);
	}

	public SfLotData setIshold(String Ishold) {
		this.repository().set(SfLotData.Ishold, Ishold);
		return this;
	}

	public String getIsrework() {
		return this.repository().getString(SfLotData.Isrework);
	}

	public SfLotData setIsrework(String Isrework) {
		this.repository().set(SfLotData.Isrework, Isrework);
		return this;
	}

	public Double getCreatedqty() {
		return this.repository().getDouble(SfLotData.Createdqty);
	}

	public SfLotData setCreatedqty(Double Createdqty) {
		this.repository().set(SfLotData.Createdqty, Createdqty);
		return this;
	}

	public Double getQty() {
		return this.repository().getDouble(SfLotData.Qty);
	}

	public SfLotData setQty(Double Qty) {
		this.repository().set(SfLotData.Qty, Qty);
		return this;
	}

	public Double getDefectqty() {
		return this.repository().getDouble(SfLotData.Defectqty);
	}

	public SfLotData setDefectqty(Double Defectqty) {
		this.repository().set(SfLotData.Defectqty, Defectqty);
		return this;
	}

	public Double getReworkcount() {
		return this.repository().getDouble(SfLotData.Reworkcount);
	}

	public SfLotData setReworkcount(Double Reworkcount) {
		this.repository().set(SfLotData.Reworkcount, Reworkcount);
		return this;
	}

	public Double getTotalreworkcount() {
		return this.repository().getDouble(SfLotData.Totalreworkcount);
	}

	public SfLotData setTotalreworkcount(Double Totalreworkcount) {
		this.repository().set(SfLotData.Totalreworkcount, Totalreworkcount);
		return this;
	}

	public String getSubprocessdefid() {
		return this.repository().getString(SfLotData.Subprocessdefid);
	}

	public SfLotData setSubprocessdefid(String Subprocessdefid) {
		this.repository().set(SfLotData.Subprocessdefid, Subprocessdefid);
		return this;
	}

	public String getSubprocessdefversion() {
		return this.repository().getString(SfLotData.Subprocessdefversion);
	}

	public SfLotData setSubprocessdefversion(String Subprocessdefversion) {
		this.repository().set(SfLotData.Subprocessdefversion, Subprocessdefversion);
		return this;
	}

	public String getStarteduser() {
		return this.repository().getString(SfLotData.Starteduser);
	}

	public SfLotData setStarteduser(String Starteduser) {
		this.repository().set(SfLotData.Starteduser, Starteduser);
		return this;
	}

	public Date getStarteddate() {
		return this.repository().getDate(SfLotData.Starteddate);
	}

	public SfLotData setStarteddate(Date Starteddate) {
		this.repository().set(SfLotData.Starteddate, Starteddate);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(SfLotData.Description);
	}

	public SfLotData setDescription(String Description) {
		this.repository().set(SfLotData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(SfLotData.Creator);
	}

	public SfLotData setCreator(String Creator) {
		this.repository().set(SfLotData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(SfLotData.Createdtime);
	}

	public SfLotData setCreatedtime(Date Createdtime) {
		this.repository().set(SfLotData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(SfLotData.Modifier);
	}

	public SfLotData setModifier(String Modifier) {
		this.repository().set(SfLotData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(SfLotData.Modifiedtime);
	}

	public SfLotData setModifiedtime(Date Modifiedtime) {
		this.repository().set(SfLotData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(SfLotData.Lasttxnhistkey);
	}

	public SfLotData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(SfLotData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(SfLotData.Lasttxnid);
	}

	public SfLotData setLasttxnid(String Lasttxnid) {
		this.repository().set(SfLotData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(SfLotData.Lasttxnuser);
	}

	public SfLotData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(SfLotData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(SfLotData.Lasttxntime);
	}

	public SfLotData setLasttxntime(Date Lasttxntime) {
		this.repository().set(SfLotData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(SfLotData.Lasttxncomment);
	}

	public SfLotData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(SfLotData.Lasttxncomment, Lasttxncomment);
		return this;
	}

	public Integer getPrintcount() {
		return this.repository().getInteger(SfLotData.Printcount);
	}

	public SfLotData setPrintcount(Integer Printcount) {
		this.repository().set(SfLotData.Printcount, Printcount);
		return this;
	}

	public String getSubpartnumber() {
		return this.repository().getString(SfLotData.Subpartnumber);
	}

	public SfLotData setSubpartnumber(String Subpartnumber) {
		this.repository().set(SfLotData.Subpartnumber, Subpartnumber);
		return this;
	}


}