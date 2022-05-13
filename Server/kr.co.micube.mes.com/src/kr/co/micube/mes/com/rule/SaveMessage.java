package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.mes.MessageData;
import kr.co.micube.tool.so.mes.MessageKey;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveMessage extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		String state = null;
		
		for (int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);
			state = row.getString("_STATE_");
			
			switch (state) {
				case UpsertState.INSERT:
					batch.add(getInsertData(row), SQLUpsertType.INSERT);
					break;
				case UpsertState.UPDATE:
					batch.add(getUpdateData(row), SQLUpsertType.UPDATE);
					break;
				case UpsertState.DELETE:
					batch.add(getDeleteData(row), SQLUpsertType.DELETE);
					break;
			}
		}
		
		batch.execute();
	}
	
	// Insert Message
	private MessageData getInsertData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		MessageData message = new MessageData();
		MessageKey messageKey = message.key();
		messageKey.setMessageid(row.getString("MESSAGEID"));
		messageKey.setLanguagetype(row.getString("LANGUAGETYPE"));
		
		message = message.selectOne();
		
		if (message != null)
		{
			throw new InValidDataException("InValidData002", String.format("MessageId = %s, LanguageType = %s", row.getString("MESSAGEID"), row.getString("LANGUAGETYPE")));
		}
		
		
		MessageData newMessage = new MessageData();
		MessageKey newMessageKey = newMessage.key();
		newMessageKey.setMessageid(row.getString("MESSAGEID"));
		newMessageKey.setLanguagetype(row.getString("LANGUAGETYPE"));
		
		newMessage.setMessagename(row.getString("TITLE"));
		newMessage.setDescription(row.getString("MESSAGENAME"));
		newMessage.setMessageclassid(row.getString("MESSAGECLASSID"));
		newMessage.setValidstate(row.getString("VALIDSTATE"));
		
		newMessage.setLasttxnid(TransactionId.CREATE);
		
		
		return newMessage;
	}
	
	// Update Message
	private MessageData getUpdateData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		MessageData message = new MessageData();
		MessageKey messageKey = message.key();
		messageKey.setMessageid(row.getString("MESSAGEID"));
		messageKey.setLanguagetype(row.getString("LANGUAGETYPE"));
		
		message = message.selectOne();
		
		if (message == null)
		{
			throw new InValidDataException("InValidData001", String.format("MessageId = %s, LanguageType = %s", row.getString("MESSAGEID"), row.getString("LANGUAGETYPE")));
		}
		
		
		message.setMessagename(row.getString("TITLE"));
		message.setDescription(row.getString("MESSAGENAME"));
		message.setMessageclassid(row.getString("MESSAGECLASSID"));
		message.setValidstate(row.getString("VALIDSTATE"));
		
		message.setLasttxnid(TransactionId.MODIFY);
		
		
		return message;
	}
	
	// Delete Message
	private MessageData getDeleteData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		MessageData message = new MessageData();
		MessageKey messageKey = message.key();
		messageKey.setMessageid(row.getString("MESSAGEID"));
		messageKey.setLanguagetype(row.getString("LANGUAGETYPE"));
		
		message = message.selectOne();
		
		if (message == null)
		{
			throw new InValidDataException("InValidData003", String.format("MessageId = %s, LanguageType = %s", row.getString("MESSAGEID"), row.getString("LANGUAGETYPE")));
		}
		
		
		message.setLasttxnid(TransactionId.DELETE);
		
		
		return message;
	}
}
