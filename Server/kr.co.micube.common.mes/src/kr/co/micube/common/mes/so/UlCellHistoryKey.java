package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlCellHistoryKey extends SQLKey {

	UlCellHistoryKey() {
	}


	public String getCellid() {
		return this.repository().getString(UlCellHistoryData.Cellid);
	}

	public UlCellHistoryKey setCellid(String Cellid) {
		this.repository().set(UlCellHistoryData.Cellid, Cellid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(UlCellHistoryData.Txnhistkey);
	}

	public UlCellHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(UlCellHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}