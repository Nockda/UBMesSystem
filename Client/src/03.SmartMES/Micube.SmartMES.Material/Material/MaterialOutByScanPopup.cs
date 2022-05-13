#region using

using DevExpress.XtraGrid.Views.Grid;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using Micube.SmartMES.Commons;
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
    public partial class MaterialOutByScanPopup : SmartPopupBaseForm, ISmartCustomPopup
    {
        #region Local Variables

        /// <summary>
        /// 팝업 그리드와 원래 그리드를 비교하기 위한 변수
        /// </summary>
        private DataTable _mappingDataSource = new DataTable();

        /// <summary>
        /// 팝업진입전 그리드의 Row
        /// </summary>
        public DataRow CurrentDataRow { get; set; }

        public DataTable CurrentDataTable { get; set; }

        private DataTable AvailableLot = new DataTable();

        #endregion

        #region 컨텐츠 영역 초기화

        public MaterialOutByScanPopup()
        {
            InitializeComponent();
            InitializeEvent();

            InitializeInfo();
            InitializeLot();

            this.chkAutoPrint.EditValue = true;
        }

        /// <summary>        
        /// 아이템 그리드를 초기화한다.
        /// </summary>
        private void InitializeInfo()
        {
            // 그리드 초기화
            grdInfo.GridButtonItem = GridButtonItem.None;
            grdInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdInfo.ShowStatusBar = false;
            grdInfo.View.SetIsReadOnly();
            grdInfo.View.SetSortOrder("ITEMID");


            grdInfo.View.AddComboBoxColumn("OUTCELLID", 100, new SqlQuery("GetCellId", "00001"), "CELLNAME", "LOCATIONID")
                .SetIsReadOnly()
                .SetLabel("CELLNAME")
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("REQSEQ")
                .SetIsHidden();
            grdInfo.View.AddTextBoxColumn("REQSERL")
                .SetIsHidden();
            grdInfo.View.AddTextBoxColumn("REQNO")
                .SetTextAlignment(TextAlignment.Center)
                .SetLabel("REQCODE");
            grdInfo.View.AddTextBoxColumn("ITEMSEQ")
                .SetIsHidden();
            grdInfo.View.AddTextBoxColumn("ITEMNO", 120)
                .SetLabel("CONSUMABLEDEFID")
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            grdInfo.View.AddTextBoxColumn("ITEMNAME", 180)
                .SetLabel("CONSUMABLEDEFNAME")
                .SetIsReadOnly();
            grdInfo.View.AddTextBoxColumn("UNITSEQ", 50)
                .SetIsHidden();
            grdInfo.View.AddTextBoxColumn("UNITNAME", 50)
                .SetLabel("UNIT")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddSpinEditColumn("REQQTY", 80)
                .SetDisplayFormat("#,###.##")
                .SetLabel("OUTREQQTY")
                .SetIsReadOnly();
            grdInfo.View.AddSpinEditColumn("PROGQTY", 80)
                .SetDisplayFormat("#,###.##")
                .SetLabel("OUTQTY")
                .SetIsReadOnly();
            grdInfo.View.AddSpinEditColumn("LEFTQTY", 80)
                .SetDisplayFormat("#,###.##")
                .SetLabel("OUTLEFTQTY")
                .SetIsReadOnly();
            grdInfo.View.AddSpinEditColumn("STOCKQTY", 80)
                .SetDisplayFormat("#,###.##")
                .SetIsReadOnly();
            grdInfo.View.AddTextBoxColumn("OUTWHSEQ", 50)
                .SetIsHidden();
            grdInfo.View.AddTextBoxColumn("OUTWAREHOUSENAME", 80)
                .SetIsReadOnly()
                .SetLabel("FROMWAREHOUSEID")
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("INWHSEQ", 50)
                .SetIsHidden();
            grdInfo.View.AddTextBoxColumn("INWAREHOUSENAME", 80)
                .SetIsReadOnly()
                .SetLabel("TOWAREHOUSEID")
                .SetTextAlignment(TextAlignment.Center);
            grdInfo.View.AddTextBoxColumn("DEPTSEQ", 50)
                .SetIsHidden();


            grdInfo.View.PopulateColumns();
        }

        private void InitializeLot()
        {
            grdLot.GridButtonItem = GridButtonItem.Delete;
            grdLot.View.GridMultiSelectionMode = GridMultiSelectionMode.RowSelect;
            grdLot.View.OptionsView.AllowCellMerge = true;
            grdLot.ShowStatusBar = false;

            grdLot.View.SetSortOrder("CONSUMABLEDEFID");
            grdLot.View.SetAutoFillColumn("CONSUMABLEDEFNAME");

            grdLot.View.AddTextBoxColumn("SEQ", 50)
                .SetIsHidden();
            grdLot.View.AddTextBoxColumn("REQSEQ")
                .SetIsHidden();
            grdLot.View.AddTextBoxColumn("REQSERL")
                .SetIsHidden();
            grdLot.View.AddTextBoxColumn("REQNO", 100)
                .SetIsHidden();
            grdLot.View.AddTextBoxColumn("CONSUMABLEDEFID", 120)
                .SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("ITEMSEQ", 50)
                .SetIsHidden();
            grdLot.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 150)
                .SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("ITEMSTANDARD", 150)
                .SetLabel("STANDARD")
                .SetIsReadOnly();
            grdLot.View.AddTextBoxColumn("CONSUMABLELOTID", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetIsReadOnly();
            grdLot.View.AddSpinEditColumn("CONSUMABLELOTQTY", 80)
                .SetDisplayFormat("#,###.##");
            grdLot.View.AddTextBoxColumn("UNITSEQ", 50)
                .SetIsHidden();
            grdLot.View.AddTextBoxColumn("UNITNAME", 50)
                .SetLabel("UNIT")
                .SetIsReadOnly();

            grdLot.View.PopulateColumns();
        }

        #endregion

        #region Event

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        public void InitializeEvent()
        {
            this.Load += MaterialOutByScanPopup_Load;
            this.lblLotNo.Editor.KeyDown += LblLotNo_KeyDown;
            this.btnTempSave.Click += BtnTempSave_Click;
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;

            grdLot.View.CellMerge += View_CellMerge;
            grdLot.ToolbarDeleteRow += GrdLot_ToolbarDeleteRow;
        }

        /// <summary>
        /// Form Road시 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaterialOutByScanPopup_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            LoadData();
            LoadTempData();
        }

        private void LblLotNo_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode != Keys.Enter) return;

            string sLotId = lblLotNo.Editor.Text;

            DataTable dtLot = grdLot.DataSource as DataTable;

            if (dtLot != null)
            {
                foreach (DataRow lotRow in dtLot.Rows)
                {
                    if (lotRow["CONSUMABLELOTID"].ToString() == sLotId)
                    {
                        ShowMessage("SelectOverlap");
                        return;
                    }
                }
            }

            bool rValue = false;

            foreach (DataRow row in AvailableLot.Rows)
            {
                if (row["CONSUMABLELOTID"].ToString() == sLotId)
                {
                    DataRow newRow = dtLot.NewRow();

                    DataTable dtInfo = grdInfo.DataSource as DataTable;
                    foreach(DataRow masterRow in dtInfo.Rows)
                    {
                        if(row["CONSUMABLEDEFID"].ToString() == masterRow["ITEMNO"].ToString())
                        {
                            newRow["REQSEQ"] = masterRow["REQSEQ"].ToString();
                            newRow["REQSERL"] = masterRow["REQSERL"].ToString();
                            newRow["REQNO"] = masterRow["REQNO"].ToString();

                            //스캔한 LOT의 출고창고와 출고요청정보의 출고창고가 다른경우
                            if(row["WAREHOUSEID"].ToString() != masterRow["OUTWHSEQ"].ToString())
                            {
                                throw MessageException.Create("IsNotCorrectLot");
                                return;
                            }
                        }
                    }
                    newRow["CONSUMABLEDEFID"] = row["CONSUMABLEDEFID"].ToString();
                    newRow["ITEMSEQ"] = row["ITEMSEQ"].ToString();
                    newRow["CONSUMABLEDEFNAME"] = row["CONSUMABLEDEFNAME"].ToString();
                    newRow["UNITSEQ"] = row["UNITSEQ"].ToString();
                    newRow["UNITNAME"] = row["UNITNAME"].ToString();
                    newRow["ITEMSTANDARD"] = row["ITEMSTANDARD"].ToString();
                    newRow["CONSUMABLELOTID"] = sLotId;
                    newRow["CONSUMABLELOTQTY"] = row["CONSUMABLELOTQTY"].ToString();

                    dtLot.Rows.Add(newRow);

                    rValue = true;
                }
            }

            if(rValue == false)
            {
                ShowMessage("IsNotCorrectLot");
            }

            grdLot.DataSource = dtLot;
            
            this.lblLotNo.Editor.EditValue = null;
            this.lblLotNo.Editor.Text = "";
        }

        private void BtnTempSave_Click(object sender,EventArgs e)
        {
            try
            {
                this.ShowWaitArea();
                btnTempSave.Focus();
                btnTempSave.Enabled = false;

                DataTable dtTemp = grdLot.DataSource as DataTable;

                if (dtTemp.Rows.Count == 0)
                {
                    throw MessageException.Create("NoSaveData");
                    return;
                }

                DataTable dtMaster = grdInfo.DataSource as DataTable;

                ExecuteRule("SaveDeliveryMaterialTempInit", dtMaster);

                ExecuteRule("SaveDeliveryMaterialTemp", dtTemp);

                Close();

            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnTempSave.Enabled = true;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowWaitArea();
                btnSave.Focus();
                btnSave.Enabled = false;

                if (!ValidationCheck())
                {
                    throw MessageException.Create("CheckOutQty");//출고할 수량을 확인하세요.
                    return;
                }

                if(!ValidationOverStock())
                {
                    if(MSGBox.Show(MessageBoxType.Question, "DelvOverStock", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }

                DataTable dtLot = grdLot.DataSource as DataTable;
                dtLot.Columns.Add("OUTWHSEQ", typeof(string));
                dtLot.Columns.Add("INWHSEQ", typeof(string));
                dtLot.Columns.Add("DEPTSEQ", typeof(string));

                DataTable dtSource = grdInfo.DataSource as DataTable;

                foreach (DataRow row in dtLot.Rows)
                {
                    foreach (DataRow sourceRow in dtSource.Rows)
                    {
                        if (row["REQSEQ"].Equals(sourceRow["REQSEQ"]) && row["REQSERL"].Equals(sourceRow["REQSERL"]) && row["ITEMSEQ"].Equals(sourceRow["ITEMSEQ"].ToString()))
                        {
                            row["OUTWHSEQ"] = sourceRow["OUTWHSEQ"];
                            row["INWHSEQ"] = sourceRow["INWHSEQ"];
                            row["DEPTSEQ"] = sourceRow["DEPTSEQ"];
                        }
                    }
                }

                DataTable resultTable = ExecuteRule<DataTable>("DeliveryMaterial", dtLot); //Lot 이동 및 분할

                ExecuteRule("SaveDeliveryMaterialTempInit", dtSource);  //Temp 테이블 삭제

                dtSource.Columns.Add("_STATE_", typeof(string));
                foreach (DataRow row in dtSource.Rows)
                {
                    row["_STATE_"] = "modified";
                }

                ExecuteRule("DeliveryRequest", dtSource);

                if (resultTable.Rows.Count > 0)
                {
                    if (chkAutoPrint.EditValue.Equals(true))
                    {
                        foreach (DataRow resultRow in resultTable.Rows)
                        {
                            string lotId = resultRow["LOTID"].ToString();
                            CommonFunction.PrintMaterialLabel(lotId);
                        }
                    }
                }



                DialogResult = DialogResult.OK;
                Close();

            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.CloseWaitArea();
                btnSave.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void View_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            if (e.Column.FieldName == "CONSUMABLEDEFID" || e.Column.FieldName == "CONSUMABLEDEFNAME" || e.Column.FieldName == "ITEMSTANDARD")
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

        /// <summary>
        /// 그리드 Delete 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdLot_ToolbarDeleteRow(object sender, EventArgs e)
        {
            try
            {
                grdLot.ShowWaitArea();

                (grdLot.View.DataSource as DataView).Delete(grdLot.View.FocusedRowHandle);
                (grdLot.View.DataSource as DataView).Table.AcceptChanges();

            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            finally
            {
                grdLot.CloseWaitArea();
            }
        }

        #endregion

        #region Private Function

        private void LoadData()
        {
            DataTable dtItems = new DataTable();

            dtItems = CurrentDataTable;

            if (dtItems.Rows.Count < 1)
            {
                ShowMessage("NoSelectData"); // 조회할 데이터가 없습니다.
            }
            else
            {
                AvailableLot.Columns.Add("CONSUMABLELOTID", typeof(string));
                AvailableLot.Columns.Add("CONSUMABLEDEFID", typeof(string));
                AvailableLot.Columns.Add("ITEMSEQ", typeof(int));
                AvailableLot.Columns.Add("CONSUMABLEDEFNAME", typeof(string));
                AvailableLot.Columns.Add("UNITSEQ", typeof(int));
                AvailableLot.Columns.Add("UNITNAME", typeof(string));
                AvailableLot.Columns.Add("ITEMSTANDARD", typeof(string));
                AvailableLot.Columns.Add("CONSUMABLELOTQTY", typeof(double));
                AvailableLot.Columns.Add("WAREHOUSEID", typeof(string));
                AvailableLot.Columns.Add("CELLID", typeof(string));

                foreach (DataRow row in CurrentDataTable.Rows)
                {
                    Dictionary<string, object> param = new Dictionary<string, object>();
                    param.Add("P_CONSUMABLEDEFID", row["ITEMSEQ"].ToString());

                    DataTable newDt = SqlExecuter.Query("GetAvailableConsumableLotByReqNo", "00001", param);

                    newDt.AsEnumerable().CopyToDataTable(AvailableLot, LoadOption.Upsert);
                }
            }

            grdInfo.DataSource = dtItems;
        }

        private void LoadTempData()
        {
            DataTable dtTemps = new DataTable();

            DataView view = CurrentDataTable.DefaultView;

            DataTable distinctTable = view.ToTable(true, new string[] { "REQSEQ","REQSERL", "ITEMSEQ"});

            foreach(DataRow row in distinctTable.Rows)
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("P_REQSEQ", row["REQSEQ"].ToString());
                param.Add("P_REQSERL", row["REQSERL"].ToString());
                param.Add("P_ITEMSEQ", row["ITEMSEQ"].ToString());

                DataTable dtTemp = SqlExecuter.Query("GetMaterialOutTemp", "00001", param);

                dtTemps.Merge(dtTemp);
            }

            grdLot.DataSource = dtTemps;
        }

        private bool ValidationCheck()
        {
            bool result = true;

            DataTable dtTarget = grdLot.DataSource as DataTable;

            foreach(DataRow row in dtTarget.Rows)
            {
                if (row["CONSUMABLELOTQTY"] == null)
                    result = false;
            }

            if(result == true)
            {
                DataTable dtSource = grdInfo.DataSource as DataTable;

                foreach(DataRow sourceRow in dtSource.Rows)
                {
                    decimal dReqQty = Convert.ToDecimal(sourceRow["LEFTQTY"].ToString()); //미출고수량
                    decimal dSumQty = 0;

                    string expression = String.Format("REQSEQ = {0} AND REQSERL = {1} AND ITEMSEQ = {2}", sourceRow["REQSEQ"].ToString(), sourceRow["REQSERL"].ToString(), sourceRow["ITEMSEQ"].ToString());
                    dSumQty = dtTarget.Select(expression).AsEnumerable().Sum(x => Convert.ToDecimal(x["CONSUMABLELOTQTY"]));

                    if (dSumQty == 0)
                        result = false;
                }
            }

            return result;
        }

        private bool ValidationOverStock()
        {
            bool result = true;

            DataTable dtTarget = grdLot.DataSource as DataTable;

            DataTable dtSource = grdInfo.DataSource as DataTable;

            foreach (DataRow sourceRow in dtSource.Rows)
            {
                decimal dReqQty = Convert.ToDecimal(sourceRow["LEFTQTY"].ToString()); //미출고수량
                decimal dSumQty = 0;

                string expression = String.Format("REQSEQ = {0} AND REQSERL = {1} AND ITEMSEQ = {2}", sourceRow["REQSEQ"].ToString(), sourceRow["REQSERL"].ToString(), sourceRow["ITEMSEQ"].ToString());
                dSumQty = dtTarget.Select(expression).AsEnumerable().Sum(x => Convert.ToDecimal(x["CONSUMABLELOTQTY"]));

                if (dReqQty < dSumQty)
                    result = false;
            }
            
            return result;
        }

        #endregion
    }

}