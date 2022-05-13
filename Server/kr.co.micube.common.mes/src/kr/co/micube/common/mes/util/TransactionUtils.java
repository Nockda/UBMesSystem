package kr.co.micube.common.mes.util;

import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.core.dto.IData;

public class TransactionUtils {
	public static TxnInfo getTransactionInfo(IData data) {
		TxnInfo txnInfo = new TxnInfo(data);
		
		return txnInfo;
	}
	
	public static TxnInfo setTransactionId(TxnInfo txnInfo, String transactionId)
	{
		txnInfo.getTransaction().set(MessageFormat.Transaction_ID, transactionId);
		
		return txnInfo;
	}
}
