package kr.co.micube.mes.quality.rule;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlCapaData;
import kr.co.micube.common.mes.so.UlCapaKey;
import kr.co.micube.common.mes.so.UlDefectData;
import kr.co.micube.common.mes.so.UlDefectKey;
import kr.co.micube.common.util.QueryProvider;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.standard.service.IdService;
import kr.co.micube.commons.factory.util.StringUtil;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 품질 관리 > 불량 관리 > 불량품 통지서 등록
 * 설               명	: 불량품 통지서를 등록 및 수정 한다.
 * 생      성      자	: 강유라
 * 생      성      일	: 2020-04-23
 * 수   정   이   력	: 2020-10-14 | 이준용 | ClaimNo매핑 이후 수정 가능하도록 프로세스 변경 
 */

public class SaveDefectRegist extends DatasetRule {
	
	//불량 통지서 발행번호 채번을 위한 트렌젝션 정보
	TxnInfo txnInfo = null;
	SimpleDateFormat insertDateFormat = new SimpleDateFormat("yyyy-MM-dd");

	@Override
	public void doEvent() throws Throwable {
	
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");//UL_DEFECT에 저장할 데이터 테이블
		txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
		
		IDataRow row = null;
		String state = null;
		
		for (int i = 0, len = dt.size(); i < len; i++) {
			
			row = dt.getRow(i);
			state = row.getString("_STATE_");

			switch (state) {
			case UpsertState.INSERT:
				getInsertData(row);
				break;

			case UpsertState.UPDATE:
				getUpdateData(row);
				break;
			}	
		}
		
	}
	
	private void getInsertData(IDataRow row) throws Throwable
	{
		UlDefectData data = new UlDefectData();
		UlDefectKey key = data.key();

		String defectDocId = GetDefectRegistNO(txnInfo);
		String claimNo =row.getString("CLAIMNUMBER");
		
		key.setDocid(defectDocId);
		
		data.setPublishdate(insertDateFormat.parse(row.getString("PUBLISHDATE")));
		data.setProgressstate("Registration");
		data.setClaimnumber(claimNo);
		data.setDepartmentid(row.getString("DEPARTMENTID"));
		data.setFindid(row.getString("FINDID"));
		data.setDetectid(row.getString("DETECTID"));
//		data.setItemid(row.getString("DEFECTITEMID"));
		data.setItemid(row.getString("DEFECTITEMNUMBER"));
		data.setCompanyid(row.getString("COMPANYID"));
		data.setDrawingnumber(row.getString("DRAWINGNUMBER"));
		
		
		data.setPaymentdate(StringUtil.isNullOrEmpty(row.getString("PAYMENTDATE"))?null:insertDateFormat.parse(row.getString("PAYMENTDATE")));
		data.setPaymentqty(StringUtil.isNullOrEmpty(row.getString("PAYMENTQTY"))?0.0:Double.valueOf(row.getString("PAYMENTQTY")));
			
		data.setUnitprice(StringUtil.isNullOrEmpty(row.getString("UNITPRICE"))?0.0:Double.valueOf(row.getString("UNITPRICE")));
		data.setDefectdate(StringUtil.isNullOrEmpty(row.getString("DEFECTDATE"))?null:insertDateFormat.parse(row.getString("DEFECTDATE")));
		data.setDefectqty(StringUtil.isNullOrEmpty(row.getString("DEFECTQTY"))?0.0:Double.valueOf(row.getString("DEFECTQTY")));

		
		data.setDefectprice(StringUtil.isNullOrEmpty(row.getString("DEFECTPRICE"))?0.0:Double.valueOf(row.getString("DEFECTPRICE")));
		data.setRecurrcnt(GetReCurrCNT(row.getString("DEFECTITEMID"), row.getString("COMPANYID")));
		data.setDefectdesc(row.getString("DEFECTDESC"));

		
		//UL_CAPA 테이블의 DEFECTDOCID UPDATE
		if(!StringUtil.isNullOrEmpty(claimNo))
		GetUpdateCapaData(defectDocId, claimNo);
		
		data.insert();	
		
	}

	private void getUpdateData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException, ParseException
	{
		UlDefectData data = new UlDefectData();
		UlDefectKey key = data.key();
		
		String defectDocId = row.getString("DOCID");
		String claimNo =row.getString("CLAIMNUMBER");
		
		
		key.setDocid(defectDocId);
		
		data = data.selectOne();
		
		if(data == null)
		{		
			throw new InValidDataException("InValidData001", String.format("DocId = %s", row.getString("DOCID")));

		}
		
		data.setClaimnumber(claimNo);
		data.setDepartmentid(row.getString("DEPARTMENTID"));
		data.setFindid(row.getString("FINDID"));
		data.setDetectid(row.getString("DETECTID"));
		data.setDrawingnumber(row.getString("DRAWINGNUMBER"));	
		
		data.setPaymentdate(StringUtil.isNullOrEmpty(row.getString("PAYMENTDATE"))?null:insertDateFormat.parse(row.getString("PAYMENTDATE")));
		data.setPaymentqty(StringUtil.isNullOrEmpty(row.getString("PAYMENTQTY"))?0.0:Double.valueOf(row.getString("PAYMENTQTY")));
			
		data.setUnitprice(StringUtil.isNullOrEmpty(row.getString("UNITPRICE"))?0.0:Double.valueOf(row.getString("UNITPRICE")));
		data.setDefectdate(StringUtil.isNullOrEmpty(row.getString("DEFECTDATE"))?null:insertDateFormat.parse(row.getString("DEFECTDATE")));
		data.setDefectqty(StringUtil.isNullOrEmpty(row.getString("DEFECTQTY"))?0.0:Double.valueOf(row.getString("DEFECTQTY")));
		
		data.setDefectprice(StringUtil.isNullOrEmpty(row.getString("DEFECTPRICE"))?0.0:Double.valueOf(row.getString("DEFECTPRICE")));
		
		data.setDefectdesc(row.getString("DEFECTDESC"));
		
		// 기존 프로세스 주석처리(153 ~ 155) - 이준용(2020.10.15)
		//UL_CAPA 테이블의 DEFECTDOCID UPDATE
		//if(!StringUtil.isNullOrEmpty(claimNo))
		//GetUpdateCapaData(defectDocId, claimNo);
		
		if(!StringUtil.isNullOrEmpty(claimNo)) {
			//ClaimNo Mapping여부 확인
			if(!CheckedMappingClaimNumber(defectDocId, claimNo)) {
				//UL_CAPA 테이블의 DEFECTDOCID UPDATE
				GetUpdateCapaData(defectDocId, claimNo);
			}
		}
		
		data.update();
		
	}
	
	private boolean CheckedMappingClaimNumber(String defectDocId, String claimNo) throws DatabaseException, InValidDataException {
		
		boolean result = false;
		
		Map<String, Object> defclaimNoMap = new HashMap<>();
		defclaimNoMap.put("DEFECTDOCID", defectDocId);
		defclaimNoMap.put("CLAIMNUMBER", claimNo);
		
		List<Map<String, Object>> resultMap = QueryProvider.select("GetDefClaimMappingInfo", "00001", defclaimNoMap);
		
		if(resultMap.size() > 0) {
			return true;
		}
		//true : 기존에 저장된 맵핑정보
		//false : 신규맵핑
		return result;
	}
	
	//재발생 횟수를 구하는 함수
	private int GetReCurrCNT(String itemId, String companyId) throws DatabaseException
	{
		int reCurrCNT = 0;
		
		Map<String, Object> recurrCNTMap = new HashMap<>();
		recurrCNTMap.put("ITEMID", itemId);
		recurrCNTMap.put("COMPANYID", companyId);
		
		List<Map<String, Object>> resultMap = QueryProvider.select("GetDefectReCurrentCNT", "00001", recurrCNTMap);
		
		if (resultMap.size() > 0)
			reCurrCNT = Integer.valueOf(resultMap.get(0).get("RECURRCNT").toString()) + 1;
		
		
		return reCurrCNT;
	}
	
	//클레임 번호 저장시 시정예방 테이블 업데이트
	private void GetUpdateCapaData(String defectDocId, String claimNo) throws DatabaseException, InValidDataException
	{		
		Map<String, Object> capaDocMap = new HashMap<>();
		capaDocMap.put("CLAIMNUMBER", claimNo);
	
		List<Map<String, Object>> resultMap = QueryProvider.select("GetCapaDocIdToUpdate", "00001", capaDocMap);
		
		if (resultMap.size() > 0)
		{//업데이트 할 DocID
			String capaDocId = resultMap.get(0).get("DOCID").toString();
			
			UlCapaData capaData = new UlCapaData();
			UlCapaKey capaKey = capaData.key();
			
			capaKey.setDocid(capaDocId);
			
			capaData = capaData.selectOne();
			

			if(capaData == null)
			{//수정할 데이터 없음 => 에러				
				throw new InValidDataException("InValidData001", String.format("DocId = %s", capaDocId));
			}
			
			capaData.setDefectdocid(defectDocId);
			capaData.update();
			
		}
		else
		{
			//해당 클레임 번호를 가진 발행 번호 없을 때 => 에러			
				throw new InValidDataException("InValidData001", String.format("ClaimNumber = %s", claimNo));
		}
	}
	
	// 불량통지서 발행 번호
	private String GetDefectRegistNO(TxnInfo txnInfo) throws Throwable {
		
		String docId = CreateDefectRegistNO(txnInfo);
		return docId;
	}
	
	// 불량통지서 발행 채번 
	private  String CreateDefectRegistNO(TxnInfo trans) throws Throwable {
			
		// FK + 년도  + - + 00001
		//SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy");
		//Date now = new Date();
		
		//String year = dateFormat.format(now).substring(2, 4);
		
		String year = FiscalYear();
		
		List<String> list = new ArrayList<String>();
		list.add(year);
		
  		List<String> idList = IdService.createId("DefectRegistNo", 1, list, trans);

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
}
