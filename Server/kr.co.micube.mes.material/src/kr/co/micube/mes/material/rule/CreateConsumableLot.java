package kr.co.micube.mes.material.rule;

import java.util.ArrayList;
import java.util.List;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.common.mes.so.UlCellData;
import kr.co.micube.common.mes.so.UlCellKey;
import kr.co.micube.common.mes.so.UlOrderdetailData;
import kr.co.micube.common.mes.so.UlOrderdetailKey;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.standard.service.IdService;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 자재관리 > 자재 > 자재LOT생성
 * 설               명	: 자재LOT를 등록 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-04-21
 * 수   정   이   력	: 2020-06-03 발주프로세스 변경에 따른 수정 | scmo
 */
public class CreateConsumableLot extends DatasetRule {
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
					List<String> argList = new ArrayList<>();
					TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
					String createId = IdService.createId("LotNo", 1, argList, txnInfo).get(0);
					batch.add(getInsertData(row, batch, createId), SQLUpsertType.INSERT);
					break;
				case UpsertState.UPDATE:
					batch.add(changeLocation(row, batch), SQLUpsertType.UPDATE);
					break;
			}
				
		}
		
		batch.execute();
	}
	
	// Insert Code
	private SfConsumablelotData getInsertData(IDataRow row, ISQLUpsertBatch batch, String createId) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfConsumablelotData code = new SfConsumablelotData();
		SfConsumablelotKey codeKey = code.key();
			
		codeKey.setConsumablelotid(createId);

		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getString("CONSUMABLELOTID")));
		}
		
		SfConsumablelotData newCode = new SfConsumablelotData();
		SfConsumablelotKey newCodeKey = newCode.key();

		newCodeKey.setConsumablelotid(createId);

		ISQLCondition cond = new SQLCondition(false);
		
		cond.set(UlCellData.Consumabledefid, row.getString("CONSUMABLEDEFID"));
		UlCellData cellData = new UlCellData();
		cellData = cellData.selectLast(cond);
		
		String sCellId = "";
		
		if(cellData != null)
		{
			UlCellKey cellKey = cellData.key();
			sCellId = cellKey.getCellid();
		}
		
		cond.clear();
		
		newCode.setEnterpriseid(row.getString("ENTERPRISEID"));
		newCode.setPlantid(row.getString("PLANTID"));
		newCode.setAreaid(row.getString("AREAID"));
		newCode.setWarehouseid(row.getInteger("WHSEQ").toString());
		newCode.setLocationid(sCellId);
		newCode.setConsumabledefid(row.getString("CONSUMABLEDEFID"));
		newCode.setConsumabledefversion("*");
		newCode.setConsumablestate(row.getString("CONSUMABLESTATE"));
		newCode.setCreatedqty(row.getDouble("CREATEDQTY"));
		newCode.setConsumablelotqty(row.getDouble("CONSUMABLELOTQTY"));
		newCode.setState(row.getString("STATE"));
			
		cond.set(UlOrderdetailData.Poseq, row.getString("POSEQ"));
		cond.set(UlOrderdetailData.Poserl, row.getString("POSERL"));
		cond.set(UlOrderdetailData.Delvseq, row.getString("DELVSEQ"));
		cond.set(UlOrderdetailData.Delvserl, row.getString("DELVSERL"));
		cond.set(UlOrderdetailData.Itemseq, row.getString("ITEMSEQ"));
		UlOrderdetailData orderdetailData = new UlOrderdetailData();
		orderdetailData = orderdetailData.selectFirst(cond);
		UlOrderdetailKey orderdetailKey = orderdetailData.key();
		
		newCode.setOrderseq(orderdetailKey.getSeq());

		return newCode;
	}
	
	private SfConsumablelotData changeLocation(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		SfConsumablelotData code = new SfConsumablelotData();
		SfConsumablelotKey codeKey = code.key();
		
		codeKey.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		
		code = code.selectOne();
		
		if (code == null)
		{
			throw new InValidDataException("InValidData001", String.format("CodeId = %s", row.getString("CONSUMABLELOTID")));
		}
			
		code.setLocationid(row.getString("LOCATIONID"));

		return code;
	}
		
}
