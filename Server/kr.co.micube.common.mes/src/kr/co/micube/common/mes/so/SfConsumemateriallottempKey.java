package kr.co.micube.common.mes.so;

import java.util.Date;
import kr.co.micube.tool.so.SQLKey;

@SuppressWarnings("unused")
public class SfConsumemateriallottempKey extends SQLKey {

	SfConsumemateriallottempKey() {
	}


	public String getLotid() {
		return this.repository().getString(SfConsumemateriallottempData.Lotid);
	}

	public SfConsumemateriallottempKey setLotid(String Lotid) {
		this.repository().set(SfConsumemateriallottempData.Lotid, Lotid);
		return this;
	}

	public String getMateriallotid() {
		return this.repository().getString(SfConsumemateriallottempData.Materiallotid);
	}

	public SfConsumemateriallottempKey setMateriallotid(String Materiallotid) {
		this.repository().set(SfConsumemateriallottempData.Materiallotid, Materiallotid);
		return this;
	}

	public String getMaterialtype() {
		return this.repository().getString(SfConsumemateriallottempData.Materialtype);
	}

	public SfConsumemateriallottempKey setMaterialtype(String Materialtype) {
		this.repository().set(SfConsumemateriallottempData.Materialtype, Materialtype);
		return this;
	}

	public String getTxnhistkey() {
		return this.repository().getString(SfConsumemateriallottempData.Txnhistkey);
	}

	public SfConsumemateriallottempKey setTxnhistkey(String Txnhistkey) {
		this.repository().set(SfConsumemateriallottempData.Txnhistkey, Txnhistkey);
		return this;
	}


}