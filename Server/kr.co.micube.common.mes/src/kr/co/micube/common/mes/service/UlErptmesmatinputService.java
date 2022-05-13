package kr.co.micube.common.mes.service;

import java.util.Date;

import kr.co.micube.common.mes.constant.ErpInterfaceAudType;
import kr.co.micube.common.mes.so.SfConsumabledefinitionData;
import kr.co.micube.common.mes.so.SfConsumemateriallotData;
import kr.co.micube.common.mes.so.UlErptmesmatinputData;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.core.util.Generate;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLDataList;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class UlErptmesmatinputService {
	
	/**
	 * SfConsumemateriallot 데이터를 기준으로 생상투입 ERP I/F 로컬 테이블에 데이터를 저장한다.
	 * 생산실적 없이 자재투입만 처리할때에도 양품수량 0인 생산실적 데이터를 I/F 해야한다.
	 * @param lotId LOT ID
	 * @param processSegmentId 공정 ID
	 * @param inputDate 투입일자(yyyyMMdd)
	 * @param txnInfo 트랜잭션 정보
	 * @return
	 * @throws SystemException 
	 */
	public static ISQLDataList<UlErptmesmatinputData> createUlErptmesmatinput(String lotId, String processSegmentId, String inputDate, TxnInfo txnInfo) throws SystemException {
		Date timeStamp = SQLService.toDate();
		ISQLDataList<UlErptmesmatinputData> result = new SQLDataList<UlErptmesmatinputData>(UlErptmesmatinputData.class);
		ISQLDataList<SfConsumemateriallotData> consumedMaterials = SfConsumeMaterialLotService.getConsumemateriallotList(lotId);
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		for (int i = 0; i < consumedMaterials.size(); i++) {
			SfConsumemateriallotData materialData = consumedMaterials.get(i);	
			result.add(insertUlErptmesmatinput(batch, lotId, i + 1, materialData.getMaterialdefid(), materialData.getConsumedqty(), inputDate, timeStamp, txnInfo));
		}
		batch.execute();
		return result;
	}

	// ERP I/F 테이블에 자재투입 등록
	private static UlErptmesmatinputData insertUlErptmesmatinput(ISQLUpsertBatch batch, String lotId, int inputSeq, String consumableDefId, Double consumedQty, String inputDate, Date timeStamp, TxnInfo txnInfo) throws SystemException {
		SfConsumabledefinitionData conDefData = SfConsumableDefinitionService.getConsumabledefinition(consumableDefId, Constant.ASTERISK);
		
		UlErptmesmatinputData data = new UlErptmesmatinputData();
		data.setMeskey(lotId);								// I/F MES Key
		data.setMesseq(inputSeq);							// I/F MES Seq
		data.setAudtype(ErpInterfaceAudType.ADD);			// AUD Type (Add, Update, Delete)
		data.setCrtdatetime(timeStamp);						// 생성시간
		data.setRecvyn(Constant.NO);						// ERP 수신여부			
		data.setInputdate(inputDate);						// 투입일자(yyyyMMdd)
		data.setItemseq(conDefData.getErp_consumabledefid());	// 자재 SEQ
		data.setItemno(conDefData.getPartnumber());				// 자재 ID
		data.setUnitseq(conDefData.getErp_unitid());		// 단위 SEQ						
		data.setInputqty(consumedQty);
		data.setTossyn(Constant.NO);						// ERP 전송여부
		data.setInterfacetxnhistkey(Generate.createTimeKey());
		data.txnInfo().set(txnInfo.getTransaction());
		batch.add(data, SQLUpsertType.INSERT);
		return data;
	}
}
