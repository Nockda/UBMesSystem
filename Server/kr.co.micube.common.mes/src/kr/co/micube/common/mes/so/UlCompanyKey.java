package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlCompanyKey extends SQLKey {

	UlCompanyKey() {
	}


	public String getCompanyid() {
		return this.repository().getString(UlCompanyData.Companyid);
	}

	public UlCompanyKey setCompanyid(String Companyid) {
		this.repository().set(UlCompanyData.Companyid, Companyid);
		return this;
	}


}