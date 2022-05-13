package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtSubsegmentspecKey extends SQLKey {

	CtSubsegmentspecKey() {
	}


	public String getSpecdefid() {
		return this.repository().getString(CtSubsegmentspecData.Specdefid);
	}

	public CtSubsegmentspecKey setSpecdefid(String Specdefid) {
		this.repository().set(CtSubsegmentspecData.Specdefid, Specdefid);
		return this;
	}

	public String getSubprocesssegmentid() {
		return this.repository().getString(CtSubsegmentspecData.Subprocesssegmentid);
	}

	public CtSubsegmentspecKey setSubprocesssegmentid(String Subprocesssegmentid) {
		this.repository().set(CtSubsegmentspecData.Subprocesssegmentid, Subprocesssegmentid);
		return this;
	}

	public Double getSpecsequence() {
		return this.repository().getDouble(CtSubsegmentspecData.Specsequence);
	}

	public CtSubsegmentspecKey setSpecsequence(Double Specsequence) {
		this.repository().set(CtSubsegmentspecData.Specsequence, Specsequence);
		return this;
	}

	public String getSpecdefidversion() {
		return this.repository().getString(CtSubsegmentspecData.Specdefidversion);
	}

	public CtSubsegmentspecKey setSpecdefidversion(String Specdefidversion) {
		this.repository().set(CtSubsegmentspecData.Specdefidversion, Specdefidversion);
		return this;
	}


}