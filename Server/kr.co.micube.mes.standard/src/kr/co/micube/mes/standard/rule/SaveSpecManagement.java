package kr.co.micube.mes.standard.rule;

import java.text.ParseException;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.CtSpecdefinitionData;
import kr.co.micube.common.mes.so.CtSpecdefinitionKey;
import kr.co.micube.common.mes.so.CtSpecdefinitionversionData;
import kr.co.micube.common.mes.so.CtSpecdefinitionversionKey;
import kr.co.micube.common.mes.so.CtSubsegmentspecData;
import kr.co.micube.common.mes.so.CtSubsegmentspecKey;
import kr.co.micube.common.mes.so.CtSubsegmentspecdetailData;
import kr.co.micube.common.mes.so.CtSubsegmentspecdetailKey;
import kr.co.micube.common.mes.util.CommonUtils;
import kr.co.micube.common.mes.util.LanguageUtils;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.so.EnterpriseData;
import kr.co.micube.commons.factory.so.PlantData;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.mes.UserData;
import kr.co.micube.tool.so.mes.UserKey;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명   : 기준정보 > 항목관리 > Spec 관리
 * 설               명   : 
 * 생      성      자   : 정승원
 * 생      성      일   : 2020-05-20
 * 수   정   이   력   : 2020-09-17 | 이준용 |세부공정 저장,수정시 VALIDSTATE 추가
 * 							 	  VALIDSTATE가 NULL로 저장되어 공정화면에서 조회가 되지 않았음.
 * 			    2021-06-08 | 정송은 | 스펙조회에서 스펙강제여부 컬럼 UPDATE 되도록 구조 변경으로 인해
 * 									UPDATE 로직에 스펙인 경우 로직 추가
 * 				2021-07-15 | 김지호 | 스펙 등록에서 스펙 버전 그리드 저장로직 추가
 * 								        스펙복사 시 파라미터 값 추가
 * 				2021-08-09 | 주시은 | 신규 등록시 스펙 버전 테이블 수정자에 생성자 등록되게끔 추가
 */

public class SaveSpecManagement extends DatasetRule{
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();      
		IDataTable specDt = ds.getTable("specList");
		IDataTable subSpecDt = ds.getTable("subSpecList");
		IDataTable subSpecDetailDt = ds.getTable("subSpecDetailList");
		
		IMessage msg = this.getMessage().get();
	    IData jmsg = msg.get();
	    IData body = jmsg.get(MessageFormat.Body);
	    String enterpriseId = body.get("enterpriseid");
	    String plantId = body.get("plantid");
	    String type = body.get("type");
	    String versionForCopy = body.getString("specversion");
	   	    
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		if("COPYSPEC".equals(type)) {
			IDataRow row = specDt.getRow(0);
			getInsertCopySpec(row, versionForCopy, subSpecDt, subSpecDetailDt, batch);
		} else {
			for(int i = 0; i < specDt.size(); i++)
			{
				IDataRow row = specDt.getRow(i);
				String state = row.getString("_STATE_");
	    	  
				switch (state) 
				{
				case UpsertState.INSERT:
					getInsertSpecData(row, batch, type, enterpriseId, plantId, subSpecDt, subSpecDetailDt);
					break;
				case UpsertState.UPDATE:
					getUpdateSpecData(row, batch, type, enterpriseId, plantId,  subSpecDt, subSpecDetailDt);
					break;
				case UpsertState.DELETE:
					getDeleteSpecData(row, batch, type);
					break;
				}
			}
		}		
		
		batch.execute();
	}
	
	/********************************************************************************************
	* COPYSPEC
	 * @throws SystemException 
	*********************************************************************************************/
	private void getInsertCopySpec(IDataRow row, String version, IDataTable subSpecDt, IDataTable subSpecDetailDt, ISQLUpsertBatch batch) throws SystemException {
	
		CtSubsegmentspecData subSpec;
		CtSubsegmentspecKey subSpecKey;
		IDataRow specRow = null;
		
		for(int i = 0; i < subSpecDt.size(); i++) {
			specRow = subSpecDt.getRow(i);
			
			subSpec = new CtSubsegmentspecData();
			subSpecKey = subSpec.key();
			
			subSpecKey
					.setSpecdefid(row.getString("SPECDEFID"))
					.setSpecsequence(specRow.getDouble("SPECSEQUENCE")) 
					.setSubprocesssegmentid(specRow.getString("SUBPROCESSSEGMENTID"))
					.setSpecdefidversion(version)
					;
			
			subSpec
					.setUsersequence(specRow.getString("USERSEQUENCE"))
					.setIsresult(specRow.getString("ISRESULT"))
					.setIsoutsourcing(specRow.getString("ISOUTSOURCING"))
					.setDescription(specRow.getString("DESCRIPTION"))
					.setValidstate(specRow.getString("VALIDSTATE"))
					.setIsmeasure(specRow.getString("ISMEASURE"))
					;
			
			batch.add(subSpec, SQLUpsertType.INSERT);
		}
	
			

		CtSubsegmentspecdetailData subSpecDetail;
		CtSubsegmentspecdetailKey subSpecDetailKey;
		IDataRow detailRow = null;
		
		for(int i = 0; i < subSpecDetailDt.size(); i++) {
			detailRow = subSpecDetailDt.getRow(i);
			
			subSpecDetail = new CtSubsegmentspecdetailData();
			subSpecDetailKey = subSpecDetail.key();
			
			subSpecDetailKey
						.setSpecdefid(row.getString("SPECDEFID"))
						.setParameterid(detailRow.getString("PARAMETERID"))
						.setSpecsequence(detailRow.getDouble("SPECSEQUENCE"))
						.setSpecdefidversion(version)
						;
			subSpecDetail
						.setSpectype(detailRow.getString("SPECTYPE"))
						.setLsl(detailRow.getDouble("LSL"))
						.setCsl(detailRow.getDouble("CSL"))
						.setUsl(detailRow.getDouble("USL"))
						.setTarget(detailRow.getString("TARGET"))
						.setDescription(detailRow.getString("DESCRIPTION"))
						.setValidstate(detailRow.getString("VALIDSTATE"))
						.setIsmeasure(detailRow.getString("ISMEASURE"))
						.setDisplaysequence(detailRow.getDouble("DISPLAYSEQUENCE"))
						.setIsspecforce(detailRow.getString("ISSPECFORCE"))
						;
			
			batch.add(subSpecDetail, SQLUpsertType.INSERT);
		}		
		
	}
	
	/********************************************************************************************
	* SPECVERSION
	 * @throws SystemException 
	*********************************************************************************************/
	private void getInsertPrevSpecData(IDataRow row, IDataTable subSpecDt, IDataTable subSpecDetailDt, ISQLUpsertBatch batch, String type) throws SystemException {
		switch(type)
		{
		case "INSERT":
			CtSubsegmentspecData subSpec;
			CtSubsegmentspecKey subSpecKey;
			
			// 이전버전에 대한 Invalid 처리위한 데이터 SO
			CtSubsegmentspecData reSubSpec;
			CtSubsegmentspecKey reSubSpecKey;
			
			IDataRow specRow = null;
			
			for(int i = 0; i < subSpecDt.size(); i++) {
				specRow = subSpecDt.getRow(i);
				
				int _next = Integer.parseInt(specRow.getString("SPECDEFIDVERSION")) + 1;
				String str_next = String.valueOf(_next);
				
				subSpec = new CtSubsegmentspecData();
				subSpecKey = subSpec.key();
				
				subSpecKey
						.setSpecdefid(row.getString("SPECDEFID"))
						.setSpecsequence(specRow.getDouble("SPECSEQUENCE"))
						.setSubprocesssegmentid(specRow.getString("SUBPROCESSSEGMENTID"))
						.setSpecdefidversion(str_next)
						;
				
				subSpec
						.setUsersequence(specRow.getString("USERSEQUENCE"))
						.setIsresult(specRow.getString("ISRESULT"))
						.setIsoutsourcing(specRow.getString("ISOUTSOURCING"))
						.setDescription(specRow.getString("DESCRIPTION"))
						.setValidstate(specRow.getString("VALIDSTATE"))
						.setIsmeasure(specRow.getString("ISMEASURE"))
						;
				
				batch.add(subSpec, SQLUpsertType.INSERT);
				
				// Invalid 처리
				reSubSpec = new CtSubsegmentspecData();
				reSubSpecKey = reSubSpec.key();
				
				reSubSpecKey
						.setSpecdefid(row.getString("SPECDEFID"))
						.setSpecsequence(specRow.getDouble("SPECSEQUENCE"))
						.setSubprocesssegmentid(specRow.getString("SUBPROCESSSEGMENTID"))
						.setSpecdefidversion(specRow.getString("SPECDEFIDVERSION"))
						;
				
				reSubSpec = reSubSpec.selectOne();
				
				reSubSpec
						.setValidstate("Invalid")
						;
				
				batch.add(reSubSpec, SQLUpsertType.UPDATE);
			}
		
			CtSubsegmentspecdetailData subSpecDetail;
			CtSubsegmentspecdetailKey subSpecDetailKey;
			
			CtSubsegmentspecdetailData reSubSpecDetail;
			CtSubsegmentspecdetailKey reSubSpecDetailKey;
			
			IDataRow detailRow = null;
			
			for(int i = 0; i < subSpecDetailDt.size(); i++) {
				detailRow = subSpecDetailDt.getRow(i);
				
				subSpecDetail = new CtSubsegmentspecdetailData();
				subSpecDetailKey = subSpecDetail.key();
				
				int _next = Integer.parseInt(detailRow.getString("SPECDEFIDVERSION")) + 1;
				String str_next = String.valueOf(_next);
				
				subSpecDetailKey
							.setSpecdefid(row.getString("SPECDEFID"))
							.setParameterid(detailRow.getString("PARAMETERID"))
							.setSpecsequence(detailRow.getDouble("SPECSEQUENCE"))
							.setSpecdefidversion(str_next) // 2021-07-13 김지호 추가
							;
				subSpecDetail
							.setSpectype(detailRow.getString("SPECTYPE"))
							.setLsl(detailRow.getDouble("LSL"))
							.setCsl(detailRow.getDouble("CSL"))
							.setUsl(detailRow.getDouble("USL"))
							.setTarget(detailRow.getString("TARGET"))
							.setDescription(detailRow.getString("DESCRIPTION"))
							.setValidstate(detailRow.getString("VALIDSTATE"))
							.setIsmeasure(detailRow.getString("ISMEASURE"))
							.setDisplaysequence(detailRow.getDouble("DISPLAYSEQUENCE"))
							.setIsspecforce(detailRow.getString("ISSPECFORCE"))
							;
				
				batch.add(subSpecDetail, SQLUpsertType.INSERT);
				
				// Invalid 처리
				reSubSpecDetail = new CtSubsegmentspecdetailData();
				reSubSpecDetailKey = reSubSpecDetail.key();
				
				reSubSpecDetailKey
							.setSpecdefid(row.getString("SPECDEFID"))
							.setParameterid(detailRow.getString("PARAMETERID"))
							.setSpecsequence(detailRow.getDouble("SPECSEQUENCE"))
							.setSpecdefidversion(specRow.getString("SPECDEFIDVERSION"))
							;
				
				reSubSpecDetail = reSubSpecDetail.selectOne();
				
				reSubSpecDetail
							.setValidstate("Invalid")
							;
				
				batch.add(reSubSpecDetail, SQLUpsertType.UPDATE);
			}
			
			break;
		}
	}

	/********************************************************************************************
	* INSERT
	 * @throws ParseException 
	*********************************************************************************************/
	private void getInsertSpecData(IDataRow row, ISQLUpsertBatch batch, String type, String enterpriseid, String plantid, IDataTable subSpecDt, IDataTable subSpecDetailDt) throws InValidDataException, DatabaseException, MESException, SystemException, ParseException
	{
		
		TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
		
		switch(type)
		{
		case "MAIN":
			CtSpecdefinitionData spec = new CtSpecdefinitionData();
			CtSpecdefinitionKey specKey = spec.key();
			specKey.setSpecdefid(row.getString("SPECDEFID"));
			
			spec = spec.selectOne();
			if(spec != null)
			{
				throw new InValidDataException("InValidData002", String.format("Spec Id = %s", row.getString("SPECDEFID")));
			}
			
			spec = new CtSpecdefinitionData();
			specKey = spec.key();
			specKey.setSpecdefid(row.getString("SPECDEFID"));
			
			String dictionaryId = Generate.createID();
			spec.setDictionaryid(dictionaryId);
			spec.setSpecdefname(row.getString("SPECDEFNAME$$KO-KR"));
			spec.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
			spec.setIsdivide(row.getString("ISDIVIDE"));
			spec.setEnterpriseid(enterpriseid);
			spec.setPlantid(plantid);
			spec.setValidstate(row.getString("VALIDSTATE"));
			spec.setLasttxnid(this.getClass().getSimpleName());

			batch.add(spec, SQLUpsertType.INSERT);
			
			//다국어		
			Map<String, String> dictionaryMap = new HashMap<>();
			List<String> languageTypes = LanguageUtils.getLanguageTypes();
			for (String lang : languageTypes) {
				if (!row.containsKey(CtSpecdefinitionData.Specdefname.toUpperCase() + "$$" + lang.toUpperCase()))
					continue;
				
				dictionaryMap.put(lang, row.getString(CtSpecdefinitionData.Specdefname.toUpperCase() + "$$" + lang.toUpperCase()));
			}
			
			CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
			
			// 스펙버전 테이블  INSERT
			CtSpecdefinitionversionData mainRev = new CtSpecdefinitionversionData();
			CtSpecdefinitionversionKey mainRevKey = mainRev.key();
			
			mainRevKey
				.setSpecdefid(row.getString("SPECDEFID"))
				.setSpecdefidversion("1")
				;
			mainRev
				.setReasonforchange("")
				.setValidstate("Valid")
				.setModifier(txnInfo.getTxnUser())
				.setModifiedtime(txnInfo.getTxnTime())
				.setLasttxnid(this.getClass().getSimpleName())
				;
			
			batch.add(mainRev, SQLUpsertType.INSERT);
			
			break;
		case "SUB":
			CtSubsegmentspecData subSpec = new CtSubsegmentspecData();
			CtSubsegmentspecKey subSpecKey = subSpec.key();
			subSpecKey.setSpecdefid(row.getString("SPECDEFID"));
			subSpecKey.setSubprocesssegmentid(row.getString("SUBPROCESSSEGMENTID"));
			subSpecKey.setSpecsequence(row.getDouble("SPECSEQUENCE"));
			subSpecKey.setSpecdefidversion(row.getString("SPECDEFIDVERSION"));
			
			subSpec = subSpec.selectOne();
			if(subSpec != null) 
			{
				throw new InValidDataException("InValidData002", String.format("Spec Id = %s, SubSegment Id = %s, Seq = %d"
						, row.getString("SPECDEFID"), row.getString("SUBPROCESSSEGMENTID"), row.getInteger("SPECSEQUENCE")));
			}
			
			subSpec = new CtSubsegmentspecData();
			subSpecKey = subSpec.key();
			subSpecKey.setSpecdefid(row.getString("SPECDEFID"));
			subSpecKey.setSubprocesssegmentid(row.getString("SUBPROCESSSEGMENTID"));
			subSpecKey.setSpecsequence(row.getDouble("SPECSEQUENCE"));
			subSpecKey.setSpecdefidversion(row.getString("SPECDEFIDVERSION"));
			
			subSpec.setUsersequence(row.getString("USERSEQUENCE"));
			subSpec.setIsresult(row.getString("ISRESULT"));
			subSpec.setIsoutsourcing(row.getString("ISOUTSOURCING"));
			subSpec.setLasttxnid(this.getClass().getSimpleName());
			
			subSpec.setValidstate(row.getString("VALIDSTATE"));
			
			batch.add(subSpec, SQLUpsertType.INSERT);
			break;
		case "ITEM":
			CtSubsegmentspecdetailData subSpecDetail = new CtSubsegmentspecdetailData();
			CtSubsegmentspecdetailKey subSpecDetailKey = subSpecDetail.key();
			subSpecDetailKey.setSpecdefid(row.getString("SPECDEFID"));
			//subSpecDetailKey.setSubprocesssegmentid(row.getString("SUBPROCESSSEGMENTID"));
			subSpecDetailKey.setParameterid(row.getString("PARAMETERID"));
			subSpecDetailKey.setSpecsequence(row.getDouble("SPECSEQUENCE"));
			subSpecDetailKey.setSpecdefidversion(row.getString("SPECDEFIDVERSION"));
			
			subSpecDetail = subSpecDetail.selectOne();
			if(subSpecDetail != null)
			{
				throw new InValidDataException("InValidData002", String.format("Spec Id = %s, SubProcesssegment Id = %s, Parameter Id = %s, Seq = %s"
						, row.getString("SPECDEFID"), row.getString("SUBPROCESSSEGMENTID"), row.getString("PARAMETERID"), row.getString("SPECSEQUENCE")));
			}
			
			subSpecDetail = new CtSubsegmentspecdetailData();
			subSpecDetailKey = subSpecDetail.key();
			subSpecDetailKey.setSpecdefid(row.getString("SPECDEFID"));
			//subSpecDetailKey.setSubprocesssegmentid(row.getString("SUBPROCESSSEGMENTID"));
			subSpecDetailKey.setParameterid(row.getString("PARAMETERID"));
			subSpecDetailKey.setSpecsequence(row.getDouble("SPECSEQUENCE"));
			subSpecDetailKey.setSpecdefidversion(row.getString("SPECDEFIDVERSION"));
			
			subSpecDetail.setLsl(row.getDouble("LSL"));
			subSpecDetail.setUsl(row.getDouble("USL"));
			subSpecDetail.setSpectype(row.getString("SPECTYPE"));
			subSpecDetail.setIsmeasure(row.getString("ISMEASURE"));
			subSpecDetail.setDisplaysequence(row.getDouble("DISPLAYSEQUENCE"));
			subSpecDetail.setIsspecforce(row.getString("ISSPECFORCE"));
			subSpecDetail.setValidstate(row.getString("VALIDSTATE"));
			subSpecDetail.setLasttxnid(this.getClass().getSimpleName());
			
			batch.add(subSpecDetail, SQLUpsertType.INSERT);
			break;
			
		case "SPECVERSION":
			CtSpecdefinitionversionData rev = new CtSpecdefinitionversionData();
			CtSpecdefinitionversionKey revKey = rev.key();
			
			revKey
				.setSpecdefid(row.getString("SPECDEFID"))
				.setSpecdefidversion(row.getString("SPECDEFIDVERSION"))
				;
			rev
				.setReasonforchange(row.getString("REASONFORCHANGE"))
				.setValidstate("Valid")
				.setModifier(txnInfo.getTxnUser())
				.setModifiedtime(txnInfo.getTxnTime())
				.setLasttxnid(this.getClass().getSimpleName())
				;
			
			batch.add(rev, SQLUpsertType.INSERT);
			
			// 이전 버전은 자동으로 Invalid 시켜줘야 함
			CtSpecdefinitionversionData preRev = new CtSpecdefinitionversionData();
			CtSpecdefinitionversionKey preRevKey = preRev.key();
			
			int version = Integer.parseInt(row.getString("SPECDEFIDVERSION")) -1;
			
			preRevKey
					.setSpecdefid(row.getString("SPECDEFID"))
					.setSpecdefidversion(String.valueOf(version))
					;
			
			preRev = preRev.selectOne();
			
			preRev.setValidstate("Invalid");
			
			batch.add(preRev, SQLUpsertType.UPDATE);
			
			getInsertPrevSpecData(row, subSpecDt, subSpecDetailDt, batch, "INSERT");
			
			break;
		}
	
			
	}
	
	/********************************************************************************************
	* UPDATE
	*********************************************************************************************/
	private void getUpdateSpecData(IDataRow row, ISQLUpsertBatch batch, String type, String enterpriseid, String plantid, IDataTable subSpecDt, IDataTable subSpecDetailDt) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		switch(type)
		{
		case "MAIN":
			CtSpecdefinitionData spec = new CtSpecdefinitionData();
			CtSpecdefinitionKey specKey = spec.key();
			specKey.setSpecdefid(row.getString("SPECDEFID"));
			
			spec = spec.selectOne();
			if(spec == null)
			{
				throw new InValidDataException("InValidData001", String.format("Spec Id : %s", row.getString("SPECID")));
			}
			
			
			//다국어
			String dictionaryId = spec.getDictionaryid();
			if(StringUtils.isNullOrEmpty(dictionaryId))
			{
				dictionaryId = Generate.createID();
				spec.setDictionaryid(dictionaryId);
			}
			
			spec.setDictionaryid(dictionaryId);
			spec.setSpecdefname(row.getString("SPECDEFNAME$$KO-KR"));
			spec.setProcesssegmentid(row.getString("PROCESSSEGMENTID"));
			spec.setIsdivide(row.getString("ISDIVIDE"));
			spec.setValidstate(row.getString("VALIDSTATE"));
			spec.setLasttxnid(this.getClass().getSimpleName());
			
			batch.add(spec, SQLUpsertType.UPDATE);
			
			Map<String, String> dictionaryMap = new HashMap<>();
			List<String> languageTypes = LanguageUtils.getLanguageTypes();
			for (String lang : languageTypes) {
				if (!row.containsKey(CtSpecdefinitionData.Specdefname.toUpperCase() + "$$" + lang.toUpperCase()))
					continue;
				
				dictionaryMap.put(lang, row.getString(CtSpecdefinitionData.Specdefname.toUpperCase() + "$$" + lang.toUpperCase()));
			}
			
			CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
			break;
		case "SUB":
			CtSubsegmentspecData subSpec = new CtSubsegmentspecData();
			CtSubsegmentspecKey subSpecKey = subSpec.key();
			subSpecKey.setSpecdefid(row.getString("SPECDEFID"));
			subSpecKey.setSubprocesssegmentid(row.getString("SUBPROCESSSEGMENTID"));
			subSpecKey.setSpecsequence(row.getDouble("SPECSEQUENCE"));
			subSpecKey.setSpecdefidversion(row.getString("SPECDEFIDVERSION"));
			
			subSpec = subSpec.selectOne();
			if(subSpec == null) 
			{
				throw new InValidDataException("InValidData001", String.format("Spec Id = %s, SubSegment Id = %s, Seq = %s"
						, row.getString("SPECDEFID"), row.getString("SUBPROCESSSEGMENTID"), row.getString("SPECSEQUENCE")));
			}
			
			subSpec.setUsersequence(row.getString("USERSEQUENCE"));
			subSpec.setIsresult(row.getString("ISRESULT"));
			subSpec.setIsoutsourcing(row.getString("ISOUTSOURCING"));
			subSpec.setLasttxnid(this.getClass().getSimpleName());
			
			subSpec.setValidstate(row.getString("VALIDSTATE"));
			
			batch.add(subSpec, SQLUpsertType.UPDATE);
			break;
		case "ITEM":
			CtSubsegmentspecdetailData subSpecDetail = new CtSubsegmentspecdetailData();
			CtSubsegmentspecdetailKey subSpecDetailKey = subSpecDetail.key();
			subSpecDetailKey.setSpecdefid(row.getString("SPECDEFID"));
			//subSpecDetailKey.setSubprocesssegmentid(row.getString("SUBPROCESSSEGMENTID"));
			subSpecDetailKey.setParameterid(row.getString("PARAMETERID"));
			subSpecDetailKey.setSpecsequence(row.getDouble("SPECSEQUENCE"));
			subSpecDetailKey.setSpecdefidversion(row.getString("SPECDEFIDVERSION"));
			
			subSpecDetail = subSpecDetail.selectOne();
			if(subSpecDetail == null)
			{
				throw new InValidDataException("InValidData001", String.format("Spec Id = %s, SubProcesssegment Id = %s, Parameter Id = %s, Seq = %s"
						, row.getString("SPECDEFID"), row.getString("SUBPROCESSSEGMENTID"), row.getString("PARAMETERID"), row.getString("SPECSEQUENCE")));
			}
	
			subSpecDetail.setLsl(row.getDouble("LSL"));
			subSpecDetail.setUsl(row.getDouble("USL"));
			subSpecDetail.setSpectype(row.getString("SPECTYPE"));
			subSpecDetail.setIsmeasure(row.getString("ISMEASURE"));
			subSpecDetail.setDisplaysequence(row.getDouble("DISPLAYSEQUENCE"));
			subSpecDetail.setIsspecforce(row.getString("ISSPECFORCE"));
			subSpecDetail.setValidstate(row.getString("VALIDSTATE"));
			subSpecDetail.setLasttxnid(this.getClass().getSimpleName());
			
			batch.add(subSpecDetail, SQLUpsertType.UPDATE);
			break;
		case "SPEC" :
			//스펙강제여부 컬럼 update
			CtSubsegmentspecdetailData detailData = new CtSubsegmentspecdetailData();
			CtSubsegmentspecdetailKey detailKey = detailData.key();
			
			//PK
			String specDefId = row.getString("SPECDEFID");
			String parameterId = row.getString("PARAMETERID");
			double seq = row.getDouble("SPECSEQUENCE");
			
			String subProcessSegId = row.getString("SUBPROCESSSEGMENTID");
			String isSpecForce = row.getString("ISSPECFORCE"); 
			
			detailKey.setParameterid(parameterId);
			detailKey.setSpecdefid(specDefId);
			detailKey.setSpecsequence(seq);
			detailKey.setSpecdefidversion(row.getString("SPECDEFIDVERSION"));
			
			detailData = detailData.selectOne();
			
			if(detailData == null) {
				throw new InValidDataException("InValidData001", String.format("Spec Id = %s, SubProcesssegment Id = %s, Parameter Id = %s, Seq = %f"
						,specDefId, subProcessSegId, parameterId, seq));
				
			}
			
			detailData.setIsspecforce(isSpecForce);
			
			batch.add(detailData, SQLUpsertType.UPDATE);
			break;
		case "SPECVERSION":
			CtSpecdefinitionversionData rev = new CtSpecdefinitionversionData();
			CtSpecdefinitionversionKey revKey = rev.key();
			
			revKey
				.setSpecdefid(row.getString("SPECDEFID"))
				.setSpecdefidversion(row.getString("SPECDEFIDVERSION"))
				;
			rev = rev.selectOne();
			
			rev
				.setReasonforchange(row.getString("REASONFORCHANGE"))
				.setLasttxnid(this.getClass().getSimpleName())
				;
			
			batch.add(rev, SQLUpsertType.UPDATE);
			
			getInsertPrevSpecData(row, subSpecDt, subSpecDetailDt, batch, "UPDATE");
			
			break;
		}
	}
	
	/********************************************************************************************
	* DELETE
	*********************************************************************************************/
	private void getDeleteSpecData(IDataRow row, ISQLUpsertBatch batch, String type) throws InValidDataException, DatabaseException, MESException, SystemException
	{		
		switch(type)
		{
		case "MAIN":
			CtSpecdefinitionData spec = new CtSpecdefinitionData();
			CtSpecdefinitionKey specKey = spec.key();
			specKey.setSpecdefid(row.getString("SPECDEFID"));
			
			spec = spec.selectOne();
			if(spec == null)
			{
				throw new InValidDataException("InValidData003", String.format("SpecId = %s", row.getString("SPECDEFID")));
			}
			
			batch.add(spec, SQLUpsertType.DELETE);
			
			//다국어
			String dictionaryId = spec.getDictionaryid();
			CommonUtils.deleteDictionaryData(batch, dictionaryId);
			
			
			//하위 정보 삭제 - CT_SUBSEGMENTSPEC
			CtSubsegmentspecData subSpec = new CtSubsegmentspecData();
			ISQLCondition cond = new SQLCondition(false);
			cond.set(CtSubsegmentspecData.Specdefid, row.getString("SPECDEFID"));
			
			ISQLDataList<CtSubsegmentspecData> subSpecList = subSpec.select(cond);
			
			if(subSpecList.size() > 0)
			{
				for(int i = 0; i < subSpecList.size(); i++)
				{
					subSpec = subSpecList.get(i);
					batch.add(subSpec, SQLUpsertType.DELETE);
				}
				
				//하위 정보 삭제 - CT_SUBSEGMENTSPECDETAIL
				cond.clear();
				
				CtSubsegmentspecdetailData subSpecDetail = new CtSubsegmentspecdetailData();
				cond.set(CtSubsegmentspecdetailData.Specdefid, row.getString("SPECDEFID"));
				
				ISQLDataList<CtSubsegmentspecdetailData> subSpecDetailList = subSpecDetail.select(cond);
				
				if(subSpecDetailList.size() > 0)
				{
					for(int i = 0; i < subSpecDetailList.size(); i++)
					{
						subSpecDetail = subSpecDetailList.get(i);
						batch.add(subSpecDetail, SQLUpsertType.DELETE);
					}
				}
			}
			
			// 스펙버전 삭제
			CtSpecdefinitionversionData specVersion = new CtSpecdefinitionversionData();
			ISQLCondition cond3 = new SQLCondition(false);
			cond3.set(CtSubsegmentspecData.Specdefid, row.getString("SPECDEFID"));
			
			ISQLDataList<CtSpecdefinitionversionData> specVersionList = specVersion.select(cond3);
			
			if(specVersionList.size() > 0)
			{
				for(int i = 0; i < specVersionList.size(); i++)
				{
					specVersion = specVersionList.get(i);
					batch.add(specVersion, SQLUpsertType.DELETE);
				}
			}

			break;
		case "SUB":
			CtSubsegmentspecData subSpec2 = new CtSubsegmentspecData();
			CtSubsegmentspecKey subSpec2Key = subSpec2.key();
			subSpec2Key.setSpecdefid(row.getString("SPECDEFID"));
			subSpec2Key.setSubprocesssegmentid(row.getString("SUBPROCESSSEGMENTID"));
			subSpec2Key.setSpecsequence(row.getDouble("SPECSEQUENCE"));
			subSpec2Key.setSpecdefidversion(row.getString("SPECDEFIDVERSION"));
			
			subSpec2 = subSpec2.selectOne();
			if(subSpec2 == null)
			{
				throw new InValidDataException("InValidData003", String.format("Spec Id = %s, SubSegment Id = %s, Seq = %s"
						, row.getString("SPECDEFID"), row.getString("SUBPROCESSSEGMENTID"), row.getString("SPECSEQUENCE")));
			}
			
			//Sub 공정 삭제
			batch.add(subSpec2, SQLUpsertType.DELETE);
			
			//하위 정보 삭제 - CT_SUBSEGMENTSPECDETAIL
			CtSubsegmentspecdetailData subSpecDetail2 = new CtSubsegmentspecdetailData();
			ISQLCondition cond2 = new SQLCondition(false);
			
			cond2.set(CtSubsegmentspecdetailData.Specdefid, row.getString("SPECDEFID"));
			cond2.set(CtSubsegmentspecdetailData.Specsequence, row.getDouble("SPECSEQUENCE"));
			
			ISQLDataList<CtSubsegmentspecdetailData> subSpecDetail2List = subSpecDetail2.select(cond2);
			if(subSpecDetail2List.size() > 0)
			{
				for(int i = 0; i < subSpecDetail2List.size(); i++)
				{
					subSpecDetail2 = subSpecDetail2List.get(i);
					batch.add(subSpecDetail2, SQLUpsertType.DELETE);
				}
			}
			
			break;
		case "ITEM":
			CtSubsegmentspecdetailData subSpecDetail3 = new CtSubsegmentspecdetailData();
			CtSubsegmentspecdetailKey subSpecDetail3Key = subSpecDetail3.key();
			subSpecDetail3Key.setSpecdefid(row.getString("SPECDEFID"));
			//subSpecDetail3Key.setSubprocesssegmentid(row.getString("SUBPROCESSSEGMENTID"));
			subSpecDetail3Key.setParameterid(row.getString("PARAMETERID"));
			subSpecDetail3Key.setSpecsequence(row.getDouble("SPECSEQUENCE"));
			subSpecDetail3Key.setSpecdefidversion(row.getString("SPECDEFIDVERSION"));
			
			subSpecDetail3 = subSpecDetail3.selectOne();
			if(subSpecDetail3 == null)
			{
				throw new InValidDataException("InValidData001", String.format("Spec Id = %s, SubProcesssegment Id = %s, Parameter Id = %s, Seq = %s"
						, row.getString("SPECDEFID"), row.getString("SUBPROCESSSEGMENTID"), row.getString("PARAMETERID"), row.getString("SPECSEQUENCE")));
			}
			
			batch.add(subSpecDetail3, SQLUpsertType.DELETE);
			
			break;
			
		}
	}
}
