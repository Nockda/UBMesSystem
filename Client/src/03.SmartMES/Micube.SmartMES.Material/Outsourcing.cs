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
    public partial class Outsourcing : SmartConditionBaseForm
    {
        public Outsourcing()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeListPlan();
            InitializeListInput();

        }

        private void InitializeListInput()
        {
            grdInput.GridButtonItem = GridButtonItem.All;
            grdInput.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdInput.View.SetIsReadOnly();

            grdInput.View.AddTextBoxColumn("입고일", 150);
            grdInput.View.AddTextBoxColumn("입고수량", 150);
            grdInput.View.AddTextBoxColumn("불량수량", 150);
            grdInput.View.AddTextBoxColumn("반입수량", 150);
            grdInput.View.AddTextBoxColumn("미입고수량", 150);
            grdInput.View.AddTextBoxColumn("반입", 150);
            grdInput.View.AddTextBoxColumn("비고", 150);
            grdInput.View.AddTextBoxColumn("담당자", 150);

            grdInput.View.PopulateColumns();
        }

        private void InitializeListPlan()
        {
            grdPlan.GridButtonItem = GridButtonItem.All;
            grdPlan.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdPlan.View.SetIsReadOnly();

            grdPlan.View.AddTextBoxColumn("입고계획번호", 150);
            grdPlan.View.AddTextBoxColumn("입고예정일", 150);
            grdPlan.View.AddTextBoxColumn("거래처", 150);
            grdPlan.View.AddTextBoxColumn("규격", 150);
            grdPlan.View.AddTextBoxColumn("품목", 150);
            grdPlan.View.AddTextBoxColumn("예정입고수량", 150);
            grdPlan.View.AddTextBoxColumn("단위", 150);
            grdPlan.View.AddTextBoxColumn("방향", 150);
            grdPlan.View.AddTextBoxColumn("종결", 150);
            grdPlan.View.AddTextBoxColumn("외주", 150);
            grdPlan.View.AddTextBoxColumn("입고계획담당자", 150);

            grdPlan.View.PopulateColumns();
        }

        private void smartBandedGrid1_Load(object sender, EventArgs e)
        {

        }
    }
}
