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

namespace Micube.SmartMES.Material
{
    public partial class Forwarding : SmartConditionBaseForm
    {
        public Forwarding()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeGridPlan();
            InitializeGridForwarding();
        }

        private void InitializeGridForwarding()
        {
            grdOutput.GridButtonItem = GridButtonItem.All;
            grdOutput.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdOutput.View.SetIsReadOnly();

            grdOutput.View.AddTextBoxColumn("출고일", 150);
            grdOutput.View.AddTextBoxColumn("출고수량", 150);
            grdOutput.View.AddTextBoxColumn("불량수량", 150);
            grdOutput.View.AddTextBoxColumn("반입수량", 150);
            grdOutput.View.AddTextBoxColumn("미출고수량", 150);
            grdOutput.View.AddTextBoxColumn("반입", 150);
            grdOutput.View.AddTextBoxColumn("비고", 150);
            grdOutput.View.AddTextBoxColumn("담당자", 150);

            grdOutput.View.PopulateColumns();
        }

        private void InitializeGridPlan()
        {
            grdPlan.GridButtonItem = GridButtonItem.All;
            grdPlan.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdPlan.View.SetIsReadOnly();

            grdPlan.View.AddTextBoxColumn("출고계획번호", 150);
            grdPlan.View.AddTextBoxColumn("출고예정일", 150);
            grdPlan.View.AddTextBoxColumn("거래처", 150);
            grdPlan.View.AddTextBoxColumn("규격", 150);
            grdPlan.View.AddTextBoxColumn("품목", 150);
            grdPlan.View.AddTextBoxColumn("예정출고수량", 150);
            grdPlan.View.AddTextBoxColumn("단위", 150);
            grdPlan.View.AddTextBoxColumn("방향", 150);
            grdPlan.View.AddTextBoxColumn("종결", 150);
            grdPlan.View.AddTextBoxColumn("외주", 150);
            grdPlan.View.AddTextBoxColumn("출고계획담당자", 150);

            grdPlan.View.PopulateColumns();
        }
    }
}
