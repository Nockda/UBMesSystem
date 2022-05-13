package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlProcessdKey extends SQLKey {

	UlProcessdKey() {
	}


	public String getProcessdid() {
		return this.repository().getString(UlProcessdData.Processdid);
	}

	public UlProcessdKey setProcessdid(String Processdid) {
		this.repository().set(UlProcessdData.Processdid, Processdid);
		return this;
	}


}