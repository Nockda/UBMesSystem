#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;

#endregion

namespace Micube.SmartMES.SystemManagement
{
    /// <summary>
    /// 프 로 그 램 명  : 시스템 관리 > 모니터링 > ERP I/F 모니터링
    /// 업  무  설  명  : ERP I/F 로그를 확인한다.
    /// 생    성    자  : 모세찬
    /// 생    성    일  : 2020-07-09
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class ErpInterfaceLog : SmartConditionBaseForm
    {
        public ErpInterfaceLog()
        {
            InitializeComponent();
        }

        #region 컨텐츠 영역 초기화

        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();

            // 컨트롤 초기화 로직 구성
            InitializeMaster();
            InitializeDetail();
        }

        /// <summary>
        /// 마스터 그리드를 초기화한다.
        /// </summary>
        private void InitializeMaster()
        {
            grdMaster.GridButtonItem = GridButtonItem.None;

            grdMaster.View.SetIsReadOnly();
            grdMaster.View.SetAutoFillColumn("INTERFACENAME");
            grdMaster.View.SetSortOrder("INTERFACEID");

            grdMaster.View.AddTextBoxColumn("INTERFACEID", 80)
                .SetTextAlignment(TextAlignment.Center);
            grdMaster.View.AddTextBoxColumn("INTERFACENAME", 120)
                .SetTextAlignment(TextAlignment.Center);
            //grdMaster.View.AddTextBoxColumn("EXECUTIONCYCLE", 90)
            //    .SetTextAlignment(TextAlignment.Center);

            grdMaster.View.PopulateColumns();
        }

        /// <summary>
        /// 디테일 그리드를 초기화한다.
        /// </summary>
        private void InitializeDetail()
        {
            grdDetail.GridButtonItem = GridButtonItem.Export;

            grdDetail.View.SetIsReadOnly();
            grdDetail.View.SetAutoFillColumn("PROGRESULT");
            grdDetail.View.SetSortOrder("CREATEDTIME", DevExpress.Data.ColumnSortOrder.Descending);
            //grdDetail.View.OptionsView.EnableAppearanceEvenRow = false;
            //grdDetail.View.OptionsView.EnableAppearanceOddRow = false;

            grdDetail.View.AddTextBoxColumn("INTERFACEID", 80)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsHidden();
            grdDetail.View.AddTextBoxColumn("INTERFACENAME", 120)
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("INTERFACETYPE", 80)
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("TXNHISTKEY", 160)
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("CREATEDTIME", 150)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("RECVYN", 70)
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("RECVDATETIME", 150)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("PROGSTATUS", 50)
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("PROGRESULT", 250);

            grdDetail.View.PopulateColumns();
        }

        #endregion

        #region Event
        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            grdMaster.View.FocusedRowChanged += View_FocusedRowChanged;
            grdDetail.View.RowStyle += View_RowStyle;
        }

        

        private void View_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            grdMasterFocusedRowChanged();
        }

        private void View_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (grdDetail.View.GetRowCellValue(e.RowHandle, "PROGSTATUS") == null) return;
            if (!grdDetail.View.GetRowCellValue(e.RowHandle, "PROGSTATUS").Equals("0"))
            {
                e.Appearance.BackColor = Color.FromArgb(30, 255, 0, 0);
                e.HighPriority = true;
            }
        }

        #endregion

        #region Search

        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dtInfo = await QueryAsync("GetInterfaceDefinition", "00001", values);

            if (dtInfo.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdMaster.DataSource = dtInfo;
            grdMasterFocusedRowChanged();
        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

        }

        #endregion

        #region Private Function

        private void grdMasterFocusedRowChanged()
        {
            DataRow dr = grdMaster.View.GetFocusedDataRow();
            var values = Conditions.GetValues();
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_DATEPERIOD_PERIODFR", values["P_DATEPERIOD_PERIODFR"]);
            param.Add("P_DATEPERIOD_PERIODTO", values["P_DATEPERIOD_PERIODTO"]);
            param.Add("P_INTERFACEID", dr["INTERFACEID"]);

            DataTable dtDetail = SqlExecuter.Query("GetInterfaceDetail", "00001", param);

            grdDetail.DataSource = dtDetail;
        }

        #endregion
    }
}
