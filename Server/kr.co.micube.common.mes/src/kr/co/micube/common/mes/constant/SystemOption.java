package kr.co.micube.common.mes.constant;

// 옵션 활성/비활성 여부는 SF_CODE.DESCRIPTION 컬럼 사용
public class SystemOption {
	public static final String CODECLASSID = "SystemOption";	// Code Class ID
	public static final String CONSUME_UNTRACKED_MATERIALS = "ConsumeUnTrackedMaterials";	// 비추적 자재 MES 재고 소진여부(N : ERP 재고 소진, MES 재고 소진처리 안함, Y : ERP 재고 소진, MES 재고 소진)
	public static final String SHIP_LABEL_MATERIALS_LOT = "ShipLabelMaterialsLot"; // 출하라벨 발행시 LOT출하여부(N : 출하 안함, Y:출하)
	public static final String WORK_TIME_MANUAL_INPUT = "WorkTimeManualInput"; // 조립실적등록시 작업시간 수동입력가능여부(N : 수동입력불가, Y : 수동입력가능)
	public static final String WORK_TIME_MANUAL_INPUT_REPAIR = "WorkTimeManualInputREPAIR"; // 수리개조실적등록시 작업시간 수동입력가능여부(N : 수동입력불가, Y : 수동입력가능)
}
