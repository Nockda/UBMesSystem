package kr.co.micube.mes.com.rule;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.component.scheduler.SchedulerManager;
import kr.co.micube.component.scheduler.SchedulerParameter;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.util.StringUtils;
import kr.co.micube.tool.message.dataset.IDataSet;
import kr.co.micube.tool.message.dataset.IDataTable;
import kr.co.micube.tool.message.dataset.support.DatasetRule;

/*
 * 프  로  그  램  명	: 공정 관리 > 스케쥴 관리 > 스케쥴 관리
 * 설               명	: 스케쥴 관리 화면에서 조회버튼 클릭 시 데이터를 조회한다.
 * 생      성      자	: 황유성
 * 생      성      일	: 2019-10-04
 * 수   정   이   력	: 
 */

public class SearchScheduleManagement extends DatasetRule {
	@Override
	public void doEvent() throws Throwable {
		IMessage msg = this.getMessage().get();
		
		IData jmsg = msg.get();
		IData body = jmsg.get(MessageFormat.Body);
		
		String jobIdSearch = body.getString("jobid");
		String ruleIdSearch = body.getString("ruleid");
		
		IDataSet responseDataSet = this.getResponseDataset();
		IDataTable responseDataTable = responseDataSet.addTable("DATA");

		List<SchedulerParameter> list = SchedulerManager.getDetails();
		for(SchedulerParameter sp : list) {
			IData transaction = sp.getMessage().get("transaction");
			String jobName = transaction.getString("jobName");
			String id = transaction.getString("id");
			String cronText = sp.getCronContext();
			
			if((StringUtils.isNullOrEmpty(jobIdSearch) || jobName.toLowerCase().contains(jobIdSearch.toLowerCase()))
				&& (StringUtils.isNullOrEmpty(ruleIdSearch) || id.toLowerCase().contains(ruleIdSearch.toLowerCase()))) {
				Map<String, Object> map = new HashMap<>();
				map.put("JOBID", jobName);
				map.put("RULEID", id);
				map.put("CRONCONTEXT", cronText);
				responseDataTable.addRow(map);
			}
		}
	}
}