package kr.co.micube.mes.quality.main;

import kr.co.micube.core.control.ComponentRegister;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.mes.quality.rule.SaveClaimManagerReg;
import kr.co.micube.mes.quality.rule.SaveDefectRegManagement;
import kr.co.micube.mes.quality.rule.SaveDefectRegist;
import kr.co.micube.mes.quality.rule.SaveDefectRegistChangeState;
import kr.co.micube.mes.quality.rule.SaveMaterialIQC;
import kr.co.micube.mes.quality.rule.SaveProductOQC;
import kr.co.micube.mes.quality.rule.SaveSearchProductOQC;
import kr.co.micube.mes.quality.rule.SaveXManage;

public class ServiceContext {
		public static void start() throws SystemException {
			ComponentRegister cr = ComponentRegister.getInstance();
			cr.add(SaveDefectRegist.class);
			cr.add(SaveDefectRegistChangeState.class);
			cr.add(SaveDefectRegManagement.class);
			cr.add(SaveXManage.class);
			cr.add(SaveClaimManagerReg.class);
			cr.add(SaveMaterialIQC.class);
			cr.add(SaveProductOQC.class);
			cr.add(SaveSearchProductOQC.class);
		}
		
		public static void stop() throws SystemException {
			ComponentRegister cr = ComponentRegister.getInstance();
			cr.remove(SaveDefectRegist.class);
			cr.remove(SaveDefectRegistChangeState.class);
			cr.remove(SaveDefectRegManagement.class);
			cr.remove(SaveXManage.class);
			cr.remove(SaveClaimManagerReg.class);		
			cr.remove(SaveMaterialIQC.class);
			cr.remove(SaveProductOQC.class);
			cr.remove(SaveSearchProductOQC.class);
		}
}
