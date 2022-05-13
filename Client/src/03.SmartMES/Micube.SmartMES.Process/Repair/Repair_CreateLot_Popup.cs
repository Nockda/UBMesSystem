using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Micube.SmartMES.Process
{
    public partial class Repair_CreateLot_Popup : SmartPopupBaseForm
    {
        public string ProcessSegmentId { get; private set; }
        public string LotCreateRuleId { get; private set; }

        public Repair_CreateLot_Popup()
        {
            InitializeComponent();
            InitializeGrid();
            InitializeEvent();
        }

        private void InitializeGrid()
        {
            grdProcess.View.OptionsSelection.MultiSelect = false;
            grdProcess.View.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            grdProcess.View.CheckMarkSelection.ShowCheckBoxHeader = false;
            grdProcess.GridButtonItem = GridButtonItem.None;
            grdProcess.View.SetIsReadOnly();
            grdProcess.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdProcess.View.AddTextBoxColumn("PROCESSSEGMENTID", 90);       // 자재코드
            grdProcess.View.AddTextBoxColumn("PROCESSSEGMENTNAME", 140);    // 품번
            grdProcess.View.AddTextBoxColumn("LOTCREATERULEID", 150);       // 자재 LOT
            grdProcess.View.AddTextBoxColumn("LOTCREATERULENAME", 200);     // 자재명
            grdProcess.View.PopulateColumns();
        }

        private void InitializeEvent()
        {
            this.Load += Repair_CreateLot_Popup_Load;
            grdProcess.View.CheckStateChanged += View_CheckStateChanged;
            grdProcess.View.DoubleClick += View_DoubleClick;
            btnOK.Click += BtnOK_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void Repair_CreateLot_Popup_Load(object sender, EventArgs e)
        {
            var param = new Dictionary<string, object>()
            {
                { "LANGUAGETYPE", UserInfo.Current.LanguageType }
            };
            grdProcess.DataSource = SqlExecuter.Query("GetRenovationProcessList", "00001", param);
        }

        private void View_CheckStateChanged(object sender, EventArgs e)
        {
            grdProcess.View.CheckStateChanged -= View_CheckStateChanged;
            grdProcess.View.UncheckedAll();
            if (grdProcess.View.FocusedRowHandle >= 0)
            {
                grdProcess.View.CheckRow(grdProcess.View.FocusedRowHandle, true);
                DataTable checkedRows = grdProcess.View.GetCheckedRows();
                this.ProcessSegmentId = checkedRows.Rows[0]["PROCESSSEGMENTID"].ToString();
                this.LotCreateRuleId = checkedRows.Rows[0]["LOTCREATERULEID"].ToString();
            }
            grdProcess.View.CheckStateChanged += View_CheckStateChanged;
        }

        private void View_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                if (info.RowHandle >= 0)
                {
                    this.ProcessSegmentId = view.GetRowCellValue(info.RowHandle, "PROCESSSEGMENTID").ToString();
                    this.LotCreateRuleId = view.GetRowCellValue(info.RowHandle, "LOTCREATERULEID").ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
