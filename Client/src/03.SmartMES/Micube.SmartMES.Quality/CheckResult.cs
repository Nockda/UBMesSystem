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
    public partial class CheckResult : SmartConditionBaseForm
    {
        public CheckResult()
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
            
            grdResult.View.SetSortOrder("NO");
            grdResult.View.AddTextBoxColumn("NO", 150);

            grdResult.View.AddTextBoxColumn("1단 현합치수",150);
            grdResult.View.AddTextBoxColumn("담당자",150);
            grdResult.View.AddTextBoxColumn("날짜",150);
            grdResult.View.AddTextBoxColumn("Ra",150);
            grdResult.View.AddTextBoxColumn("담당자",150);
            grdResult.View.AddTextBoxColumn("날짜",150);
            grdResult.View.AddTextBoxColumn("2단 현합치수",150);
            grdResult.View.AddTextBoxColumn("담당자",150);
            grdResult.View.AddTextBoxColumn("날짜",150);

            grdResult.View.PopulateColumns();

        }
    }
}
