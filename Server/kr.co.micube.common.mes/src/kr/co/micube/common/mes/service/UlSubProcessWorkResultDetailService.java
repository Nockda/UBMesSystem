package kr.co.micube.common.mes.service;

import java.text.DecimalFormat;

import kr.co.micube.common.mes.constant.ParameterInputType;
import kr.co.micube.common.mes.constant.SpecType;
import kr.co.micube.common.mes.so.CtParameterdefinitionData;
import kr.co.micube.common.mes.so.CtSubsegmentspecdetailData;
import kr.co.micube.common.mes.so.CtSubsegmentspecdetailKey;
import kr.co.micube.common.mes.so.UlSubprocessworkresultData;
import kr.co.micube.common.mes.so.UlSubprocessworkresultKey;
import kr.co.micube.common.mes.so.UlSubprocessworkresultdetailData;
import kr.co.micube.common.mes.so.UlSubprocessworkresultdetailKey;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;

public class UlSubProcessWorkResultDetailService {

	/**
	 * 세부공정 검사실적 등록(Batch Insert)
	 * 
	 * @param batch          batch
	 * @param workResultData 세부공정 작업실적
	 * @param specDetailData 세부공정 검사항목
	 * @param pointId        포인트
	 * @param seq            순번
	 * @param value          값
	 * @throws SystemException
	 */
	public static void createSubProcessWorkResultDetail(ISQLUpsertBatch batch,
			UlSubprocessworkresultData workResultData, CtSubsegmentspecdetailData specDetailData, String pointId,
			int seq, String value, String isDefect, TxnInfo txnInfo) throws SystemException {
		UlSubprocessworkresultKey workResultKey = workResultData.key();
		CtSubsegmentspecdetailKey specDetailKey = specDetailData.key();

		CtParameterdefinitionData parameterData = CtParameterDefinitionService.getParameterDefinition(specDetailKey.getParameterid());
		
		UlSubprocessworkresultdetailData data = new UlSubprocessworkresultdetailData();
		UlSubprocessworkresultdetailKey key = data.key();
		key.setWorkresulthistkey(workResultKey.getTxnhistkey());
		key.setParameterid(specDetailKey.getParameterid());
		key.setPointid(pointId);
		key.setSeq(seq);
		if(!StringUtils.isNullOrEmpty(value) && ParameterInputType.FLOAT.equals(parameterData.getInputtype())) {
			DecimalFormat decimalFormat = new DecimalFormat("0.#########");
			data.setMeasurevalue(decimalFormat.format(Double.valueOf(value.replace(",", ""))));
		}
		else {
			data.setMeasurevalue(value);
		}
		data.setSpecdefid(specDetailKey.getSpecdefid());
		if(SpecType.BOTH.equals(specDetailData.getSpectype()) || SpecType.UPPER.equals(specDetailData.getSpectype())) { 
			data.setUsl(specDetailData.getUsl());
		}
		if(SpecType.BOTH.equals(specDetailData.getSpectype()) || SpecType.LOWER.equals(specDetailData.getSpectype())) {
			data.setLsl(specDetailData.getLsl());
		}
		data.setCsl(specDetailData.getCsl());
		data.setTarget(specDetailData.getTarget());
		data.setIsdefect(isDefect);
		data.txnInfo().set(txnInfo.getTransaction());
		batch.add(data, SQLUpsertType.INSERT);
	}

	/**
	 * 세부공정 검사실적 등록(Update/Insert)
	 * 
	 * @param workResultData 세부공정 작업실적
	 * @param specDetailData 세부공정 검사항목
	 * @param pointId        포인트
	 * @param seq            순번
	 * @param value          값
	 * @throws DatabaseException
	 */
	public static UlSubprocessworkresultdetailData createSubProcessWorkResultDetail(UlSubprocessworkresultData workResultData,
			CtSubsegmentspecdetailData specDetailData, String pointId, int seq, String value, TxnInfo txnInfo)
			throws DatabaseException {
		UlSubprocessworkresultKey workResultKey = workResultData.key();
		CtSubsegmentspecdetailKey specDetailKey = specDetailData.key();

		UlSubprocessworkresultdetailData data = new UlSubprocessworkresultdetailData();
		UlSubprocessworkresultdetailKey key = data.key();
		key.setWorkresulthistkey(workResultKey.getTxnhistkey());
		key.setParameterid(specDetailKey.getParameterid());
		key.setPointid(pointId);
		key.setSeq(seq);
		data = data.selectOne();
		if (data == null) {
			data = new UlSubprocessworkresultdetailData();
			key = data.key();
			key.setWorkresulthistkey(workResultKey.getTxnhistkey());
			key.setParameterid(specDetailKey.getParameterid());
			key.setPointid(pointId);
			key.setSeq(seq);
			data.setMeasurevalue(value);
			data.setSpecdefid(specDetailKey.getSpecdefid());
			data.setUsl(specDetailData.getUsl());
			data.setCsl(specDetailData.getCsl());
			data.setLsl(specDetailData.getLsl());
			data.setTarget(specDetailData.getTarget());
			data.txnInfo().set(txnInfo.getTransaction());
			data.insert();
		} else {
			data.setMeasurevalue(value);
			data.setSpecdefid(specDetailKey.getSpecdefid());
			data.setUsl(specDetailData.getUsl());
			data.setCsl(specDetailData.getCsl());
			data.setLsl(specDetailData.getLsl());
			data.setTarget(specDetailData.getTarget());
			data.txnInfo().set(txnInfo.getTransaction());
			data.update();
		}
		return data;
	}
}
