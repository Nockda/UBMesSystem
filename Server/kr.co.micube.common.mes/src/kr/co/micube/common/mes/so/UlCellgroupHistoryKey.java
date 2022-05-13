package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class UlCellgroupHistoryKey extends SQLKey {

	UlCellgroupHistoryKey() {
	}


	public String getCellgroupid() {
		return this.repository().getString(UlCellgroupHistoryData.Cellgroupid);
	}

	public UlCellgroupHistoryKey setCellgroupid(String Cellgroupid) {
		this.repository().set(UlCellgroupHistoryData.Cellgroupid, Cellgroupid);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(UlCellgroupHistoryData.Txnhistkey);
	}

	public UlCellgroupHistoryKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(UlCellgroupHistoryData.Txnhistkey, Txnhistkey);
		return this;
	}


}