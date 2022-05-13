package kr.co.micube.mes.process.rule;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.service.SfConsumeMaterialLotTempService;
import kr.co.micube.common.mes.service.SfLotService;
import kr.co.micube.common.mes.so.SfConsumemateriallottempData;
import kr.co.micube.common.mes.so.SfLotData;
import kr.co.micube.common.mes.so.SfProcesssegmentData;
import kr.co.micube.common.mes.so.SfProcesssegmentKey;
import kr.co.micube.common.mes.so.UlProcessworkresultData;
import kr.co.micube.common.mes.so.UlProcessworkresultKey;
import kr.co.micube.common.mes.so.UlSubprocessworkresultData;
import kr.co.micube.common.mes.so.UlSubprocessworkresultKey;
import kr.co.micube.common.mes.so.UlSubprocessworkresultdetailData;
import kr.co.micube.common.mes.so.UlSubprocessworkresultdetailKey;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.common.util.QueryProvider;
import kr.co.micube.commons.factory.so.IdclassserialData;
import kr.co.micube.commons.factory.so.IdclassserialKey;
import kr.co.micube.commons.factory.so.IdclasssplitData;
import kr.co.micube.commons.factory.so.IdclasssplitKey;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.support.ISQLDataList;

/*
 * 프  로  그  램  명	: 생산지지조회
 * 설               명	: 생산지시에서 Lot을 생성 한다.
 * 생      성      자	: 배선용
 * 생      성      일	: 2020-07-23
 * 수   정   이   력	: 
 */
public class CancelCreateLot extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IMessage msg = this.getMessage().get();
		
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);
		
		String Lotid = body.getString("lotId");
		String comment = body.getString("comment");
		
		SfLotData lotData = SfLotService.getLot(Lotid);
		
		if(comment.equals("AssemblyResult Lot Terminate")) {
			// 조립실적등록의 Lot폐기 버튼으로 폐기 할 경우
			// 실린더의 경우 Lot을 재사용해야 하기 때문에 작업실적, 검사실적을 모두 삭제해줘야 함.
			
			UlProcessworkresultData workResultdt = new UlProcessworkresultData();
			UlProcessworkresultKey workResultKey = workResultdt.key();
			
			
			Map<String, Object> processmap = new HashMap<>();
			processmap.put("LOTID", Lotid);
			
			List<Map<String, Object>> proresultMap = QueryProvider.select("checkprocessworkresult", "00001", processmap);
			if(proresultMap.size() > 0) {
				for(int i = 0; i>proresultMap.size(); i++) {
					String processTXN = String.valueOf(proresultMap.get(i).get("TXNHISTKEY"));
					//트렌젝션 히스트 키에 따라 결과가 있다면 Ul_Processworkresult 하나하나 삭제시켜줌
					workResultKey.setTxnhistkey(processTXN);
					workResultdt.delete();
				}
			}
			
			UlSubprocessworkresultData subworkResultdt = new UlSubprocessworkresultData();
			UlSubprocessworkresultKey subworkResultKey = subworkResultdt.key();

			List<Map<String, Object>> subProresultMap = QueryProvider.select("checksubprocessworkresult", "00001", processmap);
			if(subProresultMap.size() > 0) {
				for(int i = 0; i<subProresultMap.size(); i++) {
					String subProcessTXN = String.valueOf(subProresultMap.get(i).get("TXNHISTKEY"));
					//트렌젝션 히스트 키에 따라 결과가 있다면 Ul_Subprocessworkresult 하나하나 삭제시켜줌
					subworkResultKey.setTxnhistkey(subProcessTXN);
					subworkResultdt.delete();
					
					
					Map<String, Object> processdetailmap = new HashMap<>();
					processdetailmap.put("WORKRESULTHISTKEY", subProcessTXN);
					List<Map<String, Object>> subProresultdetailMap = QueryProvider.select("checksubprocessworkresultdetail", "00001", processdetailmap);
					//트렌젝션 히스트 키에 따라 결과가 있다면 Ul_Subprocessworkresultdetail 하나하나 삭제시켜줌
					if(subProresultdetailMap.size()>0) {
						for (int j = 0; j<subProresultdetailMap.size(); j++) {
							UlSubprocessworkresultdetailData subworkResultdetaildt = new UlSubprocessworkresultdetailData();
							UlSubprocessworkresultdetailKey subworkResultdetailKey = subworkResultdetaildt.key();
							
							String subProcessTXNhstkey = String.valueOf(subProresultdetailMap.get(j).get("WORKRESULTHISTKEY"));
							subworkResultdetailKey.setWorkresulthistkey(subProcessTXNhstkey);
							subworkResultdetaildt.delete();
						}
					}
				}
			}
		} else {
			if(lotData == null)	{
				// 존재 하지 않은 LOT No. 입니다.
				throw new SystemException("CheckLotNo");
			}
			if(!lotData.getLotstate().equals(Constant.LOTSTATE_INPRODUCTION) || !lotData.getProcessstate().equals(Constant.LOTPROCESSSTATE_IDLE)) {
				// LOT 상태가 대기 상태인(Idle) LOT만 취소 가능 합니다.
				throw new SystemException("CheckLotStateForCancel");
			}
			ISQLDataList<SfConsumemateriallottempData> materials = SfConsumeMaterialLotTempService.getConsumemateriallottempList(Lotid);
			if(materials.size() > 0) {
				// 투입된 자재가 있습니다.
				throw new SystemException("MaterialExists");
			}	
		}
		lotData.setLasttxncomment(comment);
		
		// 다음 시리얼 넘버 불러오기
		
		SfProcesssegmentData segment = new SfProcesssegmentData();
		SfProcesssegmentKey segmentKey = segment.key();
		IdclassserialData idclassSerialDt = new IdclassserialData();
		IdclassserialKey idclassSerialKy = idclassSerialDt.key();
		
		String ProcessSegmentID = lotData.getProcesssegmentid();
		
		segmentKey.setProcesssegmentid(ProcessSegmentID);
		segmentKey.setProcesssegmentversion("*");
		
		segment = segment.selectOne();
		
		String LotCreateRule="";
		LotCreateRule = segment.getLotcreateruleid();
		idclassSerialKy.setIdclassid(LotCreateRule);
		
		if(LotCreateRule.equals("")) {
			LotCreateRule = "PLotNo";
		}

		// SF_IDCLASSSERIAL에서 라스트시리얼넘버 불러오기
		Map<String, Object> param = new HashMap<String, Object>();
		param.put("LOTCREATERULE", LotCreateRule);
		param.put("LOTID", Lotid);
		List<Map<String, Object>> result = QueryProvider.select("SelectCancelLot", "00001", param);
		Integer checkLastSerialNo = null;
		String checkLastSerialNoString = null;
		String checkPrefixNo = null;
		if (LotCreateRule.equals("CylinderLotNo")) {
			StringBuilder sb = new StringBuilder();
			sb.append(Lotid);
			sb.reverse();
			String revLot = sb.toString();
			System.out.println();
			
		} else {
			checkPrefixNo = String.valueOf(result.get(0).get("PREFIX"));
			checkLastSerialNo = Integer.valueOf(String.valueOf(result.get(0).get("LASTSERIALNO")));
			checkLastSerialNoString = String.valueOf(result.get(0).get("LASTSERIALNO"));	
		}
		
		Integer spacelen = Integer.valueOf(String.valueOf(result.get(0).get("SPACELEN")));
		if(LotCreateRule.equals("DisplaysorLotNo")) {
			spacelen = spacelen + 1;
		} else if (LotCreateRule.equals("ServiceMotorLotNo")) {
			spacelen = spacelen + 1;
		}
		
		// lastserialno가 null일 경우, prefix가 null일 경우
		// lastserialno가 null --> CylinderLotNo (이 경우 prefix만으로 계산)
		// prefix가 null일 경우 --> LN2LotNo, MBSCLotNo, PumpLotNo
		// MBSCLotNo, PumpLotNo 의 경우 prefix 없는 케이스 무시
		
		if(LotCreateRule.equals("CylinderLotNo")){
			//subsb는 prefix
			StringBuffer sb = new StringBuffer(Lotid);
			Integer sbIndex = sb.indexOf("00")+2;
			String subsb = Lotid.substring(0, sbIndex);
			
			Map<String, Object> map = new HashMap<>();
			map.put("IDCLASSID", LotCreateRule);
			map.put("SUBSB", subsb);
			
			List<Map<String, Object>> resultMap = QueryProvider.select("checkCylinderLotNoPrefix", "00001", map);
			
			String prefixwithoutspace = String.valueOf(resultMap.get(0).get("PREFIX2"));
			String prefixwithspace = String.valueOf(resultMap.get(0).get("PREFIX"));
			
			idclassSerialDt.setPrefix(prefixwithspace);
			idclassSerialDt.delete();
			
			IdclasssplitData idsplData = new IdclasssplitData();
			IdclasssplitKey idsplKey = idsplData.key();
			
			idsplKey.setIdclassid(LotCreateRule);
			idsplKey.setPrefix(prefixwithspace);
			idsplData.delete();
			
			lotData.delete();			
			
		} else if (LotCreateRule.equals("LN2LotNo")){
			// LN2LotNo의 경우 월+일 숫자를 불러오고 이 숫자와 시리얼 넘버를 합친 것을 확인한다.

			Map<String, Object> map = new HashMap<>();
			map.put("IDCLASSID", LotCreateRule);
			
			List<Map<String, Object>> resultMap = QueryProvider.select("SelectLN2CheckLastSerial", "00001", map);
			
			String currentDate = String.valueOf(resultMap.get(0).get("CURRENTDATE"));
			String lastSerialNo = String.valueOf(resultMap.get(0).get("LASTSERIALNO"));
			
			
			String originalLotNo = Lotid.substring(0, 8);
			boolean checklastlot = originalLotNo.equals(currentDate+lastSerialNo);
			lotData.delete();
			if(checklastlot == true) {
				Integer afterNo = Integer.parseInt(lastSerialNo)-1;
				idclassSerialDt.setLastserialno(Integer.toString(afterNo)); 
				idclassSerialDt.update();
			}
		} else if (LotCreateRule.equals("MBSCLotNo")){
			// MBSCLotNo인경우 PREFIX가 년+월 날짜랑 같은 IDDEFINITION을 조회 함
			Map<String, Object> map = new HashMap<>();
			map.put("IDCLASSID", LotCreateRule);
			List<Map<String, Object>> resultMap = QueryProvider.select("CheckMBSCLastSerialNoForLotCancel", "00001", map);
			//String prefixMBSC = String.valueOf(resultMap.get(0).get("PREFIX"));
			String lastSerialMBSC = String.valueOf(resultMap.get(0).get("LASTSERIALNO"));
			
			// 시리얼의 위치를 불러옴
			// 첫숫자 - 1, 마지막 숫자를 가져와서 Lot을 잘라서 비교
			if(lastSerialMBSC == null) {
				//월+일 숫자가 안맞으면 lot만 삭제
				lotData.delete();
			} else {
				//월+일 숫자가 맞으면 시리얼넘버 비교하여 마지막 시리얼일경우 -1
				List<Map<String, Object>> serialResult = QueryProvider.select("LotSerialStartIndex", "00001", map);
				Integer startSerial = Integer.valueOf(String.valueOf(serialResult.get(0).get("STARTSERIAL")));
				List<Map<String, Object>> lserialResult = QueryProvider.select("LotSerialLastIndex", "00001", map);
				Integer lastSerial = Integer.valueOf(String.valueOf(lserialResult.get(0).get("LASTSERIAL")));
				
				String originalLotNo = Lotid.substring(startSerial, lastSerial);
	
				boolean checklastlot = originalLotNo.equals(lastSerialMBSC);
				lotData.delete();
				if(checklastlot == true) {
					Integer afterNo = Integer.parseInt(lastSerialMBSC)-1;
					idclassSerialDt.setLastserialno(Integer.toString(afterNo)); 
					idclassSerialDt.update();
					
					// idclasssplit 데이터 삭제
					IdclasssplitData idsplData = new IdclasssplitData();
					IdclasssplitKey idsplKey = idsplData.key();
					
					String prefixFromLot = Lotid.substring(0, lastSerial);
					
					idsplKey.setIdclassid(LotCreateRule);
					idsplKey.setPrefix(prefixFromLot);
					idsplData.delete();	
				}
			}
		} else if (LotCreateRule.equals("PumpLotNo")){
			// PumpLotNo인경우 MBSC와 같은 로직
			Map<String, Object> map = new HashMap<>();
			map.put("IDCLASSID", LotCreateRule);
			List<Map<String, Object>> resultMap = QueryProvider.select("CheckPumpLotLastSerialNoForLotCancel", "00001", map);
			//String prefixMBSC = String.valueOf(resultMap.get(0).get("PREFIX"));
			String lastSerialMBSC = String.valueOf(resultMap.get(0).get("LASTSERIALNO"));
			
			// 시리얼의 위치를 불러옴
			// 첫숫자 - 1, 마지막 숫자를 가져와서 Lot을 잘라서 비교
			if(lastSerialMBSC == null) {
				//월+일 숫자가 안맞으면 lot만 삭제
				lotData.delete();
			} else {
				//월+일 숫자가 맞으면 시리얼넘버 비교하여 마지막 시리얼일경우 -1
				List<Map<String, Object>> serialResult = QueryProvider.select("LotSerialStartIndex", "00001", map);
				Integer startSerial = Integer.valueOf(String.valueOf(serialResult.get(0).get("STARTSERIAL")));
				List<Map<String, Object>> lserialResult = QueryProvider.select("LotSerialLastIndex", "00001", map);
				Integer lastSerial = Integer.valueOf(String.valueOf(lserialResult.get(0).get("LASTSERIAL")));
				
				String originalLotNo = Lotid.substring(startSerial, lastSerial);
	
				boolean checklastlot = originalLotNo.equals(lastSerialMBSC);
				lotData.delete();
				if(checklastlot == true) {
					Integer afterNo = Integer.parseInt(lastSerialMBSC)-1;
					idclassSerialDt.setLastserialno(Integer.toString(afterNo)); 
					idclassSerialDt.update();
					
					// idclasssplit 데이터 삭제
					IdclasssplitData idsplData = new IdclasssplitData();
					IdclasssplitKey idsplKey = idsplData.key();
					
					String prefixFromLot = Lotid.substring(0, lastSerial);
					
					idsplKey.setIdclassid(LotCreateRule);
					idsplKey.setPrefix(prefixFromLot);
					idsplData.delete();	
				}
			}
		} else if (LotCreateRule.equals("PLotNo")) {
			// PLotNo인경우 PREFIX가 년+월 날짜랑 같은 IDDEFINITION을 조회 함
			Map<String, Object> map = new HashMap<>();
			map.put("IDCLASSID", LotCreateRule);
			List<Map<String, Object>> resultMap = QueryProvider.select("CheckPLotNoLastSerialNoForLotCancel", "00001", map);
			String prefixPLN = String.valueOf(resultMap.get(0).get("PREFIX"));
			String lastSerialPLN = String.valueOf(resultMap.get(0).get("LASTSERIALNO"));
			
			// 시리얼의 위치를 불러옴
			// 첫숫자 - 1, 마지막 숫자를 가져와서 Lot을 잘라서 비교
			if(lastSerialPLN == null) {
				//월+일 숫자가 안맞으면 lot만 삭제
				lotData.delete();
			} else {
				//월+일 숫자가 맞으면 시리얼넘버 비교하여 마지막 시리얼일경우 -1
				List<Map<String, Object>> serialResult = QueryProvider.select("LotSerialStartIndex", "00001", map);
				Integer startSerial = Integer.valueOf(String.valueOf(serialResult.get(0).get("STARTSERIAL")));
				List<Map<String, Object>> lserialResult = QueryProvider.select("LotSerialLastIndex", "00001", map);
				Integer lastSerialplot = Integer.valueOf(String.valueOf(lserialResult.get(0).get("LASTSERIAL")));
				
				String originalLotNo = Lotid.substring(startSerial, lastSerialplot);
	
				boolean checklastlot = originalLotNo.equals(lastSerialPLN);
				lotData.delete();
				if(checklastlot == true) {
					Integer fixedSerial = Integer.parseInt(lastSerialPLN) -1;
					String afterNo = String.format("%05d", fixedSerial);
					idclassSerialDt.setIdclassid("PLotNo");
					idclassSerialDt.setPrefix(prefixPLN);
					idclassSerialDt.setLastserialno(afterNo); 
					idclassSerialDt.update();
					
					// idclasssplit 데이터 삭제
					IdclasssplitData idsplData = new IdclasssplitData();
					IdclasssplitKey idsplKey = idsplData.key();
					
					String prefixFromLot = Lotid.substring(0, lastSerialplot);
					
					idsplKey.setIdclassid(LotCreateRule);
					idsplKey.setPrefix(prefixFromLot);
					idsplData.delete();	
				}
			}
		} else if (LotCreateRule.equals("DisplaysorLotNo")) {
			// DisplaysorLotNo의 경우 idclassserial prefix 앞뒤에 빈칸을 붙여놓아서 처리해줘야됨.
			//채번 룰에서 시작과 끝 시리얼 넘버 가져오기
			Map<String, Object> serialParam = new HashMap<String, Object>();
			serialParam.put("IDCLASSID", LotCreateRule);
			List<Map<String, Object>> serialResult = QueryProvider.select("LotSerialStartIndex", "00001", serialParam);
			Integer startSerial = Integer.valueOf(String.valueOf(serialResult.get(0).get("STARTSERIAL")));
			List<Map<String, Object>> lserialResult = QueryProvider.select("LotSerialLastIndex", "00001", serialParam);
			Integer lastSerial = Integer.valueOf(String.valueOf(lserialResult.get(0).get("LASTSERIAL")));
	
			// 시리얼넘버와 비교하여 Max값인지 확인
			String originalLotNo = Lotid.substring(startSerial, lastSerial+1-spacelen);
			boolean checkLot = originalLotNo.equals(checkLastSerialNo.toString());
			lotData.delete();
			
			if(checkLot == true){
				//마지막 시리얼 넘버 -1
				String updatedSerialNo = "";
				checkLastSerialNo=checkLastSerialNo-1;
				updatedSerialNo = checkLastSerialNo.toString();
				
				//기존 LastSerialNo와 동일하게 0붙이고 업데이트
				Integer serialnolength = String.valueOf(result.get(0).get("LASTSERIALNO")).length();
				String deleteSerialno = String.valueOf(result.get(0).get("LASTSERIALNO"));
				Integer k = serialnolength - updatedSerialNo.length();
				String blankNo ="";
				for(int i = 0; i<k; i++) {
					blankNo= blankNo.concat("0");
				}
				blankNo = blankNo.concat(updatedSerialNo);
				
				//idclasssplit 테이블에서 Max값인지 확인하여 해당 lotid삭제 (재사용 하기 위하여)
				IdclasssplitData idsplData = new IdclasssplitData();
				IdclasssplitKey idsplKey = idsplData.key();
				String prefixFromLot = null;
				
				// IDCLASSSPLIT 테이블에서 해당 IDCLASSID에서 마지막 등록된 PREFIX 불러오기
				
				if(checkPrefixNo.replace(" ", "").equals("KBB")) {
					prefixFromLot = " " + checkPrefixNo.replace(" ", "");
				} else {
					prefixFromLot = " " + checkPrefixNo.replace(" ", "") + " ";					
				}
				String prefixFromLot2 = prefixFromLot + deleteSerialno;
				
				idsplKey.setIdclassid(LotCreateRule);
				idsplKey.setPrefix(prefixFromLot);
				
				idclassSerialDt.setIdclassid(LotCreateRule);
				idclassSerialDt.setPrefix(prefixFromLot);
				idclassSerialDt.setLastserialno(blankNo); 
				idclassSerialDt.update();
				
				
				// 마지막 등록된 PREFIX랑 현재 PREFIX 비교하여 삭제(앞에서부터 마지막등록Prefix 글자수만큼 자르고 비교)

				String idsplNo = idsplData.getPrefix();
				if (idsplNo.equalsIgnoreCase(prefixFromLot)) {
					idsplKey.setIdclassid(LotCreateRule);
					idsplKey.setPrefix(prefixFromLot2);
					idsplData.delete();	
				}
			}
		}  else if (LotCreateRule.equals("ServiceMotorLotNo")) {
			//채번 룰에서 시작과 끝 시리얼 넘버 가져오기 (SF_IDDEFINITION)
			Map<String, Object> serialParam = new HashMap<String, Object>();
			serialParam.put("IDCLASSID", LotCreateRule);
			List<Map<String, Object>> serialResult = QueryProvider.select("LotSerialStartIndex", "00001", serialParam);
			Integer startSerial = Integer.valueOf(String.valueOf(serialResult.get(0).get("STARTSERIAL")));
			List<Map<String, Object>> lserialResult = QueryProvider.select("LotSerialLastIndex", "00001", serialParam);
			Integer lastSerial = Integer.valueOf(String.valueOf(lserialResult.get(0).get("LASTSERIAL")));
	
			// 시리얼넘버와 비교하여 Max값인지 확인
			String originalLotNo = Lotid.substring(startSerial-spacelen, lastSerial-spacelen);
			//lot에서 자른 숫자랑 idclassserial이랑 같은지 확인
			boolean checkLot = originalLotNo.equals(checkLastSerialNoString);
			lotData.delete();
			
			if(checkLot == true){
				//마지막 시리얼 넘버 -1
				String updatedSerialNo = "";
				checkLastSerialNo=checkLastSerialNo-1;
				updatedSerialNo = checkLastSerialNo.toString();
				
				//기존 LastSerialNo와 동일하게 0붙이고 업데이트
				Integer serialnolength = String.valueOf(result.get(0).get("LASTSERIALNO")).length();
				Integer k = serialnolength - updatedSerialNo.length();
				String blankNo ="";
				for(int i = 0; i<k; i++) {
					blankNo= blankNo.concat("0");
				}
				
				//idclasssplit 테이블에서 Max값인지 확인하여 해당 lotid삭제 (재사용 하기 위하여)
				IdclasssplitData idsplData = new IdclasssplitData();
				IdclasssplitKey idsplKey = idsplData.key();
				String prefixFromLot = null;

				prefixFromLot = Lotid.substring(0, lastSerial+1-spacelen);
				idsplKey.setIdclassid(LotCreateRule);
				idsplKey.setPrefix(prefixFromLot);
				
				// 뒤에 두개는 시리얼에서 받아온 것
				String checkprefix = checkPrefixNo + checkLastSerialNoString;
				
				// idclasssplit에서 마지막 정보 받아오기
				Map<String, Object> parampf = new HashMap<String, Object>();
				parampf.put("IDCLASSID", LotCreateRule);
				parampf.put("PREFIX", checkprefix);
				List<Map<String, Object>> resultpf = QueryProvider.select("SelectCancelLotInfo", "00003", parampf);
				String checkprefixno = String.valueOf(resultpf.get(0).get("PREFIX"));
				
				//idclass serial 업데이트
				blankNo = blankNo.concat(updatedSerialNo);
				idclassSerialDt.setLastserialno(blankNo); 
				idclassSerialDt.update();

				idsplKey.setIdclassid(LotCreateRule);
				idsplKey.setPrefix(checkprefixno);
				idsplData.delete();	

			}
		} else {
			// 위 경우가 아닌 일반 경우
			//채번 룰에서 시작과 끝 시리얼 넘버 가져오기
			Map<String, Object> serialParam = new HashMap<String, Object>();
			serialParam.put("IDCLASSID", LotCreateRule);
			List<Map<String, Object>> serialResult = QueryProvider.select("LotSerialStartIndex", "00001", serialParam);
			Integer startSerial = Integer.valueOf(String.valueOf(serialResult.get(0).get("STARTSERIAL")));
			List<Map<String, Object>> lserialResult = QueryProvider.select("LotSerialLastIndex", "00001", serialParam);
			Integer lastSerial = Integer.valueOf(String.valueOf(lserialResult.get(0).get("LASTSERIAL")));
	
			// 시리얼넘버와 비교하여 Max값인지 확인
			String originalLotNo = Lotid.substring(startSerial-spacelen, lastSerial-spacelen);
			boolean checkLot = originalLotNo.equals(checkLastSerialNoString);
			lotData.delete();
			
			if(checkLot == true){
				//마지막 시리얼 넘버 -1
				String updatedSerialNo = "";
				checkLastSerialNo=checkLastSerialNo-1;
				updatedSerialNo = checkLastSerialNo.toString();
				
				//기존 LastSerialNo와 동일하게 0붙이고 업데이트
				Integer serialnolength = String.valueOf(result.get(0).get("LASTSERIALNO")).length();
				Integer k = serialnolength - updatedSerialNo.length();
				String blankNo ="";
				for(int i = 0; i<k; i++) {
					blankNo= blankNo.concat("0");
				}
				
				//idclasssplit 테이블에서 Max값인지 확인하여 해당 lotid삭제 (재사용 하기 위하여)
				IdclasssplitData idsplData = new IdclasssplitData();
				IdclasssplitKey idsplKey = idsplData.key();
				String prefixFromLot = null;
				
				// IDCLASSSPLIT 테이블에서 해당 IDCLASSID에서 마지막 등록된 PREFIX 불러오기
				//selectCancellot 은 idclassserial 값
				Map<String, Object> paramm = new HashMap<String, Object>();
				paramm.put("LOTCREATERULE", LotCreateRule);
				paramm.put("LOTID", Lotid);
				List<Map<String, Object>> resultSerial = QueryProvider.select("SelectCancelLot", "00001", paramm);
				String lastPrefix = String.valueOf(resultSerial.get(0).get("PREFIX"));
				String lastSr = String.valueOf(resultSerial.get(0).get("LASTSERIALNO"));
				
				if (spacelen == 0) {
					prefixFromLot = Lotid.substring(0, lastSerial);
				} else {
					prefixFromLot = Lotid.substring(0, lastSerial+1-spacelen);
				}
				idsplKey.setIdclassid(LotCreateRule);
				idsplKey.setPrefix(prefixFromLot);
				
				// 마지막 등록된 PREFIX랑 현재 PREFIX 비교하여 삭제(앞에서부터 마지막등록Prefix 글자수만큼 자르고 비교)
				int prefixLength = String.valueOf(lastPrefix).length();
				
				String checkprefix = checkPrefixNo + checkLastSerialNoString;
				
				// idclasssplit에서 마지막 정보 받아오기
				Map<String, Object> parampf = new HashMap<String, Object>();
				parampf.put("IDCLASSID", LotCreateRule);
				parampf.put("PREFIX", checkprefix);
				List<Map<String, Object>> resultpf = QueryProvider.select("SelectCancelLotInfo", "00003", parampf);
				String checkprefixno = String.valueOf(resultpf.get(0).get("PREFIX"));
				
				//idclass serial 업데이트
				blankNo = blankNo.concat(updatedSerialNo);
				idclassSerialDt.setLastserialno(blankNo); 
				idclassSerialDt.update();
				
				// RefLotNo의 경우 idsplit이랑 idserial이랑 
				// idplitafeer
				//if(LotCreateRule.equals("RefLotNo")) {
					String idSerialafter = lastPrefix + lastSr;
					if (checkprefixno.equals(idSerialafter)) {
						idsplKey.setIdclassid(LotCreateRule);
						idsplKey.setPrefix(checkprefixno);
						idsplData.delete();	
						
					}
					else{
					}
					/*
				} else {
					String idSplitsub = Lotid.substring(0, prefixLength-spacelen);
					if (lastPrefix.equals(idSplitsub)) {
						idsplKey.setIdclassid(LotCreateRule);
						idsplKey.setPrefix(idSplitsub);
						idsplData.delete();	
					}	
				}
			*/
			}
		}
	}
}
