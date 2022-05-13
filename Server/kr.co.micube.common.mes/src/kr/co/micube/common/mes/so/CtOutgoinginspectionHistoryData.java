package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtOutgoinginspectionHistoryData extends SQLData {

	public static final String Lotid = "LOTID";

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Inspectiondegree = "INSPECTIONDEGREE";

	public static final String Txnhistkey = "TXNHISTKEY";

	public static final String Inspector = "INSPECTOR";

	public static final String Inspector2 = "INSPECTOR2";

	public static final String Inspectiondate = "INSPECTIONDATE";

	public static final String Value1 = "VALUE1";

	public static final String Value2 = "VALUE2";

	public static final String Value3 = "VALUE3";

	public static final String Value4 = "VALUE4";

	public static final String Value5 = "VALUE5";

	public static final String Value6 = "VALUE6";

	public static final String Value7 = "VALUE7";

	public static final String Value8 = "VALUE8";

	public static final String Value9 = "VALUE9";

	public static final String Value10 = "VALUE10";

	public static final String Value11 = "VALUE11";

	public static final String Value12 = "VALUE12";

	public static final String Value13 = "VALUE13";

	public static final String Value14 = "VALUE14";

	public static final String Value15 = "VALUE15";

	public static final String Value16 = "VALUE16";

	public static final String Value17 = "VALUE17";

	public static final String Value18 = "VALUE18";

	public static final String Value19 = "VALUE19";

	public static final String Value20 = "VALUE20";

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

	public CtOutgoinginspectionHistoryData() {
		this(new CtOutgoinginspectionHistoryKey()); 
	}

	public CtOutgoinginspectionHistoryData(CtOutgoinginspectionHistoryKey key) {
		super(key, "CtOutgoinginspectionHistory");
	}


	public String getInspector() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Inspector);
	}

	public CtOutgoinginspectionHistoryData setInspector(String Inspector) {
		this.repository().set(CtOutgoinginspectionHistoryData.Inspector, Inspector);
		return this;
	}

	public String getInspector2() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Inspector2);
	}

	public CtOutgoinginspectionHistoryData setInspector2(String Inspector2) {
		this.repository().set(CtOutgoinginspectionHistoryData.Inspector2, Inspector2);
		return this;
	}

	public Date getInspectiondate() {
		return this.repository().getDate(CtOutgoinginspectionHistoryData.Inspectiondate);
	}

	public CtOutgoinginspectionHistoryData setInspectiondate(Date Inspectiondate) {
		this.repository().set(CtOutgoinginspectionHistoryData.Inspectiondate, Inspectiondate);
		return this;
	}

	public String getValue1() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value1);
	}

	public CtOutgoinginspectionHistoryData setValue1(String Value1) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value1, Value1);
		return this;
	}

	public String getValue2() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value2);
	}

	public CtOutgoinginspectionHistoryData setValue2(String Value2) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value2, Value2);
		return this;
	}

	public String getValue3() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value3);
	}

	public CtOutgoinginspectionHistoryData setValue3(String Value3) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value3, Value3);
		return this;
	}

	public String getValue4() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value4);
	}

	public CtOutgoinginspectionHistoryData setValue4(String Value4) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value4, Value4);
		return this;
	}

	public String getValue5() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value5);
	}

	public CtOutgoinginspectionHistoryData setValue5(String Value5) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value5, Value5);
		return this;
	}

	public String getValue6() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value6);
	}

	public CtOutgoinginspectionHistoryData setValue6(String Value6) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value6, Value6);
		return this;
	}

	public String getValue7() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value7);
	}

	public CtOutgoinginspectionHistoryData setValue7(String Value7) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value7, Value7);
		return this;
	}

	public String getValue8() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value8);
	}

	public CtOutgoinginspectionHistoryData setValue8(String Value8) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value8, Value8);
		return this;
	}

	public String getValue9() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value9);
	}

	public CtOutgoinginspectionHistoryData setValue9(String Value9) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value9, Value9);
		return this;
	}

	public String getValue10() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value10);
	}

	public CtOutgoinginspectionHistoryData setValue10(String Value10) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value10, Value10);
		return this;
	}

	public String getValue11() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value11);
	}

	public CtOutgoinginspectionHistoryData setValue11(String Value11) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value11, Value11);
		return this;
	}

	public String getValue12() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value12);
	}

	public CtOutgoinginspectionHistoryData setValue12(String Value12) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value12, Value12);
		return this;
	}

	public String getValue13() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value13);
	}

	public CtOutgoinginspectionHistoryData setValue13(String Value13) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value13, Value13);
		return this;
	}

	public String getValue14() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value14);
	}

	public CtOutgoinginspectionHistoryData setValue14(String Value14) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value14, Value14);
		return this;
	}

	public String getValue15() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value15);
	}

	public CtOutgoinginspectionHistoryData setValue15(String Value15) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value15, Value15);
		return this;
	}

	public String getValue16() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value16);
	}

	public CtOutgoinginspectionHistoryData setValue16(String Value16) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value16, Value16);
		return this;
	}

	public String getValue17() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value17);
	}

	public CtOutgoinginspectionHistoryData setValue17(String Value17) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value17, Value17);
		return this;
	}

	public String getValue18() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value18);
	}

	public CtOutgoinginspectionHistoryData setValue18(String Value18) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value18, Value18);
		return this;
	}

	public String getValue19() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value19);
	}

	public CtOutgoinginspectionHistoryData setValue19(String Value19) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value19, Value19);
		return this;
	}

	public String getValue20() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Value20);
	}

	public CtOutgoinginspectionHistoryData setValue20(String Value20) {
		this.repository().set(CtOutgoinginspectionHistoryData.Value20, Value20);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Description);
	}

	public CtOutgoinginspectionHistoryData setDescription(String Description) {
		this.repository().set(CtOutgoinginspectionHistoryData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Creator);
	}

	public CtOutgoinginspectionHistoryData setCreator(String Creator) {
		this.repository().set(CtOutgoinginspectionHistoryData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtOutgoinginspectionHistoryData.Createdtime);
	}

	public CtOutgoinginspectionHistoryData setCreatedtime(Date Createdtime) {
		this.repository().set(CtOutgoinginspectionHistoryData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Modifier);
	}

	public CtOutgoinginspectionHistoryData setModifier(String Modifier) {
		this.repository().set(CtOutgoinginspectionHistoryData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtOutgoinginspectionHistoryData.Modifiedtime);
	}

	public CtOutgoinginspectionHistoryData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtOutgoinginspectionHistoryData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getTxnid() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Txnid);
	}

	public CtOutgoinginspectionHistoryData setTxnid(String Txnid) {
		this.repository().set(CtOutgoinginspectionHistoryData.Txnid, Txnid);
		return this;
	}

	public String getTxnuser() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Txnuser);
	}

	public CtOutgoinginspectionHistoryData setTxnuser(String Txnuser) {
		this.repository().set(CtOutgoinginspectionHistoryData.Txnuser, Txnuser);
		return this;
	}

	public Date getTxntime() {
		return this.repository().getDate(CtOutgoinginspectionHistoryData.Txntime);
	}

	public CtOutgoinginspectionHistoryData setTxntime(Date Txntime) {
		this.repository().set(CtOutgoinginspectionHistoryData.Txntime, Txntime);
		return this;
	}

	public String getTxngrouphistkey() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Txngrouphistkey);
	}

	public CtOutgoinginspectionHistoryData setTxngrouphistkey(String Txngrouphistkey) {
		this.repository().set(CtOutgoinginspectionHistoryData.Txngrouphistkey, Txngrouphistkey);
		return this;
	}

	public String getTxnreasoncodeclass() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Txnreasoncodeclass);
	}

	public CtOutgoinginspectionHistoryData setTxnreasoncodeclass(String Txnreasoncodeclass) {
		this.repository().set(CtOutgoinginspectionHistoryData.Txnreasoncodeclass, Txnreasoncodeclass);
		return this;
	}

	public String getTxnreasoncode() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Txnreasoncode);
	}

	public CtOutgoinginspectionHistoryData setTxnreasoncode(String Txnreasoncode) {
		this.repository().set(CtOutgoinginspectionHistoryData.Txnreasoncode, Txnreasoncode);
		return this;
	}

	public String getTxncomment() {
		return this.repository().getString(CtOutgoinginspectionHistoryData.Txncomment);
	}

	public CtOutgoinginspectionHistoryData setTxncomment(String Txncomment) {
		this.repository().set(CtOutgoinginspectionHistoryData.Txncomment, Txncomment);
		return this;
	}


}