package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfFileKey extends SQLKey {

	SfFileKey() {
	}


	public String getManualno() {
		return this.repository().getString(SfFileData.Manualno);
	}

	public SfFileKey setManualno(String Manualno) {
		this.repository().set(SfFileData.Manualno, Manualno);
		return this;
	}

	public String getManualversion() {
		return this.repository().getString(SfFileData.Manualversion);
	}

	public SfFileKey setManualversion(String Manualversion) {
		this.repository().set(SfFileData.Manualversion, Manualversion);
		return this;
	}


}