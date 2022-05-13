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

namespace Micube.SmartMES.Lot
{
    public partial class LotLabelReissue : SmartConditionBaseForm
    {
        public LotLabelReissue()
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
            grdList.GridButtonItem = GridButtonItem.All;
            grdList.View.GridMultiSelectionMode = GridMultiSelectionMode.CheckBoxSelect;
            grdList.View.SetIsReadOnly();

            grdList.View.AddTextBoxColumn("품목코드", 150);
            grdList.View.AddTextBoxColumn("품목명", 200);
            grdList.View.AddTextBoxColumn("작업장", 150);
            grdList.View.AddTextBoxColumn("공정", 150);
            grdList.View.AddTextBoxColumn("LOT NO.", 150);
            grdList.View.AddTextBoxColumn("LOCK", 150);
            grdList.View.AddTextBoxColumn("보류", 100);

            grdList.View.PopulateColumns();

        }
    }
}
