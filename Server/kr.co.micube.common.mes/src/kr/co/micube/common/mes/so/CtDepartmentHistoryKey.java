package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtDepartmentHistoryKey extends SQLKey {

	CtDepartmentHistoryKey() {
	}


	public String getDepartmentid() {
		return this.repository().getString(CtDepartmentHistoryData.Departmentid);
	}

	public CtDepartmentHistoryKey setDepartmentid(String Departmentid) {
		this.repository().set(CtDepartmentHistoryData.Departmentid, Departmentid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(CtDepartmentHistoryData.Txnhistkey);
	}

	public CtDepartmentHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(CtDepartmentHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}