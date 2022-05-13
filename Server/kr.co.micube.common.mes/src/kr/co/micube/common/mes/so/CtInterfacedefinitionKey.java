package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtInterfacedefinitionKey extends SQLKey {

	CtInterfacedefinitionKey() {
	}


	public String getInterfaceid() {
		return this.repository().getString(CtInterfacedefinitionData.Interfaceid);
	}

	public CtInterfacedefinitionKey setInterfaceid(String Interfaceid) {
		this.repository().set(CtInterfacedefinitionData.Interfaceid, Interfaceid);
		return this;
	}


}