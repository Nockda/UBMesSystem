package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.core.sql.exception.DatabaseException;

import kr.co.micube.tool.so.support.SQLData;

@SuppressWarnings("unused")
public class CtReceivinginspectionitemresultData extends SQLData {

	public static final String Consumabledefid = "CONSUMABLEDEFID";

	public static final String Deliveryno = "DELIVERYNO";

	public static final String Deliveryserialno = "DELIVERYSERIALNO";

	public static final String Deliverysequence = "DELIVERYSEQUENCE";

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

	public static final String Resultcode = "RESULTCODE";

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

	public CtReceivinginspectionitemresultData() {
		this(new CtReceivinginspectionitemresultKey()); 
	}

	public CtReceivinginspectionitemresultData(CtReceivinginspectionitemresultKey key) {
		super(key, "CtReceivinginspectionitemresult");
	}


	public String getValue1() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value1);
	}

	public CtReceivinginspectionitemresultData setValue1(String Value1) {
		this.repository().set(CtReceivinginspectionitemresultData.Value1, Value1);
		return this;
	}

	public String getValue2() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value2);
	}

	public CtReceivinginspectionitemresultData setValue2(String Value2) {
		this.repository().set(CtReceivinginspectionitemresultData.Value2, Value2);
		return this;
	}

	public String getValue3() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value3);
	}

	public CtReceivinginspectionitemresultData setValue3(String Value3) {
		this.repository().set(CtReceivinginspectionitemresultData.Value3, Value3);
		return this;
	}

	public String getValue4() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value4);
	}

	public CtReceivinginspectionitemresultData setValue4(String Value4) {
		this.repository().set(CtReceivinginspectionitemresultData.Value4, Value4);
		return this;
	}

	public String getValue5() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value5);
	}

	public CtReceivinginspectionitemresultData setValue5(String Value5) {
		this.repository().set(CtReceivinginspectionitemresultData.Value5, Value5);
		return this;
	}

	public String getValue6() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value6);
	}

	public CtReceivinginspectionitemresultData setValue6(String Value6) {
		this.repository().set(CtReceivinginspectionitemresultData.Value6, Value6);
		return this;
	}

	public String getValue7() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value7);
	}

	public CtReceivinginspectionitemresultData setValue7(String Value7) {
		this.repository().set(CtReceivinginspectionitemresultData.Value7, Value7);
		return this;
	}

	public String getValue8() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value8);
	}

	public CtReceivinginspectionitemresultData setValue8(String Value8) {
		this.repository().set(CtReceivinginspectionitemresultData.Value8, Value8);
		return this;
	}

	public String getValue9() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value9);
	}

	public CtReceivinginspectionitemresultData setValue9(String Value9) {
		this.repository().set(CtReceivinginspectionitemresultData.Value9, Value9);
		return this;
	}

	public String getValue10() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value10);
	}

	public CtReceivinginspectionitemresultData setValue10(String Value10) {
		this.repository().set(CtReceivinginspectionitemresultData.Value10, Value10);
		return this;
	}

	public String getValue11() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value11);
	}

	public CtReceivinginspectionitemresultData setValue11(String Value11) {
		this.repository().set(CtReceivinginspectionitemresultData.Value11, Value11);
		return this;
	}

	public String getValue12() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value12);
	}

	public CtReceivinginspectionitemresultData setValue12(String Value12) {
		this.repository().set(CtReceivinginspectionitemresultData.Value12, Value12);
		return this;
	}

	public String getValue13() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value13);
	}

	public CtReceivinginspectionitemresultData setValue13(String Value13) {
		this.repository().set(CtReceivinginspectionitemresultData.Value13, Value13);
		return this;
	}

	public String getValue14() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value14);
	}

	public CtReceivinginspectionitemresultData setValue14(String Value14) {
		this.repository().set(CtReceivinginspectionitemresultData.Value14, Value14);
		return this;
	}

	public String getValue15() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value15);
	}

	public CtReceivinginspectionitemresultData setValue15(String Value15) {
		this.repository().set(CtReceivinginspectionitemresultData.Value15, Value15);
		return this;
	}

	public String getValue16() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value16);
	}

	public CtReceivinginspectionitemresultData setValue16(String Value16) {
		this.repository().set(CtReceivinginspectionitemresultData.Value16, Value16);
		return this;
	}

	public String getValue17() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value17);
	}

	public CtReceivinginspectionitemresultData setValue17(String Value17) {
		this.repository().set(CtReceivinginspectionitemresultData.Value17, Value17);
		return this;
	}

	public String getValue18() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value18);
	}

	public CtReceivinginspectionitemresultData setValue18(String Value18) {
		this.repository().set(CtReceivinginspectionitemresultData.Value18, Value18);
		return this;
	}

	public String getValue19() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value19);
	}

	public CtReceivinginspectionitemresultData setValue19(String Value19) {
		this.repository().set(CtReceivinginspectionitemresultData.Value19, Value19);
		return this;
	}

	public String getValue20() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Value20);
	}

	public CtReceivinginspectionitemresultData setValue20(String Value20) {
		this.repository().set(CtReceivinginspectionitemresultData.Value20, Value20);
		return this;
	}

	public String getResultcode() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Resultcode);
	}

	public CtReceivinginspectionitemresultData setResultcode(String Resultcode) {
		this.repository().set(CtReceivinginspectionitemresultData.Resultcode, Resultcode);
		return this;
	}

	public String getDescription() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Description);
	}

	public CtReceivinginspectionitemresultData setDescription(String Description) {
		this.repository().set(CtReceivinginspectionitemresultData.Description, Description);
		return this;
	}

	public String getCreator() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Creator);
	}

	public CtReceivinginspectionitemresultData setCreator(String Creator) {
		this.repository().set(CtReceivinginspectionitemresultData.Creator, Creator);
		return this;
	}

	public Date getCreatedtime() {
		return this.repository().getDate(CtReceivinginspectionitemresultData.Createdtime);
	}

	public CtReceivinginspectionitemresultData setCreatedtime(Date Createdtime) {
		this.repository().set(CtReceivinginspectionitemresultData.Createdtime, Createdtime);
		return this;
	}

	public String getModifier() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Modifier);
	}

	public CtReceivinginspectionitemresultData setModifier(String Modifier) {
		this.repository().set(CtReceivinginspectionitemresultData.Modifier, Modifier);
		return this;
	}

	public Date getModifiedtime() {
		return this.repository().getDate(CtReceivinginspectionitemresultData.Modifiedtime);
	}

	public CtReceivinginspectionitemresultData setModifiedtime(Date Modifiedtime) {
		this.repository().set(CtReceivinginspectionitemresultData.Modifiedtime, Modifiedtime);
		return this;
	}

	public String getLasttxnhistkey() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Lasttxnhistkey);
	}

	public CtReceivinginspectionitemresultData setLasttxnhistkey(String Lasttxnhistkey) {
		this.repository().set(CtReceivinginspectionitemresultData.Lasttxnhistkey, Lasttxnhistkey);
		return this;
	}

	public String getLasttxnid() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Lasttxnid);
	}

	public CtReceivinginspectionitemresultData setLasttxnid(String Lasttxnid) {
		this.repository().set(CtReceivinginspectionitemresultData.Lasttxnid, Lasttxnid);
		return this;
	}

	public String getLasttxnuser() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Lasttxnuser);
	}

	public CtReceivinginspectionitemresultData setLasttxnuser(String Lasttxnuser) {
		this.repository().set(CtReceivinginspectionitemresultData.Lasttxnuser, Lasttxnuser);
		return this;
	}

	public Date getLasttxntime() {
		return this.repository().getDate(CtReceivinginspectionitemresultData.Lasttxntime);
	}

	public CtReceivinginspectionitemresultData setLasttxntime(Date Lasttxntime) {
		this.repository().set(CtReceivinginspectionitemresultData.Lasttxntime, Lasttxntime);
		return this;
	}

	public String getLasttxncomment() {
		return this.repository().getString(CtReceivinginspectionitemresultData.Lasttxncomment);
	}

	public CtReceivinginspectionitemresultData setLasttxncomment(String Lasttxncomment) {
		this.repository().set(CtReceivinginspectionitemresultData.Lasttxncomment, Lasttxncomment);
		return this;
	}


}