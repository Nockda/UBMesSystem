package kr.co.micube.mes.standard.main;

import kr.co.micube.core.control.ComponentRegister;
import kr.co.micube.core.exception.SystemException;
import kr.co.micube.mes.standard.rule.MappingConsumableInfo;
import kr.co.micube.mes.standard.rule.MappingProductInfo;
import kr.co.micube.mes.standard.rule.SaveAreaWorker;
import kr.co.micube.mes.standard.rule.SaveEquipment;
import kr.co.micube.mes.standard.rule.SaveEquipmentClass;
import kr.co.micube.mes.standard.rule.SaveInspImageManagement;
import kr.co.micube.mes.standard.rule.SaveModelByProcess;
import kr.co.micube.mes.standard.rule.SaveProcessCode2;
import kr.co.micube.mes.standard.rule.SaveProcessDefinitionMgt;
import kr.co.micube.mes.standard.rule.SaveProcessStandard;
import kr.co.micube.mes.standard.rule.SaveProcessWorker;
import kr.co.micube.mes.standard.rule.SaveSpecManagement;
import kr.co.micube.mes.standard.rule.SaveTeam;
import kr.co.micube.mes.standard.rule.SaveUnit;
import kr.co.micube.mes.standard.rule.SaveWorkManualManagement;


public class ServiceContext {
		public static void start() throws SystemException {
			ComponentRegister cr = ComponentRegister.getInstance();
			cr.add(SaveSpecManagement.class);
			cr.add(SaveProcessDefinitionMgt.class);
			cr.add(SaveInspImageManagement.class);
			cr.add(MappingConsumableInfo.class);
			cr.add(MappingProductInfo.class);
			cr.add(SaveProcessStandard.class);
			cr.add(SaveProcessCode2.class);
			cr.add(SaveEquipmentClass.class);
			cr.add(SaveEquipment.class);
			cr.add(SaveAreaWorker.class);
			cr.add(SaveProcessWorker.class);
			cr.add(SaveWorkManualManagement.class);
			cr.add(SaveModelByProcess.class);
			cr.add(SaveTeam.class);
			cr.add(SaveUnit.class);
			
		}
		
		public static void stop() throws SystemException {
			ComponentRegister cr = ComponentRegister.getInstance();
			cr.remove(SaveSpecManagement.class);
			cr.remove(SaveProcessDefinitionMgt.class);
			cr.remove(SaveInspImageManagement.class);
			cr.remove(MappingConsumableInfo.class);
			cr.remove(MappingProductInfo.class);
			cr.remove(SaveProcessStandard.class);
			cr.remove(SaveProcessCode2.class);
			cr.remove(SaveEquipmentClass.class);
			cr.remove(SaveEquipment.class);
			cr.remove(SaveAreaWorker.class);
			cr.remove(SaveProcessWorker.class);
			cr.remove(SaveWorkManualManagement.class);
			cr.remove(SaveModelByProcess.class);
			cr.remove(SaveTeam.class);
			cr.remove(SaveUnit.class);

		}
}
