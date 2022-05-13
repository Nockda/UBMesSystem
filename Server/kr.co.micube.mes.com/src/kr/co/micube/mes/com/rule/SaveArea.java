package kr.co.micube.mes.com.rule;

import java.text.ParseException;
import java.time.LocalTime;
import java.util.Date;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.SfAreaData;
import kr.co.micube.common.mes.so.SfAreaKey;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
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
 * 프  로  그  램  명	: 기준정보 > 코드관리 > 작업장코드관리
 * 설               명	: 작업장관리 화면에서 변경된 데이터를 저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-05-25
 * 수   정   이   력	: 
 */
public class SaveArea extends DatasetRule {
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
	private SfAreaData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException, Throwable
	{
		SfAreaData code = new SfAreaData();
		SfAreaKey codeKey = code.key();
		Date now = new Date();
		codeKey.setAreaid(row.getString("AREAID"));
		TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("AREAID")));
		}
		
		SfAreaData newCode = new SfAreaData();
		SfAreaKey newCodeKey = newCode.key();

		newCodeKey.setAreaid(row.getString("AREAID"));
		
		//조건 추가 2021.11.04 이현석
		newCode.setAreaname(row.getString("AREANAME$$KO-KR"));
		newCode.setAreaname(row.getString("AREANAME$$EN-US"));
		newCode.setAreaname(row.getString("AREANAME$$JA-JP"));
		newCode.setEnterpriseid("ULVAC");
		newCode.setPlantid("P1");
		newCode.setAreatype("Area");
		newCode.setDictionaryid(row.getString("AREAID"));
		newCode.setModifiedtime(now);
		newCode.setModifier(txnInfo.getTxnUser());
		
		newCode.setDescription(row.getString("DESCRIPTION"));
		newCode.setWarehouseid(row.getString("WAREHOUSEID"));
		newCode.setValidstate(row.getString("VALIDSTATE"));
		newCode.setLasttxncomment("SaveArea");
		
		return newCode;
	}
	
	// Update Code
	private SfAreaData getUpdateData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException, Throwable
	{
		SfAreaData code = new SfAreaData();
		SfAreaKey codeKey = code.key();
		Date now = new Date();
		TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
		
		codeKey.setAreaid(row.getString("AREAID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("AREAID")));
		}
		//조건 추가 2021.11.04 이현석
		code.setAreaname(row.getString("AREANAME$$KO-KR"));
		code.setAreaname(row.getString("AREANAME$$EN-US"));
		code.setAreaname(row.getString("AREANAME$$JA-JP"));
		code.setPlantid("P1");
		code.setEnterpriseid("ULVAC");
		code.setAreatype("Area");
		code.setDictionaryid(row.getString("AREAID"));
		code.setModifiedtime(now);
		code.setModifier(txnInfo.getTxnUser());
		
		code.setDescription(row.getString("DESCRIPTION"));
		code.setWarehouseid(row.getString("WAREHOUSEID"));
		code.setValidstate(row.getString("VALIDSTATE"));
		code.setLasttxncomment("SaveArea");

		return code;
	}

	// Delete Code
	private SfAreaData getDeleteData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfAreaData code = new SfAreaData();
		SfAreaKey codeKey = code.key();

		codeKey.setAreaid(row.getString("AREAID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData003", String.format("CodeId = %s", row.getString("AREAID")));
		}
		
		return code;
	}
}
