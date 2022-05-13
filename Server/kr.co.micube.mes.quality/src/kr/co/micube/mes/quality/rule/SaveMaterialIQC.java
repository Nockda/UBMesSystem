package kr.co.micube.mes.quality.rule;

import java.util.Date;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.CtReceivinginspectionData;
import kr.co.micube.common.mes.so.CtReceivinginspectionKey;
import kr.co.micube.common.mes.so.CtReceivinginspectionitemresultData;
import kr.co.micube.common.mes.so.CtReceivinginspectionitemresultKey;
import kr.co.micube.common.mes.util.TransactionUtils;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명   : 품질관리 > 검사 > 자재 수입 검사
 * 설               명   : 
 * 생      성      자   : 정승원
 * 생      성      일   : 2020-06-04
 * 수   정   이   력   : 
 */

public class SaveMaterialIQC extends DatasetRule{
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();      
		IDataTable iqcList = ds.getTable("iqcList");
		IDataTable iqcResultList = ds.getTable("iqcResultList");
		
		IData txnData = this.getMessage().getTxnData();
		TxnInfo txnInfo = TransactionUtils.getTransactionInfo(txnData);
		String userId = txnInfo.getTransaction().get("user");
		Date nowDate = SQLService.toDate();
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		//판정결과 저장
		IDataRow row = iqcList.getFirstRow();
		CtReceivinginspectionData insp = new CtReceivinginspectionData();
		CtReceivinginspectionKey inspKey = insp.key();
		inspKey.setDeliveryno(row.getString("DELIVERYNO"));
		inspKey.setConsumabledefid(row.getString("CONSUMABLEDEFID"));
		inspKey.setDeliverysequence(row.getInteger("DELIVERYSEQUENCE"));
		
		insp = insp.selectOne();
		if(insp == null)
		{
			throw new InValidDataException("InValidData001", String.format("DeliveryNo : %s, ConsumableDefId : %s, Seq : %d"
					, row.getString("DELIVERYNO"), row.getString("CONSUMABLEDEFID"), row.getInteger("DELIVERYSEQUENCE")));
		}
		
		insp.setResultcode(row.getString("RESULTCODE"));
		insp.setGoodqty(row.getDouble("GOODQTY"));
		insp.setDefectqty(row.getDouble("DEFECTQTY"));
		insp.setDescription(row.getString("COMMENT"));
		insp.setInspector(userId);
		insp.setInspectiondate(nowDate);
		insp.setIserpsendyn("N");
		insp.setLasttxnid(this.getClass().getSimpleName());
		insp.setInterfacetxnhistkey(Generate.createTimeKey());
		
		batch.add(insp, SQLUpsertType.UPDATE);
		
		//serial별 검사 결과 저장
	    for(int i = 0; i < iqcResultList.size(); i++)
	    {
	    	IDataRow resultRow = iqcResultList.getRow(i);
			String state = resultRow.getString("_STATE_");
			switch(state)
			{
			case UpsertState.INSERT:
				batch.add(getInsertResultData(resultRow), SQLUpsertType.INSERT);
				break;
			case UpsertState.UPDATE:
				batch.add(getUpdateResultData(resultRow), SQLUpsertType.UPDATE);
				break;
			case UpsertState.DELETE:
				batch.add(getDeleteResultData(resultRow), SQLUpsertType.DELETE);
				break;
			}
	    }
	    
	    batch.execute();
	}
	
	/********************************************************************************************
	* CT_RECEIVINGINSPECTIONITEMRESULT INSERT
	*********************************************************************************************/
	private CtReceivinginspectionitemresultData getInsertResultData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		CtReceivinginspectionitemresultData result = new CtReceivinginspectionitemresultData();
		CtReceivinginspectionitemresultKey resultKey = result.key();
		resultKey.setConsumabledefid(row.getString("CONSUMABLEDEFID"));
		resultKey.setDeliveryno(row.getString("DELIVERYNO"));
		resultKey.setDeliveryserialno(row.getString("DELIVERYSERIALNO"));
		resultKey.setDeliverysequence(row.getInteger("DELIVERYSEQUENCE"));
		
		result = result.selectOne();
		if(result != null)
		{
			throw new InValidDataException("InValidData002", String.format("DeliveryNo : %s, ConsumableDefId : %s, Serial : %s, Seq : %d"
					, row.getString("DELIVERYNO"), row.getString("CONSUMABLEDEFID"), row.getString("DELIVERYSERIALNO"), row.getInteger("DELIVERYSEQUENCE")));
		}
		
		result = new CtReceivinginspectionitemresultData();
		resultKey = result.key();
		resultKey.setConsumabledefid(row.getString("CONSUMABLEDEFID"));
		resultKey.setDeliveryno(row.getString("DELIVERYNO"));
		resultKey.setDeliveryserialno(row.getString("DELIVERYSERIALNO"));
		resultKey.setDeliverysequence(row.getInteger("DELIVERYSEQUENCE"));
		
		result.setValue1(row.getString("A"));
		result.setValue2(row.getString("B"));
		result.setValue3(row.getString("C"));
		result.setValue4(row.getString("D"));
		result.setValue5(row.getString("E"));
		result.setValue6(row.getString("F"));
		result.setValue7(row.getString("G"));
		result.setValue8(row.getString("H"));
		result.setValue9(row.getString("I"));
		result.setValue10(row.getString("J"));
		result.setValue11(row.getString("K"));
		result.setValue12(row.getString("L"));
		result.setValue13(row.getString("M"));
		result.setValue14(row.getString("N"));
		//result.setValue15(row.getString("O"));
		//result.setValue16(row.getString("P"));
		//result.setValue17(row.getString("Q"));
		//result.setValue18(row.getString("R"));
		//result.setValue19(row.getString("S"));
		//result.setValue20(row.getString("T"));
		result.setResultcode(row.getString("RESULTCODE"));
		
		result.setLasttxnid(this.getClass().getSimpleName());
		
		return result;
	}
	
	/********************************************************************************************
	* CT_RECEIVINGINSPECTIONITEMRESULT UPDATE
	*********************************************************************************************/
	private CtReceivinginspectionitemresultData getUpdateResultData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		CtReceivinginspectionitemresultData result = new CtReceivinginspectionitemresultData();
		CtReceivinginspectionitemresultKey resultKey = result.key();
		resultKey.setConsumabledefid(row.getString("CONSUMABLEDEFID"));
		resultKey.setDeliveryno(row.getString("DELIVERYNO"));
		resultKey.setDeliveryserialno(row.getString("DELIVERYSERIALNO"));
		resultKey.setDeliverysequence(row.getInteger("DELIVERYSEQUENCE"));
		
		result = result.selectOne();
		if(result == null)
		{
			throw new InValidDataException("InValidData001", String.format("DeliveryNo : %s, ConsumableDefId : %s, Serial : %s, Seq : %d"
					, row.getString("DELIVERYNO"), row.getString("CONSUMABLEDEFID"), row.getString("DELIVERYSERIALNO"), row.getInteger("DELIVERYSEQUENCE")));
		}
		
		result.setValue1(row.getString("A"));
		result.setValue2(row.getString("B"));
		result.setValue3(row.getString("C"));
		result.setValue4(row.getString("D"));
		result.setValue5(row.getString("E"));
		result.setValue6(row.getString("F"));
		result.setValue7(row.getString("G"));
		result.setValue8(row.getString("H"));
		result.setValue9(row.getString("I"));
		result.setValue10(row.getString("J"));
		result.setValue11(row.getString("K"));
		result.setValue12(row.getString("L"));
		result.setValue13(row.getString("M"));
		result.setValue14(row.getString("N"));
		result.setValue15(row.getString("O"));
		result.setValue16(row.getString("P"));
		result.setValue17(row.getString("Q"));
		result.setValue18(row.getString("R"));
		result.setValue19(row.getString("S"));
		result.setValue20(row.getString("T"));
		result.setResultcode(row.getString("RESULTCODE"));
		
		result.setLasttxnid(this.getClass().getSimpleName());
		
		return result;
	}
	
	/********************************************************************************************
	* CT_RECEIVINGINSPECTIONITEMRESULT DELETE
	*********************************************************************************************/
	private CtReceivinginspectionitemresultData getDeleteResultData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		CtReceivinginspectionitemresultData result = new CtReceivinginspectionitemresultData();
		CtReceivinginspectionitemresultKey resultKey = result.key();
		resultKey.setConsumabledefid(row.getString("CONSUMABLEDEFID"));
		resultKey.setDeliveryno(row.getString("DELIVERYNO"));
		resultKey.setDeliveryserialno(row.getString("DELIVERYSERIALNO"));
		resultKey.setDeliverysequence(row.getInteger("DELIVERYSEQUENCE"));
		
		result = result.selectOne();
		if(result == null)
		{
			throw new InValidDataException("InValidData003", String.format("DeliveryNo : %s, ConsumableDefId : %s, Serial : %s, Seq : %d"
					, row.getString("DELIVERYNO"), row.getString("CONSUMABLEDEFID"), row.getString("DELIVERYSERIALNO"), row.getInteger("DELIVERYSEQUENCE")));
		}
		
		result.setLasttxnid(this.getClass().getSimpleName());
		
		return result;
	}
}
