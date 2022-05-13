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
    /// 프 로 그 램 명  : 자재관리 > 자재 > 자재 창고 이동팝업
    /// 업  무  설  명  : 자재창고이동 정보를 등록 및 처리한다.
    /// 생    성    자  : scmo
    /// 생    성    일  : 2020-06-03
    /// 수  정  이  력  : 2020-06-29 | scmo | 창고이동 Multiselect를 위한 UI로 변경.
    /// 
    /// 
    /// </summary>
    public partial class WarehouseMovePopup : SmartPopupBaseForm
    {
        private string _ItemDefType { get; set; }

        private DataTable AvailableLot = new DataTable();

        public WarehouseMovePopup()
        {
            InitializeComponent();
            InitializeEvent();

            InitializeLot();
        }

        private void InitializeLot()
        {
            grdLot.GridButtonItem = GridButtonItem.Delete;
            grdLot.ShowStatusBar = false;

            grdLot.View.SetSortOrder("CONSUMABLEDEFID");
            grdLot.View.SetIsReadOnly();

            grdLot.View.AddTextBoxColumn("CONSUMABLELOTID", 100)
                .SetTextAlignment(TextAlignment.Center);
            grdLot.View.AddTextBoxColumn("CONSUMABLEDEFID", 100)
                .SetTextAlignment(TextAlignment.Center);
            grdLot.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 120);
            grdLot.View.AddComboBoxColumn("WAREHOUSEID", 80, new SqlQuery("GetComboWarehouse", "00001", $"P_LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetTextAlignment(TextAlignment.Center);
            grdLot.View.AddComboBoxColumn("CELLID", 80, new SqlQuery("GetCellId", "00001"), "CELLNAME", "LOCATIONID")
                .SetLabel("CELLNAME")
                .SetTextAlignment(TextAlignment.Center);
            grdLot.View.AddSpinEditColumn("CONSUMABLELOTQTY", 80);
            grdLot.View.AddComboBoxColumn("UNIT", 50, new SqlQuery("GetUnitList", "00001"))
                .SetTextAlignment(TextAlignment.Center);
            grdLot.View.AddComboBoxColumn("CONSUMABLETYPE", 80, new SqlQuery("GetCodeList", "00001", $"CODECLASSID=ItemDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("PRODUCTDEFTYPE")
                .SetTextAlignment(TextAlignment.Center);

            grdLot.View.PopulateColumns();
        }

        private void InitializeFromWarehouseId()
        {
            lblFromWarehouseId.Editor.ComboBoxColumnShowType = ComboBoxColumnShowType.DisplayMemberOnly;
            lblFromWarehouseId.Editor.ValueMember = "CODEID";
            lblFromWarehouseId.Editor.DisplayMember = "CODENAME";

            DataTable dt = SqlExecuter.Query("GetComboWarehouse", "00001");

            lblFromWarehouseId.Editor.DataSource = dt;
            lblFromWarehouseId.Editor.ShowHeader = false;
        }

        private void InitializeToWarehouseId()
        {
            lblToWarehouseId.Editor.ComboBoxColumnShowType = ComboBoxColumnShowType.DisplayMemberOnly;
            lblToWarehouseId.Editor.ValueMember = "CODEID";
            lblToWarehouseId.Editor.DisplayMember = "CODENAME";


            DataTable dt = SqlExecuter.Query("GetComboWarehouse", "00001");

            lblToWarehouseId.Editor.DataSource = dt;
            lblToWarehouseId.Editor.ShowHeader = false;
        }

        private void InitializeReasonId()
        {
            lblType.Editor.ComboBoxColumnShowType = ComboBoxColumnShowType.DisplayMemberOnly;
            lblType.Editor.ValueMember = "CODEID";
            lblType.Editor.DisplayMember = "CODENAME";

            lblType.Editor.DataSource = SqlExecuter.Query("GetCodeList", "00001", new Dictionary<string, object>() { { "CODECLASSID", "MoveType" }, { "LANGUAGETYPE", UserInfo.Current.LanguageType } });
            lblType.Editor.ShowHeader = false;
        }




        #region Event

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        public void InitializeEvent()
        {
            this.Load += WarehouseMovePopup_Load;
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.lblToWarehouseId.Editor.TextChanged += LblToWarehouseId_TextChanged;
            this.lblFromWarehouseId.Editor.TextChanged += LblFromWarehouseId_TextChanged;
            this.lblLotNo.Editor.KeyDown += LblLotNo_KeyDown;
            this.grdLot.ToolbarDeleteRow += GrdLot_ToolbarDeleteRow;
        }

        

        /// <summary>
        /// Form Load시 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseMovePopup_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            InitializeFromWarehouseId();
            InitializeToWarehouseId();
            InitializeReasonId();

            AvailableLot.Columns.Add("CONSUMABLELOTID", typeof(string));
            AvailableLot.Columns.Add("CONSUMABLEDEFID", typeof(string));
            AvailableLot.Columns.Add("CONSUMABLEDEFNAME", typeof(string));
            AvailableLot.Columns.Add("CONSUMABLELOTQTY", typeof(double));
            AvailableLot.Columns.Add("WAREHOUSEID", typeof(string));
            AvailableLot.Columns.Add("CELLID", typeof(string));
            AvailableLot.Columns.Add("UNIT", typeof(string));
            AvailableLot.Columns.Add("CONSUMABLETYPE", typeof(string));
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowWaitArea();
                btnSave.Focus();
                btnSave.Enabled = false;

                if (ValidateContent())
                {
                    if (ShowMessage(MessageBoxButtons.YesNo, "InfoSave") == DialogResult.Yes)
                    {
                        DataTable dtLot = grdLot.DataSource as DataTable;
                        dtLot.Columns.Add("TOWAREHOUSEID", typeof(string));
                        dtLot.Columns.Add("TOCELLID", typeof(string));
                        dtLot.Columns.Add("MOVETYPE", typeof(string));
                        dtLot.Columns.Add("DESCRIPTION", typeof(string));

                        foreach (DataRow row in dtLot.Rows)
                        {
                            row["TOWAREHOUSEID"] = lblToWarehouseId.GetValue();
                            row["TOCELLID"] = lblToCellId.Editor.GetDataValue();
                            row["MOVETYPE"] = lblType.GetValue();
                            row["DESCRIPTION"] = lblDescription.EditValue;
                        }

                        ExecuteRule("MoveMaterial", dtLot);

                        ShowMessage("SuccessSave");

                        Close();
                    }
                }
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

        private void LblToWarehouseId_TextChanged(object sender, EventArgs e)
        {
            string sWarehouseId = lblToWarehouseId.GetValue().ToString();

            lblToCellId.Editor.ComboBoxColumnShowType = ComboBoxColumnShowType.DisplayMemberOnly;
            lblToCellId.Editor.ValueMember = "LOCATIONID";
            lblToCellId.Editor.DisplayMember = "CELLNAME";

            lblToCellId.Editor.DataSource = SqlExecuter.Query("GetCellId", "00001", new Dictionary<string, object>() { { "P_WAREHOUSEID", sWarehouseId } });
            lblToCellId.Editor.ShowHeader = false;
        }

        private void LblFromWarehouseId_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LblLotNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            string sLotId = lblLotNo.Editor.Text;

            DataTable dtLot = grdLot.DataSource as DataTable;

            if(dtLot != null)
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

                    newRow["CONSUMABLELOTID"] = sLotId;
                    newRow["CONSUMABLEDEFID"] = row["CONSUMABLEDEFID"].ToString();
                    newRow["CONSUMABLEDEFNAME"] = row["CONSUMABLEDEFNAME"].ToString();
                    newRow["CONSUMABLELOTQTY"] = row["CONSUMABLELOTQTY"].ToString();
                    newRow["WAREHOUSEID"] = row["WAREHOUSEID"].ToString();
                    newRow["CELLID"] = row["CELLID".ToString()];
                    newRow["UNIT"] = row["UNIT"].ToString();
                    newRow["CONSUMABLETYPE"] = row["CONSUMABLETYPE"].ToString();
               
                    dtLot.Rows.Add(newRow);

                    rValue = true;
                }
            }

            if (rValue == false)
            {
                ShowMessage("IsNotCorrectLot");
            }

            grdLot.DataSource = dtLot;

            this.lblLotNo.Editor.EditValue = null;
            this.lblLotNo.Editor.Text = "";
        }

        /// <summary>
        /// 그릳 Delete 버튼 클릭 이벤트
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

        /// <summary>
        /// 저장시 Validation 체크
        /// </summary>
        /// <returns></returns>
        private bool ValidateContent()
        {
            bool result = true;

            if (lblType.GetValue() == null || lblType.GetValue().Equals(""))
                result = false;

            if (lblToWarehouseId.GetValue() == null || lblToWarehouseId.GetValue().Equals(""))
                result = false;

            DataTable dtLot = grdLot.DataSource as DataTable;
            if (dtLot.Rows.Count < 1)
                result = false;


            return result;
        }

        private void LoadData()
        {
            AvailableLot.Clear();

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_WAREHOUSEID", lblFromWarehouseId.GetValue().ToString());

            DataTable newDt = SqlExecuter.Query("GetMaterialMovable", "00001", param);

            newDt.AsEnumerable().CopyToDataTable(AvailableLot, LoadOption.Upsert);

        }

        #endregion
    }
}
