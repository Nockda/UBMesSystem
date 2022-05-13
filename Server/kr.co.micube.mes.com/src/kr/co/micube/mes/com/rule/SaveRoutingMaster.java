package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlRoutingmasterData;
import kr.co.micube.common.mes.so.UlRoutingmasterKey;
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
 * 프  로  그  램  명	: 기준정보 > 라우팅 > 라우팅마스터
 * 설               명	: 라우팅마스터 데이터를 저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-04-14
 * 수   정   이   력	: 
 */
public class SaveRoutingMaster extends DatasetRule {
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
		private UlRoutingmasterData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlRoutingmasterData code = new UlRoutingmasterData();
			UlRoutingmasterKey codeKey = code.key();

			codeKey.setRoutingid(row.getString("ROUTINGID"));

			code = code.selectOne();
			
			if (code != null)
			{
				throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("ROUTINGID")));
			}
			
			UlRoutingmasterData newCode = new UlRoutingmasterData();
			UlRoutingmasterKey newCodeKey = newCode.key();

			newCodeKey.setRoutingid(row.getString("ROUTINGID"));
			
			newCode.setOrdertype(row.getString("ORDERTYPE"));
			newCode.setRoutingnamekor(row.getString("ROUTINGNAMEKOR"));
			newCode.setRoutingnameeng(row.getString("ROUTINGNAMEENG"));
			newCode.setRoutingnamejpn(row.getString("ROUTINGNAMEJPN"));
			newCode.setProcessid(row.getString("PROCESSID"));
			newCode.setModelid(row.getString("MODELID"));
			newCode.setLotunit(row.getString("LOTUNIT"));
			newCode.setItemassetcategory(row.getString("ITEMASSETCATEGORY"));
			newCode.setWorkgroupid(row.getString("WORKGROUPID"));
			newCode.setDescription(row.getString("DESCRIPTION"));
			newCode.setValidstate(row.getString("VALIDSTATE"));
			
			return newCode;
		}
		
		// Update Code
		private UlRoutingmasterData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlRoutingmasterData code = new UlRoutingmasterData();
			UlRoutingmasterKey codeKey = code.key();

			codeKey.setRoutingid(row.getString("ROUTINGID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("ROUTINGID")));
			}
				
			code.setOrdertype(row.getString("ORDERTYPE"));
			code.setRoutingnamekor(row.getString("ROUTINGNAMEKOR"));
			code.setRoutingnameeng(row.getString("ROUTINGNAMEENG"));
			code.setRoutingnamejpn(row.getString("ROUTINGNAMEJPN"));
			code.setProcessid(row.getString("PROCESSID"));
			code.setModelid(row.getString("MODELID"));
			code.setLotunit(row.getString("LOTUNIT"));
			code.setItemassetcategory(row.getString("ITEMASSETCATEGORY"));
			code.setWorkgroupid(row.getString("WORKGROUPID"));
			code.setDescription(row.getString("DESCRIPTION"));
			code.setValidstate(row.getString("VALIDSTATE"));

			return code;
		}

		// Delete Code
		private UlRoutingmasterData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlRoutingmasterData code = new UlRoutingmasterData();
			UlRoutingmasterKey codeKey = code.key();

			codeKey.setRoutingid(row.getString("ROUTINGID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("ROUTINGID")));
			}
			
			return code;
		}

}