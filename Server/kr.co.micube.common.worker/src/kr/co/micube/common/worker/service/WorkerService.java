package kr.co.micube.common.worker.service;

import java.util.HashMap;
import java.util.Map;

import kr.co.micube.common.util.MessageFormat;
import kr.co.micube.component.nio.kafka.ConsumerPartitioner;
import kr.co.micube.component.nio.kafka.IKafkaHandler;
import kr.co.micube.component.nio.kafka.IKafkaResult;
import kr.co.micube.component.nio.kafka.KafkaContext;
import kr.co.micube.component.nio.kafka.KafkaMessage;
import kr.co.micube.component.nio.kafka.KafkaSession;
import kr.co.micube.core.config.Configuration;
import kr.co.micube.core.control.ComponentService;
import kr.co.micube.core.control.IComponentService;
import kr.co.micube.core.dto.DataRepository;
import kr.co.micube.core.dto.IData;
import kr.co.micube.core.dto.IParameter;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.core.log.Log;
import kr.co.micube.core.nio.IMessage;
import kr.co.micube.core.nio.ISession;
import kr.co.micube.tool.worker.WorkerFactory;

public class WorkerService implements IComponentService {

	private static final String DEF_WORKER_EVENTID = "WORKER";
	private static final String DEF_CONSUMER_KEY = "SF2x";
	
	private static WorkerService _cs = null;
	
	public static WorkerService instance() {
		if (_cs == null)
			_cs = new WorkerService();
		
		return _cs;
	}
	
	public static void startService() throws SystemException {
		if (_cs == null)
			instance();
		
		_cs.setTopicName(KafkaContext.getDestination(DEF_CONSUMER_KEY));
		_cs.setGroupId(KafkaContext.getGroupId(DEF_CONSUMER_KEY));
		_cs.setBrokerUrl(KafkaContext.getBrokerUrl(DEF_CONSUMER_KEY));
		_cs.setAutoOffsetReset(KafkaContext.getAutoOffsetResetConfig(DEF_CONSUMER_KEY));

		ComponentService.add(_cs);
		
		Log.info(
			WorkerService.class, 
			"{0} Communication.Service.Topic.Start ... {1}, {2}, {3}", 
				DEF_CONSUMER_KEY,
				_cs.getTopicName(), 
				_cs.getGroupId()
		);
	}
	
	public static void stopService() throws SystemException {
		if (_cs == null)
			return;
		
		_cs.stop();
	}
	
	private Map<String, Object> _map = null;
	private ConsumerPartitioner _cp = null;
	private String _topicName = null;
	private String _groupId = null;
	private String _autoOffsetReset = null;
	private String _brokerUrl = null;
	private long _durationTime = 10000;
	
	public WorkerService() {
		this._map = new HashMap<>();
	}
	
	public long getDurationTime() {
		return _durationTime;
	}
	
	public void setDurationTime(long time) {
		this._durationTime = time;
	}
	
	public String getBrokerUrl() {
		return _brokerUrl;
	}
	
	public void setBrokerUrl(String url) {
		this._brokerUrl = url;
	}
	
	public String getAutoOffsetReset() {
		return _autoOffsetReset;
	}
	
	public void setAutoOffsetReset(String autoOffsetReset) {
		this._autoOffsetReset = autoOffsetReset;
	}
	
	public String getGroupId() {
		return _groupId;
	}
	
	public void setGroupId(String id) {
		this._groupId = id;
	}
	
	public String getTopicName() {
		return _topicName;
	}
	
	public void setTopicName(String name) {
		this._topicName = name;
	}
	
	public void setTopicName(IParameter params) {
		if (params == null || params.size() == 0)
			return;
		
		for (String key : params) {
			this._topicName = key;
			break;
		}
	}
	
	@Override
	public String name() {
		return "WorkerService";
	}

	@SuppressWarnings("unchecked")
	public <T> T parameter(String arg0) {
		return (T)_map.get(arg0);
	}

	public void setParameter(String arg0, Object arg1) {
		_map.put(arg0, arg1);
	}

	@Override
	public void start() throws SystemException {
		WorkerFactory.setDiscardTime(10000);
		_cp = new ConsumerPartitioner(DEF_WORKER_EVENTID);
		_cp.setGroupId(_groupId);
		_cp.setBrokerUrl(_brokerUrl);
		_cp.setPoolDurationTime(_durationTime);
		_cp.setAutoOffsetResetConfig(_autoOffsetReset);
		_cp.setAutoCommit(true);
		_cp.setAutoCommitInterval(1000);
		_cp.setSessionTimeout(10000);
		_cp.setConnectionsMaxIdle(300);
		_cp.setInitSeekToEnd(true);
		_cp.addTopicPartition(_topicName, 0);
		
		
		StringBuffer sb = new StringBuffer();
		sb.append("\n");
		sb.append("--------------------------------------------");
		sb.append("\n");
		sb.append("GroupID: ");
		sb.append(_groupId);
		sb.append("\n");
		sb.append("BrokerUrl: ");
		sb.append(_brokerUrl);
		sb.append("\n");
		sb.append("DurationTime: ");
		sb.append(_durationTime);
		sb.append("\n");
		sb.append("TopicName: ");
		sb.append(_topicName);
		sb.append("\n");
		sb.append("AutoOffsetReset: ");
		sb.append(_autoOffsetReset);
		sb.append("\n");
		sb.append("--------------------------------------------");
		sb.append("\n");
		
		Log.info(this, ">>>>>>>>>>>> {0}", sb);
		
		_cp.setReceiveHandler(new IKafkaHandler() {
			private static final long serialVersionUID = -4600697316979500272L;

			@Override
			public void invoke(IKafkaResult krd) throws SystemException {
				IData value = DataRepository.create(krd.getValue());
				IData head = value.get(MessageFormat.Head);
				if (head == null)
					head = value.set(MessageFormat.Head);
				
				IData trans = value.get(MessageFormat.Transaction);
				if (trans == null)
					trans = value.set(MessageFormat.Transaction);
				
				trans.set("createTime", krd.getCreateTime());
				
				IData body = value.get(MessageFormat.Body);
				if (body == null)
					body = value.set(MessageFormat.Body);
				
				IData result = value.get(MessageFormat.Result);
				if (result == null)
					result = value.set(MessageFormat.Result);
				
				if (!result.containsKey(MessageFormat.Result_Data))
					result.set(MessageFormat.Result_Data);
				
				IData info = DataRepository.create();
				info.set("offset", krd.getOffset());
				info.set("consumerKey", krd.getConsumerKey());
				info.set("resultKey", krd.getKey());
				info.set("partition", krd.getPartition());
				info.set("topicName", krd.getTopicName());
				head.set("kafka", info);
				
				ISession<IData> sess = new KafkaSession(krd);
				IMessage msg = new KafkaMessage(sess, value);
				
				// 키 생성
				String key = trans.getString(MessageFormat.Transaction_ID) + "-" + body.getString("EQPID");
				
				WorkerFactory.add(DEF_WORKER_EVENTID, key, msg);
			}
		});
		_cp.start();
	}

	@Override
	public void stop() throws SystemException {
		if (_cp == null)
			return;
		
		_cp.stop();
	}

	@Override
	public Configuration configuration() {
		// TODO Auto-generated method stub
		return null;
	}

}
