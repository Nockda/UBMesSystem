package kr.co.micube.mes.material.rule;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlKanbanData;
import kr.co.micube.common.mes.so.UlKanbanKey;
import kr.co.micube.commons.factory.service.TxnInfo;
import kr.co.micube.commons.factory.service.TxnInfoUtil;
import kr.co.micube.commons.factory.standard.service.IdService;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataVariable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLData;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class RequestKanban extends DatasetRule{
	
	private String state;
	private String kanbanCode;
    private String location;
    private String consumableDefId;
    private double qty;
    private double lotQty;
    private String unit;
    private String toWarehouse;
    private String dept;
    private String reqUserId;

	
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();		
		//IDataTable dt = ds.getTable("list");
		IDataVariable data = ds.getVariable("list");
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		List<String> argList = new ArrayList<>();
		TxnInfo txnInfo = TxnInfoUtil.getTxnInfo(this.getMessage().getTxnData());
		String createId = IdService.createId("KanbanRequest", 1, argList, txnInfo).get(0);
		
		batch.add(getInsertData(data, batch, createId), SQLUpsertType.INSERT);

		batch.execute();
}
	//Insert
	private ISQLData getInsertData(IDataVariable data, ISQLUpsertBatch batch, String createId) throws InValidDataException, DatabaseException, MESException, SystemException, ParseException {
		UlKanbanData code = new UlKanbanData();
		UlKanbanKey codeKey=code.key();
		
		//요청번호
		codeKey.setReqcode(createId);
		//요청일
		code.setReqdate(getDate());
		//상태
		state = "Request";
		code.setState(state);
		//간반코드
		kanbanCode = (String)data.getObject("kanbanCode");
		code.setCellid(kanbanCode);
		//위치
		location = (String)data.getObject("location");
		code.setLocationid(location);
		//품목ID
		consumableDefId = (String)data.getObject("itemId");
		code.setConsumabledefid(consumableDefId);
		//요청수량
		qty = Double.parseDouble((String)data.getObject("qty"));
		code.setQty(qty);
		//투입수량
		lotQty = Double.parseDouble(("0"));
		code.setLotqty(lotQty);
		//단위
		unit = (String)data.getObject("unit");
		code.setUnit(unit);
		//To창고
		toWarehouse = (String)data.getObject("toWhId");
		code.setTowarehouseid(toWarehouse);
		//From창고
		code.setFromwarehouseid((String)data.getObject("from"));
		//요청부서
		dept = (String)data.getObject("dept");
		code.setDepartment(dept);
		//요청자ID
		reqUserId = (String)data.getObject("userId");
		code.setUserid(reqUserId);
		
		return code;
	}
	//오늘날짜
	public Date getDate() throws ParseException {
		LocalDateTime now = LocalDateTime.now();
		DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
		String formatDateTime = now.format(formatter);
		SimpleDateFormat transFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		Date today = transFormat.parse(formatDateTime);
		
		return today;
	}
}