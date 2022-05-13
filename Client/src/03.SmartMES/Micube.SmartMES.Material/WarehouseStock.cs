#region using

using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.Framework.SmartControls.Grid;
using Micube.Framework.SmartControls.Grid.BandedGrid;

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using Micube.SmartMES.Commons;
using System.Windows.Forms;

#endregion

namespace Micube.SmartMES.Material
{
    /// <summary>
    /// 프 로 그 램 명  : 자재관리 > 자재현황 > 창고별 재고 현황
    /// 업  무  설  명  : 창고별 재고현황을 조회한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2020-06-15
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class WarehouseStock : SmartConditionBaseForm
    {
        public WarehouseStock()
        {
            InitializeComponent();
        }

        #region 컨텐츠 영역 초기화

        protected override void InitializeContent()
        {
            base.InitializeContent();

            InitializeEvent();
            InitializeList();
        }

        private void InitializeList()
        {
            grdList.View.OptionsFind.AlwaysVisible = true;
            grdList.GridButtonItem = GridButtonItem.Export;
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdList.View.OptionsView.EnableAppearanceEvenRow = false;
            grdList.View.OptionsView.EnableAppearanceOddRow = false;
            grdList.View.OptionsView.AllowCellMerge = true;
            grdList.View.SetSortOrder("CONSUMABLEDEFID");
            grdList.View.SetIsReadOnly();

            grdList.View.AddTextBoxColumn("CONSUMABLEDEFID", 120)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 250);
            grdList.View.AddComboBoxColumn("MODELID", 150, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ModelCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("ITEMSTANDARD", 150)
                .SetLabel("STANDARD")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("CONSUMABLETYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ItemDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CONSUMABLELOTID", 120)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("PARENTCONSUMABLELOTID", 120)
                .SetLabel("PARENTLOTID")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("ISHOLD", 50, new SqlQuery("GetCodeList", "00001", "CODECLASSID=YesNoState", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddSpinEditColumn("CONSUMABLELOTQTY", 80)
                .SetDisplayFormat("#,##0.##")
                .SetLabel("STOCKQTY");
            grdList.View.AddSpinEditColumn("WIPQTY", 80)
                .SetDisplayFormat("#,##0.##")
                .SetLabel("PLANWIPQTY");
            grdList.View.AddTextBoxColumn("UNIT", 60)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("CELLID", 100, new SqlQuery("GetCellId", "00001"), "CELLNAME", "LOCATIONID")
                .SetLabel("CELLNAME")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddDateEditColumn("INDATE", 80)
                .SetTextAlignment(TextAlignment.Center)
                .SetDisplayFormat("yyyy-MM-dd");
            grdList.View.AddSpinEditColumn("STOCKQTY", 80)
                .SetDisplayFormat("#,##0.##")
                .SetLabel("ERPQTY");
            //라벨 재발행용 데이터 - 무지시공정여부, PO번호, 업체명, 납품일자, 검사일자, 검사자
            grdList.View.AddTextBoxColumn("ISNOTORDERRESULT").SetIsHidden();
            grdList.View.AddTextBoxColumn("PONO").SetIsHidden();
            grdList.View.AddTextBoxColumn("CUSTNAME").SetIsHidden();
            grdList.View.AddTextBoxColumn("").SetIsHidden();
            grdList.View.AddTextBoxColumn("DELVDATE", 120)
            .SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetIsHidden();
            grdList.View.AddTextBoxColumn("INSPECTIONDATE", 120)
            .SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetIsHidden();
            grdList.View.AddTextBoxColumn("INSPECTOR", 100).SetIsHidden();

            grdList.View.PopulateColumns();

        }

        #endregion

        #region Event

        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            grdList.View.CellMerge += View_CellMerge;
            grdList.View.RowStyle += View_RowStyle;
            grdList.Paint += GrdLot_Paint;
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

        private void View_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            else if (e.Column.FieldName == "STOCKQTY" || e.Column.FieldName == "WIPQTY")
            {
                string str1 = view.GetRowCellDisplayText(e.RowHandle1, e.Column);
                string str2 = view.GetRowCellDisplayText(e.RowHandle2, e.Column);

                string id1 = view.GetRowCellValue(e.RowHandle1, "CONSUMABLEDEFID").ToString();
                string id2 = view.GetRowCellValue(e.RowHandle2, "CONSUMABLEDEFID").ToString();

                e.Merge = (str1 == str2 && id1 == id2);
            }
            else
            {
                e.Merge = false;
            }

            e.Handled = true;
        }

        private void View_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (coloredRows.ContainsKey(e.RowHandle))
                e.Appearance.BackColor = coloredRows[e.RowHandle];
        }

        #endregion

        #region Search

        /// <summary>
        /// 검색 버튼을 클릭하면 조회조건에 맞는 데이터를 비동기 모델로 조회한다.
        /// </summary>
        protected async override Task OnSearchAsync()
        {
            await base.OnSearchAsync();

            DateTime now = DateTime.Now;
            var dateFrom = new DateTime(now.Year, now.Month, 1);
            var dateTo = dateFrom.AddMonths(1).AddDays(-1);

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);
            values.Add("PODateFr", dateFrom.ToString("yyyyMMdd"));
            values.Add("PODateTo", dateTo.ToString("yyyyMMdd"));

            DataTable dtList = await ProcedureAsync("USP_ERPIF_GETWAREHOUSESTOCK", values);

            if (dtList.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }
            grdList.DataSource = dtList;

            CollectColoredRows();
            grdList.View.LayoutChanged();
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

        #region ToolBar
        /// <summary>
        /// 라벨재발행 버튼
        /// </summary>
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            base.OnToolbarClick(sender, e);
            SmartButton btn = sender as SmartButton;
            DataTable selectedRows = grdList.View.GetCheckedRows();

            if (btn.Name.ToString().Equals("LabelReissue"))
            {
                if (selectedRows.Rows.Count < 1)
                {
                    ShowMessage("NoSaveData");
                    return;
                }
                RePrintLabelAsync(selectedRows);
            }
        }
        #endregion

        #region Private Function

        Dictionary<int, Color> coloredRows = new Dictionary<int, Color>();

        /// <summary>
        /// Merge대체 => 같은 품목인 경우 같은 색상이 표시되도록
        /// </summary>
        private void CollectColoredRows()
        {
            coloredRows.Clear();
            if (grdList.View.DataRowCount > 0)
                coloredRows.Add(0, Color.Transparent);
            for (int i = 1; i < grdList.View.DataRowCount; i++)
            {
                int prevRowHandle = i - 1;
                Color prevColor = coloredRows[prevRowHandle];
                object val1 = grdList.View.GetRowCellValue(i, "CONSUMABLEDEFID");
                object val2 = grdList.View.GetRowCellValue(prevRowHandle, "CONSUMABLEDEFID");
                if (object.Equals(val1, val2))
                    coloredRows.Add(i, prevColor);
                else
                    coloredRows.Add(i, prevColor == Color.Transparent ? Color.FromArgb(10, 0, 0, 0) : Color.Transparent);
            }
        }

        /// <summary>
        /// 재발행 함수
        /// </summary>
        private async void RePrintLabelAsync(DataTable selectedRows)
        {
            String columnName = null;
            String type = null;

            for (int i = 0; i< selectedRows.Rows.Count; i++)
            {
                //LOT라벨
                if (selectedRows.Rows[i]["CONSUMABLETYPE"].ToString() != "Material")
                {
                    columnName = selectedRows.Rows[i]["CONSUMABLELOTID"].ToString();
                    type = "Lot";
                }
                else
                {
                    //자재LOT라벨
                    columnName = selectedRows.Rows[i]["CONSUMABLELOTID"].ToString();
                    type = "Material";
                }
                string lot = columnName;

                MessageWorker messageWorker = new MessageWorker("SaveReprintLabel");
                messageWorker.SetBody(new MessageBody()
                {
                    {"lotid", lot},
                    {"labeltype",  type}
                });

                if (type == "Material")
                {
                    var values = Conditions.GetValues();
                    values.Add("lotid", lot);

                    DataTable dtNotOrderResult = await QueryAsync("GetConsumableLabelNotOrderResult", "00001", values);

                    if (dtNotOrderResult.Rows[0]["ISNOTORDERRESULT"].ToString() == "Y")
                    {
                        CommonFunction.PrintNonOrderWorkMaterialLabel(lot, (short)1);
                    }
                    else
                    {
                        CommonFunction.PrintMaterialLabel(lot, (short)1);
                    }
                }
                else
                {
                    CommonFunction.PrintLotLabel(lot, (short)1);
                }

                //재발행 횟수
                messageWorker.Execute();
            }
        }
        #endregion
    }
}
