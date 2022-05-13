using Micube.Framework;
using Micube.Framework.Net;
using Micube.Framework.SmartControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Micube.SmartMES.Process
{
    public partial class DryerResult_Popup : SmartPopupBaseForm
    {
        public string EquipmentId { get; private set; }     // 설비 ID
        public string EquipmentName { get; private set; }   // 설비명

        public DryerResult_Popup(string equipmentId, string equipmentName)
        {
            InitializeComponent();
            InitializeGrid();
            InitializeEvent();
            this.EquipmentId = equipmentId;
            this.EquipmentName = equipmentName;
            txtEquipmentId.EditValue = equipmentId;
            txtEquipmentName.Text = equipmentName;
        }

        // 그리드 초기화
        private void InitializeGrid()
        {
            grdInputLot.GridButtonItem = GridButtonItem.Delete;
            grdInputLot.View.SetIsReadOnly();
            grdInputLot.View.AddTextBoxColumn("INPUTLOT", 110);         // 투입 LOT
            grdInputLot.View.AddTextBoxColumn("PRODUCTDEFID", 140);     // 품목 ID
            grdInputLot.View.AddTextBoxColumn("PRODUCTDEFNAME", 250);   // 품목명
            grdInputLot.View.AddTextBoxColumn("MODEL", 100);            // 기종
            grdInputLot.View.AddSpinEditColumn("QTY", 90);              // 수량
            grdInputLot.View.PopulateColumns();
        }

        private void InitializeEvent()
        {
            this.Load += DryResult_Popup_Load;
            txtInputLot.Editor.KeyDown += TxtInputLot_KeyDown;
            btnSave.Click += BtnSave_Click;
            btnClose.Click += BtnClose_Click;
        }

        private void DryResult_Popup_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtInputLot;
        }

        // 투입LOT 입력 시 그리드에 추가
        private void TxtInputLot_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string lotId = txtInputLot.Editor.Text.Trim();
                txtInputLot.Editor.Text = string.Empty;
                AddLot(lotId);
            }
        }

        // 투입LOT 그리드에 추가
        private void AddLot(string lotId)
        {
            var param = new Dictionary<string, object>()
            {
                { "CONSUMABLELOTID", lotId }
            };
            DataTable result = SqlExecuter.Query("GetConsumableLotForDry", "00001", param);
            if(result.Rows.Count == 0)
            {
                // LOT을 찾을 수 없습니다. {0}
                throw MessageException.Create("LotIsNotExists", string.Format("LotId={0}", lotId));
            }
            DataTable dt = grdInputLot.DataSource as DataTable;
            DataRow newRow = dt.NewRow();
            newRow["INPUTLOT"] = result.Rows[0]["INPUTLOT"];
            newRow["PRODUCTDEFID"] = result.Rows[0]["PRODUCTDEFID"];
            newRow["PRODUCTDEFNAME"] = result.Rows[0]["PRODUCTDEFNAME"];
            newRow["MODEL"] = result.Rows[0]["MODEL"];
            newRow["QTY"] = result.Rows[0]["QTY"];
            dt.Rows.Add(newRow);
        }

        // 건조 작업시작 룰 호출
        private void BtnSave_Click(object sender, EventArgs e)
        {
            MessageWorker messageWorker = new MessageWorker("NonOrderTrackInDryer");
            messageWorker.SetBody(new MessageBody()
            {
                { "equipmentid", this.EquipmentId },
                { "list", grdInputLot.DataSource as DataTable }
            });
            messageWorker.Execute();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 닫기
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
