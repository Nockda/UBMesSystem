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

namespace Micube.SmartMES.Equipment
{
    public partial class EquipOperationRate : SmartConditionBaseForm
    {
        public EquipOperationRate()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeGrid();

        }

        private void InitializeGrid()
        { 
            grdResult.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdResult.View.SetSortOrder("설비그룹");
            grdResult.View.AddTextBoxColumn("설비그룹", 150)
                            .SetValidationKeyColumn();

            grdResult.View.AddTextBoxColumn("설비명", 150);
            grdResult.View.AddTextBoxColumn("가동률", 150);
            grdResult.View.AddTextBoxColumn("유휴율", 150);
            grdResult.View.AddTextBoxColumn("부하시간", 150);
            grdResult.View.AddTextBoxColumn("가동시간", 150);
            grdResult.View.AddTextBoxColumn("작업준비", 150);
            grdResult.View.AddTextBoxColumn("대기시간", 150);

            grdResult.View.PopulateColumns();


        }

        private void smartPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
