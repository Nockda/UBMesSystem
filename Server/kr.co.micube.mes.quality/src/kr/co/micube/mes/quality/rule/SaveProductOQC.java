package kr.co.micube.mes.quality.rule;

import java.util.Date;

import kr.co.micube.common.mes.constant.CommonConstant.LotState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.so.CtOutgoinginspectionData;
import kr.co.micube.common.mes.so.CtOutgoinginspectionKey;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfLotKey;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.util.StringUtil;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;


/*
 * 프  로  그  램  명   : 품질관리 > 검사 > 출하 검사
 * 설               명   : 
 * 생      성      자   : 정승원
 * 생      성      일   : 2020-06-10
 * 수   정   이   력   : 
 */

public class SaveProductOQC extends DatasetRule{
	public void doEvent() throws Throwable {

		Date nowDate = SQLService.toDate();
		
		IMessage msg = this.getMessage().get();
	    IData jmsg = msg.get();
	    IData body = jmsg.get(MessageFormat.Body);
	    
	    String lotId = body.get("lotId");
	    String processSegmentId = body.get("processsegmentId");
		String inspector = body.get("inspector");
		String inspector2 = body.get("inspector2");
	    String comment = body.get("comment");
	    Double degree = body.get("degree");
		
		IDataSet ds = this.getRequestDataset();
		IDataTable dtResult = ds.getTable("result");
		IDataRow result = dtResult.getFirstRow();
		
		/********************************************************************************************
		 * LOT 체크
		*********************************************************************************************/
		SfLotData lot = new SfLotData();
		SfLotKey lotKey = lot.key();
		lotKey.setLotid(lotId);
		
		lot = lot.selectOne();
		if(!lot.getLotstate().equals(LotState.Finished))
		{
			//LOT 상태를 확인하세요.
			throw new InValidDataException("CHECKLOTSTATE", String.format("LOT ID : %s, LOT State : %s", lotId, lot.getLotstate()));
		}
		
		if(lot.getIshold().equals("Y"))
		{
			//해당 LOT은 HOLD 상태입니다.
			throw new InValidDataException("HOLDLOT", String.format("LOT ID : %s", lotId));
		}
		
		if(!lot.getProcesssegmentid().equals(processSegmentId))
		{
			//검사 공정을 확인하세요.
			throw new InValidDataException("CHECKPROCESSSEGMENT"
					, String.format("Processsegment  : %s, Lot Processsegment : %s", processSegmentId, lot.getProcesssegmentid()));
		}
		
		/********************************************************************************************
		 * 출하 검사 결과 저장
		*********************************************************************************************/
		CtOutgoinginspectionData insp = new CtOutgoinginspectionData();
		CtOutgoinginspectionKey inspKey = insp.key();
		inspKey.setLotid(lotId);
		inspKey.setProcesssegmentid(processSegmentId);
		inspKey.setInspectiondegree(degree);
		
		insp = insp.selectOne();
		if(insp != null)
		{
			//이미 출하 검사가 완료된 LOT입니다. 
			throw new InValidDataException("ALREADYSHIPPING", String.format("LOT ID : %s", lotId));
		}
		
		insp = new CtOutgoinginspectionData();
		inspKey = insp.key();
		inspKey.setLotid(lotId);
		inspKey.setProcesssegmentid(lot.getProcesssegmentid());
		inspKey.setInspectiondegree(degree);
		insp.setInspector(inspector);
		insp.setInspector2(!StringUtil.isNullOrEmpty(inspector2) ? inspector2 : null);
		insp.setInspectiondate(nowDate);
		insp.setValue1(result.getBoolean("A") == true ? "Y":null);
		insp.setValue2(result.getBoolean("B") == true ? "Y":null);
		insp.setValue3(result.getBoolean("C") == true ? "Y":null);
		insp.setValue4(result.getBoolean("D") == true ? "Y":null);
		insp.setValue5(result.getBoolean("E") == true ? "Y":null);
		insp.setValue6(result.getBoolean("F") == true ? "Y":null);
		insp.setValue7(result.getBoolean("G") == true ? "Y":null);
		insp.setValue8(result.getBoolean("H") == true ? "Y":null);
		insp.setDescription(comment);
		insp.setLasttxnid(this.getClass().getSimpleName());
		
		insp.insert();
	}
}
