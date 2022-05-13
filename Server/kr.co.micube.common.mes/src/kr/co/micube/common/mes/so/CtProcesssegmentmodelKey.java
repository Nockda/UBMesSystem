package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtProcesssegmentmodelKey extends SQLKey {

	CtProcesssegmentmodelKey() {
	}


	public String getProcesssegmentid() {
		return this.repository().getString(CtProcesssegmentmodelData.Processsegmentid);
	}

	public CtProcesssegmentmodelKey setProcesssegmentid(String Processsegmentid) {
		this.repository().set(CtProcesssegmentmodelData.Processsegmentid, Processsegmentid);
		return this;
	}

	public String getProcesssegmentversion() {
		return this.repository().getString(CtProcesssegmentmodelData.Processsegmentversion);
	}

	public CtProcesssegmentmodelKey setProcesssegmentversion(String Processsegmentversion) {
		this.repository().set(CtProcesssegmentmodelData.Processsegmentversion, Processsegmentversion);
		return this;
	}

	public String getModelid() {
		return this.repository().getString(CtProcesssegmentmodelData.Modelid);
	}

	public CtProcesssegmentmodelKey setModelid(String Modelid) {
		this.repository().set(CtProcesssegmentmodelData.Modelid, Modelid);
		return this;
	}


}