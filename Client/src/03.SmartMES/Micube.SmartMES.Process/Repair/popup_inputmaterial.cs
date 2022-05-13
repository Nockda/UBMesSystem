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

namespace Micube.SmartMES.Process
{
    public partial class popup_inputmaterial : SmartPopupBaseForm
    {
        public string LotId { get; private set; }

        public popup_inputmaterial(string lotId)
        {
            InitializeComponent();
            InitializeGrid();
            InitializeEvent();
            this.LotId = lotId;
        }

        private void InitializeGrid()
        {
            grdConsumableLots.GridButtonItem = GridButtonItem.None;
            grdConsumableLots.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdConsumableLots.View.AddTextBoxColumn("CONSUMABLEDEFID", 90).SetIsReadOnly().SetIsHidden();     // 자재코드
            grdConsumableLots.View.AddTextBoxColumn("PARTNUMBER", 90).SetIsReadOnly();          // 품번
            grdConsumableLots.View.AddTextBoxColumn("CONSUMABLELOTID", 100).SetIsReadOnly();    // 자재 LOT
            grdConsumableLots.View.AddTextBoxColumn("CONSUMABLEDEFNAME", 180).SetIsReadOnly();  // 자재명
            grdConsumableLots.View.AddSpinEditColumn("CONSUMABLELOTQTY", 60)
                .SetLabel("STOCKQTY").SetIsReadOnly();                                          // 재고수량
            grdConsumableLots.View.AddSpinEditColumn("GOODQTY", 60).SetLabel("INPUTQTY");       // 투입수량
            grdConsumableLots.View.AddTextBoxColumn("UNIT", 70)
                .SetIsReadOnly().SetTextAlignment(TextAlignment.Center);                        // 단위
            grdConsumableLots.View.AddTextBoxColumn("COMMENT", 160);                            // 특이사항
            grdConsumableLots.View.AddSpinEditColumn("BADQTY").SetIsHidden();
            grdConsumableLots.View.AddTextBoxColumn("SERIALNO");
            grdConsumableLots.View.PopulateColumns();
        }

        private void InitializeEvent()
        {
            this.Load += Popup_inputmaterial_Load;
            txtConsumableLotId.Editor.KeyDown += TxtConsumableLotId_KeyDown;
            grdConsumableLots.View.CustomDrawCell += View_CustomDrawCell;
            btnSave.Click += BtnSave_Click;
            btnClose.Click += BtnClose_Click;
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddConsumableLot();
        }

        private void AddConsumableLot()
        {
            string consumableLotId = txtConsumableLotId.Text.Trim();
            txtConsumableLotId.Text = "";
            DataTable conLots = grdConsumableLots.DataSource as DataTable;
            // 중복투입 검사
            foreach (DataRow each in conLots.Rows)
            {
                if (each["CONSUMABLELOTID"].ToString() == consumableLotId)
                {
                    // 이미 투입된 자재입니다. {0}
                    throw MessageException.Create("ConsumableLotAlreadyInput", string.Format("ConsumableLotId={0}", consumableLotId));
                }
            }
            var param = new Dictionary<string, object>()
                {
                    { "CONSUMABLELOTID", consumableLotId }
                };
            DataTable result = SqlExecuter.Query("GetConsumableLot", "00001", param);
            if (result.Rows.Count == 0)
            {
                // 시스템에 등록되지 않은 자재입니다. {0}
                throw MessageException.Create("ConsumableLotNotFound", consumableLotId);
            }
            DataRow conLot = result.Rows[0];

            DataRow newRow = conLots.NewRow();
            newRow["CONSUMABLEDEFID"] = conLot["CONSUMABLEDEFID"];
            newRow["PARTNUMBER"] = conLot["PARTNUMBER"];
            newRow["CONSUMABLELOTID"] = consumableLotId;
            newRow["CONSUMABLEDEFNAME"] = conLot["CONSUMABLEDEFNAME"];
            newRow["CONSUMABLELOTQTY"] = conLot["CONSUMABLELOTQTY"];
            newRow["GOODQTY"] = 0;
            newRow["UNIT"] = conLot["UNIT"];
            newRow["COMMENT"] = "";
            newRow["BADQTY"] = 0;
            newRow["SERIALNO"] = "";
            conLots.Rows.Add(newRow);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            grdConsumableLots.View.RemoveRow(grdConsumableLots.View.GetCheckedRowsHandle()); 
        }

        private void Popup_inputmaterial_Load(object sender, EventArgs e)
        {
            RefreshConsumableLotGrid();
            this.ActiveControl = txtConsumableLotId;
        }

        private void RefreshConsumableLotGrid()
        {
            var param = new Dictionary<string, object>()
            {
                { "LOTID", this.LotId }
            };
            grdConsumableLots.DataSource = SqlExecuter.Query("SelectRepairMaterial", "00001", param);
        }

        private void TxtConsumableLotId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddConsumableLot();
            }
        }

        private void View_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "GOODQTY" || e.Column.FieldName == "COMMENT")
            {
                e.Appearance.BackColor = Color.LightYellow;
                e.Appearance.ForeColor = Color.Black;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            grdConsumableLots.View.PostEditor();
            grdConsumableLots.View.UpdateCurrentRow();
            MessageWorker messageWorker = new MessageWorker("InputMaterial");
            messageWorker.SetBody(new MessageBody()
            {
                { "lotid", this.LotId }
                , { "isoverwrite", "Y" }
                , { "isallowinputuntracked", "Y" }
                , { "materials", grdConsumableLots.DataSource as DataTable }
            });
            messageWorker.Execute();
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DataTable dt = grdConsumableLots.DataSource as DataTable;
            if(dt != null && dt.Rows.Count > 0)
            {
                // 정말 종료하시겠습니까? 저장하지 않은 데이터는 사라집니다.
                if (MSGBox.Show(MessageBoxType.Question, "CloseWithoutSave", MessageBoxButtons.YesNo
                    , string.Format("ConsumableDefId={0}", dt.Rows[0]["CONSUMABLEDEFID"].ToString())) != DialogResult.Yes)
                {
                    return;
                }
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
