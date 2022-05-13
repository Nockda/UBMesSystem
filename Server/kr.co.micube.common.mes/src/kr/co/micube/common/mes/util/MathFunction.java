package kr.co.micube.common.mes.util;

public class MathFunction {
	
	/**
	 * number 의 소숫점 decimals 이하 자리를 버린다.
	 * 예) truncate(9.1234, 2) = 9.12
	 * @param number 숫자
	 * @param decimals 소숫점 자리수
	 * @return
	 */
	public static Double truncate(Double number, int decimals) {
		Double x = Math.pow(10, decimals);
		return Math.floor(number * x) / x;
	}
	
	/**
	 * number 의 소숫점 decimals 자리로 반올림한다.
	 * @param number 숫자
	 * @param decimals 소숫점 자리수
	 * @return
	 */
	public static Double round(Double number, int decimals) {
		Double x = Math.pow(10, decimals);
		return Long.valueOf(Math.round(number * x)).doubleValue() / x;
	}
}
