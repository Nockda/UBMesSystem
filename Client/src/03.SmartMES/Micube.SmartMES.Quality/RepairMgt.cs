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

namespace Micube.SmartMES.Quality
{
    public partial class RepairMgt : SmartConditionBaseForm
    {
        public RepairMgt()
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

            grdList.GridButtonItem = GridButtonItem.All;
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdList.View.SetSortOrder("구분");
            grdList.View.AddTextBoxColumn("구분", 150)
                            .SetValidationKeyColumn()
                            .SetValidationIsRequired();

            grdList.View.AddTextBoxColumn("X-번", 200);
            grdList.View.AddTextBoxColumn("기종", 150);
            grdList.View.AddTextBoxColumn("S/N", 150);
            grdList.View.AddTextBoxColumn("유/무상", 100);
            grdList.View.AddTextBoxColumn("수리의뢰내용(간략히)", 300);
            grdList.View.AddTextBoxColumn("수리의뢰서 발행", 100);
            grdList.View.AddTextBoxColumn("수리진행", 150);
            grdList.View.AddTextBoxColumn("수리완료", 150);
            grdList.View.AddTextBoxColumn("수리보고서", 200);
            grdList.View.AddTextBoxColumn("출하일", 200);

            grdList.View.PopulateColumns();
        }
    }
}
