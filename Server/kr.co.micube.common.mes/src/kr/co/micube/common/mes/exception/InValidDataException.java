package kr.co.micube.common.mes.exception;

public class InValidDataException extends MESException {
	private static final long serialVersionUID = -8886439588391174269L;

	/**
	 * Example
	 * 		- throw new EESException(exceptionId);
	 * @param exceptionId
	 */
	public InValidDataException(String exceptionId) {
		super(exceptionId);
	}
	
	/**
	 * Example
	 * 		- throw new EESException(exceptionId, arg1, arg2 ...);
	 * @param exceptionId
	 * @param arguments
	 */
	public InValidDataException(String exceptionId, Object ... arguments) {
		super(exceptionId, arguments);
	}
	
	/**
	 * Example
	 * 		- throw new EESException(Exception Class)
	 * @param exception
	 */
	public InValidDataException(Throwable exception) {
		super(exception);
	}
}
