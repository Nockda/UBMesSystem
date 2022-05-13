package kr.co.micube.mes.material.rule;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlMaterialdeliverytempData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;

/*
 * 프  로  그  램  명	: 자재관리 > 자재 > 자재 출고 처리(팝업 내 임시저장)
 * 설               명	: 자재출고처리 임시저장데이터를 초기화한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-06-08
 * 수   정   이   력	: 
 */
public class SaveDeliveryMaterialTempInit extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		//ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		//String state = null;
		
		for (int i = 0, len = dt.size(); i < len; i++) {
			row = dt.getRow(i);

			DeleteData(row);		
		}		
	}
	
	private void DeleteData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		//UlMaterialdeliverytempData code = new UlMaterialdeliverytempData();
		//UlMaterialdeliverytempKey codeKey = code.key();

		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlMaterialdeliverytempData.Reqseq, row.getInteger("REQSEQ"));
		cond.set(UlMaterialdeliverytempData.Reqserl, row.getInteger("REQSERL"));
		cond.set(UlMaterialdeliverytempData.Itemseq, row.getInteger("ITEMSEQ"));
		UlMaterialdeliverytempData cd = new UlMaterialdeliverytempData();
		cd.delete(cond);
	}
	

}
