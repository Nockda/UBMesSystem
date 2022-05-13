package kr.co.micube.mes.quality.rule;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlDefectData;
import kr.co.micube.common.mes.so.UlDefectKey;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 품질 관리 > 불량 관리 > 불량품 통지서  / 불량품 통지서 관리 대장
 * 설               명	: 불량품 통지서를 상태를 업데이트 한다.
 * 생      성      자	: 강유라
 * 생      성      일	: 2020-04-23
 * 수   정   이   력	: 
 */

public class SaveDefectRegistChangeState  extends DatasetRule {
	
	

	@Override
	public void doEvent() throws Throwable {
		
		IMessage msg = this.getMessage().get();
		
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);
		
		// 발행번호
		String docId = body.getString("docId");
		//변경 할 상태
		String toChangeState = body.getString("toChangeState");

		//변경할 상태에 따른 분기		
		switch (toChangeState) {
		//등록 취소	
		case "CancelRegistration":
			getUpdateState(docId, toChangeState);
			break;
			
		//접수
		case "Receipt":
			getUpdateState(docId, toChangeState);
			getUpdateReceiptDate(docId);
			break;
			
		//통지서 발송
		case "SendNotice":
			getUpdateState(docId, toChangeState);
			getUpdateDeliveryDate(docId);
			break;
			
		//조치 완료	
		case "ActionCompleted":
			getUpdateState(docId, toChangeState);
			getUpdateActionDate(docId);
			break;
			
		//대책 완료	
		case "MeasuresCompleted":
			getUpdateState(docId, toChangeState);
			getUpdateCompleteDate(docId);
			break;
			
		//진행 취소	
		case "CancelProgress":
			getUpdateState(docId, toChangeState);
			break;
		}
	}
	
	//상태 업데이트 함수
	private void getUpdateState (String DocId, String toChangeState) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlDefectData data = new UlDefectData();
		UlDefectKey key = data.key();
		key.setDocid(DocId);
		
		data = data.selectOne();
		
		if(data == null)
		{		
			throw new InValidDataException("InValidData001", String.format("DocId = %s", DocId));
		}
		
		data.setProgressstate(toChangeState);
		
		data.update();		
	}	

	//접수상태로 바꿀 때 접수일 업데이트 함수
	private void getUpdateReceiptDate (String DocId) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		UlDefectData data = new UlDefectData();
		UlDefectKey key = data.key();
		key.setDocid(DocId);
		
		data = data.selectOne();
		
		if(data == null)
		{		
			throw new InValidDataException("InValidData001", String.format("DocId = %s", DocId));
		}
		

		Date now = new Date();
		

		data.setReceiptdate(now);
		
		data.update();		
	}	
	
	//통지서발송 상태로 바꿀 때 통지서발송일 업데이트 함수
	private void getUpdateDeliveryDate (String DocId) throws InValidDataException, DatabaseException, MESException, SystemException, ParseException
	{
		UlDefectData data = new UlDefectData();
		UlDefectKey key = data.key();
		key.setDocid(DocId);
		
		data = data.selectOne();
		
		if(data == null)
		{		
			throw new InValidDataException("InValidData001", String.format("DocId = %s", DocId));
		}
		
		SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
		Date now = new Date();
		
		String dateString = dateFormat.format(now);
		//data.setDeliverydate(dateStrnowing);
		data.setDeliverydate(now);
		
		//대책소요일 = 대책완료일 - 불량통지서 발행일
		//대책완료일 없으면 "잔건" 표기 
		//불량통지서 발행일이 없으면 "미발행" 표기
		// => DB Data Type int 이기 떄문에 UI 상에서 처리 / codeclassId = DefectDayCode
		
		//Date 대책완료일
		Date dteCompleteDate = data.getCompletedate();
		if(dteCompleteDate != null) 
		{//대책완료일이 있는경우
			
			//Date 불량통지서 발행일
			Date dteDeliverDate = dateFormat.parse(dateString);
			
			CalculateDate(dteCompleteDate, dteDeliverDate);	
	        
	        data.setCompleteday(CalculateDate(dteCompleteDate, dteDeliverDate));		
		}
		
		data.update();		
	}
	
	//조치완료 상태로 바꿀 때 조치완료일 업데이트 함수
	private void getUpdateActionDate (String DocId) throws InValidDataException, DatabaseException, MESException, SystemException, ParseException
	{
		UlDefectData data = new UlDefectData();
		UlDefectKey key = data.key();
		key.setDocid(DocId);
		
		data = data.selectOne();
		
		if(data == null)
		{		
			throw new InValidDataException("InValidData001", String.format("DocId = %s", DocId));
		}
		
		SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
		Date now = new Date();
		
		String dateString = dateFormat.format(now);
		//data.setActiondate(dateString);
		data.setActiondate(now);
		
		//대응처리일 = 조치완료일 - 제품반출일
		//제품반출일 없으면 "미반출" 표기 => DB Data Type int 이기 떄문에 UI 상에서 처리 / codeclassId = DefectDayCode
		
		//Date 제품반출일
		Date dteExportDate = data.getExportdate();
		if(dteExportDate != null) 
		{//제품반출일이 있는경우
		
			//Date 조치완료일
			Date dteActionDate = dateFormat.parse(dateString);

	        data.setActionday(CalculateDate(dteActionDate, dteExportDate));			
		}
			
		data.update();		
	}
	
	//대책완료 상태로 바꿀 때 대책완료일 업데이트 함수
	private void getUpdateCompleteDate (String DocId) throws InValidDataException, DatabaseException, MESException, SystemException, ParseException
	{
		UlDefectData data = new UlDefectData();
		UlDefectKey key = data.key();
		key.setDocid(DocId);
		
		data = data.selectOne();
		
		if(data == null)
		{		
			throw new InValidDataException("InValidData001", String.format("DocId = %s", DocId));
		}
		
		SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
		Date now = new Date();
		
		String dateString = dateFormat.format(now);
		data.setCompletedate(now);
		
		//대책소요일 = 대책완료일 - 불량통지서 발행일
		//대책완료일 없으면 "잔건" 표기 
		//불량통지서 발행일이 없으면 "미발행" 표기
		// => DB Data Type int 이기 떄문에 UI 상에서 처리 / codeclassId = DefectDayCode

		//Date 불량통지서 발송일
		Date dteDeliverDate = data.getDeliverydate();
		if(dteDeliverDate != null) 
		{//불량통지서 발행일이 있는경우
			
			//Date 대책완료일
			Date dteCompleteDate = dateFormat.parse(dateString);		
	        
	        data.setCompleteday(CalculateDate(dteCompleteDate, dteDeliverDate));		
		}
		
		data.update();		
	}
	
	private int CalculateDate(Date fromDate, Date toDate)
	{
		long calDate = fromDate.getTime() - toDate.getTime(); 
        long calDateDays = calDate / (24*60*60*1000); 
        
        int intCalDay = Math.round(calDateDays);
        
		return intCalDay;		
	}
	
}
