package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtSubprocessworkerKey extends SQLKey {

	CtSubprocessworkerKey() {
	}


	public String getProcesssegmentid() {
		return this.repository().getString(CtSubprocessworkerData.Processsegmentid);
	}

	public CtSubprocessworkerKey setProcesssegmentid(String Processsegmentid) {
		this.repository().set(CtSubprocessworkerData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getSubprocesssegmentid() {
		return this.repository().getString(CtSubprocessworkerData.Subprocesssegmentid);
	}

	public CtSubprocessworkerKey setSubprocesssegmentid(String Subprocesssegmentid) {
		this.repository().set(CtSubprocessworkerData.Subprocesssegmentid, Subprocesssegmentid);
		return this;
	}

	public String getUserid() {
		return this.repository().getString(CtSubprocessworkerData.Userid);
	}

	public CtSubprocessworkerKey setUserid(String Userid) {
		this.repository().set(CtSubprocessworkerData.Userid, Userid);
		return this;
	}


}