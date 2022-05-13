package kr.co.micube.mes.process.rule;

import java.text.ParseException;
import java.util.Date;

import kr.co.micube.common.mes.service.SfEquipmentService;
import kr.co.micube.common.mes.so.CtNonorderconsumableworkresultData;
import kr.co.micube.common.mes.so.SfEquipmentData;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLDataList;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 공정관리 > 공정실적 등록 > 건조기 실적 등록
 * 설               명	: 건조기 위치교환. 총 40일의 건조기간, 20일째에 건조기 안쪽과 바깥쪽의 자재 위치를 서로 바꾼다. (온도 차이 때문)
 * 				건조시작 후 20일이 지나면 클라이언트에서 붉은색으로 건조기 위치교환 알람을 표시하고
 * 				위치교환을 하면 해당 알람이 사라진다. 
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-06-16
 * 수   정   이   력	: 
 * 				  
 */

public class SwitchDryer extends DatasetRule {

	// 트랜잭션 정보
	// private TxnInfo txnInfo;

	// 파라미터
	private String equipmentId; 	// 설비 ID
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		SfEquipmentData equipData = SfEquipmentService.getEquipment(this.equipmentId);
		if(!Constant.STATE_RUN.equals(equipData.getState())) {
			// 설비가 작업중이 아닙니다.
			throw new SystemException("EquipmentIsNotRunning");
		}
		// 설비에서 현재 작업중인 실적정보 조회
		ISQLCondition cond = new SQLCondition(false);
		cond.set(CtNonorderconsumableworkresultData.Equipmentid);
		cond.set(CtNonorderconsumableworkresultData.Workendtime);
		CtNonorderconsumableworkresultData data = new CtNonorderconsumableworkresultData();
		data.setEquipmentid(this.equipmentId);
		data.setWorkendtime(null);
		ISQLDataList<CtNonorderconsumableworkresultData> dataList = data.select(cond);
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		Date now = SQLService.toDate();
		for(int i = 0; i < dataList.size(); i++) {
			CtNonorderconsumableworkresultData eachData = dataList.get(i);
			if(eachData.getSwitchdate() != null) {
				// 이미 위치교환을 했습니다.
				throw new SystemException("AlreadySwitched");
			}
			eachData.setSwitchdate(now);
			batch.add(eachData, SQLUpsertType.UPDATE);
		}
		batch.execute();
	}

	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		// this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);

		// 파라미터
		this.equipmentId = body.getString("equipmentid");
	}
}
