package kr.co.micube.common.mes.util;

public class StringFunction {
	public static Boolean contains(String[] stringArray, String stringToFind) {
		for(int i = 0; i < stringArray.length; i++) {
			if(stringArray[i].equals(stringToFind)) {
				return true;
			}
		}
		return false;
	}
}
