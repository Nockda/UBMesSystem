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

namespace Micube.SmartMES.Material.Kanban
{
    public partial class AssemblyPop : SmartPopupBaseForm
    {
        public AssemblyPop()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {

            grdMaterialLot.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdMaterialLot.View.SetSortOrder("LOTNO");

            //LOT No
            grdMaterialLot.View.AddTextBoxColumn("LOTNO", 150)
                .SetTextAlignment(TextAlignment.Center)
                .SetValidationKeyColumn()
                .SetValidationIsRequired()
                .SetIsReadOnly();

            //자재명
            grdMaterialLot.View.AddTextBoxColumn("NAME", 200)
                .SetTextAlignment(TextAlignment.Left)
                .SetIsReadOnly();
            //수량
            grdMaterialLot.View.AddTextBoxColumn("QTY", 50)
                .SetTextAlignment(TextAlignment.Right)
                .SetIsReadOnly();

            grdMaterialLot.View.PopulateColumns();
        }

        private void btn_Search(object sender, EventArgs e)
        {
            var lot = this.txtLotCode.EditValue;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("P_LOT", lot);
            DataTable dtInfo = SqlExecuter.Query("SelectInputMaterList", "00001", param);
            grdMaterialLot.DataSource = dtInfo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
