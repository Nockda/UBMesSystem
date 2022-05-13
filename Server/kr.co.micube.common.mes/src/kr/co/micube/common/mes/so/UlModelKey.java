package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlModelKey extends SQLKey {

	UlModelKey() {
	}


	public String getModelid() {
		return this.repository().getString(UlModelData.Modelid);
	}

	public UlModelKey setModelid(String Modelid) {
		this.repository().set(UlModelData.Modelid, Modelid);
		return this;
	}


}