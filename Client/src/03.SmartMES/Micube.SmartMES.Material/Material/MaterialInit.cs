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
using System.Windows.Forms;
using Micube.SmartMES.Commons;

#endregion

namespace Micube.SmartMES.Material
{
    /// <summary>
    /// 프 로 그 램 명  : 자재관리 > 자재 > 자재 재고 LOT생성
    /// 업  무  설  명  : 실물재고를 LOT채번한다. (ERP연동은 하지 않는다.)
    /// 생    성    자  : scmo
    /// 생    성    일  : 2020-05-26
    /// 수  정  이  력  : 
    /// 
    /// 
    /// </summary>
    public partial class MaterialInit : SmartConditionBaseForm
    {
        public MaterialInit()
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

            this.smartSpliterContainer1.SplitterPosition = 1200;

            InitializeEvent();

            // 컨트롤 초기화 로직 구성
            InitializeList();
            InitializeDetail();
        }

        /// <summary>        
        /// 마스터 그리드를 초기화한다.
        /// </summary>
        private void InitializeList()
        {
            grdList.View.OptionsSelection.MultiSelect = true;

            // 그리드 초기화
            grdList.GridButtonItem = GridButtonItem.Export;
            //grdList.View.OptionsView.AllowCellMerge = true;
            grdList.View.OptionsView.EnableAppearanceEvenRow = false;
            grdList.View.OptionsView.EnableAppearanceOddRow = false;
            grdList.View.SetIsReadOnly();

            grdList.View.SetSortOrder("PARTNUMBER");

            grdList.View.AddTextBoxColumn("CONSUMABLEDEFID", 50)
                .SetIsHidden();
            grdList.View.AddTextBoxColumn("PARTNUMBER", 110)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 200);
            grdList.View.AddComboBoxColumn("MODELID", 150, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ModelCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("ITEMSTANDARD", 180)
                .SetLabel("STANDARD")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("CONSUMABLETYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ItemDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("WAREHOUSEID", 120, new SqlQuery("GetComboWarehouse", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("CELLID", 80, new SqlQuery("GetCellId", "00001"), "CELLNAME", "LOCATIONID")
                .SetLabel("CELLNAME")
                .SetIsHidden()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddSpinEditColumn("STOCKQTY", 80)
                .SetDisplayFormat("#,##0.##")
                .SetLabel("ERPQTY");
            grdList.View.AddSpinEditColumn("LOTQTY", 80)
                .SetDisplayFormat("#,##0.##")
                .SetLabel("MESSTOCK");
            grdList.View.AddSpinEditColumn("INITQTY", 80)
                .SetDisplayFormat("#,##0.##");
            grdList.View.AddSpinEditColumn("LOTSIZE", 80);
            grdList.View.AddTextBoxColumn("UNIT", 60)
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("LOTCREATERULETYPE", 80)
                .SetTextAlignment(TextAlignment.Center);

            grdList.View.PopulateColumns();
        }

        private void InitializeDetail()
        {
            grdDetail.GridButtonItem = GridButtonItem.Add;
            grdDetail.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grdDetail.View.SetSortOrder("CONSUMABLELOTID");

            grdDetail.View.AddTextBoxColumn("CONSUMABLELOTID", 120)
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("CONSUMABLEDEFID", 150)
                .SetIsReadOnly()
                .SetIsHidden();
            grdDetail.View.AddTextBoxColumn("PARTNUMBER", 110)
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("CONSUMABLETYPE", 80)
                .SetIsReadOnly()
                .SetIsHidden();
            grdDetail.View.AddComboBoxColumn("WAREHOUSEID", 100, new SqlQuery("GetComboWarehouse", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddComboBoxColumn("LOCATIONID", 100, new SqlQuery("GetCellId", "00001"), "CELLNAME", "LOCATIONID")
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddSpinEditColumn("CREATEDQTY", 80)
                .SetDisplayFormat("#,##0.##");
            grdDetail.View.AddTextBoxColumn("LOTCREATERULETYPE", 50)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center)
                .SetIsHidden();
            grdDetail.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdDetail.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            grdDetail.View.PopulateColumns();

        }

        #endregion

        #region MyRegion

        
        /// <summary>
        /// 화면에서 사용되는 이벤트를 초기화한다.
        /// </summary>
        public void InitializeEvent()
        {
            // 화면에서 사용할 이벤트 추가
            //grdList.View.CellMerge += ListView_CellMerge;
            grdList.View.RowStyle += ListView_RowStyle;
            grdList.View.FocusedRowChanged += ListView_FocusedRowChanged;

            grdDetail.View.ShowingEditor += View_ShowingEditor;
            grdDetail.View.CellValueChanged += View_CellValueChanged;
            grdDetail.View.AddingNewRow += View_AddingNewRow;
        }

        

        private void ListView_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            if (e.Column.FieldName == "CONSUMABLEDEFID" || e.Column.FieldName == "CONSUMABLEDEFNAME" 
                || e.Column.FieldName == "MODELID" || e.Column.FieldName == "ITEMSTANDARD" || e.Column.FieldName == "CONSUMABLETYPE")
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

        private void ListView_RowStyle(object sender, RowStyleEventArgs e)
        {
            var vErpStock = grdList.View.GetRowCellValue(e.RowHandle, "STOCKQTY");
            var vMesStock = grdList.View.GetRowCellValue(e.RowHandle, "LOTQTY");

            if (vErpStock == null || vMesStock == null)
                return;

            if(vErpStock.Equals(vMesStock))
            {
                e.Appearance.BackColor = Color.FromArgb(30, 0, 255, 0);
            }
            else
            {
                e.Appearance.BackColor = Color.FromArgb(30, 255, 0, 0);
            }
        }

        /// <summary>
        /// 상위 그리드 행 선택 변경시 하위 그리드 반영
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            focusedRowChange();
        }


        private void View_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (grdDetail.View.GetFocusedRowCellValue("LOTCREATERULETYPE").ToString().Equals("Auto"))
            {
                string focusColumn = grdDetail.View.FocusedColumn.FieldName;

                if (focusColumn.Equals("CONSUMABLELOTID"))
                {
                    e.Cancel = true;
                }
            }

            if (grdDetail.View.GetFocusedRowCellValue("LOTCREATERULETYPE").ToString().Equals(""))
            {
                e.Cancel = true;
            }
        }

        private void View_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.FieldName == "WAREHOUSEID")
            {
                DataRow row = grdDetail.View.GetFocusedDataRow();

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("P_WAREHOUSEID", row["WAREHOUSEID"]);
                grdDetail.View.RefreshComboBoxDataSource("LOCATIONID", new SqlQuery("GetCellId", "00001", param));
            }
        }

        private void View_AddingNewRow(SmartBandedGridView sender, AddNewRowArgs args)
        {
            DataRow focusRow = grdList.View.GetFocusedDataRow();

            if(focusRow == null)
            {
                args.IsCancel = true;
                return;
            }

            string consumabledefId = focusRow["CONSUMABLEDEFID"].ToString();
            string partnumber = focusRow["PARTNUMBER"].ToString();
            string warehouseId = focusRow["WAREHOUSEID"].ToString();
            string cellId = focusRow["CELLID"].ToString();
            string lotcreateruleType = focusRow["LOTCREATERULETYPE"].ToString();
            string consumableType = focusRow["CONSUMABLETYPE"].ToString();
            string lotsize = focusRow["LOTSIZE"].ToString();

            if(lotcreateruleType == "NotCreate")
            {
                throw MessageException.Create("INPUTMAINSEGMENTID");
                args.IsCancel = true;
                return;
            }


            args.NewRow["CONSUMABLEDEFID"] = consumabledefId;
            args.NewRow["PARTNUMBER"] = partnumber;
            args.NewRow["WAREHOUSEID"] = warehouseId;
            args.NewRow["LOCATIONID"] = cellId;
            args.NewRow["LOTCREATERULETYPE"] = lotcreateruleType;
            args.NewRow["CONSUMABLETYPE"] = consumableType;
            args.NewRow["CREATEDQTY"] = (lotsize == "") ? 0: Convert.ToDecimal(lotsize);

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_WAREHOUSEID", warehouseId);
            grdDetail.View.RefreshComboBoxDataSource("LOCATIONID", new SqlQuery("GetCellId", "00001", param));

            if (lotcreateruleType != "Auto")
                MSGBox.Show(MessageBoxType.Information, "REQUIREDLOT");

        }

        #endregion


        #region ToolBar
        protected override void OnToolbarClick(object sender, EventArgs e)
        {
            SmartButton btn = sender as SmartButton;

            if(btn.Name.ToString().Equals("LabelPrint"))
            {
                DataTable selected = grdDetail.View.GetCheckedRows();

                if (selected.Rows.Count < 1)
                {
                    ShowMessage("NoPrintData");
                    return;
                }

                foreach(DataRow row in selected.Rows)
                {
                    string itemDefType = row["CONSUMABLETYPE"].ToString();
                    string lotId = row["CONSUMABLELOTID"].ToString();

                    if (itemDefType == "Material")
                    {
                        CommonFunction.PrintMaterialLabel(lotId);
                    }
                    else
                    {
                        CommonFunction.PrintLotLabel(lotId);
                    }
                } 
            }
            else if(btn.Name.ToString().Equals("Save"))
            {
                Save();
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

            DateTime now = DateTime.Now;
            var dateFrom = new DateTime(now.Year, now.Month, 1);
            var dateTo = dateFrom.AddMonths(1).AddDays(-1);

            var values = Conditions.GetValues();
            values.Add("p_LANGUAGETYPE", UserInfo.Current.LanguageType);
            values.Add("PODateFr", dateFrom.ToString("yyyyMMdd"));
            values.Add("PODateTo", dateTo.ToString("yyyyMMdd"));
            
            if (values["P_WAREHOUSE"].ToString() == "*")
                values["P_WAREHOUSE"] = 0;

            DataTable dtList = await ProcedureAsync("USP_ERPIF_GETWAREHOUSESTOCKFORINIT",  values);

            if (dtList.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdList.DataSource = dtList;
        }

        /// <summary>
        /// 조회조건 항목을 추가한다.
        /// </summary>
        protected override void InitializeCondition()
        {
            base.InitializeCondition();
            CommonFunction.AddConditionAllItemPopup("P_PRODUCTDEFID", 2.1, true, Conditions, "PRODUCTDEFID");

        }
        /// <summary>
        /// 조회조건의 컨트롤을 추가한다.
        /// </summary>
        protected override void InitializeConditionControls()
        {
            base.InitializeConditionControls();

        }

        #endregion

        #region 유효성 검사

        /// <summary>
        /// 데이터 저장할때 컨텐츠 영역의 유효성 검사
        /// </summary>
        protected override void OnValidateContent()
        {
            base.OnValidateContent();
            grdDetail.View.CheckValidation();

            DataTable changed = grdDetail.GetChangedRows();//변경된 row

            if (changed.Rows.Count == 0)
            {
                throw MessageException.Create("NoSaveData");
            }
        }

        #endregion

        #region Private Function
        private bool ValidateContent(DataTable selected)
        {
            bool result = true;

            foreach(DataRow row in selected.Rows)
            {
                if (row["CREATEDQTY"] == System.DBNull.Value)
                    result = false;
                else
                {
                    if (Convert.ToInt32(row["CREATEDQTY"]) == 0 || Convert.ToInt32(row["CREATEDQTY"]) < 0 || string.IsNullOrEmpty(row["CREATEDQTY"].ToString()))
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        private bool ValidateNotAutoData(DataTable selected)
        {
            bool result = true;

            foreach(DataRow row in selected.Rows)
            {
                if(row["LOTCREATERULETYPE"].ToString() != "Auto")
                {
                    if (String.IsNullOrEmpty(row["CONSUMABLELOTID"].ToString()))
                        result = false;
                }
            }

            return result;
        }



        /// <summary>
        /// 저장 버튼을 클릭하면 호출한다.
        /// </summary>
        private void Save()
        {
            grdDetail.View.PostEditor();
            grdDetail.View.UpdateCurrentRow();

            DataTable changed = grdDetail.GetChangedRows();

            if (!ValidateContent(changed))
            {
                throw MessageException.Create("ISREQUIREDQTY");
                return;
            }

            if(!ValidateNotAutoData(changed))
            {
                throw MessageException.Create("ISREQUEREDLOTNO");
                return;
            }

            changed.Columns.Add("CONSUMABLESTATE", typeof(string));
            changed.Columns.Add("STATE", typeof(string));

            foreach (DataRow row in changed.Rows)
            {
                row["CONSUMABLESTATE"] = "Available";
                row["STATE"] = "InMate";
            }

            ExecuteRule("CreateConsumableLotByInit", changed);


            this.ShowMessage("SuccessSave");

            OnSearchAsync();
            focusedRowChange();
        }

        private void focusedRowChange()
        {
            if (grdList.View.FocusedRowHandle < 0)
                return;

            DataRow dr = grdList.View.GetFocusedDataRow();

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_LANGUAGETYPE", UserInfo.Current.LanguageType);
            param.Add("P_CONSUMABLEDEFID", dr["CONSUMABLEDEFID"].ToString());
            param.Add("P_WAREHOUSEID", dr["WAREHOUSEID"].ToString());

            DataTable dtDetail = SqlExecuter.Query("GetMaterialLotByInit", "00001", param);
            if (dtDetail.Rows.Count < 1)
            {
                grdDetail.DataSource = null;
            }
            else
            {
                grdDetail.DataSource = dtDetail;
            }
        }

        #endregion

    }
}
