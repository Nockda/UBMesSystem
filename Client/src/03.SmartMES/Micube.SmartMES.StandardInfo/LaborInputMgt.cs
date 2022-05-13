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

namespace Micube.SmartMES.Process.WorkManual
{
    public partial class LaborInputMgt : SmartConditionBaseForm
    {
        public LaborInputMgt()
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

            grdLabor.GridButtonItem = GridButtonItem.All;
            grdLabor.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdLabor.View.SetIsReadOnly();

            grdLabor.View.AddTextBoxColumn("NO.", 80);
            grdLabor.View.AddTextBoxColumn("일차", 80);
            grdLabor.View.AddTextBoxColumn("총인원", 80);

            var gRouting1 = grdLabor.View.AddGroupColumn("라우팅1");
            gRouting1.AddTextBoxColumn("1", 100);
            gRouting1.AddTextBoxColumn("2", 100);

            var gRouting2 = grdLabor.View.AddGroupColumn("라우팅2");
            gRouting2.AddTextBoxColumn("1", 100);
            gRouting2.AddTextBoxColumn("2", 100);

            var gRouting3 = grdLabor.View.AddGroupColumn("라우팅3");
            gRouting2.AddTextBoxColumn("1", 100);
            gRouting2.AddTextBoxColumn("2", 100);
            gRouting2.AddTextBoxColumn("3", 100);

            grdLabor.View.PopulateColumns();
        }
    }
}
