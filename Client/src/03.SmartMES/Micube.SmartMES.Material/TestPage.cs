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
    public partial class TestPage : SmartConditionBaseForm
    {
        public TestPage()
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
            //grdList.GridButtonItem = GridButtonItem.All;
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdList.View.SetSortOrder("AREACODE");                 //공정코드

            grdList.View.AddTextBoxColumn("AREACODE", 150)
                        .SetValidationKeyColumn()
                        .SetValidationIsRequired();


            grdList.View.PopulateColumns();
        }

        protected override void OnToolbarCustomClick(ToolbarClickEventArgs e)
        {
            base.OnToolbarCustomClick(e);
            TestPagePopup itemPopup = new TestPagePopup();
            itemPopup.ShowDialog(this);

        }

        private void smartLabelTextBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
