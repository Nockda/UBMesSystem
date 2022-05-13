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
    public partial class EtcOutPopup : SmartPopupBaseForm
    {
        private string _ItemDefType { get; set; }

        public EtcOutPopup()
        {
            InitializeComponent();
            InitializeEvent();
        }

        private void InitializeReasonId()
        {
            lblType.Editor.ComboBoxColumnShowType = ComboBoxColumnShowType.DisplayMemberOnly;
            lblType.Editor.ValueMember = "CODEID";
            lblType.Editor.DisplayMember = "CODENAME";

            lblType.Editor.DataSource = SqlExecuter.Query("GetCodeList", "00001", new Dictionary<string, object>() { { "CODECLASSID", "EtcOutType" }, { "LANGUAGETYPE", UserInfo.Current.LanguageType } });
            lblType.Editor.ShowHeader = false;
        }

        private void InitializeLotId()
        {
            ConditionItemSelectPopup lotPopup = new ConditionItemSelectPopup();

            lotPopup.SetPopupLayoutForm(900, 600, FormBorderStyle.FixedToolWindow);
            lotPopup.SetPopupLayout("CONSUMABLELOTID", PopupButtonStyles.Ok_Cancel, true, false);
            lotPopup.Id = "CONSUMABLELOTID";
            lotPopup.LabelText = "CONSUMABLELOTID";
            lotPopup.SearchQuery = new SqlQuery("GetMaterialEtcOutList", "00001", $"LANGUAGETYPE={ UserInfo.Current.LanguageType }");

            lotPopup.IsMultiGrid = false;
            lotPopup.ValueFieldName = "CONSUMABLELOTID";
            lotPopup.DisplayFieldName = "CONSUMABLELOTID";

            lotPopup.LanguageKey = "CONSUMABLELOTID";

            lotPopup.Conditions.AddTextBox("P_CONSUMABLELOTID")
                .SetLabel("CONSUMABLELOTID");
            lotPopup.Conditions.AddTextBox("P_CONSUMABLEDEFID")
                .SetLabel("ITEMID");
            lotPopup.Conditions.AddTextBox("P_CONSUMABLEDEFNAME")
                .SetLabel("ITEMNAME");

            lotPopup.GridColumns.AddTextBoxColumn("CONSUMABLELOTID", 100)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            lotPopup.GridColumns.AddTextBoxColumn("CONSUMABLEDEFID", 100)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            lotPopup.GridColumns.AddTextBoxColumn("CONSUMABLEDEFNAME", 120)
                .SetIsReadOnly();
            lotPopup.GridColumns.AddTextBoxColumn("STANDARD", 120)
                .SetIsReadOnly();
            lotPopup.GridColumns.AddTextBoxColumn("CONSUMABLELOTQTY", 80)
                .SetIsReadOnly();
            lotPopup.GridColumns.AddComboBoxColumn("UNIT", 90, new SqlQuery("GetUnitList", "00001"))
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            lotPopup.GridColumns.AddTextBoxColumn("WAREHOUSEID", 50)
                .SetIsHidden();
            lotPopup.GridColumns.AddTextBoxColumn("LOCATIONID", 50)
                .SetIsHidden();
            lotPopup.GridColumns.AddComboBoxColumn("CONSUMABLETYPE", 90, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ItemDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            lblLotId.Editor.SelectPopupCondition = lotPopup;

            lotPopup.SetPopupApplySelection((selectedRows, dataGridRows) =>
            {
                List<DataRow> list = selectedRows.ToList<DataRow>();

                if (list.Count == 0) return;

                this.lblItemId.EditValue = list[0]["CONSUMABLEDEFID"];
                this.lblItemName.EditValue = list[0]["CONSUMABLEDEFNAME"];
                this.lblQty.EditValue = list[0]["CONSUMABLELOTQTY"];
                this.lblWarehouseId.Editor.EditValue = list[0]["WAREHOUSEID"];
                this.lblLocationId.Editor.EditValue = list[0]["LOCATIONID"];
                this.txtLotQty.EditValue = list[0]["CONSUMABLELOTQTY"];
                _ItemDefType = list[0]["CONSUMABLETYPE"].ToString();
            });
        }

        private void InitializeWarehouseId()
        {
            lblWarehouseId.Editor.ComboBoxColumnShowType = ComboBoxColumnShowType.DisplayMemberOnly;
            lblWarehouseId.Editor.ValueMember = "CODEID";
            lblWarehouseId.Editor.DisplayMember = "CODENAME";
          

            DataTable dt = SqlExecuter.Query("GetComboWarehouse", "00001");
            //for (int i = dt.Rows.Count - 1; i >= 0; i--)
            //{
            //    DataRow dr = dt.Rows[i];
            //    if (dr["WAREHOUSETYPE"].ToString() == "0001")
            //        dr.Delete();
            //}
            //dt.AcceptChanges();

            lblWarehouseId.Editor.DataSource = dt;
            lblWarehouseId.Editor.ShowHeader = false;
        }

        #region Event

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        public void InitializeEvent()
        {
            this.Load += EtcInPopup_Load;
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.lblWarehouseId.Editor.TextChanged += LblWarehouseId_TextChanged;
            this.lblQty.Editor.ValueChanged += LblQty_ValueChanged;
        }

        /// <summary>
        /// Form Load시 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EtcInPopup_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            lblItemId.Editor.ReadOnly = true;
            lblItemName.Editor.ReadOnly = true;
            lblWarehouseId.Editor.ReadOnly = true;
            lblLocationId.Editor.ReadOnly = true;
            txtLotQty.ReadOnly = true;

            InitializeReasonId();
            InitializeLotId();
            InitializeWarehouseId();
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
                        MessageWorker worker = new MessageWorker("DeliveryConsumableLotByEtc");
                        worker.SetBody(new MessageBody()
                        {
                            {"inouttype", lblType.GetValue() }
                            ,{"consumablelotid", lblLotId.Editor.EditValue}
                            ,{"consumabledefid", lblItemId.Editor.EditValue}
                            ,{"warehouseid", lblWarehouseId.GetValue()}
                            ,{"locationid", lblLocationId.Editor.GetDataValue()}
                            ,{"consumablestate", "Available"}
                            ,{"consumableqty", txtLotQty.EditValue}
                            ,{"createdqty", lblQty.GetValue()}
                            ,{"description", lblDescription.EditValue}
                            ,{"consumabletype", _ItemDefType}
                            ,{"userid", UserInfo.Current.Id}
                        });

                        worker.Execute();

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

        private void LblWarehouseId_TextChanged(object sender, EventArgs e)
        {
            string sWarehouseId = lblWarehouseId.GetValue().ToString();

            lblLocationId.Editor.ComboBoxColumnShowType = ComboBoxColumnShowType.DisplayMemberOnly;
            lblLocationId.Editor.ValueMember = "LOCATIONID";
            lblLocationId.Editor.DisplayMember = "CELLNAME";

            lblLocationId.Editor.DataSource = SqlExecuter.Query("GetCellId", "00001", new Dictionary<string, object>() { { "P_WAREHOUSEID", sWarehouseId } });
            lblLocationId.Editor.ShowHeader = false;
        }


        private void LblQty_ValueChanged(object sender, EventArgs e)
        {
            decimal dQty = Convert.ToDecimal(lblQty.GetValue());
            decimal dTotal = Convert.ToDecimal(txtLotQty.EditValue);

            if(dQty > dTotal)
            {
                this.lblQty.Editor.EditValue = dTotal;
                return;
            }

            if(dQty < 0)
            {
                this.lblQty.Editor.EditValue = 0;
                return;
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

            if (lblLotId.GetValue() == null || lblLotId.GetValue().Equals(""))
                result = false;

            if (lblWarehouseId.GetValue() == null || lblWarehouseId.GetValue().Equals(""))
                result = false;

            if (lblQty.GetValue() == null || lblQty.GetValue().Equals("") || Convert.ToInt32(lblQty.GetValue()) <= 0)
                result = false;


            return result;
        }

        #endregion
    }
}
