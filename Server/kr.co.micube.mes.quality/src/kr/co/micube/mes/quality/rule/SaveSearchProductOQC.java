package kr.co.micube.mes.quality.rule;

import kr.co.micube.common.mes.constant.CommonConstant.ConsumableState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명   : 품질관리 > 검사 > 출하 검사 조회
 * 설               명   : 출하검사 완료된 LOT을 출하 확정한다.
 * 생      성      자   : 정승원
 * 생      성      일   : 2020-06-12
 * 수   정   이   력   : 
 */

public class SaveSearchProductOQC extends DatasetRule{
	public void doEvent() throws Throwable {
		
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		for(int i = 0; i < dt.size(); i++)
		{
			IDataRow row = dt.getRow(i);
			String lotId = row.getString("LOTID");
			
			/********************************************************************************************
			 * LOT 체크
			*********************************************************************************************/
			SfConsumablelotData lot = new SfConsumablelotData();
			SfConsumablelotKey lotKey = lot.key();
			lotKey.setConsumablelotid(lotId);
			
			lot = lot.selectOne();
			if(lot.getConsumablestate().equals(ConsumableState.Scrapped))
			{
				//폐기 처분된 LOT 입니다.
				throw new InValidDataException("SCRAPPEDLOT", String.format("LOT ID : %s", lotId));
			}
			
			if(lot.getConsumablestate().equals("Shipped"))
			{
				//이미 출하 확정된 LOT 입니다.
				throw new InValidDataException("SHIPPEDLOT", String.format("LOT ID : %s", lotId));
			}
			
			if(lot.getIshold().equals("Y"))
			{
				//해당 LOT은 HOLD 상태입니다.
				throw new InValidDataException("HOLDLOT", String.format("LOT ID : %s", lotId));
			}
			
			/********************************************************************************************
			 * LOT 출하 확정 
			*********************************************************************************************/
			lot.setConsumablestate("Shipped");
			lot.setLasttxnid(this.getClass().getSimpleName());
			
			batch.add(lot, SQLUpsertType.UPDATE);
		}
		
		batch.execute();
	}
}
