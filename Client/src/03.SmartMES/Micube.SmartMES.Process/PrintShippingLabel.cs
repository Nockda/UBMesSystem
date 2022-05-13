using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micube.SmartMES.Process
{
    /// <summary>
    /// 프 로 그 램 명  : 공정관리 > 공정작업 > 출하라벨 발행
    /// 업  무  설  명  : 출하라벨을 발행한다.
    /// 생    성    자  : yshwang
    /// 생    성    일  : 2020-06-29
    /// 수  정  이  력  :
    /// </summary>
    public partial class PrintShippingLabel : SmartConditionBaseForm
    {
        private const string PRINT_PRODUCT_LABEL = "PrintProductLabel";
        private const string PRINT_SHIPPING_LABEL = "PrintShippingLabel";

        public PrintShippingLabel()
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
            InitializeEvent();
            spnCopy.Editor.Properties.MinValue = 1;
            spnCopy.Editor.Properties.MaxValue = 100;
            spnCopy.Editor.Value = 1;
        }

        // 그리드 초기화
        private void InitializeGrid()
        {
            InitializeLotGrid();
            InitializeLabelGrid();
        }

        // LOT 그리드 초기화
        private void InitializeLotGrid()
        {
            grdLot.GridButtonItem = GridButtonItem.Export;
            grdLot.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdLot.View.AddTextBoxColumn("LOTID", 120).SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("WAREHOUSENAME", 120).SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("AREANAME", 120).SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 130).SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("PARTNUMBER", 130).SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("PRODUCTDEFNAME", 180).SetIsReadOnly();
            grdLot.View.AddComboBoxColumn("SUBPARTNUMBER", 80, new SqlQuery("GetCodeList", "00001"
                    , "CODECLASSID=SubPartNumber", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
               .SetTextAlignment(TextAlignment.Center);
            grdLot.View.AddTextBoxColumn("STANDARD", 130).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("MODEL", 120).SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("QTY", 70).SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("SHIPPINGSTATE", 80).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("TRACKINTIME", 140)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("TRACKOUTTIME", 140)
                .SetDisplayFormat("yyyy-MM-dd HH:mm:ss").SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("WORKER", 80).SetTextAlignment(TextAlignment.Center).SetIsReadOnly();
            grdLot.View.PopulateColumns();
        }

        // 라벨 그리드 초기화
        private void InitializeLabelGrid()
        {
            grdLabel.GridButtonItem = GridButtonItem.Export;
            grdLabel.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdLabel.View.SetIsReadOnly();
            grdLabel.View.AddTextBoxColumn("LABELTYPE", 100);
            grdLabel.View.AddTextBoxColumn("LABELID", 280);
            grdLabel.View.AddTextBoxColumn("LABELNAME", 280);
            grdLabel.View.AddTextBoxColumn("DESCRIPTION", 550);
            grdLabel.View.PopulateColumns();
        }
        #endregion

        #region Event
        private void InitializeEvent()
        {
            grdLot.View.FocusedRowChanged += GrdLot_FocusedRowChanged;
            grdLot.View.RowCellStyle += grdLot_RowCellStyle;
        }

        private void GrdLot_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RefreshLabelGrid();
        }

        private void RefreshLabelGrid()
        {
            if (grdLot.View.FocusedRowHandle < 0)
            {
                return;
            }
            var param = new Dictionary<string, object>()
            {
                { "LOTID", grdLot.View.GetFocusedRowCellValue("LOTID").ToString() }
                , { "LANGUAGETYPE", UserInfo.Current.LanguageType }
            };
            grdLabel.DataSource = SqlExecuter.Query("GetMappedPackageLabels", "00001", param);
        }

        private void grdLot_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if(e.Column.FieldName == "SUBPARTNUMBER")
            {
                e.Appearance.ForeColor = System.Drawing.Color.Black;
                e.Appearance.BackColor = System.Drawing.Color.LightYellow;
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
            SearchProductsAsync();
        }

        private async void SearchProductsAsync()
        {
            grdLabel.View.ClearDatas();

            var values = Conditions.GetValues();
            values.Add("LANGUAGETYPE", UserInfo.Current.LanguageType);

            DataTable result = await QueryAsync("GetLotsForPackageLabel", "00001", values);
            grdLot.DataSource = result;
            RefreshLabelGrid();
            if (result.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }
        }

        protected override void InitializeCondition()
        {
            base.InitializeCondition();
        }
        #endregion

        #region ToolBar
        /// <summary>
        /// 라벨재발행 버튼
        /// </summary>
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            DataTable checkedRows = grdLot.View.GetCheckedRows();
            if (checkedRows.Rows.Count < 1)
            {
                ShowMessage("NoSaveData");
                return;
            }
            // MBS-C 사양 저장
            MessageWorker messageWorker = new MessageWorker("SaveSubPartNumber");
            messageWorker.SetBody(new MessageBody()
            {
                { "list", checkedRows }
            });
            messageWorker.Execute();

            SmartButton button = sender as SmartButton;
            switch(button.Name.ToString())
            {
                case PRINT_PRODUCT_LABEL:
                    foreach (DataRow each in checkedRows.Rows)
                    {
                        CommonFunction.PrintProductLabel(each["LOTID"].ToString(), (short)spnCopy.Editor.Value);
                    }
                    break;
                case PRINT_SHIPPING_LABEL:
                    ExecuteRule("ShipProduct", checkedRows);
                    foreach (DataRow each in checkedRows.Rows)
                    {
                        CommonFunction.PrintShippingLabel(each["LOTID"].ToString(), (short)spnCopy.Editor.Value);
                    }
                    break;
            }
        }
        #endregion

        private string CheckSystemOption(DataTable checkedRows)
        {
            string result = null;
            DataTable resultTable = ExecuteRule<DataTable>("ShipProductCheckOption", checkedRows);
            foreach(DataRow row in resultTable.Rows)
            {
                result = row["codeData"].ToString();
            }
            return result;
        }
    }
}
