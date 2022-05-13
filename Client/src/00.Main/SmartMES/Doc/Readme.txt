--MainForm의 어셈블리이름은 속성에서 변경가능.
--어셈블리 이름을 변경하여 실행 파일명을 변경가능.

--Table Object 등록 (DataBase Script)
select ufn_saveObjectData('TableName');
--SO 생성
create so file.path:D:\SO file.package:kr.co.micube.common.mes.so tablename:EPT_M_LAYOUTEQUIPMENT
--Object Attribute Reload
reload objattr_schema owner:mesmgr