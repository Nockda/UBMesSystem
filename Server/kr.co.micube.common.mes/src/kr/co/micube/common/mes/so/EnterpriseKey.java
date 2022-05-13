package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class EnterpriseKey extends SQLKey {

	EnterpriseKey() {
	}


	public String getEnterpriseid() {
		return this.repository().getString(EnterpriseData.Enterpriseid);
	}

	public EnterpriseKey setEnterpriseid(String Enterpriseid) {
		this.repository().set(EnterpriseData.Enterpriseid, Enterpriseid);
		return this;
	}


}