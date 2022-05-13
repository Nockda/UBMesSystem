package kr.co.micube.common.worker.main;

import kr.co.micube.common.worker.service.WorkerService;
import kr.co.micube.core.exception.SystemException;

public class ServiceContext {
	public static void start() throws SystemException {
		WorkerService.startService();
	}
	
	public static void stop() throws SystemException {
		WorkerService.stopService();
	}
}
