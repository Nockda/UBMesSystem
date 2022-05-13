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

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 라우터관리 > 품목라우터관리 > 팝업 > 품목 조회
    /// 업  무  설  명  : 품목조회 팝업을 이용해 맵핑한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-09
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class MappProductPopup : SmartPopupBaseForm
    {
        public MappProductPopup()
        {
            InitializeComponent();
            InitializeInfo();
        }

        #region 컨텐츠 영역 초기화

        /// <summary>        
        /// 품목조회 그리드를 초기화한다.
        /// </summary>
        private void InitializeInfo()
        {
            // 그리드 초기화
            grdInfo.GridButtonItem = GridButtonItem.Refresh;
            grdInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grdInfo.View.SetIsReadOnly();

            grdInfo.View.SetSortOrder("품목코드");
            grdInfo.View.SetAutoFillColumn("품목명");

            grdInfo.View.AddTextBoxColumn("품목코드", 100);
            grdInfo.View.AddTextBoxColumn("품목명", 120);
            grdInfo.View.AddTextBoxColumn("품목구분", 100);
            grdInfo.View.AddTextBoxColumn("품목분류", 100);
            grdInfo.View.AddTextBoxColumn("기종", 100);
            grdInfo.View.AddTextBoxColumn("LOT구분", 100);
            grdInfo.View.PopulateColumns();
        }

        #endregion
    }
}
