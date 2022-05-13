package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlSubprocessworkresultdetailKey extends SQLKey {

	UlSubprocessworkresultdetailKey() {
	}


	public String getWorkresulthistkey() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Workresulthistkey);
	}

	public UlSubprocessworkresultdetailKey setWorkresulthistkey(String Workresulthistkey) {
		this.repository().set(UlSubprocessworkresultdetailData.Workresulthistkey, Workresulthistkey);
		return this;
	}

	public String getParameterid() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Parameterid);
	}

	public UlSubprocessworkresultdetailKey setParameterid(String Parameterid) {
		this.repository().set(UlSubprocessworkresultdetailData.Parameterid, Parameterid);
		return this;
	}

	public String getPointid() {
		return this.repository().getString(UlSubprocessworkresultdetailData.Pointid);
	}

	public UlSubprocessworkresultdetailKey setPointid(String Pointid) {
		this.repository().set(UlSubprocessworkresultdetailData.Pointid, Pointid);
		return this;
	}

	public Integer getSeq() {
		return this.repository().getInteger(UlSubprocessworkresultdetailData.Seq);
	}

	public UlSubprocessworkresultdetailKey setSeq(Integer Seq) {
		this.repository().set(UlSubprocessworkresultdetailData.Seq, Seq);
		return this;
	}


}