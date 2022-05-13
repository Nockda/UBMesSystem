package kr.co.micube.mes.material.rule;

import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.so.CtConsumablelotholdData;
import kr.co.micube.common.mes.so.CtConsumablelotholdKey;
import kr.co.micube.common.mes.so.SfConsumablelotData;
import kr.co.micube.common.mes.so.SfConsumablelotKey;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.util.Generate;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

public class SaveConsumableLotHold extends DatasetRule {

	@Override
	public void doEvent() throws Throwable {

		IMessage msg = this.getMessage().get();
		
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);
		
		String transactionType = body.getString("transactionType");
		
		switch (transactionType) {
			case "SetConsumableLotHold":
				getConsumableLotHoldData(body);
				break;
			case "SetReleaseConsumableLotHold":
				getReleaseConsumableLotHoldData(body);
				break;
		}
		
	}
	
	/**********************************************************************************************************
	 * consumableLot 보류
	 * @param data
	 * @throws DatabaseException 
	 * @throws InValidDataException 
	 **********************************************************************************************************/
	private void getConsumableLotHoldData(IData data) throws InValidDataException, DatabaseException
	{
		String strHoldReason = data.getString("reasonCode");
		String strComments = data.getString("comments");
		String struserID = data.getString("userId");

		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("lotlist");
		IDataRow row = null;
		
		for(int i = 0; i<dt.size(); i++)
		{
			row = dt.getRow(i);

			//ct_consumablelothold 이력 Insert OR Update
			insertCtConsumableLotHold(row, strHoldReason, strComments, struserID);
			// isHold update
			updateConsumableIsHold(row, "Y");
		}		
		
	}
	
	
	/**********************************************************************************************************
	 * consumableLot 보류 해제
	 * @param data
	 * @throws SystemException 
	 **********************************************************************************************************/	
	private void getReleaseConsumableLotHoldData(IData data) throws SystemException
	{	
		String strHoldReleaseReason = data.getString("reasonCode");
		String strComments = data.getString("comments");
		String strUserID = data.getString("userId");

		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("lotlist");
		IDataRow row = null;
		
		for(int i = 0; i<dt.size(); i++)
		{
			row = dt.getRow(i);
			String consumableLotId = row.getString("CONSUMABLELOTID");
			
			updateCtConsumableLotHold(row, strHoldReleaseReason, strComments, strUserID);
			
			//CT_CONSUMABLELOTHOLD에 해당 Lot hold count 구하기
			Map<String, Object> propertyMap = new HashMap<>();
			propertyMap.put("CONSUMABLELOTID", consumableLotId);

			//Hold LOT 조회 : count 0일때 만 consumableLot isHold N으로 update
			List<Map<String, Object>> holdCount = this.select("GetConsumableLotHoldCount", "00001", propertyMap);
			
			if(holdCount != null && holdCount.get(0).get("COUNT").toString().equals("0"))
			{
				updateConsumableIsHold(row, "N");
			}
		}

	};
	
	
	//ct_consumablelothold 테이블에 Insert
	private void insertCtConsumableLotHold(IDataRow row, String HoldReasonCode, String Comment, String UserId) throws DatabaseException, InValidDataException
	{
		//체크
		//CONSUMABLELOT 존재하는지?
		//CONSUMABLESTATE = "Available"
		//ISHOLD != "Y" 
		
		SfConsumablelotData consumableLotData = new SfConsumablelotData();
		SfConsumablelotKey consumableLotKey = consumableLotData.key();
		
		String consumableLotId = row.getString("CONSUMABLELOTID");
		
		consumableLotKey.setConsumablelotid(consumableLotId);
		consumableLotData = consumableLotData.selectOne();
		
		if(consumableLotData == null)
		{//자재 Lot 없는 경우 : 해당 자재 Lot이 존재하지 않습니다.
			throw new InValidDataException("NotExistConsumableLot");
		}
		
		if(!consumableLotData.getConsumablestate().equals("Available"))
		{//consumableState가 Available 아닌 경우 : 자재Lot 상태가 사용가능 하지 않습니다.
			
			throw new InValidDataException("ConsumableLotNotAvailable");
		}
		
		if(consumableLotData.getIshold().equals("Y"))
		{//isHold가 Y인 경우 : 자재Lot이 Hold되어 있습니다.
			
			throw new InValidDataException("ConsumableLotAlreadyHold");
		}
		
		//ct_consumablelothold insert
		CtConsumablelotholdData hold = new CtConsumablelotholdData();
		CtConsumablelotholdKey holdKey = hold.key();
		
		holdKey.setConsumablelotid(consumableLotId);
		holdKey.setTxnhistkey(Generate.createID());
		
		hold.setWarehouseid(consumableLotData.getWarehouseid());
		hold.setConsumablelotqty(consumableLotData.getConsumablelotqty());
		hold.setState("Y");
		hold.setReasoncodeid(HoldReasonCode);
		hold.setHolduser(UserId);
		hold.setHoldcomments(Comment);
		hold.setHolddate(new Date());
		hold.insert();	
		
	};
	
	
	//sf_consumableLot 테이블에 isHold "Y" OR "N" update
	private void updateConsumableIsHold(IDataRow row, String strYN) throws DatabaseException
	{
		SfConsumablelotData consumableLotData = new SfConsumablelotData();
		SfConsumablelotKey consumableLotKey = consumableLotData.key();
		
		consumableLotKey.setConsumablelotid(row.getString("CONSUMABLELOTID"));
		
		consumableLotData = consumableLotData.selectOne();
		
		consumableLotData.setIshold(strYN);
		consumableLotData.setLasttxnid("SaveConsumableLotHold");
		consumableLotData.update();
		
	};
	
	//ct_consumablelothold 테이블에 Update
	private void updateCtConsumableLotHold(IDataRow row, String ReleaseReasonCode, String Comment, String UserId) throws DatabaseException, InValidDataException
	{
		//체크
		//CT_CONSUMABLELOTHOLD에 존재하는지?
		//CONSUMABLESTATE = "Available" => 필요할지?
		
		String consumableLotId = row.getString("CONSUMABLELOTID");
		
		
		SfConsumablelotData consumableLotData = new SfConsumablelotData();
		SfConsumablelotKey consumableLotKey = consumableLotData.key();
		
		consumableLotKey.setConsumablelotid(consumableLotId);
		
		consumableLotData = consumableLotData.selectOne();
		
		CtConsumablelotholdData hold = new CtConsumablelotholdData();
		CtConsumablelotholdKey holdKey = hold.key();
		
		holdKey.setConsumablelotid(consumableLotId);
		holdKey.setTxnhistkey(row.getString("TXNHISTKEY"));
		
		hold = hold.selectOne();
		
		if(hold == null || consumableLotData == null)
		{//자재 Lot 없는 경우 : 해당 자재 Lot이 존재하지 않습니다.
			
			throw new InValidDataException("NotExistConsumableLot");			
		}
		
		if(!consumableLotData.getConsumablestate().equals("Available"))
		{//consumableState가 Available 아닌 경우 : 자재Lot 상태가 사용가능 하지 않습니다.
			
			throw new InValidDataException("ConsumableLotNotAvailable");
		}

		hold.setReleasereasoncodeid(ReleaseReasonCode);
		hold.setReleaseuser(UserId);
		hold.setReleasedate(new Date());
		hold.setReleasecomments(Comment);
		hold.setState("N");
		
		hold.update();

	};



}
