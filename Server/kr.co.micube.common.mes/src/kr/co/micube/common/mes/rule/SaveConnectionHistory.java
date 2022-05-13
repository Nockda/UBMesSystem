package kr.co.micube.common.mes.rule;

import kr.co.micube.common.mes.constant.ConnectionType;
import kr.co.micube.common.mes.so.SfConnectionHistoryData;
import kr.co.micube.common.mes.so.SfConnectionHistoryKey;
/*
import kr.co.micube.common.mes.so.ConnectionHistoryData;
import kr.co.micube.common.mes.so.ConnectionHistoryKey;
*/
import kr.co.micube.common.mes.util.CommonUtils;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.util.Generate;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveConnectionHistory extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IMessage msg = this.getMessage().get();
		
		IData jmsg = msg.get();
		IData head = jmsg.get(MessageFormat.Head);
		IData body = jmsg.get(MessageFormat.Body);
		
		String connectionType = body.getString("connectionType");
		
		SfConnectionHistoryData connection = new SfConnectionHistoryData();
		SfConnectionHistoryKey connectionKey = connection.key();
		
		IDataSet ds = this.getResponseDataset();
		IDataTable dt = null;
		
		String txnHistKey = "";
		
		switch (connectionType) {
			case ConnectionType.LOGIN:
				txnHistKey = Generate.createTimeKey();
				
				connectionKey.setTxnhistkey(txnHistKey);
				connection.setUserid(body.getString("userId"));
				connection.setConnectiontype("Login");
				connection.setIpaddress(head.getString("startPoint"));
				connection.setConnectiontime(CommonUtils.GetDatabaseDatetime(msg));
				
				batch.add(connection, SQLUpsertType.INSERT);
				
				dt = ds.addTable("DATA");
				dt.addRow(connection.toMap());
				
				break;
			case ConnectionType.LOGOUT:
				connectionKey.setTxnhistkey(body.getString("txnHistKey"));
				
				connection = connection.selectOne();
				
				if (connection != null)
				{
					connection.setDisconnectiontime(CommonUtils.GetDatabaseDatetime(msg));
					
					batch.add(connection, SQLUpsertType.UPDATE);
				}
				
				break;
			case ConnectionType.MENU_OPEN:
				txnHistKey = Generate.createTimeKey();
				
				connectionKey.setTxnhistkey(txnHistKey);
				connection.setUserid(body.getString("userId"));
				connection.setConnectiontype("Screen");
				connection.setUiid(body.getString("uiid"));
				connection.setMenuid(body.getString("menuId"));
				connection.setIpaddress(head.getString("startPoint"));
				connection.setConnectiontime(CommonUtils.GetDatabaseDatetime(msg));
				
				batch.add(connection, SQLUpsertType.INSERT);
				
				dt = ds.addTable("DATA");
				dt.addRow(connection.toMap());
				
				break;
			case ConnectionType.MENU_CLOSE:
				connectionKey.setTxnhistkey(body.getString("txnHistKey"));
				
				connection = connection.selectOne();
				
				if (connection != null)
				{
					connection.setDisconnectiontime(CommonUtils.GetDatabaseDatetime(msg));
					
					batch.add(connection, SQLUpsertType.UPDATE);
				}
				
				break;
		}
		
		
		batch.execute();
	}
}