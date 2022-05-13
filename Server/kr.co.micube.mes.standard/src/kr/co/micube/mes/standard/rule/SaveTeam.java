package kr.co.micube.mes.standard.rule;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.mes.constant.TransactionId;
import kr.co.micube.common.mes.constant.UpsertState;
import kr.co.micube.common.mes.exception.InValidDataException;
import kr.co.micube.common.mes.exception.MESException;
import kr.co.micube.common.mes.so.CtTeamData;
import kr.co.micube.common.mes.so.CtTeamKey;
import kr.co.micube.common.mes.util.CommonUtils;
import kr.co.micube.common.mes.util.LanguageUtils;
import kr.co.micube.core.exception.SystemException;
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



public class SaveTeam extends DatasetRule {
	public void doEvent() throws Throwable {
		IDataSet ds = this.getRequestDataset();
		
		IDataTable dt = ds.getTable("list");
		
		ISQLUpsertBatch batch = new SQLUpsertBatch();
		
		if(dt != null)
		{
			IDataRow row = null;
			String state = null;
			
			for (int i = 0, len = dt.size(); i < len; i++) {
				row = dt.getRow(i);
				state = row.getString("_STATE_");
				switch (state) {
				case UpsertState.INSERT:
					batch.add(getInsertData(row, batch), SQLUpsertType.INSERT);
					break;
				case UpsertState.UPDATE:
					batch.add(getUpdateData(row, batch), SQLUpsertType.UPDATE);	
					break;
				case UpsertState.DELETE:
					batch.add(getDeleteData(row, batch), SQLUpsertType.DELETE);
					break;
				}
			}
		}
		
		batch.execute();
	}


	//TEAM Insert
	private CtTeamData getInsertData(IDataRow row, ISQLUpsertBatch batch)
			throws InValidDataException, DatabaseException, MESException, SystemException {
		CtTeamData TeamData = new CtTeamData();
		CtTeamKey TeamKey = TeamData.key();
		TeamKey.setTeamid(row.getString("TEAMID"));
		TeamData = TeamData.selectOne();
		
		if (TeamData != null) {
			throw new InValidDataException("InValidData002",String.format("TEAMID = %s"
					,row.getString("TEAMID")));
		}
		
		TeamData = new CtTeamData();
		TeamKey = TeamData.key();
		TeamKey.setTeamid(row.getString("TEAMID"));
		TeamData.setTeamname(row.getString("TEAMNAME$$KO-KR"));
		
		TeamData.setValidstate(row.getString("VALIDSTATE"));
		TeamData.setDescription(row.getString("DESCRIPTION"));

		
		String dictionaryId = row.getString("TEAMID");
		
		TeamData.setDictionaryid(dictionaryId);
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
			
		for (String lang : languageTypes) {
			if (!row.containsKey(CtTeamData.Teamname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(CtTeamData.Teamname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		
		TeamData.setLasttxnid(TransactionId.CREATE);
		return TeamData;
	}
	
	//TEAM Update
	private CtTeamData getUpdateData(IDataRow row, ISQLUpsertBatch batch)
			throws InValidDataException, DatabaseException, MESException, SystemException {
		CtTeamData TeamData = new CtTeamData();
		CtTeamKey TeamKey = TeamData.key();
		TeamKey.setTeamid(row.getString("TEAMID"));
		TeamData = TeamData.selectOne();

		
		
		if (TeamData == null) {
			throw new InValidDataException("InValidData001",String.format("TEAMID = %s"
					,row.getString("TEAMID")));
		}
		
		String dictionaryId = TeamData.getDictionaryid();
		if (StringUtils.isNullOrEmpty(dictionaryId))
		{
			dictionaryId = Generate.createID();
			TeamData.setDictionaryid(dictionaryId);
		}
		
		TeamData.setTeamname(row.getString("TEAMNAME$$KO-KR"));
		
		TeamData.setValidstate(row.getString("VALIDSTATE"));
		TeamData.setDescription(row.getString("DESCRIPTION"));
		
		Map<String, String> dictionaryMap = new HashMap<>();
		
		List<String> languageTypes = LanguageUtils.getLanguageTypes();
			
		for (String lang : languageTypes) {
			if (!row.containsKey(CtTeamData.Teamname.toUpperCase() + "$$" + lang.toUpperCase()))
				continue;
			
			dictionaryMap.put(lang, row.getString(CtTeamData.Teamname.toUpperCase() + "$$" + lang.toUpperCase()));
		}
		
		CommonUtils.appendDictionaryData(batch, dictionaryId, dictionaryMap);
		
		
		TeamData.setLasttxnid(TransactionId.MODIFY);
		return TeamData;
	}
	
	//TEAM Delete
	private CtTeamData getDeleteData(IDataRow row, ISQLUpsertBatch batch)
			throws InValidDataException, DatabaseException, MESException, SystemException {
		CtTeamData TeamData = new CtTeamData();
		CtTeamKey TeamKey = TeamData.key();
		TeamKey.setTeamid(row.getString("TEAMID"));
		TeamData = TeamData.selectOne();

		
		
		if (TeamData == null) {
			throw new InValidDataException("InValidData003",String.format("TEAMID = %s"
					,row.getString("TEAMID")));
		}

		TeamData.setLasttxnid(TransactionId.DELETE);

		return TeamData;
	}

}
