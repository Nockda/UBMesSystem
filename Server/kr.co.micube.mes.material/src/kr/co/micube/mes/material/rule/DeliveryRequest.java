package kr.co.micube.mes.material.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlMaterialdeliveryreqData;
import kr.co.micube.common.mes.so.UlMaterialdeliveryreqKey;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 자재관리 > 자재 > 자재LOT출고
 * 설               명	: 출고요청정보를 등록한다
 * 생      성      자	: scmo
 * 생      성      일	: 2020-06-10
 * 수   정   이   력	: 
 */
public class DeliveryRequest extends DatasetRule {
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
					batch.add(getInsertData(row, batch), SQLUpsertType.INSERT);
					break;
				case UpsertState.UPDATE:
					batch.add(getUpdateData(row, batch), SQLUpsertType.UPDATE);
					break;
				case UpsertState.DELETE:
					batch.add(getDeleteData(row, batch), SQLUpsertType.DELETE);
			}
		}
		
		batch.execute();
	}
	
	// Insert Code
	private UlMaterialdeliveryreqData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlMaterialdeliveryreqData code = new UlMaterialdeliveryreqData();
		UlMaterialdeliveryreqKey codeKey = code.key();
			
		codeKey.setSeq(row.getInteger("SEQ"));
	
		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getInteger("SEQ").toString()));
		}
		
		UlMaterialdeliveryreqData newCode = new UlMaterialdeliveryreqData();
		//UlMaterialdeliveryreqKey newCodeKey = newCode.key();
	
		newCode.setReqseq(row.getInteger("REQSEQ"));
		newCode.setReqserl(row.getInteger("REQSERL"));
		newCode.setReqno(row.getString("REQNO"));
		newCode.setItemseq(row.getInteger("ITEMSEQ"));
		newCode.setItemno(row.getString("ITEMNO"));
		newCode.setCompleteyn(Constant.NO);
		newCode.setRequestqty(row.getDouble("LEFTQTY"));
			
		return newCode;
	}
	
	// Insert Code
	private UlMaterialdeliveryreqData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		ISQLCondition cond = new SQLCondition(false);
		
		UlMaterialdeliveryreqData code = new UlMaterialdeliveryreqData();
		cond.set(UlMaterialdeliveryreqData.Reqseq, row.getString("REQSEQ"));
		cond.set(UlMaterialdeliveryreqData.Reqserl, row.getString("REQSERL"));
		cond.set(UlMaterialdeliveryreqData.Itemseq, row.getString("ITEMSEQ"));
		cond.set(UlMaterialdeliveryreqData.Completeyn, Constant.NO);
		ISQLDataList<UlMaterialdeliveryreqData> codeDataList = code.select(cond);
		code = codeDataList.get(0);
		cond.clear();
		
		UlMaterialdeliveryreqKey codeKey = code.key();
		
		codeKey.setSeq(codeKey.getSeq());

		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getInteger("SEQ").toString()));
		}
		
		code.setCompleteyn(Constant.YES);
			
		return code;
	}
	
  // Delete Code 
  private UlMaterialdeliveryreqData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException 
  { 
	  UlMaterialdeliveryreqData code = new UlMaterialdeliveryreqData(); 
	  
  
	  ISQLCondition cond = new SQLCondition(false);
	  cond.set(UlMaterialdeliveryreqData.Reqseq, row.getInteger("REQSEQ"));
	  cond.set(UlMaterialdeliveryreqData.Reqserl, row.getInteger("REQSERL"));
	  cond.set(UlMaterialdeliveryreqData.Itemseq, row.getInteger("ITEMSEQ"));
	  code = code.selectFirst(cond);
	  
	  UlMaterialdeliveryreqKey codeKey = code.key();
	  
	  codeKey.setSeq(codeKey.getSeq());
	  
	  code = code.selectOne();
	  
	  if (code == null) 
	  { 
		  throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getInteger("SEQ").toString()));
	  }
	  
	  return code;
  }
}
