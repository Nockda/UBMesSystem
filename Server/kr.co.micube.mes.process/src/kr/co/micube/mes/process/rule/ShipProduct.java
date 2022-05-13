package kr.co.micube.mes.process.rule;

import java.text.ParseException;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.SystemOption;
import kr.co.micube.common.mes.service.SfConsumableLotService;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.util.QueryProvider;
import kr.co.micube.commons.factory.standard.service.CodeService;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.mes.CodeData;

/*
 * 프  로  그  램  명	: 
 * 설               명	: 제품 출하
 * 				제품 재고의 ConsumableState를 Shipped로 변경하여 MES 제품 재고를 차감한다.
 * 				ERP 에서는 출하를 따로 하기 때문에(품목으로) I/F는 하지 않는다.
 * 생      성      자	: yshwang
 * 생      성      일	: 2020-07-02
 * 수   정   이   력	: 2020-07-23 | jylee | System Option 추가
 * 				  
 */

public class ShipProduct extends DatasetRule {

	// 트랜잭션 정보
	// private TxnInfo txnInfo;

	// 파라미터
	private IDataTable list; 	// 출하 LOT 목록(컬럼 : LOTID)
	
	@Override
	public void doEvent() throws Throwable {
		loadParameter();
		CodeData codeData = CodeService.getCode(SystemOption.SHIP_LABEL_MATERIALS_LOT, SystemOption.CODECLASSID);
		if(Constant.YES.equals(codeData.getDescription())) {
			for (int i = 0; i < this.list.size(); i++) {
				String lotId = this.list.getRow(i).getString("LOTID");
				SfConsumablelotData conLotData = SfConsumableLotService.getConsumablelot(lotId);
				// 출하되지 않았고, 맵핑된 출하라벨이 있으면 출하처리
				if(!"Shipped".equals(conLotData.getConsumablestate()) && isShippingLabelMapped(conLotData.getConsumabledefid())) {
					SfConsumableLotService.shipConsumableLot(lotId);
				}
			}
		}
	}

	// 클라이언트에서 받은 파라미터를 private 변수에 저장
	private void loadParameter() throws SystemException, ParseException {
		// this.txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());

		// IMessage msg = this.getMessage().get();
		// IData jmsg = msg.get();
		// IData body = jmsg.get(MessageFormat.Body);

		// 파라미터
		IDataSet ds = this.getRequestDataset();
		this.list = ds.getTable("list");
	}
	
	private Boolean isShippingLabelMapped(String productDefId) throws DatabaseException {
		Map<String, Object> param = new HashMap<String, Object>();
		param.put("PRODUCTDEFID", productDefId);
		List<Map<String, Object>> result = QueryProvider.select("GetHasPackageLabel", "00001", param);
		return Integer.valueOf(result.get(0).get("PACKAGELABEL").toString()) > 0;
	}
}
