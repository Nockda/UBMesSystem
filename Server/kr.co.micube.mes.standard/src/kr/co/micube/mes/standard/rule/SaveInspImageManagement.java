package kr.co.micube.mes.standard.rule;

import java.io.UnsupportedEncodingException;
import java.util.Base64;

import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.commons.factory.so.InspectionFileData;
import kr.co.micube.commons.factory.so.InspectionFileKey;
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
import kr.co.micube.tool.so.SQLUpsertType;
import kr.co.micube.tool.so.support.ISQLUpsertBatch;
import kr.co.micube.tool.so.support.SQLUpsertBatch;

public class SaveInspImageManagement extends DatasetRule{
	public void doEvent() throws Throwable {
		
		IDataSet ds = this.getRequestDataset();      
		IDataTable inspDt = ds.getTable("inspList");
		
		IMessage msg = this.getMessage().get();
	    IData jmsg = msg.get();
	    IData body = jmsg.get(MessageFormat.Body);
	    String enterpriseId = body.getString("enterpriseid");
	    String plantId = body.getString("plantid");
	    
	    ISQLUpsertBatch batch = new SQLUpsertBatch();
	    
	    for(int i = 0; i < inspDt.size(); i++)
	    {
	    	IDataRow row = inspDt.getRow(i);
	    	String state = row.getString("_STATE_");
	    	
	    	switch(state)
	    	{
			case UpsertState.INSERT:
				batch.add(getInsertInspFileData(row, enterpriseId, plantId), SQLUpsertType.INSERT);
				break;
			case UpsertState.UPDATE:
				batch.add(getUpdateInspFileData(row, enterpriseId, plantId), SQLUpsertType.UPDATE);
				break;
			case UpsertState.DELETE:
				batch.add(getDeleteInspFileData(row), SQLUpsertType.DELETE);
				break;
	    	}
	    }
	    
	    batch.execute();
	}
	
	/********************************************************************************************
	* SF_INSPECTIONFILE INSERT
	*********************************************************************************************/
	private InspectionFileData getInsertInspFileData(IDataRow row, String enterpriseId, String plantId) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		String fileId = Generate.createID("FILE-");
		
		InspectionFileData insp = new InspectionFileData();
		InspectionFileKey inspKey = insp.key();
		inspKey.setFileid(fileId);
		inspKey.setInspectiontype(row.getString("INSPECTIONTYPE"));
		inspKey.setResourceid("*");
		
		insp = insp.selectOne();
		if(insp != null)
		{
			throw new InValidDataException("InValidData002", String.format("InspectionType = %s, FileId = %s"
					, fileId, row.getString("INSPECTIONTYPE")));
		}
		
		insp = new InspectionFileData();
		inspKey = insp.key();
		inspKey.setFileid(fileId);
		inspKey.setInspectiontype(row.getString("INSPECTIONTYPE"));
		inspKey.setResourceid("*");
		insp.setEnterpriseid(enterpriseId);
		insp.setPlantid(plantId);
		insp.setFilename(row.getString("FILENAME"));
		insp.setFileext(row.getString("FILEEXT"));
		try {
			insp.setFiledata((Base64.getDecoder().decode(row.getString("FILEDATA").getBytes("UTF-8"))));
		} catch (UnsupportedEncodingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		insp.setFilesize(row.getDouble("FILESIZE"));
		
		return insp;
	}
	
	/********************************************************************************************
	* SF_INSPECTIONFILE UPDATE
	*********************************************************************************************/
	private InspectionFileData getUpdateInspFileData(IDataRow row, String enterpriseId, String plantId) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		InspectionFileData insp = new InspectionFileData();
		InspectionFileKey inspKey = insp.key();
		
		String fileId = row.getString("FILEID");
		if(StringUtils.isNullOrEmpty(row.getString("FILEID")))
		{
			fileId = Generate.createID("FILE-");
		}
		
		inspKey.setFileid(fileId);
		inspKey.setInspectiontype(row.getString("INSPECTIONTYPE"));
		inspKey.setResourceid("*");
		
		insp = insp.selectOne();
		if(insp == null)
		{
			throw new InValidDataException("InValidData002", String.format("InspectionType = %s, FileId = %s"
					, fileId, row.getString("INSPECTIONTYPE")));
		}
		
		insp.setEnterpriseid(enterpriseId);
		insp.setPlantid(plantId);
		insp.setFilename(row.getString("FILENAME"));
		insp.setFileext(row.getString("FILEEXT"));
		try {
			insp.setFiledata((Base64.getDecoder().decode(row.getString("FILEDATA").getBytes("UTF-8"))));
		} catch (UnsupportedEncodingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		insp.setFilesize(row.getDouble("FILESIZE"));
		
		return insp;
	}
	
	/********************************************************************************************
	* SF_INSPECTIONFILE DELETE
	*********************************************************************************************/
	private InspectionFileData getDeleteInspFileData(IDataRow row) throws InValidDataException, DatabaseException, MESException, SystemException
	{
		InspectionFileData insp = new InspectionFileData();
		InspectionFileKey inspKey = insp.key();
		inspKey.setFileid(row.getString("FILEID"));
		inspKey.setInspectiontype(row.getString("INSPECTIONTYPE"));
		inspKey.setResourceid("*");
		
		insp = insp.selectOne();
		if(insp == null)
		{
			throw new InValidDataException("InValidData002", String.format("InspectionType = %s, FileId = %s"
					, row.getString("FILEID"), row.getString("INSPECTIONTYPE")));
		}
		
		return insp;
	}
}
