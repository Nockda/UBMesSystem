package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtDepartmentKey extends SQLKey {

	CtDepartmentKey() {
	}


	public String getDepartmentid() {
		return this.repository().getString(CtDepartmentData.Departmentid);
	}

	public CtDepartmentKey setDepartmentid(String Departmentid) {
		this.repository().set(CtDepartmentData.Departmentid, Departmentid);
		return this;
	}


}