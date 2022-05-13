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

namespace Micube.SmartMES.Status
{
    public partial class ERP : SmartConditionBaseForm
    {
        public ERP()
        {
            InitializeComponent();
        }

        protected override void InitializeContent()
        {
            base.InitializeContent();
            InitializeList();
        }

        private void InitializeList()
        {
            grdUse.GridButtonItem = GridButtonItem.All;
            grdUse.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdUse.View.SetIsReadOnly();

            grdUse.View.AddTextBoxColumn("ALL", 150);
            grdUse.View.AddTextBoxColumn("1月", 100);
            grdUse.View.AddTextBoxColumn("2月", 100);
            grdUse.View.AddTextBoxColumn("3月", 100);
            grdUse.View.AddTextBoxColumn("4月", 100);
            grdUse.View.AddTextBoxColumn("5月", 100);
            grdUse.View.AddTextBoxColumn("6月", 100);
            grdUse.View.AddTextBoxColumn("7月", 100);
            grdUse.View.AddTextBoxColumn("8月", 100);
            grdUse.View.AddTextBoxColumn("9月", 100);
            grdUse.View.AddTextBoxColumn("10月", 100);
            grdUse.View.AddTextBoxColumn("11月", 100);
            grdUse.View.AddTextBoxColumn("12月", 100);
            grdUse.View.AddTextBoxColumn("계", 100);

            grdUse.View.PopulateColumns();
        }
    }


}
