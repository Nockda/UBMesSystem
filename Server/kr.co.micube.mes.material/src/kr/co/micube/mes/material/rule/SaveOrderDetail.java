package kr.co.micube.mes.material.rule;

import java.text.ParseException;
import java.text.SimpleDateFormat;

import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.UlOrderdetailData;
import kr.co.micube.common.mes.so.UlOrderdetailKey;
import kr.co.micube.commons.factory.util.Constant;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

/*
 * 프  로  그  램  명	: 자재관리 > 자재 > 자재 입고 처리(디테일)
 * 설               명	: 자재입고처리 디테일 데이터를 저장 처리(등록, 수정, 삭제) 한다.
 * 생      성      자	: scmo
 * 생      성      일	: 2020-04-20
 * 수   정   이   력	: 2020-06-02 발주요청 변경에 따른 수정 | scmo
 */
public class SaveOrderDetail extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		IDataRow row = null;
		//String state = null;
		

		//
		//state = row.getString("_STATE_");
		
		for(int i = 0, len= dt.size(); i<len; i++) {
			row = dt.getRow(i);
			batch.add(getInsertData(row,batch), SQLUpsertType.INSERT);
		}
		
		//batch.add(getInsertData(row, batch), SQLUpsertType.INSERT);
	

		
		batch.execute();
	}
	
	private UlOrderdetailData getInsertData(IDataRow row, ISQLUpsertBatch batch) throws InValidDataException, DatabaseException, MESException, SystemException, ParseException
	{
		UlOrderdetailData code = new UlOrderdetailData();
		UlOrderdetailKey codeKey = code.key();
			
		codeKey.setSeq(row.getInteger("SEQ"));

		code = code.selectOne();
		
		if (code != null)
		{
			throw new InValidDataException("InValidData002", String.format("CodeId = %s", row.getInteger("SEQ").toString()));
		}
		
		UlOrderdetailData newCode = new UlOrderdetailData();
		//UlOrderdetailKey newCodeKey = newCode.key();
	
		newCode.setPoseq(row.getInteger("POSEQ"));
		newCode.setPoserl(row.getInteger("POSERL"));
		newCode.setPono(row.getString("PONO"));
		SimpleDateFormat transFormat = new SimpleDateFormat("yyyy-MM-dd");
		newCode.setDelvdate(transFormat.parse(row.getString("DELVDATE")));
		newCode.setDelvseq(row.getInteger("DELVSEQ"));
		newCode.setDelvserl(row.getInteger("DELVSERL"));
		newCode.setDelvno(row.getString("DELVNO"));
		newCode.setItemseq(row.getInteger("ITEMSEQ"));
		newCode.setItemno(row.getString("ITEMNO"));
		newCode.setWhseq(row.getInteger("WHSEQ"));
		newCode.setInqty(row.getDouble("OKQTY"));
		newCode.setLotsize((int)Math.round(row.getDouble("LOTSIZE")));
		newCode.setCustseq(row.getString("CUSTSEQ"));
		newCode.setCustname(row.getString("CUSTNAME"));
		
		newCode.setCompleteyn(Constant.YES);
		newCode.setTossyn(Constant.NO);

		return newCode;
	}
}
