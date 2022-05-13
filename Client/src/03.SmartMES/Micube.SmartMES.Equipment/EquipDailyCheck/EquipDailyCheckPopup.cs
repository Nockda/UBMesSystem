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

namespace Micube.SmartMES.Equipment
{
    public partial class EquipDailyCheckPopup : SmartPopupBaseForm, ISmartCustomPopup
    {
        #region Local Variables
        /// <summary>
        /// 팝업진입전 그리드의 Row
        /// </summary>
        public DataRow CurrentDataRow { get; set; }

        public DateTime _checkDate { get; set; }
        public string _equipmentCode { get; set; }

        private string _currentStatus;
        #endregion


        public EquipDailyCheckPopup()
        {
            InitializeComponent();
            InitializeEvent();

            this.lblCheckDate.Editor.ReadOnly = true;
        }

        #region 컨텐츠 영역 초기화
        private void InitializeListGrid()
        {
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CellSelect;
            grdList.GridButtonItem = GridButtonItem.None;
            grdList.View.OptionsView.AllowCellMerge = true;
            grdList.View.OptionsCustomization.AllowSort = false;

            grdList.View.AddTextBoxColumn("EQUIPCHECKID", 80)
                .SetIsHidden()
                .SetIsReadOnly()
                .SetValidationKeyColumn()
                .SetValidationIsRequired();
            grdList.View.AddComboBoxColumn("CHECKTYPE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=EquipmentCheckCatecory", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("EQUIPCHECKNAME", 200)
                .SetIsReadOnly();
            grdList.View.AddComboBoxColumn("CHECKCYCLE", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=EquipmentCheckCycle", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddSpinEditColumn("CHECKCOUNT", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("CHECKWAY", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=EquipmentCheckWay", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("RESULTWAY", 80, new SqlQuery("GetCodeList", "00001", "CODECLASSID=EquipmentResultWay", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddComboBoxColumn("RESULTTYPE01", 50, new SqlQuery("GetCodeList", "00001", "CODECLASSID=CheckSignCode", $"LANGUAGETYPE={UserInfo.Current.LanguageType}"))
                .SetLabel("RESULT")
                .SetEmptyItem("")
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddSpinEditColumn("RESULTTYPE02", 50)
                .SetDisplayFormat("#,###,##0.#0", MaskTypes.Numeric)
                .SetLabel("MEASUREVALUE")
                .SetDefault(0);
            grdList.View.AddTextBoxColumn("CREATOR", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("CREATEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("MODIFIER", 80)
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);
            grdList.View.AddTextBoxColumn("MODIFIEDTIME", 130)
                .SetDisplayFormat("yyyy-MM-dd HH;mm:ss")
                .SetIsReadOnly()
                .SetTextAlignment(TextAlignment.Center);

            grdList.View.PopulateColumns();
        }

        private void InitializeEquipmentCode()
        {
            lblEquipmentCode.Editor.ComboBoxColumnShowType = ComboBoxColumnShowType.Custom;
            lblEquipmentCode.Editor.SetVisibleColumns("CODEID", "CODENAME");
            lblEquipmentCode.Editor.SetVisibleColumnsWidth(100, 200);
            lblEquipmentCode.Editor.ValueMember = "CODEID";
            lblEquipmentCode.Editor.DisplayMember = "CODENAME";

            lblEquipmentCode.Editor.DataSource = SqlExecuter.Query("GetComboEquipment", "00001", new Dictionary<string, object>() { { "P_LANGUAGETYPE", UserInfo.Current.LanguageType } });
            lblEquipmentCode.Editor.ShowHeader = true;
            lblEquipmentCode.Editor.UseEmptyItem = true;
        }

        #endregion


        #region Event

        /// <summary>        
        /// 이벤트 초기화
        /// </summary>
        public void InitializeEvent()
        {
            this.Load += EtcInPopup_Load;
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;

            this.lblCheckDate.Editor.EditValueChanged += LblCheckDate_EditValueChanged;

            grdList.View.CellMerge += View_CellMerge;
            this.grdList.View.ShowingEditor += View_ShowingEditor;
        }

        



        /// <summary>
        /// Form Road시 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EtcInPopup_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            lblEquipmentCode.Editor.ReadOnly = true;
            _checkDate = DateTime.Now;

            InitializeListGrid();
            InitializeEquipmentCode();

            LoadData();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowWaitArea();
                btnSave.Focus();
                btnSave.Enabled = false;

                DataTable changed = new DataTable();

                if(_currentStatus == "added")
                {
                    changed = grdList.DataSource as DataTable;
                    changed.Columns.Add("_STATE_", typeof(string));
                    changed.Columns.Add("CHECKDATE", typeof(string));
                    changed.Columns.Add("EQUIPMENTID", typeof(string));
                }
                else if(_currentStatus == "modified")
                {
                    changed = grdList.GetChangedRows();
                    changed.Columns.Add("CHECKDATE", typeof(string));
                    changed.Columns.Add("EQUIPMENTID", typeof(string));
                }

                for (int rowIndex = 0; rowIndex < changed.Rows.Count; rowIndex++)
                {
                    changed.Rows[rowIndex]["CHECKDATE"] = _checkDate.ToString("yyyy-MM-dd");
                    changed.Rows[rowIndex]["EQUIPMENTID"] = _equipmentCode;
                    changed.Rows[rowIndex]["_STATE_"] = _currentStatus;
                }

                ExecuteRule("SaveEquipCheckData", changed);

                ShowMessage("SuccessSave");

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

        private void LblCheckDate_EditValueChanged(object sender, EventArgs e)
        {
            _checkDate = Convert.ToDateTime(lblCheckDate.GetValue());
            LoadData();
        }

        private void View_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null) return;

            if (e.Column.FieldName == "CHECKTYPE")
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

        private void View_ShowingEditor(object sender, CancelEventArgs e)
        {
            string focusColumn = grdList.View.FocusedColumn.FieldName;

            if (grdList.View.GetFocusedRowCellValue("RESULTWAY").ToString().Equals("ER-001"))
            {
                if(focusColumn.Equals("RESULTTYPE02"))
                {
                    e.Cancel = true;
                }
            }
            else
            {
                if (focusColumn.Equals("RESULTTYPE01"))
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region Private Function
        private void LoadData()
        {
            lblCheckDate.Editor.EditValue = _checkDate;
            lblEquipmentCode.Editor.EditValue = _equipmentCode;
            lblEquipmentCode.Editor.ReadOnly = true;

            DataTable dt = new DataTable();

            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_DATETIME", _checkDate);
            param.Add("P_EQUIPCODE", _equipmentCode);

            DataTable dtInfo = SqlExecuter.Query("GetEquipCheckDataReal", "00001", param);

            _currentStatus = "modified";

            if (dtInfo.Rows.Count < 1)
            {
                dtInfo = SqlExecuter.Query("GetEquipCheckDataStandard", "00001", param);

                if (dtInfo.Rows.Count < 1)
                {
                    ShowMessage("NoSelectData");
                }
                _currentStatus = "added";
            }

            grdList.DataSource = dtInfo;
        }
        #endregion
    }
}
