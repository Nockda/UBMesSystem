package kr.co.micube.mes.quality.rule;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlDefectData;
import kr.co.micube.common.mes.so.UlDefectKey;
import kr.co.micube.commons.factory.util.StringUtil;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 품질 관리 > 불량 관리 > 불량품 통지서 관리 대장
 * 설               명	: 불량품 통지서를 업데이트 한다.
 * 생      성      자	: 강유라
 * 생      성      일	: 2020-04-23
 * 수   정   이   력	: 
 */

public class SaveDefectRegManagement extends DatasetRule {
	
/*	String exportDate ="";//반출일자
	String reasonDesc="";//원인
	String actionDesc="";//대책
	String description="";//비고사항
*/

	SimpleDateFormat insertDateFormat = new SimpleDateFormat("yyyy-MM-dd");
	
	@Override
	public void doEvent() throws Throwable {
		
/*		IMessage msg = this.getMessage().get();
		
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);*/
		
/*		//반출일자
		exportDate = body.getString("exportDate");
		//원인
		reasonDesc = body.getString("reasonDesc");
		//대책
		actionDesc = body.getString("actionDesc");
		//비고사항
		description = body.getString("description");*/
		
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");//UL_DEFECT에 저장할 데이터 테이블
		
		IDataRow row = null;
		String state = null;
		
		for (int i = 0, len = dt.size(); i < len; i++) {
			
			row = dt.getRow(i);
			state = row.getString("_STATE_");

			switch (state) {

			case UpsertState.UPDATE:
				getUpdateData(row);
				break;
			}	
		}
	}
	
	private void getUpdateData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException, ParseException
	{
		UlDefectData data = new UlDefectData();
		UlDefectKey key = data.key();
		
		key.setDocid(row.getString("DOCID"));
		
		data = data.selectOne();
		
		if(data == null)
		{		
			throw new InValidDataException("InValidData001", String.format("DocId = %s", row.getString("DOCID")));
		}
		
		data.setLargecategory(row.getString("LARGECATEGORY"));
		data.setSmallcategroy(row.getString("SMALLCATEGROY"));
		data.setCompletestate(row.getString("COMPLETESTATE"));
		data.setActiontype(row.getString("ACTIONTYPE"));
		
		data.setExportdate(StringUtil.isNullOrEmpty(row.getString("EXPORTDATE"))?null:insertDateFormat.parse(row.getString("EXPORTDATE")));
		data.setReasondesc(row.getString("REASONDESC"));
		data.setActiondesc(row.getString("ACTIONDESC"));
		data.setDescription(row.getString("DESCRIPTION"));
		
		//대응처리일 = 조치완료일 - 제품반출일
		//제품반출일 없으면 "미반출" 표기 => DB Data Type int 이기 떄문에 UI 상에서 처리 / codeclassId = DefectDayCode
		
		//Date 조치완료일
		Date dteActionDate =  data.getActiondate();
		if(dteActionDate != null && !StringUtil.isNullOrEmpty(row.getString("EXPORTDATE"))) 
		{//조치완료일이 있는경우
			
			SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
			
			//Date 제품반출일
			Date dteExportDate = dateFormat.parse(row.getString("EXPORTDATE"));
		
	        long calDate = dteActionDate.getTime() - dteExportDate.getTime(); 
	        long calDateDays = calDate / (24*60*60*1000); 
	        
	        int intCalDay = Math.round(calDateDays);
	        
	        data.setActionday(intCalDay);			
		}

		data.update();
		
	}

}
