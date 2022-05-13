package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtOutgoinginspectionData extends SQLData {

	public static final String Lotid = "LOTID";

	public static final String Processsegmentid = "PROCESSSEGMENTID";

	public static final String Inspectiondegree = "INSPECTIONDEGREE";

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

	public static final String Lasttxnhistkey = "LASTTXNHISTKEY";

	public static final String Lasttxnid = "LASTTXNID";

	public static final String Lasttxnuser = "LASTTXNUSER";

	public static final String Lasttxntime = "LASTTXNTIME";

	public static final String Lasttxncomment = "LASTTXNCOMMENT";

	public CtOutgoinginspectionData() {
		this(new CtOutgoinginspectionKey()); 
	}

	public CtOutgoinginspectionData(CtOutgoinginspectionKey key) {
		super(key, "CtOutgoinginspection");
	}


	public String getInspector() {
		return this.repository().getString(CtOutgoinginspectionData.Inspector);
	}

	public CtOutgoinginspectionData setInspector(String Inspector) {
		this.repository().set(CtOutgoinginspectionData.Inspector, Inspector);
		return this;
	}

	public String getInspector2() {
		return this.repository().getString(CtOutgoinginspectionData.Inspector2);
	}

	public CtOutgoinginspectionData setInspector2(String Inspector2) {
		this.repository().set(CtOutgoinginspectionData.Inspector2, Inspector2);
		return this;
	}

	public Date getInspectiondate() {
		return this.repository().getDate(CtOutgoinginspectionData.Inspectiondate);
	}

	public CtOutgoinginspectionData setInspectiondate(Date Inspectiondate) {
		this.repository().set(CtOutgoinginspectionData.Inspectiondate, Inspectiondate);
		return this;
	}

	public String getValue1() {
		return this.repository().getString(CtOutgoinginspectionData.Value1);
	}

	public CtOutgoinginspectionData setValue1(String Value1) {
		this.repository().set(CtOutgoinginspectionData.Value1, Value1);
		return this;
	}

	public String getValue2() {
		return this.repository().getString(CtOutgoinginspectionData.Value2);
	}

	public CtOutgoinginspectionData setValue2(String Value2) {
		this.repository().set(CtOutgoinginspectionData.Value2, Value2);
		return this;
	}

	public String getValue3() {
		return this.repository().getString(CtOutgoinginspectionData.Value3);
	}

	public CtOutgoinginspectionData setValue3(String Value3) {
		this.repository().set(CtOutgoinginspectionData.Value3, Value3);
		return this;
	}

	public String getValue4() {
		return this.repository().getString(CtOutgoinginspectionData.Value4);
	}

	public CtOutgoinginspectionData setValue4(String Value4) {
		this.repository().set(CtOutgoinginspectionData.Value4, Value4);
		return this;
	}

	public String getValue5() {
		return this.repository().getString(CtOutgoinginspectionData.Value5);
	}

	public CtOutgoinginspectionData setValue5(String Value5) {
		this.repository().set(CtOutgoinginspectionData.Value5, Value5);
		return this;
	}

	public String getValue6() {
		return this.repository().getString(CtOutgoinginspectionData.Value6);
	}

	public CtOutgoinginspectionData setValue6(String Value6) {
		this.repository().set(CtOutgoinginspectionData.Value6, Value6);
		return this;
	}

	public String getValue7() {
		return this.repository().getString(CtOutgoinginspectionData.Value7);
	}

	public CtOutgoinginspectionData setValue7(String Value7) {
		this.repository().set(CtOutgoinginspectionData.Value7, Value7);
		return this;
	}

	public String getValue8() {
		return this.repository().getString(CtOutgoinginspectionData.Value8);
	}

	public CtOutgoinginspectionData setValue8(String Value8) {
		this.repository().set(CtOutgoinginspectionData.Value8, Value8);
		return this;
	}

	public String getValue9() {
		return this.repository().getString(CtOutgoinginspectionData.Value9);
	}

	public CtOutgoinginspectionData setValue9(String Value9) {
		this.repository().set(CtOutgoinginspectionData.Value9, Value9);
		return this;
	}

	public String getValue10() {
		return this.repository().getString(CtOutgoinginspectionData.Value10);
	}

	public CtOutgoinginspectionData setValue10(String Value10) {
		this.repository().set(CtOutgoinginspectionData.Value10, Value10);
		return this;
	}

	public String getValue11() {
		return this.repository().getString(CtOutgoinginspectionData.Value11);
	}

	public CtOutgoinginspectionData setValue11(String Value11) {
		this.repository().set(CtOutgoinginspectionData.Value11, Value11);
		return this;
	}

	public String getValue12() {
		return this.repository().getString(CtOutgoinginspectionData.Value12);
	}

	public CtOutgoinginspectionData setValue12(String Value12) {
		this.repository().set(CtOutgoinginspectionData.Value12, Value12);
		return this;
	}

	public String getValue13() {
		return this.repository().getString(CtOutgoinginspectionData.Value13);
	}

	public CtOutgoinginspectionData setValue13(String Value13) {
		this.repository().set(CtOutgoinginspectionData.Value13, Value13);
		return this;
	}

	public String getValue14() {
		return this.repository().getString(CtOutgoinginspectionData.Value14);
	}

	public CtOutgoinginspectionData setValue14(String Value14) {
		this.repository().set(CtOutgoinginspectionData.Value14, Value14);
		return this;
	}

	public String getValue15() {
		return this.repository().getString(CtOutgoinginspectionData.Value15);
	}

	public CtOutgoinginspectionData setValue15(String Value15) {
		this.repository().set(CtOutgoinginspectionData.Value15, Value15);
		return this;
	}

	public String getValue16() {
		return this.repository().getString(CtOutgoinginspectionData.Value16);
	}

	public CtOutgoinginspectionData setValue16(String Value16) {
		this.repository().set(CtOutgoinginspectionData.Value16, Value16);
		return this;
	}

	public String getValue17() {
		return this.repository().getString(CtOutgoinginspectionData.Value17);
	}

	public CtOutgoinginspectionData setValue17(String Value17) {
		this.repository().set(CtOutgoinginspectionData.Value17, Value17);
		return this;
	}

	public String getValue18() {
		return this.repository().getString(CtOutgoinginspectionData.Value18);
	}

	public CtOutgoinginspectionData setValue18(String Value18) {
		this.repository().set(CtOutgoinginspectionData.Value18, Value18);
		return this;
	}

	public String getValue19() {
		return this.repository().getString(CtOutgoinginspectionData.Value19);
	}

	public CtOutgoinginspectionData setValue19(String Value19) {
		this.repository().set(CtOutgoinginspectionData.Value19, Value19);
		return this;
	}

	public String getValue20() {
		return this.repository().getString(CtOutgoinginspectionData.Value20);
	}

	public CtOutgoinginspectionData setValue20(String Value20) {
		this.repository().set(CtOutgoinginspectionData.Value20, Value20);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtOutgoinginspectionData.Description);
	}

	public CtOutgoinginspectionData setDescription(String Description) {
		this.repository().set(CtOutgoinginspectionData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtOutgoinginspectionData.Creator);
	}

	public CtOutgoinginspectionData setCreator(String Creator) {
		this.repository().set(CtOutgoinginspectionData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtOutgoinginspectionData.Createdtime);
	}

	public CtOutgoinginspectionData setCreatedtime(Date Createdtime) {
		this.repository().set(CtOutgoinginspectionData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtOutgoinginspectionData.Modifier);
	}

	public CtOutgoinginspectionData setModifier(String Modifier) {
		this.repository().set(CtOutgoinginspectionData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtOutgoinginspectionData.Modifiedtime);
	}

	public CtOutgoinginspectionData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtOutgoinginspectionData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtOutgoinginspectionData.Lasttxnhistkey);
	}

	public CtOutgoinginspectionData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtOutgoinginspectionData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtOutgoinginspectionData.Lasttxnid);
	}

	public CtOutgoinginspectionData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtOutgoinginspectionData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtOutgoinginspectionData.Lasttxnuser);
	}

	public CtOutgoinginspectionData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtOutgoinginspectionData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtOutgoinginspectionData.Lasttxntime);
	}

	public CtOutgoinginspectionData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtOutgoinginspectionData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtOutgoinginspectionData.Lasttxncomment);
	}

	public CtOutgoinginspectionData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtOutgoinginspectionData.Lasttxncomment, Lasttxncomment);
		return this;
	}


}