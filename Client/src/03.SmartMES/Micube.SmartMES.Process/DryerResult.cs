#region using
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace Micube.SmartMES.Process
{
    /// <summary>
    /// 프 로 그 램 명  : 공정관리 > 공정등록 > 건조기
    /// 업  무  설  명  : 공정관리 - 건조기
    /// 생    성    자  : yshwang
    /// 생    성    일  : 2019-06-09
    /// 수  정  이  력  : 
    /// </summary>
    public partial class DryerResult : SmartConditionBaseForm
    {
        private const string TOOLBAR_WORKSTART = "WorkStart";   // 작업시작
        private const string TOOLBAR_WORKEND = "WorkEnd";       // 작업완료
        private const string TOOLBAR_SWITCH = "Switch";         // 위치변경

        private const string DRYERTYPE_FIRST = "First";         // 1차 건조기
        private const string DRYERTYPE_SECOND = "Second";       // 2차 건조기

        private const int WORKDAY_WARNING = 20;                 // 작업일이 WORKDAY_WARNING 이상이면 경고

        public DryerResult()
        {
            InitializeComponent();
        }

        // 조회조건 초기화
        protected override void InitializeCondition()
        {
            base.InitializeCondition();
            InitializeCondition_Equipment();
            InitializeConditionConsumableDef_Popup();
            InitializeConditionProductDef_Popup();
        }

        // 건조기 조회조건 추가
        private void InitializeCondition_Equipment()
        {
            var popup = this.Conditions.AddSelectPopup("P_EQUIPMENTID", new SqlQuery("GetDryerListForCondition", "00001"
                    , $"LANGUAGETYPE={UserInfo.Current.LanguageType}", $"P_DRYERTYPE={DRYERTYPE_FIRST}"), "EQUIPMENTNAME", "EQUIPMENTID")
                .SetPopupLayout(Language.Get("SELECTEQUIPMENT"), PopupButtonStyles.Ok_Cancel, true, true)
                .SetPopupResultCount(1)
                .SetPopupLayoutForm(800, 800, FormBorderStyle.Sizable)
                .SetPopupAutoFillColumns("EQUIPMENTNAME")
                .SetLabel("DRYER")
                .SetPosition(2.5);

            // 검색조건
            popup.Conditions.AddTextBox("EQUIPMENTID");
            popup.Conditions.AddTextBox("EQUIPMENTNAME");

            // 그리드
            popup.GridColumns.AddTextBoxColumn("EQUIPMENTID", 120);
            popup.GridColumns.AddTextBoxColumn("EQUIPMENTNAME", 260);
            popup.GridColumns.AddTextBoxColumn("AREANAME", 120);
            popup.GridColumns.AddTextBoxColumn("LOCATIONID", 120);
        }

        /// <summary>
        /// 자재코드 검색조건 팝업
        /// </summary>
        private void InitializeConditionConsumableDef_Popup()
        {
            var popup = this.Conditions.AddSelectPopup("P_CONSUMABLEPARTNUMBER", new SqlQuery("GetDryConsumableDefList", "00001"
                    , $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "CONSUMABLEDEFNAME", "PARTNUMBER")
                .SetPopupLayout(Language.Get("SELECTCONSUMABLEDEFLIST"), PopupButtonStyles.Ok_Cancel, true, true)
                .SetPopupResultCount(1)
                .SetPopupLayoutForm(800, 800, FormBorderStyle.Sizable)
                .SetPopupAutoFillColumns("CONSUMABLEDEFNAME")
                .SetLabel("CONSUMABLEPARTNUMBER")
                .SetPosition(2.6);

            // 검색조건
            popup.Conditions.AddTextBox("P_CONSUMABLEDEFTXT").SetLabel("CONSUMABLEPARTNUMBERNAME");

            // 그리드
            popup.GridColumns.AddTextBoxColumn("PARTNUMBER", 150);
            popup.GridColumns.AddTextBoxColumn("CONSUMABLETYPE", 80);
            popup.GridColumns.AddTextBoxColumn("CONSUMABLEDEFNAME", 200);
            popup.GridColumns.AddTextBoxColumn("STANDARD", 170);
        }

        /// <summary>
        /// 품목코드 검색조건 팝업
        /// </summary>
        private void InitializeConditionProductDef_Popup()
        {
            var popup = Conditions.AddSelectPopup("P_PRODUCTPARTNUMBER", new SqlQuery("GetDryProductDefList", "00001"
                    , $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "PRODUCTDEFNAME", "PARTNUMBER")
                .SetPopupLayout("PRODUCTDEFLIST", PopupButtonStyles.Ok_Cancel, true, true)
                .SetPopupResultCount(1)
                .SetPopupLayoutForm(880, 600, FormBorderStyle.Sizable)
                .SetLabel("PRODUCTPARTNUMBER")
                .SetPosition(2.7);

            // 검색조건 
            popup.Conditions.AddTextBox("P_PRODUCTDEFTXT").SetLabel("PRODUCTPARTNUMBERNAME");
            popup.Conditions.AddComboBox("P_PRODUCTDEFTYPE"
                , new SqlQuery("GetCodeList", "00001", "CODECLASSID=ProductDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetEmptyItem().SetLabel("PRODUCTDEFTYPE");

            // 그리드
            popup.GridColumns.AddTextBoxColumn("PARTNUMBER", 130);
            popup.GridColumns.AddTextBoxColumn("PRODUCTDEFTYPE", 80);
            popup.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 200);
            popup.GridColumns.AddTextBoxColumn("MODEL", 100);
            popup.GridColumns.AddTextBoxColumn("TEAM", 100);
        }

        // 조회조건의 컨트롤에 기능 추가가 필요한 경우 사용
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();
            Conditions.GetControl<SmartComboBox>("P_DRYERTYPE").EditValueChanged += Editor_EditValueChanged;
            SetConditionVisiblility("P_PRODUCTPARTNUMBER", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
        }

        private void Editor_EditValueChanged(object sender, EventArgs e)
        {
            ChangeDryerTypeOfEquipmentPopup(Conditions.GetValues()["P_DRYERTYPE"].ToString());
            switch(Conditions.GetValues()["P_DRYERTYPE"].ToString())
            {
                case DRYERTYPE_FIRST:
                    SetConditionVisiblility("P_CONSUMABLEPARTNUMBER", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);
                    SetConditionVisiblility("P_PRODUCTPARTNUMBER", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
                    break;
                case DRYERTYPE_SECOND:
                    SetConditionVisiblility("P_CONSUMABLEPARTNUMBER", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
                    SetConditionVisiblility("P_PRODUCTPARTNUMBER", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);
                    break;
            }
        }

        private void ChangeDryerTypeOfEquipmentPopup(string dryerType)
        {
            ConditionItemSelectPopup equipmentCond = new ConditionItemSelectPopup();
            equipmentCond.Id = "EQUIPMENTID";
            equipmentCond.SearchQuery = new SqlQuery("GetDryerListForCondition", "00001"
                , $"LANGUAGETYPE={UserInfo.Current.LanguageType}", $"P_DRYERTYPE={dryerType}");
            equipmentCond.ValueFieldName = "EQUIPMENTID";
            equipmentCond.DisplayFieldName = "EQUIPMENTNAME";
            equipmentCond.SetPopupLayout("SELECTEQUIPMENT", PopupButtonStyles.Ok_Cancel, true, true);
            equipmentCond.SetPopupResultCount(1);
            equipmentCond.SetPopupLayoutForm(800, 800, FormBorderStyle.Sizable);
            equipmentCond.SetPopupAutoFillColumns("EQUIPMENTNAME");

            // 조회조건
            equipmentCond.Conditions.AddTextBox("EQUIPMENTID");
            equipmentCond.Conditions.AddTextBox("EQUIPMENTNAME");

            // 그리드
            equipmentCond.GridColumns.AddTextBoxColumn("EQUIPMENTID", 120);
            equipmentCond.GridColumns.AddTextBoxColumn("EQUIPMENTNAME", 260);
            equipmentCond.GridColumns.AddTextBoxColumn("AREANAME", 120);
            equipmentCond.GridColumns.AddTextBoxColumn("LOCATIONID", 120);

            // 조회조건의 팝업 변경
            Conditions.GetControl<SmartSelectPopupEdit>("P_EQUIPMENTID").SelectPopupCondition = equipmentCond;
        }

        // 콘텐츠 초기화
        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeGrid();
            InitializeEvent();
        }

        // 그리드 초기화
        private void InitializeGrid()
        {
            InitializeEquipmentGrid();
            InitializeLotGrid();
            InitializeResultGrid();
        }

        // 건조설비 그리드 초기화
        private void InitializeEquipmentGrid()
        {
            grdEquipment.GridButtonItem = GridButtonItem.None;
            grdEquipment.View.SetIsReadOnly();
            grdEquipment.View.AddTextBoxColumn("EQUIPMENTID", 90)
                .SetTextAlignment(TextAlignment.Center);                // 설비 ID
            grdEquipment.View.AddTextBoxColumn("EQUIPMENTNAME", 170);   // 설비명
            grdEquipment.View.AddTextBoxColumn("STATE", 70)
                .SetTextAlignment(TextAlignment.Center);                // 설비상태
            grdEquipment.View.AddTextBoxColumn("WORKSTARTTIME", 150)    // 작업 시작시간
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss");
            grdEquipment.View.AddSpinEditColumn("WORKDAY", 60);         // 작업시간(단위:일)
            grdEquipment.View.AddSpinEditColumn("LOTCOUNT", 60);        // LOT 수
            grdEquipment.View.AddSpinEditColumn("QTY", 60);             // 수량
            grdEquipment.View.AddTextBoxColumn("WORKER", 100)           // 작업자
                .SetTextAlignment(TextAlignment.Center);
            grdEquipment.View.AddTextBoxColumn("SWITCHDATE", 150)       // 위치변경 시간
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss");
            grdEquipment.View.PopulateColumns();
        }

        // 투입LOT 그리드 초기화
        private void InitializeLotGrid()
        {
            grdLot.GridButtonItem = GridButtonItem.None;
            grdLot.View.AddTextBoxColumn("INPUTLOT", 100).SetIsReadOnly();          // 투입 LOT
            grdLot.View.AddTextBoxColumn("PARTNUMBER", 130).SetIsReadOnly();        // 품번
            grdLot.View.AddTextBoxColumn("PRODUCTDEFNAME", 200).SetIsReadOnly();    // 품목명
            grdLot.View.AddTextBoxColumn("MODEL", 100).SetIsReadOnly();             // 기종
            grdLot.View.AddSpinEditColumn("INPUTQTY", 60).SetIsReadOnly();          // 투입수량
            grdLot.View.AddSpinEditColumn("QTY", 60);                               // 수량
            grdLot.View.PopulateColumns();
        }

        // 건조실적 그리드 초기화
        private void InitializeResultGrid()
        {
            grdResult.GridButtonItem = GridButtonItem.None;
            grdResult.View.SetIsReadOnly();
            grdResult.View.AddTextBoxColumn("EQUIPMENTID", 90);         // 설비 ID
            grdResult.View.AddTextBoxColumn("EQUIPMENTNAME", 160);      // 설비명
            grdResult.View.AddTextBoxColumn("WORKSTARTTIME", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss");               // 작업 시작시간
            grdResult.View.AddTextBoxColumn("WORKENDTIME", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss");               // 작업 완료시간
            grdResult.View.AddSpinEditColumn("WORKDAY", 60);            // 작업시간(단위:일)
            grdResult.View.AddTextBoxColumn("OUTPUTLOT", 120);          // 생산LOT
            grdResult.View.AddTextBoxColumn("PARTNUMBER", 130);         // 품번
            grdResult.View.AddTextBoxColumn("PRODUCTDEFNAME", 200);     // 품목명
            grdResult.View.AddTextBoxColumn("MODEL", 100);              // 기종
            grdResult.View.AddSpinEditColumn("QTY", 60);                // 수량
            grdResult.View.AddTextBoxColumn("INPUTLOT", 100);           // 투입LOT
            grdResult.View.AddTextBoxColumn("WORKER", 100)              // 작업자
                .SetTextAlignment(TextAlignment.Center);
            grdResult.View.PopulateColumns();

            grdResult.View.Columns["QTY"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdResult.View.Columns["QTY"].SummaryItem.DisplayFormat = "{0:N0}"; ;
            grdResult.View.OptionsView.ShowFooter = true;
            grdResult.ShowStatusBar = false;
        }

        // 이벤트 초기화
        private void InitializeEvent()
        {
            grdEquipment.View.FocusedRowChanged += grdEquipment_FocusedRowChanged;
            grdEquipment.View.CustomDrawCell += View_CustomDrawCell;
            grdLot.View.RowCellStyle += grdLot_RowCellStyle;
        }

        private void View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (!string.IsNullOrEmpty(grdEquipment.View.GetRowCellValue(e.RowHandle, "WORKDAY").ToString())
                && decimal.Parse(grdEquipment.View.GetRowCellValue(e.RowHandle, "WORKDAY").ToString()) >= WORKDAY_WARNING
                && (grdEquipment.View.GetRowCellValue(e.RowHandle, "SWITCHDATE") == null
                    || grdEquipment.View.GetRowCellValue(e.RowHandle, "SWITCHDATE").ToString() == string.Empty))
            {
                e.Appearance.BackColor = Color.OrangeRed;
                e.Appearance.ForeColor = Color.Yellow;
            }
        }

        // 건조설비 선택시 해당 설비의 투입LOT 재조회
        private void grdEquipment_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RefreshLotGridByFocusedEquipment();
        }

        // 입력 가능한셀 색상변경
        private void grdLot_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if(e.Column.FieldName == "QTY")
            {
                e.Appearance.BackColor = Color.LightYellow;
                e.Appearance.ForeColor = Color.Black;
            }
        }

        private void RefreshLotGridByFocusedEquipment()
        {
            DataRow equipRow = grdEquipment.View.GetFocusedDataRow();
            if (equipRow != null)
            {
                RefreshLotGrid(equipRow["EQUIPMENTID"].ToString());
            }
            else
            {
                grdLot.View.ClearDatas();
            }
        }

        // 투입LOT 재조회
        private void RefreshLotGrid(string equipmentId)
        {
            var param = new Dictionary<string, object>()
            {
                { "EQUIPMENTID", equipmentId }
            };
            if (Conditions.GetValues()["P_DRYERTYPE"].ToString() == DRYERTYPE_FIRST)
            {
                grdLot.DataSource = SqlExecuter.Query("GetLotsInDryerNonOrder", "00001", param);
            }
            else
            {
                grdLot.DataSource = SqlExecuter.Query("GetLotsInDryerOrder", "00001", param);
            }
        }

        #region 검색
        //// <summary>
        /// 건조기 목록과 건조실적 조회
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();
            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            DataTable equipments = null;
            DataTable results = null;
            if (Conditions.GetValues()["P_DRYERTYPE"].ToString() == DRYERTYPE_FIRST)
            {
                equipments = await QueryAsync("GetDryerListNonOrder", "00001", values);
                results = await QueryAsync("GetDryResultNonOrder", "00001", values);
            }
            else
            {
                equipments = await QueryAsync("GetDryerListOrder", "00001", values);
                results = await QueryAsync("GetDryResultOrder", "00001", values);
            }
            if (equipments.Rows.Count == 0 && results.Rows.Count == 0)
            {
                ShowMessage("NoSelectData");
            }
            grdEquipment.DataSource = equipments;
            grdResult.DataSource = results;
        }

        #endregion

        #region ToolBar
        /// <summary>
        /// 툴바 버튼 이벤트
        /// </summary>
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            if (Conditions.GetValues()["P_DRYERTYPE"].ToString() != DRYERTYPE_FIRST)    // 1차 건조기만 작업시작/완료 가능
            {
                return;
            }
            SmartButton btn = sender as SmartButton;
            switch (btn.Name.ToString())
            {
                case TOOLBAR_WORKSTART: // 작업시작
                    var result = WorkStart();
                    if (result == DialogResult.OK)
                    {
                        RefreshEquipmentGrid();
                    }
                    break;
                case TOOLBAR_WORKEND:   // 작업완료
                    WorkEnd();
                    RefreshEquipmentGrid();
                    RefreshResultGrid();
                    break;
                case TOOLBAR_SWITCH:    // 위치변경
                    Switch();
                    RefreshEquipmentGrid();
                    break;
            }
        }

        // 작업시작 버튼 클릭 시 팝업 표시
        private DialogResult WorkStart()
        {
            DataRow equipRow = grdEquipment.View.GetFocusedDataRow();
            if(equipRow != null)
            {
                return new DryerResult_Popup(equipRow["EQUIPMENTID"].ToString(), equipRow["EQUIPMENTNAME"].ToString()).ShowDialog();
            }
            return DialogResult.Cancel;
        }
        
        // 설비 조회 및 선택되어 있던 설비 재선택
        private void RefreshEquipmentGrid()
        {
            string equipmentId = null;
            DataRow equipRow = grdEquipment.View.GetFocusedDataRow();
            if (equipRow != null)
            {
                equipmentId = equipRow["EQUIPMENTID"].ToString();
            }
            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            grdEquipment.DataSource = SqlExecuter.Query("GetDryerListNonOrder", "00001", values);
            if(equipmentId != null)
            {
                grdEquipment.View.FocusAndSelect("EQUIPMENTID", equipmentId);
                RefreshLotGridByFocusedEquipment();
            }
        }

        // 작업완료 룰 호출
        private void WorkEnd()
        {
            DataRow equipRow = grdEquipment.View.GetFocusedDataRow();
            if (equipRow != null)
            {
                MessageWorker messageWorker = new MessageWorker("NonOrderTrackOutDryer");
                messageWorker.SetBody(new MessageBody()
                {
                    { "equipmentid", equipRow["EQUIPMENTID"].ToString() }
                    , { "list", grdLot.DataSource as DataTable }
                });
                var saveResult = messageWorker.Execute<DataTable>();
                DataTable resultData = saveResult.GetResultSet();
                foreach (DataRow each in resultData.Rows)
                {
                    CommonFunction.PrintNonOrderWorkMaterialLabel(each["OUTPUTLOT"].ToString());
                }
            }
        }

        // 실적 조회
        private void RefreshResultGrid()
        {
            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);
            grdResult.DataSource = SqlExecuter.Query("GetDryResultNonOrder", "00001", values);
        }

        // 위치변경
        private void Switch()
        {
            DataRow equipRow = grdEquipment.View.GetFocusedDataRow();
            if (equipRow != null)
            {
                MessageWorker messageWorker = new MessageWorker("SwitchDryer");
                messageWorker.SetBody(new MessageBody()
                {
                    { "equipmentid", equipRow["EQUIPMENTID"].ToString() }
                });
                messageWorker.Execute();
            }
        }
        #endregion
    }
}
