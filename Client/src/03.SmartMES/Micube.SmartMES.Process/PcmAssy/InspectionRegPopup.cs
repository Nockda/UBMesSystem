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
    /// 프 로 그 램 명  : 공정관리 > 실적관리 > 조립실적 등록 > 팝업 > 검사실적 등록
    /// 업  무  설  명  : 검사실적 팝업을 이용해 등록한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2019-03-06
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class InspectionRegPopup : SmartPopupBaseForm
    {
        public InspectionRegPopup()
        {
            InitializeComponent();

            InitializeInsp();
        }

        #region 컨텐츠 영역 초기화

        /// <summary>        
        /// 작업지시 정보 그리드를 초기화한다.
        /// </summary>
        private void InitializeInsp()
        {
            // 그리드 초기화
            grdInsp.GridButtonItem = GridButtonItem.None;

            grdInsp.View.SetIsReadOnly();

            //grdInsp.View.SetSortOrder("점검구분");
            //grdInsp.View.SetAutoFillColumn("점검항목명");

            grdInsp.View.AddTextBoxColumn("1-1 M", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.AddTextBoxColumn("1-1 X", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.AddTextBoxColumn("1-2 M", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.AddTextBoxColumn("1-2 X", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.AddTextBoxColumn("1-3 M", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.AddTextBoxColumn("1-3 X", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.AddTextBoxColumn("1-4 M", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.AddTextBoxColumn("1-4 X", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.AddTextBoxColumn("1-5 M", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.AddTextBoxColumn("1-5 X", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.AddTextBoxColumn("1-6 M", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.AddTextBoxColumn("1-6 X", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.AddTextBoxColumn("1-7 M", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.AddTextBoxColumn("1-7 X", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.AddTextBoxColumn("1-8 M", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.AddTextBoxColumn("1-8 X", 80);
            grdInsp.View.AddTextBoxColumn("SP", 40);
            grdInsp.View.PopulateColumns();
        }

        #endregion
    }
}
