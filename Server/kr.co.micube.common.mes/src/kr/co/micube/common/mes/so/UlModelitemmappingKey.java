package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlModelitemmappingKey extends SQLKey {

	UlModelitemmappingKey() {
	}


	public String getModelid() {
		return this.repository().getString(UlModelitemmappingData.Modelid);
	}

	public UlModelitemmappingKey setModelid(String Modelid) {
		this.repository().set(UlModelitemmappingData.Modelid, Modelid);
		return this;
	}

	public String getItemid() {
		return this.repository().getString(UlModelitemmappingData.Itemid);
	}

	public UlModelitemmappingKey setItemid(String Itemid) {
		this.repository().set(UlModelitemmappingData.Itemid, Itemid);
		return this;
	}


}