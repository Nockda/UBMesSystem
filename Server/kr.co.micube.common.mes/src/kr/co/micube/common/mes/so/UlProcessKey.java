package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlProcessKey extends SQLKey {

	UlProcessKey() {
	}


	public String getProcessid() {
		return this.repository().getString(UlProcessData.Processid);
	}

	public UlProcessKey setProcessid(String Processid) {
		this.repository().set(UlProcessData.Processid, Processid);
		return this;
	}


}