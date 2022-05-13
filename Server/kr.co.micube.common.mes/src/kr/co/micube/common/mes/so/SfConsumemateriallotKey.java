package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfConsumemateriallotKey extends SQLKey {

	SfConsumemateriallotKey() {
	}


	public String getLotid() {
		return this.repository().getString(SfConsumemateriallotData.Lotid);
	}

	public SfConsumemateriallotKey setLotid(String Lotid) {
		this.repository().set(SfConsumemateriallotData.Lotid, Lotid);
		return this;
	}

	public String getMateriallotid() {
		return this.repository().getString(SfConsumemateriallotData.Materiallotid);
	}

	public SfConsumemateriallotKey setMateriallotid(String Materiallotid) {
		this.repository().set(SfConsumemateriallotData.Materiallotid, Materiallotid);
		return this;
	}

	public String getMaterialtype() {
		return this.repository().getString(SfConsumemateriallotData.Materialtype);
	}

	public SfConsumemateriallotKey setMaterialtype(String Materialtype) {
		this.repository().set(SfConsumemateriallotData.Materialtype, Materialtype);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfConsumemateriallotData.Txnhistkey);
	}

	public SfConsumemateriallotKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfConsumemateriallotData.Txnhistkey, Txnhistkey);
		return this;
	}


}