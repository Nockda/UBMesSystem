package kr.co.micube.mes.com.rule;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlSeqidruleData;
import kr.co.micube.common.mes.so.UlSeqidruleKey;
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
 * 프  로  그  램  명	: 기준정보 > 코드관리 > 코드자동채번규칙
 * 설               명	: 코드자동채번규칙 데이터를 저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-04-10
 * 수   정   이   력	: 
 */
public class SaveSeqIdRule extends DatasetRule {
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
		private UlSeqidruleData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlSeqidruleData code = new UlSeqidruleData();
			UlSeqidruleKey codeKey = code.key();

			codeKey.setSeqid(row.getString("SEQID"));

			code = code.selectOne();
			
			if (code != null)
			{
				throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("SEQID")));
			}
			
			UlSeqidruleData newCode = new UlSeqidruleData();
			UlSeqidruleKey newCodeKey = newCode.key();

			newCodeKey.setSeqid(row.getString("SEQID"));
			
			newCode.setSeqnamekor(row.getString("SEQNAMEKOR"));
			newCode.setSeqnameeng(row.getString("SEQNAMEENG"));
			newCode.setSeqnamejpn(row.getString("SEQNAMEJPN"));
			newCode.setSeqrule(row.getString("SEQRULE"));
			newCode.setSeqcount(row.getInteger("SEQCOUNT"));
			newCode.setLastseqid(row.getString("LASTSEQID"));
			newCode.setDescription(row.getString("DESCRIPTION"));
			
			return newCode;
		}
		
		// Update Code
		private UlSeqidruleData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlSeqidruleData code = new UlSeqidruleData();
			UlSeqidruleKey codeKey = code.key();

			codeKey.setSeqid(row.getString("SEQID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("SEQID")));
			}
				
			code.setSeqnamekor(row.getString("SEQNAMEKOR"));
			code.setSeqnameeng(row.getString("SEQNAMEENG"));
			code.setSeqnamejpn(row.getString("SEQNAMEJPN"));
			code.setSeqrule(row.getString("SEQRULE"));
			code.setSeqcount(row.getInteger("SEQCOUNT"));
			code.setLastseqid(row.getString("LASTSEQID"));
			code.setDescription(row.getString("DESCRIPTION"));

			return code;
		}

		// Delete Code
		private UlSeqidruleData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
		{
			UlSeqidruleData code = new UlSeqidruleData();
			UlSeqidruleKey codeKey = code.key();

			codeKey.setSeqid(row.getString("SEQID"));
			
			code = code.selectOne();
			
			if (code == null)
			{
				throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("SEQID")));
			}
			
			return code;
		}

}
