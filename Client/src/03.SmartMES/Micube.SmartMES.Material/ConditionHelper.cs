using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micube.SmartMES.Material
{

    /// <summary>
    /// 프 로 그 램 명  : 자재관리 
    /// 업  무  설  명  : 자재관리에서 공통으로 사용하는 팝업 조회조건 관리
    /// 생    성    자  : 강유라
    /// 생    성    일  : 2020-06-09
    /// 수  정  이  력  : 2020-06-30 유태근 / 자재 Lot 조회하는 팝업 추가
    /// 
    /// 
    /// </summary>
    /// 
    class ConditionHelper
    {
        #region 품목(자재, 제품) 팝업 초기화

        /// <summary>
        /// 품목(자재, 제품) 선택하는 팝업
        /// </summary>
        /// <param name="id"></param>
        /// <param name="position"></param>
        /// <param name="isMultiSelect"></param>
        /// <param name="conditions"></param>
        /// <param name="displayFieldName"></param>
        /// <returns></returns>
        public static ConditionCollection AddConditionConsumProductPopup(string id, double position, bool isMultiSelect, ConditionCollection conditions, string displayFieldName = "ITEMNAME")
        {
            // SelectPopup 항목 추가
            var conditionConsumProductId = conditions.AddSelectPopup(id, new SqlQuery("GetConsumProductList", "00001", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), displayFieldName, "ITEMID")
                .SetPopupLayout("SELECTPRODUCTDEFID", PopupButtonStyles.Ok_Cancel, true, true)
                .SetPopupLayoutForm(600, 800)
                .SetLabel("ITEMNAME")
                .SetPosition(position)
                .SetPopupAutoFillColumns("ITEMNAME");

            // 복수 선택 여부에 따른 Result Count 지정
            if (isMultiSelect)
                conditionConsumProductId.SetPopupResultCount(0);
            else
                conditionConsumProductId.SetPopupResultCount(1);

            // 팝업에서 사용되는 검색조건 (품목코드/명)
            conditionConsumProductId.Conditions.AddTextBox("P_ITEMIDNAME").SetLabel("PRODUCTDEFIDNAME");

            // 팝업 그리드에서 보여줄 컬럼 정의
            // 품목코드
            conditionConsumProductId.GridColumns.AddTextBoxColumn("PARTNUMBER", 150);
            //conditionConsumProductId.GridColumns.AddTextBoxColumn("ITEMID", 150);
            // 품목명
            conditionConsumProductId.GridColumns.AddTextBoxColumn("ITEMNAME", 200);
            //품목버전
            //conditionConsumProductId.GridColumns.AddTextBoxColumn("ITEMVERSION", 200);

            return conditions;
        }

        #endregion

        #region 자재 Lot 팝업 초기화

        /// <summary>
        /// 자재 Lot 선택하는 팝업
        /// </summary>
        /// <param name="id"></param>
        /// <param name="position"></param>
        /// <param name="isMultiSelect"></param>
        /// <param name="conditions"></param>
        /// <param name="displayFieldName"></param>
        /// <returns></returns>
        public static ConditionCollection AddConditionConsumableLotPopup(string id, double position, bool isMultiSelect, ConditionCollection conditions, string relationConditionId = "NONE", string label = "CONSUMABLELOTID", string displayFieldName = "CONSUMABLELOTID")
        {
            // SelectPopup 항목 추가
            var conditionConsumableLotId = conditions.AddSelectPopup(id, new SqlQuery("GetConsumableLotList", "00002", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), displayFieldName, "CONSUMABLELOTID")
                .SetPopupLayout("SELECTCONSUMABLELOTID", PopupButtonStyles.Ok_Cancel, true, true)
                .SetPopupLayoutForm(600, 800)
                .SetLabel(label)
                .SetPosition(position)
                .SetPopupAutoFillColumns("CONSUMABLELOTID");

            // 복수 선택 여부에 따른 Result Count 지정
            if (isMultiSelect)
                conditionConsumableLotId.SetPopupResultCount(0);
            else
                conditionConsumableLotId.SetPopupResultCount(1);

            // 릴레이션 조회조건 지정
            if (!relationConditionId.Equals("NONE"))
                conditionConsumableLotId.SetRelationIds(relationConditionId);

            // 팝업에서 사용되는 검색조건 (품목코드/명)
            conditionConsumableLotId.Conditions.AddTextBox("P_CONSUMABLELOTID").SetLabel("CONSUMABLELOTID");

            // 팝업 그리드에서 보여줄 컬럼 정의
            // 자재 Lot Id
            conditionConsumableLotId.GridColumns.AddTextBoxColumn("CONSUMABLELOTID", 120);
            // 작업장
            conditionConsumableLotId.GridColumns.AddTextBoxColumn("AREANAME", 100);
            // 창고
            conditionConsumableLotId.GridColumns.AddTextBoxColumn("WAREHOUSENAME", 100);
            // 위치
            conditionConsumableLotId.GridColumns.AddTextBoxColumn("LOCATIONID", 100);

            return conditions;
        }

        #endregion
    }
}
