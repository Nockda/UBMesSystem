package kr.co.micube.mes.material.main;

import kr.co.micube.core.control.ComponentRegister;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.mes.material.rule.SaveConsumableLotHold;
import kr.co.micube.mes.material.rule.SaveConsumableLotMerge;
import kr.co.micube.mes.material.rule.SaveConsumableLotSplit;

public class ServiceContext {
		public static void start() throws SystemException {
			ComponentRegister cr = ComponentRegister.getInstance();
			cr.add(SaveConsumableLotHold.class);
			cr.add(SaveConsumableLotSplit.class);
			cr.add(SaveConsumableLotMerge.class);
		}
		
		public static void stop() throws SystemException {
			ComponentRegister cr = ComponentRegister.getInstance();
			cr.remove(SaveConsumableLotHold.class);
			cr.remove(SaveConsumableLotSplit.class);
			cr.remove(SaveConsumableLotMerge.class);
		}
}
