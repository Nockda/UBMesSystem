#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;

#endregion

namespace Micube.SmartMES.Process
{
    /// <summary>
    /// 프 로 그 램 명  : 공정관리 > 설비관리 > 팝업 > 설비보전 점검 등록
    /// 업  무  설  명  : 설비보전 점검 내용을 등록한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-06
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class EquipCheckRegPopup : SmartPopupBaseForm
    {
        public EquipCheckRegPopup()
        {
            InitializeComponent();

            InitializeCheckInfo();
        }

        #region 컨텐츠 영역 초기화

        /// <summary>        
        /// 작업지시 정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeCheckInfo()
        {
            // 그리드 초기화
            grdCheckInfo.GridButtonItem = GridButtonItem.Refresh;

            grdCheckInfo.View.SetIsReadOnly();

            grdCheckInfo.View.SetSortOrder("점검구분");
            grdCheckInfo.View.SetAutoFillColumn("점검항목명");

            grdCheckInfo.View.AddTextBoxColumn("점검구분", 100);
            grdCheckInfo.View.AddTextBoxColumn("점검부위", 100);
            grdCheckInfo.View.AddTextBoxColumn("점검항목명", 200);
            grdCheckInfo.View.AddTextBoxColumn("점검주기", 100);
            grdCheckInfo.View.AddTextBoxColumn("점검방법", 100);
            grdCheckInfo.View.AddTextBoxColumn("결과구분", 100);
            grdCheckInfo.View.AddTextBoxColumn("결과", 100);
            grdCheckInfo.View.AddTextBoxColumn("측정값", 100);
            grdCheckInfo.View.AddTextBoxColumn("CREATOR", 100);
            grdCheckInfo.View.AddTextBoxColumn("CREATEDTIME", 150);
            grdCheckInfo.View.AddTextBoxColumn("MODIFIER", 100);
            grdCheckInfo.View.AddTextBoxColumn("MODIFIEDTIME", 150);
            grdCheckInfo.View.PopulateColumns();
        }

        #endregion
    }
}
