package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlSubprocessworkresultKey extends SQLKey {

	UlSubprocessworkresultKey() {
	}


	public String getTxnhistkey() {
		return this.repository().getString(UlSubprocessworkresultData.Txnhistkey);
	}

	public UlSubprocessworkresultKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(UlSubprocessworkresultData.Txnhistkey, Txnhistkey);
		return this;
	}


}