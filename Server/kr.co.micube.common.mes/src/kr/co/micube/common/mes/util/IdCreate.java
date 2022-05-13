package kr.co.micube.common.mes.util;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.standard.service.IdService;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

public class IdCreate extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IMessage msg = this.getMessage().get();
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);
		
		TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
				
		/**********************************************
		 * ID Create
		 **********************************************/
		String idClass = body.getString("idclassid");
		List<String> list = new ArrayList<String>();
        List<String> idList = IdService.createId(idClass, 1, list, txnInfo);
        String createdId = idList.get(0).toString();
        
        /**********************************************
		 * Return Created ID
		 **********************************************/
		Map<String, Object> result = new HashMap<>();
		result.put("ID", createdId);
		
		IDataSet dsResult = this.getResponseDataset();
		
		IDataTable dtResult = dsResult.addTable("RESULT");
		
		dtResult.addRow(result);
		
	}

}
