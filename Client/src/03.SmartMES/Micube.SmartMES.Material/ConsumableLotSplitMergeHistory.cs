#region using

using DevExpress.XtraGrid.Views.Grid;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.Material
{
    /// <summary>
    /// 프 로 그 램 명  : 자재관리 > 자재 Lot 관리 > 자재 분할/병합이력
    /// 업  무  설  명  : 자재 분할/병합된 이력을 조회한다.
    /// 생    성    자  : 유태근
    /// 생    성    일  : 2020-06-30
    /// 수  정  이  력  : 2020-07-16 | 이준용 | PARTNUMBER 변경
    /// 
    /// 
    /// </summary>
    public partial class ConsumableLotSplitMergeHistory : SmartConditionBaseForm
    {
        #region Local Variables

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public ConsumableLotSplitMergeHistory()
        {
            InitializeComponent();
        }

        #endregion

        #region 컨텐츠 영역 초기화

        /// <summary>
        /// 화면의 컨텐츠 영역을 초기화한다.
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();

            InitializeGrid();
        }

        /// <summary>        
        /// 자재 분할/병합 그리드
        /// </summary>
        private void InitializeGrid()
        {
            grdHistory.GridButtonItem = GridButtonItem.Export;
            grdHistory.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdHistory.View.SetAutoFillColumn("PRODUCTDEFNAME");
            grdHistory.View.SetIsReadOnly();

            // 자재 Lot Id
            grdHistory.View.AddTextBoxColumn("CONSUMABLELOTID", 120);
            // 품목 Id
            //grdHistory.View.AddTextBoxColumn("PRODUCTDEFID", 120);
            grdHistory.View.AddTextBoxColumn("PARTNUMBER", 120);
            // 품목명
            grdHistory.View.AddTextBoxColumn("PRODUCTDEFNAME", 250);
            // 규격
            grdHistory.View.AddTextBoxColumn("STANDARD", 120);
            // 창고명
            grdHistory.View.AddTextBoxColumn("WAREHOUSENAME", 120);
            // 수량
            grdHistory.View.AddSpinEditColumn("QTY", 80);
            // 구분
            grdHistory.View.AddTextBoxColumn("TYPE", 80)
                .SetTextAlignment(TextAlignment.Center);
            // Target 자재 Lot Id
            grdHistory.View.AddTextBoxColumn("TARGETCONSUMABLELOTID", 120);
            // 대상수량
            grdHistory.View.AddSpinEditColumn("TARGETQTY", 80);
            // 생성자
            grdHistory.View.AddTextBoxColumn("CREATOR", 100)
                .SetTextAlignment(TextAlignment.Center);
            // 생성일시
            grdHistory.View.AddDateEditColumn("CREATEDTIME", 120)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss", MaskTypes.DateTime);

            grdHistory.View.PopulateColumns();

            grdHistory.View.OptionsNavigation.AutoMoveRowFocus = false;
            grdHistory.View.OptionsView.AllowCellMerge = true; 
        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            grdHistory.View.CellMerge += View_CellMerge;
            grdHistory.View.RowStyle += View_RowStyle;
            grdHistory.View.RowCellStyle += View_RowCellStyle;
        }

        /// <summary>
        /// 행 Merge된 부분 색깔변경 안하기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "CONSUMABLELOTID" || e.Column.FieldName == "PARTNUMBER"
                || e.Column.FieldName == "PRODUCTDEFNAME" || e.Column.FieldName == "STANDARD"
                || e.Column.FieldName == "QTY" || e.Column.FieldName == "TYPE"
                || e.Column.FieldName == "WAREHOUSENAME")
            {
                e.Appearance.BackColor = Color.White;
            }
        }

        /// <summary>
        /// 포커스 받은 Row 색깔 표시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            int rowIndex = grdHistory.View.FocusedRowHandle;

            if (rowIndex == e.RowHandle)
            {
                e.Appearance.BackColor = Color.FromArgb(254, 254, 16);
                e.HighPriority = true;
            }
        }

        /// <summary>
        /// 사용자 지정 Cell Merge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null)
            {
                return;
            }

            if (e.Column.FieldName == "CONSUMABLELOTID" || e.Column.FieldName == "PARTNUMBER"
                || e.Column.FieldName == "PRODUCTDEFNAME" || e.Column.FieldName == "STANDARD"
                || e.Column.FieldName == "QTY" || e.Column.FieldName == "TYPE"
                || e.Column.FieldName == "WAREHOUSENAME")
            {
                string str1 = view.GetRowCellDisplayText(e.RowHandle1, e.Column);
                string str2 = view.GetRowCellDisplayText(e.RowHandle2, e.Column);
                e.Merge = (str1 == str2);
            }
            else
            {
                e.Merge = false;
            }
            e.Handled = true;
        }

        #endregion

        #region 툴바

        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            DataTable changed = grdHistory.GetChangedRows();

            ExecuteRule("SaveCodeClass", changed);
        }

        #endregion

        #region 검색

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("P_LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable dt = await SqlExecuter.QueryAsync("SelectConsumableLotSplitMergeHistory", "00001", values);

            if (dt.Rows.Count < 1)
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }

            grdHistory.DataSource = dt;
            grdHistory.View.FocusedRowHandle = -1;
        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            // TODO : 조회조건 추가 구성이 필요한 경우 사용
            ConditionHelper.AddConditionConsumProductPopup("P_CONSUMABLEDEFID", 3, false, Conditions);
            ConditionHelper.AddConditionConsumableLotPopup("P_CONSUMABLELOTID", 4, false, Conditions, "P_CONSUMABLEDEFID");
            ConditionHelper.AddConditionConsumableLotPopup("P_TARGETCONSUMABLELOTID", 5, false, Conditions, "P_CONSUMABLEDEFID", "TARGETCONSUMABLELOTID");
        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            DateTime today = DateTime.Now.Date;
            DateTime fisrtDay = today.AddDays(1 - today.Day); // 현재월의 첫째날
            DateTime lastDay = fisrtDay.AddMonths(1).AddDays(-1); // 현재월의 마지막날

            // TODO : 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용
            SmartPeriodEdit fromDate = Conditions.GetControl<SmartPeriodEdit>("P_DATEPERIOD");
            fromDate.datePeriodFr.EditValue = fisrtDay;

            SmartPeriodEdit toDate = Conditions.GetControl<SmartPeriodEdit>("P_DATEPERIOD");
            toDate.datePeriodTo.EditValue = lastDay;
        }

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터를 저장 할 때 컨텐츠 영역의 유효성을 검사한다.
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();

            // TODO : 유효성 로직 변경
            grdHistory.View.CheckValidation();

            DataTable changed = grdHistory.GetChangedRows();

            if (changed.Rows.Count == 0)
            {
                // 저장할 데이터가 존재하지 않습니다.
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function

        #endregion
    }
}