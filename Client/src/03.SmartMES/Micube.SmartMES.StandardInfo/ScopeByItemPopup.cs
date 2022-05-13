using Micube.Framework;
using Micube.Framework.Net;
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
    public partial class ScopeByItemPopup : SmartPopupBaseForm
    {
        public ScopeByItemPopup()
        {
            InitializeComponent();
            lnitializeGrid();
        }

        private void lnitializeGrid()
        {
            grdItem.GridButtonItem = GridButtonItem.Refresh;
            grdItem.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;

            grdItem.View.AddTextBoxColumn("ITEMID", 100)
                .SetValidationKeyColumn()
                .SetValidationIsRequired()
                .SetIsReadOnly(); ;
            grdItem.View.AddTextBoxColumn("ITEMNAME", 200);
            grdItem.View.AddTextBoxColumn("ITEMSTANDARD", 120);
            grdItem.View.AddTextBoxColumn("ITEMASSETCATEGORY", 80);
            grdItem.View.AddTextBoxColumn("DOMESTICFOREIGN", 80);

            grdItem.View.PopulateColumns();
        }

        private void search_Click(object sender, EventArgs e)
        {

            DataTable dtInfo = SqlExecuter.Query("GetItem", "00001");

            if (dtInfo.Rows.Count < 1)
            {
                ShowMessage("NoSelectData");
            }

            grdItem.DataSource = dtInfo;
        }

        private void select_Click(object sender, EventArgs e)
        {
            var selectRow = grdItem.View.GetDataRow(grdItem.View.FocusedRowHandle);
            ScopeByItem main = new ScopeByItem();
            
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
