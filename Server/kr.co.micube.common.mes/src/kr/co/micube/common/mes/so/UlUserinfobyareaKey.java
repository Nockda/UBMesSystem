package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlUserinfobyareaKey extends SQLKey {

	UlUserinfobyareaKey() {
	}


	public String getProcessid() {
		return this.repository().getString(UlUserinfobyareaData.Processid);
	}

	public UlUserinfobyareaKey setProcessid(String Processid) {
		this.repository().set(UlUserinfobyareaData.Processid, Processid);
		return this;
	}

	public String getAreaid() {
		return this.repository().getString(UlUserinfobyareaData.Areaid);
	}

	public UlUserinfobyareaKey setAreaid(String Areaid) {
		this.repository().set(UlUserinfobyareaData.Areaid, Areaid);
		return this;
	}


}