package kr.co.micube.mes.material.rule;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlMaterialdeliverytempData;
import kr.co.micube.common.mes.so.UlMaterialdeliverytempKey;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 자재관리 > 자재 > 자재 출고 처리(팝업 내 임시저장)
 * 설               명	: 자재출고처리 데이터를 임시저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-05-25
 * 수   정   이   력	: 
 */
public class SaveDeliveryMaterialTemp extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		//String state = null;

		for (int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);

			batch.add(getInsertData(row, batch), SQLUpsertType.INSERT);	
			
		}		
		batch.execute();
	}
	
	// Insert Code
	private UlMaterialdeliverytempData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlMaterialdeliverytempData code = new UlMaterialdeliverytempData();
		UlMaterialdeliverytempKey codeKey = code.key();

		codeKey.setSeq(row.getInteger("SEQ"));

		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", String.format("CodeId = %s", row.getInteger("SEQ").toString())));
		}
		
		UlMaterialdeliverytempData newCode = new UlMaterialdeliverytempData();
		//UlMaterialdeliverytempKey newCodeKey = newCode.key();

		//newCodeKey.setSeq(row.getInteger("SEQ"));
		
		newCode.setReqno(row.getString("REQNO"));
		newCode.setReqseq(row.getInteger("REQSEQ"));
		newCode.setReqserl(row.getInteger("REQSERL"));
		newCode.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		newCode.setConsumabledefid(row.getString("CONSUMABLEDEFID"));
		newCode.setItemseq(row.getInteger("ITEMSEQ"));
		newCode.setDeliveryqty(row.getDouble("CONSUMABLELOTQTY"));

		return newCode;
	}
}
