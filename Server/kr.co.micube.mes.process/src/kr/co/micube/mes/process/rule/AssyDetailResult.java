package kr.co.micube.mes.process.rule;


import java.text.DecimalFormat;

import kr.co.micube.common.mes.constant.ParameterInputType;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.service.CtParameterDefinitionService;
import kr.co.micube.common.mes.so.CtParameterdefinitionData;
import kr.co.micube.common.mes.so.UlSubprocessworkresultdetailData;
import kr.co.micube.common.mes.so.UlSubprocessworkresultdetailKey;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;
import kr.co.micube.commons.factory.service.TxnInfo;

public class AssyDetailResult extends DatasetRule {

	@Override
	public void doEvent() throws Throwable{
		// TODO Auto-generated method stub
		IMessage msg = this.getMessage().get();
		
		TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);
		
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		String tag = body.get("tag"); 
		
		switch(tag) {
		case "SaveWorkResult":
			SaveWorkResult(dt, batch, txnInfo);
			break;
		case "SaveInspResult":
			SaveInspResult(dt, batch, txnInfo);
			break;
			
		}
	}
	
	private void SaveWorkResult(IDataTable dt, ISQLUpsertBatch batch, TxnInfo txnInfo) throws SystemException
	{
		if ( dt != null) {	
			IDataRow row = null;			
			for (int i = 0; i < dt.size(); i++) {
				row = dt.getRow(i);
				
				UlSubprocessworkresultdetailData data = new UlSubprocessworkresultdetailData();
				UlSubprocessworkresultdetailKey key = data.key();
				key.setParameterid(row.getString("PARAMETERID"));
				key.setPointid(row.getString("POINTID"));
				key.setSeq(Integer.parseInt(row.getString("SEQ")));
				key.setWorkresulthistkey(row.getString("WORKRESULTHISTKEY"));				
				
				data = data.selectOne();
				
				if ( data == null) {
					throw new InValidDataException("InValidData001",String.format("PARAMETERID = %s , POINTID = %s , SEQ = %s , WORKRESULTHISTKEY = %s " 
							,row.getString("PARAMETERID")
							,row.getString("POINTID")
							,row.getString("SEQ")
							,row.getString("WORKRESULTHISTKEY")));
				}
				
				if(InputTypeCheck(key ,row) == false)
				{
					// 데이터가 입력 타입과 맞지 않습니다.
					throw new SystemException("NotMatchInputType");
				}
				
				data.setMeasurevalue(row.getString("MEASUREVALUE"));
				data.setTxncomment(txnInfo.getTxnComment());
				batch.add(data, SQLUpsertType.UPDATE);
				
			}
			
			batch.execute();
			
		}
	}
	
	private void SaveInspResult(IDataTable dt, ISQLUpsertBatch batch, TxnInfo txnInfo) throws SystemException
	{
		if ( dt != null) {	
			IDataRow row = null;			
			for (int i = 0; i < dt.size(); i++) {
				row = dt.getRow(i);
				UlSubprocessworkresultdetailData data = new UlSubprocessworkresultdetailData();
				UlSubprocessworkresultdetailKey key = data.key();
				key.setParameterid(row.getString("PARAMETERID"));
				key.setPointid(row.getString("POINTID"));
				key.setSeq(Integer.parseInt(row.getString("SEQ")));
				key.setWorkresulthistkey(row.getString("HISTKEY"));				
				
				data = data.selectOne();
				
				if ( data == null) {
					throw new InValidDataException("InValidData001",String.format("PARAMETERID = %s, POINTID = %s , SEQ = %s , HISTKEY = %s " 
							,row.getString("PARAMETERID")
							,row.getString("POINTID")
							,row.getString("SEQ")
							,row.getString("HISTKEY")));
				}
				
				if(InputTypeCheck(key ,row) == false)
				{
					// 데이터가 입력 타입과 맞지 않습니다.
					throw new SystemException("NotMatchInputType");
				}
				
				data.setMeasurevalue(row.getString("MEASUREVALUE"));
				data.setTxncomment(txnInfo.getTxnComment());
				batch.add(data, SQLUpsertType.UPDATE);
				
			}
			
			batch.execute();
			
		}
	}
	private boolean InputTypeCheck(UlSubprocessworkresultdetailKey key, IDataRow row) throws DatabaseException {
		
		boolean result = false;
		
		String value = row.getString("MEASUREVALUE");
		
		CtParameterdefinitionData parameterData = CtParameterDefinitionService.getParameterDefinition(key.getParameterid());
		
		switch(parameterData.getInputtype()) {
			case ParameterInputType.CHECKBOX:
					if(value.toUpperCase().equals("Y") || value.toUpperCase().equals("N"))
					{
						result = true;
					}
				break;
			case ParameterInputType.COMBOBOX:
				if(value.toUpperCase().equals("OK"))
				{
					result = true;
				}
				break;
			case ParameterInputType.FLOAT:
				try {				
				    Double.parseDouble(value);
				    result = true;	
				}
				catch (NumberFormatException e) {
				    return false;
				}
				break;
			case ParameterInputType.STRING:
					result = true;
				break;
 				
		}
		
		return result;
	}
}
