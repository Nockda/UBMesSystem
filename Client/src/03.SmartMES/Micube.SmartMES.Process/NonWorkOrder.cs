using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micube.SmartMES.Process
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 공정실적등록 > 무지시공정
    /// 업  무  설  명  : 무지시공정 실적등록
    /// 생    성    자  : yshwang
    /// 생    성    일  : 2020-06-02
    /// 수  정  이  력  : 
    /// </summary>
    public partial class NonWorkOrder : SmartConditionBaseForm
    {
        public NonWorkOrder()
        {
            InitializeComponent();
        }

        #region 컨텐츠 영역 초기화
        /// <summary>
        /// 화면의 컨텐츠 영역을 초기화한다.
        /// </summary>
        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeGrid();
            InitializeSummary();
            InitializeEvent();
        }

        /// <summary>
        /// 검색조건 설정
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();
            InitializeConditionConsumableDef_Popup();
        }

        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            SetConditionVisiblility("P_DATEPERIOD", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
            SetConditionVisiblility("P_PARENTCONSUMABLELOTID", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
            SetConditionVisiblility("P_CONSUMABLELOTID", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
        }

        /// <summary>
        /// 자재코드 검색조건 팝업
        /// </summary>
        private void InitializeConditionConsumableDef_Popup()
        {
            var popup = this.Conditions.AddSelectPopup("P_CONSUMABLEDEFID", new SqlQuery("GetNonOrderConsumableDefList", "00001"
                    , $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "CONSUMABLEDEFNAME", "PARTNUMBER")
                .SetPopupLayout(Language.Get("SELECTCONSUMABLEDEFLIST"), PopupButtonStyles.Ok_Cancel, true, true)
                .SetPopupResultCount(1)
                .SetPopupLayoutForm(800, 800, FormBorderStyle.Sizable)
                .SetPopupAutoFillColumns("CONSUMABLEDEFNAME")
                .SetLabel("CONSUMABLEDEFID")
                .SetPosition(2.5);

            // 검색조건
            popup.Conditions.AddTextBox("P_CONSUMABLEDEFTXT").SetLabel("CONSUMABLEDEFIDNAME");
            popup.Conditions.AddComboBox("CONSUMABLETYPE"
                , new SqlQuery("GetCodeList", "00001", "CODECLASSID=ConsumableType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetEmptyItem();

            // 그리드
            popup.GridColumns.AddTextBoxColumn("PARTNUMBER", 150);
            popup.GridColumns.AddTextBoxColumn("CONSUMABLETYPE", 80);
            popup.GridColumns.AddTextBoxColumn("CONSUMABLEDEFNAME", 200);
            popup.GridColumns.AddTextBoxColumn("STANDARD", 170);
        }

        /// <summary>        
        /// 그리드를 초기화한다.
        /// </summary>
        private void InitializeGrid()
        {
            // 실적입력 그리드
            grdConsumableLotList.GridButtonItem = GridButtonItem.None;
            grdConsumableLotList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdConsumableLotList.View.AddTextBoxColumn("WAREHOUSENAME", 130).SetIsReadOnly();
            grdConsumableLotList.View.AddTextBoxColumn("PARTNUMBER", 130).SetIsReadOnly();
            grdConsumableLotList.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 250).SetIsReadOnly();
            grdConsumableLotList.View.AddTextBoxColumn("CONSUMABLELOTID", 130).SetIsReadOnly();
            grdConsumableLotList.View.AddTextBoxColumn("STANDARD", 180).SetIsReadOnly();
            grdConsumableLotList.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 140).SetIsReadOnly();
            grdConsumableLotList.View.AddTextBoxColumn("UNIT", 70).SetIsReadOnly();
            grdConsumableLotList.View.AddSpinEditColumn("CONSUMABLELOTQTY", 90).SetLabel("MATERIALQTY").SetIsReadOnly();
            grdConsumableLotList.View.AddSpinEditColumn("WORKQTY", 90);
            grdConsumableLotList.View.PopulateColumns();

            // 실적조회 그리드
            grdResult.GridButtonItem = GridButtonItem.Export;
            grdResult.View.SetIsReadOnly();
            grdResult.View.AddTextBoxColumn("WAREHOUSENAME", 130);
            grdResult.View.AddTextBoxColumn("PARTNUMBER", 130);
            grdResult.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 250);
            grdResult.View.AddTextBoxColumn("CONSUMABLELOTID", 130);
            grdResult.View.AddTextBoxColumn("PARENTCONSUMABLELOTID", 130);
            grdResult.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 140);
            grdResult.View.AddTextBoxColumn("UNIT", 70);
            grdResult.View.AddTextBoxColumn("INPUTQTY", 90);
            grdResult.View.AddTextBoxColumn("COMPLETEQTY", 90);
            grdResult.View.AddTextBoxColumn("WORKER", 90);
            grdResult.View.AddTextBoxColumn("WORKTIME", 150).SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetTextAlignment(TextAlignment.Center)
                .SetLabel("WORKTIME3");
            grdResult.View.PopulateColumns();
        }

        private void InitializeSummary()
        {
            grdConsumableLotList.View.Columns["CONSUMABLELOTQTY"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdConsumableLotList.View.Columns["CONSUMABLELOTQTY"].SummaryItem.DisplayFormat = "{0:N0}";
            grdConsumableLotList.View.OptionsView.ShowFooter = true;
            grdConsumableLotList.ShowStatusBar = false;
        }
        #endregion

        #region Event
        private void InitializeEvent()
        {
            grdConsumableLotList.View.CustomDrawCell += View_CustomDrawCell;
            smartTabControl1.SelectedPageChanged += SmartTabControl1_SelectedPageChanged;
        }

        private void SmartTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (smartTabControl1.SelectedTabPageIndex == 0)  // 실적입력 탭
            {
                SetConditionVisiblility("P_DATEPERIOD", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
                SetConditionVisiblility("P_PARENTCONSUMABLELOTID", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
                SetConditionVisiblility("P_CONSUMABLELOTID", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
            }
            else if (smartTabControl1.SelectedTabPageIndex == 1) // 실적조회 탭
            {
                SetConditionVisiblility("P_DATEPERIOD", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);
                SetConditionVisiblility("P_PARENTCONSUMABLELOTID", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);
                SetConditionVisiblility("P_CONSUMABLELOTID", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);
            }
        }

        private void View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "WORKQTY")
            {
                e.Appearance.BackColor = Color.LightYellow;
                e.Appearance.ForeColor = Color.Black;
            }
        }
        #endregion

        #region Search
        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            if (smartTabControl1.SelectedTabPageIndex == 0) // 실적입력 탭
            {
                DataTable lotList = await QueryAsync("GetConsumableLotListForNonOrderWork", "00001", values);
                if (lotList.Rows.Count < 1)
                {
                    ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
                }
                grdConsumableLotList.DataSource = lotList;
            }
            else if (smartTabControl1.SelectedTabPageIndex == 1) // 실적조회 탭
            {
                DataTable resultList = await QueryAsync("GetNonOrderWorkResult", "00001", values);
                if (resultList.Rows.Count < 1)
                {
                    ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
                }
                grdResult.DataSource = resultList;
            }
        }
        #endregion

        #region ToolBar
        /// <summary>
        /// 저장버튼 클릭
        /// </summary>
        protected override void OnToolbarSaveClick()
        {
            base.OnToolbarSaveClick();

            if (smartTabControl1.SelectedTabPageIndex == 0) // 실적입력 탭
            {
                grdConsumableLotList.View.PostEditor();
                grdConsumableLotList.View.UpdateCurrentRow();

                DataTable checkedRows = grdConsumableLotList.View.GetCheckedRows();
                if (checkedRows.Rows.Count < 1)
                {
                    //ShowMessage("NoSaveData");
                    throw MessageException.Create("NoSaveData");
                }
                 DataTable childLots = ExecuteRule<DataTable>("SaveNonOrderResult", checkedRows);
                    foreach (DataRow each in childLots.Rows)
                    {
                        Commons.CommonFunction.PrintNonOrderWorkMaterialLabel(each["CONSUMABLELOTID"].ToString());
                    }
            }
        }
        #endregion
    }
}
