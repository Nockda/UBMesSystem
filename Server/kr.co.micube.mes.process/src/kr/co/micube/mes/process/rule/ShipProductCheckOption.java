package kr.co.micube.mes.process.rule;

import java.text.ParseException;
import java.util.HashMap;
import java.util.Map;

import kr.co.micube.common.mes.constant.SystemOption;
import kr.co.micube.commons.factory.standard.service.CodeService;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.mes.CodeData;

/*
 * 프  로  그  램  명	: 
 * 설               명	: 제품 출하 시스템옵션
 * 				  공통코드 시스템 옵션에서 정의돈 제품출하 라벨 옵션을 체크한다.(Y/N);			
 * 생      성      자	: jylee
 * 생      성      일	: 2020-07-24
 * 수   정   이   력	: 
 * 				  
 */

public class ShipProductCheckOption extends DatasetRule {

	// 파라미터
	private IDataTable list; 	// 출하 LOT 목록(컬럼 : LOTID)
	private IDataSet dsReturn = this.getResponseDataset();
	private IDataTable dtReturn = dsReturn.addTable("DATA");
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		
		CodeData codeData = CodeService.getCode(SystemOption.SHIP_LABEL_MATERIALS_LOT, SystemOption.CODECLASSID);
		Map<String, Object> result = new HashMap<String, Object>();
			result.put("codeData", codeData.getDescription());
			dtReturn.addRow(result);
	}

	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		// 파라미터
		IDataSet ds = this.getRequestDataset();
		this.list = ds.getTable("list");
	}
}
