using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Commons;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Micube.SmartMES.StandardInfo
{
    /// <summary>
    /// 프 로 그 램 명  : 기준정보 > 항목관리 > 라벨 재발행
    /// 업  무  설  명  : LOT라벨 / 품목라벨 이력조회 및 재발행
    /// 생    성    자  : jylee
    /// 생    성    일  : 2020-06-16
    /// 수  정  이  력  : 2020-06-19 | JYLEE | 단위(UNIT)추가
    /// </summary>
    public partial class LabelReissue : SmartConditionBaseForm
    {

        #region Local Variables

        String lot;         // LOT OR 자재LOT
        String type;        // LOT OR Material
        String columnName;  // LOT OR CONSUMABLELOT

        #endregion

        #region 생성자
        public LabelReissue()
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
            InitializeLotGrid();
            InitializeConsumableGrid();
            InitializeEvent();
            spnCopy.Editor.Properties.MinValue = 1;
            spnCopy.Editor.Properties.MaxValue = 100;
            spnCopy.Editor.Value = 1;
            spnCopy2.Editor.Properties.MinValue = 1;
            spnCopy2.Editor.Properties.MaxValue = 100;
            spnCopy2.Editor.Value = 1;
        }

        /// <summary>        
        /// LOT리스트 그리드를 초기화한다.
        /// </summary>
        private void InitializeLotGrid()
        {
            grdLot.GridButtonItem = GridButtonItem.Copy | GridButtonItem.Export | GridButtonItem.Import;
            grdLot.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdLot.View.SetIsReadOnly();

            //Lot No.
            grdLot.View.AddTextBoxColumn("LOTID", 150);

            //작업지시번호
            grdLot.View.AddTextBoxColumn("WORKORDERID", 150);

            //품목코드
            grdLot.View.AddTextBoxColumn("PRODUCTDEFID", 150)
                .SetIsHidden();

            grdLot.View.AddTextBoxColumn("PARTNUMBER", 150);

            //품목명
            grdLot.View.AddTextBoxColumn("PRODUCTDEFNAME", 300);

            //수량
            grdLot.View.AddTextBoxColumn("QTY", 80);

            //단위
            grdLot.View.AddTextBoxColumn("UNIT", 80);

            //작업장ID(Hidden)
            grdLot.View.AddTextBoxColumn("AREAID", 150)
                .SetIsHidden();

            //작업장
            grdLot.View.AddTextBoxColumn("AREANAME", 150);

            //공정ID(Hidden)
            grdLot.View.AddTextBoxColumn("PROCESSSEGMENTID", 150)
                 .SetIsHidden();

            //공정
            grdLot.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 150);

            //부모 Lot No.
            grdLot.View.AddTextBoxColumn("PARENTLOTID", 150);

            //생성시간
            grdLot.View.AddTextBoxColumn("CREATEDTIME", 150)
                 .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                 .SetTextAlignment(TextAlignment.Center);

            //작업시작 시간
            grdLot.View.AddTextBoxColumn("TRACKINTIME", 150)
                 .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                 .SetTextAlignment(TextAlignment.Center);


            //작업완료 시간
            grdLot.View.AddTextBoxColumn("TRACKOUTTIME", 150)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);

            //작업자
             grdLot.View.AddTextBoxColumn("TRACKOUTUSER", 100)
                .SetLabel("WORKER")
                .SetTextAlignment(TextAlignment.Center);

            //라벨발행횟수
            grdLot.View.AddTextBoxColumn("PRINTCOUNT", 80);

            grdLot.View.PopulateColumns();
        }

        /// <summary>        
        /// 자재LOT 그리드를 초기화한다.
        /// </summary>
        private void InitializeConsumableGrid()
        {
            grdConsumable.GridButtonItem = GridButtonItem.Copy | GridButtonItem.Export | GridButtonItem.Import;
            grdConsumable.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdConsumable.View.SetIsReadOnly();

            //자재Lot No.
            grdConsumable.View.AddTextBoxColumn("CONSUMABLELOTID", 120)
                .SetLabel("CONSUMABLELOTID");

            //발주번호
            grdConsumable.View.AddTextBoxColumn("PONO", 120)
                .SetTextAlignment(TextAlignment.Center);

            // 자재코드
            grdConsumable.View.AddTextBoxColumn("CONSUMABLEDEFID", 150).SetIsHidden();

            grdConsumable.View.AddTextBoxColumn("PARTNUMBER", 130);

            //품명
            grdConsumable.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 250);

            //수량
            grdConsumable.View.AddTextBoxColumn("CONSUMABLELOTQTY", 80);

            //단위
            grdConsumable.View.AddTextBoxColumn("UNIT", 80)
                .SetTextAlignment(TextAlignment.Center);

            //창고ID(Hidden)
            grdConsumable.View.AddTextBoxColumn("WAREHOUSEID", 150)
                .SetIsHidden();

            //창고
            grdConsumable.View.AddTextBoxColumn("WAREHOUSENAME", 100);

            //부모 Lot No.
            grdConsumable.View.AddTextBoxColumn("PARENTCONSUMABLELOTID", 120);

            //생성시간
            grdConsumable.View.AddTextBoxColumn("CREATEDTIME", 150)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);

            //업체명
            grdConsumable.View.AddTextBoxColumn("CUSTNAME", 150)
                .SetLabel("COMPANYNAME");

            //규격
            grdConsumable.View.AddTextBoxColumn("STANDARD", 120);

            //납품일자
            grdConsumable.View.AddTextBoxColumn("DELVDATE", 120)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);

            //검사일자
            grdConsumable.View.AddTextBoxColumn("INSPECTIONDATE", 120)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss")
                .SetTextAlignment(TextAlignment.Center);

            //검사자
            grdConsumable.View.AddTextBoxColumn("INSPECTOR", 100)
                .SetTextAlignment(TextAlignment.Center);

            //무지시 작업여부
            grdConsumable.View.AddTextBoxColumn("ISNOTORDERRESULT", 60)
               .SetTextAlignment(TextAlignment.Center);

            //라벨발행횟수
            grdConsumable.View.AddTextBoxColumn("PRINTCOUNT", 80);

            grdConsumable.View.PopulateColumns();
        }

        #endregion

        #region Event
        private void InitializeEvent()
        {
            smartTabControl1.SelectedPageChanged += SmartTabControl1_SelectedPageChanged;
            grdLot.Paint += GrdLot_Paint;
        }

        private void GrdLot_Paint(object sender, PaintEventArgs e)
        {
            var buttons = pnlToolbar.Controls.Find<SmartButton>(true);

            foreach (SmartButton btn in buttons)
            {
                if (string.IsNullOrWhiteSpace(btn.Text)) continue;

                int w = Size.Round(e.Graphics.MeasureString(btn.Text, btn.Font)).Width;

                btn.Size = new Size(w < 80 ? 80 : w, btn.Height);
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

            if (smartTabControl1.SelectedTabPageIndex == 0) // LOT라벨 탭
            {
                DataTable dtLot = await QueryAsync("GetLotLabelReissue", "00001", values);

                if (dtLot.Rows.Count < 1)
                {
                    ShowMessage("NoSelectData");
                }
                grdLot.DataSource = dtLot;
            }
            else if (smartTabControl1.SelectedTabPageIndex == 1) //자재라벨 탭
            {
                DataTable dtConsumable = await QueryAsync("GetConsumableLabelReissue", "00001", values);

                if (dtConsumable.Rows.Count < 1)
                {
                    ShowMessage("NoSelectData");
                }

                grdConsumable.DataSource = dtConsumable;
            }
        }

        //검색조건추가(selectPopup)
        protected override void InitializeCondition()
        {
            base.InitializeCondition();

            CommonFunction.AddConditionProductPopup("P_PRODUCTDEFID", 1.1, false, Conditions, "PARTNUMBER");
            InitializeConditionConsumableLot_Popup();
            InitializeConditionConsumableDef_Popup();
        }
        #endregion

        #region ToolBar
        /// <summary>
        /// 라벨재발행 버튼
        /// </summary>
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            SmartButton btn = sender as SmartButton;
            DataTable selectedRows = grdLot.View.GetCheckedRows();

            //LOT라벨 Tab
            if (smartTabControl1.SelectedTabPageIndex == 0)
            {
                selectedRows = grdLot.View.GetCheckedRows();

            }
            //자재LOT라벨 Tab
            else if (smartTabControl1.SelectedTabPageIndex == 1)
            {
                selectedRows = grdConsumable.View.GetCheckedRows();
            }

            if (btn.Name.ToString().Equals("LabelReissue"))
            {
                if (selectedRows.Rows.Count < 1)
                {
                    ShowMessage("NoSaveData");
                    return;
                }
                RePrintLabel(selectedRows);
            }
        }
        #endregion

        #region Private Function

        /// <summary>
        /// Default 검색조건
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

            SetConditionVisiblility("P_LOTNUM", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);                // LOT
            SetConditionVisiblility("P_PRODUCTDEFID", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);       // 품목
            SetConditionVisiblility("P_AREACODE", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);           // 작업장
            SetConditionVisiblility("P_PROCESSCODE", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);        // 공정
            SetConditionVisiblility("P_CONSUMABLELOTID", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);     // 자재LOT
            SetConditionVisiblility("P_WAREHOUSE", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);           // 창고
            SetConditionVisiblility("P_CONSUMABLEDEFID", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);     // 자재코드
            type = "Lot";
        }

        /// <summary>
        /// Tab선택 => 검색조건 변경
        /// </summary>
        private void SmartTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (smartTabControl1.SelectedTabPageIndex == 0) //LOT라벨 Tab
            {
                SetConditionVisiblility("P_LOTNUM", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);          // LOT
                SetConditionVisiblility("P_PRODUCTDEFID", DevExpress.XtraLayout.Utils.LayoutVisibility.Always); // 품목코드
                SetConditionVisiblility("P_AREACODE", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);     // 작업장
                SetConditionVisiblility("P_PROCESSCODE", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);  // 공정
                SetConditionVisiblility("P_WAREHOUSE", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
                SetConditionVisiblility("P_CONSUMABLELOTID", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
                SetConditionVisiblility("P_CONSUMABLEDEFID", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
            }
            else if (smartTabControl1.SelectedTabPageIndex == 1)  //자재LOT라벨 Tab
            {
                SetConditionVisiblility("P_CONSUMABLELOTID", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);  // 자재LOT
                SetConditionVisiblility("P_WAREHOUSE", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);        // 창고
                SetConditionVisiblility("P_CONSUMABLEDEFID", DevExpress.XtraLayout.Utils.LayoutVisibility.Always);  // 자재코드
                SetConditionVisiblility("P_LOTNUM", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
                SetConditionVisiblility("P_PRODUCTDEFID", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
                SetConditionVisiblility("P_AREACODE", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
                SetConditionVisiblility("P_PROCESSCODE", DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
            }
        }

        /// <summary>
        /// 재발행 함수
        /// </summary>
        private void RePrintLabel(DataTable selectedRows)
        {
            //LOT라벨 Tab
            if (smartTabControl1.SelectedTabPageIndex == 0)
            {
                columnName = "LOTID";
                type = "Lot";
            }
            //자재LOT라벨 Tab
            else if (smartTabControl1.SelectedTabPageIndex == 1)
            {
                columnName = "CONSUMABLELOTID";
                type = "Material";
            }

            foreach (DataRow Row in selectedRows.Rows)
            {
                string lot = Row[columnName].ToString();

                MessageWorker messageWorker = new MessageWorker("SaveReprintLabel");
                messageWorker.SetBody(new MessageBody()
                {
                    {"lotid", lot},
                    {"labeltype",  type}
                });

                if (smartTabControl1.SelectedTabPageIndex == 0) // LOT라벨 탭
                {
                    CommonFunction.PrintLotLabel(lot, (short)spnCopy.Editor.Value);
                }
                else if (smartTabControl1.SelectedTabPageIndex == 1) //자재라벨 탭
                {
                    if (Row["ISNOTORDERRESULT"].ToString() == "Y")
                    {
                        CommonFunction.PrintNonOrderWorkMaterialLabel(lot, (short)spnCopy2.Editor.Value);
                    }
                    else
                    {
                        CommonFunction.PrintMaterialLabel(lot, (short)spnCopy2.Editor.Value);
                    }
                }

                //재발행 횟수
                messageWorker.Execute();
            }
        }

        /// <summary>
        /// 자재LOT 검색조건 팝업
        /// </summary>
        private void InitializeConditionConsumableLot_Popup()
        {
            var popup = this.Conditions.AddTextBox("P_CONSUMABLELOTID")
                .SetLabel("CONSUMABLELOTID")
                .SetPosition(2.5);
        }

        /// <summary>
        /// 자재코드 검색조건 팝업
        /// </summary>
        private void InitializeConditionConsumableDef_Popup()
        {
            var popup = this.Conditions.AddSelectPopup("P_CONSUMABLEDEFID", new SqlQuery("GetConsumableDefList", "00001"
                , $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "CONSUMABLEDEFID", "CONSUMABLEDEFID")
                .SetPopupLayout(Language.Get("SELECTCONSUMABLEDEFLIST"), PopupButtonStyles.Ok_Cancel, true, false)
                .SetPopupResultCount(1)
                .SetPopupLayoutForm(800, 800, FormBorderStyle.Sizable)
                .SetLabel("CONSUMABLEDEFID")
                .SetPosition(2.5);

            // 검색조건
            popup.Conditions.AddTextBox("CONSUMABLEDEFID");
            popup.Conditions.AddTextBox("CONSUMABLEDEFNAME");

            // 그리드
            popup.GridColumns.AddTextBoxColumn("CONSUMABLEDEFID", 150);
            popup.GridColumns.AddTextBoxColumn("CONSUMABLEDEFNAME", 250);
            popup.GridColumns.AddTextBoxColumn("STANDARD", 150);
        }

        #endregion
    }
}
