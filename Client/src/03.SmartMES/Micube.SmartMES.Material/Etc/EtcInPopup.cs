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
    public partial class EtcInPopup : SmartPopupBaseForm
    {
        private string _ItemDefType { get; set; }

        public EtcInPopup()
        {
            InitializeComponent();
            InitializeEvent();
        }

        private void InitializeItemId()
        {
            ConditionItemSelectPopup itemPopup = new ConditionItemSelectPopup();

            itemPopup.SetPopupLayoutForm(800, 800, FormBorderStyle.FixedToolWindow);
            itemPopup.SetPopupLayout("SELECTPRODUCTDEFID", PopupButtonStyles.Ok_Cancel, true, false);
            itemPopup.Id = "PRODUCTDEFID";
            itemPopup.LabelText = "PRODUCTDEFID";
            itemPopup.SearchQuery = new SqlQuery("GetAllItemDefinitionListForEtc", "00001", $"PLANTID={UserInfo.Current.Plant}", $"LANGUAGETYPE={ UserInfo.Current.LanguageType }");

            itemPopup.IsMultiGrid = false;
            itemPopup.ValueFieldName = "PRODUCTDEFID";
            itemPopup.DisplayFieldName = "PRODUCTDEFID";

            itemPopup.LanguageKey = "PRODUCTDEFID";

            itemPopup.Conditions.AddTextBox("TXTPRODUCTDEFNAME");
            itemPopup.Conditions.AddComboBox("P_PRODUCTDEFTYPE", new SqlQuery("GetCodeList", "00001", $"CODECLASSID=ItemDefTypeForEtc", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"), "CODENAME", "CODEID")
                .SetDefault("Material")
                .SetLabel("PRODUCTDEFTYPE");

            itemPopup.GridColumns.AddTextBoxColumn("PRODUCTDEFID", 100)
                .SetIsReadOnly();
            itemPopup.GridColumns.AddTextBoxColumn("PRODUCTDEFNAME", 120)
                .SetIsReadOnly();
            itemPopup.GridColumns.AddComboBoxColumn("PRODUCTDEFTYPE", 90, new SqlQuery("GetCodeList", "00001", "CODECLASSID=ItemDefType", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetIsReadOnly();
            itemPopup.GridColumns.AddComboBoxColumn("UNIT", 90, new SqlQuery("GetUnitList", "00001"))
                .SetIsReadOnly();

            lblItemId.Editor.SelectPopupCondition = itemPopup;

            itemPopup.SetPopupApplySelection((selectedRows, dataGridRows) =>
            {
                List<DataRow> list = selectedRows.ToList<DataRow>();

                if (list.Count == 0) return;

                this.lblItemName.EditValue = list[0]["PRODUCTDEFNAME"];
                _ItemDefType = list[0]["PRODUCTDEFTYPE"].ToString();
            });

        }

        private void InitializeWarehouseId()
        {
            lblWarehouseId.Editor.ComboBoxColumnShowType = ComboBoxColumnShowType.DisplayMemberOnly;
            lblWarehouseId.Editor.ValueMember = "CODEID";
            lblWarehouseId.Editor.DisplayMember = "CODENAME";

            lblWarehouseId.Editor.DataSource = SqlExecuter.Query("GetComboWarehouse", "00001");
            lblWarehouseId.Editor.ShowHeader = false;
        }

        private void LblWarehouseId_TextChanged(object sender, EventArgs e)
        {
            string sWarehouseId = lblWarehouseId.GetValue().ToString();
            var sItemId = lblItemId.GetValue();

            lblLocationId.Editor.ComboBoxColumnShowType = ComboBoxColumnShowType.DisplayMemberOnly;
            lblLocationId.Editor.ValueMember = "LOCATIONID";
            lblLocationId.Editor.DisplayMember = "CELLNAME";

            DataTable dtTemp = SqlExecuter.Query("GetCellId", "00001", new Dictionary<string, object>() { { "P_WAREHOUSEID", sWarehouseId } });

            lblLocationId.Editor.DataSource = dtTemp;
            lblLocationId.Editor.ShowHeader = false;

            if(sItemId != null)
            {
                DataRow[] arrRows = dtTemp.Select("ITEMID = '" + sItemId + "'");
                if (arrRows.Length > 0)
                {
                    lblLocationId.Editor.EditValue = arrRows[0][0];
                }
            }
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
            this.lblItemId.Editor.TextChanged += LblItemId_TextChanged;
        }

        /// <summary>
        /// Form Road시 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EtcInPopup_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            lblItemName.Editor.ReadOnly = true;

            //InitializeReasonId();
            InitializeItemId();
            InitializeWarehouseId();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowWaitArea();
                btnSave.Focus();
                btnSave.Enabled = false;

                if(ValidateContent())
                {
                    if(ShowMessage(MessageBoxButtons.YesNo, "InfoSave") == DialogResult.Yes)
                    {
                        MessageWorker worker = new MessageWorker("CreateConsumableLotByEtc");
                        worker.SetBody(new MessageBody()
                        {
                            {"inouttype", lblType.GetValue() }
                            ,{"consumabledefid", lblItemId.Editor.EditValue}
                            ,{"warehouseid", lblWarehouseId.GetValue()}
                            ,{"locationid", lblLocationId.Editor.GetDataValue()}
                            ,{"consumablestate", "Available"}
                            ,{"createdqty", lblQty.GetValue()}
                            ,{"description", lblDescription.EditValue}
                            ,{"consumabletype", _ItemDefType }
                        }); ;

                        var saveResult = worker.Execute<DataTable>();
                        DataTable resultData = saveResult.GetResultSet();

                        ShowMessage("SuccessSave");

                        if (MSGBox.Show(MessageBoxType.Question, "NewLotByEtcIn", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            string lotId = resultData.Rows[0]["LOTID"].ToString();
                            if(_ItemDefType == "Material")
                            {
                                CommonFunction.PrintMaterialLabel(lotId);
                            }
                            else
                            {
                                CommonFunction.PrintLotLabel(lotId);
                            }
                        }

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

        private void LblItemId_TextChanged(object sender, EventArgs e)
        {
            if(lblItemId.Editor.EditValue != null)
                InitializeReasonId();
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

            if (lblItemId.GetValue() == null || lblItemId.GetValue().Equals(""))
                result = false;

            if (lblWarehouseId.GetValue() == null || lblWarehouseId.GetValue().Equals(""))
                result = false;

            if (lblQty.GetValue() == null || lblQty.GetValue().Equals("") || Convert.ToInt32(lblQty.GetValue()) == 0)
                result = false;


            return result;
        }

        private void InitializeReasonId()
        {
            lblType.Editor.ComboBoxColumnShowType = ComboBoxColumnShowType.DisplayMemberOnly;
            lblType.Editor.ValueMember = "CODEID";
            lblType.Editor.DisplayMember = "CODENAME";

            if(_ItemDefType == "Material")
            {
                lblType.Editor.DataSource = SqlExecuter.Query("GetCodeList", "00001", new Dictionary<string, object>() { { "CODECLASSID", "EtcInTypeMate" }, { "LANGUAGETYPE", UserInfo.Current.LanguageType } });
            }
            else
            {
                lblType.Editor.DataSource = SqlExecuter.Query("GetCodeList", "00001", new Dictionary<string, object>() { { "CODECLASSID", "EtcInTypeProd" }, { "LANGUAGETYPE", UserInfo.Current.LanguageType } });
            }

            lblType.Editor.ShowHeader = false;
        }

        #endregion
    }
}
