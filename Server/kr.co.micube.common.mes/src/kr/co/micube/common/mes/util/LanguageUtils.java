package kr.co.micube.common.mes.util;

import java.util.ArrayList;
import java.util.List;

import kr.co.micube.core.log.Log;
import kr.co.micube.core.sql.exception.DatabaseException;
import kr.co.micube.core.sql.exception.DuplicateTableNameException;
import kr.co.micube.tool.so.ISQLCondition;
import kr.co.micube.tool.so.SQLCondition;
import kr.co.micube.tool.so.mes.CodeData;
import kr.co.micube.tool.so.mes.CodeKey;
import kr.co.micube.tool.so.support.ISQLDataList;

public class LanguageUtils {
	public static List<String> _langType = null;
	
	static {
		_langType = new ArrayList<>();
		
		try {
			reloadLanguageTypes();
		} catch (Exception e) {
			Log.error(LanguageUtils.class, "Language.types.load.fail", e);
		}
	}
	
	public static void reloadLanguageTypes() throws DatabaseException, DuplicateTableNameException {
		ISQLCondition cond = new SQLCondition(false);
		cond.set(CodeData.Codeclassid);
		
		CodeData cd = new CodeData();
		CodeKey ck = cd.key();
		ck.setCodeclassid("LanguageType");
		
		ISQLDataList<CodeData> ret = cd.select(cond);
		for (int i = 0, len = ret.size(); i < len; i++) {
			_langType.add(ret.get(i).repository().getString("CODEID"));
		}
	}
	
	public static List<String> getLanguageTypes() {
		return new ArrayList<>(_langType);
	}
}