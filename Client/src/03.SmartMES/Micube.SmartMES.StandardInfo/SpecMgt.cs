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

namespace Micube.SmartMES.StandardInfo
{
    public partial class SpecMgt : SmartConditionBaseForm
    {
        public SpecMgt()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {

            grdSpec.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdSpec.View.SetSortOrder("생산품목");
            grdSpec.View.AddTextBoxColumn("생산품목", 150)
                            .SetValidationKeyColumn();

            grdSpec.View.AddTextBoxColumn("공정명", 150);
            grdSpec.View.AddTextBoxColumn("세부공정", 200);
            grdSpec.View.AddTextBoxColumn("작업순서", 150);
            grdSpec.View.AddTextBoxColumn("입력항목", 150);
            grdSpec.View.AddTextBoxColumn("단위", 150);
            grdSpec.View.AddTextBoxColumn("스펙", 150);
            grdSpec.View.AddTextBoxColumn("기종", 150);

            grdSpec.View.PopulateColumns();


        }

        private void smartBandedGrid1_Load(object sender, EventArgs e)
        {

        }
    }
}
