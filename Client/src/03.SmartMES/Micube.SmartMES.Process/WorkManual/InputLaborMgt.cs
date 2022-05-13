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
    public partial class InputLaborMgt : SmartConditionBaseForm
    {
        public InputLaborMgt()
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
            grd.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grd.View.SetSortOrder("일차");
            grd.View.AddTextBoxColumn("일차", 150)
                            .SetValidationKeyColumn();

            grd.View.AddTextBoxColumn("총인원", 80);
            grd.View.PopulateColumns();
        }
    }
}
