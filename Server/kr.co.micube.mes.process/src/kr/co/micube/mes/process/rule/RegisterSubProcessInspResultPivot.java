package kr.co.micube.mes.process.rule;

import java.text.ParseException;

import kr.co.micube.common.mes.constant.ProcessClass;
import kr.co.micube.common.mes.service.CtSubSegmentSpecDetailService;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.mes.service.UlSubProcessWorkResultDetailService;
import kr.co.micube.common.mes.service.UlSubProcessWorkResultService;
import kr.co.micube.common.mes.so.CtSubsegmentspecdetailData;
import kr.co.micube.common.mes.so.CtSubsegmentspecdetailKey;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.UlSubprocessworkresultData;
import kr.co.micube.common.mes.so.UlSubprocessworkresultKey;
import kr.co.micube.common.mes.so.UlSubprocessworkresultdetailData;
import kr.co.micube.common.mes.so.UlSubprocessworkresultdetailKey;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 조립
 * 설               명	: 가공 세부공정 검사실적 등록(pivot)
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-06-01
 * 수   정   이   력	: 
 * 				  
 */

public class RegisterSubProcessInspResultPivot extends DatasetRule {

	// 트랜잭션 정보
	private TxnInfo txnInfo;

	// 파라미터
	private String lotId; 				// LOT ID
	private String subProcessSegmentId; // 세부공정 ID
	private String specDefIdVersion;	// 스펙 ID 버전
	private IDataTable inspValues; 		// 검사실적 리스트(컬럼 : seq, parameterid columns)

	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		SfLotService.validateProcessClass(this.lotId, ProcessClass.ASSEMBLY);						// 조립 LOT인지 검증
		SfLotData lotData = SfLotService.getLot(this.lotId);
		UlSubprocessworkresultData workResult = UlSubProcessWorkResultService.getSubProcessWorkResult(this.lotId,
				lotData.getProcesssegmentid(), this.subProcessSegmentId);
		if (!Constant.LOTSTATE_INPRODUCTION.equals(lotData.getLotstate())) {
			// 이미 확정된 실적입니다.
			throw new SystemException("SubProcessIsFinished");
		}		
		deleteInspValues(workResult);
		insertInspValues(workResult);
	}

	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);

		// 파라미터
		this.lotId = body.getString("lotid");
		this.subProcessSegmentId = body.getString("subprocesssegmentid");
		this.specDefIdVersion = body.getString("specdefidversion");

		IDataSet ds = this.getRequestDataset();
		this.inspValues = ds.getTable("list");
	}
	
	// 세부공정 검사실적 삭제 
	private void deleteInspValues(UlSubprocessworkresultData workResult) throws SystemException {
		UlSubprocessworkresultKey workResultKey = workResult.key();
		ISQLCondition cond = new SQLCondition(false);
		cond.set(UlSubprocessworkresultdetailData.Workresulthistkey, workResultKey.getTxnhistkey());
		UlSubprocessworkresultdetailData data = new UlSubprocessworkresultdetailData();
		ISQLDataList<UlSubprocessworkresultdetailData> list = data.select(cond);
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		for(int i = 0; i < list.size(); i++) {
			UlSubprocessworkresultdetailData eachData = list.get(i);
			UlSubprocessworkresultdetailKey eachKey = eachData.key();
			if(eachKey.getSeq() > 0) {
				batch.add(eachData, SQLUpsertType.DELETE);
			}
		}
		batch.execute();
	}

	// 세부공정 검사실적 등록(Insert)
	private void insertInspValues(UlSubprocessworkresultData workResult) throws SystemException {
		ISQLDataList<CtSubsegmentspecdetailData> specDetailDataList = CtSubSegmentSpecDetailService.getSubSegmentSpecDetail(workResult.getSpecdefid(), this.subProcessSegmentId, this.specDefIdVersion);
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		for (int i = 0; i < this.inspValues.size(); i++) {
			IDataRow row = this.inspValues.getRow(i);
			for (String col : row.toMap().keySet()) {
				if(col.equals("SEQ") || col.equals("_STATE_") || row.getInteger("SEQ") == 0 || col.equals("ISSCRAP") || col.equals("ISDEFECT")) {
					continue;
				}
				CtSubsegmentspecdetailData specDetailData = getSubSegmentDetail(specDetailDataList, col);
				if(!StringUtils.isNullOrEmpty(row.getString(col)) || row.getBoolean("ISDEFECT")) {
					UlSubProcessWorkResultDetailService.createSubProcessWorkResultDetail(batch, workResult, specDetailData,
							Constant.ASTERISK, row.getInteger("SEQ"), row.getString(col), row.getBoolean("ISDEFECT") ? Constant.YES : Constant.NO, this.txnInfo);
				}
			}
		}
		batch.execute();
	}

	// 세부공정 스펙 상세목록 중 parameterId 에 해당하는 항목을 찾아 반환한다.
	private CtSubsegmentspecdetailData getSubSegmentDetail(ISQLDataList<CtSubsegmentspecdetailData> specDetailData, String parameterId) throws SystemException {
		for (int i = 0; i < specDetailData.size(); i++) {
			CtSubsegmentspecdetailData eachData = specDetailData.get(i);
			CtSubsegmentspecdetailKey eachKey = eachData.key();
			if (eachKey.getParameterid().equals(parameterId)) {
				return eachData;
			}
		}
		// 스펙에 등록되지 않은 파라미터입니다. {0}
		throw new SystemException("ParameterIsNotInSpec", String.format("ParameterId=%s", parameterId));
	}
}
