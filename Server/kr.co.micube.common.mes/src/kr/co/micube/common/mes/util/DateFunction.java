package kr.co.micube.common.mes.util;

import java.util.Date;

import kr.co.micube.common.mes.constant.TimeConstants;

public class DateFunction {
	
	/**
	 * startTime 과 endTime 의 차이를 시간단위로 반환한다.
	 * @param startTime 시작시간
	 * @param endTime 종료시간
	 * @return 차이시간(단위:시간)
	 */
	public static Double dateDiffInHours(Date startTime, Date endTime) {
		long diffInMilliSeconds = endTime.getTime() - startTime.getTime();
		return Long.valueOf(diffInMilliSeconds).doubleValue()
				/ (TimeConstants.MILLISECONDS_IN_SECOND * TimeConstants.SECONDS_IN_MINUTES * TimeConstants.MINUTES_IN_HOUR);
	}
	
	/**
	 * startTime 과 endTime 의 차이를 분단위로 반환한다.
	 * @param startTime 시작시간
	 * @param endTime 종료시간
	 * @return 차이시간(단위:분)
	 */
	public static Double dateDiffInMinutes(Date startTime, Date endTime) {
		long diffInMilliSeconds = endTime.getTime() - startTime.getTime();
		return Long.valueOf(diffInMilliSeconds).doubleValue()
				/ (TimeConstants.MILLISECONDS_IN_SECOND * TimeConstants.SECONDS_IN_MINUTES);
	}
}
