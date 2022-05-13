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
    public partial class TestPagePopup : SmartPopupBaseForm
    {
        public TestPagePopup()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            grdAreaList.GridButtonItem = GridButtonItem.Refresh;
            grdAreaList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdAreaList.View.SetSortOrder("AREACODE");

            grdAreaList.View.AddTextBoxColumn("AREACODE",150);
            grdAreaList.View.AddTextBoxColumn("AREANAMEKOR", 150);
            grdAreaList.View.AddTextBoxColumn("CREATOR", 150);
            grdAreaList.View.PopulateColumns();

        }
    }
}
