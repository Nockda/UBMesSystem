package kr.co.micube.mes.standard.rule;

import java.util.Base64;
import java.util.Base64.Decoder;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.so.SfLabeldefinitionData;
import kr.co.micube.common.mes.so.SfLabeldefinitionKey;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 기준정보 > 항목관리 > 바코드라벨관리
 * 설               명	: 바코드라벨관리에서 라벨 디자인정보(LABELDATA 컬럼)을 제외하고 저장한다
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-05-20
 * 수   정   이   력	: 
 * 				  
 */

public class SaveLabelData extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);

		// 파라미터
		String labelId = body.getString("labelid");
		Decoder decoder = Base64.getDecoder();		
		byte[] labelData = decoder.decode(body.getString("labeldata"));

		// 변경사항 반영
		SfLabeldefinitionData data = new SfLabeldefinitionData();
		SfLabeldefinitionKey key = data.key();
		key.setLabelid(labelId);
		data = data.selectOne();
		
		if(data == null) {
			// 수정할 데이터가 존재하지 않습니다.({0})
			throw new InValidDataException("InValidData001", String.format("LabelId=%s", labelId));
		}

		data.setLabeldata(labelData);
		data.update();
	}
}
