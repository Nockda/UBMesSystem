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
    public partial class MaterialOutPopup : SmartPopupBaseForm, ISmartCustomPopup
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


        #endregion

        public MaterialOutPopup()
        {
            InitializeComponent();
            InitializeEvent();
        }

        #region 컨텐츠 영역 초기화

        /// <summary>
        /// 마스터 리스트 그리드 초기화
        /// </summary>
        private void InitializeSource()
        {
            grdSource.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdSource.GridButtonItem = GridButtonItem.None;
            grdSource.View.SetSortOrder("CONSUMABLELOTID");
            grdSource.View.SetAutoFillColumn("CELLNAME");

            grdSource.View.SetIsReadOnly();

            grdSource.View.AddTextBoxColumn("CONSUMABLELOTID", 80);
            grdSource.View.AddTextBoxColumn("INDATE", 80);
            grdSource.View.AddSpinEditColumn("LOTQTY", 50);
            grdSource.View.AddTextBoxColumn("WAREHOUSEID", 80)
                .SetIsHidden();
            grdSource.View.AddTextBoxColumn("LOCATIONID", 80);
            grdSource.View.AddTextBoxColumn("CELLNAME", 100);

            grdSource.View.PopulateColumns();
        }

        private void InitializeTarget()
        {
            grdTarget.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdTarget.GridButtonItem = GridButtonItem.None;
            grdTarget.View.SetSortOrder("CONSUMABLELOTID");
            grdTarget.View.SetAutoFillColumn("QTY");

            grdTarget.View.AddTextBoxColumn("CONSUMABLELOTID", 80)
                .SetIsReadOnly();
            grdTarget.View.AddTextBoxColumn("INDATE", 80)
                .SetIsHidden();
            grdTarget.View.AddSpinEditColumn("LOTQTY", 50)
                .SetIsReadOnly();
            grdTarget.View.AddSpinEditColumn("DELIVERYQTY", 50)
                .SetDefault(0);
            grdTarget.View.AddTextBoxColumn("WAREHOUSEID", 80)
                .SetIsHidden();
            grdTarget.View.AddTextBoxColumn("LOCATIONID", 80)
                .SetIsHidden();
            grdTarget.View.AddTextBoxColumn("CELLNAME", 100)
                .SetIsHidden();

            grdTarget.View.PopulateColumns();
        }

        #endregion

        #region Event

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        public void InitializeEvent()
        {
            this.Load += MaterialOutPopup_Load;
            this.lblLotNo.Editor.KeyDown += LblLotNo_KeyDown;
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.ucDataLeftRightBtnCtrl.buttonClick += UcDataLeftRightBtnCtrl_buttonClick;
        }

        /// <summary>
        /// Form Road시 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaterialOutPopup_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            lblReqDepartment.Editor.EditValue = CurrentDataRow["REQDEPARTMENTID"].ToString();
            lblReqNo.Editor.EditValue = CurrentDataRow["REQNO"].ToString();
            lblWareHouseId.Editor.EditValue = CurrentDataRow["WAREHOUSEID"].ToString();
            lblItemId.Editor.EditValue = CurrentDataRow["ITEMID"].ToString();
            lblItemName.Editor.EditValue = CurrentDataRow["ITEMName"].ToString();
            lblReqQty.Editor.EditValue = CurrentDataRow["REQQTY"].ToString();

            lblReqDepartment.Editor.ReadOnly = true;
            lblReqNo.Editor.ReadOnly = true;
            lblWareHouseId.Editor.ReadOnly = true;
            lblItemId.Editor.ReadOnly = true;
            lblItemName.Editor.ReadOnly = true;
            lblReqQty.Editor.ReadOnly = true;

            InitializeSource();
            InitializeTarget();

            ucDataLeftRightBtnCtrl.SourceGrid = this.grdSource;
            ucDataLeftRightBtnCtrl.TargetGrid = this.grdTarget;

            LoadData();
        }

        private void LblLotNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;


            string sLotId = lblLotNo.Editor.Text;
            grdSource.View.CheckRow(grdSource.View.LocateByValue("CONSUMABLELOTID", sLotId), true);
            SetDataMove(grdSource, grdTarget);

            this.lblLotNo.Editor.EditValue = null;
            this.lblLotNo.Editor.Text = "";         
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowWaitArea();
                btnSave.Focus();
                btnSave.Enabled = false;

                if(ValidationCheck())
                {
                    DataTable dtTarget = grdTarget.DataSource as DataTable;
                    dtTarget.Columns.Add("RECEIVEWAREHOUSEID", typeof(string));
                    dtTarget.Columns.Add("CONSUMABLEDEFID", typeof(string));
                    dtTarget.Columns.Add("REQNO", typeof(string));

                    foreach(DataRow row in dtTarget.Rows)
                    {
                        row["RECEIVEWAREHOUSEID"] = CurrentDataRow["WAREHOUSEID"];
                        row["CONSUMABLEDEFID"] = this.lblItemId.Editor.Text;
                        row["REQNO"] = CurrentDataRow["REQNO"];
                    }

                    ExecuteRule("DeliveryMaterial", dtTarget);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    ShowMessage("NotEnough");
                }
            }
            catch(Exception ex)
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

        private void UcDataLeftRightBtnCtrl_buttonClick(object sender, EventArgs e)
        {
            if (this.ucDataLeftRightBtnCtrl.ButtonState.Equals("Right"))
            {
                //if (!EnoughValidationCheck())
                //{
                //    grdSource.View.CheckedAll(false);
                //    ShowMessage("IsTooMuch");
                //}
            }
        }

        #endregion

        #region Private Function

        private void LoadData()
        {
            string sItemId = this.lblItemId.Editor.Text;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_CONSUMABLEDEFID", sItemId);
            param.Add("P_WAREHOUSEID", "WH-001");
            param.Add("P_CONSUMABLESTATE", "Complete");

            if (string.IsNullOrEmpty(sItemId))
            {
                ShowMessage("NoSelectData");
            }

            grdSource.DataSource = SqlExecuter.Query("GetMaterialLotByItemId", "00001", param);
        }

        private void SetDataMove(SmartBandedGrid sourceGrid, SmartBandedGrid targetGrid)
        {
            List<DataRowView> listAddRows = new List<DataRowView>();

            DataTable sourceData = (DataTable)sourceGrid.DataSource;
            DataTable targetData = (DataTable)targetGrid.DataSource;

            targetData = SetInitDataTable(sourceData);

            if (targetGrid.DataSource == null) targetGrid.DataSource = targetData;

            // Check Checked Data Row
            for (int i = sourceGrid.View.RowCount - 1; i >= 0; i--)
            {
                if (!sourceGrid.View.IsRowChecked(i))
                    continue;

                DataRowView row = sourceGrid.View.GetRow(i) as DataRowView;

                listAddRows.Add(row);
            }

            // Loop For data copy
            foreach (DataRowView row in listAddRows)
            {
                DataRowView newRow = (targetGrid.View.DataSource as DataView).AddNew();
                newRow.BeginEdit();
                foreach (DataColumn dCol in targetData.Columns)
                {
                    if (!newRow.DataView.Table.Columns.Contains(dCol.ColumnName)) continue;

                    newRow.Row[dCol.ColumnName] = row.Row[dCol.ColumnName];
                }
                //newRow.Row.ItemArray = row.Row.ItemArray.Clone() as object[];

                row.Delete();
                newRow.EndEdit();
            }

            sourceData.AcceptChanges();
            targetData.AcceptChanges();
        }

        private DataTable SetInitDataTable(DataTable sourcedt)
        {
            DataTable dt = new DataTable();

            foreach (DataColumn col in sourcedt.Columns)
            {
                if (dt.Columns.Contains(col.ColumnName))
                    continue;

                dt.Columns.Add(col.ColumnName.ToString(), col.DataType);
            }

            return dt;
        }


        private bool ValidationCheck()
        {
            bool result = true;

            DataTable dtTarget = grdTarget.DataSource as DataTable;

            foreach(DataRow row in dtTarget.Rows)
            {
                if (row["DELIVERYQTY"] == null)
                    result = false;  
            }

            if(result == true)
            {
                int iReqQty = Convert.ToInt32(lblReqQty.Editor.Text);
                int iSumQty = dtTarget.AsEnumerable().Sum(x => Convert.ToInt32(x["DELIVERYQTY"]));

                if (iReqQty != iSumQty)
                    result = false;
            }

            return result;
        }

        #endregion
    }
}
