package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtModelstandardinfoKey extends SQLKey {

	CtModelstandardinfoKey() {
	}


	public String getProcesssegmentid() {
		return this.repository().getString(CtModelstandardinfoData.Processsegmentid);
	}

	public CtModelstandardinfoKey setProcesssegmentid(String Processsegmentid) {
		this.repository().set(CtModelstandardinfoData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getModelid() {
		return this.repository().getString(CtModelstandardinfoData.Modelid);
	}

	public CtModelstandardinfoKey setModelid(String Modelid) {
		this.repository().set(CtModelstandardinfoData.Modelid, Modelid);
		return this;
	}


}