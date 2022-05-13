package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlModelmappingKey extends SQLKey {

	UlModelmappingKey() {
	}


	public String getSpecid() {
		return this.repository().getString(UlModelmappingData.Specid);
	}

	public UlModelmappingKey setSpecid(String Specid) {
		this.repository().set(UlModelmappingData.Specid, Specid);
		return this;
	}

	public String getModelid() {
		return this.repository().getString(UlModelmappingData.Modelid);
	}

	public UlModelmappingKey setModelid(String Modelid) {
		this.repository().set(UlModelmappingData.Modelid, Modelid);
		return this;
	}


}