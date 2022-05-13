package kr.co.micube.mes.quality.rule;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Base64;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.so.UlCapaData;
import kr.co.micube.common.mes.so.UlCapaKey;
import kr.co.micube.common.mes.so.UlCapadtlData;
import kr.co.micube.common.mes.so.UlCapadtlKey;
import kr.co.micube.common.mes.so.UlQmfileData;
import kr.co.micube.common.mes.so.UlQmfileKey;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.common.util.QueryProvider;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.standard.service.IdService;
import kr.co.micube.commons.factory.util.StringUtil;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;


/*
 * 프  로  그  램  명	: 품질관리 > 클레임 관리 > 시정예방조치서 발행대장
 * 설               명	: 시정예방조치서 발행대장에서 저장,수정,삭제하는 룰이다.
 * 생      성      자	: 유태근
 * 생      성      일	: 2020-04-22
 * 수   정   이   력	: 2022-05-11 주시은 | X번관리대장에서 진행상태가 취소일 때 시정예방조치서의 진행상태도 취소할 수 있게 수정
 * 				  
 */

public class SaveClaimManagerReg extends DatasetRule {
	
	private String docId;
	private int detailMaxSequence = 0;
	
	public void doEvent() throws Throwable {
		
		IMessage msg = this.getMessage().get(); // 메세지
		IData jmsg = msg.get(); // IData 형태로 변환
		IData body = jmsg.get(MessageFormat.Body); // 메세지부의 Body부 추출
		
		// 저장, 수정, 삭제일때
		if (body.getString("flag").equals("Upsert"))
		{
			IDataSet ds = this.getRequestDataset();
			IDataTable dt = ds.getTable("list");
			IDataTable fdt = ds.getTable("fileList");
			IDataTable tdt = ds.getTable("teamActionList");
			docId = body.getString("docId");
			
			ISQLUpsertBatch batch = new SQLUpsertBatch();
			
			/***************************************************
			 * 시정예방조치서정보 저장
			****************************************************/
			IDataRow row = null;
			String state = null;

			for (int i = 0, len = dt.size(); i < len; i++) 
			{		
				row = dt.getRow(i);
				state = row.getString("_STATE_");
				
				switch (state) 
				{
					case UpsertState.INSERT:
						GetInsertData(row, batch);
						break;
					case UpsertState.UPDATE:
						GetUpdateData(row, batch);
						break;
					case UpsertState.DELETE:
						GetDeleteData(row, batch);
						break;
				}
			}
			
			/***************************************************
			 * 한개의 시정예방조치서에 해당하는 파일정보 저장
			****************************************************/
			row = null;
			state = null;
			
			for (int i = 0, len = fdt.size(); i < len; i++)
			{
				row = fdt.getRow(i);
				state = row.getString("_STATE_");
				
				switch (state) 
				{
					case UpsertState.INSERT:
						GetFileInsertData(row, batch);
						break;
					case UpsertState.UPDATE:
						GetFileUpdateData(row, batch);
						break;
					case UpsertState.DELETE:
						GetFileDeleteData(row, batch);
						break;
				}				
			}
			
			/***************************************************
			 * 한개의 시정예방조치서에 해당하는 팀별 조치정보 데이터 저장
			****************************************************/
			row = null;
			state = null;
			
			for (int i = 0, len = tdt.size(); i < len; i++)
			{
				row = tdt.getRow(i);
				state = row.getString("_STATE_");
				
				switch (state) 
				{
					case UpsertState.INSERT:
						GetTeamInsertData(row, batch);
						break;
					case UpsertState.UPDATE:
						GetTeamUpdateData(row, batch);
						break;
					case UpsertState.DELETE:
						GetTeamDeleteData(row, batch);
						break;
				}				
			}
			
			batch.execute();	
		}
		// 진행상태 수정일때
		else if (body.getString("flag").equals("StateChange"))
		{
			ISQLUpsertBatch batch = new SQLUpsertBatch();
			UpdateProgressState(body.getString("docId"), body.getString("state"), batch);
			batch.execute();
		}
	}
	
	/********************************************************************************************
	 * UL_CAPA INSERT
	*********************************************************************************************/
	public ISQLUpsertBatch GetInsertData(IDataRow row, ISQLUpsertBatch batch) throws Throwable
	{		
		UlCapaData data = new UlCapaData();
		UlCapaKey key = data.key();
		
		if (StringUtils.isNullOrEmpty(docId)) docId = CreatePublishNumber(TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData()));
		
		key.setDocid(docId);
		
		// 그리드부
		data.setClaimnumber(row.getString("CLAIMNUMBER")); // Claim No
		data.setPublishdate(StandardDateFormat(row.getString("PUBLISHDATE"))); // 발행일자
		data.setCustomerid(row.getString("CUSTOMERID")); // 고객사 ID
		data.setClaimtype(row.getString("CLAIMTYPE")); // Claim 구분
		data.setReqdepartmentid(row.getString("REQDEPARTMENTID")); // 요청부서
		data.setRequser(row.getString("REQUSER")); // 요청자
		data.setPublishtype(row.getString("PUBLISHTYPE")); // 발행구분
		if (!StringUtils.isNullOrEmpty(row.getString("REQCONFDATE"))) data.setReqconfdate(StandardDateFormat(row.getString("REQCONFDATE"))); // 회담희망일
		data.setDescription(row.getString("DESCRIPTION")); // 비고사항
		data.setProgressstate("CorrectiveActionPublish"); // 진행상황 - 시정조치발행
		data.setIndate(StringUtils.isNullOrEmpty(row.getString("INDATE")) ? null : StandardDateFormat(row.getString("INDATE"))); // 제품입고일자
		data.setConfirmuser(row.getString("CONFIRMUSER")); // 입고확인자
		data.setResponsedate(StringUtil.isNullOrEmpty(row.getString("ACTIONDATE")) 
				|| StringUtil.isNullOrEmpty(row.getString("INDATE")) ? null : BetweenDay(row.getString("INDATE"), row.getString("ACTIONDATE"))); // 현장대응 소요일
		
		batch.add(data, SQLUpsertType.INSERT);
		
		return batch;
	}
	
	/********************************************************************************************
	 * UL_CAPA UPDATE
	*********************************************************************************************/
	public ISQLUpsertBatch GetUpdateData(IDataRow row, ISQLUpsertBatch batch) throws Throwable
	{
		UlCapaData data = new UlCapaData();
		UlCapaKey key = data.key();
		
		key.setDocid(docId);
		
		data = data.selectOne();
		
		// 그리드부
		data.setClaimnumber(row.getString("CLAIMNUMBER")); // Claim No
		data.setPublishdate(StandardDateFormat(row.getString("PUBLISHDATE"))); // 발행일자
		data.setCustomerid(row.getString("CUSTOMERID")); // 고객사 ID
		data.setClaimtype(row.getString("CLAIMTYPE")); // Claim 구분
		data.setReqdepartmentid(row.getString("REQDEPARTMENTID")); // 요청부서
		data.setRequser(row.getString("REQUSER")); // 요청자
		data.setPublishtype(row.getString("PUBLISHTYPE")); // 발행구분
		if (!StringUtils.isNullOrEmpty(row.getString("REQCONFDATE"))) data.setReqconfdate(StandardDateFormat(row.getString("REQCONFDATE"))); // 회담희망일
		data.setDescription(row.getString("DESCRIPTION")); // 비고사항
		data.setIndate(StringUtils.isNullOrEmpty(row.getString("INDATE")) ? null : StandardDateFormat(row.getString("INDATE"))); // 제품입고일자
		data.setConfirmuser(row.getString("CONFIRMUSER")); // 입고확인자
		data.setResponsedate(StringUtil.isNullOrEmpty(row.getString("ACTIONDATE")) 
							|| StringUtil.isNullOrEmpty(row.getString("INDATE")) ? null : BetweenDay(row.getString("INDATE"), row.getString("ACTIONDATE"))); // 현장대응 소요일
		
		batch.add(data, SQLUpsertType.UPDATE);
		
		return batch;
	}
	
	/********************************************************************************************
	 * UL_CAPA DELETE
	*********************************************************************************************/
	public ISQLUpsertBatch GetDeleteData(IDataRow row, ISQLUpsertBatch batch) throws Throwable
	{
		DeleteSubData(row.getString("DOCID"), batch);
		
		UlCapaData data = new UlCapaData();
		UlCapaKey key = data.key();
		
		key.setDocid(row.getString("DOCID"));
		
		data = data.selectOne();
		
		batch.add(data, SQLUpsertType.DELETE);
		
		return batch;
	}
	
	/********************************************************************************************
	 * UL_QMFILE INSERT
	*********************************************************************************************/
	public ISQLUpsertBatch GetFileInsertData(IDataRow row, ISQLUpsertBatch batch) throws Throwable
	{			
		UlQmfileData data = new UlQmfileData();
		UlQmfileKey key = data.key();
		
		key.setDocid(docId);
		key.setSeqnumber(row.getInteger("SEQNUMBER"));
		
		data.setDescription(row.getString("DESCRIPTION"));
		data.setFilename(row.getString("FILENAME"));
		data.setFiledata(Base64.getDecoder().decode(row.getString("FILEDATA").getBytes("UTF-8")));
		
		batch.add(data, SQLUpsertType.INSERT);
		
		return batch;
	}
	
	/********************************************************************************************
	 * UL_QMFILE UPDATE
	*********************************************************************************************/
	public ISQLUpsertBatch GetFileUpdateData(IDataRow row, ISQLUpsertBatch batch) throws Throwable
	{			
		UlQmfileData data = new UlQmfileData();
		UlQmfileKey key = data.key();
		
		key.setDocid(docId);
		key.setSeqnumber(row.getInteger("SEQNUMBER"));
		
		data = data.selectOne();
		
		data.setDescription(row.getString("DESCRIPTION"));
		
		batch.add(data, SQLUpsertType.UPDATE);
		
		return batch;
	}
	
	/********************************************************************************************
	 * UL_QMFILE DELETE
	*********************************************************************************************/
	public ISQLUpsertBatch GetFileDeleteData(IDataRow row, ISQLUpsertBatch batch) throws Throwable
	{			
		UlQmfileData data = new UlQmfileData();
		UlQmfileKey key = data.key();
		
		key.setDocid(docId);
		key.setSeqnumber(row.getInteger("SEQNUMBER"));
		
		data = data.selectOne();
		
		batch.add(data, SQLUpsertType.DELETE);
		
		return batch;
	}
	
	/********************************************************************************************
	 * UL_CAPADTL INSERT
	*********************************************************************************************/
	private ISQLUpsertBatch GetTeamInsertData(IDataRow row, ISQLUpsertBatch batch) throws Throwable
	{			
		detailMaxSequence += GetMaxSequence(docId);
		
		UlCapadtlData data = new UlCapadtlData();
		UlCapadtlKey key = data.key();
		
		key.setDocid(docId);
		key.setDocsequence(detailMaxSequence);
		
		data = data.selectOne(); 
		
		if (data != null)
		{
			throw new InValidDataException("InvalidException001");
		}
		
		data = new UlCapadtlData();
		key = data.key();
		
		key.setDocid(docId);
		key.setDocsequence(detailMaxSequence);
		
		data.setTeamid(row.getString("TEAMID"));
		data.setDefecttype(row.getString("DEFECTTYPE"));
		data.setReasonteamid(row.getString("REASONTEAMID"));
		data.setReasontype(row.getString("REASONTYPE"));
		data.setDescription(row.getString("PROGRESSDESC"));
		data.setReasondesc(row.getString("REASONDESC"));
		data.setActiondesc(row.getString("ACTIONDESC"));
		data.setActiondate(StringUtils.isNullOrEmpty(row.getString("ACTIONDATE")) ? null : StandardDateFormat(row.getString("ACTIONDATE")));
		data.setValidstate("Valid");
		
		batch.add(data, SQLUpsertType.INSERT);
		
		return batch;
	}
	
	/********************************************************************************************
	 * UL_CAPADTL UPDATE
	*********************************************************************************************/
	public ISQLUpsertBatch GetTeamUpdateData(IDataRow row, ISQLUpsertBatch batch) throws Throwable
	{			
		UlCapadtlData data = new UlCapadtlData();
		UlCapadtlKey key = data.key();
		
		key.setDocid(docId);
		key.setDocsequence(row.getInteger("DOCSEQUENCE"));
		
		data = data.selectOne();
		
		data.setTeamid(row.getString("TEAMID"));
		data.setDefecttype(row.getString("DEFECTTYPE"));
		data.setReasonteamid(row.getString("REASONTEAMID"));
		data.setReasontype(row.getString("REASONTYPE"));
		data.setDescription(row.getString("PROGRESSDESC"));
		data.setReasondesc(row.getString("REASONDESC"));
		data.setActiondesc(row.getString("ACTIONDESC"));
		data.setActiondate(StringUtils.isNullOrEmpty(row.getString("ACTIONDATE")) ? null : StandardDateFormat(row.getString("ACTIONDATE")));
		data.setValidstate("Valid");
		
		batch.add(data, SQLUpsertType.UPDATE);
		
		return batch;
	}
	
	/********************************************************************************************
	 * UL_CAPADTL DELETE
	*********************************************************************************************/
	public ISQLUpsertBatch GetTeamDeleteData(IDataRow row, ISQLUpsertBatch batch) throws Throwable
	{			
		UlCapadtlData data = new UlCapadtlData();
		UlCapadtlKey key = data.key();
		
		key.setDocid(docId);
		key.setDocsequence(row.getInteger("DOCSEQUENCE"));
		
		data = data.selectOne();
		
		batch.add(data, SQLUpsertType.DELETE);
		
		return batch;
	}
	
	/********************************************************************************************
	 * UL_CAPA DELETE시 팀별 조치정보 및 파일정보 같이 삭제
	*********************************************************************************************/
	public void DeleteSubData(String deleteDocId, ISQLUpsertBatch batch) throws Throwable
	{
		Map<String, Object> param = new HashMap<>();
		param.put("DOCID", deleteDocId);
		
		// UL_CAPADTL 하위 데이터
		List<Map<String, Object>> detailResult = QueryProvider.select("GetTeamActionInfo", "00001", param);
		
		for (int i = 0; i < detailResult.size(); i++)
		{
			DeleteCapaDetailData(detailResult.get(i).get("DOCID").toString(), Integer.parseInt(detailResult.get(i).get("DOCSEQUENCE").toString()), batch);
		}
		
		// UL_QMFILE 하위 데이터
		List<Map<String, Object>> fileResult = QueryProvider.select("GetClaimManagerFileList", "00001", param);
		
		for (int i = 0; i < fileResult.size(); i++)
		{
			DeleteCapaFileData(fileResult.get(i).get("DOCID").toString(), Integer.parseInt(fileResult.get(i).get("SEQNUMBER").toString()), batch);
		}		
	}
	
	public void DeleteCapaDetailData(String deleteDocId, int sequence, ISQLUpsertBatch batch) throws Throwable
	{
		UlCapadtlData data = new UlCapadtlData();
		UlCapadtlKey key = data.key();
		
		key.setDocid(deleteDocId);
		key.setDocsequence(sequence);
		
		data = data.selectOne();
		
		batch.add(data, SQLUpsertType.DELETE);
	}
	
	public void DeleteCapaFileData(String deleteDocId, int seqNumber, ISQLUpsertBatch batch) throws Throwable
	{
		UlQmfileData data = new UlQmfileData();
		UlQmfileKey key = data.key();
			
		key.setDocid(deleteDocId);
		key.setSeqnumber(seqNumber);
		
		data = data.selectOne();
		
		batch.add(data, SQLUpsertType.DELETE);
	}
	
	/********************************************************************************************
	 * UL_CAPA PROGRESSSTATE UPDATE
	 * @param docId : 발행번호
	 * @param state : 진행상황코드
	*********************************************************************************************/
	public ISQLUpsertBatch UpdateProgressState(String docId, String state, ISQLUpsertBatch batch) throws Throwable
	{
		UlCapaData data = new UlCapaData();
		UlCapaKey key = data.key();
		
		key.setDocid(docId);
		
		data = data.selectOne();
		
		switch (state)
		{
			case "CorrectiveActionPublish": // 시정조치발행
				break;
			case "ClaimRequest": // Claim요청
				break;
			case "ClaimReceipt": // Claim접수
				data.setRecieptdate(new Date());
				break;
			case "ResponseCompleted": // 발행완료
				data.setCompletedate(new Date());
				data.setCompleteday(BetweenDay(data.getRecieptdate().toString(),Today()));
				break;
			case "ActionCompleted": // 조치완료
				data.setActiondate(new Date());
				data.setActionday(BetweenDay(data.getCompletedate().toString(),Today()));
				data.setResponsedate(data.getIndate() == null ? null : BetweenDay(data.getIndate().toString(),Today()));
				break;
			case "PublishCancel": // 발행취소
				data.setRecieptdate(null);
				data.setCompletedate(null);
				data.setActiondate(null);
				data.setCompleteday(null);
				data.setActionday(null);
				data.setResponsedate(null);
				break;
			// 2022-05-11 주시은
			case "Cancel": // 취소
				break;
		}
		
		data.setProgressstate(state);
		
		batch.add(data, SQLUpsertType.UPDATE);
		
		return batch;
	}
	
	/********************************************************************************************
	 * UL_CAPA DOCID(발행번호) 채번
	 * @param trans : 트랜잭션 정보
	*********************************************************************************************/
	private String CreatePublishNumber(TxnInfo trans) throws Throwable 
	{	
//		// YK + 20(년도) + -(하이픈) + 00001(일련번호 5자리)로 구성
//		SimpleDateFormat dateFormat = new SimpleDateFormat("yyyyMMdd");
//		Date today = new Date();
//		
//		String year = dateFormat.format(today).substring(2, 4);
		
		String year = FiscalYear();
		
		List<String> list = new ArrayList<String>();
		list.add(year);
		
  		List<String> idList = IdService.createId("PublishSequence", 1, list, trans);
  		
  		return idList.get(0).toString();
	}
	
   /********************************************************************************************
    * 회계년도 계산
   *********************************************************************************************/
   private String FiscalYear() throws Throwable 
   {
      Calendar cal = Calendar.getInstance();
      cal.setTime(new Date());
      int month = cal.get(Calendar.MONTH);
      if(month < 6)
      {
         cal.add(Calendar.YEAR, -1);
      }
      int year = cal.get(Calendar.YEAR);
      return String.valueOf(year).substring(2);
   }
	
	/********************************************************************************************
	 * 오늘날짜 반환함수
	*********************************************************************************************/
	private String Today() throws Throwable 
	{	
		SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
  		
		Date today = new Date();
		String todayStr = dateFormat.format(today);
				
		return todayStr;
	}
	
	/********************************************************************************************
	 * 두 날짜 사이 계산
	 * @param frDateStr : 이전날짜
	 * @param toDateStr : 다음날짜
	*********************************************************************************************/
	private int BetweenDay(String frDateStr, String toDateSrt) throws Throwable 
	{	
		final int MILLI_SECONDS_PER_DAY = 24 * 60 * 60 * 1000;
		Date frDate = new SimpleDateFormat("yyyy-MM-dd").parse(frDateStr);
		Date toDate = new SimpleDateFormat("yyyy-MM-dd").parse(toDateSrt);

        long difference = (toDate.getTime() - frDate.getTime()) / MILLI_SECONDS_PER_DAY;
        
        return (int)difference;
	}
	
	/********************************************************************************************
	 * 날짜 데이터 포멧 yyyy-MM-dd로 변경
	*********************************************************************************************/
	private Date StandardDateFormat(String date) throws Throwable 
	{
		SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");

		if (StringUtils.isNullOrEmpty(date)) return null;
		
		Date formatDate = format.parse(date);

		return formatDate;
	}
	
	/********************************************************************************************
	 * UL_CAPADTL의 발행번호 하나에 해당하는 Max Sequence 구하기
	*********************************************************************************************/
	private int GetMaxSequence(String docId) throws Throwable 
	{
		int maxSeq = 0;
		
		Map<String, Object> param = new HashMap<>();
		param.put("DOCID", docId);
		
		List<Map<String, Object>> result = QueryProvider.select("GetCapaDetailMaxSequence", "00001", param);
		
		maxSeq = (int)result.get(0).get("MAXSEQUENCE") + 1;
		
		return maxSeq;
	}
	
}
