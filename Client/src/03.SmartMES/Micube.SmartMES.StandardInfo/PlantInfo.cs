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
    public partial class PlantInfo : SmartConditionBaseForm
    {
        public PlantInfo()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializePlantGrid();
        }

        private void InitializePlantGrid()
        {
            grdPlantInfo.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdPlantInfo.View.SetSortOrder("사업장");

            grdPlantInfo.View.AddTextBoxColumn("사업장", 150);
            grdPlantInfo.View.AddTextBoxColumn("공장", 150);
            grdPlantInfo.View.AddTextBoxColumn("작업장", 150);
            grdPlantInfo.View.AddTextBoxColumn("공정", 150);
            grdPlantInfo.View.AddTextBoxColumn("작업자그룹", 150);
            grdPlantInfo.View.AddTextBoxColumn("설비", 150);
            grdPlantInfo.View.AddTextBoxColumn("비고", 200);

            grdPlantInfo.View.PopulateColumns();
        }
    }
}
