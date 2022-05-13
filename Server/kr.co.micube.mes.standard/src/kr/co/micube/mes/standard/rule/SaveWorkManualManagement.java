package kr.co.micube.mes.standard.rule;

import java.io.File;
import java.io.FileOutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Base64;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;

import kr.co.micube.common.mes.constant.ValidState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.so.CtWorkmanualData;
import kr.co.micube.common.mes.so.CtWorkmanualKey;
import kr.co.micube.common.mes.so.SfFileData;
import kr.co.micube.common.mes.so.SfFileKey;
import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.sql.SQLService;
import kr.co.micube.core.util.Generate;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.IDataRow;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.support.ISQLDataList;

/*
 * 프  로  그  램  명	: 기준정보 > 공정코드 > 작업매뉴얼 등록 / 조회
 * 설               명	: 작업 매뉴얼 등록
 * 생      성      자	: 정승원
 * 생      성      일	: 2020-06-19
 * 수   정   이   력	: 
 * 				  
 */


public class SaveWorkManualManagement extends DatasetRule{
	public void doEvent() throws Throwable {
		
		Date nowDate = SQLService.toDate();
		IData txnData = this.getMessage().getTxnData();
		
		String userId = txnData.get("user");
		
		IDataSet ds = this.getRequestDataset();
		IDataTable manualList = ds.getTable("manualList");
		IDataTable fileList = ds.getTable("fileList");

		/********************************************************************************************
		* CT_WORKMANUAL
		*********************************************************************************************/
		if(manualList != null && manualList.size() > 0)
		{
			IDataRow mRow = manualList.getFirstRow();
			String manualNo = mRow.getString("MANUALNO");
			
			CtWorkmanualData manual = new CtWorkmanualData();
			CtWorkmanualKey manualKey = manual.key();
			manualKey.setManualno(manualNo);
			
			manual = manual.selectOne();
			
			String drawingNo = mRow.getString("MANUALTYPE").equals("Drawing") ? mRow.getString("DRAWINGNO") : "";
			
			if(manual == null)
			{
				manualNo = Generate.createID();
				
				manual = new CtWorkmanualData();
				manualKey = manual.key();
				manualKey.setManualno(manualNo);
				manual.setManualid(mRow.getString("MANUALID"));
				manual.setManualname(mRow.getString("MANUALNAME"));
				manual.setManualversion("1");
				manual.setProcesssegmentid(mRow.getString("PROCESSSEGMENTID"));
				manual.setManualtype(mRow.getString("MANUALTYPE"));
				manual.setDrawingno(drawingNo);
				manual.setState(mRow.getString("STATE"));
				if(mRow.getString("STATE").equals("Scrap"))
				{
					manual.setScrapuser(userId);
					manual.setScrapdate(nowDate);
					manual.setValidstate(ValidState.INVALID);
				}
				else
				{
					manual.setScrapuser(null);
					manual.setScrapdate(null);
					manual.setValidstate(ValidState.VALID);
				}
				
				manual.setLasttxnid(this.getClass().getSimpleName());
				manual.insert();
			}
			else
			{
				manual.setManualid(mRow.getString("MANUALID"));
				manual.setManualname(mRow.getString("MANUALNAME"));
				
				//int revision = Integer.parseInt(manual.getManualversion());
				//manual.setManualversion(Integer.toString((revision + 1)));
				
				manual.setProcesssegmentid(mRow.getString("PROCESSSEGMENTID"));
				manual.setManualtype(mRow.getString("MANUALTYPE"));
				manual.setDrawingno(drawingNo);
				manual.setState(mRow.getString("STATE"));
				if(mRow.getString("STATE").equals("Scrap"))
				{
					manual.setScrapuser(userId);
					manual.setScrapdate(nowDate);
					manual.setValidstate(ValidState.INVALID);
				}
				else
				{
					manual.setScrapuser(null);
					manual.setScrapdate(null);
					manual.setValidstate(ValidState.VALID);
				}
				
				manual.setLasttxnid(this.getClass().getSimpleName());
				manual.update();
			}
			
			//등록된 파일 개수 반환
			SfFileData file = new SfFileData();
			ISQLCondition cond = new SQLCondition(false);
			cond.set(SfFileData.Manualno, manualNo);
			
			ISQLDataList<SfFileData> fileCount = file.select(cond);
			Map<String, Object> returnMap = new HashMap<String, Object>();
			returnMap.put("COUNT", fileCount.size());
			returnMap.put("MANUALNO", manualNo);
			
			IDataSet rpds = this.getResponseDataset(); 
			IDataTable responseDt = rpds.addTable("DATA");
			responseDt.addRow(returnMap);
		}
		
		/********************************************************************************************
		* SF_FILE
		*********************************************************************************************/
		if(fileList != null && fileList.size() > 0)
		{
			for(int i = 0; i < fileList.size(); i++)
			{
				IDataRow fRow = fileList.getRow(i);

				String path = "D:\\WorkManual\\" 
							+ fRow.getString("MANUALNO") + "\\"
							+ fRow.getString("MANUALVERSION");

				byte[] fileBytes = Base64.getDecoder().decode(fRow.getString("FILEDATA").getBytes("UTF-8"));
				if(fileBytes.length > 0)
				{
					try
					{
						File outFile = new File(path);
				        if(!outFile.exists())
				        {
				        	outFile.mkdirs();
				        }
				        
				        FileOutputStream stream = new FileOutputStream(outFile + "\\" + fRow.getString("FILENAME") + fRow.getString("FILEEXT"));
				        stream.write(fileBytes);
				        stream.close();
					}
					catch(Throwable e)
				    {
				        e.printStackTrace(System.out);
				    }
				}
				
				//파일정보 저장
		        SfFileData file = new SfFileData();
		        SfFileKey fileKey = file.key();
		        
		        fileKey.setManualno(fRow.getString("MANUALNO"));
		        fileKey.setManualversion(fRow.getString("MANUALVERSION"));

		        file = file.selectOne();
		        if(file == null)
		        {
		        	file = new SfFileData();
		        	fileKey = file.key();
		        	fileKey.setManualno(fRow.getString("MANUALNO"));
			        fileKey.setManualversion(fRow.getString("MANUALVERSION"));
			        file.setFilename(fRow.getString("FILENAME"));
			        file.setFilepath(path);
			        file.setFilesize(Double.valueOf(fileBytes.length));
			        file.setFileext(fRow.getString("FILEEXT"));
			        file.insert();
		        }
		        else
		        {
		        	if(file.getFilename() != fRow.getString("FILENAME"))
		        	{
		        		String fullName = path + "\\" + file.getFilename() + file.getFileext();
		        		String newFullName = path + "\\" + fRow.getString("FILENAME") + fRow.getString("FILEEXT");
		        		
		        		File f = new File(fullName);
		        		File nf = new File(newFullName);
		        		if(f.exists())
		        		{
		        			f.renameTo(nf);
		        			file.setFilename(fRow.getString("FILENAME"));
		        			
		        			f.delete();
		        		}
		        	}
		        	
		        	if(Double.valueOf(fileBytes.length) > 0)
		        	{
		        		file.setFilesize(Double.valueOf(fileBytes.length));
		        		file.setFileext(fRow.getString("FILEEXT"));
		        	}
		        	
			        
			        file.update();
		        }

		        //리비전 업데이트
		        CtWorkmanualData manual = new CtWorkmanualData();
				CtWorkmanualKey manualKey = manual.key();
				manualKey.setManualno(fRow.getString("MANUALNO"));
				
				manual = manual.selectOne();
				if(manual == null)
					return;
				
				int oldRevision = Integer.valueOf(manual.getManualversion());
				
		        int newRevision = Integer.valueOf(fRow.getString("MANUALVERSION"));
		        if(newRevision > 1 && oldRevision != newRevision)
		        {
		        	manual.setManualversion(fRow.getString("MANUALVERSION"));
		        	manual.update();
		        }
			}			
		}
		
		/********************************************************************************************
		* 파일데이터 클라이언트로 반환
		*********************************************************************************************/
		IMessage msg = this.getMessage().get();
	    IData jmsg = msg.get();
	    IData body = jmsg.get(MessageFormat.Body);
	    String manualNo = body.getString("manualNo");
	    String manualVersion = body.getString("manualVersion");
	    
	    if(StringUtils.isEmpty(manualNo) && StringUtils.isEmpty(manualVersion))
	    	return;
	    
	    SfFileData file = new SfFileData();
	    SfFileKey fileKey = file.key();
	    fileKey.setManualno(manualNo);
	    fileKey.setManualversion(manualVersion);
	    
	    file = file.selectOne();
	    if(file == null)
	    {
	    	//등록된 파일이 없습니다.
	    	throw new InValidDataException("NOTEXISTFILE");
	    }
	    
	    String fullPath = file.getFilepath() + "\\" + file.getFilename() + file.getFileext();
	    Path p = Paths.get(fullPath);
	    
	    byte[] fileBytes = Files.readAllBytes(p);
	    
	    Map<String, Object> returnMap = new HashMap<String, Object>();
		returnMap.put("FILEDATA", fileBytes);
		
		IDataSet rpds = this.getResponseDataset(); 
		IDataTable responseDt = rpds.addTable("DATA");
		responseDt.addRow(returnMap);
	}
}
