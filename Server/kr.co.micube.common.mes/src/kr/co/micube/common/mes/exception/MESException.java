package kr.co.micube.common.mes.exception;

import kr.co.micube.core.exception.SystemException;

public class MESException extends SystemException {
	private static final long serialVersionUID = 1533240743560925804L;

	/**
	 * Example
	 * 		- throw new EESException(exceptionId);
	 * @param exceptionId
	 */
	public MESException(String exceptionId) {
		super(exceptionId);
	}
	
	/**
	 * Example
	 * 		- throw new EESException(exceptionId, arg1, arg2 ...);
	 * @param exceptionId
	 * @param arguments
	 */
	public MESException(String exceptionId, Object ... arguments) {
		super(exceptionId, arguments);
	}
	
	/**
	 * Example
	 * 		- throw new EESException(Exception Class)
	 * @param exception
	 */
	public MESException(Throwable exception) {
		super(exception);
	}
}
