package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class CtSubsegmentspecdetailKey extends SQLKey {

	CtSubsegmentspecdetailKey() {
	}


	public String getSpecdefid() {
		return this.repository().getString(CtSubsegmentspecdetailData.Specdefid);
	}

	public CtSubsegmentspecdetailKey setSpecdefid(String Specdefid) {
		this.repository().set(CtSubsegmentspecdetailData.Specdefid, Specdefid);
		return this;
	}

	public Double getSpecsequence() {
		return this.repository().getDouble(CtSubsegmentspecdetailData.Specsequence);
	}

	public CtSubsegmentspecdetailKey setSpecsequence(Double Specsequence) {
		this.repository().set(CtSubsegmentspecdetailData.Specsequence, Specsequence);
		return this;
	}

	public String getParameterid() {
		return this.repository().getString(CtSubsegmentspecdetailData.Parameterid);
	}

	public CtSubsegmentspecdetailKey setParameterid(String Parameterid) {
		this.repository().set(CtSubsegmentspecdetailData.Parameterid, Parameterid);
		return this;
	}

	public String getSpecdefidversion() {
		return this.repository().getString(CtSubsegmentspecdetailData.Specdefidversion);
	}

	public CtSubsegmentspecdetailKey setSpecdefidversion(String Specdefidversion) {
		this.repository().set(CtSubsegmentspecdetailData.Specdefidversion, Specdefidversion);
		return this;
	}


}