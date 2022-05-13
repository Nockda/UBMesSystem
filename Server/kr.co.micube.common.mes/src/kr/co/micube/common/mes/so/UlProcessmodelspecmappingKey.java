package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlProcessmodelspecmappingKey extends SQLKey {

	UlProcessmodelspecmappingKey() {
	}


	public String getModelid() {
		return this.repository().getString(UlProcessmodelspecmappingData.Modelid);
	}

	public UlProcessmodelspecmappingKey setModelid(String Modelid) {
		this.repository().set(UlProcessmodelspecmappingData.Modelid, Modelid);
		return this;
	}

	public String getSpecid() {
		return this.repository().getString(UlProcessmodelspecmappingData.Specid);
	}

	public UlProcessmodelspecmappingKey setSpecid(String Specid) {
		this.repository().set(UlProcessmodelspecmappingData.Specid, Specid);
		return this;
	}

	public String getProcessid() {
		return this.repository().getString(UlProcessmodelspecmappingData.Processid);
	}

	public UlProcessmodelspecmappingKey setProcessid(String Processid) {
		this.repository().set(UlProcessmodelspecmappingData.Processid, Processid);
		return this;
	}


}