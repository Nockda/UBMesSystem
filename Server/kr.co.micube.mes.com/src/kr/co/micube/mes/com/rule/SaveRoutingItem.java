package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlRoutingitemData;
import kr.co.micube.common.mes.so.UlRoutingitemKey;
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
 * 프  로  그  램  명	: 기준정보 > 라우팅 > 라우팅아이템
 * 설               명	: 라우팅아이템 데이터를 저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-04-14
 * 수   정   이   력	: 
 */
public class SaveRoutingItem extends DatasetRule {
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
					break;
			}
		}
		
		batch.execute();
	}
	
	// Insert Code
		private UlRoutingitemData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlRoutingitemData code = new UlRoutingitemData();
			UlRoutingitemKey codeKey = code.key();

			codeKey.setRoutingid(row.getString("ROUTINGID"));
			codeKey.setItemid(row.getString("ITEMID"));

			code = code.selectOne();
			
			if (code != null)
			{
				throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("ROUTINGID") + "|" + row.getString("ITEMID")));
			}
			
			UlRoutingitemData newCode = new UlRoutingitemData();
			UlRoutingitemKey newCodeKey = newCode.key();

			newCodeKey.setRoutingid(row.getString("ROUTINGID"));
			newCodeKey.setItemid(row.getString("ITEMID"));
		
			newCode.setResultstate(row.getString("RESULTSTATE"));
			newCode.setOutsourcestate(row.getString("OUTSOURCESTATE"));
			newCode.setValidstate(row.getString("VALIDSTATE"));
			newCode.setProcessdstate(row.getString("PROCESSDSTATE"));
			newCode.setStandworktime(row.getDouble("STANDWORKTIME"));
			
			return newCode;
		}
		
		// Update Code
		private UlRoutingitemData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlRoutingitemData code = new UlRoutingitemData();
			UlRoutingitemKey codeKey = code.key();

			codeKey.setRoutingid(row.getString("ROUTINGID"));
			codeKey.setItemid(row.getString("ITEMID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("ROUTINGID") + "|" + row.getString("ITEMID")));
			}
				
			code.setResultstate(row.getString("RESULTSTATE"));
			code.setOutsourcestate(row.getString("OUTSOURCESTATE"));
			code.setValidstate(row.getString("VALIDSTATE"));
			code.setProcessdstate(row.getString("PROCESSDSTATE"));
			code.setStandworktime(row.getDouble("STANDWORKTIME"));

			return code;
		}

		// Delete Code
		private UlRoutingitemData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlRoutingitemData code = new UlRoutingitemData();
			UlRoutingitemKey codeKey = code.key();

			codeKey.setRoutingid(row.getString("ROUTINGID"));
			codeKey.setItemid(row.getString("ITEMID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("ROUTINGID") + "|" + row.getString("ITEMID")));
			}
			
			return code;
		}

}
