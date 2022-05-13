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
    public partial class MaterialInByScanPopup : SmartPopupBaseForm, ISmartCustomPopup
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

        public MaterialInByScanPopup()
        {
            InitializeComponent();
            InitializeEvent();
        }


        #region Event

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        public void InitializeEvent()
        {
            this.Load += MaterialInByScanPopup_Load;
            //this.lblLotNo.Editor.KeyDown += LblLotNo_KeyDown;
            //this.btnSave.Click += BtnSave_Click;
            //this.btnCancel.Click += BtnCancel_Click;
            //this.ucDataLeftRightBtnCtrl.buttonClick += UcDataLeftRightBtnCtrl_buttonClick;
        }

        /// <summary>
        /// Form Road시 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaterialInByScanPopup_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            //lblReqDepartment.Editor.EditValue = CurrentDataRow["REQDEPARTMENTID"].ToString();
            //lblReqNo.Editor.EditValue = CurrentDataRow["REQNO"].ToString();
            //lblWareHouseId.Editor.EditValue = CurrentDataRow["WAREHOUSEID"].ToString();
            //lblItemId.Editor.EditValue = CurrentDataRow["ITEMID"].ToString();
            //lblItemName.Editor.EditValue = CurrentDataRow["ITEMName"].ToString();
            //lblReqQty.Editor.EditValue = CurrentDataRow["REQQTY"].ToString();

            //lblReqDepartment.Editor.ReadOnly = true;
            //lblReqNo.Editor.ReadOnly = true;
            //lblWareHouseId.Editor.ReadOnly = true;
            //lblItemId.Editor.ReadOnly = true;
            //lblItemName.Editor.ReadOnly = true;
            //lblReqQty.Editor.ReadOnly = true;

            //InitializeSource();
            //InitializeTarget();

            //ucDataLeftRightBtnCtrl.SourceGrid = this.grdSource;
            //ucDataLeftRightBtnCtrl.TargetGrid = this.grdTarget;

            //LoadData();
        }

        //private void LblLotNo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode != Keys.Enter) return;


        //    string sLotId = lblLotNo.Editor.Text;
        //    grdSource.View.CheckRow(grdSource.View.LocateByValue("CONSUMABLELOTID", sLotId), true);
        //    SetDataMove(grdSource, grdTarget);

        //    this.lblLotNo.Editor.SetValue(null);
        //    this.lblLotNo.Editor.Text = "";
        //}

        //private void BtnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.ShowWaitArea();
        //        btnSave.Focus();
        //        btnSave.Enabled = false;

        //        if (ValidationCheck())
        //        {
        //            DataTable dtTarget = grdTarget.DataSource as DataTable;
        //            dtTarget.Columns.Add("RECEIVEWAREHOUSEID", typeof(string));
        //            dtTarget.Columns.Add("CONSUMABLEDEFID", typeof(string));
        //            dtTarget.Columns.Add("REQNO", typeof(string));

        //            foreach (DataRow row in dtTarget.Rows)
        //            {
        //                row["RECEIVEWAREHOUSEID"] = CurrentDataRow["WAREHOUSEID"];
        //                row["CONSUMABLEDEFID"] = this.lblItemId.Editor.Text;
        //                row["REQNO"] = CurrentDataRow["REQNO"];
        //            }

        //            ExecuteRule("DeliveryMaterial", dtTarget);

        //            DialogResult = DialogResult.OK;
        //            Close();
        //        }
        //        else
        //        {
        //            ShowMessage("NotEnough");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ShowError(ex);
        //    }
        //    finally
        //    {
        //        this.CloseWaitArea();
        //        btnSave.Enabled = true;
        //    }
        //}

        //private void BtnCancel_Click(object sender, EventArgs e)
        //{
        //    DialogResult = DialogResult.Cancel;
        //    Close();
        //}

        //private void UcDataLeftRightBtnCtrl_buttonClick(object sender, EventArgs e)
        //{
        //    if (this.ucDataLeftRightBtnCtrl.ButtonState.Equals("Right"))
        //    {
        //        //if (!EnoughValidationCheck())
        //        //{
        //        //    grdSource.View.CheckedAll(false);
        //        //    ShowMessage("IsTooMuch");
        //        //}
        //    }
        //}

        #endregion
    }
}
