package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfProcesssegmentKey extends SQLKey {

	SfProcesssegmentKey() {
	}


	public String getProcesssegmentid() {
		return this.repository().getString(SfProcesssegmentData.Processsegmentid);
	}

	public SfProcesssegmentKey setProcesssegmentid(String Processsegmentid) {
		this.repository().set(SfProcesssegmentData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getProcesssegmentversion() {
		return this.repository().getString(SfProcesssegmentData.Processsegmentversion);
	}

	public SfProcesssegmentKey setProcesssegmentversion(String Processsegmentversion) {
		this.repository().set(SfProcesssegmentData.Processsegmentversion, Processsegmentversion);
		return this;
	}


}