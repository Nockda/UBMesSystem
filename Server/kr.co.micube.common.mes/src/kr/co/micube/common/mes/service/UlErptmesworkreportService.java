package kr.co.micube.common.mes.service;

import java.text.SimpleDateFormat;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.ErpInterfaceAudType;
import kr.co.micube.common.mes.so.SfAreaData;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfProductdefinitionData;
import kr.co.micube.common.mes.so.SfWarehouseData;
import kr.co.micube.common.mes.so.SfWorkorderData;
import kr.co.micube.common.mes.so.UlErptmesworkreportData;
import kr.co.micube.common.mes.so.UlProcessworkresultData;
import kr.co.micube.common.mes.util.DateFunction;
import kr.co.micube.common.mes.util.MathFunction;
import kr.co.micube.common.util.QueryProvider;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.standard.service.UserService;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.tool.so.mes.UserData;

public class UlErptmesworkreportService {

	// ERP I/F 테이블에 생산실적 등록
	
	/**
	 * UlProcessworkresult 데이터를 기준으로 생산실적 ERP I/F 로컬 테이블에 데이터를 저장한다. 
	 * @param lotId LOT ID
	 * @param processSegmentId 공정 ID
	 * @param workDate 작업일자(yyyyMMdd)
	 * @param txnInfo 트랜잭션 정보
	 * @return 
	 * @throws Throwable 
	 */
	public static UlErptmesworkreportData createUlErptmesworkreport(String lotId, String processSegmentId, String workDate, TxnInfo txnInfo) throws Throwable {
		SfLotData lotData = SfLotService.getLot(lotId);
		SfWorkorderData woData = SfWorkorderService.getWorkorder(lotData.getWorkorderid());
		UlProcessworkresultData workResult = UlProcessWorkResultService.getProcessWorkResult(lotId, processSegmentId);

		String workStartTime = new SimpleDateFormat("HHmm").format(workResult.getWorkstarttime());
		String workEndTime = new SimpleDateFormat("HHmm").format(workResult.getWorkendtime());

		SfAreaData areaData = SfAreaService.getArea(lotData.getAreaid());
		SfWarehouseData warehouseData = SfWarehouseService.getWarehouse(areaData.getWarehouseid());
		UserData user = UserService.getUser(workResult.getChargeuserid());
		
		SfProductdefinitionData prodDefData = SfProductDefinitionService.getProductdefinition(lotData.getProductdefid(), lotData.getProductdefversion());
		
		Integer erp_empno = 0;
		try
		{
			erp_empno = Integer.valueOf(user.extendedColumn("ERP_EMPNO").toString());
		}
		catch(Exception e)	// NOTE : 도급 직원등은 ERP 사번이 없다
		{
		}
		UlErptmesworkreportData data = new UlErptmesworkreportData();
		data.setMeskey(lotId); 								// 실적 MES key
		data.setMesseq(1); 									// 실적 순번
		data.setAudtype(ErpInterfaceAudType.ADD);			// 실적 AUD 구분
		data.setCrtdatetime(SQLService.toDate()); 			// 생성시간
		data.setRecvyn(Constant.NO); 						// 수신여부 : N
		data.setWorkdate(workDate); 						// 작업일자
		data.setWorkorderseq(woData.getWorkorderseq());		// 작업지시 SEQ
		data.setWorkorderserl(woData.getWorkorderserl());	// 작업지시 SERL
		data.setWorkorderno(lotData.getWorkorderid());		// 작업지시 번호
		data.setWhseq(warehouseData.getWarehouseseq());		// 창고코드
		data.setDeptseq(woData.getDeptseq());				// 부서코드
		data.setEmpseq(erp_empno);							// 작업자
		data.setItemseq(woData.getItemseq()); 				// 품목 SEQ
		data.setItemno(prodDefData.getPartnumber());		// 품번
		data.setUnitseq(woData.getUnitseq());				// 단위 SEQ
		data.setProdokqty(workResult.getWorkendqty());		// 양품수량
		data.setProdbadqty(0D);								// 불량수량 	(공정 불량실적 관리하지 않음. 0 고정)
		data.setFieldwhseq(warehouseData.getWarehouseseq());	// 현장창고코드
		// data.setRemark();								// 비고
		data.setWorkstarttime(workStartTime);				// 작업시작 시간(HHmm)
		data.setWorkendtime(workEndTime);					// 작업완료 시간(HHmm)
		data.setWorkhour(MathFunction.round(DateFunction.dateDiffInHours(lotData.getTrackintime(), lotData.getTrackouttime()), 2));	// 작업시간(단위:시간)
		data.setWorkerqty(Integer.valueOf(getNumberOfWorkers(lotId, processSegmentId)).doubleValue());		// 작업자 수
		data.setTossyn(Constant.NO);						// ERP 전송 여부
		data.setInterfacetxnhistkey(Generate.createTimeKey());
		data.txnInfo().set(txnInfo.getTransaction());		
		data.insert();
		return data;
	}

	// LOT의 해당공정 작업자 수
	private static int getNumberOfWorkers(String lotId, String processSegmentId) throws DatabaseException {
		Map<String, Object> param = new HashMap<String, Object>();
		param.put("LOTID", lotId);
		List<Map<String, Object>> result = QueryProvider.select("GetWorkerQty", "00001", param);
		return Integer.valueOf(result.get(0).get("WORKERQTY").toString()).intValue();
	}
	
	/**
	 * UlProcessworkresult 데이터를 기준으로 생산실적 ERP I/F 로컬 테이블에 데이터를 저장한다. 
	 * @param lotId LOT ID
	 * @param workDate 작업일자(yyyyMMdd)
	 * @param txnInfo 트랜잭션 정보
	 * @return 
	 * @throws Throwable 
	 */
	public static UlErptmesworkreportData createEmptyUlErptmesworkreport(String lotId, String workDate, TxnInfo txnInfo) throws Throwable {
		SfLotData lotData = SfLotService.getLot(lotId);
		SfWorkorderData woData = SfWorkorderService.getWorkorder(lotData.getWorkorderid());

		SfAreaData areaData = SfAreaService.getArea(lotData.getAreaid());
		SfWarehouseData warehouseData = SfWarehouseService.getWarehouse(areaData.getWarehouseid());
		UserData user = UserService.getUser(txnInfo.getTxnUser());
		
		SfProductdefinitionData prodDefData = SfProductDefinitionService.getProductdefinition(lotData.getProductdefid(), lotData.getProductdefversion());
		
		UlErptmesworkreportData data = new UlErptmesworkreportData();
		data.setMeskey(lotId); 								// 실적 MES key
		data.setMesseq(1); 									// 실적 순번
		data.setAudtype(ErpInterfaceAudType.ADD);			// 실적 AUD 구분
		data.setCrtdatetime(SQLService.toDate()); 			// 생성시간
		data.setRecvyn(Constant.NO); 						// 수신여부 : N
		data.setWorkdate(workDate); 						// 작업일자
		data.setWorkorderseq(woData.getWorkorderseq());		// 작업지시 SEQ
		data.setWorkorderserl(woData.getWorkorderserl());	// 작업지시 SERL
		data.setWorkorderno(lotData.getWorkorderid());		// 작업지시 번호
		data.setWhseq(warehouseData.getWarehouseseq());		// 창고코드
		data.setDeptseq(woData.getDeptseq());				// 부서코드
		data.setEmpseq(Integer.valueOf(user.extendedColumn("ERP_EMPNO").toString()));	// 작업자
		data.setItemseq(woData.getItemseq()); 				// 품목 SEQ
		data.setItemno(prodDefData.getPartnumber());		// 품번
		data.setUnitseq(woData.getUnitseq());				// 단위 SEQ
		data.setProdokqty(0D);								// 양품수량
		data.setProdbadqty(0D);								// 불량수량	(공정 불량실적 관리하지 않음. 0 고정)
		data.setFieldwhseq(warehouseData.getWarehouseseq());	// 현장창고코드
		data.setRemark("생산투입 실적 I/F 용 가상실적");			// 비고
		data.setWorkstarttime("0000");						// 작업시작 시간(HHmm)
		data.setWorkendtime("0000");						// 작업완료 시간(HHmm)
		data.setWorkhour(0D);								// 작업시간(단위:시간)
		data.setWorkerqty(1D);								// 작업자 수
		data.setTossyn(Constant.NO);						// ERP 전송 여부
		data.txnInfo().set(txnInfo.getTransaction());		
		data.insert();
		return data;
	}
}
